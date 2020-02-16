using EAtoTFSConverter.Data.Logic.WorkItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EAtoTFSConverter.Data.Logic
{
    internal class DatabaseOperations
    {
        private static readonly DataClassesDataContext DataContext = new DataClassesDataContext();
        internal IEnumerable<active_EAscenario> GetActive_EAscenarios(Project selectedProject)
        {
            return DataContext.active_EAscenarios.Where(s => s.ProjectId == selectedProject.Id).ToList();
        }

        internal IEnumerable<active_Step> GetActive_Steps(Guid id)
        {
            return DataContext.active_Steps.Where(s => s.EAScenarioId == id).ToList();
        }

        internal IEnumerable<active_Step> GetActive_Steps()
        {
            return DataContext.active_Steps.ToList();
        }

        internal EAScenario getEAscenario(Guid? guid)
        {
            return DataContext.EAScenarios.FirstOrDefault(s => s.Id == guid);
        }

        internal Step GetStep(Guid? guid)
        {
            return DataContext.Steps.FirstOrDefault(s => s.Id == guid);
        }

        internal bool CheckWorkItem(Guid projectId, WorkItemType workItemType)
        {
            return DataContext.WorkItems.Count(w => w.ProjectId == projectId && w.WorkItemType == (int)workItemType) > 0;
        }

        internal int GetWorkItem(Guid projectId, WorkItemType workItemType)
        {
            return DataContext.WorkItems
                .Where(w => w.ProjectId == projectId && w.WorkItemType == (int)workItemType)
                .Select(i => i.WorkItemId)
                .FirstOrDefault();
        }

        internal IEnumerable<int> GetWorkItems(Guid projectId, WorkItemType workItemType)
        {
            return DataContext.WorkItems
                .Where(w => w.ProjectId == projectId && w.WorkItemType == (int) workItemType)
                .Select(i => i.WorkItemId)
                .Distinct();
        }

        internal string GetPersonalToken(Project project)
        {
            return DataContext.Projects
                .Where(p => p.Id == project.Id)
                .Select(t => t.AuthorizationToken)
                .FirstOrDefault()?
                .ToString();
        }

        internal string GetUriAddress(Project project)
        {
            return DataContext.Projects
                .Where(p => p.Id == project.Id)
                .Select(t => t.Address)
                .FirstOrDefault()?
                .ToString();
        }

        internal WorkItem GetWorkItem(Guid id)
        {
            return DataContext.WorkItems.FirstOrDefault(w => w.Id == id);
        }

        internal bool Insert(List<EAScenario> scenarios)
        {
            bool result;
            try
            {
                DataContext.EAScenarios.InsertAllOnSubmit(scenarios);
                DataContext.SubmitChanges();
                result = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "W aplikacji wystąpił błąd!\n" + e, "Błąd!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }
            return result;
        }

        internal bool Insert(List<UseCase> useCases)
        {
            bool result;
            try
            {
                DataContext.UseCases.InsertAllOnSubmit(useCases);
                DataContext.SubmitChanges();
                result = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "W aplikacji wystąpił błąd!\n" + e, "Błąd!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }
            return result;
        }

        internal bool Insert(List<Step> steps)
        {
            bool result;
            try
            {
                DataContext.Steps.InsertAllOnSubmit(steps);
                DataContext.SubmitChanges();
                result = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "W aplikacji wystąpił błąd!\n" + e, "Błąd!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }
            return result;
        }
        internal void Insert(WorkItem workItem)
        {
            try
            {
                DataContext.WorkItems.InsertOnSubmit(workItem);
                DataContext.SubmitChanges();
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
