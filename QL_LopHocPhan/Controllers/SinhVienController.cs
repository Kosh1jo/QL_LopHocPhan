﻿using QL_LopHocPhan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Globalization;

namespace QL_LopHocPhan.Controllers
{
    public class SinhVienController : Controller
    {

        DatabaseDataContext db = new DatabaseDataContext("Data Source=KOSH1JO\\KOSHIJO;Initial Catalog=DemoC#QLSV_65pm34;Persist Security Info=True;User ID=Anhtuan;Password=anhtuan123");
        // GET: SinhVien
        public ActionResult Index()
        {
            return View();
        }

        //Lấy ra danh sách sinh viên
        public string SearchPaging(string orderby,string sortOrder,string pageSize,string keywords,string currentPage)
        {
            int pageSizeValue = Convert.ToInt32(pageSize);
            int currentPageValue = Convert.ToInt32(currentPage);
            int skip = (currentPageValue - 1) * pageSizeValue;
            int totalCount=0;
            List<tbl_SinhVien> dssv = new List<tbl_SinhVien>();
            List<SinhVien_ett> list = new List<SinhVien_ett>();
            List<SinhVien_ett> newlist = new List<SinhVien_ett>();
            if (keywords!="")
            {
                switch (orderby)
                {
                    case "0":
                        dssv = db.tbl_SinhViens.ToList();
                        for (int i = 0; i < dssv.Count; i++)
                        {
                            SinhVien_ett obj = new SinhVien_ett(dssv[i]);
                            obj.STT = Convert.ToString(skip + i + 1);
                            list.Add(obj);
                        }
                        totalCount = list.Count();
                        if (sortOrder!="")
                        {
                            switch (sortOrder)
                            {
                                case "0":case "1":
                                    newlist = list.OrderBy(x => x.STT).ToList();
                                    for (int i = 0; i < newlist.Count; i++)
                                    {
                                        newlist[i].STT = Convert.ToString(skip + i + 1);
                                    }
                                    break;
                                case "2":
                                    newlist = list.OrderBy(x => x.STT).Reverse().ToList();
                                    for (int i = 0; i < newlist.Count; i++)
                                    {
                                        newlist[i].STT = Convert.ToString(skip + i + 1);
                                    }
                                    break;
                            }
                            list = newlist;
                        }
                        list = list.Skip(skip).Take(pageSizeValue).ToList();
                        break;
                    case "1":
                        dssv = db.tbl_SinhViens.Where(o=>o.MSSV.Contains(keywords)).ToList();
                        for (int i = 0; i < dssv.Count; i++)
                        {
                            SinhVien_ett obj = new SinhVien_ett(dssv[i]);
                            obj.STT = Convert.ToString(skip + i + 1);
                            list.Add(obj);
                        }
                        totalCount = list.Count();
                        if (sortOrder != "")
                        {
                            switch (sortOrder)
                            {
                                case "0":
                                case "1":
                                    newlist = list.OrderBy(x => x.MSSV).ToList();
                                    for (int i = 0; i < newlist.Count; i++)
                                    {
                                        newlist[i].STT = Convert.ToString(skip + i + 1);
                                    }
                                    break;
                                case "2":
                                    newlist = list.OrderBy(x => x.MSSV).Reverse().ToList();
                                    for (int i = 0; i < newlist.Count; i++)
                                    {
                                        newlist[i].STT = Convert.ToString(skip + i + 1);
                                    }
                                    break;
                            }
                            list = newlist;
                        }
                        list = list.Skip(skip).Take(pageSizeValue).ToList();
                        break;
                    case "2":
                        dssv = db.tbl_SinhViens.Where(o => o.HoTen.Contains(keywords)).ToList();
                        for (int i = 0; i < dssv.Count; i++)
                        {
                            SinhVien_ett obj = new SinhVien_ett(dssv[i]);
                            obj.STT = Convert.ToString(skip + i + 1);
                            list.Add(obj);
                        }
                        totalCount = list.Count();
                        if (sortOrder != "")
                        {
                            switch (sortOrder)
                            {
                                case "0":
                                case "1":
                                    newlist = list.OrderBy(x => x.HoTen).ToList();
                                    for (int i = 0; i < newlist.Count; i++)
                                    {
                                        newlist[i].STT = Convert.ToString(skip + i + 1);
                                    }
                                    break;
                                case "2":
                                    newlist = list.OrderBy(x => x.HoTen).Reverse().ToList();
                                    for (int i = 0; i < newlist.Count; i++)
                                    {
                                        newlist[i].STT = Convert.ToString(skip + i + 1);
                                    }
                                    break;
                            }
                            list = newlist;
                        }
                        list = list.Skip(skip).Take(pageSizeValue).ToList();
                        break;
                    case "3":
                        dssv = db.tbl_SinhViens.Where(o => o.DiaChi.Contains(keywords)).ToList();
                        for (int i = 0; i < dssv.Count; i++)
                        {
                            SinhVien_ett obj = new SinhVien_ett(dssv[i]);
                            obj.STT = Convert.ToString(skip + i + 1);
                            list.Add(obj);
                        }
                        totalCount = list.Count();
                        if (sortOrder != "")
                        {
                            switch (sortOrder)
                            {
                                case "0":
                                case "1":
                                    newlist = list.OrderBy(x => x.DiaChi).ToList();
                                    for (int i = 0; i < newlist.Count; i++)
                                    {
                                        newlist[i].STT = Convert.ToString(skip + i + 1);
                                    }
                                    break;
                                case "2":
                                    newlist = list.OrderBy(x => x.DiaChi).Reverse().ToList();
                                    for (int i = 0; i < newlist.Count; i++)
                                    {
                                        newlist[i].STT = Convert.ToString(skip + i + 1);
                                    }
                                    break;
                            }
                            list = newlist;
                        }
                        list = list.Skip(skip).Take(pageSizeValue).ToList();
                        break;
                    case "4":
                        //Tim kiếm theo ngày sinh
                        //dssv = db.tbl_SinhViens.Where(o => o.DiaChi.Contains(keywords)).ToList();
                        //for (int i = 0; i < dssv.Count; i++)
                        //{
                        //    SinhVien_ett obj = new SinhVien_ett(dssv[i]);
                        //    obj.STT = Convert.ToString(skip + i + 1);
                        //    list.Add(obj);
                        //}
                        //list = list.Skip(skip).Take(pageSizeValue).ToList();
                        break;
                    case "5":
                        dssv = db.tbl_SinhViens.Where(o => o.GioiTinh.Contains(keywords)).ToList();
                        for (int i = 0; i < dssv.Count; i++)
                        {
                            SinhVien_ett obj = new SinhVien_ett(dssv[i]);
                            obj.STT = Convert.ToString(skip + i + 1);
                            list.Add(obj);
                        }
                        totalCount = list.Count();
                        if (sortOrder != "")
                        {
                            switch (sortOrder)
                            {
                                case "0":
                                case "1":
                                    newlist = list.OrderBy(x => x.GioiTinh).ToList();
                                    for (int i = 0; i < newlist.Count; i++)
                                    {
                                        newlist[i].STT = Convert.ToString(skip + i + 1);
                                    }
                                    break;
                                case "2":
                                    newlist = list.OrderBy(x => x.GioiTinh).Reverse().ToList();
                                    for (int i = 0; i < newlist.Count; i++)
                                    {
                                        newlist[i].STT = Convert.ToString(skip + i + 1);
                                    }
                                    break;
                            }
                            list = newlist;
                        }
                        list = list.Skip(skip).Take(pageSizeValue).ToList();
                        break;
                }
            }else
            {

                dssv = db.tbl_SinhViens.ToList();
                for (int i = 0; i < dssv.Count; i++)
                {
                    SinhVien_ett obj = new SinhVien_ett(dssv[i]);
                    obj.STT = Convert.ToString(skip + i + 1);
                    list.Add(obj);
                }
                totalCount = list.Count();
                switch (orderby)
                {
                    case "0":
                        switch (sortOrder)
                        {
                            case "0":
                            case "1":
                                newlist = list.OrderBy(x => x.STT).ToList();
                                for (int i = 0; i < newlist.Count; i++)
                                {
                                    newlist[i].STT = Convert.ToString(skip + i + 1);
                                }
                                break;
                            case "2":
                                newlist = list.OrderBy(x => x.STT).Reverse().ToList();
                                for (int i = 0; i < newlist.Count; i++)
                                {
                                    newlist[i].STT = Convert.ToString(skip + i + 1);
                                }
                                break;
                        }
                        list = newlist;
                        break;
                    case "1":
                        switch (sortOrder)
                        {
                            case "0":
                            case "1":
                                newlist = list.OrderBy(x => x.MSSV).ToList();
                                for (int i = 0; i < newlist.Count; i++)
                                {
                                    newlist[i].STT = Convert.ToString(skip + i + 1);
                                }
                                break;
                            case "2":
                                newlist = list.OrderBy(x => x.MSSV).Reverse().ToList();
                                for (int i = 0; i < newlist.Count; i++)
                                {
                                    newlist[i].STT = Convert.ToString(skip + i + 1);
                                }
                                break;
                        }
                        list = newlist;
                        break;
                    case "2":
                        switch (sortOrder)
                        {
                            case "0":
                            case "1":
                                newlist = list.OrderBy(x => x.HoTen).Reverse().ToList();
                                for (int i = 0; i < newlist.Count; i++)
                                {
                                    newlist[i].STT = Convert.ToString(skip + i + 1);
                                }
                                break;
                            case "2":
                                newlist = list.OrderBy(x => x.HoTen).ToList();
                                for (int i = 0; i < newlist.Count; i++)
                                {
                                    newlist[i].STT = Convert.ToString(skip + i + 1);
                                }
                                break;
                        }
                        list = newlist;
                        break;
                    case "3":
                        switch (sortOrder)
                        {
                            case "0":
                            case "1":
                                newlist = list.OrderBy(x => x.DiaChi).ToList();
                                for (int i = 0; i < newlist.Count; i++)
                                {
                                    newlist[i].STT = Convert.ToString(skip + i + 1);
                                }
                                break;
                            case "2":
                                newlist = list.OrderBy(x => x.DiaChi).Reverse().ToList();
                                for (int i = 0; i < newlist.Count; i++)
                                {
                                    newlist[i].STT = Convert.ToString(skip + i + 1);
                                }
                                break;
                        }
                        list = newlist;
                        break;
                    case "4":
                        switch (sortOrder)
                        {
                            case "0":
                            case "1":
                                newlist = list.OrderBy(x => x.NgaySinh).ToList();
                                for (int i = 0; i < newlist.Count; i++)
                                {
                                    newlist[i].STT = Convert.ToString(skip + i + 1);
                                }
                                break;
                            case "2":
                                newlist = list.OrderBy(x => x.NgaySinh).Reverse().ToList();
                                for (int i = 0; i < newlist.Count; i++)
                                {
                                    newlist[i].STT = Convert.ToString(skip + i + 1);
                                }
                                break;
                        }
                        list = newlist;
                        break;
                    case "5":
                        switch (sortOrder)
                        {
                            case "0":
                            case "1":
                                newlist = list.OrderBy(x => x.GioiTinh).ToList();
                                for (int i = 0; i < newlist.Count; i++)
                                {
                                    newlist[i].STT = Convert.ToString(skip + i + 1);
                                }
                                break;
                            case "2":
                                newlist = list.OrderBy(x => x.GioiTinh).Reverse().ToList();
                                for (int i = 0; i < newlist.Count; i++)
                                {
                                    newlist[i].STT = Convert.ToString(skip + i + 1);
                                }
                                break;
                        }
                        list = newlist;
                        break;
                }
                list = list.Skip(skip).Take(pageSizeValue).ToList();
            }
            int totalPages = (int)Math.Ceiling((double)totalCount / pageSizeValue);

            var result = new
            {
                Data = list,
                TotalCount = totalCount,
                TotalPages = totalPages
            };
            return JsonConvert.SerializeObject(result);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public string PostCreate()
        {
            Result_ett<string> rs = new Result_ett<string>();
            try
            {
                string hoTen = Request["HoTen"];
                string mSSV = Request["MSSV"];
                string diaChi = Request["DiaChi"];
                string khoaHoc = Request["KhoaHoc"];
                string lopQuanLy = Request["LopQuanLy"];
                string ngaySinh = Request["NgaySinh"];
                string gioiTinh = Request["GioiTinh"];

                tbl_SinhVien newSV = new tbl_SinhVien();
                newSV.MSSV = mSSV;
                newSV.HoTen = hoTen;
                newSV.KhoaHoc = khoaHoc;
                newSV.LopQuanLy = lopQuanLy;
                newSV.DiaChi = diaChi;
                newSV.NgaySinh = DateTime.ParseExact(ngaySinh, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                newSV.GioiTinh = gioiTinh;
                db.tbl_SinhViens.InsertOnSubmit(newSV);
                db.SubmitChanges();
                rs.ErrCode = EnumErrCode.Success;
                rs.Message = "Thêm mới sinh viên thành công";
            }
            catch (Exception ex)
            {
                rs.ErrCode=EnumErrCode.Error;
                rs.ErrDetail=ex.Message;
                rs.Message = "Thêm mới sinh viên không thành công";
                return JsonConvert.SerializeObject(rs);
            }
            return JsonConvert.SerializeObject(rs);
        }
        public string GetObject(string mssv)
        {
            tbl_SinhVien sinhvien = new tbl_SinhVien();
            sinhvien = db.tbl_SinhViens.Where(o => o.MSSV.Equals(mssv)).FirstOrDefault();
            return JsonConvert.SerializeObject(sinhvien);
        }
        [HttpPost]
        public string PostEdit()
        {
            Result_ett<string> rs = new Result_ett<string>();
            try
            {
                string hoTen = Request["HoTen"];
                string mSSV = Request["MSSV"];
                string diaChi = Request["DiaChi"];
                string khoaHoc = Request["KhoaHoc"];
                string lopQuanLy = Request["LopQuanLy"];
                string ngaySinh = Request["NgaySinh"];
                string gioiTinh = Request["GioiTinh"];

                tbl_SinhVien newSV = db.tbl_SinhViens.Where(x => x.MSSV.Equals(mSSV)).FirstOrDefault();
                newSV.HoTen = hoTen;
                newSV.KhoaHoc = khoaHoc;
                newSV.LopQuanLy = lopQuanLy;
                newSV.DiaChi = diaChi;
                newSV.NgaySinh = DateTime.ParseExact(ngaySinh, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                newSV.GioiTinh = gioiTinh;
                db.SubmitChanges();
                rs.ErrCode = EnumErrCode.Success;
                rs.Message = "Cập nhật thông tin sinh viên thành công";
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDetail = ex.Message;
                rs.Message = "Cập nhật thông tin sinh viên không thành công";
                return JsonConvert.SerializeObject(rs);
            }
            return JsonConvert.SerializeObject(rs);
        }
        [HttpPost]
        public string Delete(string mssv)
        {
            Result_ett<string> rs = new Result_ett<string>();
            try
            {
                tbl_SinhVien delObj = db.tbl_SinhViens.Where(o => o.MSSV.Equals(mssv)).FirstOrDefault();
                db.tbl_SinhViens.DeleteOnSubmit(delObj);
                db.SubmitChanges();
                rs.ErrCode = EnumErrCode.Success;
                rs.Message = "Xóa sinh viên thành công";
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Fail;
                rs.ErrDetail = ex.Message;
                rs.Message = "Xóa sinh viên không thành công";
                return JsonConvert.SerializeObject(rs);
            }
            return JsonConvert.SerializeObject(rs);
        }
    }
}