using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDV_Buoi8
{
  public  class XuLyData
    {
       DataClasses1DataContext data = new DataClasses1DataContext();
       public void LoadMonHoc(DataGridView dtg)
       {
        var monhocs = from mh in data.MonHocs select mh;
        {
            dtg.DataSource = monhocs;
        }
       }
       public void LoadSinhVien(DataGridView dtg)
       {
           var sinhviens = from sv in data.SinhViens select new { sv.MaSinhVien,sv.HoTen,sv.NgaySinh,sv.MaLop};
           {
               dtg.DataSource = sinhviens;
           }
       }
      public void LoadMauDauSinhvien(DataGridView dtg)
      {
          var SinhViens= (from sv in data.SinhViens select sv).Skip(0).Take(1);
          dtg.DataSource = SinhViens;
      }
      public void LoadSinhVienCuoi(DataGridView dtg)
      {
          int cuoi = data.SinhViens.Count();
          var SinhvienCuoi = (from sv in data.SinhViens select new { sv.MaSinhVien,sv.MaLop }).Skip(cuoi - 1).Take(1);
          dtg.DataSource = SinhvienCuoi;
      }



      //
      public void ThemMonHoc(string pMamon,string pTenMon, DataGridView dtg)
      {
          MonHoc mh = new MonHoc();
          mh.MaMonHoc = pMamon;
          mh.TenMonHoc = pTenMon;

          data.MonHocs.InsertOnSubmit(mh);
          data.SubmitChanges();
          var monhocs = from mh1 in data.MonHocs select mh1;
          dtg.DataSource = monhocs;
      }

      //
      public void XoaMonHoc(string pMamon, DataGridView dtg)
      {
          pMamon = dtg.CurrentRow.Cells[0].Value.ToString();
          MonHoc mh = data.MonHocs.Where(t => t.MaMonHoc == pMamon).FirstOrDefault();

          data.MonHocs.DeleteOnSubmit(mh);

          data.SubmitChanges();
          //Refresh Dataa
          var monhocs = from mh1 in data.MonHocs select mh1;
          dtg.DataSource = monhocs;
      }
      
      //
      public bool SuaMonHoc( DataGridView dtg,string pTenmon)
      {
          MonHoc _monsua = data.MonHocs.Where(mh => mh.MaMonHoc == dtg.CurrentRow.Cells[0].Value.ToString()).FirstOrDefault();
          if (_monsua != null)
          {
              _monsua.TenMonHoc = pTenmon;
              data.SubmitChanges();
              return true;
          }
          return false;
         
      }

      public void LoadKhoa(ComboBox cbb)
      {
          var khoas = from kh in data.Khoas select kh;
          {
              cbb.DataSource = khoas;
              cbb.ValueMember = "MaKhoa";
          }
      }

      public void LoadLop(ComboBox cbb)
      {
          var lop = from l in data.Lops select l;
          {
              cbb.DataSource = lop;
              cbb.ValueMember = "MaLop";
          }
      }

      //public DataTable LoadLop(ComboBox cbb)
      //{
      //    var lop = from l in data.Lops select new { l.MaLop, l.TenLop };
      //    DataTable dt = new DataTable();
      //    dt.Columns.Add("MaLop");
      //    dt.Columns.Add("TenLop");
      //    dt.Rows.Add(lop.ToArray());
      //    cbb.DataSource = lop;
      //    cbb.ValueMember="MaLop";
      //    return dt;
      //}
      

      //
      
    }
}
