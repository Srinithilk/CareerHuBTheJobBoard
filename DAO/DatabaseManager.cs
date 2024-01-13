using CareerHuBTheJobBoard.Entity;
using CareerHuBTheJobBoard.MyExceptions;
using CareerHuBTheJobBoard.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CareerHuBTheJobBoard.DAO
{
    internal class DatabaseManager : IDatabaseManager
    {
        SqlConnection conn;
        public void InsertJobListing(JobListing job)
        {

            try
            {
                using (conn = DbConnUtil.GetConnection())
                {
                    string query = $"SELECT * FROM Jobs WHERE JobID={job.JobID}";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        Console.WriteLine("Job already found.Please enter new Job Id");
                    }
                    dr.Close();
                    cmd = new SqlCommand($"insert into Jobs values ('{job.JobID}','{job.CompanyID}','{job.JobTitle}','{job.JobDescription}','{job.JobLocation}','{job.Salary}','{job.JobType}','{job.PostedDate}');", conn);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("Job added successfully!");
                    else
                        Console.WriteLine("Failed to add the Job!");
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<JobListing> GetJobListings()
        {
            try
            {
                List<JobListing> job = new List<JobListing>();
                conn = DbConnUtil.GetConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Select * from Jobs";
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    job.Add(new JobListing() { JobID = (int)dr[0], CompanyID = (int)dr[1], JobTitle = dr[2].ToString(), JobDescription = dr[3].ToString(), JobLocation = dr[4].ToString(), Salary = (decimal)dr[5], JobType = dr[6].ToString(), PostedDate = (DateTime)dr[7] });
                }
                dr.Close();
                conn.Close();
                return job;
            }
            catch(Exception ex)
            {
                throw new DatabaseConnectionException("Error retrieving job listings: " + ex.Message);
            }
        }

        public List<JobListing> GetJobsPosted(Company company)
        {
            try
            {
                List<JobListing> job = new List<JobListing>();
                conn = DbConnUtil.GetConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"Select * from Jobs where CompanyID={company.CompanyID}";
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    job.Add(new JobListing() { JobID = (int)dr[0], CompanyID = (int)dr[1], JobTitle = dr[2].ToString(), JobDescription = dr[3].ToString(), JobLocation = dr[4].ToString(), Salary = (decimal)dr[5], JobType = dr[6].ToString(), PostedDate = (DateTime)dr[7] });
                }
                dr.Close();
                conn.Close();
                return job;
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionException("Error retrieving job listings: " + ex.Message);
            }
        }

        public List<JobListing> GetAlltheJobsInRange(decimal min,decimal max)
        {
            try
            {
                List<JobListing> job = new List<JobListing>();
                conn = DbConnUtil.GetConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"Select * from Jobs where Salary between {min} and {max}";
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    job.Add(new JobListing() { JobID = (int)dr[0], CompanyID = (int)dr[1], JobTitle = dr[2].ToString(), JobDescription = dr[3].ToString(), JobLocation = dr[4].ToString(), Salary = (decimal)dr[5], JobType = dr[6].ToString(), PostedDate = (DateTime)dr[7] });
                }
                dr.Close();
                conn.Close();
                return job;
            }
            catch (Exception ex)
            {
                throw new SalaryCalculationException("Error retrieving Salary Range: " + ex.Message);
            }

        }

        public void InsertCompany(Company company)
        {

            try
            {
                using (conn = DbConnUtil.GetConnection())
                {
                    string query = $"SELECT * FROM Companies WHERE CompanyID={company.CompanyID}";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        Console.WriteLine("Company already found.Please enter new Company Id");
                    }
                    dr.Close();
                    cmd = new SqlCommand($"insert into Companies values ('{company.CompanyID}','{company.CompanyName}','{company.Location}');", conn);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("Company added successfully!");
                    else
                        Console.WriteLine("Failed to add the Company!");
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Company> GetCompanies()
        {
            try 
            { 
            List<Company> company = new List<Company>();
            conn = DbConnUtil.GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * from Companies";
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                company.Add(new Company() { CompanyID = (int)dr[0], CompanyName = dr[1].ToString(), Location = dr[2].ToString() });
            }
            dr.Close();
            conn.Close();
            return company;
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionException("Error retrieving Companies: " + ex.Message);
            }
        }

        public void InsertApplicant(Applicant applicant)
        {
            try
            {
                using (conn = DbConnUtil.GetConnection())
                {
                    string query = $"SELECT * FROM Applicants WHERE ApplicantID={applicant.ApplicantID}";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        Console.WriteLine("Applicant already found.Please enter new Applicant Id");
                    }
                    dr.Close();
                    if (!applicant.Email.Contains("@"))
                    {
                        throw new InvalidEmailFormatException("Invalid Email Format.Enter Again Your Email Correctly");
                    }
                    cmd = new SqlCommand($"insert into Applicants values ('{applicant.ApplicantID}','{applicant.FirstName}','{applicant.LastName}','{applicant.Email}','{applicant.Phone}','{applicant.Resume}');", conn);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("Applicant added successfully!");
                    else
                        Console.WriteLine("Failed to add the Applicant!");
                }

            }
            catch (InvalidEmailFormatException ex)
            {
                Console.WriteLine($"\n{ex.Message}");
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Applicant> GetApplicants()
        {
            try
            { 
            List<Applicant> applicant = new List<Applicant>();
            conn = DbConnUtil.GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * from Applicants";
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                applicant.Add(new Applicant() { ApplicantID = (int)dr[0], FirstName = dr[1].ToString(), LastName = dr[2].ToString(), Email = dr[3].ToString(), Phone = dr[4].ToString(), Resume = dr[5].ToString() });
            }
            dr.Close();
            conn.Close();
            return applicant;
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionException("Error retrieving Applicants: " + ex.Message);
            }
        }
        public void InsertJobApplication(JobApplication application)
        {
            try
            {
                using (conn = DbConnUtil.GetConnection())
                {
                    string query = $"SELECT * FROM Applications WHERE ApplicationID={application.ApplicationID}";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        Console.WriteLine("Application already found.Please enter new Application Id");
                    }
                    dr.Close();
                    cmd = new SqlCommand($"insert into Applications values ('{application.ApplicationID}','{application.JobID}','{application.ApplicantID}','{application.ApplicationDate}','{application.CoverLetter}');", conn);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("Application added successfully!");
                    else
                        Console.WriteLine("Failed to add the Applicantion!");
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<JobApplication> GetApplicationsForJob(int jobID )
        {
            try
            {
            List<JobApplication> jobApplications = new List<JobApplication>();
            conn = DbConnUtil.GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"Select * from Applications where jobID = {jobID}";
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                jobApplications.Add(new JobApplication() { ApplicationID = (int)dr[0], JobID = (int)dr[1], ApplicantID = (int)dr[2], ApplicationDate =(DateTime)dr[3], CoverLetter = dr[4].ToString()});
            }
            dr.Close();
            conn.Close();
            return jobApplications;
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionException("Error retrieving job Applications: " + ex.Message);
            }
        }

        public void CreateProfile(int applicantID, string firstName, string lastName, string email, string phone,string resume)
        {
            try
            {
                using (conn = DbConnUtil.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand($"insert into Applicants values ('{applicantID}','{firstName}','{lastName}','{email}','{phone}','{resume}');", conn);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("Applicant Profile Created Successfully");
                    else
                        Console.WriteLine("Failed to Create Profile!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
