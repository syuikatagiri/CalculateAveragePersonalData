using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace CalculateAveragePersonalData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();       
        }
        
        /// <summary>
        /// データテーブルの作成,
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = createData();
            dataGridView1.DataSource = dt;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime datetime_now = DateTime.Now;
            currentTimeLabel.Text = datetime_now.ToLongTimeString();
        }

        private DataTable createData()
        {
            DataTable dt = new DataTable();
      
            dt.Columns.Add("Day", typeof(string));
            dt.Columns.Add("No.", typeof(int));
            dt.Columns.Add("Required", typeof(Decimal));
            dt.Columns.Add("wake up", typeof(string));

            string fileName = "PersonalData.csv";
            StreamReader sr = new StreamReader(@fileName);

            List<string[]> lists = new List<string[]>();

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                //カンマで配列の要素として分ける
                string[] values = line.Split(',');

                // 配列からリストに格納する
                dt.Rows.Add(values);
            }

            return dt;
        }
    }
}
