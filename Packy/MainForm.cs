using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Packy.Adapters;
using Packy.Models;

namespace Packy
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

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
        
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {

        }
    }
}
