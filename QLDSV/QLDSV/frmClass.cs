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
    public partial class frmClass : Form
    {
        int index = 0;
        String depID = "";
        String currentClassID = "";
        String currentClassName = "";
        String method = Program.Method.New;

        // Stack Undo
        public Stack stUndo = new Stack();
        public Stack stRedo = new Stack();
        public ClassDto dtoUndo = new ClassDto("", "", "");
        public bool isUndo = false;
        public bool isRedo = false;


        public class ClassDto
        {
            public String strClassID;
            public String strClassName;
            public String method;
            public int index;
            public ClassDto(String depID, String depName, String strMethod)
            {
                strClassID = depID;
                strClassName = depName;
                method = strMethod;
            }
        }

        public frmClass()
        {
            InitializeComponent();
            this.bdsClass.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsQLDSV);
        }

        private void frmClass_Load(object sender, EventArgs e)
        {
            Program.connect.Close();
            dsQLDSV.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dataSetTracNghiem.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connectStr;
            this.lOPTableAdapter.Fill(this.dsQLDSV.LOP);

            cbbDep.DataSource = Program.bds;
            cbbDep.DisplayMember = "MAKH";
            cbbDep.ValueMember = "TENKH";
            cbbDep.SelectedIndex = Program.currentBranch;

            depID = Program.currentBranch == 0 ? "CNTT" : "VT";

            Program.currentBidingSource = bdsClass;

            groupBox1.Enabled = true;
            txtClassName.Enabled = txtClassName.Enabled = false;

            //setCurrentRole();
            updateUIUndo();
            if (bdsClass.Count == 0) btnDel.Enabled = false;
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
                    this.lOPTableAdapter.Connection.ConnectionString = Program.connectStr;
                    this.lOPTableAdapter.Fill(this.dsQLDSV.LOP);
                }
            }
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            index = bdsClass.Position;
            bdsClass.AddNew();
            groupBox1.Enabled = true;
            txtClassId.Enabled = txtClassName.Enabled = true;
            txtDepId.Text = depID;
            cbbDep.Enabled = false;
            groupBox2.Enabled = false;
            txtClassId.Focus();
            method = Program.Method.New;

            btnCancel.Enabled = btnSave.Enabled = true;
            btnRefresh.Enabled = btnNew.Enabled = btnEdit.Enabled = btnDel.Enabled = false;
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            index = bdsClass.Position;
            groupBox1.Enabled = true;
            txtDepId.Text = depID;
            txtClassId.Enabled = false;
            txtClassName.Enabled = true;
            cbbDep.Enabled = false;
            groupBox2.Enabled = false;
            method = Program.Method.Update;

            currentClassName = ((DataRowView)bdsClass[index])["TENLOP"].ToString();
            currentClassID = ((DataRowView)bdsClass[index])["MALOP"].ToString();

            dtoUndo.strClassID = currentClassID;
            dtoUndo.strClassName = currentClassName;

            btnCancel.Enabled = btnSave.Enabled = true;
            btnDel.Enabled = btnNew.Enabled = btnRefresh.Enabled = btnEdit.Enabled = false;
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            index = bdsClass.Position;
            method = Program.Method.Delete;
            currentClassName = ((DataRowView)bdsClass[index])["TENLOP"].ToString();
            currentClassID = ((DataRowView)bdsClass[index])["MALOP"].ToString();
            sqlDeleteMethod(currentClassID, currentClassName, method);
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (method == Program.Method.New)
            {
                sqlNewMethod(txtClassId.Text, txtClassName.Text, method);
            }
            else if (method == Program.Method.Update)
            {
                sqlUpdateMethod(txtClassId.Text, txtClassName.Text, method);
            }

            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            btnNew.Enabled = btnEdit.Enabled = btnDel.Enabled = btnRefresh.Enabled = true;
            btnSave.Enabled = btnCancel.Enabled = false;
        }

        public void sqlNewMethod(String strClassID, String strClassName, String method)
        {
            string result = checkExistData(strClassID, method, strClassName);

            if (result == "-1")
            {
                MessageBox.Show("The " + strClassID + " has already exists!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (result == "1")
            {
                MessageBox.Show("The " + strClassName + " has already exists!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (strClassID.Length == 0 || strClassName.Length == 0)
                {
                    MessageBox.Show("ClassID or ClassName can not empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    try
                    {
                        this.Validate();
                        bdsClass.EndEdit();
                        bdsClass.ResetCurrentItem();
                        this.lOPTableAdapter.Update(this.dsQLDSV.LOP);
                        if (isUndo == false)
                        {
                            ClassDto dataUndo = new ClassDto(strClassID, strClassName, method);
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

        public void sqlUpdateMethod(String strClassID, String strClassName, String method)
        {
            string result = checkExistData(strClassID, method, strClassName);

            if (result == "1")
            {
                MessageBox.Show("The " + strClassName + " has already exists!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (txtClassName.Text.Length == 0)
                {
                    MessageBox.Show("Class name can not empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    try
                    {
                        this.Validate();
                        bdsClass.EndEdit();
                        bdsClass.ResetCurrentItem();
                        this.lOPTableAdapter.Update(this.dsQLDSV.LOP);
                        if (isUndo == false)
                        {
                            ClassDto dataUndo = new ClassDto(dtoUndo.strClassID, dtoUndo.strClassName, method);
                            stUndo.Push(dataUndo);
                            updateUIUndo();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Update class failed! \n" + ex.Message, "Error", MessageBoxButtons.OK);
                        return;
                    }
                }
            }
        }

        public void sqlDeleteMethod(String strClassID, String strClassName, String method)
        {
            string result = checkExistData(strClassID, method, strClassName);

            if (result == "-1")
            {
                MessageBox.Show("Can not delete " + strClassName + " class. \nThe class has students available! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                if (MessageBox.Show("Do you want to delete " + strClassName + " class?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        bdsClass.RemoveCurrent();
                        this.lOPTableAdapter.Update(this.dsQLDSV.LOP);
                        if (isUndo == false)
                        {
                            ClassDto dataUndo = new ClassDto(strClassID, strClassName, method);
                            stUndo.Push(dataUndo);
                            updateUIUndo();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failure. Please delete again!\n" + ex.Message, "",
                            MessageBoxButtons.OK);
                        this.lOPTableAdapter.Fill(this.dsQLDSV.LOP);
                        bdsClass.Position = bdsClass.Find("MAKH", strClassID);
                        return;
                    }
                }
            }
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupBox1.Enabled = true;
            txtClassId.Enabled = txtClassName.Enabled = false;
            if (Program.currentRole == "TRUONG")
            {
                cbbDep.Enabled = true;
            }
            else
            {
                cbbDep.Enabled = false;
            }
            groupBox2.Enabled = true;
            bdsClass.MoveFirst();
            stUndo.Clear();
            stRedo.Clear();
            updateUIUndo();
            this.lOPTableAdapter.Fill(this.dsQLDSV.LOP);

            btnNew.Enabled = btnEdit.Enabled = btnDel.Enabled = btnRefresh.Enabled = true;
            btnSave.Enabled = btnCancel.Enabled = false;
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupBox1.Enabled = true;
            txtClassId.Enabled = txtClassName.Enabled = false;
            cbbDep.Enabled = true;
            groupBox2.Enabled = true;
            index = bdsClass.Position;
            bdsClass.CancelEdit();

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
            ClassDto dataUndo = (ClassDto)stUndo.Pop();
            if (dataUndo.method == Program.Method.New)
            {
                stRedo.Push(dataUndo);
                int index = getIndexDBS(dataUndo.strClassID);
                if (index >= 0)
                {
                    bdsClass.Position = index;
                    sqlDeleteMethod(dataUndo.strClassID, dataUndo.strClassName, Program.Method.Delete);
                }
            }
            else if (dataUndo.method == Program.Method.Update)
            {
                int index = getIndexDBS(dataUndo.strClassID);
                if (index >= 0)
                {
                    ClassDto dataRedo = new ClassDto(txtClassId.Text, txtClassName.Text, method);
                    stRedo.Push(dataRedo);
                    bdsClass.Position = index;
                    txtClassName.Text = dataUndo.strClassName;
                    txtClassId.Text = dataUndo.strClassID;
                    sqlUpdateMethod(dataUndo.strClassID, dataUndo.strClassName, method);
                }

            }
            else if (dataUndo.method == Program.Method.Delete)
            {
                stRedo.Push(dataUndo);
                bdsClass.AddNew();
                txtDepId.Text = depID;
                txtClassName.Text = dataUndo.strClassName;
                txtClassId.Text = dataUndo.strClassID;
                sqlNewMethod(dataUndo.strClassID, dataUndo.strClassName, Program.Method.New);
            }
            isUndo = false;
            updateUIUndo();
        }

        private void btnRedo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isRedo = isUndo = true;
            ClassDto dataRedo = (ClassDto)stRedo.Pop();
            if (dataRedo.method == Program.Method.New)
            {
                stUndo.Push(dataRedo);
                bdsClass.AddNew();
                txtDepId.Text = depID;
                txtClassName.Text = dataRedo.strClassName;
                txtClassId.Text = dataRedo.strClassID;
                sqlNewMethod(dataRedo.strClassID, dataRedo.strClassName, Program.Method.New);
            }
            else if (dataRedo.method == Program.Method.Update)
            {
                int index = getIndexDBS(dataRedo.strClassID);
                if (index >= 0)
                {
                    ClassDto dataUndo = new ClassDto(txtClassId.Text, txtClassName.Text, method);
                    stUndo.Push(dataUndo);
                    bdsClass.Position = index;
                    txtClassName.Text = dataRedo.strClassName;
                    txtClassId.Text = dataRedo.strClassID;
                    sqlUpdateMethod(dataRedo.strClassID, dataRedo.strClassName, method);
                }

            }
            else if (dataRedo.method == Program.Method.Delete)
            {
                stUndo.Push(dataRedo);
                int index = getIndexDBS(dataRedo.strClassID);
                if (index >= 0)
                {
                    bdsClass.Position = index;
                    sqlDeleteMethod(dataRedo.strClassID, dataRedo.strClassName, Program.Method.Delete);
                }
            }
            isRedo = isUndo = false;
            updateUIUndo();
        }

        private String checkExistData(string classId, string method, string className)
        {
            String sqlStr = "";

            if (Program.connect.State == ConnectionState.Closed)
            {
                Program.connect.Open();
            }
            
            sqlStr = "sp_KiemTraLop";
            Program.cmd = Program.connect.CreateCommand();
            Program.cmd.CommandType = CommandType.StoredProcedure;
            Program.cmd.CommandText = sqlStr;

            Program.cmd.Parameters.Add("@MALOP", SqlDbType.NChar).Value = classId;
            Program.cmd.Parameters.Add("@METHOD", SqlDbType.NChar).Value = method;
            Program.cmd.Parameters.Add("@TENLOP", SqlDbType.NVarChar).Value = className;
            Program.cmd.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            Program.cmd.ExecuteNonQuery();
            String result = Program.cmd.Parameters["@ReturnValue"].Value.ToString();

            Program.connect.Close();
            return result;
        }

        public int getIndexDBS(string strClassID)
        {
            for (int i = 0; i < bdsClass.Count; i++)
            {
                if (strClassID.Trim() == ((DataRowView)bdsClass[i])["MALOP"].ToString().Trim())
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
