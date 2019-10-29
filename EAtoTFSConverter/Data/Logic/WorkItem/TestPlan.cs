using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.Logic
{
    class TestPlan : IWorkItemBase, IWorkItemCreateLogic
    {
        public int WorkItemId { get; set; }

        public bool CheckIfExists(Project project)
        {            
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                return true;
            }            
        }

        public void CreateWorkItem()
        {
            throw new NotImplementedException();
        }
    }
}
