using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FirebirdSql.Data.FirebirdClient;

namespace FbTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set the ServerType to 1 for connect to the embedded server
            string connectionString = 
                "User=SYSDBA;" +
                "Password=masterkey;" +
                "Database=proiect.fdb;" +
                "DataSource=sintact-server;" +
                "Port=3050;" +
                "Dialect=3;" +
                "Charset=NONE;" +
                "Role=;" +
                "Connection lifetime=15;" +
                "Pooling=true;" +
                "MinPoolSize=0;" +
                "MaxPoolSize=50;" +
                "Packet Size=8192;" +
                "ServerType=0;";
            
/*
            FbConnectionStringBuilder csb = new FbConnectionStringBuilder();
            csb.DataSource = "sintact-server";
            csb.Port = 3050;
            //csb.Database = String.Format(@"{0}/database/database.fdb", AppDomain.CurrentDomain.BaseDirectory);
            csb.Database = @"d:\firebird\data\proiect.fdb";
            csb.UserID = "SYSDBA";
            csb.Password = "masterkey";
            csb.ServerType = FbServerType.Default;
            FbConnection db = new FbConnection(csb.ToString());
*/
            FbConnection myConnection1 = new FbConnection(connectionString);
            FbConnection myConnection2 = new FbConnection(connectionString);
            FbConnection myConnection3 = new FbConnection(connectionString);

            try
            {
                // Open two connections.
                Console.WriteLine("Open two connections.");
                myConnection1.Open();
                myConnection2.Open();

                // Now there are two connections in the pool that matches the connection string.
                // Return the both connections to the pool. 
                Console.WriteLine("Return both of the connections to the pool.");
                myConnection1.Close();
                myConnection2.Close();

                // Get a connection out of the pool.
                Console.WriteLine("Open a connection from the pool.");
                myConnection1.Open();

                // Get a second connection out of the pool.
                Console.WriteLine("Open a second connection from the pool.");
                myConnection2.Open();

                // Open a third connection.
                Console.WriteLine("Open a third connection.");
                myConnection3.Open();

                // Return the all connections to the pool. 
                Console.WriteLine("Return all three connections to the pool.");
                myConnection1.Close();
                myConnection2.Close();
                myConnection3.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();

        }
    }
}
