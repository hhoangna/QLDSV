namespace QLDSV
{
    partial class frmStudent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label mASVLabel;
            System.Windows.Forms.Label hOLabel;
            System.Windows.Forms.Label tENLabel;
            System.Windows.Forms.Label pHAILabel1;
            System.Windows.Forms.Label nGAYSINHLabel;
            System.Windows.Forms.Label nOISINHLabel;
            System.Windows.Forms.Label dIACHILabel;
            System.Windows.Forms.Label nGHIHOCLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCountry = new DevExpress.XtraEditors.TextEdit();
            this.bdsStudentFromClass = new System.Windows.Forms.BindingSource(this.components);
            this.dsQLDSV = new QLDSV.dsQLDSV();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnDel = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbClass = new System.Windows.Forms.ComboBox();
            this.cbbDep = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAbsent = new System.Windows.Forms.CheckBox();
            this.txtAddress = new DevExpress.XtraEditors.TextEdit();
            this.dpBirthday = new System.Windows.Forms.DateTimePicker();
            this.cbGender = new System.Windows.Forms.CheckBox();
            this.txtLastname = new DevExpress.XtraEditors.TextEdit();
            this.txtFistname = new DevExpress.XtraEditors.TextEdit();
            this.txtStudentId = new DevExpress.XtraEditors.TextEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sp_DanhSachSinhVienTheoLopGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.StudentId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClassId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Gender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Birthday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Country = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Absent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sp_DanhSachSinhVienTheoLopTableAdapter = new QLDSV.dsQLDSVTableAdapters.sp_DanhSachSinhVienTheoLopTableAdapter();
            this.tableAdapterManager = new QLDSV.dsQLDSVTableAdapters.TableAdapterManager();
            mASVLabel = new System.Windows.Forms.Label();
            hOLabel = new System.Windows.Forms.Label();
            tENLabel = new System.Windows.Forms.Label();
            pHAILabel1 = new System.Windows.Forms.Label();
            nGAYSINHLabel = new System.Windows.Forms.Label();
            nOISINHLabel = new System.Windows.Forms.Label();
            dIACHILabel = new System.Windows.Forms.Label();
            nGHIHOCLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCountry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStudentFromClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsQLDSV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFistname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStudentId.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sp_DanhSachSinhVienTheoLopGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // mASVLabel
            // 
            mASVLabel.AutoSize = true;
            mASVLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mASVLabel.Location = new System.Drawing.Point(266, 155);
            mASVLabel.Name = "mASVLabel";
            mASVLabel.Size = new System.Drawing.Size(93, 22);
            mASVLabel.TabIndex = 0;
            mASVLabel.Text = "Student ID";
            // 
            // hOLabel
            // 
            hOLabel.AutoSize = true;
            hOLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            hOLabel.Location = new System.Drawing.Point(96, 202);
            hOLabel.Name = "hOLabel";
            hOLabel.Size = new System.Drawing.Size(98, 22);
            hOLabel.TabIndex = 2;
            hOLabel.Text = "First Name";
            // 
            // tENLabel
            // 
            tENLabel.AutoSize = true;
            tENLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tENLabel.Location = new System.Drawing.Point(457, 202);
            tENLabel.Name = "tENLabel";
            tENLabel.Size = new System.Drawing.Size(94, 22);
            tENLabel.TabIndex = 4;
            tENLabel.Text = "Last Name";
            // 
            // pHAILabel1
            // 
            pHAILabel1.AutoSize = true;
            pHAILabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            pHAILabel1.Location = new System.Drawing.Point(733, 202);
            pHAILabel1.Name = "pHAILabel1";
            pHAILabel1.Size = new System.Drawing.Size(68, 22);
            pHAILabel1.TabIndex = 10;
            pHAILabel1.Text = "Gender";
            // 
            // nGAYSINHLabel
            // 
            nGAYSINHLabel.AutoSize = true;
            nGAYSINHLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nGAYSINHLabel.Location = new System.Drawing.Point(760, 161);
            nGAYSINHLabel.Name = "nGAYSINHLabel";
            nGAYSINHLabel.Size = new System.Drawing.Size(78, 22);
            nGAYSINHLabel.TabIndex = 11;
            nGAYSINHLabel.Text = "Birthday";
            // 
            // nOISINHLabel
            // 
            nOISINHLabel.AutoSize = true;
            nOISINHLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nOISINHLabel.Location = new System.Drawing.Point(122, 293);
            nOISINHLabel.Name = "nOISINHLabel";
            nOISINHLabel.Size = new System.Drawing.Size(72, 22);
            nOISINHLabel.TabIndex = 12;
            nOISINHLabel.Text = "Country";
            // 
            // dIACHILabel
            // 
            dIACHILabel.AutoSize = true;
            dIACHILabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dIACHILabel.Location = new System.Drawing.Point(118, 250);
            dIACHILabel.Name = "dIACHILabel";
            dIACHILabel.Size = new System.Drawing.Size(76, 22);
            dIACHILabel.TabIndex = 14;
            dIACHILabel.Text = "Address";
            // 
            // nGHIHOCLabel
            // 
            nGHIHOCLabel.AutoSize = true;
            nGHIHOCLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nGHIHOCLabel.Location = new System.Drawing.Point(917, 202);
            nGHIHOCLabel.Name = "nGHIHOCLabel";
            nGHIHOCLabel.Size = new System.Drawing.Size(65, 22);
            nGHIHOCLabel.TabIndex = 16;
            nGHIHOCLabel.Text = "Absent";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCountry);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(nOISINHLabel);
            this.groupBox1.Controls.Add(this.cbbClass);
            this.groupBox1.Controls.Add(this.cbbDep);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(nGHIHOCLabel);
            this.groupBox1.Controls.Add(this.cbAbsent);
            this.groupBox1.Controls.Add(dIACHILabel);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(nGAYSINHLabel);
            this.groupBox1.Controls.Add(this.dpBirthday);
            this.groupBox1.Controls.Add(pHAILabel1);
            this.groupBox1.Controls.Add(this.cbGender);
            this.groupBox1.Controls.Add(tENLabel);
            this.groupBox1.Controls.Add(this.txtLastname);
            this.groupBox1.Controls.Add(hOLabel);
            this.groupBox1.Controls.Add(this.txtFistname);
            this.groupBox1.Controls.Add(mASVLabel);
            this.groupBox1.Controls.Add(this.txtStudentId);
            this.groupBox1.Location = new System.Drawing.Point(0, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1196, 339);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(165, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 22);
            this.label3.TabIndex = 22;
            this.label3.Text = "Dep";
            // 
            // txtCountry
            // 
            this.txtCountry.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsStudentFromClass, "NOISINH", true));
            this.txtCountry.Location = new System.Drawing.Point(200, 290);
            this.txtCountry.MenuManager = this.barManager1;
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCountry.Properties.Appearance.Options.UseFont = true;
            this.txtCountry.Size = new System.Drawing.Size(801, 28);
            this.txtCountry.TabIndex = 13;
            // 
            // bdsStudentFromClass
            // 
            this.bdsStudentFromClass.DataMember = "sp_DanhSachSinhVienTheoLop";
            this.bdsStudentFromClass.DataSource = this.dsQLDSV;
            // 
            // dsQLDSV
            // 
            this.dsQLDSV.DataSetName = "dsQLDSV";
            this.dsQLDSV.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnNew,
            this.btnEdit,
            this.btnSave,
            this.btnDel,
            this.btnRefresh,
            this.btnCancel,
            this.btnClose});
            this.barManager1.MaxItemId = 7;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnNew, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCancel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnClose, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnNew
            // 
            this.btnNew.Caption = "New";
            this.btnNew.Glyph = global::QLDSV.Properties.Resources.icons8_plus;
            this.btnNew.Id = 0;
            this.btnNew.Name = "btnNew";
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Edit";
            this.btnEdit.Glyph = global::QLDSV.Properties.Resources.icons8_pencil;
            this.btnEdit.Id = 1;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Glyph = global::QLDSV.Properties.Resources.icons8_save;
            this.btnSave.Id = 2;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnDel
            // 
            this.btnDel.Caption = "Delete";
            this.btnDel.Glyph = global::QLDSV.Properties.Resources.icons8_trash;
            this.btnDel.Id = 3;
            this.btnDel.Name = "btnDel";
            this.btnDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDel_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Glyph = global::QLDSV.Properties.Resources.icons8_refresh;
            this.btnRefresh.Id = 4;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "Cancel";
            this.btnCancel.Glyph = global::QLDSV.Properties.Resources.icons8_cancel;
            this.btnCancel.Id = 5;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancel_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Close";
            this.btnClose.Glyph = global::QLDSV.Properties.Resources.icons8_home;
            this.btnClose.Id = 6;
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1196, 59);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 684);
            this.barDockControlBottom.Size = new System.Drawing.Size(1196, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 59);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 625);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1196, 59);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 625);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(623, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 22);
            this.label2.TabIndex = 21;
            this.label2.Text = "Class";
            // 
            // cbbClass
            // 
            this.cbbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbClass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbClass.FormattingEnabled = true;
            this.cbbClass.Location = new System.Drawing.Point(683, 90);
            this.cbbClass.Name = "cbbClass";
            this.cbbClass.Size = new System.Drawing.Size(245, 30);
            this.cbbClass.TabIndex = 20;
            this.cbbClass.SelectionChangeCommitted += new System.EventHandler(this.cbbClass_SelectionChangeCommitted);
            // 
            // cbbDep
            // 
            this.cbbDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDep.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbDep.FormattingEnabled = true;
            this.cbbDep.Location = new System.Drawing.Point(214, 90);
            this.cbbDep.Name = "cbbDep";
            this.cbbDep.Size = new System.Drawing.Size(316, 30);
            this.cbbDep.TabIndex = 19;
            this.cbbDep.SelectionChangeCommitted += new System.EventHandler(this.cbbDep_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("VNI-Jamai", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(468, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "Student Info";
            // 
            // cbAbsent
            // 
            this.cbAbsent.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bdsStudentFromClass, "NGHIHOC", true));
            this.cbAbsent.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAbsent.Location = new System.Drawing.Point(988, 202);
            this.cbAbsent.Name = "cbAbsent";
            this.cbAbsent.Size = new System.Drawing.Size(33, 24);
            this.cbAbsent.TabIndex = 17;
            this.cbAbsent.UseVisualStyleBackColor = true;
            // 
            // txtAddress
            // 
            this.txtAddress.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsStudentFromClass, "DIACHI", true));
            this.txtAddress.Location = new System.Drawing.Point(200, 247);
            this.txtAddress.MenuManager = this.barManager1;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Properties.Appearance.Options.UseFont = true;
            this.txtAddress.Size = new System.Drawing.Size(801, 28);
            this.txtAddress.TabIndex = 15;
            // 
            // dpBirthday
            // 
            this.dpBirthday.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdsStudentFromClass, "NGAYSINH", true));
            this.dpBirthday.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpBirthday.Location = new System.Drawing.Point(844, 155);
            this.dpBirthday.Name = "dpBirthday";
            this.dpBirthday.Size = new System.Drawing.Size(157, 30);
            this.dpBirthday.TabIndex = 12;
            this.dpBirthday.ValueChanged += new System.EventHandler(this.pickerBirthday_ValueChanged);
            // 
            // cbGender
            // 
            this.cbGender.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bdsStudentFromClass, "PHAI", true));
            this.cbGender.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGender.Location = new System.Drawing.Point(807, 202);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(104, 24);
            this.cbGender.TabIndex = 11;
            this.cbGender.Text = "Male";
            this.cbGender.UseVisualStyleBackColor = true;
            // 
            // txtLastname
            // 
            this.txtLastname.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsStudentFromClass, "TEN", true));
            this.txtLastname.Location = new System.Drawing.Point(554, 199);
            this.txtLastname.MenuManager = this.barManager1;
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastname.Properties.Appearance.Options.UseFont = true;
            this.txtLastname.Size = new System.Drawing.Size(141, 28);
            this.txtLastname.TabIndex = 5;
            this.txtLastname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLastName_KeyboardPressed);
            // 
            // txtFistname
            // 
            this.txtFistname.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsStudentFromClass, "HO", true));
            this.txtFistname.Location = new System.Drawing.Point(200, 199);
            this.txtFistname.MenuManager = this.barManager1;
            this.txtFistname.Name = "txtFistname";
            this.txtFistname.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFistname.Properties.Appearance.Options.UseFont = true;
            this.txtFistname.Size = new System.Drawing.Size(222, 28);
            this.txtFistname.TabIndex = 3;
            this.txtFistname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFirstName_KeyboardPressed);
            // 
            // txtStudentId
            // 
            this.txtStudentId.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsStudentFromClass, "MASV", true));
            this.txtStudentId.Location = new System.Drawing.Point(364, 152);
            this.txtStudentId.MenuManager = this.barManager1;
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentId.Properties.Appearance.Options.UseFont = true;
            this.txtStudentId.Size = new System.Drawing.Size(166, 28);
            this.txtStudentId.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.sp_DanhSachSinhVienTheoLopGridControl);
            this.groupBox2.Location = new System.Drawing.Point(0, 410);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1196, 273);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // sp_DanhSachSinhVienTheoLopGridControl
            // 
            this.sp_DanhSachSinhVienTheoLopGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sp_DanhSachSinhVienTheoLopGridControl.DataSource = this.bdsStudentFromClass;
            this.sp_DanhSachSinhVienTheoLopGridControl.Location = new System.Drawing.Point(0, 21);
            this.sp_DanhSachSinhVienTheoLopGridControl.MainView = this.gridView1;
            this.sp_DanhSachSinhVienTheoLopGridControl.Name = "sp_DanhSachSinhVienTheoLopGridControl";
            this.sp_DanhSachSinhVienTheoLopGridControl.Size = new System.Drawing.Size(1196, 302);
            this.sp_DanhSachSinhVienTheoLopGridControl.TabIndex = 0;
            this.sp_DanhSachSinhVienTheoLopGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.StudentId,
            this.FirstName,
            this.LastName,
            this.ClassId,
            this.Gender,
            this.Birthday,
            this.Country,
            this.Address,
            this.Absent});
            this.gridView1.GridControl = this.sp_DanhSachSinhVienTheoLopGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // StudentId
            // 
            this.StudentId.Caption = "Student Id";
            this.StudentId.FieldName = "MASV";
            this.StudentId.Name = "StudentId";
            this.StudentId.OptionsColumn.AllowEdit = false;
            this.StudentId.OptionsColumn.ReadOnly = true;
            this.StudentId.Visible = true;
            this.StudentId.VisibleIndex = 0;
            // 
            // FirstName
            // 
            this.FirstName.Caption = "First Name";
            this.FirstName.FieldName = "HO";
            this.FirstName.Name = "FirstName";
            this.FirstName.OptionsColumn.AllowEdit = false;
            this.FirstName.OptionsColumn.ReadOnly = true;
            this.FirstName.Visible = true;
            this.FirstName.VisibleIndex = 1;
            // 
            // LastName
            // 
            this.LastName.Caption = "Last Name";
            this.LastName.FieldName = "TEN";
            this.LastName.Name = "LastName";
            this.LastName.OptionsColumn.AllowEdit = false;
            this.LastName.OptionsColumn.ReadOnly = true;
            this.LastName.Visible = true;
            this.LastName.VisibleIndex = 2;
            // 
            // ClassId
            // 
            this.ClassId.Caption = "Class Id";
            this.ClassId.FieldName = "MALOP";
            this.ClassId.Name = "ClassId";
            this.ClassId.OptionsColumn.AllowEdit = false;
            this.ClassId.OptionsColumn.ReadOnly = true;
            this.ClassId.Visible = true;
            this.ClassId.VisibleIndex = 3;
            // 
            // Gender
            // 
            this.Gender.Caption = "Gender";
            this.Gender.FieldName = "PHAI";
            this.Gender.Name = "Gender";
            this.Gender.OptionsColumn.AllowEdit = false;
            this.Gender.OptionsColumn.ReadOnly = true;
            this.Gender.Visible = true;
            this.Gender.VisibleIndex = 4;
            // 
            // Birthday
            // 
            this.Birthday.Caption = "Birthday";
            this.Birthday.FieldName = "NGAYSINH";
            this.Birthday.Name = "Birthday";
            this.Birthday.OptionsColumn.AllowEdit = false;
            this.Birthday.OptionsColumn.ReadOnly = true;
            this.Birthday.Visible = true;
            this.Birthday.VisibleIndex = 5;
            // 
            // Country
            // 
            this.Country.Caption = "Country";
            this.Country.FieldName = "NOISINH";
            this.Country.Name = "Country";
            this.Country.OptionsColumn.AllowEdit = false;
            this.Country.OptionsColumn.ReadOnly = true;
            this.Country.Visible = true;
            this.Country.VisibleIndex = 6;
            // 
            // Address
            // 
            this.Address.Caption = "Address";
            this.Address.FieldName = "DIACHI";
            this.Address.Name = "Address";
            this.Address.OptionsColumn.AllowEdit = false;
            this.Address.OptionsColumn.ReadOnly = true;
            this.Address.Visible = true;
            this.Address.VisibleIndex = 7;
            // 
            // Absent
            // 
            this.Absent.Caption = "Absent";
            this.Absent.FieldName = "NGHIHOC";
            this.Absent.Name = "Absent";
            this.Absent.OptionsColumn.AllowEdit = false;
            this.Absent.OptionsColumn.ReadOnly = true;
            this.Absent.Visible = true;
            this.Absent.VisibleIndex = 8;
            // 
            // sp_DanhSachSinhVienTheoLopTableAdapter
            // 
            this.sp_DanhSachSinhVienTheoLopTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DIEMTableAdapter = null;
            this.tableAdapterManager.GIANGVIENTableAdapter = null;
            this.tableAdapterManager.KHOATableAdapter = null;
            this.tableAdapterManager.LOPTableAdapter = null;
            this.tableAdapterManager.MONHOCTableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.sp_DanhSachSinhVienTheoLopTableAdapter = this.sp_DanhSachSinhVienTheoLopTableAdapter;
            this.tableAdapterManager.UpdateOrder = QLDSV.dsQLDSVTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // frmStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 684);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmStudent";
            this.Text = "Student";
            this.Load += new System.EventHandler(this.frmStudent_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCountry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStudentFromClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsQLDSV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFistname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStudentId.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp_DanhSachSinhVienTheoLopGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.BindingSource bdsStudentFromClass;
        private dsQLDSV dsQLDSV;
        private dsQLDSVTableAdapters.sp_DanhSachSinhVienTheoLopTableAdapter sp_DanhSachSinhVienTheoLopTableAdapter;
        private dsQLDSVTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl sp_DanhSachSinhVienTheoLopGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn StudentId;
        private DevExpress.XtraGrid.Columns.GridColumn LastName;
        private DevExpress.XtraGrid.Columns.GridColumn FirstName;
        private DevExpress.XtraGrid.Columns.GridColumn ClassId;
        private DevExpress.XtraGrid.Columns.GridColumn Gender;
        private DevExpress.XtraGrid.Columns.GridColumn Birthday;
        private DevExpress.XtraGrid.Columns.GridColumn Country;
        private DevExpress.XtraGrid.Columns.GridColumn Address;
        private DevExpress.XtraGrid.Columns.GridColumn Absent;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnDel;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnCancel;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbClass;
        private System.Windows.Forms.ComboBox cbbDep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbAbsent;
        private DevExpress.XtraEditors.TextEdit txtAddress;
        private DevExpress.XtraEditors.TextEdit txtCountry;
        private System.Windows.Forms.DateTimePicker dpBirthday;
        private System.Windows.Forms.CheckBox cbGender;
        private DevExpress.XtraEditors.TextEdit txtLastname;
        private DevExpress.XtraEditors.TextEdit txtFistname;
        private DevExpress.XtraEditors.TextEdit txtStudentId;
    }
}