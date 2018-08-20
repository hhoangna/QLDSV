using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace QLDSV
{
    public partial class frmMenu : Form
    {
        public string depID = "";
        public string currentClassId = "";
        public string currentClassName = "";
        public bool enable = false;

        public frmMenu()
        {
            InitializeComponent();
            getStateButton();
        }

        private void getStateButton()
        {
            btnList.Enabled = btnReport.Enabled = btnScore.Enabled = enable;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            Program.classSelected = getClassIDSelected();
            frmStudent frm = new frmStudent();
            frm.ShowDialog();
        }

        private void btnScore_Click(object sender, EventArgs e)
        {
            Program.classSelected = getClassIDSelected();
            Program.className = getClassNameSelected();
            frmScore frm = new frmScore();
            frm.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            rpListStudentFromClass rpt = new rpListStudentFromClass(getClassIDSelected());
            rpt.lblClass.Text = "Lớp: " + cbbClass.Text;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            initUIComboBoxDep();
        }

        public void initUIComboBoxDep()
        {
            cbbDep.DataSource = Program.bds;
            cbbDep.DisplayMember = "MAKH";
            cbbDep.ValueMember = "TENKH";
            cbbDep.SelectedIndex = Program.currentBranch;

            depID = Program.currentBranch == 0 ? "CNTT" : "VT";

            initUIComboBoxClass();
        }

        public void initUIComboBoxClass()
        {
            String strLenh = "exec sp_DanhSachLopTheoKhoa'" + depID + "'";
            DataTable dt = Program.ExecSqlDataTable(strLenh);
            if (dt != null)
            {
                if (dt.Rows.Count == 0)
                {
                    cbbClass.SelectedIndex = -1;
                    cbbClass.DataSource = null;
                }
                else
                {
                    cbbClass.DataSource = dt;
                    cbbClass.DisplayMember = "TENLOP";
                    cbbClass.ValueMember = "MALOP";
                }
                cbbClass.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Can not show list class", "Notification!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public String getClassIDSelected()
        {
            currentClassId = cbbClass.SelectedIndex >= 0 ? cbbClass.SelectedValue.ToString() : "";
            return currentClassId;
        }

        public String getClassNameSelected()
        {
            currentClassName = cbbClass.SelectedIndex >= 0 ? cbbClass.Text.ToString() : "";
            return currentClassName;
        }

        private void cbbDep_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbbDep.SelectedValue != null)
            {
                if (cbbDep.SelectedValue.ToString() == "System.Data.DataRowView") return;
                Program.serverName = cbbDep.SelectedValue.ToString();
                Program.currentBranch = cbbDep.SelectedIndex;
                depID = Program.currentBranch == 0 ? "CNTT" : "VT";

                if (cbbDep.SelectedIndex != Program.currentBranch)
                {
                    Program.userName = Program.remoteLogin;
                    Program.password = Program.remotePass;
                }
                else
                {
                    Program.userName = Program.currentUserName;
                    Program.password = Program.currentPass;
                }
                if (Program.Connection() == 0)
                    MessageBox.Show("Can not connect to new server", "Notification!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    initUIComboBoxClass();
                }
            }
        }

        private void cbbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            enable = cbbClass.SelectedIndex == -1 ? false : true;
            getStateButton();
        }
    }
}
