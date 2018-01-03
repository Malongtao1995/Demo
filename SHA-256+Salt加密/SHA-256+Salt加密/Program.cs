using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SHA_256_Salt加密
{
    class Program
    {
        static void Main(string[] args)
        {
            //Insert("李四", "456");//注册
             Login("李四", "456");
        }
        private static void Insert(string Name, string Password)
        {

            string strsalt = Guid.NewGuid().ToString();
            byte[] saltandpwd = Encoding.UTF8.GetBytes(strsalt + Password);
            byte[] hashsalt = new SHA256Managed().ComputeHash(saltandpwd);
            string hashStr = Convert.ToBase64String(hashsalt);
            using (SqlConnection conn = new SqlConnection("Server=.;Database=TSQLFundamentals2008;User ID=sa;Password=syspro;"))
            {
                conn.Open();
                SqlParameter[] sqlparmater = new SqlParameter[3];
                sqlparmater[0] = new SqlParameter("@userName", System.Data.SqlDbType.NVarChar, 50);
                sqlparmater[1] = new SqlParameter("@userPassword", System.Data.SqlDbType.NVarChar, 50);
                sqlparmater[2] = new SqlParameter("@salt", System.Data.SqlDbType.NVarChar, 50);
                sqlparmater[0].Value = Name;
                sqlparmater[1].Value = hashStr;
                sqlparmater[2].Value = strsalt;
                string sql = @"
insert into userInfo
values(@userName,@userPassword,@salt)
";
                SqlCommand sqlcmd = conn.CreateCommand();
                sqlcmd.CommandText = sql;
                sqlcmd.Parameters.AddRange(sqlparmater);
                if (sqlcmd.ExecuteNonQuery() > 0)
                {
                    Console.WriteLine("注册成功");
                }
                else
                {
                    Console.WriteLine("注册失败");
                }
            }
        }
        private static void Login(string Name, string Password)
        {
            using (SqlConnection conn = new SqlConnection("Server=.;Database=TSQLFundamentals2008;User ID=sa;Password=syspro;"))
            {
                conn.Open();
                string sql = "select * from userInfo where userName='" + Name + "'";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                SqlDataReader da=cmd.ExecuteReader();
                if (da.HasRows)
                {
                    da.Read();
                    string salt = da[2].ToString();
                    byte[] hashandsalt = Encoding.UTF8.GetBytes(salt + Password);
                    byte[] strhashsalt = new SHA256Managed().ComputeHash(hashandsalt);
                    string comparepassword = Convert.ToBase64String(strhashsalt);
                    if (da[1].ToString()==comparepassword)
                    {
                        Console.WriteLine("密码正确");
                    }  else Console.WriteLine("密码错误");
                    
                }
                else
                {
                    Console.WriteLine("用户不 存在");
                }

            }
        }
    }
}
