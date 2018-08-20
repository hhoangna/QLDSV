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
    public partial class frmScore : Form
    {
        String subjectId = "";
        int time;
        bool enable;
        public class ScoreItem
        {
            public string studentId;
            public string name;
            public string subjectId;
            public int time;
            public double score;
            public string title;

            public ScoreItem(string title, string studentId, string name, string subjectId, int time, double score)
            {
                this.studentId = studentId;
                this.name = name;
                this.subjectId = subjectId;
                this.time = time;
                this.score = score;
                this.title = title;
            }
        }

        public List<ScoreItem> listScore;

        public frmScore()
        {
            InitializeComponent();
            listScore = new List<ScoreItem>();
        }

        private void frmScore_Load(object sender, EventArgs e)
        {
            dsQLDSV.EnforceConstraints = false;
            this.sp_DanhSachDiemTableAdapter.Connection.ConnectionString = Program.connectStr;
            // TODO: This line of code loads data into the 'dsQLDSV.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Fill(this.dsQLDSV.MONHOC);

            btnCancel.Enabled = btnSave.Enabled = btnNew.Enabled = btnChange.Enabled = groupBox2.Enabled = lbScore.Enabled = false;
            getStateButtonNew();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            txtTime.Enabled = cbbSubject.Enabled = groupBox2.Enabled = btnShow.Enabled = false;
            btnNew.Enabled = lbScore.Enabled = btnChange.Enabled = true;
            btnCancel.Enabled = btnSave.Enabled = false;
            bdsObject.CancelEdit();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtTime.Enabled = cbbSubject.Enabled = btnChange.Enabled = groupBox2.Enabled = btnShow.Enabled = false;
            btnNew.Enabled = btnChange.Enabled = lbScore.Enabled = true;
            btnCancel.Enabled = btnSave.Enabled = false;

            if (Program.connect.State == ConnectionState.Closed)
            {
                Program.connect.Open();
            }

            string sqlStr = "sp_InsertAndUpdateDiem";
            Program.cmd = Program.connect.CreateCommand();
            Program.cmd.CommandType = CommandType.StoredProcedure;
            Program.cmd.CommandText = sqlStr;

            foreach (ScoreItem score in listScore)
            {
                Program.cmd.Parameters.Clear();
                Program.cmd.Parameters.Add("@MASV", SqlDbType.NChar).Value = score.studentId;
                Program.cmd.Parameters.Add("@MAMH", SqlDbType.NChar).Value = score.subjectId;
                Program.cmd.Parameters.Add("@LAN", SqlDbType.Int).Value = score.time;
                Program.cmd.Parameters.Add("@DIEM", SqlDbType.Float).Value = score.score == 0 ? (object)DBNull.Value : score.score;

                Program.cmd.ExecuteNonQuery();
            }

            Program.connect.Close();
        }

        public void updateScore(int index, double value)
        {
            ScoreItem item = listScore[index];
            item.score = value;
            updateListData();
        }

        public void initInfo(int index)
        {
            ScoreItem item = listScore[index];
            lblStudentId.Text = item.studentId;
            lblName.Text = item.name;
            txtScore.Text = item.score == (double)0 ? "" : item.score.ToString();

        }

        public void getListScoreFromSubject(String subjectId, int time)
        {
            String strLenh = "exec sp_DanhSachDiem'" + Program.classSelected + "', '" + subjectId + "', '" + time + "'";
            DataTable dt = Program.ExecSqlDataTable(strLenh);
            if (dt != null)
            {
                int i = 1;
                foreach (DataRow dtRow in dt.Rows)
                {
                    string masv = dtRow[0].ToString();
                    string name = dtRow[1].ToString();
                    string mamh = getSubjectIdSelected();
                    int lan = getTime();
                    double diem = dtRow[2] == DBNull.Value ? (double)0 : (double)dtRow[2];
                    string title = "Question:" + i++;
                    ScoreItem item = new ScoreItem(title, masv, name, mamh, lan, diem);
                    listScore.Add(item);
                    lbScore.Items.Add(title);
                }
                updateListData();
            }
            else
            {
                MessageBox.Show("Can not show exam", "Notification!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            lbScore.SelectedIndex = -1;
        }

        public void updateListData()
        {
            lbScore.Update();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtTime.Enabled = cbbSubject.Enabled = false;
            btnNew.Enabled = btnShow.Enabled = false;
            btnChange.Enabled = false;
            btnCancel.Enabled = btnSave.Enabled = groupBox2.Enabled = true;
        }

        public String getSubjectIdSelected()
        {
            subjectId = cbbSubject.SelectedIndex >= 0 ? cbbSubject.SelectedValue.ToString() : "";
            return subjectId;
        }

        public int getTime()
        {
            time = Convert.ToInt32(txtTime.Text);
            return time;
        }

        private void getStateButtonNew()
        {
            btnShow.Enabled = enable;
        }

        private void txtTime_TextChanged(object sender, EventArgs e)
        {
            enable = txtTime.Text == "" ? false : true;
            getStateButtonNew();
        }

        private void txtScore_TextChanged(object sender, EventArgs e)
        {
            int index = lbScore.SelectedIndex;
            if (index >= 0 && txtScore.Text != "")
            {
                string valueS = txtScore.Text;
                double value = Convert.ToDouble(valueS);
                updateScore(index, value);
            }
        }

        private void lbScore_SelectedIndexChanged(object sender, EventArgs e)
        {
            initInfo(lbScore.SelectedIndex);
        }

        private void btnShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtTime.Enabled = cbbSubject.Enabled = false;
            lbScore.Enabled = btnChange.Enabled = btnNew.Enabled = true;
            btnCancel.Enabled = btnSave.Enabled = btnShow.Enabled = groupBox2.Enabled = false;
            
            getListScoreFromSubject(getSubjectIdSelected(), getTime());
            
        }

        private void btnChange_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnChange.Enabled = btnCancel.Enabled = btnSave.Enabled = btnNew.Enabled = btnChange.Enabled = groupBox2.Enabled = lbScore.Enabled = false;
            btnShow.Enabled = cbbSubject.Enabled = txtTime.Enabled = true;

            lbScore.Items.Clear();
            listScore.Clear();
        }
    }
}
