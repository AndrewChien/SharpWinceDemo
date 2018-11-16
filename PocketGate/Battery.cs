using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace PocketGate
{
    class Battery
    {
        public static int Percent = 0;
        private static SYSTEM_POWER_STATUS_EX status = new SYSTEM_POWER_STATUS_EX();
        public static State StateNow = State.Normal;

        private class SYSTEM_POWER_STATUS_EX
        {
            public byte ACLineStatus = 0;
            public byte BatteryFlag = 0;
            public byte BatteryLifePercent = 0;
            public byte Reserved1 = 0;
            public uint BatteryLifeTime = 0;
            public uint BatteryFullLifeTime = 0;
            public byte Reserved2 = 0;
            public byte BackupBatteryFlag = 0;
            public byte BackupBatteryLifePercent = 0;
            public byte Reserved3 = 0;
            public uint BackupBatteryLifeTime = 0;
            public uint BackupBatteryFullLifeTime = 0;
        }
        public enum State
        {
            /// <summary>
            /// 充电中
            /// </summary>
            Charge,
            /// <summary>
            /// 充电不足
            /// </summary>
            UnderCharge,
            /// <summary>
            /// 正常状态
            /// </summary>
            Normal,
            /// <summary>
            /// 充电完成
            /// </summary>
            ChargeFinally
        };

        [DllImport("coredll")]
        private static extern int GetSystemPowerStatusEx(SYSTEM_POWER_STATUS_EX lpSystemPowerStatus, bool fUpdate);
        /// <summary>
        /// 获取电池状态
        /// </summary>
        public static void GetBatteryState()
        {
            if (GetSystemPowerStatusEx(status, false) == 1)
            {
                if (status.ACLineStatus == 1)
                {
                    //BatteryFlag = 128  充电完成
                    if (status.BatteryFlag == 128)
                    //if (status.BatteryLifePercent >= 100)
                    {
                        //status.BatteryLifePercent = 100;  //.BatteryFullLifeTime

                        StateNow = State.ChargeFinally;
                    }  //BatteryFlag = 8 正在充电
                    else
                    {
                        StateNow = State.Charge;

                    }
                }
                else
                {
                    //BatteryFlag = 1 正在使用电池
                    StateNow = State.Normal;
                    if (status.BatteryLifePercent > 100) status.BatteryLifePercent = 100;
                }

                Percent = status.BatteryLifePercent;
                if (Percent <= 20)
                {
                    StateNow = State.UnderCharge;

                }
 
            }
        }

    }
}
