using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dotnetCHARTING.WinForms;
namespace TeeChartDemo
{
    public partial class D3 : Form
    {
        public D3()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1_SelectedIndexChanged(null, null);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.SeriesCollection.Clear();
            ShowData show = new ShowData();
            #region 调用说明及范例
            //在要显示统计图的页面代码直接调用，方法类似如下：        

            show.Title = "2012年各月消费情况统计";
            show.XTitle = "月份";
            show.YTitle = "金额(万元)";
            show.PicHight = 300;
            show.PicWidth = 600;
            show.SeriesName = "总金额";
            show.PhaysicalImagePath = "images";
            DataTable dt = new DataTable();
            dt.Columns.Add("month", typeof(string));
            dt.Columns.Add("money", typeof(string));
            dt.Columns["month"].AutoIncrement = true;
            for (int i = 1; i < 13; i++)
            {
                DataRow dr = dt.NewRow();
                dr["month"] = i.ToString();
                dr["money"] = 100 * i;
                dt.Rows.Add(dr);
            }
            show.DataSource = dt;



            #endregion
            if (comboBox1.Text == "柱状图")
            {
                show.CreateColumn(chart1);//显示柱形图

            }
            else if (comboBox1.Text == "饼状图")
            {
                show.CreatePie(this.chart1);   //显示饼图
            }
            else if (comboBox1.Text == "线状图")
            {
                show.CreateLine(this.chart1);  //显示曲线图
            }
            chart1.Refresh(); 
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Image image = chart1.GetChartBitmap() as Image;
                if (image != null)
                {
                    e.Graphics.DrawImage(image, e.Graphics.VisibleClipBounds);
                    e.HasMorePages = false;
                }
            }
            catch (Exception exception)
            {

            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            if (printDialog.ShowDialog(this) == DialogResult.OK) //到这里会出现选择打印项的窗口  
            {
                printDocument1.Print(); //到这里会出现给文件命名的窗口，点击确定后进行打印并完成打印  
            }  
        }
    }
}
