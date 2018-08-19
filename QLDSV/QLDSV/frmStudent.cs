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
    public partial class frmStudent : Form
    {
        int index;
        String method = "";
        String currentStudentID = "";
        String classID = "";
        String depID = "";
        public frmStudent()
        {
            InitializeComponent();
        }


        private void frmStudent_Load(object sender, EventArgs e)
        {
            dsQLDSV.EnforceConstraints = false;
            this.sp_DanhSachSinhVienTheoLopTableAdapter.Connection.ConnectionString = Program.connectStr;
            // TODO: This line of code loads data into the 'dataSetTracNghiem.SINHVIEN' table. You can move, or remove it, as needed.

            initUIComboBoxDep();

            groupBox1.Enabled = true;
            txtFistname.Enabled = txtLastname.Enabled = txtAddress.Enabled = dpBirthday.Enabled
               = txtCountry.Enabled = txtStudentId.Enabled = txtAddress.Enabled = cbAbsent.Enabled = cbGender.Enabled = false;

            setCurrentRole();
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

        public void getDataStudentFormClassID(String classID)
        {
            try
            {
                this.sp_DanhSachSinhVienTheoLopTableAdapter.Fill(this.dsQLDSV.sp_DanhSachSinhVienTheoLop, classID);
                this.sp_DanhSachSinhVienTheoLopTableAdapter.ClearBeforeFill = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            setCurrentRole();
        }

        public String getClassIDSelected()
        {
            classID = cbbClass.SelectedIndex >= 0 ? cbbClass.SelectedValue.ToString() : "";
            return classID;
        }

        public bool getStateGender()
        {
            return cbGender.CheckState == CheckState.Checked ? true : false;
        }

        public bool getStateAbsent()
        {
            return cbAbsent.CheckState == CheckState.Checked ? true : false;
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

        private void cbbClass_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getDataStudentFormClassID(getClassIDSelected());
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            index = bdsStudentFromClass.Position;
            groupBox1.Enabled = true;
            bdsStudentFromClass.AddNew();
            txtStudentId.Enabled = txtFistname.Enabled = txtLastname.Enabled = txtAddress.Enabled = dpBirthday.Enabled = txtCountry.Enabled = true;
            cbAbsent.Enabled = cbGender.Enabled = true;
            dpBirthday.Format = DateTimePickerFormat.Custom;
            dpBirthday.CustomFormat = " ";
            cbbDep.Enabled = false;
            cbbClass.Enabled = false;
            groupBox2.Enabled = false;
            txtStudentId.Focus();
            method = Program.Method.New;

            btnCancel.Enabled = btnSave.Enabled = true;
            btnRefresh.Enabled = btnNew.Enabled = btnEdit.Enabled = btnDel.Enabled = false;
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            index = bdsStudentFromClass.Position;
            groupBox1.Enabled = true;
            txtStudentId.Enabled = false;
            txtFistname.Enabled = txtLastname.Enabled = txtAddress.Enabled = dpBirthday.Enabled = txtCountry.Enabled = true;
            cbAbsent.Enabled = cbGender.Enabled = true;
            cbbDep.Enabled = false;
            cbbClass.Enabled = false;
            groupBox2.Enabled = false;
            method = Program.Method.Update;

            btnCancel.Enabled = btnSave.Enabled = true;
            btnDel.Enabled = btnNew.Enabled = btnRefresh.Enabled = btnEdit.Enabled = false;
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsStudentFromClass.Count != 1)
            {
                currentStudentID = ((DataRowView)bdsStudentFromClass[index])["MASV"].ToString();
            }
            String sqlStr = checkExistData(txtStudentId.Text.Trim(), method);

            if (method == Program.Method.New)
            {
                if (sqlStr == "-1")
                {
                    MessageBox.Show("The " + txtStudentId.Text + " has already exists!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (txtStudentId.Text.Length == 0 || txtFistname.Text.Length == 0 || txtLastname.Text.Length == 0)
                    {
                        MessageBox.Show("Student ID or Name can not empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        try
                        {
                            this.Validate();
                            bdsStudentFromClass.EndEdit();
                            bdsStudentFromClass.ResetCurrentItem();
                            this.sp_DanhSachSinhVienTheoLopTableAdapter.Insert(txtStudentId.Text, txtFistname.Text, txtLastname.Text, getClassIDSelected(), 
                                getStateGender(), dpBirthday.Value.Date, txtCountry.Text, txtAddress.Text, getStateAbsent());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Create student failed! \n" + ex.Message, "Error", MessageBoxButtons.OK);
                            Program.myReader.Close();
                            return;
                        }
                    }
                    Program.myReader.Close();
                }
            }
            else if (method == Program.Method.Update)
            {
                if (txtFistname.Text.Length == 0)
                {
                    MessageBox.Show("Last Name can not empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (txtLastname.Text.Length == 0)
                {
                    MessageBox.Show("First Name can not empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    try
                    {
                        this.Validate();
                        bdsStudentFromClass.EndEdit();
                        bdsStudentFromClass.ResetCurrentItem();
                        this.sp_DanhSachSinhVienTheoLopTableAdapter.Update(txtStudentId.Text, txtFistname.Text, txtLastname.Text, getStateGender(), dpBirthday.Value.Date, txtCountry.Text, txtAddress.Text, getStateAbsent());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Update student failed! \n" + ex.Message, "Error", MessageBoxButtons.OK);
                        Program.myReader.Close();
                        return;
                    }
                }
                Program.myReader.Close();
            }
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            txtFistname.Enabled = txtLastname.Enabled = txtAddress.Enabled = dpBirthday.Enabled
               = txtCountry.Enabled = txtStudentId.Enabled = txtAddress.Enabled = cbAbsent.Enabled = cbGender.Enabled = false;
            btnNew.Enabled = btnEdit.Enabled = btnDel.Enabled = btnRefresh.Enabled = true;
            btnSave.Enabled = btnCancel.Enabled = false;
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            index = bdsStudentFromClass.Position;
            method = Program.Method.Delete;
            currentStudentID = ((DataRowView)bdsStudentFromClass[index])["MASV"].ToString();

            String sqlStr = checkExistData(currentStudentID, method);

            if (sqlStr == "-1")
            {
                MessageBox.Show("Can not delete this student. \nThe student has data available! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (MessageBox.Show("Do you want to delete this student?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        bdsStudentFromClass.RemoveCurrent();
                        this.sp_DanhSachSinhVienTheoLopTableAdapter.Delete(currentStudentID);
                        if (bdsStudentFromClass.Count == 0)
                        {
                            btnDel.Enabled = false;
                            btnEdit.Enabled = false;
                            btnRefresh.Enabled = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failure. Please delete again!\n" + ex.Message, "",
                           MessageBoxButtons.OK);
                        getDataStudentFormClassID(getClassIDSelected());
                        bdsStudentFromClass.Position = bdsStudentFromClass.Find("MASV", currentStudentID);
                        return;
                    }
                }
            }
            Program.myReader.Close();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupBox1.Enabled = true;
            txtFistname.Enabled = txtLastname.Enabled = txtAddress.Enabled = dpBirthday.Enabled
               = txtCountry.Enabled = txtStudentId.Enabled = txtAddress.Enabled = cbAbsent.Enabled = cbGender.Enabled = false;

            if (bdsStudentFromClass.Count == 0) btnDel.Enabled = false;
            else btnDel.Enabled = true;

            if (Program.currentRole == "PGV")
            {
                cbbDep.Enabled = true;
                cbbClass.Enabled = true;
            }
            else
            {
                cbbDep.Enabled = false;
                cbbClass.Enabled = true;
            }
            groupBox2.Enabled = true;
            bdsStudentFromClass.MoveFirst();
            getDataStudentFormClassID(getClassIDSelected());

            btnNew.Enabled = btnEdit.Enabled = btnRefresh.Enabled = true;
            btnSave.Enabled = btnCancel.Enabled = false;
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupBox1.Enabled = true;
            txtFistname.Enabled = txtLastname.Enabled = txtAddress.Enabled = dpBirthday.Enabled
               = txtCountry.Enabled = txtStudentId.Enabled = txtAddress.Enabled = cbAbsent.Enabled = cbGender.Enabled = false;
            bdsStudentFromClass.MoveFirst();
            getDataStudentFormClassID(getClassIDSelected());
            groupBox2.Enabled = true;

            setCurrentRole();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        public void setCurrentRole()
        {
            if (Program.currentRole == "PGV")
            {
                cbbDep.Enabled = true;
                cbbClass.Enabled = true;
                initButtonBarManage(true);
            }
            else
            {
                cbbDep.Enabled = false;
                cbbClass.Enabled = true;
                btnNew.Enabled = btnEdit.Enabled = btnRefresh.Enabled = true;
                btnSave.Enabled = btnCancel.Enabled = false;

                if (bdsStudentFromClass.Count == 0)
                {
                    btnDel.Enabled = btnEdit.Enabled = btnRefresh.Enabled = false;
                }
                else
                {
                    btnDel.Enabled = btnEdit.Enabled = btnRefresh.Enabled = true;
                }
            }
        }

        public void initButtonBarManage(Boolean isEnable)
        {
            btnNew.Enabled = btnEdit.Enabled = btnSave.Enabled = btnRefresh.Enabled = btnDel.Enabled = btnCancel.Enabled = isEnable;
        }

        private void txtFirstName_KeyboardPressed(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLastName_KeyboardPressed(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void pickerBirthday_ValueChanged(object sender, EventArgs e)
        {
            dpBirthday.Format = DateTimePickerFormat.Short;
            dpBirthday.CustomFormat = "yyyy-MM-dd";
        }

        private String checkExistData(string studentId, string method)
        {
            String sqlStr = "";

            if (Program.connect.State == ConnectionState.Closed)
            {
                Program.connect.Open();
            }

            sqlStr = "sp_KiemTraSinhVien";
            Program.cmd = Program.connect.CreateCommand();
            Program.cmd.CommandType = CommandType.StoredProcedure;
            Program.cmd.CommandText = sqlStr;

            Program.cmd.Parameters.Add("@MASV", SqlDbType.NChar).Value = studentId;
            Program.cmd.Parameters.Add("@METHOD", SqlDbType.NChar).Value = method;
            Program.cmd.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            Program.cmd.ExecuteNonQuery();
            String result = Program.cmd.Parameters["@ReturnValue"].Value.ToString();

            Program.connect.Close();
            return result;
        }

        //private void txtSearch_TextChanged(object sender, EventArgs e)
        //{
        //    bdsStudentFromClass.Filter = "MASV LIKE '%" + this.txtSearch.Text + "%'" + " OR TEN LIKE '%" + this.txtSearch.Text + "%'";
        //}

        //private void checkBoxSearch_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBoxSearch.Checked == true)
        //    {
        //        txtSearch.Text = "";
        //        getDataStudentFormClassID("");
        //        cbbBranch.SelectedIndex = -1;
        //        cbbClass.SelectedIndex = -1;
        //        cbbClass.Enabled = false;
        //        cbbBranch.Enabled = false;
        //    }
        //    else
        //    {
        //        txtSearch.Text = "";
        //        cbbClass.Enabled = true;
        //        cbbBranch.Enabled = true;
        //    }
        //}
    }
}
