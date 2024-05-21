using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace AJAX_CRUD.Models
{
    public class DBLayer
    {
        SqlConnection connection;
        public DBLayer()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBName"].ConnectionString);
        }
        public int ExecuteDML(string proname, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(proname, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (SqlParameter param in parameters)
            {
                if (param.Value != null)
                {
                    cmd.Parameters.Add(param);
                }
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }                
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            return result;
        }
        public int ExecuteDML(string proname)
        {
            SqlCommand cmd = new SqlCommand(proname, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }                
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            return result;
        }
        public DataTable ExecuteSelect(string proname, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(proname, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (SqlParameter param in parameters)
            {
                if (param.Value != null)
                {
                    cmd.Parameters.Add(param);
                }
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            return dt;
        }
        public DataTable ExecuteSelect(string proname)
        {
            SqlCommand cmd = new SqlCommand(proname, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            return dt;
        }
        public object ExecuteSclar(string proname, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(proname, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (SqlParameter param in parameters)
            {
                if (param.Value != null)
                {
                    cmd.Parameters.Add(param);
                }
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            object result = cmd.ExecuteScalar();
            connection.Close();
            return result;
        }
        public object ExecuteSclar(string proname)
        {
            SqlCommand cmd = new SqlCommand(proname, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }                
            object result = cmd.ExecuteScalar();
            connection.Close();
            return result;
        }
    }
}