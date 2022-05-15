using NDP_TASK_3.Api;
using NDP_TASK_3.Objects;
using NDP_TASK_3.Reporters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDP_TASK_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.MaxDate = DateTime.Now.AddMonths(1);
            loadDataGrid(new GunlukMaliTablo(), DateTime.Now);
        }

        private void loadDataGrid(IReporter reporter, DateTime filterDate)
        {
            DataTable dataSource = new DataTable();
            dataGridView1.DataSource = dataSource;
            Report report = (Report)reporter.Report(filterDate);
            report.getColumns().ForEach((string item) => dataSource.Columns.Add(item, typeof(string)));
            foreach (List<string> item in report.getRows())
            {
                dataSource.Rows.Add(item.ToArray());
            }
            if(report.getRows().Count == 0)
            {
                dataSource.Rows.Add("Veri Bulunamadi");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadDataGrid(new DepodakiUrunler(), dateTimePicker1.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadDataGrid(new GunlukMaliTablo(), dateTimePicker1.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadDataGrid(new GunlukSatilanUrunler(), dateTimePicker1.Value);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadDataGrid(new GunlukSiparisler(), dateTimePicker1.Value);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadDataGrid(new RaftakiUrunler(), dateTimePicker1.Value);
        }
    }
}
