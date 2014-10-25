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
                       role,
                       street,
                       flat,
                       home,
                       surname,
                       lastname,
                       phone,
                       summ;

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
        public string Phone
        {
            set { phone = value; }
            get { return phone; }
        }
        public string Flat
        {
            set { flat = value; }
            get { return flat; }
        }
        public string Home
        {
            set { home = value; }
            get { return home; }
        }
        public string Street
        {
            set { street = value; }
            get { return street; }
        }
        public string Surname
        {
            set { surname = value; }
            get { return surname; }
        }
        public string Summ
        {
            set { summ = value; }
            get { return summ; }
        }
        public string Lastname
        {
            set { lastname = value; }
            get { return lastname; }
        }

        public void CheckUser(string log)
        {
            SqlConnectionStringBuilder strConn = new SqlConnectionStringBuilder();
            strConn["Data Source"] = "../../HomeManagment.sdf";
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
            strConn["Data Source"] = "../../HomeManagment.sdf";
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
                "(Login,Password,Name,Role) Values (@login,@password,@name,@role)", ConnCe))
            {
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@role", "User");
                cmd.ExecuteNonQuery();
            }

            ConnCe.Close();
            ConnCe.Dispose();
        }
        public void PhoneAutorize(string phones)
        {
            SqlConnectionStringBuilder strConn = new SqlConnectionStringBuilder();
            strConn["Data Source"] = "../../HomeManagment.sdf";
            SqlCeConnection ConnCe = new SqlCeConnection(strConn.ConnectionString);

            try
            {
                ConnCe.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            SqlCeCommand cmd = new SqlCeCommand("Select * From [Flats]" + " Where [Phone] ='" + phones + "'", ConnCe);

            using (SqlCeDataReader dr2 = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (dr2.Read())
                {
                    id = dr2.GetValue(0).ToString().Trim();
                    street = dr2.GetValue(1).ToString().Trim();
                    home = dr2.GetValue(2).ToString().Trim();
                    flat = dr2.GetValue(3).ToString().Trim();
                    surname = dr2.GetValue(4).ToString().Trim();
                    name = dr2.GetValue(5).ToString().Trim();
                    lastname = dr2.GetValue(6).ToString().Trim();
                    phone = dr2.GetValue(7).ToString().Trim();
                    summ = dr2.GetValue(8).ToString().Trim();
                }
            }

            ConnCe.Close();
            ConnCe.Dispose();
        }
        public void Pay(string phones)
        {
            SqlConnectionStringBuilder strConn = new SqlConnectionStringBuilder();
            strConn["Data Source"] = "../../HomeManagment.sdf";
            SqlCeConnection ConnCe = new SqlCeConnection(strConn.ConnectionString);

            try
            {
                ConnCe.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            using (SqlCeCommand cmd = new SqlCeCommand("Delete from [Flats]" +
                 " Where [Phone] ='" + phones + "'", ConnCe))

            using (SqlCeDataReader dr2 = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (dr2.Read())
                {
                    id = dr2.GetValue(0).ToString().Trim();
                    street = dr2.GetValue(1).ToString().Trim();
                    home = dr2.GetValue(2).ToString().Trim();
                    flat = dr2.GetValue(3).ToString().Trim();
                    surname = dr2.GetValue(4).ToString().Trim();
                    name = dr2.GetValue(5).ToString().Trim();
                    lastname = dr2.GetValue(6).ToString().Trim();
                    phone = dr2.GetValue(7).ToString().Trim();
                    summ = dr2.GetValue(8).ToString().Trim();
                }
            }
            ConnCe.Close();
            ConnCe.Dispose();
        }
    }
}
