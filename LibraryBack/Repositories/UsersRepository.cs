// using System;
// using System.Collections.Generic;
// using System.Data.SqlClient;

// namespace LibraryBack.Repository
// {
//     public interface IUserRepository
//     {
//         string CheckLogin(Login login);
//     }
//     public class usersRepository : IUserRepository
//     {
//         public string CheckLogin(LoginModel login)
//         {
//             var cs = "Server=localhost\\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;";
//             using var con = SqlConnection(cs);
//             con.Open();

//             string query = string.Format("SELECT Id FROM UserTbl WHERE Username = '{0}' AND Password = '{1}';", login.Username, login, Password);
            
//             using var cmd = new SqlCommand(query, con);

//             using SqlDataReader rdr = cmd.ExecuteReader();
         
//             while (rdr.Read())
//             {
//                 var output = rdr.GetInt32(0);
//             }
//             return output;

//         }
//     }
// }