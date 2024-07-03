using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;


namespace QL_ThuocTay
{
    public partial class frmThuoc : Form
    {
       
        XuLy xl = new XuLy();
        public frmThuoc()
        {
            InitializeComponent();
        }

        private void tHONGTINTHUOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tHONGTINTHUOCBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qL_NHATHUOCTAYDataSet);

        }

        private void frmThuoc_Load(object sender, EventArgs e)
        {
                      
            //============NHÓM THUỐC====================
            dgvNhomThuoc.DataSource = xl.GetNhomThuoc();
            txtMaNhomThuoc.Enabled = txtTenNhomThuoc.Enabled = false;
            btnXoa_NhomThuoc.Enabled = btnSua_NhomThuoc.Enabled = btnLuu_NhomThuoc.Enabled = false;

            //============BỆNH====================
            dgv_Benh.DataSource = xl.GetBenh();
            txtMaBenh.Enabled = txtTenBenh.Enabled = false;
            btnXoa_Benh.Enabled = btnSua_Benh.Enabled = btnLuu_Benh.Enabled = false;

            //============NHÀ SẢN XUẤT====================
            dgv_NSX.DataSource = xl.GetNSX();
            txtMaNSX.Enabled = txtTenNSX.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = txtEmail.Enabled = false;
            btnXoa_NSX.Enabled = btnSua_NSX.Enabled = btnLuu_NSX.Enabled = false;

            //============THÔNG TIN THUỐC====================
            dgvThuoc.DataSource = xl.GetThuoc();
            txtMaThuoc.Enabled = txtTenThuoc.Enabled = txtSoLuongTon.Enabled = cboDVT.Enabled = txtGiaBan.Enabled = false;
            txtCongDung.Enabled = txtCachDung.Enabled = txtChiDinh.Enabled = txtBaoQuan.Enabled = txtHSD.Enabled = cbTenNSX.Enabled = cbNhomThuoc.Enabled = cbViTr.Enabled = false;
            btnXoa_Thuoc.Enabled = btnSua_Thuoc.Enabled = btnLuu_Thuoc.Enabled = false;

            
            //====================LOAD COMBOX
            //Load cbTenNhomThuoc
            cbNhomThuoc.DataSource = xl.GetNhomThuoc();
            cbNhomThuoc.ValueMember = "MANHOM";
            cbNhomThuoc.DisplayMember = "TENNHOM";


            //Load cbTen_NSX
            cbTenNSX.DataSource = xl.GetNSX();
            cbTenNSX.ValueMember = "MA_NSX";
            cbTenNSX.DisplayMember = "TEN_NSX";
        }


        private void dgvNhomThuoc_SelectionChanged(object sender, EventArgs e)
        {
            btnXoa_NhomThuoc.Enabled = btnSua_NhomThuoc.Enabled = true;
            if (dgvNhomThuoc.CurrentRow !=null)
            {
                for (int i = 0; i < dgvNhomThuoc.Rows.Count; i++)
                {
                    dgvNhomThuoc.Rows[i].Cells[0].Value = i + 1;
                }
                txtMaNhomThuoc.Text = dgvNhomThuoc.CurrentRow.Cells[1].Value.ToString();
                txtTenNhomThuoc.Text = dgvNhomThuoc.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void dgv_Benh_SelectionChanged(object sender, EventArgs e)
        {
            btnXoa_Benh.Enabled = btnSua_Benh.Enabled = true;
            if (dgv_Benh.CurrentRow != null)
            {
                for (int i = 0; i < dgv_Benh.Rows.Count; i++)
                {
                    dgv_Benh.Rows[i].Cells[0].Value = i + 1;
                }
                txtMaBenh.Text = dgv_Benh.CurrentRow.Cells[1].Value.ToString();
                txtTenBenh.Text = dgv_Benh.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void dgv_NSX_SelectionChanged(object sender, EventArgs e)
        {
            btnXoa_NSX.Enabled = btnSua_NSX.Enabled = true;
            if (dgv_NSX.CurrentRow != null)
            {
                for (int i = 0; i < dgv_NSX.Rows.Count; i++)
                {
                    dgv_NSX.Rows[i].Cells[0].Value = i + 1;
                }
                txtMaNSX.Text = dgv_NSX.CurrentRow.Cells[1].Value.ToString();
                txtTenNSX.Text = dgv_NSX.CurrentRow.Cells[2].Value.ToString();
                txtDiaChi.Text= dgv_NSX.CurrentRow.Cells[3].Value.ToString();
                txtSDT.Text = dgv_NSX.CurrentRow.Cells[4].Value.ToString();
                txtEmail.Text = dgv_NSX.CurrentRow.Cells[5].Value.ToString();

            }
        }
       
        
        private void dgvThuoc_SelectionChanged(object sender, EventArgs e)
        {
            btnXoa_Thuoc.Enabled = btnSua_Thuoc.Enabled = true;
            if (dgvThuoc.CurrentRow != null)
            {
                for (int i = 0; i < dgvThuoc.Rows.Count; i++)
                {
                    dgvThuoc.Rows[i].Cells[0].Value = i + 1;
                }

                txtMaThuoc.Text = dgvThuoc.CurrentRow.Cells[1].Value.ToString();
                txtTenThuoc.Text = dgvThuoc.CurrentRow.Cells[2].Value.ToString();
                txtSoLuongTon.Text = dgvThuoc.CurrentRow.Cells[3].Value.ToString();
                cboDVT.Text = dgvThuoc.CurrentRow.Cells[4].Value.ToString();
                txtGiaBan.Text = dgvThuoc.CurrentRow.Cells[5].Value.ToString();
                txtCongDung.Text = dgvThuoc.CurrentRow.Cells[6].Value.ToString();
                txtCachDung.Text = dgvThuoc.CurrentRow.Cells[7].Value.ToString();
                txtChiDinh.Text = dgvThuoc.CurrentRow.Cells[8].Value.ToString();
                txtBaoQuan.Text = dgvThuoc.CurrentRow.Cells[9].Value.ToString();
                txtHSD.Text = dgvThuoc.CurrentRow.Cells[10].Value.ToString();
                txtImage.Text = dgvThuoc.CurrentRow.Cells[11].Value.ToString();
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                pictureBox1.Image = Image.FromFile(txtImage.Text.ToString());            
                cbTenNSX.SelectedValue = dgvThuoc.CurrentRow.Cells[12].Value.ToString();
                cbViTr.Text = dgvThuoc.CurrentRow.Cells[13].Value.ToString();
                cbNhomThuoc.SelectedValue = dgvThuoc.CurrentRow.Cells[14].Value.ToString();                               
            }
        }

       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = openFileDialog.Filter = "All files (*.*)|*.*|JPG file (*.jpg)|*.jpg";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog.FileName;
                txtImage.Text = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }
        }
        
        private void btnThem_NhomThuoc_Click(object sender, EventArgs e)
        {
            txtMaNhomThuoc.Enabled = txtTenNhomThuoc.Enabled =  true;
            btnXoa_NhomThuoc.Enabled = btnSua_NhomThuoc.Enabled = btnLuu_NhomThuoc.Enabled = false;
            btnLuu_NhomThuoc.Enabled = true;
            txtMaNhomThuoc.Focus();
            txtMaNhomThuoc.Clear();
            txtTenNhomThuoc.Clear();
        }

        private void btnSua_NhomThuoc_Click(object sender, EventArgs e)
        {
            btnLuu_NhomThuoc.Enabled = true;
            txtMaNhomThuoc.Enabled = false;
            txtTenNhomThuoc.Enabled = true;
        }

        private void btnXoa_NhomThuoc_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn muốn xóa??", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                            MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                if (xl.XoaNhomThuoc(txtMaNhomThuoc.Text))
                {
                    MessageBox.Show("Đã xóa thành công " + txtMaNhomThuoc.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                    xl.loadNhomThuoc();
                    dgvNhomThuoc.DataSource = xl.GetNhomThuoc();
                }
                else
                {
                    MessageBox.Show("Thất bại!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnLuu_NhomThuoc_Click(object sender, EventArgs e)
        {
            //Kiểm tra thông tin vừa nhập
            if (txtMaNhomThuoc.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập MÃ NHÓM THUỐC!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtMaNhomThuoc.Focus();
                return;
            }
            if (txtTenNhomThuoc.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập TÊN NHÓM THUỐC!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtTenNhomThuoc.Focus();
                return;
            }
            try
            {
                if (txtMaNhomThuoc.Enabled == true)
                {
                    //Kiểm tra khóa chính
                    if (xl.KTKhoaChinh_NHOMTHUOC(txtMaNhomThuoc.Text) == 3)
                    {
                        MessageBox.Show("Sai câu lệnh!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    //Ktra có trùng khóa chính ko
                    if (xl.KTKhoaChinh_KHACHHANG(txtMaNhomThuoc.Text) == 1)
                    {
                        MessageBox.Show("Trùng khóa chính vui lòng nhập lại!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }

                    if (xl.ThemnNhomThuoc(txtMaNhomThuoc.Text, txtTenNhomThuoc.Text))
                    {
                        MessageBox.Show("Đã thêm thành công " + txtMaNhomThuoc.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                        xl.loadNhomThuoc();
                        dgvNhomThuoc.DataSource = xl.GetNhomThuoc();
                    }
                    else
                    {
                        MessageBox.Show("Thất bại!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    if (xl.suaNhomThuoc(txtMaNhomThuoc.Text, txtTenNhomThuoc.Text))
                    {
                        MessageBox.Show("Đã sửa thành công  " + txtMaNhomThuoc.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                        xl.loadNhomThuoc();
                        dgvNhomThuoc.DataSource = xl.GetNhomThuoc();
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

        private void btnThem_Benh_Click(object sender, EventArgs e)
        {
            txtMaBenh.Enabled = txtTenBenh.Enabled = true;
            btnXoa_Benh.Enabled = btnSua_Benh.Enabled = btnLuu_Benh.Enabled = false;
            btnLuu_Benh.Enabled = true;
            txtMaBenh.Focus();
            txtMaBenh.Clear();
            txtTenBenh.Clear();
        }

        private void btnSua_Benh_Click(object sender, EventArgs e)
        {
            btnLuu_Benh.Enabled = true;
            txtMaBenh .Enabled = false;
            txtTenBenh.Enabled = true;
        }

        private void btnXoa_Benh_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa??", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                            MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                if (xl.XoaBenh(txtMaBenh.Text))
                {
                    MessageBox.Show("Đã xóa thành công " + txtMaBenh.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                    xl.loadBenh();
                    dgv_Benh.DataSource = xl.GetBenh();
                }
                else
                {
                    MessageBox.Show("Thất bại!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnLuu_Benh_Click(object sender, EventArgs e)
        {
            //Kiểm tra thông tin vừa nhập
            if (txtMaBenh.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập MÃ BỆNH!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtMaBenh.Focus();
                return;
            }
            if (txtTenBenh.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập TÊN BỆNH!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtTenBenh.Focus();
                return;
            }
            try
            {
                if (txtMaBenh.Enabled == true)
                {
                    //Kiểm tra khóa chính
                    if (xl.KTKhoaChinh_BENH(txtMaBenh.Text) == 3)
                    {
                        MessageBox.Show("Sai câu lệnh!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    //Ktra có trùng khóa chính ko
                    if (xl.KTKhoaChinh_BENH(txtMaBenh.Text) == 1)
                    {
                        MessageBox.Show("Trùng khóa chính vui lòng nhập lại!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }

                    if (xl.ThemnBenh(txtMaBenh.Text, txtTenBenh.Text))
                    {
                        MessageBox.Show("Đã thêm thành công " + txtMaBenh.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                        xl.loadBenh();
                        dgv_Benh.DataSource = xl.GetBenh();
                    }
                    else
                    {
                        MessageBox.Show("Thất bại!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    if (xl.suaBenh(txtMaBenh.Text, txtTenBenh.Text))
                    {
                        MessageBox.Show("Đã sửa thành công  " + txtMaBenh.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                        xl.loadBenh();
                        dgv_Benh.DataSource = xl.GetBenh();
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

        private void btnThem_NSX_Click(object sender, EventArgs e)
        {
            txtMaNSX.Enabled = txtTenNSX.Enabled =txtSDT.Enabled=txtEmail.Enabled=txtDiaChi.Enabled= true;
            btnXoa_NSX.Enabled = btnSua_NSX.Enabled = btnLuu_NSX.Enabled = false;
            btnLuu_NSX.Enabled = true;
            txtMaNSX.Focus();
            txtMaNSX.Clear();
            txtTenNSX.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
        }

        private void btnXoa_NSX_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa??", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                            MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                if (xl.XoaNSX(txtMaNSX.Text))
                {
                    MessageBox.Show("Đã xóa thành công " + txtMaNSX.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                    xl.loadNSX();
                    dgv_NSX.DataSource = xl.GetNSX();
                }
                else
                {
                    MessageBox.Show("Thất bại!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSua_NSX_Click(object sender, EventArgs e)
        {
            btnLuu_NSX.Enabled = true;
            txtMaNSX.Enabled = false;
            txtTenNSX.Enabled = true;
            txtSDT.Enabled = true;
            txtEmail.Enabled = true;
            txtDiaChi.Enabled = true;
        }

        private void btnLuu_NSX_Click(object sender, EventArgs e)
        {
            //Kiểm tra thông tin vừa nhập
            if (txtMaNSX.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập MÃ NHÀ SẢN XUẤT!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtMaNSX.Focus();
                return;
            }
            if (txtTenNSX.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập TÊN NHÀ SẢN XUẤT!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtTenNSX.Focus();
                return;
            }
            if (txtSDT.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập SỐ ĐIỆN THOẠI!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtSDT.Focus();
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
            try
            {
                if (txtMaNSX.Enabled == true)
                {
                    //Kiểm tra khóa chính
                    if (xl.KTKhoaChinh_NSX(txtMaNSX.Text) == 3)
                    {
                        MessageBox.Show("Sai câu lệnh!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    //Ktra có trùng khóa chính ko
                    if (xl.KTKhoaChinh_NSX(txtMaNSX.Text) == 1)
                    {
                        MessageBox.Show("Trùng khóa chính vui lòng nhập lại!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }

                    if (xl.ThemnNSX(txtMaNSX.Text, txtTenNSX.Text,txtDiaChi.Text,txtSDT.Text,txtEmail.Text))
                    {
                        MessageBox.Show("Đã thêm thành công " + txtMaBenh.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                        xl.loadNSX();
                        dgv_NSX.DataSource = xl.GetNSX();
                    }
                    else
                    {
                        MessageBox.Show("Thất bại!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    if (xl.suaNSX(txtMaNSX.Text, txtTenNSX.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text))
                    {
                        MessageBox.Show("Đã sửa thành công  " + txtMaNSX.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                        xl.loadNSX();
                        dgv_NSX.DataSource = xl.GetNSX();
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

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            txtMaThuoc.Enabled = txtTenThuoc.Enabled = txtSoLuongTon.Enabled = cboDVT.Enabled = txtGiaBan.Enabled = true;
            txtCongDung.Enabled = txtCachDung.Enabled = txtChiDinh.Enabled = txtBaoQuan.Enabled = txtHSD.Enabled = cbTenNSX.Enabled = cbNhomThuoc.Enabled = cbViTr.Enabled = true;
            btnLuu_Thuoc.Enabled = true;
            txtMaThuoc.Focus();
            txtMaThuoc.Clear();
            txtTenThuoc.Clear();
            txtSoLuongTon.Clear();
            cboDVT.Text="";
            txtGiaBan.Clear();
            txtCongDung.Clear();
            txtCachDung.Clear();
            txtChiDinh.Clear();
            txtBaoQuan.Clear();
            txtHSD.Clear();
            cbTenNSX.SelectedValue = "";
            cbNhomThuoc.SelectedValue = "";
            cbViTr.Text = "";
            pictureBox1.Image=null;
        }

        private void btnXoa_Thuoc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa??", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                            MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                if (xl.XoaThuoc(txtMaThuoc.Text))
                {
                    MessageBox.Show("Đã xóa thành công " + txtMaThuoc.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                    xl.loadThuoc();
                    dgvThuoc.DataSource = xl.GetThuoc();
                }
                else
                {
                    MessageBox.Show("Thất bại!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSua_Thuoc_Click(object sender, EventArgs e)
        {
            btnLuu_Thuoc.Enabled = true;
            txtTenThuoc.Enabled = txtSoLuongTon.Enabled = cboDVT.Enabled = txtGiaBan.Enabled = true;
            txtCongDung.Enabled = txtCachDung.Enabled = txtChiDinh.Enabled = txtBaoQuan.Enabled = txtHSD.Enabled = cbTenNSX.Enabled = cbNhomThuoc.Enabled = cbViTr.Enabled = true;

        }

        //SELECT MATHUOC,TENTHUOC,SOLUONGTON,DVT,GIABAN,CONGDUNG,CACHDUNG,CHIDINH,BAOQUAN,HSD,HINH,MA_NSX,TENVITRI,MANHOM
        private void btnLuu_Thuoc_Click(object sender, EventArgs e)
        {           
            //Kiểm tra thông tin vừa nhập
            if (txtMaThuoc.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập MÃ THUỐC!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtMaNSX.Focus();
                return;
            }
            if (txtTenThuoc.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập TÊN THUỐC!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtTenThuoc.Focus();
                return;
            }
            if (txtSoLuongTon.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập SỐ LƯỢNG!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtSoLuongTon.Focus();
                return;
            }
            if (cboDVT.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập ĐƠN VỊ TÍNH!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                cboDVT.Focus();
                return;
            }
            if (txtGiaBan.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập GIÁ BÁN!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtGiaBan.Focus();
                return;
            }
            if (txtCongDung.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập CÔNG DỤNG!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtCongDung.Focus();
                return;
            }
            if (txtCachDung.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập CÁCH DÙNG!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtCachDung.Focus();
                return;
            }
            if (txtChiDinh.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập CHỈ ĐỊNH!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtChiDinh.Focus();
                return;
            }
            if (txtBaoQuan.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập BẢO QUẢN!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtBaoQuan.Focus();
                return;
            }
            if (txtHSD.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập HẠN SỬ DỤNG!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtCongDung.Focus();
                return;
            }
            if (cbTenNSX.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập TÊN NHÀ SẢN XUẤT!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtCachDung.Focus();
                return;
            }
            if (cbNhomThuoc.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập NHÓM THUỐC!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtChiDinh.Focus();
                return;
            }
            if (cbViTr.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập VỊ TRÍ THUỐC!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtBaoQuan.Focus();
                return;
            }
            //if (pictureBox1.Text == string.Empty)
            //{
            //    MessageBox.Show("Vui lòng chọn HÌNH ẢNH THUỐC!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //    txtBaoQuan.Focus();
            //    return;
            //}
            try
            {
                if (txtMaThuoc.Enabled == true)
                {
                    //Kiểm tra khóa chính
                    if (xl.KTKhoaChinh_THUOC(txtMaThuoc.Text) == 3)
                    {
                        MessageBox.Show("Sai câu lệnh!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    //Ktra có trùng khóa chính ko
                    if (xl.KTKhoaChinh_THUOC(txtMaThuoc.Text) == 1)
                    {
                        MessageBox.Show("Trùng khóa chính vui lòng nhập lại!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }

                    if (xl.ThemnThuoc(txtMaThuoc.Text, txtTenThuoc.Text, int.Parse(txtSoLuongTon.Text), cboDVT.Text, int.Parse(txtGiaBan.Text), txtCongDung.Text, txtCachDung.Text, txtChiDinh.Text, txtBaoQuan.Text, txtHSD.Text, txtImage.Text, cbTenNSX.SelectedValue.ToString(), cbViTr.Text, cbNhomThuoc.SelectedValue.ToString()))
                    {
                        MessageBox.Show("Đã thêm thành công " + txtMaThuoc.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                        xl.loadThuoc();
                        dgvThuoc.DataSource = xl.GetThuoc();
                    }
                    else
                    {
                        MessageBox.Show("Thất bại!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    if (xl.suaThuoc(txtMaThuoc.Text, txtTenThuoc.Text, int.Parse(txtSoLuongTon.Text), cboDVT.Text, int.Parse(txtGiaBan.Text), txtCongDung.Text, txtCachDung.Text, txtChiDinh.Text, txtBaoQuan.Text, txtHSD.Text, txtImage.Text, cbTenNSX.SelectedValue.ToString(), cbViTr.Text, cbNhomThuoc.SelectedValue.ToString()))
                    {
                        MessageBox.Show("Đã sửa thành công  " + txtMaThuoc.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                        xl.loadThuoc();
                        dgvThuoc.DataSource = xl.GetThuoc();
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

       
    }
}
