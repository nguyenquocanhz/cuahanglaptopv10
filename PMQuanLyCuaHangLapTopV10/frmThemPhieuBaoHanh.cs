using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQuanLyCuaHangLapTopV10
{
    public partial class frmThemPhieuBaoHanh : Form
    {
        public frmThemPhieuBaoHanh()
        {
            InitializeComponent();
            Button btn = new Button();
            this.Controls.Add(btn);

            btn.Text = "Click Me";
            btn.Location = new Point(10, 10);
            btn.Click += new EventHandler(btn_Click);
        }
        private void btn_Click(object sender, EventArgs e)
        {
            // Handle button click event
            MessageBox.Show("Button clicked!");
        }
    }
}
