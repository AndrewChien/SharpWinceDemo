using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Runtime.InteropServices;

namespace PocketGate
{
    class Ping
    {
        public static List<int> PingReply(string host)
        {
            var strs = host.Split('.');
            List<int?> list = new List<int?>();
            byte[] RequestData = Encoding.ASCII.GetBytes(new string('\0', 64));

            //Allocate ICMP_ECHO_REPLY structure
            ICMP_ECHO_REPLY reply = new ICMP_ECHO_REPLY(255);
            reply.DataSize = 255;
            IntPtr pData = LocalAlloc(LMEM_ZEROINIT, reply.DataSize);
            reply.Data = pData;
            IntPtr h = IcmpCreateFile();
            uint ipaddr = 256 * 256 * 256 * uint.Parse(strs[3]) +
              256 * 256 * uint.Parse(strs[2]) +
              256 * uint.Parse(strs[1]) +
              uint.Parse(strs[0]);

            for (int i = 0; i < 4; i++)
            {
                uint ret = IcmpSendEcho(h, ipaddr, RequestData, (short)RequestData.Length, IntPtr.Zero, reply._Data, reply._Data.Length, 1000);
                int dwErr = 0;
                if (ret == 0)
                {
                    dwErr = GetLastError();
                    list.Add(null);
                }
                else
                    if (dwErr != 11010)
                        list.Add(reply.RoundTripTime);
                    else
                        list.Add(null);
                System.Threading.Thread.Sleep(10);
            }
            IcmpCloseHandle(h);
            LocalFree(reply.Data);

            var nullCount = list.Count(a => a == null);
            double? ave = double.MaxValue;
            if (nullCount < 4)
                ave = list.Where(a => a != null).Average();
            int result = int.MinValue;
            switch (nullCount)
            {
                case 0:
                    {
                        if (ave < 10)
                            result = 4;
                        else
                            if (ave < 30)
                                result = 3;
                            else
                                if (ave < 100)
                                    result = 2;
                                else
                                    result = 1;
                    }
                    break;
                case 1:
                    {
                        if (ave < 30)
                            result = 3;
                        else
                            if (ave < 100)
                                result = 2;
                            else
                                result = 1;
                    }
                    break;
                case 2:
                    {
                        if (ave < 50)
                            result = 2;
                        else
                            result = 1;
                    }
                    break;
                case 3:
                    {
                        result = 1;
                    }
                    break;
                case 4:
                    result = 0;
                    break;
            }
            var values = new List<int>();

            values.Add(result);
            values.Add(nullCount);
            if (ave == double.MaxValue)
                values.Add(9999);
            else
                values.Add((int)ave);
            return values;
        }
        #region Memory Management
        [DllImport("coredll")]
        extern public static IntPtr LocalAlloc(int flags, int size);
        [DllImport("coredll")]
        extern public static IntPtr LocalFree(IntPtr pMem);

        const int LMEM_ZEROINIT = 0x40;

        #endregion


        #region IPHLPAPI P/Invokes
        [DllImport("iphlpapi")]
        extern public static IntPtr IcmpCreateFile();

        [DllImport("iphlpapi")]
        extern public static bool IcmpCloseHandle(IntPtr h);

        [DllImport("iphlpapi")]
        extern public static uint IcmpSendEcho(
                         IntPtr IcmpHandle,
                         uint DestinationAddress,
                         byte[] RequestData,
                         short RequestSize,
                         IntPtr /*IP_OPTION_INFORMATION*/ RequestOptions,
                         byte[] ReplyBuffer,
                         int ReplySize,
                         int Timeout);

        #endregion

        [DllImport("coredll")]
        extern static int GetLastError();

    }
    public class ICMP_ECHO_REPLY
    {
        public ICMP_ECHO_REPLY(int size) { data = new byte[size]; }
        byte[] data;
        public byte[] _Data { get { return data; } }
        public int Address { get { return BitConverter.ToInt32(data, 0); } }
        public int Status { get { return BitConverter.ToInt32(data, 4); } }
        public int RoundTripTime { get { return BitConverter.ToInt32(data, 8); } }
        public short DataSize { get { return BitConverter.ToInt16(data, 0xc); } set { BitConverter.GetBytes(value).CopyTo(data, 0xc); } }
        public IntPtr Data { get { return new IntPtr(BitConverter.ToInt32(data, 0x10)); } set { BitConverter.GetBytes(value.ToInt32()).CopyTo(data, 0x10); } }
        public byte Ttl { get { return data[0x14]; } }
        public byte Tos { get { return data[0x15]; } }
        public byte Flags { get { return data[0x16]; } }
        public byte OptionsSize { get { return data[0x17]; } }
        public IntPtr OptionsData { get { return new IntPtr(BitConverter.ToInt32(data, 0x18)); } set { BitConverter.GetBytes(value.ToInt32()).CopyTo(data, 0x18); } }
    }
}
