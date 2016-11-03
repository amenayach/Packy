using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Packy.Adapters;
using Packy.Models;
using Packy.UserControls;
using Packy.Utils;

namespace Packy
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DataOrganizer.InitDataFolder();
        }

        public string TargetedProject { get; set; }

        public bool DoPublish { get; set; }

        private void MainForm_Load(object sender, EventArgs e)
        {

            //testing serializer
            //var source1 = new Source(@"C:\Users\aayach\Desktop", "MyDesktop");
            //var source2 = new Source(@"C:\Users\aayach\Desktop\Search payload.txt", "Search Payload");

            //var dest = new Destination(@"C:\Users\aayach\Desktop\dest", "Desto") { Sources = new[] { source1, source2 }.ToList() };

            //var proj = new Project()
            //{
            //    Title = "Proj",
            //    Destinations = new List<Destination>(new[] { dest })
            //};

            //XmlSerializer.SaveFile(proj, "proj.xml");

            //var data = XmlSerializer.GetFile<Project>("proj.xml");

            LoadData(false);

            var projects = GetProjects();

            foreach (var projectName in projects)
            {

                if (projectName.ToLower() == TargetedProject.NullTrimer().ToLower())
                {

                    ClearOldProjectControl(true);

                    var projControl = new ProjectUserControl(projectName)
                    {
                        Dock = DockStyle.Fill,
                        ProjectDeleted = () =>
                        {
                            LoadData(false);
                        }
                    };

                    splitContainer1.Panel2.Controls.Add(projControl);

                    if (DoPublish)
                    {
                        projControl.Publish();
                    }

                    break;
                }

            }

        }

        private void LoadData(bool saveBeforeClear)
        {

            //this.Text = $"{TargetedProject} - {DoPublish}";

            ClearOldProjectControl(saveBeforeClear);
            pnlSideBar.Controls.Clear();

            var projects = GetProjects();

            for (int i = 0; i < projects.Count; i++)
            {

                var projectName = projects[i];

                var newSideButton = new Button
                {
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Microsoft Sans Serif", 13F),
                    Location = new Point(4, pnlSideBar.Controls.Count * 52 + 6),
                    Name = "btn" + projectName,
                    Size = new Size(pnlSideBar.Width - 6, 38),
                    Text = projectName,
                    UseVisualStyleBackColor = true,
                    Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right))),
                    Tag = projectName
                };

                //Adding the new button to the sidebar
                pnlSideBar.Controls.Add(newSideButton);

                //Handling the click event
                newSideButton.Click += (sender, args) =>
                {
                    ClearOldProjectControl(true);

                    var projControl = new ProjectUserControl(projectName)
                    {
                        Dock = DockStyle.Fill,
                        ProjectDeleted = () =>
                        {
                            LoadData(false);
                        }
                    };

                    splitContainer1.Panel2.Controls.Add(projControl);

                };

            }

        }

        private static List<string> GetProjects()
        {
            return new DirectoryInfo(DataOrganizer.GetDataFolderPath()).GetFiles()
                .Where(f => f.Name.ToLower().EndsWith(".packy"))
                .Select(m => m.Name.Substring(0, (m.Name.Length - ".packy".Length))).ToList();
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            var projectName = ControlMod.InputBox("", "Please enter the project name:");

            var invalidChars = Path.GetInvalidFileNameChars();

            projectName = new string(projectName
              .Where(x => !invalidChars.Contains(x))
              .ToArray());

            if (!string.IsNullOrEmpty(projectName.NullTrimer()))
            {

                projectName = projectName.NullTrimer().Replace(" ", "_");

                var projControl = new ProjectUserControl(projectName)
                {
                    Dock = DockStyle.Fill,
                    ProjectDeleted = () =>
                    {
                        LoadData(false);
                    }
                };

                ClearOldProjectControl(true);

                splitContainer1.Panel2.Controls.Add(projControl);

                var newSideButton = new Button
                {
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Microsoft Sans Serif", 13F),
                    Location = new Point(4, pnlSideBar.Controls.Count * 52 + 6),
                    Name = "btn" + projectName,
                    Size = new Size(pnlSideBar.Width - 6, 38),
                    Text = projectName,
                    UseVisualStyleBackColor = true,
                    Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right))),
                    Tag = projectName
                };

                pnlSideBar.Controls.Add(newSideButton);

            }
        }

        private void ClearOldProjectControl(bool saveBeforeClear)
        {

            if (splitContainer1.Panel2.Controls.Count > 0)
            {

                var oldPorjectControl = splitContainer1.Panel2.Controls[0] as ProjectUserControl;

                if (oldPorjectControl != null)
                {
                    if (saveBeforeClear)
                    {
                        oldPorjectControl.Save();
                    }
                    splitContainer1.Panel2.Controls.Remove(oldPorjectControl);
                }

                splitContainer1.Panel2.Controls.Clear();

            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                if (splitContainer1.Panel2.Controls.Count > 0)
                {

                    var oldPorjectControl = splitContainer1.Panel2.Controls[0] as ProjectUserControl;

                    if (oldPorjectControl != null)
                    {
                        oldPorjectControl.Save();
                    }

                }

            }
            catch
            {
                // Ignored
                throw;
            }
        }
    }
}
