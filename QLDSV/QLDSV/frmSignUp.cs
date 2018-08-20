using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV
{
    public partial class frmSignUp : Form
    {
        String userRole = "";

        public frmSignUp()
        {
            InitializeComponent();
            txtPass.Enabled = txtPassConfirm.Enabled = txtUserID.Enabled = txtUserName.Enabled = cbbRole.Enabled = false;
            btnCreate.Enabled = false;

            if (Program.currentRole == "PGV")
            {
                cbbDep.Enabled = true;
                cbbRole.Items.Clear();
                cbbRole.Items.Add("USER");
                cbbRole.Items.Add("KHOA");
                cbbRole.Items.Add("PGV");
            }
            else
            {
                cbbDep.Enabled = false;
                cbbRole.Items.Clear();
                cbbRole.Items.Add("USER");
                cbbRole.Items.Add("KHOA");
            }
        }

        private void rbTeacher_CheckedChanged(object sender, EventArgs e)
        {
            cbbRole.Visible = true;
            txtUserName.Visible = true;
            lblROle.Visible = lblUserName.Visible = true;
            txtPass.Enabled = txtPassConfirm.Enabled = txtUserID.Enabled = txtUserName.Enabled = cbbRole.Enabled = true;
            btnCreate.Enabled = true;
            txtUserID.MaxLength = 10;
        }

        private void rbStudent_CheckedChanged(object sender, EventArgs e)
        {
            cbbRole.Visible = false;
            txtUserName.Visible = false;
            lblROle.Visible = lblUserName.Visible = false;
            txtPass.Enabled = txtPassConfirm.Enabled = txtUserID.Enabled = txtUserName.Enabled = true;
            btnCreate.Enabled = true;
            txtUserID.MaxLength = 10;
        }

        private String checkExistsAccount(String userID)
        {
            String sqlStr = "";
            if (Program.connect.State == ConnectionState.Closed)
            {
                Program.connect.Open();
            }

            sqlStr = "sp_KiemTraTaiKhoanDaDangKy";
            Program.cmd = Program.connect.CreateCommand();
            Program.cmd.CommandType = CommandType.StoredProcedure;
            Program.cmd.CommandText = sqlStr;

            Program.cmd.Parameters.Add("@TENUSER", SqlDbType.NChar).Value = userID;
            Program.cmd.Parameters.Add("@ReturnValue", SqlDbType.VarChar).Direction = ParameterDirection.ReturnValue;
            Program.cmd.ExecuteNonQuery();
            Program.connect.Close();

            String result = Program.cmd.Parameters["@ReturnValue"].Value.ToString();

            return result;
        }

        private void createAccount()
        {
            if (rbStudent.Checked)
            {
                userRole = "USER";
                txtUserName.Text = txtUserID.Text;
            }
            else
            {
                userRole = cbbRole.SelectedItem.ToString();
            }

            String checkExists = checkExistsAccount(txtUserID.Text);
            if (checkExists == "-1")
            {
                MessageBox.Show("The User ID hasn't exists!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Program.myReader.Close();
                return;
            }
            else if (checkExists == "1")
            {
                MessageBox.Show("The User ID has been registerd!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Program.myReader.Close();
                return;
            }
            else
            {
                if (txtUserID.Text.Length == 0 || txtPass.Text.Length == 0 || txtPassConfirm.Text.Length == 0)
                {
                    MessageBox.Show("Can not empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (txtPassConfirm.UseSystemPasswordChar.ToString() != txtPassConfirm.UseSystemPasswordChar.ToString())
                {
                    MessageBox.Show("Confirm password incorrect", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    try
                    {
                        String sqlStr = "";
                        sqlStr = "exec sp_TaoTaiKhoan '" + txtUserName.Text + "', '" + txtPass.Text + "', '" + txtUserID.Text + "', '" + userRole + "'";

                        Program.myReader = Program.ExecSqlDataReader(sqlStr);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();
                        MessageBox.Show("Create user successfully!", "Notification", MessageBoxButtons.OK);
                        Program.myReader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Create user failed!" + ex.Message, "Error", MessageBoxButtons.OK);
                        Program.myReader.Close();
                        return;
                    }
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            createAccount();
            txtPass.Text = "";
            txtPassConfirm.Text = "";
            txtUserID.Text = "";
            txtUserName.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbbDep_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbbDep.SelectedValue != null)
            {
                if (cbbDep.SelectedValue.ToString() == "System.Data.DataRowView") return;
                Program.serverName = cbbDep.SelectedValue.ToString();

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
            }
        }

        private void frmSignUp_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsView.viewPhanManh' table. You can move, or remove it, as needed.
            this.viewPhanManhTableAdapter.Fill(this.dsView.viewPhanManh);
            this.dsView.EnforceConstraints = false;

            cbbDep.DataSource = viewPhanManhBindingSource;
            cbbDep.DisplayMember = "MAKH";
            cbbDep.ValueMember = "TENKH";
            cbbDep.SelectedIndex = Program.currentBranch;

            this.viewPhanManhTableAdapter.Connection.ConnectionString = Program.connectStr;
        }
    }
}
