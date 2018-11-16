using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using PocketGate.Helper;
using Newtonsoft.Json;
using System.Resources;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace PocketGate
{
    public partial class MainForm : Form
    {
        DateTime StartDate = DateTime.Now;
        int ClickCount = 0;
        int TicketCount = 0;
        bool CtrlPressed = false;
        Configuration Config = null;
        List<byte> input = new List<byte>();

        [DllImport("coredll.dll")]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, IntPtr lParam);

        public MainForm()
        {
            InitializeComponent();
            FullScreen.HideHHTaskBar();
            this.WindowState = FormWindowState.Maximized;
            Config = Configuration.ReadConfig();
            if (Config == null)
                this.Close();
            lbl_Logo.Text = Config.ScenicSpots;
            pnl_Card_Yes.Visible = pnl_Card_No.Visible = pnl_Valid.Visible = pnl_Invalid.Visible = false;
            pnl_Card_Yes.Location = pnl_Card_No.Location =
                pnl_Valid.Location = pnl_Invalid.Location = pnl_General.Location;
            pnl_General.Visible = true;
            Tmr_Refresh.Enabled = true;
            this.Tmr_Refresh_Tick(Tmr_Refresh, null);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //const uint HWND_BROADCAST = 0xffff;
            //const uint WM_APP = 0x8000;
            //const uint WM_WZCSYSTRAYICON = WM_APP + 100;
            //const uint WM_LBUTTONDBLCLK = 0x0203;
            //PostMessage((IntPtr)HWND_BROADCAST, WM_WZCSYSTRAYICON, 1, (IntPtr)WM_LBUTTONDBLCLK);

        }

        private void Form1_Closed(object sender, EventArgs e)
        {
            FullScreen.ShowHHTaskBar();
        }

        /// <summary>
        /// 背景控件框调整大小事件绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            pic_BackImage.Width = this.Width;
            pic_BackImage.Height = this.Height + 200;
        }

        #region 检测输入逻辑

        /// <summary>
        /// 检测输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DateTime.Now.Date != StartDate.Date)
            {
                TicketCount = 0;
                StartDate = DateTime.Now;
            }
            //检测回车键 13 CR
            if (e.KeyChar != (char)13)
                input.Add((byte)e.KeyChar);
            else
            {
                var str = Encoding.Default.GetString(input.ToArray(), 0, input.Count);
                Check(str);
                input.Clear();
            }
        }

        /// <summary>
        /// 根据输入字符串选择市民卡或检票
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        private TicketInfo Check(string no)
        {
            Tmr_Count_Dispose();

            try
            {
                if (!string.IsNullOrEmpty(no) && no.Length > 50)
                {
                    CheckCityCard(no);
                    return new TicketInfo();
                }

                bool isVerifyTicketSuccess = false;
                var ticket = VerifyTicketByTicketNo(no, out isVerifyTicketSuccess);
                if (ticket == null)
                {
                    lbl_TicketNo_Invalid.Text = no;
                    pnl_General.Visible = true;
                    pnl_Valid.Visible = false;
                    pnl_Invalid.Visible = false;
                    pic_Invalid.Image = null;
                }
                else
                {
                    if (isVerifyTicketSuccess)
                    {
                        lbl_TicketNo.Text = ticket.TicketNo;
                        lbl_TicketName.Text = ticket.Name;
                        lbl_TickType.Text = ticket.TicketType;
                        lbl_TicketNumber.Text = ticket.Number;
                        lbl_TicketSellTime.Text = ticket.SellTime;
                        lbl_TicketPrice.Text = ticket.Price;
                        lbl_TicketValid.Text = "有效";
                        lbl_TicketVerifyTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                        lbl_TicketVerifyGate.Text = Config.GateName;

                        pnl_General.Visible = false;
                        pnl_Valid.Visible = true;
                        pnl_Invalid.Visible = false;

                        TicketCount++;
                        lbl_HasCount.Text = TicketCount.ToString();
                    }
                    else
                    {
                        lbl_TicketNo_Invalid.Text = no;
                        pnl_General.Visible = false;
                        pnl_Valid.Visible = false;
                        pnl_Invalid.Visible = true;
                        pic_Invalid.Image = ticket.ShowImg;
                    }
                    pic_Invalid.Refresh();
                    if (!string.IsNullOrEmpty(ticket.Music))
                        SoundHelper.Play(ticket.Music);
                }
                Tmr_Count.Enabled = true;
                return ticket;
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败，可能网络异常\r\n或服务未启动，请稍后再试!", "网络异常");
                return null;
            }
        }

        #endregion

        #region 检票逻辑

        /// <summary>
        /// 检票
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        private TicketInfo VerifyTicketByTicketNo(string no, out bool isVerifyTicketSuccess)
        {
            isVerifyTicketSuccess = false;
            if (string.IsNullOrEmpty(no))
            {
                MessageBox.Show("没有读取到票号信息", "扫码异常");
                return null;
            }

            var vTicket = new VerifyTicket()
            {
                gateId = Config.GateName,
                ticketNo = no
            };

            var apiResult = VerifyTicketHelper.VerifyTicket(vTicket, Config.WebUrl);
            if (apiResult == null)
            {
                MessageBox.Show("没有获取到服务端的返回数据", "网络异常");
                return null;
            }

            isVerifyTicketSuccess = apiResult.flag;
            return GetTicketInfo(apiResult);
        }

        /// <summary>
        /// 通过检票接口服务返回的对象构造TicketInfo
        /// </summary>
        /// <param name="apiResult"></param>
        /// <returns></returns>
        private TicketInfo GetTicketInfo(ApiResult<selled_ticket> apiResult)
        {
            if (apiResult == null) return null;
            Bitmap showImg = null;
            var music = GetMusicName(apiResult, out showImg);
            TicketInfo result = new TicketInfo
            {
                Error = apiResult.msg,
                Music = music,
                ShowImg = showImg
            };

            if (apiResult.flag && apiResult.oData != null)
            {
                result.TicketNo = apiResult.oData.TicketNo;
                result.TicketType = GetTicketTypeName(apiResult.oData.TicketName);
                result.Name = apiResult.oData.TicketName;
                result.Price = apiResult.oData.TicketPayPrice.ToString("F2");
                result.SellTime = apiResult.oData.TicketSellTime.ToString("yyyy-MM-dd HH:mm:ss");
                result.Number = apiResult.oData.TicketLimitPerson.ToString();
            }

            return result;
        }

        /// <summary>
        /// 构造语音名称和显示图片名称
        /// </summary>
        /// <param name="apiResult"></param>
        /// <param name="showImg"></param>
        /// <returns></returns>
        private string GetMusicName(ApiResult<selled_ticket> apiResult, out Bitmap showImg)
        {
            showImg = Properties.Resources.无效票;
            string result = string.Empty;
            if (apiResult == null) return result;

            if (apiResult.flag)
            {
                if (apiResult.oData != null)
                {
                    if (apiResult.oData.TicketName.Contains("全价"))
                        result = "ATicket.wav";
                    if (apiResult.oData.TicketName.Contains("半价"))
                        result = "BTicket.wav";
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(apiResult.msg))
                {
                    switch (apiResult.msg)
                    {
                        case "验票失败：该票不存在":
                            result = "NoRec_OVER_OutTTicket.wav";
                            showImg = Properties.Resources.无效票;
                            break;
                        case "验票失败：该票已经使用":
                            result = "AEnterTicket.wav";
                            showImg = Properties.Resources.已使用;
                            break;
                        case "验票失败：该票已经作废":
                            result = "NoRec_OVER_OutTTicket.wav";
                            showImg = Properties.Resources.无效票;
                            break;
                        case "验票失败：该票不适用于该景点":
                            result = "NoRec_OVER_OutTTicket.wav";
                            showImg = Properties.Resources.无效票;
                            break;
                        case "验票失败：该票在该景点已经使用":
                            result = "AEnterTicket.wav";
                            showImg = Properties.Resources.已使用;
                            break;
                        case "验票失败：未到使用时间":
                            result = "NoToDayTicket.wav";
                            showImg = Properties.Resources.未到期;
                            break;
                        case "验票失败：已过期":
                            result = "OVERTicket.wav";
                            showImg = Properties.Resources.已过期;
                            break;
                        default:
                            result = "NoRec_OVER_OutTTicket.wav";
                            showImg = Properties.Resources.无效票;
                            break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 获取票型名称
        /// </summary>
        /// <param name="ticketName"></param>
        /// <returns></returns>
        private static string GetTicketTypeName(string ticketName)
        {
            if (string.IsNullOrEmpty(ticketName)) return ticketName;

            string result = ticketName;
            string pattern = @"\(.*?\)";//匹配模式
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(ticketName);
            foreach (Match match in matches)
            {
                result = match.Value.Trim('(', ')');
                break;
            }

            return result;
        }

        #endregion

        #region 定时器相关

        private void Tmr_Clock_Tick(object sender, EventArgs e)
        {
            lbl_Date.Text = DateTime.Now.ToString("yyyy-MM-dd 星期ddd");
            lbl_Time.Text = DateTime.Now.ToString("HH:mm:ss");
            //pic_BackImage.Refresh();
        }

        private void Tmr_Refresh_Tick(object sender, EventArgs e)
        {
            Battery.GetBatteryState();
            var status = Battery.StateNow;
            var percent = Battery.Percent;
            switch (status)
            {
                case Battery.State.Charge:
                    {
                        if (percent < 40)
                            pic_Battery.Image = Properties.Resources.bc20;
                        else
                            if (percent < 60)
                                pic_Battery.Image = Properties.Resources.bc40;
                            else
                                if (percent < 80)
                                    pic_Battery.Image = Properties.Resources.bc60;
                                else
                                    if (percent < 95)
                                        pic_Battery.Image = Properties.Resources.bc80;
                                    else
                                        pic_Battery.Image = Properties.Resources.bc100;
                    }
                    break;
                case Battery.State.ChargeFinally:
                    pic_Battery.Image = Properties.Resources.bc100;
                    break;
                case Battery.State.Normal:
                    {
                        if (percent < 20)
                            pic_Battery.Image = Properties.Resources.b0;
                        else
                            if (percent < 40)
                                pic_Battery.Image = Properties.Resources.b20;
                            else
                                if (percent < 60)
                                    pic_Battery.Image = Properties.Resources.b40;
                                else
                                    if (percent < 80)
                                        pic_Battery.Image = Properties.Resources.b60;
                                    else
                                        if (percent < 95)
                                            pic_Battery.Image = Properties.Resources.b80;
                                        else
                                            pic_Battery.Image = Properties.Resources.b100;
                    }
                    break;
                case Battery.State.UnderCharge:
                    pic_Battery.Image = Properties.Resources.b0;
                    break;
            }
            Uri uri = new Uri(Config.WebUrl);
            var list = Ping.PingReply(uri.Host);
            var ping = list[0];
            lbl_WifiString.Text = list[1] + "," + list[2];
            switch (ping)
            {
                case 0:
                    pic_Wifi.Image = Properties.Resources.wifi0;
                    break;
                case 1:
                    pic_Wifi.Image = Properties.Resources.wifi1;
                    break;
                case 2:
                    pic_Wifi.Image = Properties.Resources.wifi2;
                    break;
                case 3:
                    pic_Wifi.Image = Properties.Resources.wifi3;
                    break;
                case 4:
                    pic_Wifi.Image = Properties.Resources.wifi4;
                    break;
            }
        }

        private void Tmr_Count_Tick(object sender, EventArgs e)
        {
            int count = int.Parse(lbl_Valid_Count.Text);

            if (count >= 0)
                count--;
            if (count < 0)
            {
                Tmr_Count_Dispose();
                return;
            }
            lbl_Card_No_Count.Text = lbl_Card_Yes_Count.Text =
                lbl_Valid_Count.Text = lbl_Invalid_Count.Text = count.ToString();
            lbl_Valid_Count.Refresh();
            lbl_Invalid_Count.Refresh();
            lbl_Card_No_Count.Refresh();
            lbl_Card_Yes_Count.Refresh();

        }

        /// <summary>
        /// 释放定时器资源
        /// </summary>
        private void Tmr_Count_Dispose()
        {
            Tmr_Count.Enabled = false;
            pnl_General.Visible = true;
            pnl_Card_Yes.Visible = pnl_Card_No.Visible = pnl_Invalid.Visible = pnl_Valid.Visible = false;
            lbl_Card_Yes_Count.Text = lbl_Card_No_Count.Text
                = lbl_Valid_Count.Text = lbl_Invalid_Count.Text = "20";
        }

        #endregion

        #region 市民卡相关

        /// <summary>
        /// 手持设备扫描市民卡二维码入口函数
        /// </summary>
        /// <param name="qcode"></param>
        private void CheckCityCard(string qcode)
        {
            if (string.IsNullOrEmpty(qcode)) return;

            var cityCard = GetCityCardQCode(qcode);
            if (cityCard == null)
            {
                ShowCardMessage("二维码格式错误");
            }
            else if (cityCard.start_time > DateTime.Now || cityCard.end_time <= DateTime.Now)
            {
                ShowCardMessage("此二维码已经过期");
            }
            else if (string.IsNullOrEmpty(cityCard.card_no))
            {
                ShowCardMessage("没有扫描到市民卡信息");
            }
            else
            {
                VerifyTicketByCardNo(cityCard.card_no);
            }

            Tmr_Count.Enabled = true;
        }

        /// <summary>
        /// 将市民卡二维码转换为对象
        /// </summary>
        /// <param name="qcode"></param>
        /// <returns></returns>
        private CityCardQCode GetCityCardQCode(string qcode)
        {
            if (string.IsNullOrEmpty(qcode)) return null;

            var tmp = Common.DesHelper.Decrypt3Des(Config.DesKey, qcode);
            if (string.IsNullOrEmpty(tmp)) return null;

            return JsonConvert.DeserializeObject<CityCardQCode>(tmp);
        }

        /// <summary>
        /// 市民卡检票
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        private void VerifyTicketByCardNo(string cardNo)
        {
            var vTicket = new VerifyTicket()
            {
                gateId = Config.GateName,
                citizenCard = cardNo,
                isfingerprint = "1"
            };

            var apiResult = VerifyTicketHelper.VerifyTicket(vTicket, Config.WebUrl);
            if (apiResult == null)
            {
                MessageBox.Show("没有获取到服务端的返回数据", "网络异常");
                return;
            }

            if (apiResult.flag)
            {
                var person = VerifyTicketHelper.GetCitizenCardPerson(cardNo, Config.WebUrl);
                ShowCardInfo(cardNo
                    , apiResult.oData
                    , person == null ? new CitizenCardPerson() : person.oData);
            }
            else
            {
                if (string.IsNullOrEmpty(apiResult.msg))
                    apiResult.msg = "检票失败";

                ShowCardMessage(apiResult.msg);
            }
        }

        /// <summary>
        /// 显示市民卡信息（检票成功）
        /// </summary>
        /// <param name="cardNo"></param>
        /// <param name="apiResult"></param>
        /// <param name="person"></param>
        private void ShowCardInfo(string cardNo
            , selled_ticket selledTicket
            , CitizenCardPerson person)
        {
            if (selledTicket == null) selledTicket = new selled_ticket();
            if (person == null) person = new CitizenCardPerson();
            if (!pnl_Card_Yes.Visible) pnl_Card_Yes.Visible = true;
            lbl_Card_Yes_Num.Text = cardNo;
            lbl_Card_Yes_Name.Text = person.name;
            lbl_Card_Yes_PayType.Text =
                selledTicket.TicketPayPrice == 0 ? "年卡" : "直接扣费";
            lbl_Card_Yes_Price.Text = selledTicket.TicketPayPrice.ToString();
            lbl_Card_Yes_YouXiao.Text = selledTicket.TicketEndTime.ToString("yyyy年MM月dd日");

            ShowCardPersonPhono(person.photo);
        }

        /// <summary>
        /// 显示照片
        /// </summary>
        /// <param name="phono"></param>
        private void ShowCardPersonPhono(string phono)
        {
            if (string.IsNullOrEmpty(phono)) return;

            try
            {

                byte[] arr = Convert.FromBase64String(phono);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);
                ms.Close();
                pbx__Card_Yes_Phono.Image = bmp;
            }
            catch (Exception e)
            {

            }
        }

        /// <summary>
        /// 显示市民卡扫码消息
        /// </summary>
        /// <param name="msg"></param>
        private void ShowCardMessage(string msg)
        {
            if (!pnl_Card_No.Visible) pnl_Card_No.Visible = true;
            lbl_Card_No_Msg.Text = msg;
        }

        #endregion

        #region 退出程序后门

        /// <summary>
        /// 退出程序后门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pic_Logo_Click(object sender, EventArgs e)
        {
            if (++ClickCount >= 2 && CtrlPressed)
                this.Close();
        }

        /// <summary>
        /// 跟踪ctrl键弹起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (((int)e.KeyCode).ToString() == "212")
                CtrlPressed = false;
        }

        /// <summary>
        /// 跟踪ctrl键按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (((int)e.KeyCode).ToString() == "212")
                CtrlPressed = true;

        }

        #endregion

        #region 弃用

        public static string WebResponseGet(HttpWebRequest webRequest)
        {
            StreamReader responseReader = null;
            string responseData = "";
            try
            {
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                responseData = responseReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                return "连接错误:" + ex.Message;
            }
            finally
            {
                webRequest.GetResponse().GetResponseStream().Close();
                responseReader.Close();
                responseReader = null;
            }
            return responseData;
        }

        #endregion
    }
}