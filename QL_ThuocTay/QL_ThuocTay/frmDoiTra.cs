using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_ThuocTay
{
    public partial class frmDoiTra : Form
    {
        XuLy xl = new XuLy();
        public frmDoiTra()
        {
            InitializeComponent();
        }

        private void frmDoiTra_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qL_NHATHUOCTAYDataSet.DOITRA' table. You can move, or remove it, as needed.
            //this.dOITRATableAdapter.Fill(this.qL_NHATHUOCTAYDataSet.DOITRA);

            dgvDoiTra.DataSource = xl.GetDoiTra();
            //vô hiệu các txt 
            txtMaDoiTra.Enabled = cbNhanVien.Enabled =cbMaKH.Enabled=dataNgayLap.Enabled=txtLyDo.Enabled=txtGiaTri.Enabled=cbTrangThai.Enabled= false;
            //vô hiệu button
            btnXoa.Enabled = btnXoa.Enabled = btnLuu.Enabled = false;

            //=====================LOAD COMBOX

            //Load cboTENNV
            cbNhanVien.DataSource = xl.GetNhanVien();
            cbNhanVien.ValueMember = "MANV";
            cbNhanVien.DisplayMember = "TENNV";

            //Load cboTENKH
            cbMaKH.DataSource = xl.GetKH();
            cbMaKH.ValueMember = "MAKH";
            cbMaKH.DisplayMember = "TENKH";

        }

        private void dgvDoiTra_SelectionChanged(object sender, EventArgs e)
        {
            btnXoa.Enabled = btnSua.Enabled = true;
            if (dgvDoiTra.CurrentRow != null)
            {
                txtMaDoiTra.Text = dgvDoiTra.CurrentRow.Cells[0].Value.ToString();            
                cbNhanVien.SelectedValue = dgvDoiTra.CurrentRow.Cells[1].Value.ToString();
                cbMaKH.SelectedValue = dgvDoiTra.CurrentRow.Cells[2].Value.ToString();
                dataNgayLap.Text = dgvDoiTra.CurrentRow.Cells[3].Value.ToString();                
                txtLyDo.Text = dgvDoiTra.CurrentRow.Cells[4].Value.ToString();
                txtGiaTri.Text = dgvDoiTra.CurrentRow.Cells[5].Value.ToString();
                cbTrangThai.Text = dgvDoiTra.CurrentRow.Cells[6].Value.ToString();
                
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)

        {
            //Kiểm tra thông tin vừa nhập
            if (txtMaDoiTra.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập MÃ ĐỔI TRẢ!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtMaDoiTra.Focus();
                return;
            }
            if (cbNhanVien.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập TÊN NHÂN VIÊN!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                cbNhanVien.Focus();
                return;
            }
            if (cbMaKH.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập MÃ KHÁCH HÀNG!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                cbMaKH.Focus();
                return;
            }
            if (dataNgayLap.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập NGÀY LẬP!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                dataNgayLap.Focus();
                return;
            }
            if (txtLyDo.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập LÝ DO!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtLyDo.Focus();
                return;
            }
            if (txtGiaTri.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập GIÁ TRỊ!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtGiaTri.Focus();
                return;
            }
            if (cbTrangThai.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập TRẠNG THÁI ĐỔI TAR!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                cbTrangThai.Focus();
                return;
            }
            

            try
            {
                if (txtMaDoiTra.Enabled == true)
                {
                    //Kiểm tra khóa chính
                    if (xl.KTKhoaChinh_NHOMTHUOC(txtMaDoiTra.Text) == 3)
                    {
                        MessageBox.Show("Sai câu lệnh!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    //Ktra có trùng khóa chính ko
                    if (xl.KTKhoaChinh_KHACHHANG(txtMaDoiTra.Text) == 1)
                    {
                        MessageBox.Show("Trùng khóa chính vui lòng nhập lại!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }

                    if (xl.ThemnDoiTra(txtMaDoiTra.Text, cbNhanVien.SelectedValue.ToString(),cbMaKH.SelectedValue.ToString(),dataNgayLap.Text,txtLyDo.Text,float.Parse(txtGiaTri.Text),cbTrangThai.Text))
                    {
                        MessageBox.Show("Đã thêm thành công " + txtMaDoiTra.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                        xl.loadDoiTra();
                        dgvDoiTra.DataSource = xl.GetDoiTra();
                    }
                    else
                    {
                        MessageBox.Show("Thất bại!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    if (xl.suaDoiTra(txtMaDoiTra.Text, cbNhanVien.SelectedValue.ToString(), cbMaKH.SelectedValue.ToString(), dataNgayLap.Text, txtLyDo.Text, float.Parse(txtGiaTri.Text), cbTrangThai.Text))
                    {
                        MessageBox.Show("Đã sửa thành công  " + txtMaDoiTra.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                        xl.loadDoiTra();
                        dgvDoiTra.DataSource = xl.GetDoiTra();
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


        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaDoiTra.Enabled = cbNhanVien.Enabled = cbMaKH.Enabled = dataNgayLap.Enabled = txtLyDo.Enabled = txtGiaTri.Enabled = cbTrangThai.Enabled =true;
            btnXoa.Enabled = btnSua.Enabled = false;
            btnLuu.Enabled = true;
            txtMaDoiTra.Focus();
            txtMaDoiTra.Clear();
            cbNhanVien.SelectedValue = "";
            cbMaKH.SelectedValue = "";
            dataNgayLap.Text = "";
            txtLyDo.Clear();
            txtGiaTri.Clear();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            txtMaDoiTra.Enabled = false;
            cbNhanVien.Enabled = cbMaKH.Enabled = dataNgayLap.Enabled = txtLyDo.Enabled = txtGiaTri.Enabled = cbTrangThai.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa??", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                           MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                if (xl.XoaDoiTra(txtMaDoiTra.Text))
                {
                    MessageBox.Show("Đã xóa thành công " + txtMaDoiTra.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                    xl.loadDoiTra();
                    dgvDoiTra.DataSource = xl.GetDoiTra();
                }
                else
                {
                    MessageBox.Show("Thất bại!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
