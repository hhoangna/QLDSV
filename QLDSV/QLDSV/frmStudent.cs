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
        public frmStudent()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            dsQLDSV.EnforceConstraints = false;
            this.sp_DanhSachSinhVienTheoLopTableAdapter.Connection.ConnectionString = Program.connectStr;
            // TODO: This line of code loads data into the 'dataSetTracNghiem.SINHVIEN' table. You can move, or remove it, as needed.

            getDataStudentFormClassID(Program.classSelected);

            groupBox1.Enabled = true;
            txtFistname.Enabled = txtLastname.Enabled = txtAddress.Enabled = dpBirthday.Enabled
               = txtCountry.Enabled = txtStudentId.Enabled = txtAddress.Enabled = cbAbsent.Enabled = cbGender.Enabled = false;

            setCurrentRole();
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

        public bool getStateGender()
        {
            return cbGender.CheckState == CheckState.Checked ? true : false;
        }

        public bool getStateAbsent()
        {
            return cbAbsent.CheckState == CheckState.Checked ? true : false;
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
                            this.sp_DanhSachSinhVienTheoLopTableAdapter.Insert(txtStudentId.Text, txtFistname.Text, txtLastname.Text, Program.classSelected, 
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
                        getDataStudentFormClassID(Program.classSelected);
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

            groupBox2.Enabled = true;
            bdsStudentFromClass.MoveFirst();
            getDataStudentFormClassID(Program.classSelected);

            btnNew.Enabled = btnEdit.Enabled = btnRefresh.Enabled = true;
            btnSave.Enabled = btnCancel.Enabled = false;
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupBox1.Enabled = true;
            txtFistname.Enabled = txtLastname.Enabled = txtAddress.Enabled = dpBirthday.Enabled
               = txtCountry.Enabled = txtStudentId.Enabled = txtAddress.Enabled = cbAbsent.Enabled = cbGender.Enabled = false;
            bdsStudentFromClass.MoveFirst();
            getDataStudentFormClassID(Program.classSelected);
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
                initButtonBarManage(true);
            }
            else
            {
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
