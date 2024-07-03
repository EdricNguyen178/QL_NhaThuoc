namespace QL_ThuocTay
{
    partial class frmBanThuoc
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
            this.qL_NHATHUOCTAYDataSet = new QL_ThuocTay.QL_NHATHUOCTAYDataSet();
            this.tHONGTINTHUOCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tHONGTINTHUOCTableAdapter = new QL_ThuocTay.QL_NHATHUOCTAYDataSetTableAdapters.THONGTINTHUOCTableAdapter();
            this.tableAdapterManager = new QL_ThuocTay.QL_NHATHUOCTAYDataSetTableAdapters.TableAdapterManager();
            this.bANTHUOCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bANTHUOCTableAdapter = new QL_ThuocTay.QL_NHATHUOCTAYDataSetTableAdapters.BANTHUOCTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.qL_NHATHUOCTAYDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tHONGTINTHUOCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bANTHUOCBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // qL_NHATHUOCTAYDataSet
            // 
            this.qL_NHATHUOCTAYDataSet.DataSetName = "QL_NHATHUOCTAYDataSet";
            this.qL_NHATHUOCTAYDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tHONGTINTHUOCBindingSource
            // 
            this.tHONGTINTHUOCBindingSource.DataMember = "THONGTINTHUOC";
            this.tHONGTINTHUOCBindingSource.DataSource = this.qL_NHATHUOCTAYDataSet;
            // 
            // tHONGTINTHUOCTableAdapter
            // 
            this.tHONGTINTHUOCTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BANTHUOCTableAdapter = null;
            this.tableAdapterManager.BENHTableAdapter = null;
            this.tableAdapterManager.CTHD_BANTableAdapter = null;
            this.tableAdapterManager.CTNHAPTHUOCTableAdapter = null;
            this.tableAdapterManager.DIEUTRITableAdapter = null;
            this.tableAdapterManager.DOITRATableAdapter = null;
            this.tableAdapterManager.HOADON_BANTableAdapter = null;
            this.tableAdapterManager.KHACHHANGTableAdapter = null;
            this.tableAdapterManager.NGUOIDUNGTableAdapter = null;
            this.tableAdapterManager.NHANVIENTableAdapter = null;
            this.tableAdapterManager.NHAPTHUOCTableAdapter = null;
            this.tableAdapterManager.NHASXTableAdapter = null;
            this.tableAdapterManager.NHOMTHUOCTableAdapter = null;
            this.tableAdapterManager.THONGTINTHUOCTableAdapter = this.tHONGTINTHUOCTableAdapter;
            this.tableAdapterManager.UpdateOrder = QL_ThuocTay.QL_NHATHUOCTAYDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // bANTHUOCBindingSource
            // 
            this.bANTHUOCBindingSource.DataMember = "BANTHUOC";
            this.bANTHUOCBindingSource.DataSource = this.qL_NHATHUOCTAYDataSet;
            // 
            // bANTHUOCTableAdapter
            // 
            this.bANTHUOCTableAdapter.ClearBeforeFill = true;
            // 
            // frmBanThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 398);
            this.Name = "frmBanThuoc";
            this.Text = "BÁN THUỐC";
            this.Load += new System.EventHandler(this.frmBanThuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qL_NHATHUOCTAYDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tHONGTINTHUOCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bANTHUOCBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QL_NHATHUOCTAYDataSet qL_NHATHUOCTAYDataSet;
        private System.Windows.Forms.BindingSource tHONGTINTHUOCBindingSource;
        private QL_NHATHUOCTAYDataSetTableAdapters.THONGTINTHUOCTableAdapter tHONGTINTHUOCTableAdapter;
        private QL_NHATHUOCTAYDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource bANTHUOCBindingSource;
        private QL_NHATHUOCTAYDataSetTableAdapters.BANTHUOCTableAdapter bANTHUOCTableAdapter;
    }
}