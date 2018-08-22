using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLDSV
{
    public partial class rpListScoreFromClass : DevExpress.XtraReports.UI.XtraReport
    {
        public rpListScoreFromClass(string classId)
        {
            InitializeComponent();
            this.dsQLDSV1.EnforceConstraints = false;
            this.sp_InBangDiemLopTableAdapter.Fill(dsQLDSV1.sp_InBangDiemLop, classId);
        }

    }
}
