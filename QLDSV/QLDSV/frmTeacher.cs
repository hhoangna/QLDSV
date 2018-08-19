using System;
using System.Collections;
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
    public partial class frmTeacher : Form
    {
        int index = 0;
        String depID = "";
        String currentTeacherID = "";
        String currentFirstName = "";
        String currentLastName = "";
        String method = Program.Method.New;

        // Stack Undo
        public Stack stUndo = new Stack();
        public Stack stRedo = new Stack();
        public TeacherDto dtoUndo = new TeacherDto("", "", "", "");
        public bool isUndo = false;
        public bool isRedo = false;


        public class TeacherDto
        {
            public String strTeacherId;
            public String strFirst;
            public String strLast;
            public String method;
            public int index;
            public TeacherDto(String teacherId, String first, String last, String strMethod)
            {
                strTeacherId = teacherId;
                strFirst = first;
                strLast = last;
                method = strMethod;
            }
        }

        public frmTeacher()
        {
            InitializeComponent();
            this.bdsTeacher.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsQLDSV);
        }

        private void frmTeacher_Load(object sender, EventArgs e)
        {
            Program.connect.Close();
            dsQLDSV.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dataSetTracNghiem.LOP' table. You can move, or remove it, as needed.
            this.gIANGVIENTableAdapter.Connection.ConnectionString = Program.connectStr;
            this.gIANGVIENTableAdapter.Fill(this.dsQLDSV.GIANGVIEN);

            cbbDep.DataSource = Program.bds;
            cbbDep.DisplayMember = "MAKH";
            cbbDep.ValueMember = "TENKH";
            cbbDep.SelectedIndex = Program.currentBranch;

            depID = Program.currentBranch == 0 ? "CNTT" : "VT";

            Program.currentBidingSource = bdsTeacher;

            groupBox1.Enabled = true;
            txtTeacherId.Enabled = txtFirstName.Enabled = txtLastName.Enabled = false;

            //setCurrentRole();
            updateUIUndo();
            if (bdsTeacher.Count == 0) btnDel.Enabled = false;
        }

        public void setCurrentRole()
        {
            if (Program.currentRole == "PGV")
            {
                cbbDep.Enabled = true;
                initButtonBarManage(true);
            }
            else
            {
                cbbDep.Enabled = false;
                cbbDep.Visible = false;
                btnNew.Enabled = btnEdit.Enabled = btnDel.Enabled = btnRefresh.Enabled = true;
                btnSave.Enabled = btnCancel.Enabled = false;
            }
        }

        public void updateUIUndo()
        {
            if (stUndo.Count > 0)
            {
                btnUndo.Enabled = true;
            }
            else
            {
                btnUndo.Enabled = false;
            }

            if (stRedo.Count > 0)
            {
                btnRedo.Enabled = true;
            }
            else
            {
                btnRedo.Enabled = false;
            }
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
                    MessageBox.Show("Connect Error", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    this.gIANGVIENTableAdapter.Connection.ConnectionString = Program.connectStr;
                    this.gIANGVIENTableAdapter.Fill(this.dsQLDSV.GIANGVIEN);
                }
            }
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            index = bdsTeacher.Position;
            bdsTeacher.AddNew();
            groupBox1.Enabled = true;
            txtTeacherId.Enabled = txtFirstName.Enabled = txtLastName.Enabled = true;
            txtDepId.Text = depID;
            cbbDep.Enabled = false;
            groupBox2.Enabled = false;
            txtTeacherId.Focus();
            method = Program.Method.New;

            btnCancel.Enabled = btnSave.Enabled = true;
            btnRefresh.Enabled = btnNew.Enabled = btnEdit.Enabled = btnDel.Enabled = false;
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            index = bdsTeacher.Position;
            groupBox1.Enabled = true;
            txtDepId.Text = depID;
            txtTeacherId.Enabled = false;
            txtFirstName.Enabled = txtLastName.Enabled = true;
            cbbDep.Enabled = false;
            groupBox2.Enabled = false;
            method = Program.Method.Update;

            currentFirstName = ((DataRowView)bdsTeacher[index])["HO"].ToString();
            currentTeacherID = ((DataRowView)bdsTeacher[index])["MAGV"].ToString();
            currentLastName = ((DataRowView)bdsTeacher[index])["TEN"].ToString();

            dtoUndo.strTeacherId = currentTeacherID;
            dtoUndo.strFirst = currentFirstName;
            dtoUndo.strLast = currentLastName;

            btnCancel.Enabled = btnSave.Enabled = true;
            btnDel.Enabled = btnNew.Enabled = btnRefresh.Enabled = btnEdit.Enabled = false;
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            index = bdsTeacher.Position;
            method = Program.Method.Delete;
            currentFirstName = ((DataRowView)bdsTeacher[index])["HO"].ToString();
            currentTeacherID = ((DataRowView)bdsTeacher[index])["MAGV"].ToString();
            currentLastName = ((DataRowView)bdsTeacher[index])["TEN"].ToString();
            sqlDeleteMethod(currentTeacherID, currentFirstName, currentLastName, method);
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (method == Program.Method.New)
            {
                sqlNewMethod(txtTeacherId.Text, txtFirstName.Text, txtLastName.Text, method);
            }
            else if (method == Program.Method.Update)
            {
                sqlUpdateMethod(txtTeacherId.Text, txtFirstName.Text, txtLastName.Text, method);
            }

            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            btnNew.Enabled = btnEdit.Enabled = btnDel.Enabled = btnRefresh.Enabled = true;
            btnSave.Enabled = btnCancel.Enabled = false;
        }

        public void sqlNewMethod(String teacherID, String first, String last, String method)
        {
            string result = checkExistData(teacherID, method);

            if (result == "-1")
            {
                MessageBox.Show("The " + teacherID + " has already exists!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (teacherID.Length == 0 || first.Length == 0 || last.Length == 0)
                {
                    MessageBox.Show("Can not empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    try
                    {
                        this.Validate();
                        bdsTeacher.EndEdit();
                        bdsTeacher.ResetCurrentItem();
                        this.gIANGVIENTableAdapter.Update(this.dsQLDSV.GIANGVIEN);
                        if (isUndo == false)
                        {
                            TeacherDto dataUndo = new TeacherDto(teacherID, first, last, method);
                            stUndo.Push(dataUndo);
                            updateUIUndo();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Create class failed! \n" + ex.Message, "Error", MessageBoxButtons.OK);
                        return;
                    }
                }
            }
        }

        public void sqlUpdateMethod(String teacherID, String first, String last, String method)
        {
            if (first.Length == 0 || last.Length == 0)
            {
                MessageBox.Show("Can not empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    this.Validate();
                    bdsTeacher.EndEdit();
                    bdsTeacher.ResetCurrentItem();
                    this.gIANGVIENTableAdapter.Update(this.dsQLDSV.GIANGVIEN);
                    if (isUndo == false)
                    {
                        TeacherDto dataUndo = new TeacherDto(dtoUndo.strTeacherId, dtoUndo.strFirst, dtoUndo.strLast, method);
                        stUndo.Push(dataUndo);
                        updateUIUndo();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update teacher failed! \n" + ex.Message, "Error", MessageBoxButtons.OK);
                    return;
                }
            }
        }

        public void sqlDeleteMethod(String teacherID, String first, String last, String method)
        {
            string result = checkExistData(teacherID, method);

            if (result == "-1")
            {
                MessageBox.Show("Can not delete teacher. \nThe teacher is a VIP USER! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                if (MessageBox.Show("Do you want to delete this teacher?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        bdsTeacher.RemoveCurrent();
                        this.gIANGVIENTableAdapter.Update(this.dsQLDSV.GIANGVIEN);
                        if (isUndo == false)
                        {
                            TeacherDto dataUndo = new TeacherDto(teacherID, first, last, method);
                            stUndo.Push(dataUndo);
                            updateUIUndo();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failure. Please delete again!\n" + ex.Message, "",
                            MessageBoxButtons.OK);
                        this.gIANGVIENTableAdapter.Fill(this.dsQLDSV.GIANGVIEN);
                        bdsTeacher.Position = bdsTeacher.Find("MAKH", teacherID);
                        return;
                    }
                }
            }
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupBox1.Enabled = true;
            txtTeacherId.Enabled = txtLastName.Enabled = txtLastName.Enabled = false;
            if (Program.currentRole == "PGV")
            {
                cbbDep.Enabled = true;
            }
            else
            {
                cbbDep.Enabled = false;
            }
            groupBox2.Enabled = true;
            bdsTeacher.MoveFirst();
            stUndo.Clear();
            stRedo.Clear();
            updateUIUndo();
            this.gIANGVIENTableAdapter.Fill(this.dsQLDSV.GIANGVIEN);

            btnNew.Enabled = btnEdit.Enabled = btnDel.Enabled = btnRefresh.Enabled = true;
            btnSave.Enabled = btnCancel.Enabled = false;
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupBox1.Enabled = true;
            txtTeacherId.Enabled = txtLastName.Enabled = txtLastName.Enabled = false;
            cbbDep.Enabled = true;
            groupBox2.Enabled = true;
            index = bdsTeacher.Position;
            bdsTeacher.CancelEdit();

            setCurrentRole();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        public void initButtonBarManage(Boolean isEnable)
        {
            btnNew.Enabled = btnEdit.Enabled = btnSave.Enabled = btnRefresh.Enabled = btnDel.Enabled = btnCancel.Enabled = btnUndo.Enabled = btnRedo.Enabled = isEnable;
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isUndo = true;
            TeacherDto dataUndo = (TeacherDto)stUndo.Pop();
            if (dataUndo.method == Program.Method.New)
            {
                stRedo.Push(dataUndo);
                int index = getIndexDBS(dataUndo.strTeacherId);
                if (index >= 0)
                {
                    bdsTeacher.Position = index;
                    sqlDeleteMethod(dataUndo.strTeacherId, dataUndo.strFirst, dataUndo.strLast, Program.Method.Delete);
                }
            }
            else if (dataUndo.method == Program.Method.Update)
            {
                int index = getIndexDBS(dataUndo.strTeacherId);
                if (index >= 0)
                {
                    TeacherDto dataRedo = new TeacherDto(txtTeacherId.Text, txtFirstName.Text, txtLastName.Text, method);
                    stRedo.Push(dataRedo);
                    bdsTeacher.Position = index;
                    txtFirstName.Text = dataUndo.strFirst;
                    txtLastName.Text = dataUndo.strLast;
                    txtTeacherId.Text = dataUndo.strTeacherId;
                    sqlUpdateMethod(dataUndo.strTeacherId, dataUndo.strFirst, dataUndo.strLast, method);
                }

            }
            else if (dataUndo.method == Program.Method.Delete)
            {
                stRedo.Push(dataUndo);
                bdsTeacher.AddNew();
                txtDepId.Text = depID;
                txtFirstName.Text = dataUndo.strFirst;
                txtLastName.Text = dataUndo.strLast;
                txtTeacherId.Text = dataUndo.strTeacherId;
                sqlNewMethod(dataUndo.strTeacherId, dataUndo.strFirst, dataUndo.strLast, Program.Method.New);
            }
            isUndo = false;
            updateUIUndo();
        }

        private void btnRedo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isRedo = isUndo = true;
            TeacherDto dataRedo = (TeacherDto)stRedo.Pop();
            if (dataRedo.method == Program.Method.New)
            {
                stUndo.Push(dataRedo);
                bdsTeacher.AddNew();
                txtDepId.Text = depID;
                txtFirstName.Text = dataRedo.strFirst;
                txtLastName.Text = dataRedo.strLast;
                txtTeacherId.Text = dataRedo.strTeacherId;
                sqlNewMethod(dataRedo.strTeacherId, dataRedo.strFirst, dataRedo.strLast, Program.Method.New);
            }
            else if (dataRedo.method == Program.Method.Update)
            {
                int index = getIndexDBS(dataRedo.strTeacherId);
                if (index >= 0)
                {
                    TeacherDto dataUndo = new TeacherDto(txtTeacherId.Text, txtFirstName.Text, txtLastName.Text, method);
                    stUndo.Push(dataUndo);
                    bdsTeacher.Position = index;
                    txtFirstName.Text = dataRedo.strFirst;
                    txtLastName.Text = dataRedo.strLast;
                    txtTeacherId.Text = dataRedo.strTeacherId;
                    sqlUpdateMethod(dataRedo.strTeacherId, dataRedo.strFirst, dataRedo.strLast, method);
                }

            }
            else if (dataRedo.method == Program.Method.Delete)
            {
                stUndo.Push(dataRedo);
                int index = getIndexDBS(dataRedo.strTeacherId);
                if (index >= 0)
                {
                    bdsTeacher.Position = index;
                    sqlDeleteMethod(dataRedo.strTeacherId, dataRedo.strFirst, dataRedo.strLast, Program.Method.Delete);
                }
            }
            isRedo = isUndo = false;
            updateUIUndo();
        }

        private String checkExistData(string teacherId, string method)
        {
            String sqlStr = "";

            if (Program.connect.State == ConnectionState.Closed)
            {
                Program.connect.Open();
            }
            sqlStr = "sp_KiemTraGiangVien";
            Program.cmd = Program.connect.CreateCommand();
            Program.cmd.CommandType = CommandType.StoredProcedure;
            Program.cmd.CommandText = sqlStr;

            Program.cmd.Parameters.Add("@MAGV", SqlDbType.NChar).Value = teacherId;
            Program.cmd.Parameters.Add("@METHOD", SqlDbType.NChar).Value = method;
            Program.cmd.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            Program.cmd.ExecuteNonQuery();
            String result = Program.cmd.Parameters["@ReturnValue"].Value.ToString();

            Program.connect.Close();
            return result;
        }

        public int getIndexDBS(string strDepID)
        {
            for (int i = 0; i < bdsTeacher.Count; i++)
            {
                if (strDepID.Trim() == ((DataRowView)bdsTeacher[i])["MAGV"].ToString().Trim())
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
