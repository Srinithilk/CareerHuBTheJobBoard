using CareerHuBTheJobBoard.DAO;
using CareerHuBTheJobBoard.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHuBTheJobBoard
{
    internal class MainModule
    {
        static SqlConnection conn;
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO THE JOB BOARD");
            Console.WriteLine("========================");
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("----");
                Console.WriteLine();
                Console.WriteLine("JOB LISTING");
                Console.WriteLine("-----------");
                Console.WriteLine("1. Insert JobListing");
                Console.WriteLine("2. Getall JobListing");
                Console.WriteLine("Company");
                Console.WriteLine("-------");
                Console.WriteLine("3. Insert Company");
                Console.WriteLine("4. Getall Company");
                Console.WriteLine("Applicant");
                Console.WriteLine("---------");
                Console.WriteLine("5. Insert Applicant");
                Console.WriteLine("6. Getall Applicant");
                Console.WriteLine("JobApplication");
                Console.WriteLine("---------");
                Console.WriteLine("7. Insert JobApplication");
                Console.WriteLine("8. Getall JobApplication");
                Console.WriteLine("9. EXIT");
                Console.WriteLine();
                Console.Write("Enter your choice: ");
                int x = int.Parse(Console.ReadLine());

                switch (x)
                {
                    case 1:
                        try
                        {
                            IDatabaseManager databaseManager = new DatabaseManager();
                            Console.WriteLine("Enter the JobID,CompanyID,JobTitle,JobDescription,JobLocation,Salary,JobType,PostedDate for insert into the Database");
                            JobListing job = new JobListing();
                            job.JobID = Convert.ToInt32(Console.ReadLine());
                            job.CompanyID = Convert.ToInt32(Console.ReadLine());
                            job.JobTitle = Console.ReadLine();
                            job.JobDescription = Console.ReadLine();
                            job.JobLocation = Console.ReadLine();
                            job.Salary = Convert.ToDecimal(Console.ReadLine());
                            job.JobType = Console.ReadLine();
                            job.PostedDate = Convert.ToDateTime(Console.ReadLine());
                            //Console.WriteLine( databaseManager.InsertJobListing(JobListing job);
                            databaseManager.InsertJobListing(job);
                            Console.WriteLine($"{job.JobID} \n {job.CompanyID}\n {job.JobTitle} \n {job.JobDescription}\n {job.JobLocation} \n {job.Salary}\n {job.JobType} \n {job.PostedDate}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        continue;
                    case 2:
                        try
                        {
                            IDatabaseManager databaseManager = new DatabaseManager();
                            List<JobListing> joblist = databaseManager.GetJobListings();
                            foreach (JobListing j in joblist)
                            {
                                Console.WriteLine($"{j.JobID}\t {j.CompanyID}\t {j.JobTitle}\t {j.JobDescription}\t {j.JobLocation}\t {j.Salary}\t {j.JobType}\t {j.PostedDate}");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        continue;
                    case 3:
                        try
                        {
                            IDatabaseManager databaseManager = new DatabaseManager();
                            Console.WriteLine("Enter the CompanyID,CompanyName,Location for insert into the Database");
                            Company company = new Company();
                            company.CompanyID = Convert.ToInt32(Console.ReadLine());
                            company.CompanyName = Console.ReadLine();
                            company.Location = Console.ReadLine();
                            //Console.WriteLine( databaseManager.InsertCompany(Company company);
                            databaseManager.InsertCompany( company);
                            Console.WriteLine($"{company.CompanyID} \n {company.CompanyName}\n {company.Location}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        continue;
                    case 4:
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
                        continue;
                    case 5:
                        try
                        {
                            IDatabaseManager databaseManager = new DatabaseManager();
                            Console.WriteLine("Enter the ApplicantID,FirstName,LastName,Email,Phone,Resume for insert into the Database");
                            Applicant applicant= new Applicant();
                            applicant.ApplicantID = Convert.ToInt32(Console.ReadLine());
                            applicant.FirstName = Console.ReadLine();
                            applicant.LastName = Console.ReadLine();
                            applicant.Email = Console.ReadLine();
                            applicant.Phone = Console.ReadLine();
                            applicant.Resume = Console.ReadLine();
                            //Console.WriteLine( databaseManager.InsertApplicant(applicant);
                            databaseManager.InsertApplicant(applicant);
                            Console.WriteLine($"{applicant.ApplicantID} \n {applicant.FirstName} \n {applicant.LastName} \n {applicant.Email} \n {applicant.Phone} \n {applicant.Resume}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        continue;
                    case 6:
                        try
                        {
                            IDatabaseManager databaseManager = new DatabaseManager();
                            List<Applicant> jobapp = databaseManager.GetApplicants();
                            foreach (Applicant ja in jobapp)
                            {
                                Console.WriteLine($"{ja.ApplicantID}\t {ja.FirstName}\t {ja.LastName}\t {ja.Email}\t {ja.Phone}\t {ja.Resume}");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        continue;
                    case 7:
                        try
                        {
                            IDatabaseManager databaseManager = new DatabaseManager();
                            Console.WriteLine("Enter the ApplicantionID,JobID,ApplicantID,ApplicationDate,CoverLetter for insert into the Database");
                            JobApplication application = new JobApplication();
                            application.ApplicationID = Convert.ToInt32(Console.ReadLine());
                            application.JobID = Convert.ToInt32(Console.ReadLine());
                            application.ApplicantID = Convert.ToInt32(Console.ReadLine());
                            application.ApplicationDate = Convert.ToDateTime(Console.ReadLine());
                            application.CoverLetter = Console.ReadLine();
                            //Console.WriteLine(  databaseManager.InsertJobApplication(application);
                            databaseManager.InsertJobApplication(application);
                            Console.WriteLine($"{application.ApplicationID} \n {application.JobID} \n {application.ApplicationID} \n {application.ApplicationDate} \n {application.CoverLetter}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        continue;
                    case 8:
                        try
                        {
                            IDatabaseManager databaseManager = new DatabaseManager();
                            List<JobApplication> jobapplic = databaseManager.GetApplicationsForJob();
                            foreach (JobApplication jap in jobapplic)
                            {
                                Console.WriteLine($"{jap.ApplicationID}\t {jap.JobID}\t {jap.ApplicantID}\t {jap.ApplicationDate}\t {jap.CoverLetter}\t");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        continue;
                    case 9:
                        Console.WriteLine("Exiting program.");
                        Console.ReadLine();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        continue;
                }
            }
        }
    }
}
