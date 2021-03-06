﻿namespace ProjectReporter.Controls
{
    partial class YanJiuGuGanEditor
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.plTitle = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLast = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnNext = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnExcelLoad = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lklDownloadFuJian = new System.Windows.Forms.LinkLabel();
            this.plContent = new System.Windows.Forms.Panel();
            this.dgvDetail = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.selpersonid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colXingMing = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn();
            this.colSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colZhiWu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCongShiZhuanYe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGongZuoDanWei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMeiNianGongZuoShiJian = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewNumericUpDownColumn();
            this.colRenWuFenGong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIDCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colXiangMuZhongZhiWu = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn();
            this.colMoveUp = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn();
            this.colMoveDown = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn();
            this.colEditThis = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.ofdExcelDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.plTitle)).BeginInit();
            this.plTitle.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.plContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // plTitle
            // 
            this.plTitle.Controls.Add(this.label1);
            this.plTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plTitle.Location = new System.Drawing.Point(54, 20);
            this.plTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.plTitle.Name = "plTitle";
            this.plTitle.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.plTitle.Size = new System.Drawing.Size(847, 30);
            this.plTitle.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F);
            this.label1.Location = new System.Drawing.Point(6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(841, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "负责人及研究骨干情况表";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 3;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel15.Controls.Add(this.tableLayoutPanel1, 1, 3);
            this.tableLayoutPanel15.Controls.Add(this.plTitle, 1, 1);
            this.tableLayoutPanel15.Controls.Add(this.plContent, 1, 2);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 5;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(955, 572);
            this.tableLayoutPanel15.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnLast, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNext, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnExcelLoad, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lklDownloadFuJian, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(53, 515);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(849, 34);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(752, 3);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(1, 25);
            this.btnLast.TabIndex = 1;
            this.btnLast.Values.Text = "返回";
            this.btnLast.Visible = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(752, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(1, 28);
            this.btnSave.TabIndex = 0;
            this.btnSave.Values.Text = "添加";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(752, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(94, 27);
            this.btnNext.TabIndex = 2;
            this.btnNext.Values.Text = "下一步";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnExcelLoad
            // 
            this.btnExcelLoad.Location = new System.Drawing.Point(652, 3);
            this.btnExcelLoad.Name = "btnExcelLoad";
            this.btnExcelLoad.Size = new System.Drawing.Size(94, 27);
            this.btnExcelLoad.TabIndex = 3;
            this.btnExcelLoad.Values.Text = "从Excel导入";
            this.btnExcelLoad.Click += new System.EventHandler(this.btnExcelLoad_Click);
            // 
            // lklDownloadFuJian
            // 
            this.lklDownloadFuJian.Dock = System.Windows.Forms.DockStyle.Right;
            this.lklDownloadFuJian.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lklDownloadFuJian.Location = new System.Drawing.Point(396, 0);
            this.lklDownloadFuJian.Name = "lklDownloadFuJian";
            this.lklDownloadFuJian.Size = new System.Drawing.Size(150, 34);
            this.lklDownloadFuJian.TabIndex = 4;
            this.lklDownloadFuJian.TabStop = true;
            this.lklDownloadFuJian.Text = "研究骨干导入模板.xls";
            this.lklDownloadFuJian.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lklDownloadFuJian.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklDownloadFuJian_LinkClicked);
            // 
            // plContent
            // 
            this.plContent.BackColor = System.Drawing.Color.Transparent;
            this.plContent.Controls.Add(this.dgvDetail);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(53, 53);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(849, 456);
            this.plContent.TabIndex = 7;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToResizeRows = false;
            this.dgvDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            this.dgvDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvDetail.ColumnHeadersHeight = 35;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selpersonid,
            this.colXingMing,
            this.colSex,
            this.colZhiWu,
            this.colCongShiZhuanYe,
            this.colGongZuoDanWei,
            this.colMeiNianGongZuoShiJian,
            this.colRenWuFenGong,
            this.colIDCard,
            this.colXiangMuZhongZhiWu,
            this.colMoveUp,
            this.colMoveDown,
            this.colEditThis,
            this.delete});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetail.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowTemplate.Height = 35;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(849, 456);
            this.dgvDetail.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvDetail.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvDetail.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvDetail.StateCommon.HeaderColumn.Content.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.dgvDetail.TabIndex = 5;
            this.dgvDetail.EditModeChanged += new System.EventHandler(this.dgvDetail_EditModeChanged);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            this.dgvDetail.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentDoubleClick);
            this.dgvDetail.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvDetail_CellParsing);
            this.dgvDetail.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvDetail_RowsAdded);
            // 
            // selpersonid
            // 
            this.selpersonid.HeaderText = "序号";
            this.selpersonid.MinimumWidth = 50;
            this.selpersonid.Name = "selpersonid";
            this.selpersonid.ReadOnly = true;
            this.selpersonid.Width = 50;
            // 
            // colXingMing
            // 
            this.colXingMing.DropDownWidth = 200;
            this.colXingMing.HeaderText = "姓名";
            this.colXingMing.MinimumWidth = 50;
            this.colXingMing.Name = "colXingMing";
            this.colXingMing.ReadOnly = true;
            this.colXingMing.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colXingMing.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colXingMing.Width = 50;
            // 
            // colSex
            // 
            this.colSex.HeaderText = "性别";
            this.colSex.MinimumWidth = 50;
            this.colSex.Name = "colSex";
            this.colSex.ReadOnly = true;
            this.colSex.Width = 50;
            // 
            // colZhiWu
            // 
            this.colZhiWu.HeaderText = "职务/职称";
            this.colZhiWu.MinimumWidth = 90;
            this.colZhiWu.Name = "colZhiWu";
            this.colZhiWu.ReadOnly = true;
            this.colZhiWu.Width = 90;
            // 
            // colCongShiZhuanYe
            // 
            this.colCongShiZhuanYe.HeaderText = "技术方向";
            this.colCongShiZhuanYe.MinimumWidth = 90;
            this.colCongShiZhuanYe.Name = "colCongShiZhuanYe";
            this.colCongShiZhuanYe.ReadOnly = true;
            this.colCongShiZhuanYe.Width = 90;
            // 
            // colGongZuoDanWei
            // 
            this.colGongZuoDanWei.HeaderText = "工作单位";
            this.colGongZuoDanWei.MinimumWidth = 90;
            this.colGongZuoDanWei.Name = "colGongZuoDanWei";
            this.colGongZuoDanWei.ReadOnly = true;
            this.colGongZuoDanWei.Width = 90;
            // 
            // colMeiNianGongZuoShiJian
            // 
            this.colMeiNianGongZuoShiJian.HeaderText = "工作时间(月)";
            this.colMeiNianGongZuoShiJian.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.colMeiNianGongZuoShiJian.MinimumWidth = 60;
            this.colMeiNianGongZuoShiJian.Name = "colMeiNianGongZuoShiJian";
            this.colMeiNianGongZuoShiJian.ReadOnly = true;
            this.colMeiNianGongZuoShiJian.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMeiNianGongZuoShiJian.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colMeiNianGongZuoShiJian.Width = 60;
            // 
            // colRenWuFenGong
            // 
            this.colRenWuFenGong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRenWuFenGong.HeaderText = "任务分工";
            this.colRenWuFenGong.MinimumWidth = 50;
            this.colRenWuFenGong.Name = "colRenWuFenGong";
            this.colRenWuFenGong.ReadOnly = true;
            this.colRenWuFenGong.Width = 101;
            // 
            // colIDCard
            // 
            this.colIDCard.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colIDCard.HeaderText = "身份证号码";
            this.colIDCard.MinimumWidth = 70;
            this.colIDCard.Name = "colIDCard";
            this.colIDCard.ReadOnly = true;
            // 
            // colXiangMuZhongZhiWu
            // 
            this.colXiangMuZhongZhiWu.DropDownWidth = 200;
            this.colXiangMuZhongZhiWu.HeaderText = "项目中职务";
            this.colXiangMuZhongZhiWu.MinimumWidth = 100;
            this.colXiangMuZhongZhiWu.Name = "colXiangMuZhongZhiWu";
            this.colXiangMuZhongZhiWu.ReadOnly = true;
            this.colXiangMuZhongZhiWu.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colXiangMuZhongZhiWu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colXiangMuZhongZhiWu.Width = 100;
            // 
            // colMoveUp
            // 
            this.colMoveUp.HeaderText = "";
            this.colMoveUp.MinimumWidth = 50;
            this.colMoveUp.Name = "colMoveUp";
            this.colMoveUp.ReadOnly = true;
            this.colMoveUp.Text = "向上";
            this.colMoveUp.Width = 50;
            // 
            // colMoveDown
            // 
            this.colMoveDown.HeaderText = "";
            this.colMoveDown.MinimumWidth = 50;
            this.colMoveDown.Name = "colMoveDown";
            this.colMoveDown.ReadOnly = true;
            this.colMoveDown.Text = "向下";
            this.colMoveDown.Width = 50;
            // 
            // colEditThis
            // 
            this.colEditThis.HeaderText = "";
            this.colEditThis.MinimumWidth = 50;
            this.colEditThis.Name = "colEditThis";
            this.colEditThis.ReadOnly = true;
            this.colEditThis.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEditThis.Text = "编辑";
            this.colEditThis.Width = 50;
            // 
            // delete
            // 
            this.delete.HeaderText = "删除";
            this.delete.Image = global::ProjectReporter.Properties.Resources.DELETE_16;
            this.delete.MinimumWidth = 45;
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delete.Width = 45;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "删除";
            this.dataGridViewImageColumn1.Image = global::ProjectReporter.Properties.Resources.DELETE_16;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 45;
            // 
            // ofdExcelDialog
            // 
            this.ofdExcelDialog.Filter = "*.xls|*.xls";
            // 
            // YanJiuGuGanEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel15);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "YanJiuGuGanEditor";
            this.Size = new System.Drawing.Size(955, 572);
            ((System.ComponentModel.ISupportInitialize)(this.plTitle)).EndInit();
            this.plTitle.ResumeLayout(false);
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.plContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel plTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnLast;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnNext;
        private System.Windows.Forms.Panel plContent;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvDetail;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnExcelLoad;
        private System.Windows.Forms.OpenFileDialog ofdExcelDialog;
        private System.Windows.Forms.LinkLabel lklDownloadFuJian;
        private System.Windows.Forms.DataGridViewTextBoxColumn selpersonid;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn colXingMing;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colZhiWu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCongShiZhuanYe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGongZuoDanWei;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewNumericUpDownColumn colMeiNianGongZuoShiJian;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRenWuFenGong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIDCard;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn colXiangMuZhongZhiWu;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn colMoveUp;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn colMoveDown;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn colEditThis;
        private System.Windows.Forms.DataGridViewImageColumn delete;
    }
}
