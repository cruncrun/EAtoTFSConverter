using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAtoTFSConverter.Data.DBOperations;
using EAtoTFSConverter.Data.XMLParse;

namespace EAtoTFSConverter.Data
{
    static class DataController
    {
        public static void Analize(IEnumerable<XMLParse.EAScenario> result)
        {
            /*  1.  Check if EAScenario exists (compare guid)
             *      a.  Doesn't exist - insert
             *      b.  Exists - update
             *  2.  Check if UseCase exists
             *      a.  Doesn't exist - insert
             *      b.  Exists - update
             *  3.  Check if Step exists
             *      a.  Doesn't exist - insert
             *      b.  Exists - update
             *      
             */

            foreach (XMLParse.EAScenario scenario in result)
            {
                using (DataClassesDataContext dataContext = new DataClassesDataContext())
                {
                    EAScenario s = new EAScenario
                    {
                        SubjectId = scenario.SubjectId,
                        XmiId = scenario.XmiId,
                        Name = scenario.Name,
                        Type = scenario.Type,   
                        Description = scenario.Description
                    };

                    dataContext.EAScenarios.InsertOnSubmit(s);
                    dataContext.EAScenarios.InsertOnSubmit(scenario);
                    dataContext.SubmitChanges();

                    /*
                    var query = from s in dataContext.EAScenarios
                                where s.SubjectId == subjectId
                                select s;
                    */
                }
                DataMapper.CheckIfExists(scenario.SubjectId);
            }
        }

        
    }
}
