/*using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace SQLiteConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //CreateTable();
            //AddRow();
            //DeleteRow();
            ReadTable();
        }

        const string dbfile = "URI=file:MySQLiteDB.db";
        static void CreateTable()
        {
            SQLiteConnection connection = new SQLiteConnection(dbfile);
            connection.Open();
            string tbl = "create table Kunde (ID integer primary key, Kunde varchar);";
            SQLiteCommand command = new SQLiteCommand(tbl,connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        static void AddRow()
        {
            SQLiteConnection connection = new SQLiteConnection(dbfile);
            connection.Open();
            string addKunde = "insert into Kunde (ID,Kunde) values (2, 'Karl');";
            SQLiteCommand command = new SQLiteCommand(addKunde, connection);
            connection.Close();
            Console.WriteLine("Row added successfully");
            Console.ReadLine();
        }
        static void DeleteRow()
        {
            SQLiteConnection connection = new SQLiteConnection(dbfile);
            connection.Open();
            string deleteKunde = "delete from Kunde where id=3;";
            SQLiteCommand command = new SQLiteCommand(deleteKunde, connection);
            connection.Close();
            Console.WriteLine("Row deleted successfully");
            Console.ReadLine();            
        }
        static void UpdateRow()
        {
            SQLiteConnection connection = new SQLiteConnection(dbfile);
            connection.Open();
            string updateKunde = "update Kunde set NAME='Popopirat Gbr' where id=1;";
            SQLiteCommand command = new SQLiteCommand(updateKunde, connection);
            connection.Close();
            Console.WriteLine("Row updated successfully");
            Console.ReadLine();    
        }

        static void ReadTable()
        {
            using (SQLiteConnection connection = new SQLiteConnection(dbfile))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand("select * from Kunde", connection);
                SQLiteDataReader reader = command.ExecuteReader();
                Console.WriteLine($"id     {reader.GetName(1)}");
                Console.WriteLine("-------------------");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetInt32(0)} {reader["Kunde"]}");
                }
            }
            Console.WriteLine("end of table");
        }
            
    }
}*/
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace SQLiteDemo
{
   class Program
   {

      static void Main(string[] args)
      {
         SQLiteConnection sqlite_conn;
         sqlite_conn = CreateConnection();
         //CreateTable(sqlite_conn);
         //InsertData(sqlite_conn);
         UpdateData(sqlite_conn);
         ReadData(sqlite_conn);
      }

      static SQLiteConnection CreateConnection()
      {

         SQLiteConnection sqlite_conn;
         // Create a new database connection:
         sqlite_conn = new SQLiteConnection("Data Source=Kundenliste.db;Version=3;New=True;Compress=True;");
         // Open the connection:
         try
         {
            sqlite_conn.Open();
         }
         catch (Exception ex)
         {

         }
         return sqlite_conn;
      }

      static void CreateTable(SQLiteConnection conn)
      {

          SQLiteCommand sqlite_cmd;
          string Createsql = "CREATE TABLE SampleTable (ID string primary key, Kunde string, Character string, Colour string, Adress string, Mail string, Phone string)";
          sqlite_cmd = conn.CreateCommand();
          sqlite_cmd.CommandText = Createsql;
          sqlite_cmd.ExecuteNonQuery();
          
      }

      static void InsertData(SQLiteConnection conn)
             {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = conn.CreateCommand();
                sqlite_cmd.CommandText = "INSERT INTO SampleTable (ID, Kunde, Character, Colour, Adress, Mail, Phone) VALUES " +
                                         "('1', 'Karl Müller ','KM','Blue','Bergstraße 10','karl@karl@gmail.com','+01573223456');";
                sqlite_cmd.ExecuteNonQuery();

             }
      static void UpdateData(SQLiteConnection conn)
      {
          SQLiteCommand sqlite_cmd;
          sqlite_cmd = conn.CreateCommand();
          sqlite_cmd.CommandText = "UPDATE SampleTable set Kunde='Popopirat Gbr' where ID='1';";
          sqlite_cmd.ExecuteNonQuery();
          string deleteKunde = "delete from Kunde where id=3;";
      }
      
      static void DeleteData(SQLiteConnection conn)
      {
          SQLiteCommand sqlite_cmd;
          sqlite_cmd = conn.CreateCommand();
          sqlite_cmd.CommandText = "delete from Kunde where ID='3';";
          sqlite_cmd.ExecuteNonQuery();
      }
      static void ReadData(SQLiteConnection conn)
      {
         SQLiteDataReader sqlite_datareader;
         SQLiteCommand sqlite_cmd;
         sqlite_cmd = conn.CreateCommand();
         sqlite_cmd.CommandText = "SELECT * FROM SampleTable";

         sqlite_datareader = sqlite_cmd.ExecuteReader();
         Console.WriteLine($"ID     {sqlite_datareader.GetName(1)}    Character    Colour    Adress    Mail    Phone");
         Console.WriteLine("-------------------");
         while (sqlite_datareader.Read())
         {
             
             Console.WriteLine($"{sqlite_datareader["ID"]} {sqlite_datareader["Kunde"]} {sqlite_datareader["Character"]} {sqlite_datareader["Colour"]}" +
                               $" {sqlite_datareader["Adress"]} {sqlite_datareader["Mail"]} {sqlite_datareader["Phone"]}");
         }
         conn.Close();
      }
      
   }
}