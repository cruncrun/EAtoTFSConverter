﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EAtoTFSConverter.Data.XMLParse
{
    internal static class XMLParse
    {
        public static void Parse(XDocument source, Project project)
        {
            var result = from ea in source.Descendants("EAScenario")
                select new EAScenario
                {
                    Id = Guid.NewGuid(),
                    XmiId = (string) ea.Attribute("xmi.id"),
                    SubjectId = (string) ea.Attribute("subject"),
                    ProjectId = project.Id,
                    Name = (string) ea.Attribute("name"),
                    Type = (string) ea.Attribute("type"),
                    Description = (string) ea.Attribute("description"),
                    Steps = from s in ea.Descendants("step")
                        select new Step
                        {
                            Guid = (Guid) s.Attribute("guid"),
                            SubjectId = (string) ea.Attribute("subject"),
                            Name = (string) s.Attribute("name"),
                            Level = (int) s.Attribute("level"),
                            Result = (string) s.Attribute("result")
                        },
                    UseCase = from uc in ea.Descendants("item")
                        select new UseCase
                        {
                            Guid = (Guid) uc.Attribute("guid"),
                            SubjectId = (string) ea.Attribute("subject"),
                            Name = (string) uc.Attribute("oldname")
                        }
                };
            if (!ValidateResult(result))
            {
                MessageBox.Show(
                    "Wybrany plik XML nie zawiera żadnych scenariuszy testów!", "Błąd!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                var dc = new ParsedDataController(project);
                dc.PrepareData(result);
            }
        }

        private static bool ValidateResult(IEnumerable<EAScenario> result)
        {
            return result.Any();
        }
    }
}