using CareerHuBTheJobBoard.DAO;
using CareerHuBTheJobBoard.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CareerHuBTheJobBoard
{
    internal class MainModule
    {
        static SqlConnection conn;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("========================");
                Console.WriteLine("CAREER HUB THE JOB BOARD");
                Console.WriteLine("========================");
                Console.WriteLine("Menu:");
                Console.WriteLine("-----------");
                Console.WriteLine("JobListings");
                Console.WriteLine("-----------");
                Console.WriteLine("1. Insert JobListing");
                Console.WriteLine("2. Getall JobListing");
                Console.WriteLine("3. Get Jobs Posted By Company");
                Console.WriteLine("4. List All Jobs In Salary Range");
                Console.WriteLine("-------");
                Console.WriteLine("Company");
                Console.WriteLine("-------");
                Console.WriteLine("5. Insert Company");
                Console.WriteLine("6. Getall Company");
                Console.WriteLine("---------");
                Console.WriteLine("Applicant");
                Console.WriteLine("---------");
                Console.WriteLine("7. Insert Applicant");
                Console.WriteLine("8. Getall Applicant");
                Console.WriteLine("9. Create Applicant Profile");
                Console.WriteLine("--------------");
                Console.WriteLine("JobApplication");
                Console.WriteLine("--------------");
                Console.WriteLine("10. Insert JobApplication");
                Console.WriteLine("11. Getall JobApplication by Job ID");
                Console.WriteLine("12. EXIT");
                Console.WriteLine();
                Console.Write("Enter your choice: ");
                int z = int.Parse(Console.ReadLine());

                switch (z)
                {
                    case 1:
                        try
                        {
                            IDatabaseManager databaseManager = new DatabaseManager();
                            Console.WriteLine("Enter the Job Details for insert into the Database");
                            JobListing job = new JobListing();
                            Console.WriteLine("Enter the JobID:");
                            job.JobID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the CompanyID:");
                            job.CompanyID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the JobTitle:");
                            job.JobTitle = Console.ReadLine();
                            Console.WriteLine("Enter the JobDescription:");
                            job.JobDescription = Console.ReadLine();
                            Console.WriteLine("Enter the Joblocation:");
                            job.JobLocation = Console.ReadLine();
                            Console.WriteLine("Enter the Salary:");
                            job.Salary = Convert.ToDecimal(Console.ReadLine());
                            Console.WriteLine("Enter the JobType:");
                            job.JobType = Console.ReadLine();
                            Console.WriteLine("Enter the PostedDate:");
                            job.PostedDate = Convert.ToDateTime(Console.ReadLine());
                            databaseManager.InsertJobListing(job);
                            Console.WriteLine($"{job.JobID} \n {job.CompanyID}\n {job.JobTitle} \n {job.JobDescription}\n {job.JobLocation} \n {job.Salary}\n {job.JobType} \n {job.PostedDate}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 2:
                        try
                        {
                            IDatabaseManager databaseManager = new DatabaseManager();
                            List<JobListing> joblist = databaseManager.GetJobListings();
                            foreach (JobListing j in joblist)
                            {
                                Console.WriteLine($"{j.JobID}\n {j.CompanyID}\n {j.JobTitle}\n {j.JobDescription}\n {j.JobLocation}\n {j.Salary}\n {j.JobType}\n {j.PostedDate}");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 3:
                        try
                        {
                            IDatabaseManager databaseManager = new DatabaseManager();
                            Console.WriteLine("Enter Company ID");
                            Company company = new Company();
                            company.CompanyID = Convert.ToInt32(Console.ReadLine());
                            List<JobListing> joblistpost = databaseManager.GetJobsPosted(company);
                            foreach (JobListing jl in joblistpost)
                            {
                                Console.WriteLine($"{jl.JobID}\t {jl.CompanyID}\t {jl.JobTitle}\t {jl.JobDescription}\t {jl.JobLocation}\t {jl.Salary}\t {jl.JobType}\t {jl.PostedDate}");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 4:
                        try
                        {
                            IDatabaseManager databaseManager = new DatabaseManager();
                            Console.WriteLine("Enter Min and Max Salary to search : ");
                            Console.Write("Max Salary : ");
                            int max = int.Parse(Console.ReadLine());
                            Console.Write("Min Salary : ");
                            int min = int.Parse(Console.ReadLine());
                            List<JobListing> jblist = databaseManager.GetAlltheJobsInRange(min,max);
                      
                            foreach (JobListing jbl in jblist)
                            {
                                Console.WriteLine($"{jbl.JobID}\t {jbl.CompanyID}\t {jbl.JobTitle}\t {jbl.JobDescription}\t {jbl.JobLocation}\t {jbl.Salary}\t {jbl.JobType}\t {jbl.PostedDate}");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 5:
                        try
                        {
                            IDatabaseManager databaseManager = new DatabaseManager();
                            Console.WriteLine("Enter the Company Details for insert into the Database");
                            Company company = new Company();
                            Console.WriteLine("Enter the CompanyID:");
                            company.CompanyID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the CompanyName:");
                            company.CompanyName = Console.ReadLine();
                            Console.WriteLine("Enter the JobLocation:");
                            company.Location = Console.ReadLine();
                            databaseManager.InsertCompany( company);
                            Console.WriteLine($"{company.CompanyID} \n {company.CompanyName}\n {company.Location}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 6:
                        try
                        {
                            IDatabaseManager databaseManager = new DatabaseManager();
                            List<Company> com = databaseManager.GetCompanies();
                            foreach (Company c in com)
                            {
                                Console.WriteLine($"{c.CompanyID}\t {c.CompanyName}\t {c.Location}");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 7:
                        try
                        {
                            IDatabaseManager databaseManager = new DatabaseManager();
                            Console.WriteLine("Enter the Applicant Details for insert into the Database");
                            Applicant applicant= new Applicant();
                            Console.WriteLine("Enter the Applicant ID:");
                            applicant.ApplicantID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the Firstname:");
                            applicant.FirstName = Console.ReadLine();
                            Console.WriteLine("Enter the Lastname:");
                            applicant.LastName = Console.ReadLine();
                            Console.WriteLine("Enter the EmailID:");
                            applicant.Email = Console.ReadLine();
                            Console.WriteLine("Enter the Phone Number:");
                            applicant.Phone = Console.ReadLine();
                            Console.WriteLine("Enter the ResumeDetails:");
                            applicant.Resume = Console.ReadLine();
                            databaseManager.InsertApplicant(applicant);
                            Console.WriteLine($"{applicant.ApplicantID} \n {applicant.FirstName} \n {applicant.LastName} \n {applicant.Email} \n {applicant.Phone} \n {applicant.Resume}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 8:
                        try
                        {
                            IDatabaseManager databaseManager = new DatabaseManager();
                            List<Applicant> jobapp = databaseManager.GetApplicants();
                            foreach (Applicant ja in jobapp)
                            {
                                Console.WriteLine($"{ja.ApplicantID}\n {ja.FirstName}\n {ja.LastName}\n {ja.Email}\n {ja.Phone}\n {ja.Resume}");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 9:
                        try
                        {
                            IDatabaseManager databaseManager = new DatabaseManager();
                            Console.WriteLine("Enter the Applicant Details for insert into the Database");
                            Applicant applicant = new Applicant();
                            Console.WriteLine("Enter the Applicant ID:");
                            applicant.ApplicantID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the First Name:");
                            applicant.FirstName = Console.ReadLine();
                            Console.WriteLine("Enter the Last Name:");
                            applicant.LastName = Console.ReadLine();
                            Console.WriteLine("Enter the Email:");
                            applicant.Email = Console.ReadLine();
                            Console.WriteLine("Enter the Phone Number:");
                            applicant.Phone = Console.ReadLine();
                            Console.WriteLine("Enter the ResumeDetails:");
                            applicant.Resume = Console.ReadLine();
                            databaseManager.CreateProfile(applicant.ApplicantID,applicant.FirstName,applicant.LastName,applicant.Email,applicant.Phone,applicant.Resume);
                            Console.WriteLine($"{applicant.ApplicantID} \n {applicant.FirstName} \n {applicant.LastName} \n {applicant.Email} \n {applicant.Phone} \n {applicant.Resume}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 10:
                        try
                        {
                            IDatabaseManager databaseManager = new DatabaseManager();
                            Console.WriteLine("Enter the Applicantion Details for insert into the Database");
                            JobApplication application = new JobApplication();
                            Console.WriteLine("Enter the Application ID:");
                            application.ApplicationID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the JobID:");
                            application.JobID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the ApplicantID:");
                            application.ApplicantID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the Application Date:");
                            application.ApplicationDate = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Enter the CoverLetter:");
                            application.CoverLetter = Console.ReadLine();
                            databaseManager.InsertJobApplication(application);
                            Console.WriteLine($"{application.ApplicationID} \n {application.JobID} \n {application.ApplicationID} \n {application.ApplicationDate} \n {application.CoverLetter}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 11:
                        try
                        {
                            IDatabaseManager databaseManager = new DatabaseManager();
                            JobApplication application = new JobApplication();
                            Console.WriteLine("Enter Job ID");
                            application.JobID= Convert.ToInt32(Console.ReadLine());
                            List<JobApplication> jobapplic = databaseManager.GetApplicationsForJob(application.JobID);
                            foreach (JobApplication jap in jobapplic)
                            {
                                Console.WriteLine($"{jap.ApplicationID}\t {jap.JobID}\t {jap.ApplicantID}\t {jap.ApplicationDate}\t {jap.CoverLetter}\t");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 12:
                        Console.WriteLine("Exiting..!");
                        Console.ReadLine();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid choice!");
                        break;
                }
            }
        }
    }
}
