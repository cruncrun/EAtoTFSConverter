using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EAtoTFSConverter.Data.XMLParse
{
    static class XMLParse
    {
        public static void Parse(XDocument source)
        {
            IEnumerable<EAScenario> result = from ea in source.Descendants("EAScenario")
                                             select new EAScenario()
                                             {
                                                 Name = (string)ea.Attribute("name"),
                                                 Type = (string)ea.Attribute("type"), // przerzucić typy na enuma?
                                                 Description = (string)ea.Attribute("description"),
                                                 SubjectId = GetGuidFromEAIdentifier((string)ea.Attribute("subject")),
                                                 XmiId = GetGuidFromEAIdentifier((string)ea.Attribute("xmi.id")),
                                                 Steps = from s in ea.Descendants("step")
                                                         select new Step()
                                                         {
                                                             Id = (Guid)s.Attribute("guid"),
                                                             SubjectId = GetGuidFromEAIdentifier((string)ea.Attribute("subject")),
                                                             Name = (string)s.Attribute("name"),
                                                             Level = (int)s.Attribute("level"),
                                                             Result = (string)s.Attribute("result")                                                             
                                                             // dodać nową klasę Extension
                                                         },
                                                 UseCase = from uc in ea.Descendants("item")
                                                           select new UseCase()
                                                           {
                                                               Id = (Guid)uc.Attribute("guid"),
                                                               SubjectId = GetGuidFromEAIdentifier((string)ea.Attribute("subject")),
                                                               Name = (string)uc.Attribute("oldname")                                                               
                                                           },
                                             };
            if (!ValidateResult(result))
            {
                MessageBox.Show(
                    "Wybrany plik XML nie zawiera żadnych scenariuszy testów!", "Błąd!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataController.Analize(result);
                // Insert into database...
            }
        }

        private static bool ValidateResult(IEnumerable<EAScenario> result) => result.Any();

        private static Guid GetGuidFromEAIdentifier(string subject) => Guid.Parse(subject.Substring(5).Replace("_", "-"));
    }
}
