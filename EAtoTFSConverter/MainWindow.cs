using EAtoTFSConverter.Data.Logic;
using EAtoTFSConverter.Data.Logic.WorkItems;
using EAtoTFSConverter.Data.XMLParse;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using TreeNode = System.Windows.Forms.TreeNode;

namespace EAtoTFSConverter
{
    public partial class MainWindow : Form
    {
        private string _filePath = string.Empty;
        private Project _selectedProject;

        public MainWindow()
        {
            InitializeComponent();
            PopulateLists();
        }

        private void PopulateLists()
        {
            PopulateProjectsList();
        }

        private void PopulateScenariosTree()
        {
            DatabaseOperations db = new DatabaseOperations();
            var queryScenarios = db.GetActive_EAscenarios(_selectedProject);
            InitializeTreeView(queryScenarios);
        }

        private void InitializeTreeView(IEnumerable<active_EAscenario> queryScenarios)
        {
            treeView_scenarios.BeginUpdate();
            foreach (var scenario in queryScenarios)
            {
                DatabaseOperations db = new DatabaseOperations();
                var steps = db.GetActive_Steps(scenario.Id);
                TreeNode[] stepsArray = GenerateStepTreeNodes(steps);
                TreeNode scenarioTreeNode = new TreeNode(scenario.Name, stepsArray);
                treeView_scenarios.Nodes.Add(scenarioTreeNode);
            }
            treeView_scenarios.EndUpdate();
        }

        private TreeNode[] GenerateStepTreeNodes(IEnumerable<active_Step> steps)
        {
            IList<TreeNode> treeNodesList = steps.Select(s => new TreeNode(s.Name)).ToList();
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
                _filePath = openFileDialog.FileName;
                XDocument source = XDocument.Load(_filePath);
                XMLParse.Parse(source, DataMapper.MapProject(_selectedProject));
            }
            openFileDialog.Dispose();
        }

        private void Cb_chooseProject_OnChanged(object sender, EventArgs e)
        {
            _selectedProject = (Project)cb_chooseProject.SelectedItem;
            treeView_scenarios.Nodes.Clear();
            PopulateScenariosTree();
        }

        private void Btn_sendToTFS_Click(object sender, EventArgs e)
        {
            WorkItemLogic workItemLogic = new WorkItemLogic(_selectedProject);
            workItemLogic.PrepareData();
        }
    }
}
