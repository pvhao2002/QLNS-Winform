using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class frmMain : Form
    {
        frmEmployee frmEmpl;
        frmDepartment frmDepart;
        frmContract frmContract;
        frmRewardDiscipline frmRewardDiscipline;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmEmpl = new frmEmployee();
            frmEmpl.TopLevel = false;
            pnMain.Controls.Add(frmEmpl);
            frmEmpl.Dock = DockStyle.Fill;
            frmEmpl.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnContract_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmContract = new frmContract();
            frmContract.TopLevel = false;
            pnMain.Controls.Add(frmContract);
            frmContract.Dock = DockStyle.Fill;
            frmContract.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnManaDepartment_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmDepart = new frmDepartment();
            frmDepart.TopLevel = false;
            pnMain.Controls.Add(frmDepart);
            frmDepart.Dock = DockStyle.Fill;
            frmDepart.Show();
        }

        private void btnManaEmp_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmEmpl = new frmEmployee();
            frmEmpl.TopLevel = false;
            pnMain.Controls.Add(frmEmpl);
            frmEmpl.Dock = DockStyle.Fill;
            frmEmpl.Show();
        }

        private void btnReward_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmRewardDiscipline = new frmRewardDiscipline();
            frmRewardDiscipline.TopLevel = false;
            pnMain.Controls.Add(frmRewardDiscipline);
            frmRewardDiscipline.Dock = DockStyle.Fill;
            frmRewardDiscipline.Show();
        }
    }
}
