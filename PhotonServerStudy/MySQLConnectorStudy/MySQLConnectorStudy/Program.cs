using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MySQLConnectorStudy
{
	class Program
	{
		static MySqlConnection conn;
		static void Main(string[] args)
		{
			string connectStr = "server=localhost;port=3306;database=mysqlstudy;user=root;password=Asdfg30358297";
			conn = new MySqlConnection(connectStr);
			try
			{
				conn.Open();
				Console.WriteLine("Connected!");

				//ReadAll();
				//InsertUser("xuweizhen", "337952");
				//UpdatePassword("zhaoyijie", "qq1942");
				//DeleteUser("xuweizhen");
				//GetUsersCount();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.ToString());
			}

			conn.Close();
			Console.ReadKey();
		}
		static void ReadAll()
		{
			string sql = "select * from users";
			MySqlCommand cmd = new MySqlCommand(sql, conn);
			//cmd.ExecuteReader();//查询语句
			//cmd.ExecuteScalar();//单条查询
			//cmd.ExecuteNonQuery();//插入删除
			MySqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				//Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
				Console.WriteLine(reader.GetString("username") + " " + reader.GetString("password"));
			}
			reader.Close();
		}
		static void InsertUser(string username, string password)
		{
			string sql = "insert into users(username,password) values('"+username+"','"+password+"')";
			MySqlCommand cmd = new MySqlCommand(sql, conn);
			int result = cmd.ExecuteNonQuery();//返回值为受影响的行数
		}
		static void UpdatePassword(string username, string password)
		{
			//直接使用字符串参数
			//string sql = "update users set password = '"+password+"' where username = '"+username+"'";
			//使用commmand参数
			string sql = "update users set password = @password where username = @username";
			MySqlCommand cmd = new MySqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("password", password);
			cmd.Parameters.AddWithValue("username", username);
			int result = cmd.ExecuteNonQuery();//返回值为受影响的行数
		}
		static void DeleteUser(string username)
		{
			string sql = "delete from users where username = '"+username+"'";
			MySqlCommand cmd = new MySqlCommand(sql, conn);
			int result = cmd.ExecuteNonQuery();//返回值为受影响的行数
		}
		static void GetUsersCount()
		{
			string sql = "select count(*) from users";
			MySqlCommand cmd = new MySqlCommand(sql, conn);
			object result = cmd.ExecuteScalar();
			Console.WriteLine(Convert.ToInt32(result.ToString()));
		}
	}
}
