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
    public partial class frmNhanVien : Form
    {
        XuLy xl = new XuLy();
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void nHANVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.nHANVIENBindingSource.EndEdit();
            

        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = xl.GetNhanVien();
            // TODO: This line of code loads data into the 'qL_NHATHUOCTAYDataSet.NHANVIEN' table. You can move, or remove it, as needed.
            //this.nHANVIENTableAdapter.Fill(this.qL_NHATHUOCTAYDataSet.NHANVIEN);
            //// TODO: This line of code loads data into the 'qL_NHATHUOCTAYDataSet.NHANVIEN' table. You can move, or remove it, as needed.
            //this.nHANVIENTableAdapter.Fill(this.qL_NHATHUOCTAYDataSet.NHANVIEN);

            //vô hiệu các txt 
            //txtMaNV.Enabled = cbMaND.Enabled = txtTenNV.Enabled = txtEmail.Enabled = dataNS.Enabled =txtDiaChi.Enabled=txtSDT.Enabled=cbTrinhDo.Enabled=txtLuong.Enabled= false;
            //vô hiệu button
           // btnXoa.Enabled = btnSua.Enabled = btnLuu.Enabled = false;



            //=============Load cbo==================
            //Load cboNGUOIDUNG
            cbMaND.DataSource = xl.GetNguoiDung();
            cbMaND.ValueMember = "MAND";
            cbMaND.DisplayMember = "MAND";

            //Load tên quyền
            cbQuyen.DataSource = xl.GetNguoiDung();
            cbQuyen.ValueMember = "TENQUYEN";
            cbQuyen.DisplayMember = "TENQUYEN";


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            if (dgvNhanVien.CurrentRow != null)
            {
                txtMaNV.Text = dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
                cbMaND.SelectedValue = dgvNhanVien.CurrentRow.Cells[1].Value.ToString();
                txtTenNV.Text = dgvNhanVien.CurrentRow.Cells[2].Value.ToString();
                txtEmail.Text = dgvNhanVien.CurrentRow.Cells[3].Value.ToString();
                dataNS.Text = dgvNhanVien.CurrentRow.Cells[4].Value.ToString();             
                if (dgvNhanVien.CurrentRow.Cells[5].Value.ToString() == "True")
                    rdNam.Checked = true;
                else
                    rdNu.Checked = true;
                txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells[6].Value.ToString();
                txtSDT.Text = dgvNhanVien.CurrentRow.Cells[7].Value.ToString();
                cbTrinhDo.Text = dgvNhanVien.CurrentRow.Cells[8].Value.ToString();
                txtLuong.Text = dgvNhanVien.CurrentRow.Cells[9].Value.ToString();
            }
        }     

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaNV.Enabled = cbMaND.Enabled = txtTenNV.Enabled = txtEmail.Enabled = dataNS.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = cbTrinhDo.Enabled = txtLuong.Enabled = true;
            btnXoa.Enabled = btnSua.Enabled =  false;
            btnLuu.Enabled = true;
            txtMaNV.Focus();
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtLuong.Clear();
            cbMaND.SelectedValue = " ";
            cbQuyen.SelectedValue = "";
            dataNS.Text = "";
            cbTrinhDo.Text = " ";

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            bool GioiTinh;
            if (rdNam.Checked == true)
                GioiTinh = true; //Nam
            else
                GioiTinh = false; //Nữ

            //Kiểm tra thông tin vừa nhập
            if (txtMaNV.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập MÃ NHÂN VIÊN!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }
            if (txtTenNV.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập TÊN NHÂN VIÊN!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtTenNV.Focus();
                return;
            }
            if (txtEmail.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập EMAIL!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            if (txtDiaChi.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập ĐỊA CHỈ!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }
            if (txtSDT.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập SỐ ĐIỆN THOẠI!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }
            if (txtLuong.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập LƯƠNG!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtLuong.Focus();
                return;
            }
            if (cbMaND.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập MÃ NGƯỜI DÙNG!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                cbMaND.Focus();
                return;
            }
            if (cbQuyen.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập QUYỀN!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                cbQuyen.Focus();
                return;
            }
            
            if (cbTrinhDo.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập TRÌNH ĐỘ !!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                cbTrinhDo.Focus();
                return;
            }


            try
            {
                if (txtMaNV.Enabled == true)
                {
                    //Kiểm tra khóa chính
                    if (xl.KTKhoaChinh_NHANVIEN(txtMaNV.Text) == 3)
                    {
                        MessageBox.Show("Sai câu lệnh!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    //Ktra có trùng khóa chính ko
                    if (xl.KTKhoaChinh_NHANVIEN(txtMaNV.Text) == 1)
                    {
                        MessageBox.Show("Trùng khóa chính vui lòng nhập lại!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }

                    if (xl.ThemnNhanVien(txtMaNV.Text, cbMaND.SelectedValue.ToString(), txtTenNV.Text, txtEmail.Text, dataNS.Text, GioiTinh, txtDiaChi.Text, txtSDT.Text, cbTrinhDo.Text, int.Parse(txtLuong.Text)))
                    {

                        MessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                        xl.loadNhanVien();
                        dgvNhanVien.DataSource = xl.GetNhanVien();
                    }
                    else
                    {
                        MessageBox.Show("Thất bại!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    if (xl.suaNhanVien(txtMaNV.Text, cbMaND.SelectedValue.ToString(), txtTenNV.Text, txtEmail.Text, dataNS.Text, GioiTinh, txtDiaChi.Text, txtSDT.Text, cbTrinhDo.Text, int.Parse(txtLuong.Text)))
                    {
                        MessageBox.Show("Đã sửa thành công  " + txtMaNV.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                        xl.loadNhanVien();
                        dgvNhanVien.DataSource = xl.GetNhanVien();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa??", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                            MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                if (xl.XoaNhanVien(txtMaNV.Text))
                {
                    MessageBox.Show("Đã xóa thành công ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                    xl.loadNhanVien();
                    dgvNhanVien.DataSource = xl.GetNhanVien();
                }
                else
                {
                    MessageBox.Show("Thất bại!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            txtMaNV.Enabled = false;
            cbMaND.Enabled = txtTenNV.Enabled = txtEmail.Enabled = dataNS.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = cbTrinhDo.Enabled = txtLuong.Enabled = true;
        }
    }
}
