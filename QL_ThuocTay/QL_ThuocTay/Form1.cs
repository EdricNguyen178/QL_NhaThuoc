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
    public partial class Form1 : Form
    {
        XuLy xl = new XuLy();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult ThongBao;
            ThongBao = (MessageBox.Show("Bạn có muốn thoát chương trình ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
            if (ThongBao == DialogResult.Yes)
                MessageBox.Show("Hẹn gặp lại !!! ");
            Application.Exit();
        }

        private void ckPass_CheckedChanged(object sender, EventArgs e)
        {
            if (ckPass.Checked == true)
            {
                txtMatKhau.PasswordChar = '\0';
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
            }
        }

        private void btnDN_Admin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập TÊN ĐĂNG NHẬP hoặc MẬT KHẨU!", "Thông báo");
                return;
            }
            int kq = xl.Check_Config(); //hàm Check_Config() thuộc Class QL_NguoiDung
            if (kq == 0)
            {
                ProcessLogin();// Cấu hình phù hợp xử lý đăng nhập
            }
        }
        public void ProcessLogin()
        {
            int ketQua = xl.Check_User(txtUser.Text, txtMatKhau.Text); //Check_User viết trong Class QL_NguoiDung
                                                                       // Wrong username or pass
            if (ketQua == 10)
            {
                MessageBox.Show("Sai TÊN ĐĂNG NHẬP hoặc MẬT KHẨU!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Account had been disabled
            else if (ketQua == 20)
            {
                MessageBox.Show("Tài khoản bị khóa");
                return;
            }
            MessageBox.Show("ĐĂNG NHẬP THÀNH CÔNG", "Thông báo");
            this.Hide();
            frmMain main = new frmMain();
            main.ShowDialog();

        }
    }
}
    
