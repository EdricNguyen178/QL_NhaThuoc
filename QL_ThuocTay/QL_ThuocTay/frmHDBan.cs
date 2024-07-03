using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace QL_ThuocTay
{
    public partial class frmHDBan : Form
    {
        XuLy xl = new XuLy();
        SqlConnection _Sqlconn = new SqlConnection(Properties.Settings.Default.SqlCon);
        DataSet dsQL = new DataSet();
        public frmHDBan()
        {
            InitializeComponent();
        }

        private void frmHDBan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qL_NHATHUOCTAYDataSet.CTHD_BAN' table. You can move, or remove it, as needed.
            //this.cTHD_BANTableAdapter.Fill(this.qL_NHATHUOCTAYDataSet.CTHD_BAN);
            // TODO: This line of code loads data into the 'qL_NHATHUOCTAYDataSet.HOADON_BAN' table. You can move, or remove it, as needed.
            //this.hOADON_BANTableAdapter.Fill(this.qL_NHATHUOCTAYDataSet.HOADON_BAN);


            //================== HÓA ĐƠN BÁN=====================
            dgvBanThuoc.DataSource = xl.GetXuatThuoc();

            txtMaHDBan.Enabled = cbNhanVien.Enabled = cbMaKH.Enabled = dataNLap.Enabled =  cbTinhTrang.Enabled = txtTongTien.Enabled = txtGhiChu.Enabled = false;
            btnLuu_HDB.Enabled = btnSua_HDB.Enabled = btnXoa_HDBAN.Enabled = false;
            //================== CHI TIẾT HÓA ĐƠN BÁN============
            dgvCTBanThuoc.DataSource = xl.Get_CTXuatThuoc();

            cbHDB.Enabled = cbMaThuoc.Enabled = txtSLBan.Enabled = cbDVT.Enabled = txtGiaBan.Enabled = txtThanhTien.Enabled = false;
            btnLuu_CTHDB.Enabled = btnSua_CTHDB.Enabled = btnXoa_CTHDB.Enabled = false;

            //=====================LOAD COMBOX
            //LOAD cbo MAHD
            cbHDB.DataSource = xl.GetXuatThuoc();
            cbHDB.ValueMember = "MAHD";
            cbHDB.DisplayMember = "MAHD";
            //Load cboTENNV
            cbNhanVien.DataSource = xl.GetNhanVien();
            cbNhanVien.ValueMember = "MANV";
            cbNhanVien.DisplayMember = "TENNV";

            //Load cboTENKH
            cbMaKH.DataSource = xl.GetKH();
            cbMaKH.ValueMember = "MAKH";
            cbMaKH.DisplayMember = "TENKH";

            //Load  cbo Thuốc
            cbMaThuoc.DataSource = xl.GetThuoc();
            cbMaThuoc.ValueMember = "MATHUOC";
            cbMaThuoc.DisplayMember = "TENTHUOC";




        }

        private void dgvBanThuoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBanThuoc.CurrentRow != null)
            {
                for (int i = 0; i < dgvBanThuoc.Rows.Count; i++)
                {
                    dgvBanThuoc.Rows[i].Cells[0].Value = i + 1;
                }
                txtMaHDBan.Text = dgvBanThuoc.CurrentRow.Cells[1].Value.ToString();
                cbNhanVien.SelectedValue = dgvBanThuoc.CurrentRow.Cells[2].Value.ToString();
                cbMaKH.SelectedValue = dgvBanThuoc.CurrentRow.Cells[3].Value.ToString();
                dataNLap.Text = dgvBanThuoc.CurrentRow.Cells[4].Value.ToString();
                txtTongTien.Text = dgvBanThuoc.CurrentRow.Cells[5].Value.ToString();
                cbTinhTrang.Text = dgvBanThuoc.CurrentRow.Cells[6].Value.ToString();
                txtGhiChu.Text = dgvBanThuoc.CurrentRow.Cells[7].Value.ToString();

            }
        }

        

        private void dgvCTBanThuoc_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgvCTBanThuoc.CurrentRow != null)
            {
                for (int i = 0; i < dgvCTBanThuoc.Rows.Count; i++)
                {
                    dgvCTBanThuoc.Rows[i].Cells[0].Value = i + 1;
                }
                cbHDB.Text = dgvCTBanThuoc.CurrentRow.Cells[1].Value.ToString();
                cbMaThuoc.SelectedValue = dgvCTBanThuoc.CurrentRow.Cells[2].Value.ToString();
                txtSLBan.Text = dgvCTBanThuoc.CurrentRow.Cells[3].Value.ToString();
                cbDVT.Text = dgvCTBanThuoc.CurrentRow.Cells[4].Value.ToString();
                txtGiaBan.Text = dgvCTBanThuoc.CurrentRow.Cells[5].Value.ToString();
                txtThanhTien.Text = dgvCTBanThuoc.CurrentRow.Cells[6].Value.ToString();

            }
        }

        private void btnThem_HDBan_Click(object sender, EventArgs e)
        {
            btnLuu_HDB.Enabled = true;
            txtMaHDBan.Enabled = cbNhanVien.Enabled = cbMaKH.Enabled = dataNLap.Enabled = cbTinhTrang.Enabled = txtTongTien.Enabled = txtGhiChu.Enabled= true;
            txtMaHDBan.Focus();
            txtMaHDBan.Clear();
            cbNhanVien.SelectedValue = "";
            cbMaKH.SelectedValue = "";
            dataNLap.Text = "";
            txtTongTien.Clear();
            cbTinhTrang.Text = "";
            txtGhiChu.Clear();
            
        }

        private void btnXoa_HDBAN_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa??", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                           MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {

                if (xl.KTTonTaiMaHD_CTHDXUAT(txtMaHDBan.Text) == 1)
                {
                    MessageBox.Show("Dữ liệu đang sử dụng không thể xóa!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (xl.Xoa_XuatThuoc(txtMaHDBan.Text))
                    {
                        MessageBox.Show("Đã xóa thành công ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                    }
                    else
                    {
                        MessageBox.Show("Thất bại!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                }

            }
        }

        private void btnSua_HDB_Click(object sender, EventArgs e)
        {
            btnLuu_HDB.Enabled = true;
            txtMaHDBan.Enabled = false;
            cbNhanVien.Enabled = cbMaKH.Enabled = dataNLap.Enabled = cbTinhTrang.Enabled = txtTongTien.Enabled = txtGhiChu.Enabled = true;
        }

        private void btnLuu_HDB_Click(object sender, EventArgs e)
        {
            //Kiểm tra thông tin vừa nhập
            //if (txtMaHDNhap.Text == string.Empty)
            //{
            //    MessageBox.Show("Vui lòng nhập MÃ HÓA ĐON!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //    txtMaHDNhap.Focus();
            //    return;
            //}
            //if (cbNhanVien.Text == string.Empty)
            //{
            //    MessageBox.Show("Vui lòng nhập MÃ NHÂN VIÊN!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //    cbNhanVien.Focus();
            //    return;
            //}
            //if (dataNgayLap.Text == null)
            //{
            //    MessageBox.Show("Vui lòng nhập NGÀY LẬP!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //    dataNgayLap.Focus();
            //    return;
            //}

            try
            {
                if (txtMaHDBan.Enabled == true)
                {
                    //Kiểm tra khóa chính
                    if (xl.KTKhoaChinh_XuatThuoc(txtMaHDBan.Text) == 3)
                    {
                        MessageBox.Show("Sai câu lệnh!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    //Ktra có trùng khóa chính ko
                    if (xl.KTKhoaChinh_XuatThuoc(txtMaHDBan.Text) == 1)
                    {
                        MessageBox.Show("Trùng khóa chính vui lòng nhập lại!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }

                    if (xl.Themn_XuatThuoc(txtMaHDBan.Text, cbNhanVien.SelectedValue.ToString(), cbMaKH.SelectedValue.ToString(),dataNLap.Text,cbTinhTrang.Text,txtGhiChu.Text))
                    {
                        MessageBox.Show("Đã thêm thành công" + txtMaHDBan.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                        //xlhd.loadDL_HD();
                        //dtGV_HD.DataSource = xlhd.GetHD();
                    }
                    else
                    {
                        MessageBox.Show("Thất bại!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    if (xl.sua_XuatThuoc(txtMaHDBan.Text, cbNhanVien.SelectedValue.ToString(), cbMaKH.SelectedValue.ToString(), dataNLap.Text, cbTinhTrang.Text, txtGhiChu.Text))
                    {
                        MessageBox.Show("Đã sửa thành công " + txtMaHDBan.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);

                    }
                    else
                    {

                        MessageBox.Show("Thất bại!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
            }
        }

        private void btnThem_CTHĐB_Click(object sender, EventArgs e)
        {
            btnLuu_CTHDB.Enabled = true;
            cbHDB.Enabled = cbMaThuoc.Enabled = txtSLBan.Enabled = cbDVT.Enabled = txtGiaBan.Enabled = txtThanhTien.Enabled = true;
            cbHDB.Focus();
            cbHDB.SelectedValue = "";
            cbMaThuoc.SelectedValue = "";
            txtSLBan.Clear();
            cbDVT.SelectedValue = "";
            txtGiaBan.Clear();
            txtThanhTien.Clear();
        }

        private void btnXoa_CTHDB_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa  dòng đã chọn?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                try
                {
                    if (_Sqlconn.State == ConnectionState.Closed)
                    {
                        _Sqlconn.Open();
                    }
                    //string them;

                    //them = "DELETE FROM CTHD WHERE MAHD=('" + cboMaHD_CT.SelectedValue.ToString() + "') and MAVE('" + cboMaVe_CT.SelectedValue.ToString() + "')";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = _Sqlconn;
                    cmd.CommandText = "DELETE CTHD_BAN WHERE MAHD='" + (cbHDB.SelectedValue.ToString()) + "'";
                    cmd.ExecuteNonQuery();

                    if (_Sqlconn.State == ConnectionState.Open)
                    {
                        _Sqlconn.Close();
                    }
                    MessageBox.Show("Đã xóa thành công " + cbHDB.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                    SqlDataAdapter dta = new SqlDataAdapter("SELECT MAHD, MATHUOC, SLBAN, DVT, GIABAN, THANHTIEN FROM CTHD_BAN", _Sqlconn);
                    dta.Fill(dsQL, "CTHD_BAN ");
                    dgvCTBanThuoc.DataSource = dsQL.Tables["CTHD_BAN "];
                    xl.loadXuatThuoc();
                    dgvBanThuoc.DataSource = xl.GetXuatThuoc();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thất bại!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                }
            }
        }

        private void btnSua_CTHDB_Click(object sender, EventArgs e)
        {
            btnLuu_CTHDB.Enabled = true;
            cbHDB.Enabled = false;
            cbMaThuoc.Enabled = txtSLBan.Enabled = cbDVT.Enabled = txtGiaBan.Enabled = txtThanhTien.Enabled = true;
        }

        private void btnLuu_CTHDB_Click(object sender, EventArgs e)
        {
            //Kiểm tra thông tin vừa nhập
            //if (cboMaHD_CT.Text == string.Empty)
            //{
            //    MessageBox.Show("Vui lòng nhập MÃ HÓA ĐON!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //    cboMaHD_CT.Focus();
            //    return;
            //}
            //if (cboMaVe_CT.Text == string.Empty)
            //{
            //    MessageBox.Show("Vui lòng nhập TÊN KHÁCH HÀNG!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //    cboMaVe_CT.Focus();
            //    return;
            //}
            //if (txtSLNguoiLon_CT.Text == string.Empty)
            //{
            //    MessageBox.Show("Vui lòng nhập SỐ LƯỢNG VÉ!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //    txtSLNguoiLon_CT.Focus();
            //    return;
            //}
            try
            {
                if (cbHDB.Enabled == true)
                {

                    if (xl.Themn_CTXuatThuoc(cbHDB.SelectedValue.ToString(), cbMaThuoc.SelectedValue.ToString(), int.Parse(txtSLBan.Text), cbDVT.Text, int.Parse(txtGiaBan.Text), int.Parse(txtThanhTien.Text)))
                    {
                        MessageBox.Show("Đã thêm thành công" + txtMaHDBan.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);

                        xl.load_CTXuatThuoc();
                        dgvCTBanThuoc.DataSource = xl.Get_CTXuatThuoc();
                        xl.loadXuatThuoc();
                        dgvBanThuoc.DataSource = xl.GetXuatThuoc();


                    }
                    else
                    {
                        MessageBox.Show("Thất bại!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa ", "Sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {

                        try
                        {
                            if (_Sqlconn.State == ConnectionState.Closed)
                            {
                                _Sqlconn.Open();
                            }
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = _Sqlconn;
                            cmd.CommandText = "UPDATE CTHD_BAN SET MATHUOC=('" + cbMaThuoc.SelectedValue.ToString() + "') ,SLBAN=('" + int.Parse(txtSLBan.Text) + "' ),DVT=('" + cbDVT.Text + "' ),GIABAN=('" + int.Parse(txtGiaBan.Text) + "' ), THANHTIEN=('" + int.Parse(txtThanhTien.Text) + "' ) WHERE MAHD=('" + cbHDB.SelectedValue.ToString() + "')";
                            cmd.ExecuteNonQuery();

                            if (_Sqlconn.State == ConnectionState.Open)
                            {
                                _Sqlconn.Close();
                            }
                            MessageBox.Show("Đã sửa thành công " + cbHDB.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                            SqlDataAdapter dta = new SqlDataAdapter("SELECT MAHD, MATHUOC, SLBAN, DVT, GIABAN, THANHTIEN FROM CTHD_BAN", _Sqlconn);
                            dta.Fill(dsQL, "CT_BAN");
                            dgvCTBanThuoc.DataSource = dsQL.Tables["CT_BAN"];
                            xl.loadXuatThuoc();
                            dgvBanThuoc.DataSource = xl.GetXuatThuoc();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Thất bại!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
            }
        }

        private void btnThanh_Click(object sender, EventArgs e)
        {
            int SL = int.Parse(txtSLBan.Text);
            //int SLTreEm = int.Parse(txtSLTreEm_CT.Text);
            int Gia = int.Parse(txtGiaBan.Text);
            double TongTien = Convert.ToInt32(xl.tinhTongTien(SL, Gia));
            txtThanhTien.Text = TongTien.ToString();
        }
    }
}
