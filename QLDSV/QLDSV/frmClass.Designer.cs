﻿namespace QLDSV
{
    partial class frmClass
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
            this.dsQLDSV = new QLDSV.dsQLDSV();
            this.lOPTableAdapter = new QLDSV.dsQLDSVTableAdapters.LOPTableAdapter();
            this.tableAdapterManager = new QLDSV.dsQLDSVTableAdapters.TableAdapterManager();
            this.bdsClass = new System.Windows.Forms.BindingSource(this.components);
            this.lOPGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ClassID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClassName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DepID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblClassId = new System.Windows.Forms.Label();
            this.lblClassName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDepId = new DevExpress.XtraEditors.TextEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnDel = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.btnRedo = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClassName = new DevExpress.XtraEditors.TextEdit();
            this.txtClassId = new DevExpress.XtraEditors.TextEdit();
            this.cbbDep = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dsQLDSV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOPGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClassName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClassId.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dsQLDSV
            // 
            this.dsQLDSV.DataSetName = "dsQLDSV";
            this.dsQLDSV.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lOPTableAdapter
            // 
            this.lOPTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DIEMTableAdapter = null;
            this.tableAdapterManager.GIANGVIENTableAdapter = null;
            this.tableAdapterManager.KHOATableAdapter = null;
            this.tableAdapterManager.LOPTableAdapter = this.lOPTableAdapter;
            this.tableAdapterManager.MONHOCTableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.sp_DanhSachSinhVienTheoLopTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QLDSV.dsQLDSVTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // bdsClass
            // 
            this.bdsClass.DataMember = "LOP";
            this.bdsClass.DataSource = this.dsQLDSV;
            // 
            // lOPGridControl
            // 
            this.lOPGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lOPGridControl.DataSource = this.bdsClass;
            this.lOPGridControl.Location = new System.Drawing.Point(0, 17);
            this.lOPGridControl.MainView = this.gridView1;
            this.lOPGridControl.Name = "lOPGridControl";
            this.lOPGridControl.Size = new System.Drawing.Size(1172, 286);
            this.lOPGridControl.TabIndex = 2;
            this.lOPGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ClassID,
            this.ClassName,
            this.DepID});
            this.gridView1.GridControl = this.lOPGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // ClassID
            // 
            this.ClassID.Caption = "ClassID";
            this.ClassID.FieldName = "MALOP";
            this.ClassID.Name = "ClassID";
            this.ClassID.OptionsColumn.AllowEdit = false;
            this.ClassID.OptionsColumn.ReadOnly = true;
            this.ClassID.Visible = true;
            this.ClassID.VisibleIndex = 0;
            // 
            // ClassName
            // 
            this.ClassName.Caption = "ClassName";
            this.ClassName.FieldName = "TENLOP";
            this.ClassName.Name = "ClassName";
            this.ClassName.OptionsColumn.AllowEdit = false;
            this.ClassName.OptionsColumn.ReadOnly = true;
            this.ClassName.Visible = true;
            this.ClassName.VisibleIndex = 1;
            // 
            // DepID
            // 
            this.DepID.Caption = "DepID";
            this.DepID.FieldName = "MAKH";
            this.DepID.Name = "DepID";
            this.DepID.OptionsColumn.AllowEdit = false;
            this.DepID.OptionsColumn.ReadOnly = true;
            this.DepID.Visible = true;
            this.DepID.VisibleIndex = 2;
            // 
            // lblClassId
            // 
            this.lblClassId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblClassId.AutoSize = true;
            this.lblClassId.Location = new System.Drawing.Point(662, 126);
            this.lblClassId.Name = "lblClassId";
            this.lblClassId.Size = new System.Drawing.Size(79, 22);
            this.lblClassId.TabIndex = 4;
            this.lblClassId.Text = "Class ID";
            // 
            // lblClassName
            // 
            this.lblClassName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblClassName.AutoSize = true;
            this.lblClassName.Location = new System.Drawing.Point(636, 164);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(105, 22);
            this.lblClassName.TabIndex = 6;
            this.lblClassName.Text = "Class Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtDepId);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblClassName);
            this.groupBox1.Controls.Add(this.txtClassName);
            this.groupBox1.Controls.Add(this.lblClassId);
            this.groupBox1.Controls.Add(this.txtClassId);
            this.groupBox1.Controls.Add(this.cbbDep);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1172, 243);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtDepId
            // 
            this.txtDepId.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsClass, "MAKH", true));
            this.txtDepId.Enabled = false;
            this.txtDepId.Location = new System.Drawing.Point(226, 174);
            this.txtDepId.MenuManager = this.barManager1;
            this.txtDepId.Name = "txtDepId";
            this.txtDepId.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepId.Properties.Appearance.Options.UseFont = true;
            this.txtDepId.Size = new System.Drawing.Size(137, 28);
            this.txtDepId.TabIndex = 9;
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
            this.btnClose,
            this.btnUndo,
            this.btnRedo});
            this.barManager1.MaxItemId = 9;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnUndo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRedo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCancel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnClose, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
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
            // btnUndo
            // 
            this.btnUndo.Caption = "Undo";
            this.btnUndo.Glyph = global::QLDSV.Properties.Resources.icons8_undo_32;
            this.btnUndo.Id = 7;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUndo_ItemClick);
            // 
            // btnRedo
            // 
            this.btnRedo.Caption = "Redo";
            this.btnRedo.Glyph = global::QLDSV.Properties.Resources.icons8_redo_32;
            this.btnRedo.Id = 8;
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRedo_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(1172, 59);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 598);
            this.barDockControlBottom.Size = new System.Drawing.Size(1172, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 59);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 539);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1172, 59);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 539);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 22);
            this.label2.TabIndex = 8;
            this.label2.Text = "Dep ID";
            // 
            // txtClassName
            // 
            this.txtClassName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtClassName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsClass, "TENLOP", true));
            this.txtClassName.Location = new System.Drawing.Point(758, 165);
            this.txtClassName.MenuManager = this.barManager1;
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClassName.Properties.Appearance.Options.UseFont = true;
            this.txtClassName.Properties.MaxLength = 50;
            this.txtClassName.Size = new System.Drawing.Size(235, 28);
            this.txtClassName.TabIndex = 7;
            // 
            // txtClassId
            // 
            this.txtClassId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtClassId.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsClass, "MALOP", true));
            this.txtClassId.Location = new System.Drawing.Point(758, 123);
            this.txtClassId.MenuManager = this.barManager1;
            this.txtClassId.Name = "txtClassId";
            this.txtClassId.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClassId.Properties.Appearance.Options.UseFont = true;
            this.txtClassId.Properties.MaxLength = 10;
            this.txtClassId.Size = new System.Drawing.Size(235, 28);
            this.txtClassId.TabIndex = 5;
            // 
            // cbbDep
            // 
            this.cbbDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDep.FormattingEnabled = true;
            this.cbbDep.Location = new System.Drawing.Point(101, 118);
            this.cbbDep.Name = "cbbDep";
            this.cbbDep.Size = new System.Drawing.Size(325, 30);
            this.cbbDep.TabIndex = 3;
            this.cbbDep.SelectionChangeCommitted += new System.EventHandler(this.cbbDep_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("VNI-Jamai", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(144, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 55);
            this.label1.TabIndex = 2;
            this.label1.Text = "Class Info";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lOPGridControl);
            this.groupBox2.Location = new System.Drawing.Point(0, 297);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1172, 289);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // frmClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1172, 598);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmClass";
            this.Text = "Class";
            this.Load += new System.EventHandler(this.frmClass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsQLDSV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOPGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClassName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClassId.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private dsQLDSV dsQLDSV;
        private System.Windows.Forms.BindingSource bdsClass;
        private dsQLDSVTableAdapters.LOPTableAdapter lOPTableAdapter;
        private dsQLDSVTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl lOPGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbDep;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnDel;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnCancel;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.BarButtonItem btnUndo;
        private DevExpress.XtraBars.BarButtonItem btnRedo;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.TextEdit txtClassName;
        private DevExpress.XtraEditors.TextEdit txtClassId;
        private System.Windows.Forms.Label lblClassId;
        private System.Windows.Forms.Label lblClassName;
        private DevExpress.XtraGrid.Columns.GridColumn ClassID;
        private DevExpress.XtraGrid.Columns.GridColumn ClassName;
        private DevExpress.XtraGrid.Columns.GridColumn DepID;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtDepId;
    }
}