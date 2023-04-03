using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDV_Buoi8
{
    public partial class Form2 : Form
    {
        XuLyData xuly = new XuLyData();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            xuly.LoadSinhVien(dataGridView1);
            xuly.LoadKhoa(cbbMakhoa);
            xuly.LoadLop(cbbMalop);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            txtMaSV.Text = row.Cells[0].Value.ToString();
            txtHoten.Text = row.Cells[1].Value.ToString();
            cbbMalop.Text = row.Cells[3].Value.ToString();
            string m = row.Cells[2].Value.ToString();
            DateTime dt = DateTime.Parse(m);
            dateTimePicker1.Value = dt;
        }
    }
}
