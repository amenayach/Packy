using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Packy.Models;
using Packy.Utils;

namespace Packy.UserControls
{
    public partial class DestinationUserControl : UserControl
    {

        private List<Destination> destinations = null;

        public DestinationUserControl()
        {
            InitializeComponent();
        }

        private void DestinationUserControl_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
            }
            catch
            {
                //Ignored
            }
        }

        private void DestinationUserControl_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    var filePaths = e.Data.GetData(DataFormats.FileDrop) as string[];
                    if (filePaths != null && filePaths.Length > 0)
                    {
                        AddDestinations(filePaths);
                    }
                }
            }
            catch
            {
                //Ignored
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {

                var files = IoManager.BrowseFiles();

                if (ControlMod.NotEmpty(files))
                {

                    AddDestinations(files);

                }

            }
            catch (Exception ex)
            {
                ControlMod.PromptMsg(ex);
            }
        }

        private void AddDestinations(string[] files)
        {

            if (destinations == null)
            {
                destinations = new List<Destination>();
            }

            if (ControlMod.NotEmpty(files))
            {

                foreach (var file in files)
                {

                    var newDestination = new Destination(file);

                    if (!destinations.Contains(newDestination, new DestinationComparer()))
                    {
                        destinations.Add(newDestination);
                        AddDestinationUi(newDestination);
                    }

                }

            }

        }

        private void AddDestinationUi(Destination newDestination)
        {
            var newButton = new Button
            {
                Anchor = (AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                ForeColor = Color.White,
                Location = new Point(-1, destinations.Count * 50),
                Margin = new Padding(5),
                Name = "btn" + (destinations.Count + 1),
                Size = new Size(pnlHolder.Width, 48),
                TabIndex = destinations.Count,
                Text = newDestination.Name,
                Tag = newDestination,
                UseVisualStyleBackColor = true
            };

            newButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);

            pnlHolder.Controls.Add(newButton);
        }

    }
}
