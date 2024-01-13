using CareerHuBTheJobBoard.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CareerHuBTheJobBoard.DAO
{
    interface IDatabaseManager
    {
        void InsertJobListing(JobListing job);
        List<JobListing> GetJobListings();
        List<JobListing> GetJobsPosted(Company company);
        List<JobListing> GetAlltheJobsInRange(decimal min,decimal max);
        void InsertCompany(Company company);
        List<Company> GetCompanies();
        void InsertApplicant(Applicant applicant);
        List<Applicant> GetApplicants();
        void InsertJobApplication(JobApplication application);
        List<JobApplication> GetApplicationsForJob(int jobID);
        void CreateProfile(int applicantID, string firstName, string lastName, string email, string phone, string resume);
    }

}
