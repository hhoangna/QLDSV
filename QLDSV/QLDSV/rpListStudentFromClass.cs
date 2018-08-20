using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLDSV
{
    public partial class rpListStudentFromClass : DevExpress.XtraReports.UI.XtraReport
    {
        public rpListStudentFromClass(string classId)
        {
            InitializeComponent();
            this.dsQLDSV1.EnforceConstraints = false;
            this.sp_InDanhSachSinhVienTableAdapter.Fill(dsQLDSV1.sp_InDanhSachSinhVien, classId);
        }

    }
}
