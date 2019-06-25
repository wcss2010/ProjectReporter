﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ComponentFactory.Krypton.Toolkit;
using ProjectReporter.DB.Entitys;
using ProjectReporter.DB;
using System.Diagnostics;

namespace ProjectReporter.Controls
{
    public partial class BaoMiZiZhiFuYinJianEditor : BaseEditor
    {
        public BaoMiZiZhiFuYinJianEditor()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OnSaveEvent();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            OnLastEvent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            OnNextEvent();
        }

        public override void ClearView()
        {
            base.ClearView();

            dgvDetail.Rows.Clear();
        }

        public override void RefreshView()
        {
            base.RefreshView();

            dgvDetail.Rows.Clear();
            List<ExtFileList> list = ConnectionManager.Context.table("ExtFileList").where("ProjectID='" + MainForm.Instance.ProjectObj.ID + "'").select("*").getList<ExtFileList>(new ExtFileList());
            int index = 0;
            foreach (ExtFileList efl in list)
            {
                index++;
                List<object> cells = new List<object>();
                cells.Add(index.ToString());
                cells.Add(efl.ExtName);
                cells.Add(efl.SourceFileName);
                cells.Add(efl.IsIgnore == 1 ? true : false);

                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = efl;
                dgvDetail.Rows[rowIndex].Cells[2].Tag = "uploaded";
            }
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
            {
                if (dgvRow.Cells[1].Value == null || string.IsNullOrEmpty(dgvRow.Cells[1].Value.ToString()))
                {
                    MessageBox.Show("对不起,请输入单位名称!");
                    break; ;
                }

                if (dgvRow.Tag != null)
                {
                    //修改
                    ExtFileList efl = (ExtFileList)dgvRow.Tag;

                    //检查是否修改过
                    if (dgvRow.Cells[2].Tag != null)
                    {
                        string sourceFile = dgvRow.Cells[2].Tag.ToString();
                        string realFileName = DateTime.Now.Ticks + "___" + Path.GetFileName(sourceFile);
                        string destFile = Path.Combine(MainForm.ProjectFilesDir, realFileName);
                        if (File.Exists(sourceFile))
                        {
                            //旧地址
                            string oldFile = Path.Combine(MainForm.ProjectFilesDir, efl.RealFileName);
                            try
                            {
                                File.Delete(oldFile);
                            }
                            catch (Exception ex) { }

                            //复制新地址
                            File.Copy(sourceFile, destFile, true);

                            //源文件
                            efl.SourceFileName = Path.GetFileName(sourceFile);

                            //真实文件名称
                            efl.RealFileName = realFileName;

                            //是否为军队单位
                            efl.IsIgnore = ((bool)dgvRow.Cells[3].Value) ? 1 : 0;

                            //单位名称
                            efl.ExtName = dgvRow.Cells[1].Value.ToString();

                            //更新数据
                            efl.copyTo(ConnectionManager.Context.table("ExtFileList")).where("ID='" + efl.ID + "'").update();
                        }
                        else
                        {
                            //是否为军队单位
                            efl.IsIgnore = ((bool)dgvRow.Cells[3].Value) ? 1 : 0;

                            //单位名称
                            efl.ExtName = dgvRow.Cells[1].Value.ToString();

                            //更新数据
                            efl.copyTo(ConnectionManager.Context.table("ExtFileList")).where("ID='" + efl.ID + "'").update();
                        }
                    }
                    else
                    {
                        //是否为军队单位
                        efl.IsIgnore = ((bool)dgvRow.Cells[3].Value) ? 1 : 0;

                        //单位名称
                        efl.ExtName = dgvRow.Cells[1].Value.ToString();

                        //源文件名
                        efl.SourceFileName = string.Empty;

                        //真实文件名
                        efl.RealFileName = string.Empty;

                        //更新数据
                        efl.copyTo(ConnectionManager.Context.table("ExtFileList")).where("ID='" + efl.ID + "'").update();
                    }
                }
                else
                {
                    //增加
                    if (dgvRow.Cells[2].Tag != null)
                    {
                        string sourceFile = dgvRow.Cells[2].Tag.ToString();
                        string realFileName = DateTime.Now.Ticks + "___" + Path.GetFileName(sourceFile);
                        string destFile = Path.Combine(MainForm.ProjectFilesDir, realFileName);
                        if (File.Exists(sourceFile))
                        {
                            //复制新地址
                            File.Copy(sourceFile, destFile, true);

                            ExtFileList efll = new ExtFileList();
                            efll.ID = Guid.NewGuid().ToString();
                            efll.ProjectID = MainForm.Instance.ProjectObj.ID;
                            efll.ExtName = dgvRow.Cells[1].Value.ToString();
                            efll.SourceFileName = Path.GetFileName(sourceFile);
                            efll.RealFileName = realFileName;
                            efll.IsIgnore = ((bool)dgvRow.Cells[3].Value) ? 1 : 0;
                            efll.copyTo(ConnectionManager.Context.table("ExtFileList")).insert();
                        }
                    }
                    else
                    {
                        ExtFileList efll = new ExtFileList();
                        efll.ID = Guid.NewGuid().ToString();
                        efll.ProjectID = MainForm.Instance.ProjectObj.ID;
                        efll.ExtName = dgvRow.Cells[1].Value.ToString();
                        efll.SourceFileName = string.Empty;
                        efll.RealFileName = string.Empty;
                        efll.IsIgnore = ((bool)dgvRow.Cells[3].Value) ? 1 : 0;
                        efll.copyTo(ConnectionManager.Context.table("ExtFileList")).insert();
                    }
                }
            }

            //刷新数据
            RefreshView();
        }

        public override bool IsInputCompleted()
        {
            if (dgvDetail.Rows.Count == 0)
            {
                MessageBox.Show("对不起,请上传保密资质!");
            }
            return dgvDetail.Rows.Count >= 1;
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1)
            {
                if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                {
                    if (dgvDetail.Rows[e.RowIndex].Tag != null)
                    {
                        ExtFileList task = (ExtFileList)dgvDetail.Rows[e.RowIndex].Tag;
                        if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                File.Delete(Path.Combine(MainForm.ProjectFilesDir, task.RealFileName));
                            }
                            catch (Exception ex) { }

                            ConnectionManager.Context.table("ExtFileList").where("ID='" + task.ID + "'").delete();
                            RefreshView();
                        }
                    }
                    else
                    {
                        if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                        {
                            if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                try
                                {
                                    dgvDetail.Rows.RemoveAt(e.RowIndex);
                                }
                                catch (Exception ex)
                                {
                                    RefreshView();
                                }
                            }
                        }
                    }
                }
                else if (e.ColumnIndex == dgvDetail.Columns.Count - 2)
                {
                    if (ofdUpload.ShowDialog() == DialogResult.OK)
                    {
                        dgvDetail.Rows[e.RowIndex].Cells[2].Tag = ofdUpload.FileName;
                        dgvDetail.Rows[e.RowIndex].Cells[2].Value = Path.GetFileName(ofdUpload.FileName);
                    }
                }
                else if (e.ColumnIndex == 2)
                {
                    if (dgvDetail.Rows[e.RowIndex].Tag != null)
                    {
                        ExtFileList task = (ExtFileList)dgvDetail.Rows[e.RowIndex].Tag;

                        if (string.IsNullOrEmpty(task.RealFileName))
                        {
                            return;
                        }
                        else
                        {
                            try
                            {
                                Process.Start(Path.Combine(MainForm.ProjectFilesDir, task.RealFileName));
                            }
                            catch (Exception ex) { }
                        }
                    }
                }
            }
        }

        private void dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((KryptonDataGridView)sender)[((KryptonDataGridView)sender).Columns.Count - 1, e.RowIndex == 0 ? e.RowIndex : e.RowIndex - 1].Value = global::ProjectReporter.Properties.Resources.DELETE_28;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvDetail.Rows.Add(new object[] { dgvDetail.Rows.Count + 1, string.Empty, string.Empty, false });
        }
    }
}