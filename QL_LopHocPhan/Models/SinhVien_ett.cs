using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QL_LopHocPhan.Models
{
    public class SinhVien_ett:tbl_SinhVien
    {
        public string STT { get; set; }
        public SinhVien_ett()
        {

        }
        public void BindObj(tbl_SinhVien obj)
        {
            this.MSSV = obj.MSSV;
            this.HoTen = obj.HoTen;
            this.DiaChi = obj.DiaChi;
            this.KhoaHoc = obj.KhoaHoc;
            this.LopQuanLy = obj.LopQuanLy;
            this.NgaySinh = obj.NgaySinh;
            this.GioiTinh = obj.GioiTinh;
        }
        public SinhVien_ett(tbl_SinhVien obj)
        {
            BindObj(obj);
        }
    }
}