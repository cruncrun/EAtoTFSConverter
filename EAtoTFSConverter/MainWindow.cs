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

        public MainWindow()
        {
            InitializeComponent();
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
            }
        }
    }
}
