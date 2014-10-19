using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Data;
using System.Data.Sql;
using System.Data.SqlServerCe;
using System.Data.SqlClient;

namespace Home_managment
{
     public class Connect
    {
        public string id,
                       login,
                       password,
                       name,
                       role;

        public Connect() { }

        public string Id
        {
            set { id = value; }
            get { return id; }
        }

        public string Login
        {
            set { login = value; }
            get { return login; }
        }

        public string Password
        {
            set { password = value; }
            get { return password; }
        }

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public string Role
        {
            set { role = value; }
            get { return role; }
        }



        public void CheckUser(string log)
        {
            SqlConnectionStringBuilder strConn = new SqlConnectionStringBuilder();
            strConn["Data Source"] = "HomeManagment.sdf";
            SqlCeConnection ConnCe = new SqlCeConnection(strConn.ConnectionString);

            try
            {
                ConnCe.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            SqlCeCommand cmd = new SqlCeCommand("Select * From [users]" + " Where [login] = '" + log + "'", ConnCe);

            using (SqlCeDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (dr.Read())
                {
                    id = dr.GetValue(0).ToString().Trim();
                    login = dr.GetValue(1).ToString().Trim();
                    password = dr.GetValue(2).ToString().Trim();
                    name = dr.GetValue(3).ToString().Trim();
                    role = dr.GetValue(4).ToString().Trim();
                }
            }

            ConnCe.Close();
            ConnCe.Dispose();
        }

        public void NewUser(string login, string password, string name)
        {
            SqlConnectionStringBuilder strConn = new SqlConnectionStringBuilder();
            strConn["Data Source"] = "HomeManagment.sdf";
            SqlCeConnection ConnCe = new SqlCeConnection(strConn.ConnectionString);

            try
            {
                ConnCe.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            using (SqlCeCommand cmd = new SqlCeCommand("Insert into [Users]" +
                "(Login,Password,Name) Values (@login,@password,@name)", ConnCe))
            {
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.ExecuteNonQuery();
            }

            ConnCe.Close();
            ConnCe.Dispose();
        }
    }
}
