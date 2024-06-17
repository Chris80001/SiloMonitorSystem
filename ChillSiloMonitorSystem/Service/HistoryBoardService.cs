using ChillSiloMonitorSystem.Common;
using ChillSiloMonitorSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ChillSiloMonitorSystem.Service
{
    public class HistoryBoardService
    {
        private string _strProductVersion = "ChilinSiloMonitorSystem";
        private string _strModule = "HistoryBoardService";
        private Boolean _isError = false;
        private string _strErrorMessage = string.Empty;

        public List<Employee> GetEmployeeList()
        {
            string strProcedure = "GetEmployeeList";

            List<Employee> result = new List<Employee>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("Select ID, HeadID, FullName, Prefix, Title, City, State, Email, " +
                                                            "Skype, MobilePhone, BirthDate, HireDate " +
                                                            "From Employee " +
                                                    //"Where DebitInventoryTime between @StartTime And @EndTime " +
                                                    "Order by ID, HeadID ", conn);
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee Employee = new Employee();
                            //ID
                            Employee.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                            //HeadID
                            Employee.HeadID = reader.GetInt32(reader.GetOrdinal("HeadID"));
                            //Prefix
                            if (!reader.IsDBNull(reader.GetOrdinal("Prefix")))
                                Employee.Prefix = reader["Prefix"].ToString();
                            else
                                Employee.Prefix = null;
                            //Title
                            if (!reader.IsDBNull(reader.GetOrdinal("Title")))
                                Employee.Title = reader["Title"].ToString();
                            else
                                Employee.Title = null;
                            //City
                            if (!reader.IsDBNull(reader.GetOrdinal("City")))
                                Employee.City = reader["City"].ToString();
                            else
                                Employee.City = null;
                            //State
                            if (!reader.IsDBNull(reader.GetOrdinal("State")))
                                Employee.State = reader["State"].ToString();
                            else
                                Employee.State = null;
                            //Email
                            if (!reader.IsDBNull(reader.GetOrdinal("Email")))
                                Employee.Email = reader["Email"].ToString();
                            else
                                Employee.Email = null;
                            //Skype
                            if (!reader.IsDBNull(reader.GetOrdinal("Skype")))
                                Employee.Skype = reader["Skype"].ToString();
                            else
                                Employee.Skype = null;
                            //MobilePhone
                            if (!reader.IsDBNull(reader.GetOrdinal("MobilePhone")))
                                Employee.MobilePhone = reader["MobilePhone"].ToString();
                            else
                                Employee.MobilePhone = null;
                            //BirthDate
                            if (!reader.IsDBNull(reader.GetOrdinal("BirthDate")))
                                Employee.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
                            else
                                Employee.BirthDate = new DateTime();
                            //HireDate
                            if (!reader.IsDBNull(reader.GetOrdinal("HireDate")))
                                Employee.HireDate = Convert.ToDateTime(reader["HireDate"]);
                            else
                                Employee.HireDate = new DateTime();


                            result.Add(Employee);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    _isError = true;
                    _strErrorMessage = WriteContext.ErrorReturn(_strProductVersion, _strModule, strProcedure, ex.Message.ToString());
                }
            }
            return result;
        }

        public List<Employee> GetEmployeeList(string Department)
        {
            string strProcedure = "GetEmployeeList";

            List<Employee> result = new List<Employee>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("Select ID, HeadID, FullName, Prefix, Title, City, State, Email, " +
                                                            "Skype, MobilePhone, BirthDate, HireDate " +
                                                            "From Employee " +
                                                    "Where State = @Department " +
                                                    "Order by ID, HeadID ", conn);

                command.Parameters.AddWithValue("@Department", Department);

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee Employee = new Employee();
                            //ID
                            Employee.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                            //HeadID
                            Employee.HeadID = reader.GetInt32(reader.GetOrdinal("HeadID"));
                            //FullName
                            if (!reader.IsDBNull(reader.GetOrdinal("FullName")))
                                Employee.FullName = reader["FullName"].ToString();
                            else
                                Employee.FullName = null;
                            //Prefix
                            if (!reader.IsDBNull(reader.GetOrdinal("Prefix")))
                                Employee.Prefix = reader["Prefix"].ToString();
                            else
                                Employee.Prefix = null;
                            //Title
                            if (!reader.IsDBNull(reader.GetOrdinal("Title")))
                                Employee.Title = reader["Title"].ToString();
                            else
                                Employee.Title = null;
                            //City
                            if (!reader.IsDBNull(reader.GetOrdinal("City")))
                                Employee.City = reader["City"].ToString();
                            else
                                Employee.City = null;
                            //State
                            if (!reader.IsDBNull(reader.GetOrdinal("State")))
                                Employee.State = reader["State"].ToString();
                            else
                                Employee.State = null;
                            //Email
                            if (!reader.IsDBNull(reader.GetOrdinal("Email")))
                                Employee.Email = reader["Email"].ToString();
                            else
                                Employee.Email = null;
                            //Skype
                            if (!reader.IsDBNull(reader.GetOrdinal("Skype")))
                                Employee.Skype = reader["Skype"].ToString();
                            else
                                Employee.Skype = null;
                            //MobilePhone
                            if (!reader.IsDBNull(reader.GetOrdinal("MobilePhone")))
                                Employee.MobilePhone = reader["MobilePhone"].ToString();
                            else
                                Employee.MobilePhone = null;
                            //BirthDate
                            if (!reader.IsDBNull(reader.GetOrdinal("BirthDate")))
                                Employee.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
                            else
                                Employee.BirthDate = new DateTime();
                            //HireDate
                            if (!reader.IsDBNull(reader.GetOrdinal("HireDate")))
                                Employee.HireDate = Convert.ToDateTime(reader["HireDate"]);
                            else
                                Employee.HireDate = new DateTime();


                            result.Add(Employee);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    _isError = true;
                    _strErrorMessage = WriteContext.ErrorReturn(_strProductVersion, _strModule, strProcedure, ex.Message.ToString());
                }
            }
            return result;
        }

        public List<HistoryBoardPathDyeing> GetHistoryBoardPathDyeingList()
        {
            string strProcedure = "GetHistoryBoardPathDyeingList";

            List<HistoryBoardPathDyeing> result = new List<HistoryBoardPathDyeing>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("Select Id, SettingRowDataId, Sort, Department, PLC, TagAddress, ShowLocation, StartTime, " +
                                                            "Path, EndTime, SaveTime " +
                                                            "From HistoryBoardPathDyeing " +
                                                    "Order by SaveTime desc ", conn);

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HistoryBoardPathDyeing HistoryBoardPathDyeing = new HistoryBoardPathDyeing();
                            //Id
                            HistoryBoardPathDyeing.Id = reader["Id"].ToString();
                            //SettingRowDataId
                            HistoryBoardPathDyeing.SettingRowDataId = reader["SettingRowDataId"].ToString();
                            //Sort
                            if (!reader.IsDBNull(reader.GetOrdinal("Sort")))
                                HistoryBoardPathDyeing.Sort = reader.GetInt32(reader.GetOrdinal("Sort"));
                            else
                                HistoryBoardPathDyeing.Sort = 0;
                            //Department
                            if (!reader.IsDBNull(reader.GetOrdinal("Department")))
                                HistoryBoardPathDyeing.Department = reader["Department"].ToString();
                            else
                                HistoryBoardPathDyeing.Department = null;
                            //PLC
                            if (!reader.IsDBNull(reader.GetOrdinal("PLC")))
                                HistoryBoardPathDyeing.PLC = reader["PLC"].ToString();
                            else
                                HistoryBoardPathDyeing.PLC = null;
                            //TagAddress
                            if (!reader.IsDBNull(reader.GetOrdinal("TagAddress")))
                                HistoryBoardPathDyeing.TagAddress = reader["TagAddress"].ToString();
                            else
                                HistoryBoardPathDyeing.TagAddress = null;
                            //ShowLocation
                            if (!reader.IsDBNull(reader.GetOrdinal("ShowLocation")))
                                HistoryBoardPathDyeing.ShowLocation = reader["ShowLocation"].ToString();
                            else
                                HistoryBoardPathDyeing.ShowLocation = null;
                            //StartTime
                            if (!reader.IsDBNull(reader.GetOrdinal("StartTime")))
                                HistoryBoardPathDyeing.StartTime = Convert.ToDateTime(reader["StartTime"]);
                            else
                                HistoryBoardPathDyeing.StartTime = null;
                            //Path
                            if (!reader.IsDBNull(reader.GetOrdinal("Path")))
                                HistoryBoardPathDyeing.Path = reader["Path"].ToString();
                            else
                                HistoryBoardPathDyeing.Path = null;
                            //EndTime
                            if (!reader.IsDBNull(reader.GetOrdinal("EndTime")))
                                HistoryBoardPathDyeing.EndTime = Convert.ToDateTime(reader["EndTime"]);
                            else
                                HistoryBoardPathDyeing.EndTime = null;
                            //SaveTime
                            if (!reader.IsDBNull(reader.GetOrdinal("SaveTime")))
                                HistoryBoardPathDyeing.SaveTime = Convert.ToDateTime(reader["SaveTime"]);
                            else
                                HistoryBoardPathDyeing.SaveTime = new DateTime();

                            result.Add(HistoryBoardPathDyeing);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    _isError = true;
                    _strErrorMessage = WriteContext.ErrorReturn(_strProductVersion, _strModule, strProcedure, ex.Message.ToString());
                }
            }
            return result;
        }

        public List<HistoryBoardPathMultiple> GetHistoryBoardPathMultipleList()
        {
            string strProcedure = "GetHistoryBoardPathMultipleList";

            List<HistoryBoardPathMultiple> result = new List<HistoryBoardPathMultiple>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("Select Id, SettingRowDataId, Sort, Department, PLC, TagAddress, ShowLocation, StartTime, " +
                                                            "Path, EndTime, SaveTime " +
                                                            "From HistoryBoardPathMultiple " +
                                                    "Order by SaveTime desc ", conn);

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HistoryBoardPathMultiple HistoryBoardPathMultiple = new HistoryBoardPathMultiple();
                            //Id
                            HistoryBoardPathMultiple.Id = reader["Id"].ToString();
                            //SettingRowDataId
                            HistoryBoardPathMultiple.SettingRowDataId = reader["SettingRowDataId"].ToString();
                            //Sort
                            if (!reader.IsDBNull(reader.GetOrdinal("Sort")))
                                HistoryBoardPathMultiple.Sort = reader.GetInt32(reader.GetOrdinal("Sort"));
                            else
                                HistoryBoardPathMultiple.Sort = 0;
                            //Department
                            if (!reader.IsDBNull(reader.GetOrdinal("Department")))
                                HistoryBoardPathMultiple.Department = reader["Department"].ToString();
                            else
                                HistoryBoardPathMultiple.Department = null;
                            //PLC
                            if (!reader.IsDBNull(reader.GetOrdinal("PLC")))
                                HistoryBoardPathMultiple.PLC = reader["PLC"].ToString();
                            else
                                HistoryBoardPathMultiple.PLC = null;
                            //TagAddress
                            if (!reader.IsDBNull(reader.GetOrdinal("TagAddress")))
                                HistoryBoardPathMultiple.TagAddress = reader["TagAddress"].ToString();
                            else
                                HistoryBoardPathMultiple.TagAddress = null;
                            //ShowLocation
                            if (!reader.IsDBNull(reader.GetOrdinal("ShowLocation")))
                                HistoryBoardPathMultiple.ShowLocation = reader["ShowLocation"].ToString();
                            else
                                HistoryBoardPathMultiple.ShowLocation = null;
                            //StartTime
                            if (!reader.IsDBNull(reader.GetOrdinal("StartTime")))
                                HistoryBoardPathMultiple.StartTime = Convert.ToDateTime(reader["StartTime"]);
                            else
                                HistoryBoardPathMultiple.StartTime = null;
                            //Path
                            if (!reader.IsDBNull(reader.GetOrdinal("Path")))
                                HistoryBoardPathMultiple.Path = reader["Path"].ToString();
                            else
                                HistoryBoardPathMultiple.Path = null;
                            //EndTime
                            if (!reader.IsDBNull(reader.GetOrdinal("EndTime")))
                                HistoryBoardPathMultiple.EndTime = Convert.ToDateTime(reader["EndTime"]);
                            else
                                HistoryBoardPathMultiple.EndTime = null;
                            //SaveTime
                            if (!reader.IsDBNull(reader.GetOrdinal("SaveTime")))
                                HistoryBoardPathMultiple.SaveTime = Convert.ToDateTime(reader["SaveTime"]);
                            else
                                HistoryBoardPathMultiple.SaveTime = new DateTime();

                            result.Add(HistoryBoardPathMultiple);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    _isError = true;
                    _strErrorMessage = WriteContext.ErrorReturn(_strProductVersion, _strModule, strProcedure, ex.Message.ToString());
                }
            }
            return result;
        }

        public List<HistoryBoardPathNew> GetHistoryBoardPathNewList()
        {
            string strProcedure = "GetHistoryBoardPathNewList";

            List<HistoryBoardPathNew> result = new List<HistoryBoardPathNew>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("Select Id, SettingRowDataId, Sort, Department, PLC, TagAddress, ShowLocation, StartTime, " +
                                                            "Path, EndTime, SaveTime " +
                                                            "From HistoryBoardPathNew " +
                                                    "Order by SaveTime desc ", conn);

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HistoryBoardPathNew HistoryBoardPathNew = new HistoryBoardPathNew();
                            //Id
                            HistoryBoardPathNew.Id = reader["Id"].ToString();
                            //SettingRowDataId
                            HistoryBoardPathNew.SettingRowDataId = reader["SettingRowDataId"].ToString();
                            //Sort
                            if (!reader.IsDBNull(reader.GetOrdinal("Sort")))
                                HistoryBoardPathNew.Sort = reader.GetInt32(reader.GetOrdinal("Sort"));
                            else
                                HistoryBoardPathNew.Sort = 0;
                            //Department
                            if (!reader.IsDBNull(reader.GetOrdinal("Department")))
                                HistoryBoardPathNew.Department = reader["Department"].ToString();
                            else
                                HistoryBoardPathNew.Department = null;
                            //PLC
                            if (!reader.IsDBNull(reader.GetOrdinal("PLC")))
                                HistoryBoardPathNew.PLC = reader["PLC"].ToString();
                            else
                                HistoryBoardPathNew.PLC = null;
                            //TagAddress
                            if (!reader.IsDBNull(reader.GetOrdinal("TagAddress")))
                                HistoryBoardPathNew.TagAddress = reader["TagAddress"].ToString();
                            else
                                HistoryBoardPathNew.TagAddress = null;
                            //ShowLocation
                            if (!reader.IsDBNull(reader.GetOrdinal("ShowLocation")))
                                HistoryBoardPathNew.ShowLocation = reader["ShowLocation"].ToString();
                            else
                                HistoryBoardPathNew.ShowLocation = null;
                            //StartTime
                            if (!reader.IsDBNull(reader.GetOrdinal("StartTime")))
                                HistoryBoardPathNew.StartTime = Convert.ToDateTime(reader["StartTime"]);
                            else
                                HistoryBoardPathNew.StartTime = null;
                            //Path
                            if (!reader.IsDBNull(reader.GetOrdinal("Path")))
                                HistoryBoardPathNew.Path = reader["Path"].ToString();
                            else
                                HistoryBoardPathNew.Path = null;
                            //EndTime
                            if (!reader.IsDBNull(reader.GetOrdinal("EndTime")))
                                HistoryBoardPathNew.EndTime = Convert.ToDateTime(reader["EndTime"]);
                            else
                                HistoryBoardPathNew.EndTime = null;
                            //SaveTime
                            if (!reader.IsDBNull(reader.GetOrdinal("SaveTime")))
                                HistoryBoardPathNew.SaveTime = Convert.ToDateTime(reader["SaveTime"]);
                            else
                                HistoryBoardPathNew.SaveTime = new DateTime();

                            result.Add(HistoryBoardPathNew);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    _isError = true;
                    _strErrorMessage = WriteContext.ErrorReturn(_strProductVersion, _strModule, strProcedure, ex.Message.ToString());
                }
            }
            return result;
        }

        public List<HistoryBoardExceptionDyeing> GetHistoryBoardExceptionDyeingList()
        {
            string strProcedure = "GetHistoryBoardExceptionDyeingList";

            List<HistoryBoardExceptionDyeing> result = new List<HistoryBoardExceptionDyeing>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("Select Id, SettingRowDataId, Sort, Department, PLC, TagAddress, ShowLocation, StartTime, " +
                                                            "ExceptionMsg, EndTime, SaveTime " +
                                                            "From HistoryBoardExceptionDyeing " +
                                                    "Order by SaveTime desc ", conn);

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HistoryBoardExceptionDyeing HistoryBoardExceptionDyeing = new HistoryBoardExceptionDyeing();
                            //Id
                            HistoryBoardExceptionDyeing.Id = reader["Id"].ToString();
                            //SettingRowDataId
                            HistoryBoardExceptionDyeing.SettingRowDataId = reader["SettingRowDataId"].ToString();
                            //Sort
                            if (!reader.IsDBNull(reader.GetOrdinal("Sort")))
                                HistoryBoardExceptionDyeing.Sort = reader.GetInt32(reader.GetOrdinal("Sort"));
                            else
                                HistoryBoardExceptionDyeing.Sort = 0;
                            //Department
                            if (!reader.IsDBNull(reader.GetOrdinal("Department")))
                                HistoryBoardExceptionDyeing.Department = reader["Department"].ToString();
                            else
                                HistoryBoardExceptionDyeing.Department = null;
                            //PLC
                            if (!reader.IsDBNull(reader.GetOrdinal("PLC")))
                                HistoryBoardExceptionDyeing.PLC = reader["PLC"].ToString();
                            else
                                HistoryBoardExceptionDyeing.PLC = null;
                            //TagAddress
                            if (!reader.IsDBNull(reader.GetOrdinal("TagAddress")))
                                HistoryBoardExceptionDyeing.TagAddress = reader["TagAddress"].ToString();
                            else
                                HistoryBoardExceptionDyeing.TagAddress = null;
                            //ShowLocation
                            if (!reader.IsDBNull(reader.GetOrdinal("ShowLocation")))
                                HistoryBoardExceptionDyeing.ShowLocation = reader["ShowLocation"].ToString();
                            else
                                HistoryBoardExceptionDyeing.ShowLocation = null;
                            //StartTime
                            if (!reader.IsDBNull(reader.GetOrdinal("StartTime")))
                                HistoryBoardExceptionDyeing.StartTime = Convert.ToDateTime(reader["StartTime"]);
                            else
                                HistoryBoardExceptionDyeing.StartTime = null;
                            //ExceptionMsg
                            if (!reader.IsDBNull(reader.GetOrdinal("ExceptionMsg")))
                                HistoryBoardExceptionDyeing.ExceptionMsg = reader["ExceptionMsg"].ToString();
                            else
                                HistoryBoardExceptionDyeing.ExceptionMsg = null;
                            //EndTime
                            if (!reader.IsDBNull(reader.GetOrdinal("EndTime")))
                                HistoryBoardExceptionDyeing.EndTime = Convert.ToDateTime(reader["EndTime"]);
                            else
                                HistoryBoardExceptionDyeing.EndTime = null;
                            //SaveTime
                            if (!reader.IsDBNull(reader.GetOrdinal("SaveTime")))
                                HistoryBoardExceptionDyeing.SaveTime = Convert.ToDateTime(reader["SaveTime"]);
                            else
                                HistoryBoardExceptionDyeing.SaveTime = new DateTime();

                            result.Add(HistoryBoardExceptionDyeing);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    _isError = true;
                    _strErrorMessage = WriteContext.ErrorReturn(_strProductVersion, _strModule, strProcedure, ex.Message.ToString());
                }
            }
            return result;
        }

        public List<HistoryBoardExceptionMultiple> GetHistoryBoardExceptionMultipleList()
        {
            string strProcedure = "GetHistoryBoardExceptionMultipleList";

            List<HistoryBoardExceptionMultiple> result = new List<HistoryBoardExceptionMultiple>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("Select Id, SettingRowDataId, Sort, Department, PLC, TagAddress, ShowLocation, StartTime, " +
                                                            "ExceptionMsg, EndTime, SaveTime " +
                                                            "From HistoryBoardExceptionMultiple " +
                                                    "Order by SaveTime desc ", conn);

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HistoryBoardExceptionMultiple HistoryBoardExceptionMultiple = new HistoryBoardExceptionMultiple();
                            //Id
                            HistoryBoardExceptionMultiple.Id = reader["Id"].ToString();
                            //SettingRowDataId
                            HistoryBoardExceptionMultiple.SettingRowDataId = reader["SettingRowDataId"].ToString();
                            //Sort
                            if (!reader.IsDBNull(reader.GetOrdinal("Sort")))
                                HistoryBoardExceptionMultiple.Sort = reader.GetInt32(reader.GetOrdinal("Sort"));
                            else
                                HistoryBoardExceptionMultiple.Sort = 0;
                            //Department
                            if (!reader.IsDBNull(reader.GetOrdinal("Department")))
                                HistoryBoardExceptionMultiple.Department = reader["Department"].ToString();
                            else
                                HistoryBoardExceptionMultiple.Department = null;
                            //PLC
                            if (!reader.IsDBNull(reader.GetOrdinal("PLC")))
                                HistoryBoardExceptionMultiple.PLC = reader["PLC"].ToString();
                            else
                                HistoryBoardExceptionMultiple.PLC = null;
                            //TagAddress
                            if (!reader.IsDBNull(reader.GetOrdinal("TagAddress")))
                                HistoryBoardExceptionMultiple.TagAddress = reader["TagAddress"].ToString();
                            else
                                HistoryBoardExceptionMultiple.TagAddress = null;
                            //ShowLocation
                            if (!reader.IsDBNull(reader.GetOrdinal("ShowLocation")))
                                HistoryBoardExceptionMultiple.ShowLocation = reader["ShowLocation"].ToString();
                            else
                                HistoryBoardExceptionMultiple.ShowLocation = null;
                            //StartTime
                            if (!reader.IsDBNull(reader.GetOrdinal("StartTime")))
                                HistoryBoardExceptionMultiple.StartTime = Convert.ToDateTime(reader["StartTime"]);
                            else
                                HistoryBoardExceptionMultiple.StartTime = null;
                            //ExceptionMsg
                            if (!reader.IsDBNull(reader.GetOrdinal("ExceptionMsg")))
                                HistoryBoardExceptionMultiple.ExceptionMsg = reader["ExceptionMsg"].ToString();
                            else
                                HistoryBoardExceptionMultiple.ExceptionMsg = null;
                            //EndTime
                            if (!reader.IsDBNull(reader.GetOrdinal("EndTime")))
                                HistoryBoardExceptionMultiple.EndTime = Convert.ToDateTime(reader["EndTime"]);
                            else
                                HistoryBoardExceptionMultiple.EndTime = null;
                            //SaveTime
                            if (!reader.IsDBNull(reader.GetOrdinal("SaveTime")))
                                HistoryBoardExceptionMultiple.SaveTime = Convert.ToDateTime(reader["SaveTime"]);
                            else
                                HistoryBoardExceptionMultiple.SaveTime = new DateTime();

                            result.Add(HistoryBoardExceptionMultiple);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    _isError = true;
                    _strErrorMessage = WriteContext.ErrorReturn(_strProductVersion, _strModule, strProcedure, ex.Message.ToString());
                }
            }
            return result;
        }

        public List<HistoryBoardExceptionNew> GetHistoryBoardExceptionNewList()
        {
            string strProcedure = "GetHistoryBoardExceptionNewList";

            List<HistoryBoardExceptionNew> result = new List<HistoryBoardExceptionNew>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("Select Id, SettingRowDataId, Sort, Department, PLC, TagAddress, ShowLocation, StartTime, " +
                                                            "ExceptionMsg, EndTime, SaveTime " +
                                                            "From HistoryBoardExceptionNew " +
                                                    "Order by SaveTime desc ", conn);

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HistoryBoardExceptionNew HistoryBoardExceptionNew = new HistoryBoardExceptionNew();
                            //Id
                            HistoryBoardExceptionNew.Id = reader["Id"].ToString();
                            //SettingRowDataId
                            HistoryBoardExceptionNew.SettingRowDataId = reader["SettingRowDataId"].ToString();
                            //Sort
                            if (!reader.IsDBNull(reader.GetOrdinal("Sort")))
                                HistoryBoardExceptionNew.Sort = reader.GetInt32(reader.GetOrdinal("Sort"));
                            else
                                HistoryBoardExceptionNew.Sort = 0;
                            //Department
                            if (!reader.IsDBNull(reader.GetOrdinal("Department")))
                                HistoryBoardExceptionNew.Department = reader["Department"].ToString();
                            else
                                HistoryBoardExceptionNew.Department = null;
                            //PLC
                            if (!reader.IsDBNull(reader.GetOrdinal("PLC")))
                                HistoryBoardExceptionNew.PLC = reader["PLC"].ToString();
                            else
                                HistoryBoardExceptionNew.PLC = null;
                            //TagAddress
                            if (!reader.IsDBNull(reader.GetOrdinal("TagAddress")))
                                HistoryBoardExceptionNew.TagAddress = reader["TagAddress"].ToString();
                            else
                                HistoryBoardExceptionNew.TagAddress = null;
                            //ShowLocation
                            if (!reader.IsDBNull(reader.GetOrdinal("ShowLocation")))
                                HistoryBoardExceptionNew.ShowLocation = reader["ShowLocation"].ToString();
                            else
                                HistoryBoardExceptionNew.ShowLocation = null;
                            //StartTime
                            if (!reader.IsDBNull(reader.GetOrdinal("StartTime")))
                                HistoryBoardExceptionNew.StartTime = Convert.ToDateTime(reader["StartTime"]);
                            else
                                HistoryBoardExceptionNew.StartTime = null;
                            //ExceptionMsg
                            if (!reader.IsDBNull(reader.GetOrdinal("ExceptionMsg")))
                                HistoryBoardExceptionNew.ExceptionMsg = reader["ExceptionMsg"].ToString();
                            else
                                HistoryBoardExceptionNew.ExceptionMsg = null;
                            //EndTime
                            if (!reader.IsDBNull(reader.GetOrdinal("EndTime")))
                                HistoryBoardExceptionNew.EndTime = Convert.ToDateTime(reader["EndTime"]);
                            else
                                HistoryBoardExceptionNew.EndTime = null;
                            //SaveTime
                            if (!reader.IsDBNull(reader.GetOrdinal("SaveTime")))
                                HistoryBoardExceptionNew.SaveTime = Convert.ToDateTime(reader["SaveTime"]);
                            else
                                HistoryBoardExceptionNew.SaveTime = new DateTime();

                            result.Add(HistoryBoardExceptionNew);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    _isError = true;
                    _strErrorMessage = WriteContext.ErrorReturn(_strProductVersion, _strModule, strProcedure, ex.Message.ToString());
                }
            }
            return result;
        }
    }
}