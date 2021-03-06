﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using ProjectReporter.DB;
using ProjectReporter.DB.Entitys;
using ProjectReporter.Forms;
using ProjectReporter.DB.Services;
using System.IO;
using System.Diagnostics;

namespace ProjectReporter.Controls
{
    public partial class YanJiuGuGanEditor : BaseEditor
    {
        public YanJiuGuGanEditor()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NewGuGanLianXiRenForm form = new NewGuGanLianXiRenForm(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                MainForm.Instance.RefreshEditorWithoutRTFTextEditor();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            OnLastEvent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            OnNextEvent();
        }

        private void dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((KryptonDataGridView)sender)[((KryptonDataGridView)sender).Columns.Count - 1, e.RowIndex == 0 ? e.RowIndex : e.RowIndex - 1].Value = global::ProjectReporter.Properties.Resources.DELETE_28;
            ((KryptonDataGridView)sender)[((KryptonDataGridView)sender).Columns.Count - 2, e.RowIndex == 0 ? e.RowIndex : e.RowIndex - 1].Value = "编辑";
            ((KryptonDataGridView)sender)[((KryptonDataGridView)sender).Columns.Count - 3, e.RowIndex == 0 ? e.RowIndex : e.RowIndex - 1].Value = "向下";
            ((KryptonDataGridView)sender)[((KryptonDataGridView)sender).Columns.Count - 4, e.RowIndex == 0 ? e.RowIndex : e.RowIndex - 1].Value = "向上";
        }

        public override void ClearView()
        {
            base.ClearView();

            dgvDetail.Rows.Clear();
        }

        public override void RefreshView()
        {
            base.RefreshView();

            UpatePersonList();

            UpdateJobList();

            UpdateTaskList();
        }

        private void UpdateJobList()
        {
            KryptonDataGridViewComboBoxColumn comboboxColumn = (KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[9];
            comboboxColumn.Items.Clear();
            JobDict.Clear();

            //项目的负责人和成员
            string projectA = "项目负责人";
            //string projectB = "项目-成员";
            ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[9]).Items.Add(projectA);
            //((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[9]).Items.Add(projectB);
            JobDict.Add(projectA, MainForm.Instance.ProjectObj);
            //JobDict.Add(projectB, MainForm.Instance.ProjectObj);

            List<Project> ketiList = ConnectionManager.Context.table("Project").where("ParentID='" + MainForm.Instance.ProjectObj.ID + "'").select("*").getList<Project>(new Project());
            if (ketiList != null)
            {
                foreach (Project proj in ketiList)
                {
                    projectA = proj.Name + "负责人";
                    string projectB = proj.Name + "成员";
                    ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[9]).Items.Add(projectA);
                    ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[9]).Items.Add(projectB);
                    JobDict[projectA] = proj;
                    JobDict[projectB] = proj;
                }
            }
        }

        private void UpdateTaskList()
        {
            TaskList = ConnectionManager.Context.table("Task").where("ProjectID in (select ID from Project where ParentID = '" + MainForm.Instance.ProjectObj.ID + "') or ProjectID='" + MainForm.Instance.ProjectObj.ID + "'").orderBy("DisplayOrder").select("*").getList<Task>(new Task());

            int indexx = 0;
            dgvDetail.Rows.Clear();            
            foreach (Task task in TaskList)
            {
                indexx++;
                Person person = null;
                Unit unit = null;
                foreach (Person p in PersonList)
                {
                    if (p.ID != null && p.ID.Equals(task.PersonID))
                    {
                        person = p;
                        break;
                    }
                }
                
                if (person == null || string.IsNullOrEmpty(person.ID))
                {
                    continue;
                }

                unit = ConnectionManager.Context.table("Unit").where("ID='" + person.UnitID + "'").select("*").getItem<Unit>(new Unit());

                if (unit == null || string.IsNullOrEmpty(unit.ID))
                {
                    continue;
                }

                List<object> cells = new List<object>();
                cells.Add(indexx + "");
                cells.Add(person.Name);
                cells.Add(person.Sex);
                cells.Add(person.Job);
                cells.Add(person.Specialty);
                cells.Add(unit.UnitName);
                cells.Add(task.TotalTime);
                cells.Add(task.Content);
                cells.Add(person.IDCard);

                string roleName = string.Empty;
                foreach (KeyValuePair<string, Project> kvp in JobDict)
                {
                    if (kvp.Value.ID != null && kvp.Value.ID.Equals(task.ProjectID))
                    {
                        if (kvp.Key.EndsWith(task.Role))
                        {
                            roleName = kvp.Key;
                            break;
                        }
                    }
                }
                cells.Add(roleName);                
                
                cells.Add("向上");
                cells.Add("向下");
                cells.Add("编辑");

                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = task;
            }
        }

        private void UpatePersonList()
        {
            KryptonDataGridViewComboBoxColumn comobobxColumn = ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[1]);
            comobobxColumn.Items.Clear();
            PersonDict.Clear();

            PersonList = ConnectionManager.Context.table("Person").select("*").getList<Person>(new Person());
            if (PersonList != null)
            {
                foreach (Person person in PersonList)
                {
                    string key = person.Name + "(" + person.IDCard + ")";
                    PersonDict.Add(key, person);

                    comobobxColumn.Items.Add(key);
                }
            }
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            //foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
            //{
            //    Task task = null;
            //    if (dgvRow.Tag == null)
            //    {
            //        //新行
            //        task = new Task();
            //        task.ProjectID = MainForm.Instance.ProjectObj.ID;
            //        task.Type = "项目";
            //    }
            //    else
            //    {
            //        //已存在
            //        task = (Task)dgvRow.Tag;
            //    }

            //    if (dgvRow.Cells[1].Value == null || string.IsNullOrEmpty(dgvRow.Cells[1].Value.ToString()))
            //    {
            //        continue;
            //    }
            //    if (dgvRow.Cells[5].Value == null || string.IsNullOrEmpty(dgvRow.Cells[5].Value.ToString()))
            //    {
            //        MessageBox.Show("对不起,请选择项目内职务");
            //        return;
            //    }
            //    if (dgvRow.Cells[6].Value == null || string.IsNullOrEmpty(dgvRow.Cells[6].Value.ToString()))
            //    {
            //        MessageBox.Show("对不起,请输入任务分工");
            //        return;
            //    }
            //    if (dgvRow.Cells[7].Value == null || string.IsNullOrEmpty(dgvRow.Cells[7].Value.ToString()))
            //    {
            //        MessageBox.Show("对不起,请输入每年为项目工作时间(月)");
            //        return;
            //    }

            //    if (PersonDict.ContainsKey(dgvRow.Cells[1].Value.ToString()))
            //    {
            //        task.PersonID = PersonDict[dgvRow.Cells[1].Value.ToString()].ID;
            //        task.IDCard = PersonDict[dgvRow.Cells[1].Value.ToString()].IDCard;
            //    }
            //    else
            //    {
            //        MessageBox.Show("对不起,人员不存在");
            //        return;
            //    }

            //    string roleName = dgvRow.Cells[5].Value.ToString();
            //    if (JobDict.ContainsKey(roleName))
            //    {
            //        if (roleName.StartsWith("项目-"))
            //        {
            //            //项目
            //            task.Type = "项目";
            //            task.Role = roleName.Replace("项目-", string.Empty);
            //        }
            //        else
            //        {
            //            //课题
            //            task.Type = "课题";
            //            task.Role = roleName.Split('-')[1];
            //        }

            //        task.ProjectID = JobDict[roleName].ID;
            //    }

            //    task.Content = dgvRow.Cells[6].Value.ToString();
            //    task.TotalTime = Int32.Parse(dgvRow.Cells[7].Value.ToString());

            //    if (string.IsNullOrEmpty(task.ID))
            //    {
            //        //insert
            //        task.ID = Guid.NewGuid().ToString();
            //        task.copyTo(ConnectionManager.Context.table("Task")).insert();
            //    }
            //    else
            //    {
            //        //update
            //        task.copyTo(ConnectionManager.Context.table("Task")).where("ID='" + task.ID + "'").update();
            //    }
            //}

            //MainForm.Instance.RefreshEditorWithoutRTFTextEditor();
        }

        public List<Person> PersonList { get; set; }

        protected Dictionary<string, Person> PersonDict = new Dictionary<string, Person>();

        protected Dictionary<string, Project> JobDict = new Dictionary<string, Project>();

        private void dgvDetail_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                KryptonDataGridViewComboBoxCell comboboxCell = (KryptonDataGridViewComboBoxCell)dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (comboboxCell.EditedFormattedValue != null)
                {
                    string key = comboboxCell.EditedFormattedValue.ToString();

                    if (PersonDict.ContainsKey(key))
                    {
                        Person person = PersonDict[key];

                        Unit unitObj = ConnectionManager.Context.table("Unit").where("ID='" + person.UnitID + "'").select("*").getItem<Unit>(new Unit());
                        if (unitObj != null)
                        {
                            dgvDetail[2, e.RowIndex].Value = unitObj.UnitName;
                            dgvDetail[3, e.RowIndex].Value = person.Job;
                            dgvDetail[4, e.RowIndex].Value = person.Specialty;
                        }
                    }
                }
            }
        }

        public List<Task> TaskList { get; set; }

        private void dgvDetail_EditModeChanged(object sender, EventArgs e)
        {
            //if (dgvDetail.SelectedRows != null && dgvDetail.SelectedRows.Count >= 1)
            //{
            //    DataGridViewRow dgvRow = dgvDetail.SelectedRows[0];
            //    if (dgvRow.Cells[1].Value != null)
            //    {
            //        string key = dgvRow.Cells[1].Value.ToString();

            //        if (PersonDict.ContainsKey(key))
            //        {
            //            Person person = PersonDict[key];

            //            Unit unitObj = ConnectionManager.Context.table("Unit").where("ID='" + person.UnitID + "'").select("*").getItem<Unit>(new Unit());
            //            if (unitObj != null)
            //            {
            //                dgvRow.Cells[2].Value = unitObj.UnitName;
            //                dgvRow.Cells[3].Value = person.Job;
            //                dgvRow.Cells[4].Value = person.Specialty;
            //            }
            //        }
            //    }
            //}
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1)
            {
                if (e.ColumnIndex == dgvDetail.Columns.Count - 3)
                {
                    if (dgvDetail.Rows[e.RowIndex].Tag != null)
                    {
                        Task task = (Task)dgvDetail.Rows[e.RowIndex].Tag;
                        MoveToDown(e.RowIndex, task);
                    }
                }

                if (e.ColumnIndex == dgvDetail.Columns.Count - 4)
                {
                    if (dgvDetail.Rows[e.RowIndex].Tag != null)
                    {
                        Task task = (Task)dgvDetail.Rows[e.RowIndex].Tag;
                        MoveToUp(e.RowIndex, task);
                    }
                }

                if (e.ColumnIndex == dgvDetail.Columns.Count - 2)
                {
                    if (dgvDetail.Rows[e.RowIndex].Tag != null)
                    {
                        Task task = (Task)dgvDetail.Rows[e.RowIndex].Tag;

                        NewGuGanLianXiRenForm form = new NewGuGanLianXiRenForm(task);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            MainForm.Instance.RefreshEditorWithoutRTFTextEditor();
                        }
                    }
                }

                if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                {
                    if (dgvDetail.Rows[e.RowIndex].Tag != null)
                    {
                        Task task = (Task)dgvDetail.Rows[e.RowIndex].Tag;
                        if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ConnectionManager.Context.table("Task").where("ID='" + task.ID + "'").delete();
                            MainForm.Instance.RefreshEditorWithoutRTFTextEditor();
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
                                    UpdateTaskList();
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 向上移动
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="task"></param>
        private void MoveToUp(int rowIndex, Task task)
        {
            if (TaskList != null)
            {
                int taskIndex = TaskList.IndexOf(task);
                if (taskIndex >= 1)
                {
                    TaskList.Remove(task);
                    TaskList.Insert(taskIndex - 1, task);

                    int ri = 0;
                    foreach (Task t in TaskList)
                    {
                        t.DisplayOrder = ri;
                        ri++;

                        t.copyTo(ConnectionManager.Context.table("Task")).where("ID='" + t.ID + "'").update();
                    }

                    UpdateTaskList();
                    if (taskIndex >= 1)
                    {
                        dgvDetail.Rows[taskIndex - 1].Selected = true;
                    }
                }
            }
        }

        /// <summary>
        /// 向下移动
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="task"></param>
        private void MoveToDown(int rowIndex, Task task)
        {
            if (TaskList != null)
            {
                int taskIndex = TaskList.IndexOf(task);
                if (taskIndex <= TaskList.Count - 2)
                {
                    TaskList.Remove(task);
                    TaskList.Insert(taskIndex + 1, task);

                    int ri = 0;
                    foreach (Task t in TaskList)
                    {
                        t.DisplayOrder = ri;
                        ri++;

                        t.copyTo(ConnectionManager.Context.table("Task")).where("ID='" + t.ID + "'").update();
                    }

                    UpdateTaskList();
                    if (taskIndex < dgvDetail.Rows.Count - 1)
                    {
                        dgvDetail.Rows[taskIndex + 1].Selected = true;
                    }
                    else
                    {
                        dgvDetail.Rows[dgvDetail.Rows.Count - 1].Selected = true;
                    }
                }
            }
        }

        public override bool IsInputCompleted()
        {
            if (dgvDetail.Rows.Count == 0)
            {
                MessageBox.Show("对不起,请输入研究骨干信息!");
            }

            return dgvDetail.Rows.Count >= 1;
        }

        private void dgvDetail_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows[e.RowIndex].Tag != null)
            {
                Task task = (Task)dgvDetail.Rows[e.RowIndex].Tag;
                NewGuGanLianXiRenForm form = new NewGuGanLianXiRenForm(task);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    MainForm.Instance.RefreshEditorWithoutRTFTextEditor();
                }
            }
        }

        private void btnExcelLoad_Click(object sender, EventArgs e)
        {
            if (ofdExcelDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataSet ds = ProjectReporter.Utility.ExcelHelper.ExcelToDataSet(ofdExcelDialog.FileName);
                    if (ds != null && ds.Tables.Count >= 1)
                    {
                        //显示提示窗体
                        ProjectReporter.Forms.UIDoWorkProcessForm upf = new Forms.UIDoWorkProcessForm();
                        upf.EnabledDisplayProgress = false;
                        upf.LabalText = "正在导入，请稍等...";
                        upf.ShowProgress();

                        foreach (DataTable dt in ds.Tables)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (dr[0] != null && dr[0].ToString().Equals("单位开户帐号"))
                                {
                                    continue;
                                }

                                if (dr.ItemArray != null)
                                {
                                    //插入骨干人员
                                    insertPersonFromDataRow(dr);
                                }
                            }
                        }

                        upf.Close();

                        RefreshView();
                        MessageBox.Show("操作完成！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导入失败!Ex:" + ex.ToString());
                }
            }
        }

        /// <summary>
        /// 插入骨干人员信息
        /// </summary>
        /// <param name="dr">行数据</param>
        private void insertPersonFromDataRow(DataRow dr)
        {
            UnitExtService _unitInforService = new UnitExtService();

            try
            {
                //加载字段
                string unitName = dr["单位名称"] != null ? dr["单位名称"].ToString() : string.Empty;
                //string unitType = dr["隶属部门"] != null ? dr["隶属部门"].ToString() : string.Empty;
                string unitType = "其它";
                string unitAddress = dr["单位通信地址"] != null ? dr["单位通信地址"].ToString() : string.Empty;
                string unitContact = dr["单位联系人"] != null ? dr["单位联系人"].ToString() : string.Empty;
                string unitTelephone = dr["单位联系电话"] != null ? dr["单位联系电话"].ToString() : string.Empty;
                string personName = dr["姓名"] != null ? dr["姓名"].ToString() : string.Empty;
                string personIDCard = dr["身份证"] != null ? dr["身份证"].ToString() : string.Empty;
                string personJob = dr["职务职称"] != null ? dr["职务职称"].ToString() : string.Empty;
                string personSpecialty = dr["从事专业"] != null ? dr["从事专业"].ToString() : string.Empty;
                string personSex = dr["性别"] != null ? dr["性别"].ToString() : string.Empty;
                string personBirthday = dr["出生年月"] != null ? dr["出生年月"].ToString() : string.Empty;
                string personTelephone = dr["座机"] != null ? dr["座机"].ToString() : string.Empty;
                string personMobilePhone = dr["手机"] != null ? dr["手机"].ToString() : string.Empty;
                string personAddress = dr["通信地址"] != null ? dr["通信地址"].ToString() : string.Empty;
                string subjectName = dr["课题名称"] != null ? dr["课题名称"].ToString() : string.Empty;
                string jobInProjectOrSubject = dr["项目或课题中职务"] != null ? dr["项目或课题中职务"].ToString() : string.Empty;
                string taskInProject = dr["任务分工"] != null ? dr["任务分工"].ToString() : string.Empty;
                string timeInProject = dr["每年为本项目工作时间(月)"] != null ? dr["每年为本项目工作时间(月)"].ToString() : string.Empty;

                //进行必要字段的校验
                
                //检查身份证
                if (string.IsNullOrEmpty(personIDCard))
                {
                    throw new Exception("对不起，'身份证'不能为空");
                }

                //检查出生日期
                DateTime dt = DateTime.MinValue;
                if (DateTime.TryParse(personBirthday, out dt) == false)
                {
                    throw new Exception("对不起，'出生日期'格式错误！");
                }

                //检查项目或课题中职务f
                if (jobInProjectOrSubject != "成员" && jobInProjectOrSubject != "负责人")
                {
                    throw new Exception("对不起，'项目或课题中职务'里只能写成员或负责人！");
                }

                //检查性别
                if (personSex != "男" && personSex != "女")
                {
                    throw new Exception("对不起，性别必须是'男'或'女'");
                }

                //检查每年为本项目工作时间
                int timeResult = 0;
                if (int.TryParse(timeInProject, out timeResult) == false)
                {
                    throw new Exception("对不起，'每年为本项目工作时间'只能是数字！");
                }

                //检查课题名称
                if (!string.IsNullOrEmpty(subjectName))
                {
                    long subjectCount = ConnectionManager.Context.table("Project").where("Name='" + subjectName + "'").select("count(*)").getValue<long>(0);
                    if (subjectCount <= 0)
                    {
                        throw new Exception("对不起，'" + subjectName + "'不是有效的课题名称！");
                    }
                }

                //检查非空
                foreach (DataColumn dc in dr.Table.Columns)
                {
                    if (dc.ColumnName == "课题名称")
                    {
                        continue;
                    }
                    else if (dr[dc.ColumnName] == null || dr[dc.ColumnName].ToString() == string.Empty)
                    {
                        throw new Exception("对不起，'" + dc.ColumnName + "'不能为空！");
                    }
                }

                #region 插入人员数据

                ////判断是不是需要创建单位
                //UnitExt unitExtObj = ConnectionManager.Context.table("UnitExt").where("UnitBankNo='" + unitBankNo + "'").select("*").getItem<UnitExt>(new UnitExt());
                
                ////判断是否需要创建单位信息
                //if (string.IsNullOrEmpty(unitExtObj.ID))
                //{
                //    //需要创建单位

                //    //创建帐号信息
                //    if (unitExtObj == null)
                //    {
                //        unitExtObj = new UnitExt();
                //    }
                //    unitExtObj.UnitName = unitName;
                //    unitExtObj.UnitType = unitType;
                //    unitExtObj.UnitBankUser = unitBankUser;
                //    unitExtObj.UnitBankName = unitBankName;
                //    unitExtObj.UnitBankNo = unitBankNo;
                //    unitExtObj.IsUserAdded = 1;
                //    _unitInforService.UpdateUnitInfors(new List<UnitExt>(new UnitExt[] { unitExtObj }));
                //}

                string unitID = string.Empty;
                unitID = ConnectionManager.Context.table("Unit").where("UnitName='" + unitName + "'").select("ID").getValue<string>(Guid.NewGuid().ToString());

                //创建单位信息
                NewProjectEditor.BuildUnitRecord(unitID, unitName, unitName, unitName, unitContact, unitTelephone, unitType, unitAddress);

                //创建人员
                Person PersonObj = ConnectionManager.Context.table("Person").where("IDCard = '" + personIDCard + "'").select("*").getItem<Person>(new Person());
                string newPersonIds = Guid.NewGuid().ToString();

                if (PersonObj != null && PersonObj.ID != null && PersonObj.ID.Length > 1)
                {
                    //删除旧的人员信息
                    ConnectionManager.Context.table("Person").where("IDCard = '" + personIDCard + "'").delete();

                    //更新人员ID
                    ConnectionManager.Context.table("Task").where("IDCard = '" + personIDCard + "'").set("PersonID", newPersonIds).update();
                }
                else
                {
                    PersonObj = new Person();
                }

                PersonObj.ID = newPersonIds;
                PersonObj.UnitID = unitID;                
                PersonObj.Name = personName;
                PersonObj.Sex = personSex;
                PersonObj.Birthday = DateTime.Parse(personBirthday);
                PersonObj.IDCard = personIDCard;
                PersonObj.Job = personJob;
                PersonObj.Specialty = personSpecialty;
                PersonObj.Address = personAddress;
                PersonObj.Telephone = personTelephone;
                PersonObj.MobilePhone = personMobilePhone;
                PersonObj.copyTo(ConnectionManager.Context.table("Person")).insert();

                //添加/修改Task
                Task task = ConnectionManager.Context.table("Task").where("IDCard='" + personIDCard + "' and ProjectID in (select ID from Project where Name = '" + (string.IsNullOrEmpty(subjectName) ? MainForm.Instance.ProjectObj.Name : subjectName) + "')").select("*").getItem<Task>(new Task());
                if (task == null || string.IsNullOrEmpty(task.ID))
                {
                    //新行
                    task = new Task();
                    task.ProjectID = ConnectionManager.Context.table("Project").where("Name = '" + (string.IsNullOrEmpty(subjectName) ? MainForm.Instance.ProjectObj.Name : subjectName) + "'").select("ID").getValue<string>(string.Empty);
                    task.DisplayOrder = GetMaxDisplayOrder() + 1;
                }

                task.Type = string.IsNullOrEmpty(subjectName) || subjectName == MainForm.Instance.ProjectObj.Name ? "项目" : "课题";
                task.Role = jobInProjectOrSubject;

                task.PersonID = PersonObj.ID;
                task.IDCard = PersonObj.IDCard;

                task.Content = taskInProject;
                task.TotalTime = int.Parse(timeInProject);
                
                if (string.IsNullOrEmpty(task.ID))
                {
                    //insert
                    task.ID = Guid.NewGuid().ToString();
                    task.copyTo(ConnectionManager.Context.table("Task")).insert();
                }
                else
                {
                    //update
                    task.copyTo(ConnectionManager.Context.table("Task")).where("ID='" + task.ID + "'").update();
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("插入错误！Ex:" + ex.ToString(), "错误");
            }
        }

        private void lklDownloadFuJian_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sourcePath = Path.Combine(Application.StartupPath, Path.Combine("Helper", "lianxiren.xls"));

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.xls|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.Copy(sourcePath, sfd.FileName, true);
                    Process.Start(sfd.FileName);

                    MessageBox.Show("下载完成！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("下载失败！Ex:" + ex.ToString());
                }
            }
        }

        /// <summary>
        /// 获得最大的记录号
        /// </summary>
        /// <returns></returns>
        public static int GetMaxDisplayOrder()
        {
            try
            {
                return (int)ConnectionManager.Context.table("Task").select("max(DisplayOrder)").getValue<long>(0);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}