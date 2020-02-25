using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Steema.TeeChart.Styles;
using System.Drawing;
using Steema.TeeChart;
using System.Collections;

namespace Steema.TeeChart
{
    public class TeeChartHelperB
    {
        private bool flagtime;
        private DateTime sdt;
        private DateTime edt;
        public TeeChartHelperB()
        {

        }
        /// <summary>
        /// 导出图片
        /// </summary>
        public void ExportPic(TChart tChart1)
        {
            #region 导出图片
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "jpg图片文档|*.jpg";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                   
                    tChart1.Export.Image.JPEG.Save(sfd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            #endregion
        }
       /// <summary>
       /// 打印图表
       /// </summary>
       /// <param name="tChart1"></param>
       /// <param name="hengx">true为横向打印，false为纵向打印</param>
        public void printPic(TChart tChart1, Boolean hengx)//hengx为true表示横向打印，flase表示纵向打印
        {
            #region 打印图表
            tChart1.Printer.Landscape = hengx; //横向
            //tChart1.Printer.Preview();
            tChart1.Printer.Grayscale = true;//彩色打印 false黑白打印
            tChart1.Printer.Print();
            #endregion
        }

        /// <summary>
        /// 显示3D效果
        /// </summary>
        public void View3D(TChart tChart1)
        {
            tChart1.Aspect.View3D = true;

        }
       /// <summary>
       /// 绘制曲线图，横纵轴均为数值
       /// </summary>
       /// <param name="tChart1"></param>
       /// <param name="title">色标显示标题</param>
       /// <param name="tmp_Yvalue">纵轴数据</param>
       /// <param name="XValue">横纵数据</param>
        /// <param name="showSeBiao">showSeBiao为true显示色标，false不显示</param>
        public void LineDrawing(TChart tChart1, string title, double[] tmp_Yvalue, double[] XValue, Boolean showSeBiao)
        {
            #region 单曲线绘制
            tChart1.Series.Clear();
            ShowSeBiao(tChart1, showSeBiao);

            Line lines = new Line(tChart1.Chart);
            lines.Color = Color.Blue;
            lines.Title = title;
            tChart1.Series.Add(lines);
            AddLine(tChart1, lines, tmp_Yvalue, XValue);
          
            #endregion

        }
        private void ShowSeBiao(TChart tChart1, bool flag)
        {
            if (flag)
            {
                tChart1.Legend.Alignment = Steema.TeeChart.LegendAlignments.Right;//色标显示位置
                tChart1.Legend.LegendStyle = Steema.TeeChart.LegendStyles.Series;//色标显示样式;
                tChart1.Legend.Visible = true;//色标显示
            }
            else
            {
                tChart1.Legend.Visible = false;
            }
          
        }

        #region 自定义函数
        /// <summary>
        /// 向TChart中添加曲线
        /// </summary>
        /// <param name="tChart1"></param>
        /// <param name="tmp_line"></param>
        /// <param name="tmp_Yvalue"></param>
        /// <param name="XValue"></param>
        private void AddLine(TChart tChart1, Line tmp_line, double[] tmp_Yvalue, double[] XValue)
        {

            tChart1.Aspect.View3D = false;//是否3D显示
            tmp_line.Marks.Gradient.Visible = true;//显示网格
            tmp_line.Marks.Visible = false;

            tmp_line.Marks.Gradient.StartColor = Color.FromArgb(255, 215, 0);//网格颜色设置
            tmp_line.Marks.Gradient.EndColor = Color.White;
            tmp_line.Marks.Symbol.Visible = true;

            tmp_line.Add(XValue, tmp_Yvalue);
            tmp_line.Pointer.Visible = true;
            tmp_line.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.SmallDot;
            tmp_line.Pointer.Color = Color.Black;
            tChart1.Axes.Left.Automatic = false;
            tChart1.Axes.Left.Minimum = getMin(tmp_Yvalue) - 1;
            tChart1.Axes.Left.Maximum = getMax(tmp_Yvalue) + 1;

            tChart1.Axes.Left.Increment = 0;//纵坐标增量
            tChart1.Page.MaxPointsPerPage = 0;
            tChart1.Axes.Bottom.Increment =0;//横坐标增量
            
            int len = XValue.Length;
            tChart1.Axes.Bottom.SetMinMax(XValue[0], XValue[len - 1]);
            tChart1.Refresh();
            tChart1.Axes.Bottom.Labels.MultiLine = false;
        }
        #endregion
        /// <summary>
        /// 根据DataGridView数据列绘制曲线图
        /// </summary>
        /// <param name="tChart1"></param>
        /// <param name="title">图标标题</param>
        /// <param name="dgv">DataGridView</param>
        /// <param name="showSeBiao">true显示色标，false不显示</param>
        /// <param name="Xindex">自定义横轴所在列</param>
        public void LineDrawing(TChart tChart1, string title, DataGridView dgv, Boolean showSeBiao, int Xindex)//Xindex横轴所在列
        {
            tChart1.Series.Clear();
            Line lines = new Line(tChart1.Chart);
            lines.Color = Color.Blue;
            lines.Title = title;
            tChart1.Series.Add(lines);
            AddLine(tChart1, lines, dgv, Xindex);
            ShowSeBiao(tChart1, showSeBiao);

        }
        
        /// <summary>
        /// 向TChart添加曲线，根据选择列定义纵轴
        /// </summary>
        /// <param name="tChart1"></param>
        /// <param name="tmp_line"></param>
        /// <param name="dgv"></param>
        /// <param name="Xindex">自定义横轴所在列</param>
        private void AddLine(TChart tChart1, Line tmp_line, DataGridView dgv, int Xindex)//Xindex表示X轴所在列
        {
            int j = 0;
           
            dgv.MultiSelect = false;
            double tmp_value = 0;
            DateTime tmp_times;
            j = dgv.CurrentCell.ColumnIndex;
            int count = dgv.Rows.Count;
            double[] tmp_Yvalue = new double[count - 1];
            DateTime[] tmp_time = new DateTime[count - 1];
            string[] XValue = new string[count - 1];
            for (int i = 0; i < dgv.Rows.Count - 1; i++)//y轴数据列
            {
                if (j != 0)
                {
                    if (double.TryParse(dgv.Rows[i].Cells[j].Value.ToString(), out tmp_value))
                    {
                        if (dgv.Rows[i].Cells[j].Value.ToString() != "" && dgv.Rows[i].Cells[j].Value != null)
                        {
                            tmp_Yvalue[i] = Convert.ToDouble(dgv.Rows[i].Cells[j].Value.ToString());
                        }

                    }
                    else
                    {
                        MessageBox.Show("请选择数据列！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        for (int s = 0; s < dgv.Rows.Count - 1; s++)
                        {
                            tmp_Yvalue[s] = 0;
                        }
                        break;
                    }
                }

            }
            for (int i = 0; i < dgv.Rows.Count - 1; i++)//x轴是否为时间列
            {
                if (j != 0)
                {
                    if (DateTime.TryParse(dgv.Rows[i].Cells[Xindex].Value.ToString(), out tmp_times))
                    {
                        if (dgv.Rows[i].Cells[Xindex].Value.ToString() != "" && dgv.Rows[i].Cells[Xindex].Value != null)
                        {
                            tmp_time[i] = Convert.ToDateTime(dgv.Rows[i].Cells[Xindex].Value.ToString());
                        }
                        flagtime = true;

                    }
                    else
                    {
                        flagtime = false;
                        break;
                    }

                }

            }
            for (int i = 0; i < dgv.Rows.Count - 1; i++)//x轴不为时间列
            {
                if (j != 0)
                {
                    if (!flagtime)
                    {
                        if (dgv.Rows[i].Cells[Xindex].Value.ToString() != "" && dgv.Rows[i].Cells[Xindex].Value != null)
                        {
                            XValue[i] = dgv.Rows[i].Cells[Xindex].Value.ToString();
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            tChart1.Aspect.View3D = false;//是否3D显示
            tmp_line.Marks.Gradient.Visible = true;//显示网格
            tmp_line.Marks.Visible = false;

            tmp_line.Marks.Gradient.StartColor = Color.FromArgb(255, 215, 0);//网格颜色设置
            tmp_line.Marks.Gradient.EndColor = Color.White;
            tmp_line.Marks.Symbol.Visible = true;
            if (flagtime)//横轴为时间列
            {
                tmp_line.XValues.DateTime = true;
                tmp_line.Add(tmp_time, tmp_Yvalue);
                tChart1.Axes.Bottom.Increment = Steema.TeeChart.Utils.GetDateTimeStep(Steema.TeeChart.DateTimeSteps.OneMonth);//横坐标按月增量 
                tChart1.Axes.Bottom.Labels.DateTimeFormat = "yyyy-MM-dd";
                tChart1.Axes.Bottom.Automatic = true;
                sdt= getMin(tmp_time).AddDays(-1);
                edt = getMax(tmp_time).AddDays(1);
               tChart1.Axes.Bottom.SetMinMax(sdt, edt);

            }
            else
            {
                for (int m = 0; m < tmp_Yvalue.Length; m++)
                {
                    tmp_line.Add(tmp_Yvalue[m], XValue[m]);
                }
                int len = XValue.Length;
                tChart1.Axes.Bottom.SetMinMax(0, len);
               
            }
            tmp_line.Pointer.Visible = true;
            tmp_line.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.SmallDot;
            tmp_line.Pointer.Color = Color.Black;
            tChart1.Axes.Left.Automatic = false;
            tChart1.Axes.Left.Minimum = getMin(tmp_Yvalue) - 1;
            tChart1.Axes.Left.Maximum = getMax(tmp_Yvalue) + 1;

            tChart1.Axes.Left.Increment = 0;//纵坐标增量
           //  tChart1.Page.MaxPointsPerPage = 0;
           /// tChart1.Axes.Bottom.Increment = 0;//横坐标增量
            tChart1.Axes.Bottom.Labels.MultiLine = false;
            tChart1.Refresh();
           
        }

        /// <summary>
        /// 曲线图 以时间为横轴
        /// </summary>
        /// <param name="tChart1"></param>
        /// <param name="title"></param>
        /// <param name="tmp_Yvalue"></param>
        /// <param name="XValue"></param>
        public void LineDrawing(TChart tChart1, string title, double[] tmp_Yvalue, DateTime[] XValue,Boolean showSeBiao)//以时间为横轴
        {
            tChart1.Series.Clear();
            Line lines = new Line(tChart1.Chart);
            lines.Color = Color.Blue;
            lines.Title = title;
            tChart1.Series.Add(lines);
            AddLine(tChart1, lines, tmp_Yvalue, XValue);
            ShowSeBiao(tChart1, showSeBiao);


        }
        /// <summary>
        /// 时间为横轴绘制曲线
        /// </summary>
        /// <param name="tChart1"></param>
        /// <param name="tmp_line"></param>
        /// <param name="tmp_Yvalue"></param>
        /// <param name="XValue"></param>
        private void AddLine(TChart tChart1, Line tmp_line, double[] tmp_Yvalue, DateTime[] XValue)
        {
            tChart1.Aspect.View3D = false;//是否3D显示
            tmp_line.Marks.Gradient.Visible = true;//显示网格
            tmp_line.Marks.Visible = false;

            tmp_line.Marks.Gradient.StartColor = Color.FromArgb(255, 215, 0);//网格颜色设置
            tmp_line.Marks.Gradient.EndColor = Color.White;
            tmp_line.Marks.Symbol.Visible = true;

            tmp_line.Add(XValue, tmp_Yvalue);
            tmp_line.Pointer.Visible = true;
            tmp_line.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.SmallDot;
            tmp_line.Pointer.Color = Color.Black;
            tChart1.Axes.Left.Automatic = false;
            tChart1.Axes.Left.Minimum = getMin(tmp_Yvalue) - 1;
            tChart1.Axes.Left.Maximum = getMax(tmp_Yvalue) + 1;
            tChart1.Axes.Left.Increment = 0.4;//纵坐标增量
            tChart1.Page.MaxPointsPerPage = 0;
            tChart1.Axes.Bottom.Increment = Steema.TeeChart.Utils.GetDateTimeStep(Steema.TeeChart.DateTimeSteps.OneMonth);//横坐标按月增量 
            int len = XValue.Length;
            tChart1.Axes.Bottom.SetMinMax(XValue[0], XValue[len-1]);
            tChart1.Refresh();
            tChart1.Axes.Bottom.Labels.MultiLine = false;
            tmp_line.XValues.DateTime = true;

        }
        /// <summary>
        /// 横轴为时间轴时，坐标增量值设定
        /// </summary>
        /// <param name="tChart1"></param>
        /// <param name="time">day表示按日增长，week按周增长，month按月增长</param>
        public void showType(TChart tChart1,string time)
        {
           
            if (time == "day")
            {
                tChart1.Axes.Bottom.Increment = Steema.TeeChart.Utils.GetDateTimeStep(Steema.TeeChart.DateTimeSteps.OneDay);//横坐标按日增量 
            }
            else if (time == "week")
            {
                tChart1.Axes.Bottom.Increment = Steema.TeeChart.Utils.GetDateTimeStep(Steema.TeeChart.DateTimeSteps.OneWeek);//横坐标按周增量 

            }
            else if (time == "month")
            {
                tChart1.Axes.Bottom.Increment = Steema.TeeChart.Utils.GetDateTimeStep(Steema.TeeChart.DateTimeSteps.OneMonth);//横坐标按月增量 

            }
            else if (time == "year")
            {
                tChart1.Axes.Bottom.Increment = Steema.TeeChart.Utils.GetDateTimeStep(Steema.TeeChart.DateTimeSteps.OneYear);//横坐标按年增量 

            }
        
        }

        public void LineDrawing(TChart tChart1, string title, string[] tmp_Yvalue, string[] XValue, Boolean showSeBiao)
        {
            tChart1.Series.Clear();
            Line lines = new Line(tChart1.Chart);
            lines.Color = Color.Blue;
            lines.Title = title;
            tChart1.Series.Add(lines);
            AddLine(tChart1, lines, tmp_Yvalue, XValue);
            ShowSeBiao(tChart1, showSeBiao);

        }
        #region XY轴数据为字符串数组
        private void AddLine(TChart tChart1, Line tmp_line, string[] tmp_Yvalue, string[] XValue)
        {
            int len = tmp_Yvalue.Length;
            double tmp_yvalue;
            DateTime tmp_time;
            double[] tmp_Yvalue1 = new double[len];
            DateTime[] tmp_Xvalue = new DateTime[len];
            bool ftime=false;
            for (int i = 0; i < tmp_Yvalue.Length; i++)//y轴为数据轴，否则设为0
            {
                if (double.TryParse(tmp_Yvalue[i], out tmp_yvalue))
                {
                    tmp_Yvalue1[i] = tmp_yvalue;
                }
                else
                {
                    tmp_Yvalue1[i] = 0;
                }
            }
            for (int i = 0; i < XValue.Length; i++)//y轴为数据轴，否则设为0
            {

                if (DateTime.TryParse(XValue[i], out tmp_time))
                {
                    tmp_Xvalue[i] = tmp_time;
                    ftime = true;
                }
                else
                {
                    ftime = false;
                    break;
                }
            }
            tChart1.Aspect.View3D = false;//是否3D显示
            tmp_line.Marks.Gradient.Visible = true;//显示网格
            tmp_line.Marks.Visible = false;

            tmp_line.Marks.Gradient.StartColor = Color.FromArgb(255, 215, 0);//网格颜色设置
            tmp_line.Marks.Gradient.EndColor = Color.White;
            tmp_line.Marks.Symbol.Visible = true;
            if (ftime)
            {
                tmp_line.Add(tmp_Xvalue, tmp_Yvalue1);
            }
            else
            {
                for (int j = 0; j < tmp_Yvalue1.Length; j++)
                {
                    tmp_line.Add(tmp_Yvalue1[j], XValue[j]);
                }
            }
            tmp_line.Pointer.Visible = true;
            tmp_line.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.SmallDot;
            tmp_line.Pointer.Color = Color.Black;
            tChart1.Axes.Left.Automatic = false;
            tChart1.Axes.Left.Minimum = getMin(tmp_Yvalue1) - 1;
            tChart1.Axes.Left.Maximum = getMax(tmp_Yvalue1) + 1;
            tChart1.Axes.Bottom.Automatic = false;
            tChart1.Axes.Bottom.Increment = 0;//横坐标增量
         
            tChart1.Axes.Left.Increment =0;//纵坐标增量
           
            int lenx = XValue.Length;
            tChart1.Axes.Bottom.SetMinMax(0, lenx - 1);
            tChart1.Refresh();

            tChart1.Axes.Bottom.Labels.MultiLine = false;
        }
        #endregion

        /// <summary>
        /// 柱形图 
        /// </summary>
        /// <param name="tChart1"></param>
        /// <param name="tmp_Yvalue"></param>
        /// <param name="XValue"></param>
        public void BarDrawing(TChart tChart1,  double[] tmp_Yvalue, double[] XValue,Boolean showSeBiao)
        {
            tChart1.Series.Clear();
            Bar bars = new Bar(tChart1.Chart);
            bars.Color = Color.Blue;
            //bars.Title = title;
            tChart1.Series.Add(bars);
            AddBar(tChart1, bars, tmp_Yvalue, XValue);
            ShowSeBiao(tChart1, showSeBiao);

        }

        private void AddBar(TChart tChart1, Bar tmp_bar, double[] tmp_Yvalue, double[] XValue)
        {
            tChart1.Aspect.View3D = false;
            tmp_bar.Marks.Gradient.Visible = true;
            tmp_bar.Marks.Visible = false;//标签卡不显示

            tmp_bar.Marks.Gradient.StartColor = Color.FromArgb(255, 215, 0);//网格颜色设置
            tmp_bar.Marks.Gradient.EndColor = Color.White;
            tmp_bar.Marks.Symbol.Visible = true;
            
            tmp_bar.Add(XValue, tmp_Yvalue);
            tChart1.Axes.Left.Minimum = getMin(tmp_Yvalue) - 1;
            tChart1.Axes.Left.Maximum = getMax(tmp_Yvalue) + 1;
            tChart1.Axes.Left.Increment = 0;//纵坐标增量
            tChart1.Page.MaxPointsPerPage = 0;
            tChart1.Axes.Bottom.Increment = 0;//横坐标增量
            
            int len = XValue.Length;
            tChart1.Axes.Bottom.SetMinMax(XValue[0], XValue[len-1]);
            tChart1.Refresh();

        }
        public void BarDrawing(TChart tChart1, DataGridView dgv, Boolean showSeBiao, int Xindex)
        {
            tChart1.Series.Clear();
            Bar bars = new Bar(tChart1.Chart);
            bars.Color = Color.Blue;
            tChart1.Series.Add(bars);
            AddBar(tChart1, bars, dgv, Xindex);
            ShowSeBiao(tChart1, showSeBiao);

        }
        /// <summary>
        /// 根据DataGridView中选中列数据绘制柱状图
        /// </summary>
        /// <param name="tChart1"></param>
        /// <param name="tmp_bar"></param>
        /// <param name="dgv"></param>
        private void AddBar(TChart tChart1, Bar tmp_bar, DataGridView dgv, int Xindex)
        {
            int j = 0;
            flagtime = false;
            dgv.MultiSelect = false;
            double tmp_value = 0;
            DateTime tmp_times;
            j = dgv.CurrentCell.ColumnIndex;
            int count = dgv.Rows.Count;
            double[] tmp_Yvalue = new double[count - 1];
            DateTime[] tmp_time=new DateTime[count - 1];
            string[] XValue = new string[count - 1];
            for (int i = 0; i < dgv.Rows.Count - 1; i++)//y轴数据列
            {
                if (j != 0)
                {
                    if (double.TryParse(dgv.Rows[i].Cells[j].Value.ToString(), out tmp_value))
                    {
                        if (dgv.Rows[i].Cells[j].Value.ToString() != "" && dgv.Rows[i].Cells[j].Value != null)
                        {
                            tmp_Yvalue[i] = Convert.ToDouble(dgv.Rows[i].Cells[j].Value.ToString());
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("请选择数据列！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        for (int s = 0; s < dgv.Rows.Count - 1; s++)
                        {
                            tmp_Yvalue[s] = 0;
                        }
                        break;
                    }
                }

            }
            for (int i = 0; i < dgv.Rows.Count - 1; i++)//x轴是否为时间列
            {
                if (j != 0)
                {
                    if (DateTime.TryParse(dgv.Rows[i].Cells[Xindex].Value.ToString(), out tmp_times))
                    {
                        if (dgv.Rows[i].Cells[Xindex].Value.ToString() != "" && dgv.Rows[i].Cells[Xindex].Value != null)
                        {
                            tmp_time[i] = Convert.ToDateTime(dgv.Rows[i].Cells[Xindex].Value.ToString());
                        }
                        flagtime = true;

                    }
                    else
                    {
                        flagtime = false;
                        break;
                    }
                  
                }

            }
            for (int i = 0; i < dgv.Rows.Count - 1; i++)//x轴不为时间列
            {
                if (j != 0)
                {
                    if (!flagtime)
                    {
                        if (dgv.Rows[i].Cells[Xindex].Value.ToString() != "" && dgv.Rows[i].Cells[Xindex].Value != null)
                        {
                            XValue[i] = dgv.Rows[i].Cells[Xindex].Value.ToString();
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            tChart1.Aspect.View3D = false;//是否3D显示
            tmp_bar.Marks.Gradient.Visible = true;//显示网格
            tmp_bar.Marks.Visible = false;
           
            tmp_bar.Marks.Gradient.StartColor = Color.FromArgb(255, 215, 0);//网格颜色设置
            tmp_bar.Marks.Gradient.EndColor = Color.White;
            tmp_bar.Marks.Symbol.Visible = true;
            if (flagtime)
            {
                tmp_bar.Add(tmp_time, tmp_Yvalue);
                DateTime mindt = getMin(tmp_time);
                DateTime maxdt = getMax(tmp_time);
                tChart1.Axes.Bottom.SetMinMax(mindt, maxdt);
            }
            else
            {
                for (int m = 0; m < tmp_Yvalue.Length; m++)
                {
                    tmp_bar.Add(tmp_Yvalue[m], XValue[m]);
                }
                int len = XValue.Length;
                tChart1.Axes.Bottom.SetMinMax(0, len);
            }
            tChart1.Axes.Bottom.MaximumOffset =0;
            tChart1.Axes.Bottom.MinimumOffset = 0;
            tChart1.Axes.Left.Automatic = false;
            tChart1.Axes.Left.Minimum = getMin(tmp_Yvalue) - 1;
            tChart1.Axes.Left.Maximum = getMax(tmp_Yvalue) + 1;
            tChart1.Axes.Bottom.Automatic = false;
            tChart1.Axes.Left.Increment = 0;//纵坐标增量
            tChart1.Axes.Bottom.Increment = 0;//横坐标增量
            
            tChart1.Refresh();
            tChart1.Axes.Bottom.Labels.MultiLine = false;
            
        }
        /// <summary>
        /// 设置图表标题
        /// </summary>
        /// <param name="tchart1"></param>
        /// <param name="headerText"></param>
        public void setHeaderText(TChart tchart1, string headerText)
        {

            tchart1.Header.Text = headerText;
        }

        private void AddLine(TChart tchart1, Line tmp_line, ArrayList Xvalue, ArrayList Yvalue)
        {
            string[] tmp_yvalue = (string[])Yvalue.ToArray(typeof(string));
            string[] tmp_xvalue = (string[])Xvalue.ToArray(typeof(string));
            this.AddLine(tchart1,tmp_line, tmp_yvalue, tmp_xvalue);

        }
        private double getMax(double[] tmp_Yvalue)//获得纵坐标的最大值
        {
            #region
            double max = 0;
            for (int i = 0; i < tmp_Yvalue.Length; i++)
            {
                if (tmp_Yvalue[i] > max)
                {
                    max = tmp_Yvalue[i];
                }

            }
            return max;
            #endregion
        }
        private double getMin(double[] tmp_Yvalue)//获得坐标轴的最小值
        {
            #region
            double min = tmp_Yvalue[0];
            for (int i = 0; i < tmp_Yvalue.Length; i++)
            {
                if (tmp_Yvalue[i] < min)
                {
                    min = tmp_Yvalue[i];
                }

            }
            return min;
            #endregion
        }
        private DateTime getMax(DateTime[] tmp_Yvalue)//获得时间坐标轴的最大值
        {
            DateTime max=tmp_Yvalue[0];
            for (int i = 0; i < tmp_Yvalue.Length; i++)
            {
                if (tmp_Yvalue[i] > max)
                {
                    max = tmp_Yvalue[i];
                }

            }
            return max;
        }
        private DateTime getMin(DateTime[] tmp_Yvalue)//获得时间坐标轴的最小值
        {
            DateTime min = tmp_Yvalue[0];
            for (int i = 0; i < tmp_Yvalue.Length; i++)
            {
                if (tmp_Yvalue[i] < min)
                {
                    min = tmp_Yvalue[i];
                }

            }
            return min;
        }
    }
}