using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace ChillSiloMonitorSystem.Common
{
    public static class GetAppString
    {
        public static string GetMessage(string strApp)
        {
            return ConfigurationManager.AppSettings[strApp];
        }
    }
    public class Database
    {
        public static string DBConnection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            }
        }

        public static string DBProvider
        {
            get
            {
                return ConfigurationManager.AppSettings["dbProvider"];
            }
        }


        public static IDbConnection GetConnection(string database, string sprovider)
        {
            IDbConnection connection;
            DbProviderFactory factory;
            String provider = sprovider;
            if (string.IsNullOrEmpty(provider) == true)
            {
                provider = "System.Data.OracleClient";
            }
            factory = DbProviderFactories.GetFactory(provider);
            connection = factory.CreateConnection();
            connection.ConnectionString = database;
            connection.Open();
            return connection;
        }

        public static string GetParaemters(string parameterName)
        {
            string sName = string.Empty;
            string strProvider = ConfigurationManager.AppSettings["dbProvider"];
            switch (strProvider)
            {
                case "System.Data.SqlClient":
                    sName = "@" + parameterName;
                    break;
                default:
                    sName = ":" + parameterName;
                    break;
            }
            return sName;
        }

        /// <summary>
        /// 建立參數物件
        /// </summary>
        /// <param name="cm">符合IDbCommand介面的物件</param>
        /// <param name="parameterName">參數名稱</param>
        /// <param name="value">參數值</param>
        /// <returns>參數物件</returns>
        /// <remarks></remarks>
        public static IDbDataParameter CreateParametere(IDbCommand cm, string parameterName, object value)
        {
            string strProvider = ConfigurationManager.AppSettings["dbProvider"];
            IDbDataParameter param = cm.CreateParameter();
            switch (strProvider)
            {
                case "System.Data.SqlClient":
                    param.ParameterName = "@" + parameterName;
                    break;
                default:
                    param.ParameterName = ":" + parameterName;
                    break;
            }
            param.Value = value;
            return param;
        }

        /// <summary>
        /// 建立參數物件, 如果值等於-1時，改值為Null
        /// </summary>
        /// <param name="cm">符合IDbCommand介面的物件</param>
        /// <param name="parameterName">參數名稱</param>
        /// <param name="value">參數值</param>
        /// <returns>參數物件</returns>
        /// <remarks></remarks>
        public static IDbDataParameter CreateParameter(IDbCommand cm, string parameterName, decimal value)
        {
            string strProvider = ConfigurationManager.AppSettings["dbProvider"];

            IDbDataParameter param = cm.CreateParameter();
            switch (strProvider)
            {
                case "System.Data.SqlClient":
                    param.ParameterName = "@" + parameterName;
                    break;
                default:
                    param.ParameterName = ":" + parameterName;
                    break;
            }
            if (value == decimal.MinusOne)
            {
                param.Value = DBNull.Value;
            }
            else
            {
                param.Value = value;
            }
            return param;
        }

        /// <summary>
        ///  建立參數物件, 如果值等於-1時，改值為Null
        /// </summary>
        /// <param name="cm">符合IDbCommand介面的物件</param>
        /// <param name="parameterName">參數名稱</param>
        /// <param name="value">參數值</param>
        /// <returns>參數物件</returns>
        /// <remarks></remarks>
        public static IDbDataParameter CreateParameter(IDbCommand cm, string parameterName, decimal value, decimal defaultValue)
        {
            string strProvider = ConfigurationManager.AppSettings["dbProvider"];

            IDbDataParameter param = cm.CreateParameter();
            switch (strProvider)
            {
                case "System.Data.SqlClient":
                    param.ParameterName = "@" + parameterName;
                    break;
                default:
                    param.ParameterName = ":" + parameterName;
                    break;
            }
            if (value == decimal.MinusOne)
            {
                param.Value = defaultValue;
            }
            else
            {
                param.Value = value;
            }
            return param;
        }

        /// <summary>
        ///  建立參數物件, 如果字串長度為0時, 改值為Null
        /// </summary>
        /// <param name="cm">符合IDbCommand介面的物件</param>
        /// <param name="parameterName">參數名稱</param>
        /// <param name="value">參數值</param>
        /// <returns>參數物件</returns>
        /// <remarks></remarks>
        public static IDbDataParameter CreateParameter(IDbCommand cm, string parameterName, string value)
        {
            string strProvider = ConfigurationManager.AppSettings["dbProvider"];
            IDbDataParameter param = cm.CreateParameter();
            switch (strProvider)
            {
                case "System.Data.SqlClient":
                    param.ParameterName = "@" + parameterName;
                    break;
                default:
                    param.ParameterName = ":" + parameterName;
                    break;
            }
            if (value.Length == 0)
            {
                param.Value = DBNull.Value;
            }
            else
            {
                param.Value = value;
            }
            return param;
        }

        public static string GetParaemters(string parameterName, string sProvide = "dbProvider")
        {
            string sName = string.Empty;
            string strProvider = ConfigurationManager.AppSettings[sProvide];
            if (strProvider != null)
            {
                switch (strProvider)
                {
                    case "System.Data.SqlClient":
                        sName = "@" + parameterName;
                        //sName =   parameterName;
                        break;
                    default:
                        sName = ":" + parameterName;
                        break;
                }
            }
            else
            {
                switch (sProvide)
                {
                    case "System.Data.SqlClient":
                        sName = "@" + parameterName;
                        break;
                    default:
                        sName = ":" + parameterName;
                        break;
                }

            }

            //switch (strProvider)
            //{
            //    case "System.Data.SqlClient":
            //        sName = "@" + parameterName;
            //        //sName =   parameterName;
            //        break;
            //    default:
            //        sName = ":" + parameterName;
            //        break;
            //}
            return sName;
        }

        /// <summary>
        /// 建立參數物件
        /// </summary>
        /// <param name="cm">符合IDbCommand介面的物件</param>
        /// <param name="parameterName">參數名稱</param>
        /// <param name="value">參數值</param>
        /// <returns>參數物件</returns>
        /// <remarks></remarks>
        public static IDbDataParameter CreateParametereValue(IDbCommand cm, string parameterName, object value, string sProvide = "dbProvider")
        {
            string strProvider = ConfigurationManager.AppSettings[sProvide];
            IDbDataParameter param = cm.CreateParameter();
            if (strProvider != null)
            {
                switch (strProvider)
                {
                    case "System.Data.SqlClient":
                        param.ParameterName = "@" + parameterName;
                        break;
                    default:
                        param.ParameterName = ":" + parameterName;
                        break;
                }
            }
            else
            {
                switch (sProvide)
                {
                    case "System.Data.SqlClient":
                        param.ParameterName = "@" + parameterName;
                        break;
                    default:
                        param.ParameterName = ":" + parameterName;
                        break;
                }

            }


            param.Value = value;
            return param;
        }
    }
}