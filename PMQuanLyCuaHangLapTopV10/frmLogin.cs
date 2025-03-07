using PMQuanLyCuaHangLapTopV10.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PMQuanLyCuaHangLapTopV10
{
    public partial class frmLogin : Form
    {
        private Color originalButtonColor;
        private bool isDragging = false;        // Flag to track if the form is being dragged
        private Point offset;                // Offset from the mouse click to the form's top-left corner
        private Color originalExitButtonForeColor; // Store original exit button forcolor for hover effect
        private Color hoverExitButtonForeColor = Color.White; // Hover color for exit button


        public frmLogin()
        {
            InitializeComponent();
            originalButtonColor = btnLogin.BackColor;
            originalExitButtonForeColor = btnExit.ForeColor; // Store original exit button color

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            formFadeInTimer.Start();
            txtAcc.Focus();
        }

        private void formFadeInTimer_Tick(object sender, EventArgs e)
        {
            if (Opacity < 1)
            {
                Opacity += 0.05;
            }
            else
            {
                formFadeInTimer.Stop();
            }
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = ControlPaint.LightLight(originalButtonColor);
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = originalButtonColor;
        }

        private void checkShowPwd_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar = checkShowPwd.Checked ? '\0' : '●';
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Close the application
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.ForeColor = hoverExitButtonForeColor; // Change color on hover
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.ForeColor = originalExitButtonForeColor; // Restore original color
        }

        // --- Form Dragging Code ---

        private void pnlDragBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                offset = new Point(e.X, e.Y); // Calculate offset from top-left of the panel
            }
        }

        private void pnlDragBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point newLocation = this.PointToScreen(new Point(e.X - offset.X, e.Y - offset.Y)); // Convert panel coords to screen coords
                this.Location = newLocation; // Move the form
            }
        }

        private void pnlDragBar_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false; // Stop dragging
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ListNV listNV = new ListNV();

            if (listNV.CheckDangNhap(txtAcc.Text, txtPass.Text))
            {
                frmMain frmMain = new frmMain();
                this.Hide();
                frmMain.Show();
                MessageBox.Show("Login Success");
            }
            else 
            {
                MessageBox.Show("Login Failed");

            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}