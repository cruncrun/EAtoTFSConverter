using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EAtoTFSConverter.Data
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }        
        public Project()
        {

        }
    }

    public class Projects
    {
        public IEnumerable<EAtoTFSConverter.Project> ProjectList { get; set; }


        public Projects()
        {
            ProjectList = GetAllProjects();
        }

        public IEnumerable<EAtoTFSConverter.Project> GetAllProjects()
        {
            IEnumerable<EAtoTFSConverter.Project> queryAllProjects;
            
            try
            {
                using (DataClassesDataContext dataContext = new DataClassesDataContext())
                {
                    queryAllProjects = from projects in dataContext.Projects
                                       select projects;
                    return queryAllProjects;                    
                }                
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "W aplikacji wystąpił błąd!\n" + e, "Błąd!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }
        }
    }
}
