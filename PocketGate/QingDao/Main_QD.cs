using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PocketGate.Helper;
using System.Text.RegularExpressions;
using Microsoft.WindowsCE.Forms;
using System.Runtime.InteropServices;
using PocketGate.Common;
using System.Threading;
using System.IO;
//using Microsoft.Win32;

namespace PocketGate.QingDao
{
    public partial class Main_QD : Form
    {
        Configuration Config = null;
        int ClickCount = 0;
        bool CtrlPressed = false;
        bool ScanNow = false;
        List<byte> input = new List<byte>();
        TokenStyle LoginToken;//服务器登录令牌
        protected string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);//获取路径
        Thread tBusy;
        private void ThreadCallBusy(string s)
        {
            new Splash(s).ShowDialog();
        }
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private int timercount = 0;
        bool ScanCountSwitch = false;//退回扫码检票页标记
        bool ManulCountSwitch = false;//退回人工检票页标记
        int timedelay = 10;

        /// <summary>
        /// 创建桌面快捷方式
        /// </summary>
        private void CreateDesktopIcon()
        {
            string PathGPRS = appPath + "\\PocketGate.exe";
            string PathGPRSTrue = Config.ShotCutPath;
            if (!File.Exists(PathGPRSTrue))
            {
                //File.Copy(PathGPRS, PathGPRSTrue, true);
                try
                {
                    string text = (PathGPRS.Length + 2).ToString() + "#\"" + PathGPRS + "\"";
                    byte[] buf = new byte[text.Length];
                    buf = System.Text.Encoding.GetEncoding(936).GetBytes(text.Substring(0, text.Length));
                    FileStream fs = new FileStream(PathGPRSTrue, FileMode.CreateNew);
                    fs.Write(buf, 0, buf.Length);
                    fs.Close();
                    fs = null;
                }
                catch (System.Exception ex)
                {
                }
            }
        }

        ///// <summary>
        ///// 更改注册表  设置程序非自动运行
        ///// </summary>
        ///// <returns></returns>
        //public static bool SetRegeditForRun()
        //{
        //    RegEdit regedit = new RegEdit();
        //    int bError = regedit.WriteValue(RegEdit.HKEY.HKEY_LOCAL_MACHINE, "init", "Launch50", @"explorer.exe", RegistryValueKind.String);//Wince注册表HKEY_LOCAL_MACHINE\init\Launch50默认启动explorer.exe桌面运行程序，将它改成自己的exe即可(绝对路径)
        //    if (bError > 0)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        public Main_QD()
        {
            InitializeComponent();

            #region 以下加载窗体贴图（取消）
            ////以下加载登录页
            //this.picLoginMain.Image = new Bitmap(appPath + @"\Pics\login.png");//\Program Files\PocketGate\Pics\login.png
            //this.picLogin.Image = new Bitmap(appPath + @"\Pics\loginbtn.png");
            ////以下加载检票选择页
            //this.picCheckMain.Image = new Bitmap(appPath + @"\Pics\chkmain.png");//\Program Files\PocketGate\Pics\login.png
            //this.pic_auto.Image = new Bitmap(appPath + @"\Pics\chkmainbtn.png");
            //this.pic_manul.Image = new Bitmap(appPath + @"\Pics\chkmainbtn.png");
            //this.pic_logout1.Image = new Bitmap(appPath + @"\Pics\chkmaincancel.png");
            ////以下加载人工检票页
            //this.picCheckManul.Image = new Bitmap(appPath + @"\Pics\chkent.png");//\Program Files\PocketGate\Pics\login.png
            //this.picDo.Image = new Bitmap(appPath + @"\Pics\chkentchk.png");
            //this.picBackMain1.Image = new Bitmap(appPath + @"\Pics\tckback.png");
            //this.pic_logout2.Image = new Bitmap(appPath + @"\Pics\chkentcancel.png");
            ////以下加载扫码检票页
            //this.picCheckScan.Image = new Bitmap(appPath + @"\Pics\chkscn.png");//\Program Files\PocketGate\Pics\login.png
            //this.picBackMain2.Image = new Bitmap(appPath + @"\Pics\tckback.png");
            //this.pic_logout3.Image = new Bitmap(appPath + @"\Pics\chkentcancel.png");
            ////以下加载扫码检票失败页（弃用）
            //this.picCRAF.Image = new Bitmap(appPath + @"\Pics\tckflr.png");//\Program Files\PocketGate\Pics\login.png
            //this.picBackAuto1.Image = new Bitmap(appPath + @"\Pics\tckback.png");
            //this.pic_logout4.Image = new Bitmap(appPath + @"\Pics\chkentcancel.png");
            ////以下加载扫码检票成功页
            //this.picCRAS.Image = new Bitmap(appPath + @"\Pics\tcksuc.png");//\Program Files\PocketGate\Pics\login.png
            //this.picBackAuto2.Image = new Bitmap(appPath + @"\Pics\tckback.png");
            //this.pic_logout5.Image = new Bitmap(appPath + @"\Pics\chkentcancel.png");
            ////以下加载人工检票失败页（弃用）
            //this.picCREF.Image = new Bitmap(appPath + @"\Pics\tckflrent.png");//\Program Files\PocketGate\Pics\login.png
            //this.picDo1.Image = new Bitmap(appPath + @"\Pics\chkentchk.png");
            //this.picBackHand1.Image = new Bitmap(appPath + @"\Pics\tckback.png");
            //this.pic_logout6.Image = new Bitmap(appPath + @"\Pics\chkentcancel.png");
            ////以下加载人工检票成功页
            //this.picCRES.Image = new Bitmap(appPath + @"\Pics\tcksucent.png");//\Program Files\PocketGate\Pics\login.png
            //this.picDo2.Image = new Bitmap(appPath + @"\Pics\chkentchk.png");
            //this.picBackHand2.Image = new Bitmap(appPath + @"\Pics\tckback.png");
            //this.pic_logout7.Image = new Bitmap(appPath + @"\Pics\chkentcancel.png");
            ////以下加载扫码检票失败页
            //this.pic_ChkFail_Scan.Image = new Bitmap(appPath + @"\Pics\ScanFailure.png");//\Program Files\PocketGate\Pics\login.png
            //this.picBackAuto3.Image = new Bitmap(appPath + @"\Pics\tckback.png");
            //this.pic_logout8.Image = new Bitmap(appPath + @"\Pics\chkentcancel.png");
            ////以下加载人工检票失败页
            //this.pic_ChkFail_Manul.Image = new Bitmap(appPath + @"\Pics\ManulFailure.png");//\Program Files\PocketGate\Pics\login.png
            //this.picDo3.Image = new Bitmap(appPath + @"\Pics\chkentchk.png");
            //this.picBackHand3.Image = new Bitmap(appPath + @"\Pics\tckback.png");
            //this.pic_logout9.Image = new Bitmap(appPath + @"\Pics\chkentcancel.png");
            #endregion
        }

        private void Main_QD_Load(object sender, EventArgs e)
        {
            try
            {
                ThreadStart starter = delegate { ThreadCallBusy("正在启动..."); };
                tBusy = new Thread(starter);
                tBusy.Start();
                //隐藏输入法
                ImmDisableIME(0);
                //隐藏任务栏
                FullScreen.HideHHTaskBar();
                this.WindowState = FormWindowState.Maximized;
                Config = Configuration.ReadConfig();
                if (Config == null)
                {
                    MessageBox.Show("配置文件丢失！", "提示");
                    if (tBusy != null)
                        tBusy.Abort();
                    Close();
                }
                //创建桌面快速启动图标
                CreateDesktopIcon();
                //读登录页设备码和用户名
                txtDevice.Text = Config.DeviceCode;
                txtUsr.Text = Config.UserName;
                timer.Tick += new EventHandler(timer_Tick);
                timer.Interval = 1000;
                timer.Enabled = true;
                timedelay = int.Parse(Config.ReturnDelay);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "严重错误即将关闭");
                Close();
            }
            finally
            {
                if (tBusy != null)
                    tBusy.Abort();
            }
        }

        /// <summary>
        /// 检票成功或失败页10秒自动回退到检票正页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (ScanCountSwitch)
            {
                timercount++;
                if (timercount > timedelay)
                    LoadCheckScan(true);
            }
            else if (ManulCountSwitch)
            {
                timercount++;
                if (timercount > timedelay)
                    LoadCheckManul(true);
            }
        }

        private void Main_QD_Closed(object sender, EventArgs e)
        {
            FullScreen.ShowHHTaskBar();
            timer.Enabled = false;
            timer.Dispose();
        }

        private void Main_QD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ScanNow)//扫码页
            {
                //检测回车键 13 CR
                if (e.KeyChar != (char)13)
                {
                    input.Add((byte)e.KeyChar);
                }
                else
                {
                    var str = Encoding.Default.GetString(input.ToArray(), 0, input.Count);
                    ScanCheck(str);
                    input.Clear();
                }
            }
        }

        #region 检票逻辑

        /// <summary>
        /// 扫码检票
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        private TicketInfo_QD ScanCheck(string no)
        {
            ScanNow = false;
            bool isVerifyTicketSuccess = false;
            try
            {
                var ticket = VerifyTicketByTicketNo(no, out isVerifyTicketSuccess);
                if (ticket == null)
                {
                    //扫码失败
                    LoadChkFail_Scan(ticket.Error, true);
                }
                else
                {
                    if (isVerifyTicketSuccess)
                    {
                        //扫码成功
                        LoadCRAS(true);
                        lbl_autsc_TckName.Text = ticket.TicketTypeName;//票种名称
                        lbl_autsc_TckProp.Text = ticket.TicketMode;//票种属性
                        lbl_autsc_Name.Text = ticket.VisitorName;//游客姓名
                        lbl_autsc_ID.Text = ticket.IdCardNo;//身份证号码
                        lbl_autsc_OutWay.Text = ticket.PeopleNum > 1 ? "一票多人" : "一票一人";//出票方式
                        lbl_autsc_Num.Text = ticket.PeopleNum.ToString();//通行人数
                        lbl_autsc_UseDate.Text = ticket.TicketStartTime.Date.ToString("yyyy-MM-dd") + "~" + ticket.TicketEndTime.Date.ToString("yyyy-MM-dd");//检票有效期
                        lbl_autsc_PlayDate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");//游玩时间
                    }
                    else
                    {
                        //扫码失败
                        LoadChkFail_Scan(ticket.Error, true);
                    }
                    if (!string.IsNullOrEmpty(ticket.Music))
                        SoundHelper.Play(ticket.Music);
                }
                return ticket;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
                return null;
            }
            finally
            {
                ScanNow = true;
            }
        }

        /// <summary>
        /// 人工检票
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        private TicketInfo_QD VerifyTicketByTicketNo(string no, out bool isVerifyTicketSuccess)
        {
            try
            {
                isVerifyTicketSuccess = false;
                ThreadStart starter = delegate { ThreadCallBusy("正在检票..."); };
                tBusy = new Thread(starter);
                tBusy.Start();
                if (string.IsNullOrEmpty(no))
                {
                    throw new Exception("没有读取到票号信息");
                }
                var vTicket = new VerifyTicket_QD()
                {
                    ticketNo = no,
                    deviceCode = Config.DeviceCode,
                    deviceIP = SysInfo.GetIpAddress(),
                    deviceMAC = SysInfo.GetMac()
                };
                var apiResult = VerifyTicketHelper.VerifyTicket_QD(vTicket, Config.WebUrl, LoginToken);//请求api
                if (apiResult == null)
                {
                    throw new Exception(apiResult.msg);
                }
                isVerifyTicketSuccess = apiResult.isSuc;
                return GetTicketInfo_QD(apiResult);//有数据进行序列化
            }
            catch(Exception ex)
            {
                if (ex.Message.Contains("无法连接到服务器"))
                {
                    MessageBox.Show("连接超时，请重新登录！", "提示");
                    LoadLogin(true);
                }
                throw ex;
            }
            finally
            {
                if (tBusy != null)
                    tBusy.Abort();
            }
        }

        /// <summary>
        /// 序列化结果
        /// </summary>
        /// <param name="apiResult"></param>
        /// <returns></returns>
        private TicketInfo_QD GetTicketInfo_QD(ApiResult_QD<VerifyTicketResult_QD> apiResult)
        {
            if (apiResult == null) return null;
            var music = GetMusicName_QD(apiResult);//附加音频
            TicketInfo_QD result = new TicketInfo_QD
            {
                Error = apiResult.msg,
                Music = music
            };
            if (apiResult.isSuc && apiResult.Data != null)
            {
                result.TicketNo = apiResult.Data.TicketNo;
                result.TicketTypeName = apiResult.Data.TicketTypeName;
                result.TicketMouldName = apiResult.Data.TicketMouldName;
                result.Price = decimal.Parse(apiResult.Data.Price.ToString("F2"));
                result.PeopleNum = apiResult.Data.PeopleNum;
                result.TicketStartTime = apiResult.Data.TicketStartTime;
                result.TicketEndTime = apiResult.Data.TicketEndTime;
                result.Days = apiResult.Data.Days;
                result.VisitorName = apiResult.Data.VisitorName;
                result.IdCardNo = apiResult.Data.IdCardNo;
                result.IcCardName = apiResult.Data.IcCardName;
                result.IcCardNo = apiResult.Data.IcCardNo;
                result.SoundIndex = apiResult.Data.SoundIndex;
                result.Photo = apiResult.Data.Photo;
                result.TicketMode = apiResult.Data.TicketMode;
            }
            return result;
        }

        /// <summary>
        /// 附加音频文件
        /// </summary>
        /// <param name="apiResult"></param>
        /// <param name="showImg"></param>
        /// <returns></returns>
        private string GetMusicName_QD(ApiResult_QD<VerifyTicketResult_QD> apiResult)
        {
            string result = string.Empty;
            if (apiResult == null) return result;

            if (apiResult.isSuc)//api返回成功
            {
                if (apiResult.Data != null)
                {
                    result = "检票成功.wav";
                }
            }
            else//api返回失败
            {
                if (!string.IsNullOrEmpty(apiResult.msg))
                {
                    if (apiResult.msg.Contains("没有找到门票信息"))
                    {
                        result = "没有门票信息.wav";
                    }
                    else if (apiResult.msg.Contains("门票状态不可用"))
                    {
                        result = "门票状态不可用.wav";
                    }
                    else if (apiResult.msg.Contains("门票已退票"))
                    {
                        result = "门票已退票.wav";
                    }
                    else if (apiResult.msg.Contains("门票已作废"))
                    {
                        result = "门票已作废.wav";
                    }
                    else if (apiResult.msg.Contains("门票已过期"))
                    {
                        result = "门票已过期.wav";
                    }
                    else if (apiResult.msg.Contains("门票可检票次数不够"))
                    {
                        result = "门票可检票次数不够.wav";
                    }
                    else if (apiResult.msg.Contains("门票已使用"))
                    {
                        result = "门票已使用.wav";
                    }
                    else if (apiResult.msg.Contains("不能在当前景点使用"))
                    {
                        result = "门票不可用.wav";
                    }
                    else
                    {
                        result = "门票不可用.wav";
                    }
                }
            }

            return result;
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

        #region LoadForm界面调整

        /// <summary>
        /// 登录页
        /// </summary>
        /// <param name="clrcache">true则清界面控件内容，false不清除</param>
        private void LoadLogin(bool clrcache)
        {
            ScanCountSwitch = false;
            ManulCountSwitch = false;
            timercount = 0;
            ScanNow = false;
            panel1.Location = new Point(0, 0);
            panel1.BringToFront();
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            ShowHideSoftKeyBoard(false);
            //清空变量
            if (clrcache)
            {
                txtPwd.Text = "";
                lblErr.Text = "";
            }
            picLogin.Focus();
        }

        /// <summary>
        /// 检票选择页
        /// </summary>
        private void LoadCheckMain(bool clrcache)
        {
            ScanCountSwitch = false;
            ManulCountSwitch = false;
            timercount = 0;
            ScanNow = false;
            panel2.Location = new Point(0, 0);
            panel2.BringToFront();
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            ShowHideSoftKeyBoard(false);
            pic_auto.Focus();
        }

        /// <summary>
        /// 人工检票页
        /// </summary>
        private void LoadCheckManul(bool clrcache)
        {
            ScanCountSwitch = false;
            ManulCountSwitch = false;
            timercount = 0;
            ScanNow = false;
            panel3.Location = new Point(0, 0);
            panel3.BringToFront();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            ShowHideSoftKeyBoard(false);
            //清空变量
            if (clrcache)
            {
                txtChk.Text = "";
            }
            picDo.Focus();
        }

        /// <summary>
        /// 扫码检票页
        /// </summary>
        private void LoadCheckScan(bool clrcache)
        {
            ScanCountSwitch = false;
            ManulCountSwitch = false;
            timercount = 0;
            ScanNow = true;
            panel4.Location = new Point(0, 0);
            panel4.BringToFront();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            ShowHideSoftKeyBoard(false);
        }

        /// <summary>
        /// 扫码检票成功页
        /// </summary>
        private void LoadCRAS(bool clrcache)
        {
            ScanCountSwitch = true;
            ManulCountSwitch = false;
            timercount = 0;
            ScanNow = true;
            panel6.Location = new Point(0, 0);
            panel6.BringToFront();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            ShowHideSoftKeyBoard(false);
        }

        /// <summary>
        /// 人工检票成功页
        /// </summary>
        private void LoadCRES(bool clrcache)
        {
            ScanCountSwitch = false;
            ManulCountSwitch = true;
            timercount = 0;
            ScanNow = false;
            panel8.Location = new Point(0, 0);
            panel8.BringToFront();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = true;
            panel9.Visible = false;
            panel10.Visible = false;
            ShowHideSoftKeyBoard(false);
            //清空变量
            if (clrcache)
            {
                txtChk2.Text = "";
            }
            picDo2.Focus();
        }

        /// <summary>
        /// 加载扫码失败页
        /// </summary>
        /// <param name="msg"></param>
        private void LoadChkFail_Scan(string msg, bool clrcache)
        {
            ScanCountSwitch = true;
            ManulCountSwitch = false;
            timercount = 0;
            ScanNow = true;
            panel9.Location = new Point(0, 0);
            panel9.BringToFront();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = true;
            panel10.Visible = false;
            ShowHideSoftKeyBoard(false);
            //清空变量
            if (clrcache)
            {
                lbl_msg_scan.Text = msg;
            }
        }

        /// <summary>
        /// 人工检票失败页
        /// </summary>
        /// <param name="msg"></param>
        private void LoadChkFail_Manul(string msg, bool clrcache)
        {
            ScanCountSwitch = false;
            ManulCountSwitch = true;
            timercount = 0;
            ScanNow = false;
            panel10.Location = new Point(0, 0);
            panel10.BringToFront();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = true;
            ShowHideSoftKeyBoard(false);
            //清空变量
            if (clrcache)
            {
                txtChk3.Text = "";
                lbl_msg_scan.Text = msg;
            }
            picDo3.Focus();
        }

        private void ResetSwitch_TextChanged(object sender, EventArgs e)
        {
            //重置返回人工检票主页面的时间
            timercount = 0;
        }

        #endregion

        #region 按钮事件

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picLogin_Click(object sender, EventArgs e)
        {
            picLogin.Enabled = false;
            try
            {
                ThreadStart starter = delegate { ThreadCallBusy("正在登录..."); };
                tBusy = new Thread(starter);
                tBusy.Start();
                //一次性获取登录Token
                LoginToken = VerifyTicketHelper.GetToken(Config.TokenUrl);
                //验证登录
                LoginInfo login = new LoginInfo();
                login.LoginName = txtUsr.Text;
                login.Password = Hash.MD5(txtPwd.Text);
                var usrinfo = VerifyTicketHelper.Login_QD(login, Config.AuthInfoUrl, LoginToken);//请求api
                if (usrinfo.isSuc)
                {
                    //登录成功
                    //写config文件
                    Config.DeviceCode = txtDevice.Text;
                    Config.UserName = txtUsr.Text;
                    Configuration.SaveConfig(Config);
                    LoadCheckMain(true);
                    picLogin.Enabled = true;
                }
                else
                {
                    lblErr.Text = usrinfo.msg;
                    picLogin.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                lblErr.Text = ex.Message;
                picLogin.Enabled = true;
            }
            finally
            {
                if (tBusy != null)
                    tBusy.Abort();
            }
        }

        /// <summary>
        /// 返回主界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pic_backmain_Click(object sender, EventArgs e)
        {
            LoadCheckMain(true);
        }

        /// <summary>
        /// 自动验票入口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pic_auto_Click(object sender, EventArgs e)
        {
            LoadCheckScan(true);
        }

        /// <summary>
        /// 人工输入验票入口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pic_manul_Click(object sender, EventArgs e)
        {
            LoadCheckManul(true);
        }

        /// <summary>
        /// 人工验票正页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picDo_Click(object sender, EventArgs e)
        {
            try
            {
                picDo.Enabled = false;
                bool isVerifyTicketSuccess = false;
                var entin = txtChk.Text.Trim();
                if (string.IsNullOrEmpty(entin))
                    MessageBox.Show("票号不可为空！", "提示");
                var ticket = VerifyTicketByTicketNo(entin, out isVerifyTicketSuccess);
                if (ticket == null)
                {
                    //人工验票失败
                    LoadChkFail_Manul(ticket.Error, true);
                }
                else
                {
                    if (isVerifyTicketSuccess)
                    {
                        //人工验票成功
                        LoadCRES(true);
                        lbl_hndsc_TckName.Text = ticket.TicketTypeName;//票种名称
                        lbl_hndsc_TckProp.Text = ticket.TicketMode;//票种属性
                        lbl_hndsc_OutWay.Text = ticket.PeopleNum > 1 ? "一票多人" : "一票一人";//出票方式
                        lbl_hndsc_Num.Text = ticket.PeopleNum.ToString();//通行人数
                        lbl_hndsc_UseDate.Text = ticket.TicketStartTime.Date.ToString("yyyy-MM-dd") + "~" + ticket.TicketEndTime.Date.ToString("yyyy-MM-dd");//检票有效期
                        lbl_hndsc_PlayDate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");//游玩时间
                    }
                    else
                    {
                        //人工验票失败
                        LoadChkFail_Manul(ticket.Error, true);
                    }
                    if (!string.IsNullOrEmpty(ticket.Music))
                        SoundHelper.Play(ticket.Music);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
            finally
            {
                picDo.Enabled = true;
            }
        }

        /// <summary>
        /// 人工验票失败验票（弃用）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picDo1_Click(object sender, EventArgs e)
        {
            try
            {
                picDo1.Enabled = false;
                bool isVerifyTicketSuccess = false;
                var ticket = VerifyTicketByTicketNo(txtChk1.Text.Trim(), out isVerifyTicketSuccess);
                if (ticket == null)
                {
                    //人工验票失败
                    LoadChkFail_Manul(ticket.Error, true);
                }
                else
                {
                    if (isVerifyTicketSuccess)
                    {
                        //人工验票成功
                        LoadCRES(true);
                        lbl_hndsc_TckName.Text = ticket.TicketTypeName;//票种名称
                        lbl_hndsc_TckProp.Text = ticket.TicketMode;//票种属性
                        lbl_hndsc_OutWay.Text = ticket.PeopleNum > 1 ? "一票多人" : "一票一人";//出票方式
                        lbl_hndsc_Num.Text = ticket.PeopleNum.ToString();//通行人数
                        lbl_hndsc_UseDate.Text = ticket.TicketStartTime.Date.ToString("yyyy-MM-dd") + "~" + ticket.TicketEndTime.Date.ToString("yyyy-MM-dd");//检票有效期
                        lbl_hndsc_PlayDate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");//游玩时间
                    }
                    else
                    {
                        //人工验票失败
                        LoadChkFail_Manul(ticket.Error, true);
                    }
                    if (!string.IsNullOrEmpty(ticket.Music))
                        SoundHelper.Play(ticket.Music);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
            finally
            {
                picDo1.Enabled = true;
            }
        }

        /// <summary>
        /// 人工验票成功验票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picDo2_Click(object sender, EventArgs e)
        {
            try
            {
                picDo2.Enabled = false;
                bool isVerifyTicketSuccess = false;
                var entin = txtChk2.Text.Trim();
                if (string.IsNullOrEmpty(entin))
                    MessageBox.Show("票号不可为空！", "提示");
                var ticket = VerifyTicketByTicketNo(entin, out isVerifyTicketSuccess);
                if (ticket == null)
                {
                    //人工验票失败
                    LoadChkFail_Manul(ticket.Error, true);
                }
                else
                {
                    if (isVerifyTicketSuccess)
                    {
                        //人工验票成功
                        LoadCRES(true);
                        lbl_hndsc_TckName.Text = ticket.TicketTypeName;//票种名称
                        lbl_hndsc_TckProp.Text = ticket.TicketMode;//票种属性
                        lbl_hndsc_OutWay.Text = ticket.PeopleNum > 1 ? "一票多人" : "一票一人";//出票方式
                        lbl_hndsc_Num.Text = ticket.PeopleNum.ToString();//通行人数
                        lbl_hndsc_UseDate.Text = ticket.TicketStartTime.Date.ToString("yyyy-MM-dd") + "~" + ticket.TicketEndTime.Date.ToString("yyyy-MM-dd");//检票有效期
                        lbl_hndsc_PlayDate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");//游玩时间
                    }
                    else
                    {
                        //人工验票失败
                        LoadChkFail_Manul(ticket.Error, true);
                    }
                    if (!string.IsNullOrEmpty(ticket.Music))
                        SoundHelper.Play(ticket.Music);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
            finally
            {
                picDo2.Enabled = true;
            }
        }

        /// <summary>
        /// 人工验票失败验票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picDo3_Click(object sender, EventArgs e)
        {
            try
            {
                picDo3.Enabled = false;
                bool isVerifyTicketSuccess = false;
                var entin = txtChk3.Text.Trim();
                if (string.IsNullOrEmpty(entin))
                    MessageBox.Show("票号不可为空！", "提示");
                var ticket = VerifyTicketByTicketNo(entin, out isVerifyTicketSuccess);
                if (ticket == null)
                {
                    //人工验票失败
                    LoadChkFail_Manul(ticket.Error, true);
                }
                else
                {
                    if (isVerifyTicketSuccess)
                    {
                        //人工验票成功
                        LoadCRES(true);
                        lbl_hndsc_TckName.Text = ticket.TicketTypeName;//票种名称
                        lbl_hndsc_TckProp.Text = ticket.TicketMode;//票种属性
                        lbl_hndsc_OutWay.Text = ticket.PeopleNum > 1 ? "一票多人" : "一票一人";//出票方式
                        lbl_hndsc_Num.Text = ticket.PeopleNum.ToString();//通行人数
                        lbl_hndsc_UseDate.Text = ticket.TicketStartTime.Date.ToString("yyyy-MM-dd") + "~" + ticket.TicketEndTime.Date.ToString("yyyy-MM-dd");//检票有效期
                        lbl_hndsc_PlayDate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");//游玩时间
                    }
                    else
                    {
                        //人工验票失败
                        LoadChkFail_Manul(ticket.Error, true);
                    }
                    if (!string.IsNullOrEmpty(ticket.Music))
                        SoundHelper.Play(ticket.Music);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
            finally
            {
                picDo3.Enabled = true;
            }
        }

        /// <summary>
        /// 返回登录页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pic_logout_Click(object sender, EventArgs e)
        {
            LoadLogin(true);
        }

        #endregion

        #region 软键盘设置

        [DllImport("coredll.dll", CharSet = CharSet.Auto)]
        public static extern bool ImmDisableIME(uint idThread);
        [DllImport("coredll.dll", CharSet = CharSet.Auto)]
        private static extern bool SipShowIM(long flags);
        [DllImport("coredll.dll", CharSet = CharSet.Auto)]
        private static extern bool SipGetCurrentIM(out Guid guid);
        [DllImport("coredll.dll", CharSet = CharSet.Auto)]
        private static extern bool SipSetCurrentIM(byte[] guidArray);

        /// <summary>
        /// 软键盘
        /// </summary>
        public static InputPanel _softKeyBoard = new InputPanel();
        /// <summary>
        /// 显示/隐藏 软键盘 
        /// </summary>
        /// <param name="isShow"></param>
        public static void ShowHideSoftKeyBoard(bool isShow)
        {
            _softKeyBoard.Enabled = isShow;
        }

        private void txt_GotFocus(object sender, EventArgs e)
        {
            ShowHideSoftKeyBoard(true);
        }

        private void txt_LostFocus(object sender, EventArgs e)
        {
            ShowHideSoftKeyBoard(false);
        }

        private void picLoginMain_Click(object sender, EventArgs e)
        {
            ShowHideSoftKeyBoard(false);
        }

        private void picCheckManul_Click(object sender, EventArgs e)
        {
            ShowHideSoftKeyBoard(false);
        }

        private void picCREF_Click(object sender, EventArgs e)
        {
            ShowHideSoftKeyBoard(false);
        }

        private void picCRES_Click(object sender, EventArgs e)
        {
            ShowHideSoftKeyBoard(false);
        }

        private void picCheckMain_Click(object sender, EventArgs e)
        {
            ShowHideSoftKeyBoard(false);
        }

        private void picCheckScan_Click(object sender, EventArgs e)
        {
            ShowHideSoftKeyBoard(false);
        }

        private void picCRAF_Click(object sender, EventArgs e)
        {
            ShowHideSoftKeyBoard(false);
        }

        private void picCRAS_Click(object sender, EventArgs e)
        {
            ShowHideSoftKeyBoard(false);
        }

        private void pic_ChkFail_Scan_Click(object sender, EventArgs e)
        {
            ShowHideSoftKeyBoard(false);
        }

        private void pic_ChkFail_Manul_Click(object sender, EventArgs e)
        {
            ShowHideSoftKeyBoard(false);
        }

        #endregion
    }
}