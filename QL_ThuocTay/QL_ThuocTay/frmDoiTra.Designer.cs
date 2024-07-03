namespace QL_ThuocTay
{
    partial class frmDoiTra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoiTra));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbMaKH = new System.Windows.Forms.ComboBox();
            this.cbNhanVien = new System.Windows.Forms.ComboBox();
            this.txtGiaTri = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.dataNgayLap = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaDoiTra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDoiTra = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dOITRABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qL_NHATHUOCTAYDataSet = new QL_ThuocTay.QL_NHATHUOCTAYDataSet();
            this.dOITRATableAdapter = new QL_ThuocTay.QL_NHATHUOCTAYDataSetTableAdapters.DOITRATableAdapter();
            this.btnTK_KhachHang = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoiTra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOITRABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qL_NHATHUOCTAYDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PowderBlue;
            this.panel1.Controls.Add(this.btnTK_KhachHang);
            this.panel1.Controls.Add(this.txtTimKiem);
            this.panel1.Controls.Add(this.cbMaKH);
            this.panel1.Controls.Add(this.cbNhanVien);
            this.panel1.Controls.Add(this.txtGiaTri);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtLyDo);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnLuu);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cbTrangThai);
            this.panel1.Controls.Add(this.dataNgayLap);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtMaDoiTra);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1428, 290);
            this.panel1.TabIndex = 0;
            // 
            // cbMaKH
            // 
            this.cbMaKH.FormattingEnabled = true;
            this.cbMaKH.Location = new System.Drawing.Point(411, 148);
            this.cbMaKH.Name = "cbMaKH";
            this.cbMaKH.Size = new System.Drawing.Size(121, 24);
            this.cbMaKH.TabIndex = 71;
            // 
            // cbNhanVien
            // 
            this.cbNhanVien.FormattingEnabled = true;
            this.cbNhanVien.Location = new System.Drawing.Point(411, 105);
            this.cbNhanVien.Name = "cbNhanVien";
            this.cbNhanVien.Size = new System.Drawing.Size(121, 24);
            this.cbNhanVien.TabIndex = 70;
            // 
            // txtGiaTri
            // 
            this.txtGiaTri.Location = new System.Drawing.Point(993, 163);
            this.txtGiaTri.Name = "txtGiaTri";
            this.txtGiaTri.Size = new System.Drawing.Size(100, 22);
            this.txtGiaTri.TabIndex = 69;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(898, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 17);
            this.label9.TabIndex = 68;
            this.label9.Text = "Giá trị đổi trả";
            // 
            // txtLyDo
            // 
            this.txtLyDo.Location = new System.Drawing.Point(712, 134);
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(100, 22);
            this.txtLyDo.TabIndex = 67;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(617, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 17);
            this.label8.TabIndex = 66;
            this.label8.Text = "Lý do đổi trả";
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.White;
            this.btnLuu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLuu.BackgroundImage")));
            this.btnLuu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.Red;
            this.btnLuu.Location = new System.Drawing.Point(1210, 207);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 44);
            this.btnLuu.TabIndex = 65;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.White;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThem.ForeColor = System.Drawing.Color.Red;
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(1210, 37);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(124, 40);
            this.btnThem.TabIndex = 62;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.White;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXoa.ForeColor = System.Drawing.Color.Red;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(1210, 93);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(124, 40);
            this.btnXoa.TabIndex = 63;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.White;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSua.ForeColor = System.Drawing.Color.Red;
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(1210, 145);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(124, 40);
            this.btnSua.TabIndex = 64;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(276, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 17);
            this.label7.TabIndex = 37;
            this.label7.Text = "Tên khách hàng";
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.FormattingEnabled = true;
            this.cbTrangThai.Items.AddRange(new object[] {
            "Đã thanh toán",
            "Chưa thanh toán"});
            this.cbTrangThai.Location = new System.Drawing.Point(993, 30);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(121, 24);
            this.cbTrangThai.TabIndex = 36;
            // 
            // dataNgayLap
            // 
            this.dataNgayLap.CustomFormat = "dd/MM/yyyy";
            this.dataNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dataNgayLap.Location = new System.Drawing.Point(352, 189);
            this.dataNgayLap.Name = "dataNgayLap";
            this.dataNgayLap.Size = new System.Drawing.Size(200, 22);
            this.dataNgayLap.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(276, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 17);
            this.label6.TabIndex = 33;
            this.label6.Text = "Tên nhân viên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 32;
            this.label5.Text = "Ngày lập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(898, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "Trạng thái";
            // 
            // txtMaDoiTra
            // 
            this.txtMaDoiTra.Location = new System.Drawing.Point(411, 27);
            this.txtMaDoiTra.Name = "txtMaDoiTra";
            this.txtMaDoiTra.Size = new System.Drawing.Size(100, 22);
            this.txtMaDoiTra.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Mã đổi trả";
            // 
            // dgvDoiTra
            // 
            this.dgvDoiTra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoiTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoiTra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgvDoiTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDoiTra.Location = new System.Drawing.Point(0, 290);
            this.dgvDoiTra.Name = "dgvDoiTra";
            this.dgvDoiTra.RowTemplate.Height = 24;
            this.dgvDoiTra.Size = new System.Drawing.Size(1428, 368);
            this.dgvDoiTra.TabIndex = 1;
            this.dgvDoiTra.SelectionChanged += new System.EventHandler(this.dgvDoiTra_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MADOITRA";
            this.Column1.HeaderText = "Mã đổi trả";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "MANV";
            this.Column2.HeaderText = "Mã nhân viên";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "MAKH";
            this.Column3.HeaderText = "Mã khách hàng";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "NGAYLAP";
            this.Column4.HeaderText = "Ngày lập";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "LYDO_DOITRA";
            this.Column5.HeaderText = "Lý do đổi trả";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "GIATRI_DOITRA";
            this.Column6.HeaderText = "Giá trị đổi trả";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "TRANGTHAI_DOITAR";
            this.Column7.HeaderText = "Trạng thái";
            this.Column7.Name = "Column7";
            // 
            // dOITRABindingSource
            // 
            this.dOITRABindingSource.DataMember = "DOITRA";
            this.dOITRABindingSource.DataSource = this.qL_NHATHUOCTAYDataSet;
            // 
            // qL_NHATHUOCTAYDataSet
            // 
            this.qL_NHATHUOCTAYDataSet.DataSetName = "QL_NHATHUOCTAYDataSet";
            this.qL_NHATHUOCTAYDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dOITRATableAdapter
            // 
            this.dOITRATableAdapter.ClearBeforeFill = true;
            // 
            // btnTK_KhachHang
            // 
            this.btnTK_KhachHang.BackColor = System.Drawing.Color.White;
            this.btnTK_KhachHang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTK_KhachHang.Image = ((System.Drawing.Image)(resources.GetObject("btnTK_KhachHang.Image")));
            this.btnTK_KhachHang.Location = new System.Drawing.Point(929, 231);
            this.btnTK_KhachHang.Name = "btnTK_KhachHang";
            this.btnTK_KhachHang.Size = new System.Drawing.Size(66, 41);
            this.btnTK_KhachHang.TabIndex = 73;
            this.btnTK_KhachHang.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(428, 231);
            this.txtTimKiem.Multiline = true;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(477, 35);
            this.txtTimKiem.TabIndex = 72;
            // 
            // frmDoiTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1428, 658);
            this.Controls.Add(this.dgvDoiTra);
            this.Controls.Add(this.panel1);
            this.Name = "frmDoiTra";
            this.Text = "ĐỔI TRẢ THUỐC";
            this.Load += new System.EventHandler(this.frmDoiTra_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoiTra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOITRABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qL_NHATHUOCTAYDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDoiTra;
        private QL_NHATHUOCTAYDataSet qL_NHATHUOCTAYDataSet;
        private System.Windows.Forms.BindingSource dOITRABindingSource;
        private QL_NHATHUOCTAYDataSetTableAdapters.DOITRATableAdapter dOITRATableAdapter;
        private System.Windows.Forms.ComboBox cbTrangThai;
        private System.Windows.Forms.DateTimePicker dataNgayLap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaDoiTra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.TextBox txtGiaTri;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbMaKH;
        private System.Windows.Forms.ComboBox cbNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Button btnTK_KhachHang;
        private System.Windows.Forms.TextBox txtTimKiem;
    }
}