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
    public partial class frmBanThuoc : Form
    {
        public frmBanThuoc()
        {
            InitializeComponent();
        }

        private void tHONGTINTHUOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tHONGTINTHUOCBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qL_NHATHUOCTAYDataSet);

        }

        private void frmBanThuoc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qL_NHATHUOCTAYDataSet.BANTHUOC' table. You can move, or remove it, as needed.
            this.bANTHUOCTableAdapter.Fill(this.qL_NHATHUOCTAYDataSet.BANTHUOC);
            // TODO: This line of code loads data into the 'qL_NHATHUOCTAYDataSet.THONGTINTHUOC' table. You can move, or remove it, as needed.
            this.tHONGTINTHUOCTableAdapter.Fill(this.qL_NHATHUOCTAYDataSet.THONGTINTHUOC);

        }
    }
}
