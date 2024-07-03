using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.Windows.Forms;

namespace QL_ThuocTay
{
    public class XuLy
    {
        DataSet ds = new DataSet();
        SqlDataAdapter dt;
        SqlConnection _Sqlconn = new SqlConnection(Properties.Settings.Default.SqlCon);
        public XuLy()
        {
            loadNhanVien();
            loadThuoc();
            loadNguoiDung();
            loadNhomThuoc();
            loadNSX();
            loadKH();
            loadDoiTra();
            loadBenh();
            loadNhapThuoc();
            load_CTNhapThuoc();
            loadXuatThuoc();
            load_CTXuatThuoc();


        }
        public void executeQuery(String sql)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection _Sqlconn = new SqlConnection(Properties.Settings.Default.SqlCon);
            try
            {
                cmd.Connection = _Sqlconn;
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                _Sqlconn.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi", "Không thể thực thi !");
                return;
            }

        }
        public int Check_Config()
        {
            if (Properties.Settings.Default.SqlCon == string.Empty)
                return 1;// Chuỗi cấu hình không tồn tại
            SqlConnection _Sqlconn = new SqlConnection(Properties.Settings.Default.SqlCon);
            try
            {
                if (_Sqlconn.State == System.Data.ConnectionState.Closed)
                    _Sqlconn.Open();
                return 0;// Kết nối thành công chuỗi cấu hình hợp lệ
            }
            catch
            {
                return 2;// Chuỗi cấu hình không phù hợp.
            }
        }


        public int Check_User(string pUser, string pPass)
        {
            SqlDataAdapter daUser = new SqlDataAdapter("select * from NGUOIDUNG where TENDN = '" + pUser + "' and MATKHAU = '" + pPass + "'",
                                                             Properties.Settings.Default.SqlCon);
            DataTable dt = new DataTable();
            daUser.Fill(dt);
            if (dt.Rows.Count == 0)
                return 10;// User không tồn tại
            else if (dt.Rows[0][2] == null || dt.Rows[0][2].ToString() == "False")
            {
                return 20;// Không hoạt động
            }
            return 30;// Đăng nhập thành công
        }
    

        //================================LOAD DATA=======================

                                                                                 //============NHẬP THUỐC================

        public void loadNhapThuoc()
        {
            string cauLenh = "select * from NHAPTHUOC";
            dt = new SqlDataAdapter(cauLenh, _Sqlconn);
            dt.Fill(ds, "NHAPTHUOC");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["NHAPTHUOC"].Columns[0];
            ds.Tables["NHAPTHUOC"].PrimaryKey = key;

        }

        public DataTable GetNhapThuoc()
        {
            return ds.Tables["NHAPTHUOC"];
        }

        //SELECT MAHD_NHAP, MANV, NGAYLAP, TONGNHAP FROM NHAPTHUOC

        //===============================Thêm======================================

        public bool ThemnNhapThuoc(string pMaHD, string pMANV,string pNgLap)
        {
            try
            {
                DataRow dtR = ds.Tables["NHAPTHUOC"].NewRow();
                // gán dữ liệu lên row
                dtR["MAHD_NHAP"] = pMaHD;
                dtR["MANV"] = pMANV;
                dtR["NGAYLAP"] = pNgLap;
               

                //Thêm dữ liệu vào databale                
                ds.Tables["NHAPTHUOC"].Rows.Add(dtR);
                // Lưu xuống dataset
                string cauLenh = "SELECT MAHD_NHAP, MANV, NGAYLAP, TONGNHAP FROM NHAPTHUOC";

                SqlDataAdapter dta = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dta);

                dta.Update(ds, "NHAPTHUOC");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //=================================Xóa================================

        public bool XoaNhapThuoc(string pMaHD)
        {
            try
            {
                DataRow dtR = ds.Tables["NHAPTHUOC"].Rows.Find(pMaHD);
                //gán dữ liệu lên row mới tạo ra
                if (dtR != null)
                    dtR.Delete();

                // Lưu xuống dataset
                string cauLenh = "SELECT MAHD_NHAP, MANV, NGAYLAP, TONGNHAP FROM NHAPTHUOC";

                dt = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dt);

                dt.Update(ds, "NHAPTHUOC");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //========================================Sửa==================================
        public bool suaNhapThuoc(string pMaHD, string pMANV, string pNgLap)
        {
            try
            {
                DataRow dtR = ds.Tables["NHAPTHUOC"].Rows.Find(pMaHD);
                dtR["MAHD_NHAP"] = pMaHD;
                dtR["MANV"] = pMANV;
                dtR["NGAYLAP"] = pNgLap;
               
                string cauLenh = "SELECT MAHD_NHAP, MANV, NGAYLAP, TONGNHAP FROM NHAPTHUOC";
                SqlDataAdapter dta = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dta);

                dta.Update(ds, "NHAPTHUOC");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Kiểm tra khóa chính
        public int KTKhoaChinh_NhapThuoc(string pMaHD)
        {
            try
            {

                if (_Sqlconn.State == ConnectionState.Closed)
                {
                    _Sqlconn.Open();
                }
                string cauLenh = "select count(*) from NHAPTHUOC where MAHD_NHAP ='" + pMaHD + "'";

                SqlCommand cmd = new SqlCommand(cauLenh, _Sqlconn);

                int kq = (int)cmd.ExecuteScalar();
                if (_Sqlconn.State == ConnectionState.Open)
                {
                    _Sqlconn.Close();
                }
                if (kq >= 1)
                    return 1;//trùng khóa chính
                else
                    return 2;//Thêm               
            }
            catch
            {
                return 3;//Lỗi cú pháp
            }
        }



        public int KTTonTaiMaHD_CTHDNHAP(string pMahd)
        {
            try
            {
                //Kiểm tra ket noi truoc khi mo
                if (_Sqlconn.State == ConnectionState.Closed)
                {
                    _Sqlconn.Open();
                }
                //xac dinh cau sql THÊM
                string insertStr;
                insertStr = "select count(*) from CTNHAPTHUOC where MAHD_NHAP='" + pMahd + "'";

                //Khai bao command moi

                SqlCommand cmd = new SqlCommand(insertStr, _Sqlconn);
                int kq = (int)cmd.ExecuteScalar();
                if (_Sqlconn.State == ConnectionState.Open)
                    _Sqlconn.Close();
                if (kq >= 1)
                    return 1;//có tồn tại
                else
                    return 2;//Ko tồn tại
            }
            catch
            {
                return 3;//Lỗi
            }

        }




        //============CHI TIẾT NHẬP THUỐC================
        public void load_CTNhapThuoc()
        {
            string cauLenh = "select * from CTNHAPTHUOC";
            dt = new SqlDataAdapter(cauLenh, _Sqlconn);
            dt.Fill(ds, "CTNHAPTHUOC");
            DataColumn[] key = new DataColumn[2];            
            key[0] = ds.Tables["CTNHAPTHUOC"].Columns[0];
            key[1] = ds.Tables["CTNHAPTHUOC"].Columns[1];
            ds.Tables["CTNHAPTHUOC"].PrimaryKey = key;

        }

        public DataTable Get_CTNhapThuoc()
        {
            return ds.Tables["CTNHAPTHUOC"];
        }



        //SELECT MAHD_NHAP, MATHUOC, SLBAN, DVT, GIANHAP, THANHTIEN FROM CTNHAPTHUOC
        //===============================Thêm======================================

        public bool Themn_CTNhapThuoc(string pMaHD, string pMAThuoc, int iSLBan, string pDVT,int iGiaBan,int iThanhTien)
        {
            try
            {
                DataRow dtR = ds.Tables["CTNHAPTHUOC"].NewRow();
                // gán dữ liệu lên row
                dtR["MAHD_NHAP"] = pMaHD;
                dtR["MATHUOC"] = pMAThuoc;
                dtR["SLBAN"] = iSLBan;
                dtR["DVT"] =pDVT;
                dtR["GIANHAP"] = iGiaBan;
                dtR["THANHTIEN"] = iThanhTien;

                //Thêm dữ liệu vào databale                
                ds.Tables["CTNHAPTHUOC"].Rows.Add(dtR);
                // Lưu xuống dataset
                string cauLenh = "SELECT MAHD_NHAP, MATHUOC, SLBAN, DVT, GIANHAP, THANHTIEN FROM CTNHAPTHUOC";

                SqlDataAdapter dta = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dta);

                dta.Update(ds, "CTNHAPTHUOC");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //=================================Xóa================================

        public bool Xoa_CTNhapThuoc(string pMaHD)
        {
            try
            {
                DataRow dtR = ds.Tables["CTNHAPTHUOC"].Rows.Find(pMaHD);
                //gán dữ liệu lên row mới tạo ra
                if (dtR != null)
                    dtR.Delete();

                // Lưu xuống dataset
                string cauLenh = "SELECT MAHD_NHAP, MATHUOC, SLBAN, DVT, GIANHAP, THANHTIEN FROM CTNHAPTHUOC";

                dt = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dt);

                dt.Update(ds, "CTNHAPTHUOC");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //========================================Sửa==================================
        public bool sua_CTNhapThuoc(string pMaHD, string pMAThuoc, int iSLBan, string pDVT, int iGiaBan, int iThanhTien)
        {
            try
            {
                DataRow dtR = ds.Tables["CTNHAPTHUOC"].Rows.Find(pMaHD);
                dtR["MAHD_NHAP"] = pMaHD;
                dtR["MATHUOC"] = pMAThuoc;
                dtR["SLBAN"] = iSLBan;
                dtR["DVT"] = pDVT;
                dtR["GIANHAP"] = iGiaBan;
                dtR["THANHTIEN"] = iThanhTien;
                string cauLenh = "SELECT MAHD_NHAP, MATHUOC, SLBAN, DVT, GIANHAP, THANHTIEN FROM CTNHAPTHUOC";
                SqlDataAdapter dta = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dta);

                dta.Update(ds, "CTNHAPTHUOC");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Kiểm tra khóa chính
        public int KTKhoaChinh_CTNHAPTHUOC(string pMaHD)
        {
            try
            {

                if (_Sqlconn.State == ConnectionState.Closed)
                {
                    _Sqlconn.Open();
                }
                string cauLenh = "select count(*) from CTNHAPTHUOC where MAHD_NHAP ='" + pMaHD + "'";

                SqlCommand cmd = new SqlCommand(cauLenh, _Sqlconn);

                int kq = (int)cmd.ExecuteScalar();
                if (_Sqlconn.State == ConnectionState.Open)
                {
                    _Sqlconn.Close();
                }
                if (kq >= 1)
                    return 1;//trùng khóa chính
                else
                    return 2;//Thêm               
            }
            catch
            {
                return 3;//Lỗi cú pháp
            }
        }



        //Tính tổng tiền CT
        public double tinhTongTien(int sl, int fGia)
        {
            return (sl * fGia);
        }

        //============XUÂT THUỐC================
        public void loadXuatThuoc()
        {
            string cauLenh = "select * from HOADON_BAN";
            dt = new SqlDataAdapter(cauLenh, _Sqlconn);
            dt.Fill(ds, "HOADON_BAN");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["HOADON_BAN"].Columns[0];
            ds.Tables["HOADON_BAN"].PrimaryKey = key;

        }

        public DataTable GetXuatThuoc()
        {
            return ds.Tables["HOADON_BAN"];
        }




        //SELECT MAHD, MANV, MAKH, NGAYLAPHD, TONGHD, TINHTRANG, GHICHU FROM HOADON_BAN
        //===============================Thêm======================================

        public bool Themn_XuatThuoc(string pMaHD, string pMANV, string pMaKH,string pNgayLap, string pTinhTrang,string pGhiChu)
        {
            try
            {
                DataRow dtR = ds.Tables["HOADON_BAN"].NewRow();
                // gán dữ liệu lên row
                dtR["MAHD"] = pMaHD;
                dtR["MANV"] = pMANV;
                dtR["MAKH"] = pMaKH;
                dtR["NGAYLAPHD"] = pNgayLap;
              
                dtR["TINHTRANG"] = pTinhTrang;
                dtR["GHICHU"] = pGhiChu;
                //Thêm dữ liệu vào databale                
                ds.Tables["HOADON_BAN"].Rows.Add(dtR);
                // Lưu xuống dataset
                string cauLenh = "SELECT MAHD, MANV, MAKH, NGAYLAPHD, TONGHD, TINHTRANG, GHICHU FROM HOADON_BAN";

                SqlDataAdapter dta = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dta);

                dta.Update(ds, "HOADON_BAN");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //=================================Xóa================================

        public bool Xoa_XuatThuoc(string pMaHD)
        {
            try
            {
                DataRow dtR = ds.Tables["HOADON_BAN"].Rows.Find(pMaHD);
                //gán dữ liệu lên row mới tạo ra
                if (dtR != null)
                    dtR.Delete();

                // Lưu xuống dataset
                string cauLenh = "SELECT MAHD, MANV, MAKH, NGAYLAPHD, TONGHD, TINHTRANG, GHICHU FROM HOADON_BAN";

                dt = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dt);

                dt.Update(ds, "HOADON_BAN");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //========================================Sửa==================================
        public bool sua_XuatThuoc(string pMaHD, string pMANV, string pMaKH, string pNgayLap, string pTinhTrang, string pGhiChu)
        {
            try
            {
                DataRow dtR = ds.Tables["HOADON_BAN"].Rows.Find(pMaHD);
                dtR["MAHD"] = pMaHD;
                dtR["MANV"] = pMANV;
                dtR["MAKH"] = pMaKH;
                dtR["NGAYLAPHD"] = pNgayLap;

                dtR["TINHTRANG"] = pTinhTrang;
                dtR["GHICHU"] = pGhiChu;

                string cauLenh = "SELECT MAHD, MANV, MAKH, NGAYLAPHD, TONGHD, TINHTRANG, GHICHU FROM HOADON_BAN";
                SqlDataAdapter dta = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dta);

                dta.Update(ds, "HOADON_BAN");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Kiểm tra khóa chính
        public int KTKhoaChinh_XuatThuoc(string pMaHD)
        {
            try
            {

                if (_Sqlconn.State == ConnectionState.Closed)
                {
                    _Sqlconn.Open();
                }
                string cauLenh = "select count(*) from HOADON_BAN where MAHD ='" + pMaHD + "'";

                SqlCommand cmd = new SqlCommand(cauLenh, _Sqlconn);

                int kq = (int)cmd.ExecuteScalar();
                if (_Sqlconn.State == ConnectionState.Open)
                {
                    _Sqlconn.Close();
                }
                if (kq >= 1)
                    return 1;//trùng khóa chính
                else
                    return 2;//Thêm               
            }
            catch
            {
                return 3;//Lỗi cú pháp
            }
        }


        public int KTTonTaiMaHD_CTHDXUAT(string pMahd)
        {
            try
            {
                //Kiểm tra ket noi truoc khi mo
                if (_Sqlconn.State == ConnectionState.Closed)
                {
                    _Sqlconn.Open();
                }
                //xac dinh cau sql THÊM
                string insertStr;
                insertStr = "select count(*) from CTHD_BAN where MAHD='" + pMahd + "'";

                //Khai bao command moi

                SqlCommand cmd = new SqlCommand(insertStr, _Sqlconn);
                int kq = (int)cmd.ExecuteScalar();
                if (_Sqlconn.State == ConnectionState.Open)
                    _Sqlconn.Close();
                if (kq >= 1)
                    return 1;//có tồn tại
                else
                    return 2;//Ko tồn tại
            }
            catch
            {
                return 3;//Lỗi
            }

        }
        //============CHI TIẾT XUẤT THUỐC================
        public void load_CTXuatThuoc()
        {
            string cauLenh = "select * from CTHD_BAN";
            dt = new SqlDataAdapter(cauLenh, _Sqlconn);
            dt.Fill(ds, "CTHD_BAN");
            DataColumn[] key = new DataColumn[2];
            key[0] = ds.Tables["CTHD_BAN"].Columns[0];
            key[1] = ds.Tables["CTHD_BAN"].Columns[1];
            ds.Tables["CTHD_BAN"].PrimaryKey = key;

        }

        public DataTable Get_CTXuatThuoc()
        {
            return ds.Tables["CTHD_BAN"];
        }
        //SELECT MAHD, MATHUOC, SLBAN, DVT, GIABAN, THANHTIEN FROM CTHD_BAN
        //===============================Thêm======================================

        public bool Themn_CTXuatThuoc(string pMaHD, string pMAThuoc,int iSL,string pDVT,int iGiaBan,int iThanhTien)
        {
            try
            {
                DataRow dtR = ds.Tables["CTHD_BAN"].NewRow();
                // gán dữ liệu lên row
                dtR["MAHD"] = pMaHD;
                dtR["MATHUOC"] = pMAThuoc;
                dtR["SLBAN"] = iSL;
                dtR["DVT"] = pDVT;
                dtR["GIABAN"] = iGiaBan;
                dtR["THANHTIEN"] = iThanhTien;

                //Thêm dữ liệu vào databale                
                ds.Tables["CTHD_BAN"].Rows.Add(dtR);
                // Lưu xuống dataset
                string cauLenh = "SELECT MAHD, MATHUOC, SLBAN, DVT, GIABAN, THANHTIEN FROM CTHD_BAN";

                SqlDataAdapter dta = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dta);

                dta.Update(ds, "CTHD_BAN");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //=================================Xóa================================

        public bool Xoa_CTXuatThuoc(string pMaHD)
        {
            try
            {
                DataRow dtR = ds.Tables["CTHD_BAN"].Rows.Find(pMaHD);
                //gán dữ liệu lên row mới tạo ra
                if (dtR != null)
                    dtR.Delete();

                // Lưu xuống dataset
                string cauLenh = "SELECT MAHD, MATHUOC, SLBAN, DVT, GIABAN, THANHTIEN FROM CTHD_BAN";

                dt = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dt);

                dt.Update(ds, "CTHD_BAN");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //========================================Sửa==================================
        public bool sua_XuatThuoc(string pMaHD, string pMAThuoc,int iSL,string pDVT,int iGiaBan,int iThanhTien)
        {
            try
            {
                DataRow dtR = ds.Tables["CTHD_BAN"].Rows.Find(pMaHD);
                dtR["MAHD"] = pMaHD;
                dtR["MATHUOC"] = pMAThuoc;
                dtR["SLBAN"] = iSL;
                dtR["DVT"] = pDVT;
                dtR["GIABAN"] = iGiaBan;
                dtR["THANHTIEN"] = iThanhTien;
                string cauLenh = "SELECT MAHD, MATHUOC, SLBAN, DVT, GIABAN, THANHTIEN FROM CTHD_BAN";
                SqlDataAdapter dta = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dta);

                dta.Update(ds, "CTHD_BAN");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Kiểm tra khóa chính
        public int KTKhoaChinh_CTXuatHD(string pMaHD)
        {
            try
            {

                if (_Sqlconn.State == ConnectionState.Closed)
                {
                    _Sqlconn.Open();
                }
                string cauLenh = "select count(*) from CTHD_BAN where MAHD_NHAP ='" + pMaHD + "'";

                SqlCommand cmd = new SqlCommand(cauLenh, _Sqlconn);

                int kq = (int)cmd.ExecuteScalar();
                if (_Sqlconn.State == ConnectionState.Open)
                {
                    _Sqlconn.Close();
                }
                if (kq >= 1)
                    return 1;//trùng khóa chính
                else
                    return 2;//Thêm               
            }
            catch
            {
                return 3;//Lỗi cú pháp
            }
        }
                                                                            //============NHÂN VIÊN================       

        public void loadNhanVien()
        {
            string cauLenh = "select * from NHANVIEN";
            dt = new SqlDataAdapter(cauLenh, _Sqlconn);
            dt.Fill(ds, "NHANVIEN");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["NHANVIEN"].Columns[0];
            ds.Tables["NHANVIEN"].PrimaryKey = key;

        }

        public DataTable GetNhanVien()
        {
            return ds.Tables["NHANVIEN"];
        }
      
             //===============================Thêm======================================
        //    string cauLenh = "SELECT NV.MANV,NV.MAND,NV.TENNV,NV.EMAIL,NV.NGAYSINH,NV.GIOITINH,NV.DIACHI,NV.SDT,NV.TRINHDO,NV.LUONG,ND.TENQUYEN FROM NHANVIEN NV, NGUOIDUNG ND";
        //('NV01','ND01',N'Nguyễn Văn Định',N'dinhvn1512@gmail.com','15/12/2001',1,N'Bình Định','0923841382',N'Đại học',800000),
        public bool ThemnNhanVien(string pMaNV, string pMaND, string pTenNV,string pEmail,string pdate,bool gTinh,string pDiaChi,string pSDT,string pTrinhDo,int iLuong)
        {
            try
            {
                DataRow dtR = ds.Tables["NHANVIEN"].NewRow();
                // gán dữ liệu lên row
                dtR["MANV"] = pMaNV;
                dtR["MAND"] = pMaND;
                dtR["TENNV"] = pTenNV;
                dtR["EMAIL"] = pEmail;
                dtR["NGAYSINH"] = pdate;
                dtR["GIOITINH"] =gTinh;
                dtR["DIACHI"] = pDiaChi;
                dtR["SDT"] = pSDT;
                dtR["TRINHDO"] = pTrinhDo;
                dtR["LUONG"] = iLuong;

                //Thêm dữ liệu vào databale                
                ds.Tables["NHANVIEN"].Rows.Add(dtR);
                // Lưu xuống dataset
                string cauLenh = "select NV.MANV,NV.MAND,NV.TENNV,NV.EMAIL,NV.NGAYSINH,NV.GIOITINH,NV.DIACHI,NV.SDT,NV.TRINHDO,NV.LUONG from NHANVIEN NV";

                SqlDataAdapter dta = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dta);

                dta.Update(ds, "NHANVIEN");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //=================================Xóa================================

        public bool XoaNhanVien(string pMaNV)
        {
            try
            {
                DataRow dtR = ds.Tables["NHANVIEN"].Rows.Find(pMaNV);
                //gán dữ liệu lên row mới tạo ra
                if (dtR != null)
                    dtR.Delete();

                // Lưu xuống dataset
                string cauLenh = "select NV.MANV,NV.MAND,NV.TENNV,NV.EMAIL,NV.NGAYSINH,NV.GIOITINH,NV.DIACHI,NV.SDT,NV.TRINHDO,NV.LUONG from NHANVIEN NV";

                dt = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dt);

                dt.Update(ds, "NHANVIEN");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //========================================Sửa==================================
        public bool suaNhanVien(string pMaNV, string pMaND, string pTenNV, string pEmail, string pdate, bool gTinh, string pDiaChi, string pSDT, string pTrinhDo, int iLuong)
        {
            try
            {
                DataRow dtR = ds.Tables["NHANVIEN"].Rows.Find(pMaNV);
                dtR["MANV"] = pMaNV;
                dtR["MAND"] = pMaND;
                dtR["TENNV"] = pTenNV;
                dtR["EMAIL"] = pEmail;
                dtR["NGAYSINH"] = pdate;
                dtR["GIOITINH"] = gTinh;
                dtR["DIACHI"] = pDiaChi;
                dtR["SDT"] = pSDT;
                dtR["TRINHDO"] = pTrinhDo;
                dtR["LUONG"] = iLuong;
                string cauLenh = "select NV.MANV,NV.MAND,NV.TENNV,NV.EMAIL,NV.NGAYSINH,NV.GIOITINH,NV.DIACHI,NV.SDT,NV.TRINHDO,NV.LUONG from NHANVIEN NV";
                SqlDataAdapter dta = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dta);

                dta.Update(ds, "NHANVIEN");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Kiểm tra khóa chính
        public int KTKhoaChinh_NHANVIEN(string pMaNV)
        {
            try
            {

                if (_Sqlconn.State == ConnectionState.Closed)
                {
                    _Sqlconn.Open();
                }
                string cauLenh = "select count(*) from NHANVIEN where MANV='" + pMaNV + "'";

                SqlCommand cmd = new SqlCommand(cauLenh, _Sqlconn);

                int kq = (int)cmd.ExecuteScalar();
                if (_Sqlconn.State == ConnectionState.Open)
                {
                    _Sqlconn.Close();
                }
                if (kq >= 1)
                    return 1;//trùng khóa chính
                else
                    return 2;//Thêm               
            }
            catch
            {
                return 3;//Lỗi cú pháp
            }
        }


                                                                                     //============THUỐC================
        public void loadThuoc()
        {
            string cauLenh = "select * from THONGTINTHUOC";
            dt = new SqlDataAdapter(cauLenh, _Sqlconn);
            dt.Fill(ds, "THONGTINTHUOC");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["THONGTINTHUOC"].Columns[0];
            ds.Tables["THONGTINTHUOC"].PrimaryKey = key;

        }

        public DataTable GetThuoc()
        {
            return ds.Tables["THONGTINTHUOC"];
        }

        //===============================Thêm======================================

        public bool ThemnThuoc(string pMaThuoc, string pTenThuoc,int sl,string pDVT,int gBan,string pCongDung,string pCachDung,string pChiDinh,string pBaoQuan,string pHSD,string pHinh,string pMaNSX,string pTenVT,string pMaNhom)
        {
            try
            {
                DataRow dtR = ds.Tables["THONGTINTHUOC"].NewRow();
                // gán dữ liệu lên row
                dtR["MATHUOC"] = pMaThuoc;
                dtR["TENTHUOC"] = pTenThuoc;
                dtR["SOLUONGTON"] = sl;
                dtR["DVT"] = pDVT;
                dtR["GIABAN"] = gBan;
                dtR["CONGDUNG"] = pCongDung;
                dtR["CACHDUNG"] = pCachDung;
                dtR["CHIDINH"] = pChiDinh;
                dtR["BAOQUAN"] = pBaoQuan;
                dtR["HSD"] = pHSD;
                dtR["HINH"] = pHinh;
                dtR["MA_NSX"] = pMaNSX;
                dtR["TENVITRI"] = pTenVT;
                dtR["MANHOM"] = pMaNhom;

                //Thêm dữ liệu vào databale                
                ds.Tables["THONGTINTHUOC"].Rows.Add(dtR);
                // Lưu xuống dataset
                string cauLenh = "SELECT MATHUOC,TENTHUOC,SOLUONGTON,DVT,GIABAN,CONGDUNG,CACHDUNG,CHIDINH,BAOQUAN,HSD,HINH,MA_NSX,TENVITRI,MANHOM FROM THONGTINTHUOC";

                SqlDataAdapter dta = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dta);

                dta.Update(ds, "THONGTINTHUOC");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //=================================Xóa================================

        public bool XoaThuoc(string pMaThuoc)
        {
            try
            {
                DataRow dtR = ds.Tables["THONGTINTHUOC"].Rows.Find(pMaThuoc);
                //gán dữ liệu lên row mới tạo ra
                if (dtR != null)
                    dtR.Delete();

                // Lưu xuống dataset
                string cauLenh = "SELECT MATHUOC,TENTHUOC,SOLUONGTON,DVT,GIABAN,CONGDUNG,CACHDUNG,CHIDINH,BAOQUAN,HSD,HINH,MA_NSX,TENVITRI,MANHOM FROM THONGTINTHUOC";

                dt = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dt);

                dt.Update(ds, "THONGTINTHUOC");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //========================================Sửa==================================
        public bool suaThuoc(string pMaThuoc, string pTenThuoc, int sl, string pDVT, int gBan, string pCongDung, string pCachDung, string pChiDinh, string pBaoQuan, string pHSD, string pHinh, string pMaNSX, string pTenVT, string pMaNhom)
        {
            try
            {
                DataRow dtR = ds.Tables["THONGTINTHUOC"].Rows.Find(pMaThuoc);
                dtR["MATHUOC"] = pMaThuoc;
                dtR["TENTHUOC"] = pTenThuoc;
                dtR["SOLUONGTON"] = sl;
                dtR["DVT"] = pDVT;
                dtR["GIABAN"] = gBan;
                dtR["CONGDUNG"] = pCongDung;
                dtR["CACHDUNG"] = pCachDung;
                dtR["CHIDINH"] = pChiDinh;
                dtR["BAOQUAN"] = pBaoQuan;
                dtR["HSD"] = pHSD;
                dtR["HINH"] = pHinh;
                dtR["MA_NSX"] = pMaNSX;
                dtR["TENVITRI"] = pTenVT;
                dtR["MANHOM"] = pMaNhom;
                string cauLenh = "SELECT MATHUOC,TENTHUOC,SOLUONGTON,DVT,GIABAN,CONGDUNG,CACHDUNG,CHIDINH,BAOQUAN,HSD,HINH,MA_NSX,TENVITRI,MANHOM FROM THONGTINTHUOC";
                SqlDataAdapter dta = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dta);

                dta.Update(ds, "THONGTINTHUOC");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Kiểm tra khóa chính
        public int KTKhoaChinh_THUOC(string pMaBenh)
        {
            try
            {

                if (_Sqlconn.State == ConnectionState.Closed)
                {
                    _Sqlconn.Open();
                }
                string cauLenh = "select count(*) from THONGTINTHUOC where MABENH='" + pMaBenh + "'";

                SqlCommand cmd = new SqlCommand(cauLenh, _Sqlconn);

                int kq = (int)cmd.ExecuteScalar();
                if (_Sqlconn.State == ConnectionState.Open)
                {
                    _Sqlconn.Close();
                }
                if (kq >= 1)
                    return 1;//trùng khóa chính
                else
                    return 2;//Thêm               
            }
            catch
            {
                return 3;//Lỗi cú pháp
            }
        }

                                                                                     //============NGƯỜI DÙNG================
        public void loadNguoiDung()
        {
            string cauLenh = "select * from NGUOIDUNG";
            dt = new SqlDataAdapter(cauLenh, _Sqlconn);
            dt.Fill(ds, "NGUOIDUNG");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["NGUOIDUNG"].Columns[0];
            ds.Tables["NGUOIDUNG"].PrimaryKey = key;

        }

        public DataTable GetNguoiDung()
        {
            return ds.Tables["NGUOIDUNG"];
        }
                                                                                    //============BỆNH================.


        public void loadBenh()
        {
            string cauLenh = "select * from BENH";
            dt = new SqlDataAdapter(cauLenh, _Sqlconn);
            dt.Fill(ds, "BENH");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["BENH"].Columns[0];
            ds.Tables["BENH"].PrimaryKey = key;

        }

        public DataTable GetBenh()
        {
            return ds.Tables["BENH"];
        }
        //===============================Thêm======================================

        public bool ThemnBenh(string pMaBenh, string pTenBenh)
        {
            try
            {
                DataRow dtR = ds.Tables["BENH"].NewRow();
                // gán dữ liệu lên row
                dtR["MABENH"] = pMaBenh;
                dtR["TENBENH"] = pTenBenh;

                //Thêm dữ liệu vào databale                
                ds.Tables["BENH"].Rows.Add(dtR);
                // Lưu xuống dataset
                string cauLenh = "select MABENH,TENBENH FROM BENH";

                SqlDataAdapter dta = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dta);

                dta.Update(ds, "BENH");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //=================================Xóa================================

        public bool XoaBenh(string pMaBenh)
        {
            try
            {
                DataRow dtR = ds.Tables["BENH"].Rows.Find(pMaBenh);
                //gán dữ liệu lên row mới tạo ra
                if (dtR != null)
                    dtR.Delete();

                // Lưu xuống dataset
                string cauLenh = "select MABENH,TENBENH FROM BENH";

                dt = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dt);

                dt.Update(ds, "BENH");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //========================================Sửa==================================
        public bool suaBenh(string pMaBenh, string pTenBenh)
        {
            try
            {
                DataRow dtR = ds.Tables["BENH"].Rows.Find(pMaBenh);
                dtR["MABENH"] = pMaBenh;
                dtR["TENBENH"] = pTenBenh;
                string cauLenh = "select MABENH,TENBENH FROM BENH";
                SqlDataAdapter dta = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dta);

                dta.Update(ds, "BENH");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Kiểm tra khóa chính
        public int KTKhoaChinh_BENH(string pMaBenh)
        {
            try
            {

                if (_Sqlconn.State == ConnectionState.Closed)
                {
                    _Sqlconn.Open();
                }
                string cauLenh = "select count(*) from BENH where MABENH='" + pMaBenh + "'";

                SqlCommand cmd = new SqlCommand(cauLenh, _Sqlconn);

                int kq = (int)cmd.ExecuteScalar();
                if (_Sqlconn.State == ConnectionState.Open)
                {
                    _Sqlconn.Close();
                }
                if (kq >= 1)
                    return 1;//trùng khóa chính
                else
                    return 2;//Thêm               
            }
            catch
            {
                return 3;//Lỗi cú pháp
            }
        }


                                                                                    //============NHÓM THUỐC================

        public void loadNhomThuoc()
        {
            string cauLenh = "select * from NHOMTHUOC";
            dt = new SqlDataAdapter(cauLenh, _Sqlconn);
            dt.Fill(ds, "NHOMTHUOC");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["NHOMTHUOC"].Columns[0];
            ds.Tables["NHOMTHUOC"].PrimaryKey = key;

        }

        public DataTable GetNhomThuoc()
        {
            return ds.Tables["NHOMTHUOC"];
        }
        //===============================Thêm======================================
       
        public bool ThemnNhomThuoc(string pMaNhom, string pTenNhom)
        {
            try
            {
                DataRow dtR = ds.Tables["NHOMTHUOC"].NewRow();
                // gán dữ liệu lên row
                dtR["MANHOM"] = pMaNhom;               
                dtR["TENNHOM"] = pTenNhom;                

                //Thêm dữ liệu vào databale                
                ds.Tables["NHOMTHUOC"].Rows.Add(dtR);
                // Lưu xuống dataset
                string cauLenh = "select MANHOM,TENNHOM FROM NHOMTHUOC";

                SqlDataAdapter dta = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dta);

                dta.Update(ds, "NHOMTHUOC");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //=================================Xóa================================

        public bool XoaNhomThuoc(string pMaNhom)
        {
            try
            {
                DataRow dtR = ds.Tables["NHOMTHUOC"].Rows.Find(pMaNhom);
                //gán dữ liệu lên row mới tạo ra
                if (dtR != null)
                    dtR.Delete();

                // Lưu xuống dataset
                string cauLenh = "select MANHOM,TENNHOM FROM NHOMTHUOC";

                dt = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dt);

                dt.Update(ds, "NHOMTHUOC");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //========================================Sửa==================================
        public bool suaNhomThuoc(string pMaNhom, string pTenNhom)
        {
            try
            {
                DataRow dtR = ds.Tables["NHOMTHUOC"].Rows.Find(pMaNhom);
                dtR["MANHOM"] = pMaNhom;
                dtR["TENNHOM"] = pTenNhom;
                string cauLenh = "select MANHOM,TENNHOM FROM NHOMTHUOC";
                SqlDataAdapter dta = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dta);

                dta.Update(ds, "NHOMTHUOC");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Kiểm tra khóa chính
        public int KTKhoaChinh_NHOMTHUOC(string pMaNhom)
        {
            try
            {

                if (_Sqlconn.State == ConnectionState.Closed)
                {
                    _Sqlconn.Open();
                }
                string cauLenh = "select count(*) from NHOMTHUOC where MANHOM='" + pMaNhom + "'";

                SqlCommand cmd = new SqlCommand(cauLenh, _Sqlconn);

                int kq = (int)cmd.ExecuteScalar();
                if (_Sqlconn.State == ConnectionState.Open)
                {
                    _Sqlconn.Close();
                }
                if (kq >= 1)
                    return 1;//trùng khóa chính
                else
                    return 2;//Thêm               
            }
            catch
            {
                return 3;//Lỗi cú pháp
            }
        }



                                                                                 //============NHÀ SẢN XUẤT================
        public void loadNSX()
        {
            string cauLenh = "select * from NhaSX";
            dt = new SqlDataAdapter(cauLenh, _Sqlconn);
            dt.Fill(ds, "NhaSX");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["NhaSX"].Columns[0];
            ds.Tables["NhaSX"].PrimaryKey = key;

        }

        public DataTable GetNSX()
        {
            return ds.Tables["NhaSX"];
        }


        //===============================Thêm======================================

        public bool ThemnNSX(string pMaNSX, string pTenNSX,string pDC,string pSDT,string pEmail)
        {
            try
            {
                DataRow dtR = ds.Tables["NHASX"].NewRow();
                // gán dữ liệu lên row
                dtR["MA_NSX"] = pMaNSX;
                dtR["TEN_NSX"] = pTenNSX;
                dtR["DIACHI"] = pDC;
                dtR["SDT"] = pSDT;
                dtR["EMAIL"] = pEmail;
                
                //Thêm dữ liệu vào databale                
                ds.Tables["NHASX"].Rows.Add(dtR);
                // Lưu xuống dataset
                string cauLenh = "SELECT MA_NSX,TEN_NSX,DIACHI,SDT,EMAIL FROM NHASX ";

                SqlDataAdapter dta = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dta);

                dta.Update(ds, "NHASX");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //=================================Xóa================================

        public bool XoaNSX(string pMaNSX)
        {
            try
            {
                DataRow dtR = ds.Tables["NHASX"].Rows.Find(pMaNSX);
                //gán dữ liệu lên row mới tạo ra
                if (dtR != null)
                    dtR.Delete();

                // Lưu xuống dataset
                string cauLenh = "SELECT MA_NSX,TEN_NSX,DIACHI,SDT,EMAIL FROM NHASX ";

                dt = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dt);

                dt.Update(ds, "NHASX");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //========================================Sửa==================================
        public bool suaNSX(string pMaNSX, string pTenNSX, string pDC, string pSDT, string pEmail)
        {
            try
            {
                DataRow dtR = ds.Tables["NHOMTHUOC"].Rows.Find(pMaNSX);
                dtR["MA_NSX"] = pMaNSX;
                dtR["TEN_NSX"] = pTenNSX;
                dtR["DIACHI"] = pDC;
                dtR["SDT"] = pSDT;
                dtR["EMAIL"] = pEmail;
                string cauLenh = "SELECT MA_NSX,TEN_NSX,DIACHI,SDT,EMAIL FROM NHASX";
                SqlDataAdapter dta = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dta);

                dta.Update(ds, "NHASX");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Kiểm tra khóa chính
        public int KTKhoaChinh_NSX(string pMaNSX)
        {
            try
            {

                if (_Sqlconn.State == ConnectionState.Closed)
                {
                    _Sqlconn.Open();
                }
                string cauLenh = "select count(*) from NHASX where MA_NSX='" + pMaNSX + "'";

                SqlCommand cmd = new SqlCommand(cauLenh, _Sqlconn);

                int kq = (int)cmd.ExecuteScalar();
                if (_Sqlconn.State == ConnectionState.Open)
                {
                    _Sqlconn.Close();
                }
                if (kq >= 1)
                    return 1;//trùng khóa chính
                else
                    return 2;//Thêm               
            }
            catch
            {
                return 3;//Lỗi cú pháp
            }
        }

        
                                                                                    //============ĐỔI TRẢ================
        public void loadDoiTra()
        {
            string cauLenh = "select * from DOITRA";
            dt = new SqlDataAdapter(cauLenh, _Sqlconn);
            dt.Fill(ds, "DOITRA");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["DOITRA"].Columns[0];
            ds.Tables["DOITRA"].PrimaryKey = key;

        }

        public DataTable GetDoiTra()
        {
            return ds.Tables["DOITRA"];
        }

        //===================THÊM=================================
        //SELECT MADOITRA, MANV, MAKH, NGAYLAP, LYDO_DOITRA, GIATRI_DOITRA, TRANGTHAI_DOITAR FROM DOITRA
        public bool ThemnDoiTra(string pMaDTR, string pMaNV, string pMAKH, string pNgay, string pLyDo, float dGtr, string pTrangThai)
        {
            try
            {
                DataRow dtR = ds.Tables["DOITRA"].NewRow();
                // gán dữ liệu lên row
                dtR["MADOITRA"] = pMaDTR;
                dtR["MANV"] = pMaNV;
                dtR["MAKH"] = pMAKH;              
                dtR["NGAYLAP"] = pNgay;
                dtR["LYDO_DOITRA"] = pLyDo;
                dtR["GIATRI_DOITRA"] = dGtr;
                dtR["TRANGTHAI_DOITAR"] = pTrangThai;
                

                //Thêm dữ liệu vào databale                
                ds.Tables["DOITRA"].Rows.Add(dtR);
                // Lưu xuống dataset
                string cauLenh = "SELECT MADOITRA, MANV, MAKH, NGAYLAP, LYDO_DOITRA, GIATRI_DOITRA, TRANGTHAI_DOITAR FROM DOITRA";

                SqlDataAdapter dta = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dta);

                dta.Update(ds, "DOITRA");
                return true;
            }
            catch
            {
                return false;
            }
        }


        //=================================Xóa================================

        public bool XoaDoiTra(string pMaDT)
        {
            try
            {
                DataRow dtR = ds.Tables["DOITRA"].Rows.Find(pMaDT);
                //gán dữ liệu lên row mới tạo ra
                if (dtR != null)
                    dtR.Delete();

                // Lưu xuống dataset
                string cauLenh = "SELECT MADOITRA,MANV,MAKH,NGAYLAP,LYDO_DOITRA,GIATRI_DOITRA,TRANGTHAI_DOITAR FROM DOITRA";

                dt = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dt);

                dt.Update(ds, "DOITRA");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //========================================Sửa==================================
        public bool suaDoiTra(string pMaDTR, string pMaNV, string pMAKH, string pNgay, string pLyDo, float dGtr, string pTrangThai)
        {
            try
            {
                DataRow dtR = ds.Tables["DOITRA"].Rows.Find(pMaDTR);
                dtR["MADOITRA"] = pMaDTR;
                dtR["MANV"] = pMaNV;
                dtR["MAKH"] = pMAKH;
                dtR["NGAYLAP"] = pNgay;
                dtR["LYDO_DOITRA"] = pLyDo;
                dtR["GIATRI_DOITRA"] = dGtr;
                dtR["TRANGTHAI_DOITAR"] = pTrangThai;
                string cauLenh = "SELECT MADOITRA,MANV,MAKH,NGAYLAP,LYDO_DOITRA,GIATRI_DOITRA,TRANGTHAI_DOITAR FROM DOITRA";
                SqlDataAdapter dta = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dta);

                dta.Update(ds, "DOITRA");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Kiểm tra khóa chính
        public int KTKhoaChinh_DOITRA(string pMaDT)
        {
            try
            {

                if (_Sqlconn.State == ConnectionState.Closed)
                {
                    _Sqlconn.Open();
                }
                string cauLenh = "select count(*) from DOITRA where MADOITRA='" + pMaDT + "'";

                SqlCommand cmd = new SqlCommand(cauLenh, _Sqlconn);

                int kq = (int)cmd.ExecuteScalar();
                if (_Sqlconn.State == ConnectionState.Open)
                {
                    _Sqlconn.Close();
                }
                if (kq >= 1)
                    return 1;//trùng khóa chính
                else
                    return 2;//Thêm               
            }
            catch
            {
                return 3;//Lỗi cú pháp
            }
        }

                                                                //====================================================KHÁCH HÀNG=========================================
        

        //SELECT MAKH, TENKH,NGAYSINH,GIOITINH,DIACHI,SDT FROM KHACHHANG
        //============KHÁCH HÀNG================
        public void loadKH()
        {
            string cauLenh = "select * from KHACHHANG";
            dt = new SqlDataAdapter(cauLenh, _Sqlconn);
            dt.Fill(ds, "KHACHHANG");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["KHACHHANG"].Columns[0];
            ds.Tables["KHACHHANG"].PrimaryKey = key;

        }

        public DataTable GetKH()
        {
            return ds.Tables["KHACHHANG"];
        }
        //===============================Thêm======================================
        public bool ThemKhachHang(string pMaKH, string pTenKH, string pNgayS, bool GT, string pDC, string pSDT)
        {
            try
            {
                DataRow dtR = ds.Tables["KHACHHANG"].NewRow();
                // gán dữ liệu lên row
                dtR["MAKH"] = pMaKH;
                dtR["TENKH"] = pTenKH;
                dtR["NGAYSINH"] = pNgayS;
                dtR["GIOITINH"] = GT;
                dtR["DIACHI"] = pDC;
                dtR["SDT"] = pSDT;
                


                //Thêm dữ liệu vào databale                
                ds.Tables["KHACHHANG"].Rows.Add(dtR);
                // Lưu xuống dataset
                string cauLenh = "SELECT MAKH, TENKH,NGAYSINH,GIOITINH,DIACHI,SDT FROM KHACHHANG";

                SqlDataAdapter dta = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dta);

                dta.Update(ds, "KHACHHANG");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //=================================Xóa================================

        public bool XoaKH(string pMaKH)
        {
            try
            {
                DataRow dtR = ds.Tables["KHACHHANG"].Rows.Find(pMaKH);
                //gán dữ liệu lên row mới tạo ra
                if (dtR != null)
                    dtR.Delete();

                // Lưu xuống dataset
                string cauLenh = "SELECT MAKH, TENKH,NGAYSINH,GIOITINH,DIACHI,SDT FROM KHACHHANG";

                dt = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dt);

                dt.Update(ds, "KHACHHANG");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //========================================Sửa==================================
        public bool suaKhachHang(string pMaKH, string pTenKH, string pNgayS, bool GT, string pDC, string pSDT)
        {
            try
            {
                DataRow dtR = ds.Tables["KHACHHANG"].Rows.Find(pMaKH);
                dtR["MAKH"] = pMaKH;
                dtR["TENKH"] = pTenKH;
                dtR["NGAYSINH"] = pNgayS;
                dtR["GIOITINH"] = GT;
                dtR["DIACHI"] = pDC;
                dtR["SDT"] = pSDT;
                string cauLenh = "SELECT MAKH, TENKH,NGAYSINH,GIOITINH,DIACHI,SDT FROM KHACHHANG";
                SqlDataAdapter dta = new SqlDataAdapter(cauLenh, _Sqlconn);

                SqlCommandBuilder build = new SqlCommandBuilder(dta);

                dta.Update(ds, "KHACHHANG");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Kiểm tra khóa chính
        public int KTKhoaChinh_KHACHHANG(string pMaKH)
        {
            try
            {
               
                if (_Sqlconn.State == ConnectionState.Closed)
                {
                    _Sqlconn.Open();
                }
                string cauLenh = "select count(*) from KHACHHANG where MAKH='" + pMaKH + "'";

                SqlCommand cmd = new SqlCommand(cauLenh, _Sqlconn);

                int kq = (int)cmd.ExecuteScalar();
                if (_Sqlconn.State == ConnectionState.Open)
                {
                    _Sqlconn.Close();
                }
                if (kq >= 1)
                    return 1;//trùng khóa chính
                else
                    return 2;//Thêm               
            }
            catch
            {
                return 3;//Lỗi cú pháp
            }
        }




    }
}
