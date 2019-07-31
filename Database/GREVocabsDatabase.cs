using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using GRE_Vocabs.Models;

namespace GRE_Vocabs.Database
{
    class GREVocabsDatabase
    {
        private SQLiteConnection dbConnection;
        private static string sqliteFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/database.db";  // set folder for database
        private static string sqlitePw = "password"; // set password for database

        public GREVocabsDatabase()
        {
            // check if database file exist when not create with password
            if (!File.Exists(sqliteFile))
            {
                dbConnection = new SQLiteConnection("Data Source=" + sqliteFile);
                dbConnection.SetPassword(sqlitePw);
            }
            dbConnection = new SQLiteConnection("Data Source=" + sqliteFile + ";Password=" + sqlitePw); // connect to database
            createDb();

        }

        public void createDb()
        {
            dbConnection.Open();

            SQLiteCommand sqlite_cmd = dbConnection.CreateCommand();
            //Creates table VocabList 
            string createVocabList = "CREATE TABLE IF NOT EXISTS VocabList(VocabListId INT PRIMARY KEY NOT NULL, VocabListName VARCHAR(20) NOT NULL)";
            sqlite_cmd.CommandText = createVocabList;
            sqlite_cmd.ExecuteNonQuery();

            //Insert Data On VocabList table
            sqlite_cmd.CommandText = "INSERT OR REPLACE INTO VocabList (VocabListId, VocabListName) VALUES (1, 'ETS GRE Official Guide 3rd Edition');" +
                                     "INSERT OR REPLACE INTO VocabList(VocabListId, VocabListName) VALUES(2, 'Mangoosh GRE Vocab E-Book List');";
            sqlite_cmd.ExecuteNonQuery();
            dbConnection.Close();
        }

        public List<VocabList> GetVocabList()
        {
            List<VocabList> data = new List<VocabList>();
            dbConnection.Open();
            SQLiteCommand sqlite_cmd = dbConnection.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM VocabList";
            SQLiteDataReader reader = sqlite_cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    VocabList vl = new VocabList();
                    vl.VocabListId = reader.GetInt32(0);
                    vl.VocabListName = reader.GetString(1);
                    data.Add(vl);
                }
            }

            dbConnection.Close();
            return data;
        }
    }
}
