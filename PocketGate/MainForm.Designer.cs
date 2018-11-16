namespace PocketGate
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Logo = new System.Windows.Forms.Label();
            this.Tmr_Clock = new System.Windows.Forms.Timer();
            this.pnl_Valid = new System.Windows.Forms.Panel();
            this.lbl_Valid_Count = new System.Windows.Forms.Label();
            this.lbl_TicketVerifyGate = new System.Windows.Forms.Label();
            this.lbl_TicketVerifyTime = new System.Windows.Forms.Label();
            this.lbl_TicketValid = new System.Windows.Forms.Label();
            this.lbl_TicketPrice = new System.Windows.Forms.Label();
            this.lbl_TicketSellTime = new System.Windows.Forms.Label();
            this.lbl_TicketNumber = new System.Windows.Forms.Label();
            this.lbl_TickType = new System.Windows.Forms.Label();
            this.lbl_TicketName = new System.Windows.Forms.Label();
            this.lbl_TicketNo = new System.Windows.Forms.Label();
            this.lbl_TicketVerifyGate_L = new System.Windows.Forms.Label();
            this.lbl_TicketVerifyTime_L = new System.Windows.Forms.Label();
            this.lbl_TicketValid_L = new System.Windows.Forms.Label();
            this.lbl_TicketPrice_L = new System.Windows.Forms.Label();
            this.lbl_TicketSellTime_L = new System.Windows.Forms.Label();
            this.lbl_TicketNumber_L = new System.Windows.Forms.Label();
            this.lbl_TickType_L = new System.Windows.Forms.Label();
            this.lbl_TicketName_L = new System.Windows.Forms.Label();
            this.lbl_TicketNo_L = new System.Windows.Forms.Label();
            this.lbl_TicketInfo = new System.Windows.Forms.Label();
            this.pnl_General = new System.Windows.Forms.Panel();
            this.lbl_WifiString = new System.Windows.Forms.Label();
            this.lbl_HasCount = new System.Windows.Forms.Label();
            this.lbl_HasUnit = new System.Windows.Forms.Label();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.lbl_Support = new System.Windows.Forms.Label();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.lbl_Date = new System.Windows.Forms.Label();
            this.lbl_Has = new System.Windows.Forms.Label();
            this.pnl_Invalid = new System.Windows.Forms.Panel();
            this.lbl_Invalid_Count = new System.Windows.Forms.Label();
            this.pic_Invalid = new System.Windows.Forms.PictureBox();
            this.lbl_TicketNo_Invalid = new System.Windows.Forms.Label();
            this.lbl_TicketNo_L_Invalid = new System.Windows.Forms.Label();
            this.lbl_TicketInfo_InValid = new System.Windows.Forms.Label();
            this.Tmr_Refresh = new System.Windows.Forms.Timer();
            this.Tmr_Count = new System.Windows.Forms.Timer();
            this.pic_Battery = new System.Windows.Forms.PictureBox();
            this.pic_Logo = new System.Windows.Forms.PictureBox();
            this.pic_BackImage = new System.Windows.Forms.PictureBox();
            this.pic_Wifi = new System.Windows.Forms.PictureBox();
            this.pnl_Card_No = new System.Windows.Forms.Panel();
            this.lbl_Card_No_Msg = new System.Windows.Forms.Label();
            this.lbl_Card_No_Count = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnl_Card_Yes = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_Card_Yes_Count = new System.Windows.Forms.Label();
            this.lbl_Card_Yes_YouXiao = new System.Windows.Forms.Label();
            this.lbl_Card_Yes_Price = new System.Windows.Forms.Label();
            this.lbl_Card_Yes_Name = new System.Windows.Forms.Label();
            this.lbl_Card_Yes_Num = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Card_Yes_PayType = new System.Windows.Forms.Label();
            this.pbx__Card_Yes_Phono = new System.Windows.Forms.PictureBox();
            this.pnl_Valid.SuspendLayout();
            this.pnl_General.SuspendLayout();
            this.pnl_Invalid.SuspendLayout();
            this.pnl_Card_No.SuspendLayout();
            this.pnl_Card_Yes.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(316, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "全价票";
            // 
            // lbl_Logo
            // 
            this.lbl_Logo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(79)))), ((int)(((byte)(121)))));
            this.lbl_Logo.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.lbl_Logo.ForeColor = System.Drawing.Color.White;
            this.lbl_Logo.Location = new System.Drawing.Point(33, 3);
            this.lbl_Logo.Name = "lbl_Logo";
            this.lbl_Logo.Size = new System.Drawing.Size(204, 26);
            this.lbl_Logo.Text = "电子票务系统";
            // 
            // Tmr_Clock
            // 
            this.Tmr_Clock.Enabled = true;
            this.Tmr_Clock.Interval = 1000;
            this.Tmr_Clock.Tick += new System.EventHandler(this.Tmr_Clock_Tick);
            // 
            // pnl_Valid
            // 
            this.pnl_Valid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.pnl_Valid.Controls.Add(this.lbl_Valid_Count);
            this.pnl_Valid.Controls.Add(this.lbl_TicketVerifyGate);
            this.pnl_Valid.Controls.Add(this.lbl_TicketVerifyTime);
            this.pnl_Valid.Controls.Add(this.lbl_TicketValid);
            this.pnl_Valid.Controls.Add(this.lbl_TicketPrice);
            this.pnl_Valid.Controls.Add(this.lbl_TicketSellTime);
            this.pnl_Valid.Controls.Add(this.lbl_TicketNumber);
            this.pnl_Valid.Controls.Add(this.lbl_TickType);
            this.pnl_Valid.Controls.Add(this.lbl_TicketName);
            this.pnl_Valid.Controls.Add(this.lbl_TicketNo);
            this.pnl_Valid.Controls.Add(this.lbl_TicketVerifyGate_L);
            this.pnl_Valid.Controls.Add(this.lbl_TicketVerifyTime_L);
            this.pnl_Valid.Controls.Add(this.lbl_TicketValid_L);
            this.pnl_Valid.Controls.Add(this.lbl_TicketPrice_L);
            this.pnl_Valid.Controls.Add(this.lbl_TicketSellTime_L);
            this.pnl_Valid.Controls.Add(this.lbl_TicketNumber_L);
            this.pnl_Valid.Controls.Add(this.lbl_TickType_L);
            this.pnl_Valid.Controls.Add(this.lbl_TicketName_L);
            this.pnl_Valid.Controls.Add(this.lbl_TicketNo_L);
            this.pnl_Valid.Controls.Add(this.lbl_TicketInfo);
            this.pnl_Valid.Location = new System.Drawing.Point(246, 29);
            this.pnl_Valid.Name = "pnl_Valid";
            this.pnl_Valid.Size = new System.Drawing.Size(240, 320);
            // 
            // lbl_Valid_Count
            // 
            this.lbl_Valid_Count.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_Valid_Count.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_Valid_Count.ForeColor = System.Drawing.Color.Silver;
            this.lbl_Valid_Count.Location = new System.Drawing.Point(214, 274);
            this.lbl_Valid_Count.Name = "lbl_Valid_Count";
            this.lbl_Valid_Count.Size = new System.Drawing.Size(22, 18);
            this.lbl_Valid_Count.Text = "20";
            // 
            // lbl_TicketVerifyGate
            // 
            this.lbl_TicketVerifyGate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_TicketVerifyGate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_TicketVerifyGate.ForeColor = System.Drawing.Color.White;
            this.lbl_TicketVerifyGate.Location = new System.Drawing.Point(94, 260);
            this.lbl_TicketVerifyGate.Name = "lbl_TicketVerifyGate";
            this.lbl_TicketVerifyGate.Size = new System.Drawing.Size(140, 18);
            this.lbl_TicketVerifyGate.Text = "检票通道：";
            // 
            // lbl_TicketVerifyTime
            // 
            this.lbl_TicketVerifyTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_TicketVerifyTime.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_TicketVerifyTime.ForeColor = System.Drawing.Color.White;
            this.lbl_TicketVerifyTime.Location = new System.Drawing.Point(94, 235);
            this.lbl_TicketVerifyTime.Name = "lbl_TicketVerifyTime";
            this.lbl_TicketVerifyTime.Size = new System.Drawing.Size(140, 18);
            this.lbl_TicketVerifyTime.Text = "检票时间：";
            // 
            // lbl_TicketValid
            // 
            this.lbl_TicketValid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_TicketValid.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_TicketValid.ForeColor = System.Drawing.Color.Red;
            this.lbl_TicketValid.Location = new System.Drawing.Point(94, 210);
            this.lbl_TicketValid.Name = "lbl_TicketValid";
            this.lbl_TicketValid.Size = new System.Drawing.Size(140, 18);
            this.lbl_TicketValid.Text = "有效期：";
            // 
            // lbl_TicketPrice
            // 
            this.lbl_TicketPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_TicketPrice.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_TicketPrice.ForeColor = System.Drawing.Color.White;
            this.lbl_TicketPrice.Location = new System.Drawing.Point(94, 185);
            this.lbl_TicketPrice.Name = "lbl_TicketPrice";
            this.lbl_TicketPrice.Size = new System.Drawing.Size(140, 18);
            this.lbl_TicketPrice.Text = "票价：";
            // 
            // lbl_TicketSellTime
            // 
            this.lbl_TicketSellTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_TicketSellTime.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_TicketSellTime.ForeColor = System.Drawing.Color.White;
            this.lbl_TicketSellTime.Location = new System.Drawing.Point(94, 160);
            this.lbl_TicketSellTime.Name = "lbl_TicketSellTime";
            this.lbl_TicketSellTime.Size = new System.Drawing.Size(140, 18);
            this.lbl_TicketSellTime.Text = "购买时间：";
            // 
            // lbl_TicketNumber
            // 
            this.lbl_TicketNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_TicketNumber.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_TicketNumber.ForeColor = System.Drawing.Color.Red;
            this.lbl_TicketNumber.Location = new System.Drawing.Point(94, 135);
            this.lbl_TicketNumber.Name = "lbl_TicketNumber";
            this.lbl_TicketNumber.Size = new System.Drawing.Size(140, 18);
            this.lbl_TicketNumber.Text = "人数：";
            // 
            // lbl_TickType
            // 
            this.lbl_TickType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_TickType.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_TickType.ForeColor = System.Drawing.Color.White;
            this.lbl_TickType.Location = new System.Drawing.Point(94, 110);
            this.lbl_TickType.Name = "lbl_TickType";
            this.lbl_TickType.Size = new System.Drawing.Size(140, 18);
            this.lbl_TickType.Text = "票类型：";
            // 
            // lbl_TicketName
            // 
            this.lbl_TicketName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_TicketName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_TicketName.ForeColor = System.Drawing.Color.White;
            this.lbl_TicketName.Location = new System.Drawing.Point(94, 85);
            this.lbl_TicketName.Name = "lbl_TicketName";
            this.lbl_TicketName.Size = new System.Drawing.Size(140, 18);
            this.lbl_TicketName.Text = "票名称：";
            // 
            // lbl_TicketNo
            // 
            this.lbl_TicketNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_TicketNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_TicketNo.ForeColor = System.Drawing.Color.White;
            this.lbl_TicketNo.Location = new System.Drawing.Point(94, 60);
            this.lbl_TicketNo.Name = "lbl_TicketNo";
            this.lbl_TicketNo.Size = new System.Drawing.Size(140, 18);
            this.lbl_TicketNo.Text = "票号：";
            // 
            // lbl_TicketVerifyGate_L
            // 
            this.lbl_TicketVerifyGate_L.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_TicketVerifyGate_L.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_TicketVerifyGate_L.ForeColor = System.Drawing.Color.Silver;
            this.lbl_TicketVerifyGate_L.Location = new System.Drawing.Point(16, 260);
            this.lbl_TicketVerifyGate_L.Name = "lbl_TicketVerifyGate_L";
            this.lbl_TicketVerifyGate_L.Size = new System.Drawing.Size(70, 18);
            this.lbl_TicketVerifyGate_L.Text = "检票通道：";
            this.lbl_TicketVerifyGate_L.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_TicketVerifyTime_L
            // 
            this.lbl_TicketVerifyTime_L.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_TicketVerifyTime_L.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_TicketVerifyTime_L.ForeColor = System.Drawing.Color.Silver;
            this.lbl_TicketVerifyTime_L.Location = new System.Drawing.Point(16, 235);
            this.lbl_TicketVerifyTime_L.Name = "lbl_TicketVerifyTime_L";
            this.lbl_TicketVerifyTime_L.Size = new System.Drawing.Size(70, 18);
            this.lbl_TicketVerifyTime_L.Text = "检票时间：";
            this.lbl_TicketVerifyTime_L.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_TicketValid_L
            // 
            this.lbl_TicketValid_L.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_TicketValid_L.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_TicketValid_L.ForeColor = System.Drawing.Color.Silver;
            this.lbl_TicketValid_L.Location = new System.Drawing.Point(16, 210);
            this.lbl_TicketValid_L.Name = "lbl_TicketValid_L";
            this.lbl_TicketValid_L.Size = new System.Drawing.Size(70, 18);
            this.lbl_TicketValid_L.Text = "有效期：";
            this.lbl_TicketValid_L.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_TicketPrice_L
            // 
            this.lbl_TicketPrice_L.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_TicketPrice_L.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_TicketPrice_L.ForeColor = System.Drawing.Color.Silver;
            this.lbl_TicketPrice_L.Location = new System.Drawing.Point(16, 185);
            this.lbl_TicketPrice_L.Name = "lbl_TicketPrice_L";
            this.lbl_TicketPrice_L.Size = new System.Drawing.Size(70, 18);
            this.lbl_TicketPrice_L.Text = "票价：";
            this.lbl_TicketPrice_L.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_TicketSellTime_L
            // 
            this.lbl_TicketSellTime_L.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_TicketSellTime_L.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_TicketSellTime_L.ForeColor = System.Drawing.Color.Silver;
            this.lbl_TicketSellTime_L.Location = new System.Drawing.Point(16, 160);
            this.lbl_TicketSellTime_L.Name = "lbl_TicketSellTime_L";
            this.lbl_TicketSellTime_L.Size = new System.Drawing.Size(70, 18);
            this.lbl_TicketSellTime_L.Text = "购买时间：";
            this.lbl_TicketSellTime_L.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_TicketNumber_L
            // 
            this.lbl_TicketNumber_L.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_TicketNumber_L.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_TicketNumber_L.ForeColor = System.Drawing.Color.Silver;
            this.lbl_TicketNumber_L.Location = new System.Drawing.Point(16, 135);
            this.lbl_TicketNumber_L.Name = "lbl_TicketNumber_L";
            this.lbl_TicketNumber_L.Size = new System.Drawing.Size(70, 18);
            this.lbl_TicketNumber_L.Text = "人数：";
            this.lbl_TicketNumber_L.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_TickType_L
            // 
            this.lbl_TickType_L.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_TickType_L.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_TickType_L.ForeColor = System.Drawing.Color.Silver;
            this.lbl_TickType_L.Location = new System.Drawing.Point(16, 110);
            this.lbl_TickType_L.Name = "lbl_TickType_L";
            this.lbl_TickType_L.Size = new System.Drawing.Size(70, 18);
            this.lbl_TickType_L.Text = "票类型：";
            this.lbl_TickType_L.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_TicketName_L
            // 
            this.lbl_TicketName_L.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_TicketName_L.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_TicketName_L.ForeColor = System.Drawing.Color.Silver;
            this.lbl_TicketName_L.Location = new System.Drawing.Point(16, 85);
            this.lbl_TicketName_L.Name = "lbl_TicketName_L";
            this.lbl_TicketName_L.Size = new System.Drawing.Size(70, 18);
            this.lbl_TicketName_L.Text = "票名称：";
            this.lbl_TicketName_L.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_TicketNo_L
            // 
            this.lbl_TicketNo_L.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_TicketNo_L.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_TicketNo_L.ForeColor = System.Drawing.Color.Silver;
            this.lbl_TicketNo_L.Location = new System.Drawing.Point(16, 60);
            this.lbl_TicketNo_L.Name = "lbl_TicketNo_L";
            this.lbl_TicketNo_L.Size = new System.Drawing.Size(70, 18);
            this.lbl_TicketNo_L.Text = "票号：";
            this.lbl_TicketNo_L.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_TicketInfo
            // 
            this.lbl_TicketInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_TicketInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lbl_TicketInfo.ForeColor = System.Drawing.Color.White;
            this.lbl_TicketInfo.Location = new System.Drawing.Point(75, 21);
            this.lbl_TicketInfo.Name = "lbl_TicketInfo";
            this.lbl_TicketInfo.Size = new System.Drawing.Size(84, 21);
            this.lbl_TicketInfo.Text = "门票信息";
            // 
            // pnl_General
            // 
            this.pnl_General.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.pnl_General.Controls.Add(this.lbl_WifiString);
            this.pnl_General.Controls.Add(this.lbl_HasCount);
            this.pnl_General.Controls.Add(this.lbl_HasUnit);
            this.pnl_General.Controls.Add(this.lbl_Time);
            this.pnl_General.Controls.Add(this.lbl_Support);
            this.pnl_General.Controls.Add(this.lbl_Title);
            this.pnl_General.Controls.Add(this.lbl_Date);
            this.pnl_General.Controls.Add(this.lbl_Has);
            this.pnl_General.Location = new System.Drawing.Point(0, 29);
            this.pnl_General.Name = "pnl_General";
            this.pnl_General.Size = new System.Drawing.Size(240, 320);
            // 
            // lbl_WifiString
            // 
            this.lbl_WifiString.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_WifiString.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_WifiString.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(125)))), ((int)(((byte)(180)))));
            this.lbl_WifiString.Location = new System.Drawing.Point(193, 267);
            this.lbl_WifiString.Name = "lbl_WifiString";
            this.lbl_WifiString.Size = new System.Drawing.Size(40, 18);
            // 
            // lbl_HasCount
            // 
            this.lbl_HasCount.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.lbl_HasCount.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_HasCount.Location = new System.Drawing.Point(128, 201);
            this.lbl_HasCount.Name = "lbl_HasCount";
            this.lbl_HasCount.Size = new System.Drawing.Size(54, 20);
            this.lbl_HasCount.Text = "0";
            // 
            // lbl_HasUnit
            // 
            this.lbl_HasUnit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lbl_HasUnit.ForeColor = System.Drawing.Color.White;
            this.lbl_HasUnit.Location = new System.Drawing.Point(189, 203);
            this.lbl_HasUnit.Name = "lbl_HasUnit";
            this.lbl_HasUnit.Size = new System.Drawing.Size(27, 20);
            this.lbl_HasUnit.Text = "张";
            // 
            // lbl_Time
            // 
            this.lbl_Time.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.lbl_Time.ForeColor = System.Drawing.Color.White;
            this.lbl_Time.Location = new System.Drawing.Point(75, 135);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(100, 20);
            this.lbl_Time.Text = "时间：";
            // 
            // lbl_Support
            // 
            this.lbl_Support.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_Support.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_Support.ForeColor = System.Drawing.Color.White;
            this.lbl_Support.Location = new System.Drawing.Point(55, 268);
            this.lbl_Support.Name = "lbl_Support";
            this.lbl_Support.Size = new System.Drawing.Size(132, 14);
            this.lbl_Support.Text = "技术支持：浙江卓锐";
            // 
            // lbl_Title
            // 
            this.lbl_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_Title.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lbl_Title.ForeColor = System.Drawing.Color.White;
            this.lbl_Title.Location = new System.Drawing.Point(17, 39);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(207, 21);
            this.lbl_Title.Text = "欢迎使用电子票务手持检票机";
            // 
            // lbl_Date
            // 
            this.lbl_Date.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lbl_Date.ForeColor = System.Drawing.Color.White;
            this.lbl_Date.Location = new System.Drawing.Point(47, 100);
            this.lbl_Date.Name = "lbl_Date";
            this.lbl_Date.Size = new System.Drawing.Size(145, 20);
            this.lbl_Date.Text = "日期：";
            // 
            // lbl_Has
            // 
            this.lbl_Has.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lbl_Has.ForeColor = System.Drawing.Color.White;
            this.lbl_Has.Location = new System.Drawing.Point(18, 203);
            this.lbl_Has.Name = "lbl_Has";
            this.lbl_Has.Size = new System.Drawing.Size(104, 20);
            this.lbl_Has.Text = "今天已检票";
            // 
            // pnl_Invalid
            // 
            this.pnl_Invalid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.pnl_Invalid.Controls.Add(this.lbl_Invalid_Count);
            this.pnl_Invalid.Controls.Add(this.pic_Invalid);
            this.pnl_Invalid.Controls.Add(this.lbl_TicketNo_Invalid);
            this.pnl_Invalid.Controls.Add(this.lbl_TicketNo_L_Invalid);
            this.pnl_Invalid.Controls.Add(this.lbl_TicketInfo_InValid);
            this.pnl_Invalid.Location = new System.Drawing.Point(492, 29);
            this.pnl_Invalid.Name = "pnl_Invalid";
            this.pnl_Invalid.Size = new System.Drawing.Size(240, 320);
            // 
            // lbl_Invalid_Count
            // 
            this.lbl_Invalid_Count.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_Invalid_Count.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_Invalid_Count.ForeColor = System.Drawing.Color.Silver;
            this.lbl_Invalid_Count.Location = new System.Drawing.Point(214, 274);
            this.lbl_Invalid_Count.Name = "lbl_Invalid_Count";
            this.lbl_Invalid_Count.Size = new System.Drawing.Size(22, 18);
            this.lbl_Invalid_Count.Text = "20";
            // 
            // pic_Invalid
            // 
            this.pic_Invalid.Location = new System.Drawing.Point(55, 110);
            this.pic_Invalid.Name = "pic_Invalid";
            this.pic_Invalid.Size = new System.Drawing.Size(120, 148);
            // 
            // lbl_TicketNo_Invalid
            // 
            this.lbl_TicketNo_Invalid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_TicketNo_Invalid.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_TicketNo_Invalid.ForeColor = System.Drawing.Color.White;
            this.lbl_TicketNo_Invalid.Location = new System.Drawing.Point(94, 60);
            this.lbl_TicketNo_Invalid.Name = "lbl_TicketNo_Invalid";
            this.lbl_TicketNo_Invalid.Size = new System.Drawing.Size(140, 18);
            this.lbl_TicketNo_Invalid.Text = "票号：";
            // 
            // lbl_TicketNo_L_Invalid
            // 
            this.lbl_TicketNo_L_Invalid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_TicketNo_L_Invalid.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_TicketNo_L_Invalid.ForeColor = System.Drawing.Color.Silver;
            this.lbl_TicketNo_L_Invalid.Location = new System.Drawing.Point(29, 60);
            this.lbl_TicketNo_L_Invalid.Name = "lbl_TicketNo_L_Invalid";
            this.lbl_TicketNo_L_Invalid.Size = new System.Drawing.Size(70, 18);
            this.lbl_TicketNo_L_Invalid.Text = "票号：";
            // 
            // lbl_TicketInfo_InValid
            // 
            this.lbl_TicketInfo_InValid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_TicketInfo_InValid.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lbl_TicketInfo_InValid.ForeColor = System.Drawing.Color.White;
            this.lbl_TicketInfo_InValid.Location = new System.Drawing.Point(75, 21);
            this.lbl_TicketInfo_InValid.Name = "lbl_TicketInfo_InValid";
            this.lbl_TicketInfo_InValid.Size = new System.Drawing.Size(84, 21);
            this.lbl_TicketInfo_InValid.Text = "门票信息";
            // 
            // Tmr_Refresh
            // 
            this.Tmr_Refresh.Enabled = true;
            this.Tmr_Refresh.Interval = 5000;
            this.Tmr_Refresh.Tick += new System.EventHandler(this.Tmr_Refresh_Tick);
            // 
            // Tmr_Count
            // 
            this.Tmr_Count.Interval = 1000;
            this.Tmr_Count.Tick += new System.EventHandler(this.Tmr_Count_Tick);
            // 
            // pic_Battery
            // 
            this.pic_Battery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(79)))), ((int)(((byte)(121)))));
            this.pic_Battery.Image = ((System.Drawing.Image)(resources.GetObject("pic_Battery.Image")));
            this.pic_Battery.Location = new System.Drawing.Point(213, -1);
            this.pic_Battery.Name = "pic_Battery";
            this.pic_Battery.Size = new System.Drawing.Size(22, 30);
            // 
            // pic_Logo
            // 
            this.pic_Logo.Image = ((System.Drawing.Image)(resources.GetObject("pic_Logo.Image")));
            this.pic_Logo.Location = new System.Drawing.Point(0, 0);
            this.pic_Logo.Name = "pic_Logo";
            this.pic_Logo.Size = new System.Drawing.Size(240, 30);
            this.pic_Logo.Click += new System.EventHandler(this.pic_Logo_Click);
            // 
            // pic_BackImage
            // 
            this.pic_BackImage.Image = ((System.Drawing.Image)(resources.GetObject("pic_BackImage.Image")));
            this.pic_BackImage.Location = new System.Drawing.Point(0, 0);
            this.pic_BackImage.Name = "pic_BackImage";
            this.pic_BackImage.Size = new System.Drawing.Size(1337, 364);
            this.pic_BackImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_BackImage.Resize += new System.EventHandler(this.pictureBox1_Resize);
            // 
            // pic_Wifi
            // 
            this.pic_Wifi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(79)))), ((int)(((byte)(121)))));
            this.pic_Wifi.Image = ((System.Drawing.Image)(resources.GetObject("pic_Wifi.Image")));
            this.pic_Wifi.Location = new System.Drawing.Point(189, -1);
            this.pic_Wifi.Name = "pic_Wifi";
            this.pic_Wifi.Size = new System.Drawing.Size(22, 30);
            // 
            // pnl_Card_No
            // 
            this.pnl_Card_No.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.pnl_Card_No.Controls.Add(this.lbl_Card_No_Msg);
            this.pnl_Card_No.Controls.Add(this.lbl_Card_No_Count);
            this.pnl_Card_No.Controls.Add(this.label5);
            this.pnl_Card_No.Location = new System.Drawing.Point(984, 29);
            this.pnl_Card_No.Name = "pnl_Card_No";
            this.pnl_Card_No.Size = new System.Drawing.Size(240, 320);
            // 
            // lbl_Card_No_Msg
            // 
            this.lbl_Card_No_Msg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_Card_No_Msg.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular);
            this.lbl_Card_No_Msg.ForeColor = System.Drawing.Color.Red;
            this.lbl_Card_No_Msg.Location = new System.Drawing.Point(51, 60);
            this.lbl_Card_No_Msg.Name = "lbl_Card_No_Msg";
            this.lbl_Card_No_Msg.Size = new System.Drawing.Size(140, 198);
            this.lbl_Card_No_Msg.Text = "错误消息";
            // 
            // lbl_Card_No_Count
            // 
            this.lbl_Card_No_Count.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_Card_No_Count.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_Card_No_Count.ForeColor = System.Drawing.Color.Silver;
            this.lbl_Card_No_Count.Location = new System.Drawing.Point(214, 274);
            this.lbl_Card_No_Count.Name = "lbl_Card_No_Count";
            this.lbl_Card_No_Count.Size = new System.Drawing.Size(22, 18);
            this.lbl_Card_No_Count.Text = "20";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(75, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 21);
            this.label5.Text = "检票失败";
            // 
            // pnl_Card_Yes
            // 
            this.pnl_Card_Yes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.pnl_Card_Yes.Controls.Add(this.pbx__Card_Yes_Phono);
            this.pnl_Card_Yes.Controls.Add(this.lbl_Card_Yes_PayType);
            this.pnl_Card_Yes.Controls.Add(this.label2);
            this.pnl_Card_Yes.Controls.Add(this.label3);
            this.pnl_Card_Yes.Controls.Add(this.lbl_Card_Yes_Count);
            this.pnl_Card_Yes.Controls.Add(this.lbl_Card_Yes_YouXiao);
            this.pnl_Card_Yes.Controls.Add(this.lbl_Card_Yes_Price);
            this.pnl_Card_Yes.Controls.Add(this.lbl_Card_Yes_Name);
            this.pnl_Card_Yes.Controls.Add(this.lbl_Card_Yes_Num);
            this.pnl_Card_Yes.Controls.Add(this.label18);
            this.pnl_Card_Yes.Controls.Add(this.label22);
            this.pnl_Card_Yes.Controls.Add(this.label23);
            this.pnl_Card_Yes.Controls.Add(this.label24);
            this.pnl_Card_Yes.Location = new System.Drawing.Point(738, 29);
            this.pnl_Card_Yes.Name = "pnl_Card_Yes";
            this.pnl_Card_Yes.Size = new System.Drawing.Size(240, 320);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(123, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 18);
            this.label3.Text = "元";
            // 
            // lbl_Card_Yes_Count
            // 
            this.lbl_Card_Yes_Count.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_Card_Yes_Count.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_Card_Yes_Count.ForeColor = System.Drawing.Color.Silver;
            this.lbl_Card_Yes_Count.Location = new System.Drawing.Point(214, 274);
            this.lbl_Card_Yes_Count.Name = "lbl_Card_Yes_Count";
            this.lbl_Card_Yes_Count.Size = new System.Drawing.Size(22, 18);
            this.lbl_Card_Yes_Count.Text = "20";
            // 
            // lbl_Card_Yes_YouXiao
            // 
            this.lbl_Card_Yes_YouXiao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_Card_Yes_YouXiao.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_Card_Yes_YouXiao.ForeColor = System.Drawing.Color.Red;
            this.lbl_Card_Yes_YouXiao.Location = new System.Drawing.Point(94, 260);
            this.lbl_Card_Yes_YouXiao.Name = "lbl_Card_Yes_YouXiao";
            this.lbl_Card_Yes_YouXiao.Size = new System.Drawing.Size(140, 18);
            this.lbl_Card_Yes_YouXiao.Text = "有效期：";
            // 
            // lbl_Card_Yes_Price
            // 
            this.lbl_Card_Yes_Price.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_Card_Yes_Price.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_Card_Yes_Price.ForeColor = System.Drawing.Color.Red;
            this.lbl_Card_Yes_Price.Location = new System.Drawing.Point(94, 235);
            this.lbl_Card_Yes_Price.Name = "lbl_Card_Yes_Price";
            this.lbl_Card_Yes_Price.Size = new System.Drawing.Size(39, 18);
            this.lbl_Card_Yes_Price.Text = "扣款：";
            // 
            // lbl_Card_Yes_Name
            // 
            this.lbl_Card_Yes_Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_Card_Yes_Name.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_Card_Yes_Name.ForeColor = System.Drawing.Color.White;
            this.lbl_Card_Yes_Name.Location = new System.Drawing.Point(94, 185);
            this.lbl_Card_Yes_Name.Name = "lbl_Card_Yes_Name";
            this.lbl_Card_Yes_Name.Size = new System.Drawing.Size(140, 18);
            this.lbl_Card_Yes_Name.Text = "持卡人：";
            // 
            // lbl_Card_Yes_Num
            // 
            this.lbl_Card_Yes_Num.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_Card_Yes_Num.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_Card_Yes_Num.ForeColor = System.Drawing.Color.White;
            this.lbl_Card_Yes_Num.Location = new System.Drawing.Point(94, 21);
            this.lbl_Card_Yes_Num.Name = "lbl_Card_Yes_Num";
            this.lbl_Card_Yes_Num.Size = new System.Drawing.Size(140, 18);
            this.lbl_Card_Yes_Num.Text = "卡号：";
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.label18.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label18.ForeColor = System.Drawing.Color.Silver;
            this.label18.Location = new System.Drawing.Point(16, 260);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 18);
            this.label18.Text = "有效期：";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.label22.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label22.ForeColor = System.Drawing.Color.Silver;
            this.label22.Location = new System.Drawing.Point(16, 235);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(70, 18);
            this.label22.Text = "扣款：";
            this.label22.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.label23.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label23.ForeColor = System.Drawing.Color.Silver;
            this.label23.Location = new System.Drawing.Point(16, 185);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(70, 18);
            this.label23.Text = "持卡人：";
            this.label23.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.label24.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label24.ForeColor = System.Drawing.Color.Silver;
            this.label24.Location = new System.Drawing.Point(16, 21);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(70, 18);
            this.label24.Text = "卡号：";
            this.label24.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(16, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 18);
            this.label2.Text = "扣费方式";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_Card_Yes_PayType
            // 
            this.lbl_Card_Yes_PayType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(105)))), ((int)(((byte)(170)))));
            this.lbl_Card_Yes_PayType.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbl_Card_Yes_PayType.ForeColor = System.Drawing.Color.White;
            this.lbl_Card_Yes_PayType.Location = new System.Drawing.Point(94, 210);
            this.lbl_Card_Yes_PayType.Name = "lbl_Card_Yes_PayType";
            this.lbl_Card_Yes_PayType.Size = new System.Drawing.Size(140, 18);
            this.lbl_Card_Yes_PayType.Text = "持卡人：";
            // 
            // pbx__Card_Yes_Phono
            // 
            this.pbx__Card_Yes_Phono.Location = new System.Drawing.Point(67, 42);
            this.pbx__Card_Yes_Phono.Name = "pbx__Card_Yes_Phono";
            this.pbx__Card_Yes_Phono.Size = new System.Drawing.Size(102, 136);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1439, 401);
            this.Controls.Add(this.pnl_Card_Yes);
            this.Controls.Add(this.pnl_Card_No);
            this.Controls.Add(this.pic_Wifi);
            this.Controls.Add(this.pic_Battery);
            this.Controls.Add(this.pnl_Invalid);
            this.Controls.Add(this.pnl_General);
            this.Controls.Add(this.pnl_Valid);
            this.Controls.Add(this.lbl_Logo);
            this.Controls.Add(this.pic_Logo);
            this.Controls.Add(this.pic_BackImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "手持式闸机程序";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Closed += new System.EventHandler(this.Form1_Closed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.pnl_Valid.ResumeLayout(false);
            this.pnl_General.ResumeLayout(false);
            this.pnl_Invalid.ResumeLayout(false);
            this.pnl_Card_No.ResumeLayout(false);
            this.pnl_Card_Yes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_BackImage;
        private System.Windows.Forms.Label lbl_Logo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer Tmr_Clock;
        private System.Windows.Forms.PictureBox pic_Logo;
        private System.Windows.Forms.Panel pnl_Valid;
        private System.Windows.Forms.Label lbl_TicketPrice_L;
        private System.Windows.Forms.Label lbl_TicketSellTime_L;
        private System.Windows.Forms.Label lbl_TicketNumber_L;
        private System.Windows.Forms.Label lbl_TickType_L;
        private System.Windows.Forms.Label lbl_TicketName_L;
        private System.Windows.Forms.Label lbl_TicketNo_L;
        private System.Windows.Forms.Label lbl_TicketInfo;
        private System.Windows.Forms.Panel pnl_General;
        private System.Windows.Forms.Label lbl_HasCount;
        private System.Windows.Forms.Label lbl_HasUnit;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Label lbl_Support;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label lbl_Date;
        private System.Windows.Forms.Label lbl_Has;
        private System.Windows.Forms.Label lbl_TicketVerifyGate_L;
        private System.Windows.Forms.Label lbl_TicketVerifyTime_L;
        private System.Windows.Forms.Label lbl_TicketValid_L;
        private System.Windows.Forms.Label lbl_TicketVerifyGate;
        private System.Windows.Forms.Label lbl_TicketVerifyTime;
        private System.Windows.Forms.Label lbl_TicketValid;
        private System.Windows.Forms.Label lbl_TicketPrice;
        private System.Windows.Forms.Label lbl_TicketSellTime;
        private System.Windows.Forms.Label lbl_TicketNumber;
        private System.Windows.Forms.Label lbl_TickType;
        private System.Windows.Forms.Label lbl_TicketName;
        private System.Windows.Forms.Label lbl_TicketNo;
        private System.Windows.Forms.Panel pnl_Invalid;
        private System.Windows.Forms.Label lbl_TicketNo_Invalid;
        private System.Windows.Forms.Label lbl_TicketNo_L_Invalid;
        private System.Windows.Forms.Label lbl_TicketInfo_InValid;
        private System.Windows.Forms.PictureBox pic_Invalid;
        private System.Windows.Forms.Timer Tmr_Refresh;
        private System.Windows.Forms.Label lbl_Valid_Count;
        private System.Windows.Forms.Label lbl_Invalid_Count;
        private System.Windows.Forms.Timer Tmr_Count;
        private System.Windows.Forms.PictureBox pic_Battery;
        private System.Windows.Forms.PictureBox pic_Wifi;
        private System.Windows.Forms.Label lbl_WifiString;
        private System.Windows.Forms.Panel pnl_Card_No;
        private System.Windows.Forms.Label lbl_Card_No_Count;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnl_Card_Yes;
        private System.Windows.Forms.Label lbl_Card_Yes_Count;
        private System.Windows.Forms.Label lbl_Card_Yes_YouXiao;
        private System.Windows.Forms.Label lbl_Card_Yes_Price;
        private System.Windows.Forms.Label lbl_Card_Yes_Name;
        private System.Windows.Forms.Label lbl_Card_Yes_Num;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_Card_No_Msg;
        private System.Windows.Forms.Label lbl_Card_Yes_PayType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbx__Card_Yes_Phono;
    }
}

