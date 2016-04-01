using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApplication1
{
    class MyDataSet
    {
        SqlConnection _data;
        public void Start()
        {
            _data = new SqlConnection();
            _data.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\projects\ConsoleApplication1\ConsoleApplication1\Database1.mdf;Integrated Security=True";
        }
        public bool Set(string email, string password, string nick)
        {
            try
            {
                _data.Open();
                var cmd = new SqlCommand("INSERT INTO [Accounts] ([Email], [Password], [Nick]) VALUES (@email, @pass, @nick)", _data);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@pass", password);
                cmd.Parameters.AddWithValue("@nick", nick);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Yeah!");
                _data.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }
        public void Clear()
        {
            try
            {
                _data.Open();
                var cmd = new SqlCommand("DELETE FROM [Accounts]", _data);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("DBCC CHECKIDENT([Accounts], RESEED, 0)", _data);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Yeah!");
                _data.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyDataSet _data = new MyDataSet();
            _data.Start();
            _data.Set("ad", "and", "ad");
            //_data.Clear();
        }
    }
}
