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
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using TreeNode = System.Windows.Forms.TreeNode;

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
            PopulateScenariosTree();
        }

        private void PopulateScenariosTree()
        {
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                var queryScenarios = from scenarios in dataContext.active_EAscenarios
                                     where scenarios.ProjectId == selectedProject.Id
                                     select scenarios;
                var querySteps = from steps in dataContext.active_Steps                                 
                                 select steps;

                InitializeTreeView(queryScenarios, querySteps);
            }
        }

        private void InitializeTreeView(IQueryable<active_EAscenario> queryScenarios, IQueryable<active_Step> querySteps)
        {
            treeView_scenarios.BeginUpdate();

            foreach (var scenario in queryScenarios)
            {
                var steps = from s in querySteps
                            where s.EAScenarioId == scenario.Id
                            select s;
                TreeNode[] stepsArray = GenerateTreeNodes(steps);
                TreeNode scenarioTreeNode = new TreeNode(scenario.Name, stepsArray);
                treeView_scenarios.Nodes.Add(scenarioTreeNode);                
            }            
        }

        private TreeNode[] GenerateTreeNodes(IQueryable<active_Step> steps)
        {
            List<TreeNode> treeNodesList = new List<TreeNode>();
            foreach (var s in steps)
            {
                treeNodesList.Add(new TreeNode(s.Name));
            }
            return treeNodesList.ToArray();
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

        private void Cb_chooseProject_OnChanged(object sender, EventArgs e)
        {
            selectedProject = (Project)cb_chooseProject.SelectedItem;
            PopulateScenariosTree();
        }
    }
}
