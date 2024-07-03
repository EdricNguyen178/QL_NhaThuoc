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
    public partial class frmKhachHang : Form
    {
        XuLy xl = new XuLy();
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {           
            dgvKhachHang.DataSource = xl.GetKH();
            //vô hiệu các txt 
            txtMaKH.Enabled = txtTenKH.Enabled = dataNS.Enabled = txtSDT.Enabled =txtDiaChi.Enabled = false;           
            //vô hiệu button
            btnXoa.Enabled = btnSua.Enabled = btnLuu.Enabled = false;
        }
        
        private void dgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = btnXoa.Enabled = true;
            if (dgvKhachHang.CurrentRow != null)
            {
                for (int i = 0; i < dgvKhachHang.Rows.Count; i++)
                {
                    dgvKhachHang.Rows[i].Cells[0].Value = i + 1;
                }
                txtMaKH.Text = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();
                txtTenKH.Text = dgvKhachHang.CurrentRow.Cells[2].Value.ToString();
                if (dgvKhachHang.CurrentRow.Cells[4].Value.ToString() == "True")
                    rdNam.Checked = true;
                else
                    rdNu.Checked = true;
                dataNS.Text = dgvKhachHang.CurrentRow.Cells[3].Value.ToString();
                txtSDT.Text = dgvKhachHang.CurrentRow.Cells[6].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells[5].Value.ToString();
                
            }
        }
       
        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool GioiTinh;
            if (rdNam.Checked == true)
                GioiTinh = true; //Nam
            else
                GioiTinh = false; //Nữ
            //Kiểm tra thông tin vừa nhập
            if (txtMaKH.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập MÃ KHÁCH HÀNG!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }
            if (txtTenKH.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập TÊN TOUR!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtTenKH.Focus();
                return;
            }
            if(dataNS.Text==string.Empty)
            {
                MessageBox.Show("Vui lòng nhập NGÀY SINH!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                dataNS.Focus();
                return;
            }
            if (txtSDT.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập SỐ ĐIỆN THOẠI!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }
            if (txtDiaChi.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập ĐỊA CHỈ!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }


            try
            {
                if (txtMaKH.Enabled == true)
                {
                    //Kiểm tra khóa chính
                    if (xl.KTKhoaChinh_KHACHHANG(txtMaKH.Text) == 3)
                    {
                        MessageBox.Show("Sai câu lệnh!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    //Ktra có trùng khóa chính ko
                    if (xl.KTKhoaChinh_KHACHHANG(txtMaKH.Text) == 1)
                    {
                        MessageBox.Show("Trùng khóa chính vui lòng nhập lại!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }

                    if (xl.ThemKhachHang(txtMaKH.Text, txtTenKH.Text, dataNS.Text, GioiTinh, txtDiaChi.Text, txtSDT.Text))
                    {
                        MessageBox.Show("Đã thêm thành công " + txtMaKH.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                        xl.loadKH();
                        dgvKhachHang.DataSource = xl.GetKH();
                    }
                    else
                    {
                        MessageBox.Show("Thất bại!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    if (xl.suaKhachHang(txtMaKH.Text, txtTenKH.Text, dataNS.Text, GioiTinh, txtDiaChi.Text, txtSDT.Text))
                    {
                        MessageBox.Show("Đã sửa thành công  " +  txtMaKH.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                        xl.loadKH();
                        dgvKhachHang.DataSource = xl.GetKH();
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
                if (xl.XoaKH(txtMaKH.Text))
                {
                    MessageBox.Show("Đã xóa thành công ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                    xl.loadKH();
                    dgvKhachHang.DataSource = xl.GetKH();
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
            txtMaKH.Enabled = false;
            txtTenKH.Enabled = dataNS.Enabled = txtSDT.Enabled = txtDiaChi.Enabled = true;            
           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaKH.Enabled = txtTenKH.Enabled = dataNS.Enabled = txtSDT.Enabled = txtDiaChi.Enabled = true;
            btnXoa.Enabled = btnSua.Enabled = btnLuu.Enabled = false;
            btnLuu.Enabled = true;
            txtMaKH.Focus();
            txtMaKH.Clear();
            txtTenKH.Clear();
            dataNS.Text = "";           
            txtDiaChi.Clear();
            txtSDT.Clear();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnTK_KhachHang_Click(object sender, EventArgs e)
        {
            //string str = @"SELECT MAKH, TENKH,NGAYSINH,GIOITINH,DIACHI,SDT FROM KHACHHANG WHERE MAKH LIKE N'%" + txtTimKiem.Text + "%' or TENKH LIKE '%" + txtTimKiem.Text + "%'";
            //DataTable dt = ConnecsionString.getDataTable(str);
            //dgvKhachHang.DataSource = dt;
        }
    }
}
