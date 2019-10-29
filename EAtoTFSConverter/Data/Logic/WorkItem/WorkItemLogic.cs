using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAtoTFSConverter.Data.Logic
{
    class WorkItemLogic
    {
        internal void PrepareData(Project project)
        {
            TestPlan testPlan = new TestPlan();
            testPlan.CheckIfExists(project);
        }
    }
}
