using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_ThuocTay
{
    public partial class frmMain : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        public frmMain()
        {
            InitializeComponent();
            random = new Random();
            cutomizeDesing();
            btnClose.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wWsg, int wParam, int lParama);

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    panelTittle.BackColor = color;
                    panelLoGo.BackColor = ThemeColor.ChangeColor(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColor(color, -0.3);
                    btnClose.Visible = true;
                }
            }
        }
        //Design button khi bấm chọn
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(18, 10, 42);
                    previousBtn.ForeColor = Color.Gainsboro;

                }
            }
        }
        //Thiết lập panelmenu
        private void cutomizeDesing()
        {
            panelHeThong.Visible = false;
            panelDanhMuc.Visible = false;
            panelChucNang.Visible = false;
            panelThongKe.Visible = false;
        }
        //Ẩn menu con
        private void hideMenu()
        {
            if (panelHeThong.Visible == true)
                panelHeThong.Visible = false;
            if (panelDanhMuc.Visible == true)
                panelDanhMuc.Visible = false;
            if (panelChucNang.Visible == true)
                panelChucNang.Visible = false;
            if (panelThongKe.Visible == true)
                panelThongKe.Visible = false;
        }
        //Show menu con
        private void showMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        //mở form con
        private Form activeForm = null;

        private void openChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelChild.Controls.Add(childForm);
            this.panelChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lbTieuDe.Text = childForm.Text;

        }


        private void Reset()
        {
            DisableButton();
            lbTieuDe.Text = "HOME";
            panelTittle.BackColor = Color.FromArgb(0, 150, 136);
            panelLoGo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnClose.Visible = false;
        }
        private void btnHide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }    

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            DialogResult ThongBao;
            ThongBao = (MessageBox.Show("Bạn có muốn thoát chương trình ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
            if (ThongBao == DialogResult.Yes)
                MessageBox.Show("Hẹn gặp lại !!! ");
            Application.Exit();
        }

        private void panelTittle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            showMenu(panelHeThong);
        }

        private void btnThuoc_Click(object sender, EventArgs e)
        {
            openChildForm(new frmThuoc(), sender);
            //hideMenu();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();

        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            showMenu(panelDanhMuc);
        }

        private void btnChucNang_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            showMenu(panelChucNang);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            showMenu(panelThongKe);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {          
            openChildForm(new frmNhanVien(), sender);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            openChildForm(new frmKhachHang(), sender);
        }          
          

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            openChildForm(new frmNhapThuoc(), sender);
        }

        

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnDoiTra_Click(object sender, EventArgs e)
        {
            openChildForm(new frmDoiTra(), sender);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHDBanThuoc_Click(object sender, EventArgs e)
        {
            openChildForm(new frmHDBan(), sender);
        }

        private void btnBanThuoc_Click(object sender, EventArgs e)
        {
            openChildForm(new frmBanThuoc(), sender);
        }
    }
}
