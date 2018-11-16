namespace PocketGate.QingDao
{
    partial class CheckScan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckScan));
            this.picCheckScan = new System.Windows.Forms.PictureBox();
            this.picBack = new System.Windows.Forms.PictureBox();
            this.pic_logout = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // picCheckScan
            // 
            this.picCheckScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCheckScan.Image = ((System.Drawing.Image)(resources.GetObject("picCheckScan.Image")));
            this.picCheckScan.Location = new System.Drawing.Point(0, 0);
            this.picCheckScan.Name = "picCheckScan";
            this.picCheckScan.Size = new System.Drawing.Size(238, 295);
            this.picCheckScan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // picBack
            // 
            this.picBack.BackColor = System.Drawing.Color.White;
            this.picBack.Image = ((System.Drawing.Image)(resources.GetObject("picBack.Image")));
            this.picBack.Location = new System.Drawing.Point(3, 5);
            this.picBack.Name = "picBack";
            this.picBack.Size = new System.Drawing.Size(8, 15);
            this.picBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // pic_logout
            // 
            this.pic_logout.BackColor = System.Drawing.Color.White;
            this.pic_logout.Image = ((System.Drawing.Image)(resources.GetObject("pic_logout.Image")));
            this.pic_logout.Location = new System.Drawing.Point(205, 6);
            this.pic_logout.Name = "pic_logout";
            this.pic_logout.Size = new System.Drawing.Size(30, 15);
            this.pic_logout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // CheckScan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.picBack);
            this.Controls.Add(this.pic_logout);
            this.Controls.Add(this.picCheckScan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckScan";
            this.Text = "CheckScan";
            this.Load += new System.EventHandler(this.CheckScan_Load);
            this.Closed += new System.EventHandler(this.CheckScan_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCheckScan;
        private System.Windows.Forms.PictureBox picBack;
        private System.Windows.Forms.PictureBox pic_logout;
    }
}