using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.DBOperations
{
    static class DataMapper
    {
        public static void CheckIfExists(Guid subjectId)
        {
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {

                /*
                var query = from s in dataContext.EAScenarios
                            where s.SubjectId == subjectId
                            select s;
                */
            }
            
        }
    }
}
