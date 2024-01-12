using CareerHuBTheJobBoard.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CareerHuBTheJobBoard.DAO
{
     interface IDatabaseManager
    {
        void InsertJobListing(JobListing job);
        List<JobListing> GetJobListings();
        void InsertCompany(Company company);
        List<Company> GetCompanies();
        void InsertApplicant(Applicant applicant);
        List<Applicant> GetApplicants();
        void InsertJobApplication(JobApplication application);
        //List<JobApplication> GetApplicationsForJob(int jobID);
        List<JobApplication> GetApplicationsForJob();
    }
}
