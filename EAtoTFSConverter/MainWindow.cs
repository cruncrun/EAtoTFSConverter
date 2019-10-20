using EAtoTFSConverter.Data;
using EAtoTFSConverter.Data.DBOperations;
using EAtoTFSConverter.Data.XMLParse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace EAtoTFSConverter
{
    public partial class MainWindow : Form
    {
        private string filePath = string.Empty;
        private Project selectedProject;

        public MainWindow()
        {
            InitializeComponent();
            PopulateLists();
        }

        private void PopulateLists()
        {
            PopulateProjectsList();
        }

        private void PopulateProjectsList()
        {
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                var queryAllProjects = from projects in dataContext.Projects
                                       select projects;
                cb_chooseProject.DisplayMember = "Name";
                cb_chooseProject.DataSource = queryAllProjects;
            }
        }

        private void Btn_load_EA_XML_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "C:\\",
                Filter = "XML Files (*.xml)|*.xml|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                XDocument source = XDocument.Load(filePath);

                XMLParse.Parse(source, DataMapper.MapProject(selectedProject));
            }

            openFileDialog.Dispose();
        }

        private void cb_chooseProject_OnChanged(object sender, EventArgs e)
        {
            selectedProject = (Project)cb_chooseProject.SelectedItem; 
        }
    }
}
