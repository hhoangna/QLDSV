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
    public partial class frmSubject : Form
    {
        int index;
        String currentSubName = "";
        String currentSubID = "";
        string method = Program.Method.New;

        public frmSubject()
        {
            InitializeComponent();
        }

        private void mONHOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsSubject.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsQLDSV);

        }

        private void frmSubject_Load(object sender, EventArgs e)
        {
            dsQLDSV.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dsQLDSV.DIEM' table. You can move, or remove it, as needed.
            this.dIEMTableAdapter.Fill(this.dsQLDSV.DIEM);
            // TODO: This line of code loads data into the 'dsQLDSV.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Fill(this.dsQLDSV.MONHOC);

        }

        public void setCurrentRole()
        {
            if (Program.currentRole == "TRUONG")
            {
                initButtonBarManage(false);
            }
            else
            {
                btnNew.Enabled = btnEdit.Enabled = btnRefresh.Enabled = true;
                btnSave.Enabled = btnCancel.Enabled = false;

                if (bdsSubject.Count == 0)
                {
                    btnDel.Enabled = btnEdit.Enabled = btnRefresh.Enabled = false;
                }
                else
                {
                    btnDel.Enabled = btnEdit.Enabled = btnRefresh.Enabled = true;
                }
            }
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            index = bdsSubject.Position;
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            method = Program.Method.Update;

            btnCancel.Enabled = btnSave.Enabled = true;
            btnDel.Enabled = btnNew.Enabled = btnRefresh.Enabled = btnEdit.Enabled = false;
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            index = bdsSubject.Position;
            groupBox1.Enabled = true;
            bdsSubject.AddNew();
            groupBox2.Enabled = false;
            method = Program.Method.New;
            txtSubID.Focus();

            btnCancel.Enabled = btnSave.Enabled = true;
            btnRefresh.Enabled = btnNew.Enabled = btnEdit.Enabled = btnDel.Enabled = false;
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtSubID.Text.Length == 0 || txtSubName.Text.Length == 0)
            {
                MessageBox.Show("Subjects ID or Subject Name can not empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (checkExistData(txtSubID.Text.Trim(), method, txtSubName.Text.Trim()) == "-1")
            {
                MessageBox.Show("SubjectID already exists!", "Error", MessageBoxButtons.OK);
                return;
            }
            else if (checkExistData(txtSubID.Text.Trim(), method, txtSubName.Text.Trim()) == "1")
            {
                MessageBox.Show("SubjectName already exists!", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                try
                {
                    this.Validate();
                    bdsSubject.EndEdit();
                    bdsSubject.ResetCurrentItem();
                    this.mONHOCTableAdapter.Update(this.dsQLDSV.MONHOC);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update subjects failed! \n" + ex.Message, "Error", MessageBoxButtons.OK);
                    return;
                }
            }

            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            btnNew.Enabled = btnEdit.Enabled = btnDel.Enabled = btnRefresh.Enabled = true;
            btnSave.Enabled = btnCancel.Enabled = false;
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            index = bdsSubject.Position;
            bdsSubject.CancelEdit();

            btnNew.Enabled = btnEdit.Enabled = btnDel.Enabled = btnRefresh.Enabled = true;
            btnSave.Enabled = btnCancel.Enabled = false;
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            bdsSubject.MoveFirst();
            this.mONHOCTableAdapter.Fill(this.dsQLDSV.MONHOC);

            btnNew.Enabled = btnEdit.Enabled = btnDel.Enabled = btnRefresh.Enabled = true;
            btnSave.Enabled = btnCancel.Enabled = false;
        }

        private String checkExistData(String subId, string method, string subName)
        {
            String sqlStr = "";
            if (Program.connect.State == ConnectionState.Closed)
            {
                Program.connect.Open();
            }
            sqlStr = "sp_KiemTraMonHoc";
            Program.cmd = Program.connect.CreateCommand();
            Program.cmd.CommandType = CommandType.StoredProcedure;
            Program.cmd.CommandText = sqlStr;

            Program.cmd.Parameters.Add("@MAMH", SqlDbType.NChar).Value = subId;
            Program.cmd.Parameters.Add("@METHOD", SqlDbType.NChar).Value = method;
            Program.cmd.Parameters.Add("@TENMH", SqlDbType.NVarChar).Value = subName;
            Program.cmd.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            Program.cmd.ExecuteNonQuery();
            String result = Program.cmd.Parameters["@ReturnValue"].Value.ToString();

            Program.connect.Close();
            return result;
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            index = bdsSubject.Position;

            currentSubName = ((DataRowView)bdsSubject[index])["TENMH"].ToString();
            currentSubID = ((DataRowView)bdsSubject[index])["MAMH"].ToString();
            method = Program.Method.Delete;

            String check = checkExistData(currentSubID, method, currentSubName);

            if (check == "-1" || bdsScore.Count > 0)
            {
                MessageBox.Show("Can not delete " + currentSubName + " subject. \nThe subject has data available! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (MessageBox.Show("Do you want to delete " + currentSubName + " subject?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bdsSubject.RemoveCurrent();
                    this.mONHOCTableAdapter.Update(this.dsQLDSV.MONHOC);
                    if (bdsSubject.Count == 0)
                    {
                        btnCancel.Enabled = btnDel.Enabled = btnEdit.Enabled = btnRefresh.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failure. Please delete again!\n" + ex.Message, "",
                        MessageBoxButtons.OK);
                    this.mONHOCTableAdapter.Fill(this.dsQLDSV.MONHOC);
                    bdsSubject.Position = bdsSubject.Find("MAMH", currentSubID);
                    return;
                }
            }
            if (bdsSubject.Count == 0) btnDel.Enabled = false;
        }
        public void initButtonBarManage(Boolean isEnable)
        {
            btnNew.Enabled = btnEdit.Enabled = btnSave.Enabled = btnRefresh.Enabled = btnDel.Enabled = btnCancel.Enabled = isEnable;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bdsSubject.Filter = "MAMH LIKE '%" + this.txtSearch.Text + "%'" + " OR TENMH LIKE '%" + this.txtSearch.Text + "%'";
        }

        private void Max_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }
    }
}
