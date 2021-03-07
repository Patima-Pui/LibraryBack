using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace LibraryBack.Repositories
{   
    public interface IUsersRepository
    {
        UsersListModel SelectAllUsers();
        int SelectUserIdFromDB(LoginModle log);
        int InsertUserDetails(UserModel datail);
    }
    public class UsersRepository : IUsersRepository
    {
         public UsersListModel SelectAllUsers()
        {
            var cs = "Server=localhost\\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;";
            using var con = new SqlConnection(cs); //Using Class SqlConnection for COnnent to database
            con.Open();

            string sql = "SELECT UserId, Username, Name, Surname, Birthday, Email  FROM UserTable";
            using var cmd = new SqlCommand(sql, con); //Using Class SqlCommand for query data

            using SqlDataReader rdr = cmd.ExecuteReader();

            UsersListModel output = new UsersListModel();
            output.UsersList = new List<UserModel>();

            while (rdr.Read())
            {
                output.UsersList.Add(
                    new UserModel()
                    {
                        userId = rdr.GetInt32(0),
                        username = rdr.GetString(1),
                        name = rdr.GetString(2),
                        surname = rdr.GetString(3),
                        birthday = rdr.GetDateTime(4),
                        email = rdr.GetString(5),
                    }
                );
            }

            return output;
        }

        public int SelectUserIdFromDB(LoginModle log)
        {
            var cs = "Server=localhost\\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;";
            using var con = new SqlConnection(cs);
            con.Open();

            string sql = string.Format("SELECT UserId FROM UserTable WHERE Username = '{0}' AND Password = '{1}';", log.username, log.password);
            using var cmd = new SqlCommand(sql, con);
            using SqlDataReader rdr = cmd.ExecuteReader();

            var output = -1;

            while (rdr.Read())
            {
                output = rdr.GetInt32(0);
            }

            return output;
        }

        public int InsertUserDetails(UserModel datail)
        {
            var cs = "Server=localhost\\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;";
            using var con = new SqlConnection(cs);
            con.Open();

            DateTime Now = DateTime.Now;
            var sql = string.Format(@"INSERT INTO 
            UserTable(Username, Password, Name, Surname, Birthday, Email, CreateDate, CreateName, UpdateDate, UpdateName)
            VALUES(@Username, @Password, @Name, @Surname, @Birthday, @Email, @CreateDate, @CreateName, @UpdateDate, @UpdateName)");

            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.Parameters.AddWithValue("@Username", datail.username);
            cmd.Parameters.AddWithValue("@Password", datail.password);
            cmd.Parameters.AddWithValue("@Name", datail.name);
            cmd.Parameters.AddWithValue("@Surname", datail.surname);
            cmd.Parameters.AddWithValue("@Birthday", datail.birthday);
            cmd.Parameters.AddWithValue("@Email", datail.email);
            cmd.Parameters.AddWithValue("@CreateDate", Now);
            cmd.Parameters.AddWithValue("@CreateName", datail.upsertName);
            cmd.Parameters.AddWithValue("@UpdateDate", Now);
            cmd.Parameters.AddWithValue("@UpdateName", datail.upsertName);
            var res = cmd.ExecuteNonQuery();
            return res;
        }
    }
}