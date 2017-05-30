using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Packy.Adapters;
using Packy.Models;
using Packy.Utils;

namespace Packy.UserControls
{
    public partial class ProjectUserControl : UserControl
    {

        private string _projectName = string.Empty;

        private bool publish = false;

        public Action ProjectDeleted { get; set; }

        public ProjectUserControl()
        {
            InitializeComponent();

            //this.publish = publish;

        }

        public ProjectUserControl(string projectName)
        {
            InitializeComponent();

            //this.publish = publish;

            _projectName = projectName;

            tbProjectName.Text = _projectName;

        }

        private void Control_Load(object sender, EventArgs e)
        {
            try
            {
                FSrc.DataPropertyName = "Src";
                FDest.DataPropertyName = "Dest";
                grd.AutoGenerateColumns = false;
                grd_Resize(null, null);

                var projectFilePath = Path.Combine(DataOrganizer.GetDataFolderPath(), _projectName + ".packy");

                if (System.IO.File.Exists(projectFilePath))
                {

                    var project = ControlMod.loadBinary(projectFilePath) as FlatProject;

                    if (project != null)
                    {
                        grd.AllowUserToAddRows = false;
                        foreach (Tuple<string, string> track in project.Tracks)
                        {
                            int rowIndex = grd.Rows.Add();
                            grd.sg(rowIndex, FSrc, track.Item1);
                            grd.sg(rowIndex, FDest, track.Item2);
                        }
                    }//data.NotEmpty()

                }//System.IO.File.Exists(filename)
            }
            catch (Exception ex)
            {
                ControlMod.PromptMsg(ex);
            }
            grd.AllowUserToAddRows = true;

            if (publish)
            {
                btnPublish_Click(null, null);
            }
        }

        private void grd_Resize(object sender, EventArgs e)
        {
            FSrc.Width = (grd.Width - grd.VerticalScrollingOffset - grd.RowHeadersWidth - 20) / 2;
            FDest.Width = FSrc.Width;
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            Publish();
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    var filePaths = e.Data.GetData(DataFormats.FileDrop) as string[];
                    if (filePaths != null && filePaths.Length > 0)
                    {

                        if (sender.Equals(lblSrcDrop) || sender.Equals(lblDestDrop))
                        {
                            grd.AllowUserToAddRows = false;
                            foreach (var _filePath in filePaths)
                            {
                                var filePath = _filePath;

                                if (sender.Equals(lblDestDrop) && System.IO.File.Exists(filePath))
                                {
                                    filePath = new System.IO.FileInfo(filePath).Directory.FullName;
                                }

                                int rowIndex = FindEmptyRow(sender.Equals(lblSrcDrop));
                                if (rowIndex >= 0)
                                {

                                    grd.sg(rowIndex, sender.Equals(lblSrcDrop) ? FSrc : FDest, filePath);

                                } // rowIndex >= 0

                            } //foreach

                        } //f (sender.Equals(lblSrcDrop) || sender.Equals(lblDestDrop))
                    }
                }
            }
            catch
            {
                // Ignored
            }
            lblDestDrop.Visible = false;
            lblSrcDrop.Visible = false;
            grd.AllowUserToAddRows = true;
        }

        private int FindEmptyRow(bool isSrc)
        {
            var res = -1;
            foreach (DataGridViewRow row in grd.Rows)
            {
                var val = isSrc ? grd.gg(row, FSrc).AsString() : grd.gg(row, FDest).AsString();
                if (val.IsEmpty())
                {
                    res = row.Index;
                    break;
                }
            }
            if (res == -1)
            {
                res = grd.Rows.Add();
            }
            return res;
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                var copyEffect = e.Data.GetDataPresent(DataFormats.FileDrop);
                e.Effect = copyEffect ? DragDropEffects.Copy : DragDropEffects.None;
                lblDestDrop.Visible = copyEffect;
                lblSrcDrop.Visible = copyEffect;
            }
            catch { }
        }

        public void Save()
        {
            try
            {

                if (string.IsNullOrEmpty(_projectName))
                {
                    return;
                }

                grd.AllowUserToAddRows = false;
                var data = new List<Tuple<string, string>>();

                foreach (DataGridViewRow row in grd.Rows)
                {
                    data.Add(new Tuple<string, string>(grd.gg(row, FSrc).AsString(), grd.gg(row, FDest).AsString()));
                }
                ControlMod.saveBinary(new FlatProject() { Name = _projectName, Tracks = data }, System.IO.Path.Combine(DataOrganizer.GetDataFolderPath(), _projectName + ".packy"));
            }
            catch (Exception ex)
            {
                ControlMod.PromptMsg(ex);
            }
            grd.AllowUserToAddRows = true;
        }

        public void Publish()
        {
            try
            {
                grd.AllowUserToAddRows = false;

                foreach (DataGridViewRow row in grd.Rows)
                {
                    grd.sg(row.Index, FFlag, 2);
                    lblStatus.Text = "";
                    Application.DoEvents();
                    try
                    {
                        var fullname = grd.gg(row, FSrc).ToString();
                        var fileName = new System.IO.FileInfo(fullname).Name;
                        var tempRow = row;

                        Async.GetDataAsync<bool>(() =>
                        {
                            try
                            {
                                return CopyDir.Copy(fullname, grd.gg(tempRow, FDest).ToString());
                            }
                            catch
                            {
                                return false;
                            }
                        }, (bool success) =>
                        {
                            grd.sg(tempRow.Index, FFlag, success ? 1 : -1);
                            Application.DoEvents();
                        });

                    }
                    catch
                    {
                        grd.sg(row.Index, FFlag, -1);
                    }
                }
            }
            catch (Exception ex)
            {
                ControlMod.PromptMsg(ex);
            }

            grd.AllowUserToAddRows = true;
            //lblStatus.Text = "Done";
            Application.DoEvents();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                try
                {

                    var filename = Path.Combine(DataOrganizer.GetDataFolderPath(), _projectName + ".packy");

                    if (File.Exists(filename))
                    {
                        File.Delete(filename);
                    }

                    if (ProjectDeleted != null)
                    {
                        ProjectDeleted();
                    }
                }
                catch
                {
                    // Ignored
                }
            }
        }

        private void grd_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0 && !grd.Rows[e.RowIndex].IsNewRow)
            {

                var flag = grd.gg(e.RowIndex, FFlag) as int?;
                e.Graphics.FillRectangle(Brushes.White, e.CellBounds);

                if (flag >= 2)
                {

                    e.Graphics.DrawImage(Properties.Resources.hourglass, e.CellBounds.X + 14, e.CellBounds.Y + 1,
                        e.CellBounds.Height - 4, e.CellBounds.Height - 4);

                }
                else if (flag >= 1)
                {

                    e.Graphics.DrawImage(Properties.Resources.checkicon, e.CellBounds.X + 14, e.CellBounds.Y + 1,
                        e.CellBounds.Height - 4, e.CellBounds.Height - 4);

                }
                else if (flag == -1)
                {
                    e.Graphics.DrawImage(Properties.Resources.erroricon, e.CellBounds.X + 14, e.CellBounds.Y + 1,
                     e.CellBounds.Height - 4, e.CellBounds.Height - 4);
                }

                e.Handled = true;
            }
        }

        private void grd_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            grd.Invalidate();
        }
    }
}
