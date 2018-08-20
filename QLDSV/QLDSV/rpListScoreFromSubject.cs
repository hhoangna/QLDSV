using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLDSV
{
    public partial class rpListScoreFromSubject : DevExpress.XtraReports.UI.XtraReport
    {
        public rpListScoreFromSubject(string classId, string subjectId, int time)
        {
            InitializeComponent();
            this.dsQLDSV1.EnforceConstraints = false;
            this.sp_DanhSachDiemTableAdapter.Fill(dsQLDSV1.sp_DanhSachDiem, classId, subjectId, time);
        }

    }
}
