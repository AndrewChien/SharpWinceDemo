namespace PocketGate.QingDao
{
    partial class CheckManual
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
            this.picCheckManul = new System.Windows.Forms.PictureBox();
            this.txtChk = new System.Windows.Forms.TextBox();
            this.picDo = new System.Windows.Forms.PictureBox();
            this.pic_logout = new System.Windows.Forms.PictureBox();
            this.picBack = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // picCheckManul
            // 
            this.picCheckManul.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCheckManul.Location = new System.Drawing.Point(0, 0);
            this.picCheckManul.Name = "picCheckManul";
            this.picCheckManul.Size = new System.Drawing.Size(238, 295);
            this.picCheckManul.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // txtChk
            // 
            this.txtChk.Location = new System.Drawing.Point(13, 37);
            this.txtChk.Name = "txtChk";
            this.txtChk.Size = new System.Drawing.Size(213, 23);
            this.txtChk.TabIndex = 1;
            // 
            // picDo
            // 
            this.picDo.BackColor = System.Drawing.Color.White;
            this.picDo.Location = new System.Drawing.Point(13, 64);
            this.picDo.Name = "picDo";
            this.picDo.Size = new System.Drawing.Size(213, 24);
            this.picDo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // pic_logout
            // 
            this.pic_logout.BackColor = System.Drawing.Color.White;
            this.pic_logout.Location = new System.Drawing.Point(205, 8);
            this.pic_logout.Name = "pic_logout";
            this.pic_logout.Size = new System.Drawing.Size(30, 15);
            this.pic_logout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // picBack
            // 
            this.picBack.BackColor = System.Drawing.Color.White;
            this.picBack.Location = new System.Drawing.Point(3, 7);
            this.picBack.Name = "picBack";
            this.picBack.Size = new System.Drawing.Size(8, 15);
            this.picBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // CheckManual
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.picBack);
            this.Controls.Add(this.pic_logout);
            this.Controls.Add(this.picDo);
            this.Controls.Add(this.txtChk);
            this.Controls.Add(this.picCheckManul);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckManual";
            this.Text = "CheckManual";
            this.Load += new System.EventHandler(this.CheckManual_Load);
            this.Closed += new System.EventHandler(this.CheckManual_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCheckManul;
        private System.Windows.Forms.TextBox txtChk;
        private System.Windows.Forms.PictureBox picDo;
        private System.Windows.Forms.PictureBox pic_logout;
        private System.Windows.Forms.PictureBox picBack;
    }
}