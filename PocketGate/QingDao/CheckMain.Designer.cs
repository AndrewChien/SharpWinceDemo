namespace PocketGate.QingDao
{
    partial class CheckMain
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
            this.picCheckMain = new System.Windows.Forms.PictureBox();
            this.pic_auto = new System.Windows.Forms.PictureBox();
            this.pic_manul = new System.Windows.Forms.PictureBox();
            this.pic_logout = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // picCheckMain
            // 
            this.picCheckMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCheckMain.Location = new System.Drawing.Point(0, 0);
            this.picCheckMain.Name = "picCheckMain";
            this.picCheckMain.Size = new System.Drawing.Size(238, 295);
            this.picCheckMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // pic_auto
            // 
            this.pic_auto.BackColor = System.Drawing.Color.White;
            this.pic_auto.Location = new System.Drawing.Point(21, 117);
            this.pic_auto.Name = "pic_auto";
            this.pic_auto.Size = new System.Drawing.Size(196, 26);
            this.pic_auto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_auto.Click += new System.EventHandler(this.pic_aotochk_Click);
            // 
            // pic_manul
            // 
            this.pic_manul.BackColor = System.Drawing.Color.White;
            this.pic_manul.Location = new System.Drawing.Point(21, 239);
            this.pic_manul.Name = "pic_manul";
            this.pic_manul.Size = new System.Drawing.Size(196, 26);
            this.pic_manul.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_manul.Click += new System.EventHandler(this.pic_handchk_Click);
            // 
            // pic_logout
            // 
            this.pic_logout.BackColor = System.Drawing.Color.White;
            this.pic_logout.Location = new System.Drawing.Point(205, 14);
            this.pic_logout.Name = "pic_logout";
            this.pic_logout.Size = new System.Drawing.Size(30, 15);
            this.pic_logout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_logout.Click += new System.EventHandler(this.pic_cancel_Click);
            // 
            // CheckMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.pic_logout);
            this.Controls.Add(this.pic_manul);
            this.Controls.Add(this.pic_auto);
            this.Controls.Add(this.picCheckMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckMain";
            this.Text = "CheckMain";
            this.Load += new System.EventHandler(this.CheckMain_Load);
            this.Closed += new System.EventHandler(this.CheckMain_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCheckMain;
        private System.Windows.Forms.PictureBox pic_auto;
        private System.Windows.Forms.PictureBox pic_manul;
        private System.Windows.Forms.PictureBox pic_logout;

    }
}