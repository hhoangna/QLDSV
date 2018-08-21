using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLDSV
{
    public partial class rpScoreFromStudent : DevExpress.XtraReports.UI.XtraReport
    {
        public rpScoreFromStudent(string studentId)
        {
            InitializeComponent();
            this.dsQLDSV1.EnforceConstraints = false;
            this.sp_InPhieuDiemCaNhanTableAdapter.Fill(dsQLDSV1.sp_InPhieuDiemCaNhan, studentId);
        }

    }
}
