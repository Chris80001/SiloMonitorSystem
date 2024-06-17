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
    public class ImmediateBoardService
    {
        private string _strProductVersion = "ChilinSiloMonitorSystem";
        private string _strModule = "ImmediateBoardService";
        private Boolean _isError = false;
        private string _strErrorMessage = string.Empty;

        public List<ImmediateBoardDyeing> GetImmediateBoardDyeingList(string ShowLocation)
        {
            string strProcedure = "GetImmediateBoardDyeingList";

            List<ImmediateBoardDyeing> result = new List<ImmediateBoardDyeing>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("Select Id, SettingRowDataId, Sort, Department, PLC, TagAddress, ShowLocation, " +
                                                            "State, Name, SaveTime " +
                                                            "From ImmediateBoardDyeing " +
                                                    "Where ShowLocation = @ShowLocation " +
                                                    "Order by Sort ", conn);

                command.Parameters.AddWithValue("@ShowLocation", ShowLocation);
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ImmediateBoardDyeing ImmediateBoardDyeing = new ImmediateBoardDyeing();
                            //Id
                            ImmediateBoardDyeing.Id = reader["Id"].ToString();
                            //SettingRowDataId
                            ImmediateBoardDyeing.SettingRowDataId = reader["SettingRowDataId"].ToString();
                            //Sort
                            if (!reader.IsDBNull(reader.GetOrdinal("Sort")))
                                ImmediateBoardDyeing.Sort = reader.GetInt32(reader.GetOrdinal("Sort"));
                            else
                                ImmediateBoardDyeing.Sort = 0;
                            //Department
                            if (!reader.IsDBNull(reader.GetOrdinal("Department")))
                                ImmediateBoardDyeing.Department = reader["Department"].ToString();
                            else
                                ImmediateBoardDyeing.Department = null;
                            //PLC
                            if (!reader.IsDBNull(reader.GetOrdinal("PLC")))
                                ImmediateBoardDyeing.PLC = reader["PLC"].ToString();
                            else
                                ImmediateBoardDyeing.PLC = null;
                            //TagAddress
                            if (!reader.IsDBNull(reader.GetOrdinal("TagAddress")))
                                ImmediateBoardDyeing.TagAddress = reader["TagAddress"].ToString();
                            else
                                ImmediateBoardDyeing.TagAddress = null;
                            //ShowLocation
                            if (!reader.IsDBNull(reader.GetOrdinal("ShowLocation")))
                                ImmediateBoardDyeing.ShowLocation = reader["ShowLocation"].ToString();
                            else
                                ImmediateBoardDyeing.ShowLocation = null;
                            //State
                            if (!reader.IsDBNull(reader.GetOrdinal("State")))
                                ImmediateBoardDyeing.State = reader["State"].ToString();
                            else
                                ImmediateBoardDyeing.State = null;
                            //Name
                            if (!reader.IsDBNull(reader.GetOrdinal("Name")))
                                ImmediateBoardDyeing.Name = reader["Name"].ToString();
                            else
                                ImmediateBoardDyeing.Name = null;
                            //SaveTime
                            if (!reader.IsDBNull(reader.GetOrdinal("SaveTime")))
                                ImmediateBoardDyeing.SaveTime = Convert.ToDateTime(reader["SaveTime"]);
                            else
                                ImmediateBoardDyeing.SaveTime = new DateTime();

                            result.Add(ImmediateBoardDyeing);
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

        public List<ImmediateBoardMultiple> GetImmediateBoardMultipleList(string ShowLocation)
        {
            string strProcedure = "GetImmediateBoardMultipleList";

            List<ImmediateBoardMultiple> result = new List<ImmediateBoardMultiple>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("Select Id, SettingRowDataId, Sort, Department, PLC, TagAddress, ShowLocation, " +
                                                            "State, Name, SaveTime " +
                                                            "From ImmediateBoardMultiple " +
                                                    "Where ShowLocation = @ShowLocation " +
                                                    "Order by Sort ", conn);

                command.Parameters.AddWithValue("@ShowLocation", ShowLocation);
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ImmediateBoardMultiple ImmediateBoardMultiple = new ImmediateBoardMultiple();
                            //Id
                            ImmediateBoardMultiple.Id = reader["Id"].ToString();
                            //SettingRowDataId
                            ImmediateBoardMultiple.SettingRowDataId = reader["SettingRowDataId"].ToString();
                            //Sort
                            if (!reader.IsDBNull(reader.GetOrdinal("Sort")))
                                ImmediateBoardMultiple.Sort = reader.GetInt32(reader.GetOrdinal("Sort"));
                            else
                                ImmediateBoardMultiple.Sort = 0;
                            //Department
                            if (!reader.IsDBNull(reader.GetOrdinal("Department")))
                                ImmediateBoardMultiple.Department = reader["Department"].ToString();
                            else
                                ImmediateBoardMultiple.Department = null;
                            //PLC
                            if (!reader.IsDBNull(reader.GetOrdinal("PLC")))
                                ImmediateBoardMultiple.PLC = reader["PLC"].ToString();
                            else
                                ImmediateBoardMultiple.PLC = null;
                            //TagAddress
                            if (!reader.IsDBNull(reader.GetOrdinal("TagAddress")))
                                ImmediateBoardMultiple.TagAddress = reader["TagAddress"].ToString();
                            else
                                ImmediateBoardMultiple.TagAddress = null;
                            //ShowLocation
                            if (!reader.IsDBNull(reader.GetOrdinal("ShowLocation")))
                                ImmediateBoardMultiple.ShowLocation = reader["ShowLocation"].ToString();
                            else
                                ImmediateBoardMultiple.ShowLocation = null;
                            //State
                            if (!reader.IsDBNull(reader.GetOrdinal("State")))
                                ImmediateBoardMultiple.State = reader["State"].ToString();
                            else
                                ImmediateBoardMultiple.State = null;
                            //Name
                            if (!reader.IsDBNull(reader.GetOrdinal("Name")))
                                ImmediateBoardMultiple.Name = reader["Name"].ToString();
                            else
                                ImmediateBoardMultiple.Name = null;
                            //SaveTime
                            if (!reader.IsDBNull(reader.GetOrdinal("SaveTime")))
                                ImmediateBoardMultiple.SaveTime = Convert.ToDateTime(reader["SaveTime"]);
                            else
                                ImmediateBoardMultiple.SaveTime = new DateTime();

                            result.Add(ImmediateBoardMultiple);
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

        public List<ImmediateBoardNew> GetImmediateBoardNewList(string ShowLocation)
        {
            string strProcedure = "GetImmediateBoardNewList";

            List<ImmediateBoardNew> result = new List<ImmediateBoardNew>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("Select Id, SettingRowDataId, Sort, Department, PLC, TagAddress, ShowLocation, " +
                                                            "State, Name, SaveTime " +
                                                            "From ImmediateBoardNew " +
                                                    "Where ShowLocation = @ShowLocation " +
                                                    "Order by Sort ", conn);

                command.Parameters.AddWithValue("@ShowLocation", ShowLocation);
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ImmediateBoardNew ImmediateBoardNew = new ImmediateBoardNew();
                            //Id
                            ImmediateBoardNew.Id = reader["Id"].ToString();
                            //SettingRowDataId
                            ImmediateBoardNew.SettingRowDataId = reader["SettingRowDataId"].ToString();
                            //Sort
                            if (!reader.IsDBNull(reader.GetOrdinal("Sort")))
                                ImmediateBoardNew.Sort = reader.GetInt32(reader.GetOrdinal("Sort"));
                            else
                                ImmediateBoardNew.Sort = 0;
                            //Department
                            if (!reader.IsDBNull(reader.GetOrdinal("Department")))
                                ImmediateBoardNew.Department = reader["Department"].ToString();
                            else
                                ImmediateBoardNew.Department = null;
                            //PLC
                            if (!reader.IsDBNull(reader.GetOrdinal("PLC")))
                                ImmediateBoardNew.PLC = reader["PLC"].ToString();
                            else
                                ImmediateBoardNew.PLC = null;
                            //TagAddress
                            if (!reader.IsDBNull(reader.GetOrdinal("TagAddress")))
                                ImmediateBoardNew.TagAddress = reader["TagAddress"].ToString();
                            else
                                ImmediateBoardNew.TagAddress = null;
                            //ShowLocation
                            if (!reader.IsDBNull(reader.GetOrdinal("ShowLocation")))
                                ImmediateBoardNew.ShowLocation = reader["ShowLocation"].ToString();
                            else
                                ImmediateBoardNew.ShowLocation = null;
                            //State
                            if (!reader.IsDBNull(reader.GetOrdinal("State")))
                                ImmediateBoardNew.State = reader["State"].ToString();
                            else
                                ImmediateBoardNew.State = null;
                            //Name
                            if (!reader.IsDBNull(reader.GetOrdinal("Name")))
                                ImmediateBoardNew.Name = reader["Name"].ToString();
                            else
                                ImmediateBoardNew.Name = null;
                            //SaveTime
                            if (!reader.IsDBNull(reader.GetOrdinal("SaveTime")))
                                ImmediateBoardNew.SaveTime = Convert.ToDateTime(reader["SaveTime"]);
                            else
                                ImmediateBoardNew.SaveTime = new DateTime();

                            result.Add(ImmediateBoardNew);
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