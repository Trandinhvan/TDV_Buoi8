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
    public partial class Form1 : Form
    {
        XuLyData xuly = new XuLyData();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            xuly.LoadMonHoc(dataGridView1);
            //xuly.LoadSinhVienCuoi(dataGridView2);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuly.ThemMonHoc(txtMaMonHoc.Text, txtTenMonHoc.Text, dataGridView1);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            xuly.XoaMonHoc(txtMaMonHoc.Text, dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            txtMaMonHoc.Text = row.Cells[0].Value.ToString();
            txtTenMonHoc.Text = row.Cells[1].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(xuly.SuaMonHoc(dataGridView1,txtTenMonHoc.Text))
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
        }
    }
}
