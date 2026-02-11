using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        internal void CreateNewIssue(AccountData account, IssueData issueData, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public List<ProjectData> GetProjectListByAPI()
        {
            List<ProjectData> projects = new List<ProjectData>();

            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();

            Mantis.ProjectData[] projectsMantis = client.mc_projects_get_user_accessible(adminUsername, adminPassword);

            foreach (Mantis.ProjectData project in projectsMantis)
            {
                projects.Add(new ProjectData()
                {
                    Name = project.name,
                    Id = project.id,
                    Link = "http://localhost:8443/mantisbt/manage_proj_edit_page.php?project_id=" + project.id,
                });
            }
            return projects;
        }

        public void CreateProjectByAPI(ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData mantistProject = new Mantis.ProjectData();
            mantistProject.name = project.Name;

            client.mc_project_add(adminUsername, adminPassword, mantistProject);
        }
    }
}
