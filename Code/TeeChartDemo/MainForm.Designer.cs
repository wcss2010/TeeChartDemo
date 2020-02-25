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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThirdImageForm = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnXYLineImage
            // 
            this.btnXYLineImage.Location = new System.Drawing.Point(17, 35);
            this.btnXYLineImage.Name = "btnXYLineImage";
            this.btnXYLineImage.Size = new System.Drawing.Size(112, 45);
            this.btnXYLineImage.TabIndex = 0;
            this.btnXYLineImage.Text = "曲线图(静态)";
            this.btnXYLineImage.UseVisualStyleBackColor = true;
            this.btnXYLineImage.Click += new System.EventHandler(this.btnXYLineImage_Click);
            // 
            // btnXYLineImage2
            // 
            this.btnXYLineImage2.Location = new System.Drawing.Point(158, 35);
            this.btnXYLineImage2.Name = "btnXYLineImage2";
            this.btnXYLineImage2.Size = new System.Drawing.Size(112, 45);
            this.btnXYLineImage2.TabIndex = 1;
            this.btnXYLineImage2.Text = "曲线图(动态)";
            this.btnXYLineImage2.UseVisualStyleBackColor = true;
            this.btnXYLineImage2.Click += new System.EventHandler(this.btnXYLineImage2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnXYLineImage);
            this.groupBox1.Controls.Add(this.btnXYLineImage2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TeeChart";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnThirdImageForm);
            this.groupBox2.Location = new System.Drawing.Point(12, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 103);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = ".NetCharting";
            // 
            // btnThirdImageForm
            // 
            this.btnThirdImageForm.Location = new System.Drawing.Point(17, 31);
            this.btnThirdImageForm.Name = "btnThirdImageForm";
            this.btnThirdImageForm.Size = new System.Drawing.Size(253, 39);
            this.btnThirdImageForm.TabIndex = 0;
            this.btnThirdImageForm.Text = "饼图，线图，柱图";
            this.btnThirdImageForm.UseVisualStyleBackColor = true;
            this.btnThirdImageForm.Click += new System.EventHandler(this.btnThirdImageForm_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 415);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TeeChart与.NetCharting控件演示";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnXYLineImage;
        private System.Windows.Forms.Button btnXYLineImage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnThirdImageForm;
    }
}

