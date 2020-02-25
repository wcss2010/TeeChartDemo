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
            this.btnXYLineImage2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnXYLineImage
            // 
            this.btnXYLineImage.Location = new System.Drawing.Point(12, 12);
            this.btnXYLineImage.Name = "btnXYLineImage";
            this.btnXYLineImage.Size = new System.Drawing.Size(112, 45);
            this.btnXYLineImage.TabIndex = 0;
            this.btnXYLineImage.Text = "曲线图(静态)";
            this.btnXYLineImage.UseVisualStyleBackColor = true;
            this.btnXYLineImage.Click += new System.EventHandler(this.btnXYLineImage_Click);
            // 
            // btnXYLineImage2
            // 
            this.btnXYLineImage2.Location = new System.Drawing.Point(153, 12);
            this.btnXYLineImage2.Name = "btnXYLineImage2";
            this.btnXYLineImage2.Size = new System.Drawing.Size(112, 45);
            this.btnXYLineImage2.TabIndex = 1;
            this.btnXYLineImage2.Text = "曲线图(动态)";
            this.btnXYLineImage2.UseVisualStyleBackColor = true;
            this.btnXYLineImage2.Click += new System.EventHandler(this.btnXYLineImage2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 415);
            this.Controls.Add(this.btnXYLineImage2);
            this.Controls.Add(this.btnXYLineImage);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnXYLineImage;
        private System.Windows.Forms.Button btnXYLineImage2;
    }
}

