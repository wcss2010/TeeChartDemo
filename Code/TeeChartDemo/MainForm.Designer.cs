namespace TeeChartDemo
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
            this.btnXYLineImage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnXYLineImage
            // 
            this.btnXYLineImage.Location = new System.Drawing.Point(12, 12);
            this.btnXYLineImage.Name = "btnXYLineImage";
            this.btnXYLineImage.Size = new System.Drawing.Size(112, 45);
            this.btnXYLineImage.TabIndex = 0;
            this.btnXYLineImage.Text = "曲线图";
            this.btnXYLineImage.UseVisualStyleBackColor = true;
            this.btnXYLineImage.Click += new System.EventHandler(this.btnXYLineImage_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 415);
            this.Controls.Add(this.btnXYLineImage);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnXYLineImage;
    }
}

