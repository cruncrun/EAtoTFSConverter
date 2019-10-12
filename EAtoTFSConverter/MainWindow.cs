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

                ParseSourceXML(source);
            }

            openFileDialog.Dispose();
        }

        private static void ParseSourceXML(XDocument source)
        {
            IEnumerable<EAScenario> result = from ea in source.Descendants("EAScenario")
                                             select new EAScenario()
                                             {
                                                 Name = (string)ea.Attribute("name"),
                                                 Xmi_Id = (string)ea.Attribute("xmi.id"),
                                                 Type = (string)ea.Attribute("type"),
                                                 Steps = from s in ea.Descendants("step")
                                                         select new Step()
                                                         {
                                                             Guid = (Guid)s.Attribute("guid"),
                                                             Name = (string)s.Attribute("name"),
                                                             Level = (int)s.Attribute("level"),
                                                             Result = (string)s.Attribute("result")
                                                         },
                                                 UseCase = from uc in ea.Descendants("item")
                                                           select new UseCase()
                                                           {
                                                               Guid = (Guid)uc.Attribute("guid"),
                                                               Name = (string)uc.Attribute("oldname")
                                                           },
                                             };
            if (!result.Any())
            {
                MessageBox.Show(
                    "Wybrany plik XML nie zawierał żadnych wyeksportowanych scenariuszy.", "Błąd!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                // Insert into database...
            }
        }
    }
}
