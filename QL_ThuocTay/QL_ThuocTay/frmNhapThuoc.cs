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
    public partial class frmNhapThuoc : Form
    {
        XuLy xl = new XuLy();
        SqlConnection _Sqlconn = new SqlConnection(Properties.Settings.Default.SqlCon);
        DataSet dsQL = new DataSet();
        public frmNhapThuoc()
        {
            InitializeComponent();
        }

        private void frmNhapThuoc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qL_NHATHUOCTAYDataSet.CTNHAPTHUOC' table. You can move, or remove it, as needed.
            //this.cTNHAPTHUOCTableAdapter.Fill(this.qL_NHATHUOCTAYDataSet.CTNHAPTHUOC);
            // TODO: This line of code loads data into the 'qL_NHATHUOCTAYDataSet.NHAPTHUOC' table. You can move, or remove it, as needed.
            //this.nHAPTHUOCTableAdapter.Fill(this.qL_NHATHUOCTAYDataSet.NHAPTHUOC);



                                //=============Load data ==================
            //================== NHẬP THUỐC
            dgvNhapThuoc.DataSource = xl.GetNhapThuoc();
            txtMaHDNhap.Enabled = cbNhanVien.Enabled = dataNgayLap.Enabled = txtTongTien.Enabled = false;
            btnXoa_Nhap.Enabled = btnSua_Nhap.Enabled = btnLuu_Nhap.Enabled = false;

            //==================CT NHẬP THUỐC

            dgvCTNhap.DataSource = xl.Get_CTNhapThuoc();
           cbMaHDN.Enabled = cbMaThuoc.Enabled = cbDVT.Enabled = txtGiaNhap.Enabled = txtSLNhap.Enabled = txtThanhTien.Enabled = false;
            btnLuu_Nhap_CT.Enabled = btnSua_Nhap_CT.Enabled = btnXoa_CT.Enabled = false;
            //=============Load cbo==================
            //LOAD cbo MAHD
            cbMaHDN.DataSource = xl.GetNhapThuoc();
            cbMaHDN.ValueMember = "MAHD_NHAP";
            cbMaHDN.DisplayMember = "MAHD_NHAP";
            //Load cboTENNV
            cbNhanVien.DataSource = xl.GetNhanVien();
            cbNhanVien.ValueMember = "MANV";
            cbNhanVien.DisplayMember = "TENNV";

            //Load  cbo Thuốc
            cbMaThuoc.DataSource = xl.GetThuoc();
            cbMaThuoc.ValueMember = "MATHUOC";
            cbMaThuoc.DisplayMember = "TENTHUOC";



        }

        private void dgvNhapThuoc_SelectionChanged(object sender, EventArgs e)
        {
            btnXoa_Nhap.Enabled = btnSua_Nhap.Enabled = true;
            if (dgvNhapThuoc.CurrentRow != null)
            {
                for (int i = 0; i < dgvNhapThuoc.Rows.Count; i++)
                {
                    dgvNhapThuoc.Rows[i].Cells[0].Value = i + 1;
                }
                txtMaHDNhap.Text = dgvNhapThuoc.CurrentRow.Cells[1].Value.ToString();
                cbNhanVien.SelectedValue = dgvNhapThuoc.CurrentRow.Cells[2].Value.ToString();
                dataNgayLap.Text = dgvNhapThuoc.CurrentRow.Cells[3].Value.ToString();
                txtTongTien.Text = dgvNhapThuoc.CurrentRow.Cells[4].Value.ToString();
                
            }
        }

        private void dgvCTNhap_SelectionChanged(object sender, EventArgs e)
        {
            btnXoa_CT.Enabled = btnSua_Nhap_CT.Enabled = true;
            if (dgvCTNhap.CurrentRow != null)
            {
                for (int i = 0; i < dgvCTNhap.Rows.Count; i++)
                {
                    dgvCTNhap.Rows[i].Cells[0].Value = i + 1;
                }
                cbMaHDN.SelectedValue = dgvCTNhap.CurrentRow.Cells[1].Value.ToString();
                cbMaThuoc.SelectedValue = dgvCTNhap.CurrentRow.Cells[2].Value.ToString();
                txtSLNhap.Text = dgvCTNhap.CurrentRow.Cells[3].Value.ToString();
                cbDVT.Text = dgvCTNhap.CurrentRow.Cells[4].Value.ToString();
                txtGiaNhap.Text = dgvCTNhap.CurrentRow.Cells[5].Value.ToString();
                txtThanhTien.Text = dgvCTNhap.CurrentRow.Cells[6].Value.ToString();

            }
        }

        private void btnThem_Nhap_Click(object sender, EventArgs e)
        {
            txtMaHDNhap.Enabled = cbNhanVien.Enabled = dataNgayLap.Enabled = true;
            btnLuu_Nhap.Enabled = true;
            txtMaHDNhap.Focus();
            txtMaHDNhap.Clear();
            cbNhanVien.SelectedValue = "";
            txtTongTien.Enabled = false;
            dataNgayLap.Text = "";
        }

        private void btnXoa_Nhap_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa??", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                           MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {

                if (xl.KTTonTaiMaHD_CTHDNHAP(txtMaHDNhap.Text) == 1)
                {
                    MessageBox.Show("Dữ liệu đang sử dụng không thể xóa!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (xl.XoaNhapThuoc(txtMaHDNhap.Text))
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

        private void btnSua_Nhap_Click(object sender, EventArgs e)
        {
            btnLuu_Nhap.Enabled = true;
            txtMaHDNhap.Enabled = txtTongTien.Enabled= false;
            cbNhanVien.Enabled = dataNgayLap.Enabled = true;
        }

        private void btnLuu_Nhap_Click(object sender, EventArgs e)
        {
            //Kiểm tra thông tin vừa nhập
            if (txtMaHDNhap.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập MÃ HÓA ĐON!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtMaHDNhap.Focus();
                return;
            }
            if (cbNhanVien.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập MÃ NHÂN VIÊN!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                cbNhanVien.Focus();
                return;
            }
            if (dataNgayLap.Text == null)
            {
                MessageBox.Show("Vui lòng nhập NGÀY LẬP!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                dataNgayLap.Focus();
                return;
            }

            try
            {
                if (txtMaHDNhap.Enabled == true)
                {
                    //Kiểm tra khóa chính
                    if (xl.KTKhoaChinh_NhapThuoc(txtMaHDNhap.Text) == 3)
                    {
                        MessageBox.Show("Sai câu lệnh!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    //Ktra có trùng khóa chính ko
                    if (xl.KTKhoaChinh_NhapThuoc(txtMaHDNhap.Text) == 1)
                    {
                        MessageBox.Show("Trùng khóa chính vui lòng nhập lại!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }

                    if (xl.ThemnNhapThuoc(txtMaHDNhap.Text, cbNhanVien.SelectedValue.ToString(), dataNgayLap.Text))
                    {
                        MessageBox.Show("Đã thêm thành công" + txtMaHDNhap.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
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
                    if (xl.suaNhapThuoc(txtMaHDNhap.Text, cbNhanVien.SelectedValue.ToString(), dataNgayLap.Text))
                    {
                        MessageBox.Show("Đã sửa thành công " + txtMaHDNhap.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);

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



        //==========================================CHI TIẾT NHẬP THUÓC=================================================//
        private void btnThem_Nhap_CT_Click(object sender, EventArgs e)
        {
            btnLuu_Nhap_CT.Enabled = true;
            cbMaHDN.Enabled = cbMaThuoc.Enabled = cbDVT.Enabled = txtGiaNhap.Enabled = txtSLNhap.Enabled = txtThanhTien.Enabled = true;
            cbMaHDN.Focus();
            cbMaHDN.SelectedValue = "";
            cbMaThuoc.SelectedValue = "";
            cbDVT.Text = "";
            txtGiaNhap.Clear();
            txtThanhTien.Clear();

        }

        private void btnXoa_CT_Click(object sender, EventArgs e)
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
                    cmd.CommandText = "DELETE CTNHAPTHUOC WHERE MAHD_NHAP='" + (cbMaHDN.SelectedValue.ToString())+ "'";
                    cmd.ExecuteNonQuery();

                    if (_Sqlconn.State == ConnectionState.Open)
                    {
                        _Sqlconn.Close();
                    }
                    MessageBox.Show("Đã xóa thành công " + cbMaHDN.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                    SqlDataAdapter dta = new SqlDataAdapter("SELECT MAHD_NHAP, MATHUOC, SLBAN, DVT, GIANHAP, THANHTIEN FROM CTNHAPTHUOC", _Sqlconn);
                    dta.Fill(dsQL, "CTNHAPTHUOC");
                    dgvCTNhap.DataSource = dsQL.Tables["CTNHAPTHUOC"];
                    xl.loadNhapThuoc();
                    dgvNhapThuoc.DataSource = xl.GetNhapThuoc();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thất bại!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                }
            }
        }

        private void btnSua_Nhap_CT_Click(object sender, EventArgs e)
        {
            btnLuu_Nhap_CT.Enabled = true;
            cbMaHDN.Enabled = false;
            cbMaThuoc.Enabled = cbDVT.Enabled = txtGiaNhap.Enabled = txtSLNhap.Enabled = txtThanhTien.Enabled = true;
        }

        private void btnLuu_Nhap_CT_Click(object sender, EventArgs e)
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
                if (cbMaHDN.Enabled == true)
                {

                    if (xl.Themn_CTNhapThuoc(cbMaHDN.SelectedValue.ToString(), cbMaThuoc.SelectedValue.ToString(),int.Parse(txtSLNhap.Text),cbDVT.Text, int.Parse(txtGiaNhap.Text), int.Parse(txtThanhTien.Text)))
                    {
                        MessageBox.Show("Đã thêm thành công" + txtMaHDNhap.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);

                        xl.load_CTNhapThuoc();
                        dgvCTNhap.DataSource = xl.Get_CTNhapThuoc();
                        xl.loadNhapThuoc();
                        dgvNhapThuoc.DataSource = xl.GetNhapThuoc();


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
                            cmd.CommandText = "UPDATE CTNHAPTHUOC SET MATHUOC=('" + cbMaThuoc.SelectedValue.ToString() + "') ,SLBAN=('" + int.Parse(txtSLNhap.Text) + "' ),DVT=('" + cbDVT.Text + "' ),GIANHAP=('" + int.Parse(txtGiaNhap.Text) + "' ), THANHTIEN=('" + int.Parse(txtThanhTien.Text) + "' ) WHERE MAHD_NHAP=('" + cbMaHDN.SelectedValue.ToString() + "')";
                            cmd.ExecuteNonQuery();

                            if (_Sqlconn.State == ConnectionState.Open)
                            {
                                _Sqlconn.Close();
                            }
                            MessageBox.Show("Đã sửa thành công " + cbMaHDN.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                            SqlDataAdapter dta = new SqlDataAdapter("SELECT MAHD_NHAP, MATHUOC, SLBAN, DVT, GIANHAP, THANHTIEN FROM CTNHAPTHUOC", _Sqlconn);
                            dta.Fill(dsQL, "CTNHAPTHUOC");
                            dgvCTNhap.DataSource = dsQL.Tables["CTNHAPTHUOC"];
                            xl.loadNhapThuoc();
                            dgvNhapThuoc.DataSource = xl.GetNhapThuoc();
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
            int SL = int.Parse(txtSLNhap.Text);
            //int SLTreEm = int.Parse(txtSLTreEm_CT.Text);
            int Gia =int.Parse(txtGiaNhap.Text);
            double TongTien = Convert.ToInt32(xl.tinhTongTien(SL, Gia));
            txtThanhTien.Text = TongTien.ToString();
        }
    }
}
