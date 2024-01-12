using CareerHuBTheJobBoard.Entity;
using CareerHuBTheJobBoard.MyExceptions;
using CareerHuBTheJobBoard.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    SqlCommand cmd = new SqlCommand($"insert into Jobs values ('{job.JobID}','{job.CompanyID}','{job.JobTitle}','{job.JobDescription}','{job.JobLocation}','{job.Salary}','{job.JobType}','{job.PostedDate}');", conn);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("Job added successfully!");
                    else
                        Console.WriteLine("Failed to add the Job!");
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

        public void InsertCompany(Company company)
        {

            try
            {
                using (conn = DbConnUtil.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand($"insert into Companies values ('{company.CompanyID}','{company.CompanyName}','{company.Location}');", conn);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("Company added successfully!");
                    else
                        Console.WriteLine("Failed to add the Company!");
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
        public void InsertApplicant(Applicant applicant)
        {
            try
            {
                using (conn = DbConnUtil.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand($"insert into Applicants values ('{applicant.ApplicantID}','{applicant.FirstName}','{applicant.LastName}','{applicant.Email}','{applicant.Phone}','{applicant.Resume}');", conn);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("Applicant added successfully!");
                    else
                        Console.WriteLine("Failed to add the Applicant!");
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
        public void InsertJobApplication(JobApplication application)
        {
            try
            {
                using (conn = DbConnUtil.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand($"insert into Applications values ('{application.ApplicationID}','{application.JobID}','{application.ApplicantID}','{application.ApplicationDate}','{application.CoverLetter}');", conn);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("Applicantion added successfully!");
                    else
                        Console.WriteLine("Failed to add the Applicantion!");
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

        public List<Company> GetCompanies()
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

        public List<Applicant> GetApplicants()
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

        public List<JobApplication> GetApplicationsForJob()
        {
            List<JobApplication> jobApplications = new List<JobApplication>();
            conn = DbConnUtil.GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"Select * from Applications";
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
    }
}
