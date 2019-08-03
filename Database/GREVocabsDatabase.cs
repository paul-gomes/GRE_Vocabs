﻿using System;
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
            string createVocabList = "CREATE TABLE IF NOT EXISTS VocabList(VocabListId INT PRIMARY KEY NOT NULL, VocabListName VARCHAR(50) NOT NULL)";
            sqlite_cmd.CommandText = createVocabList;
            sqlite_cmd.ExecuteNonQuery();

            //Creates table Words
            string createWords = "CREATE TABLE IF NOT EXISTS Words(WordId INT PRIMARY KEY NOT NULL, Word VARCHAR(20) NOT NULL, WordStatus VARCHAR(20) NOT NULL, VocabListId INT NOT NULL, FOREIGN KEY(VocabListId) REFERENCES VocabList(VocabListId))";
            sqlite_cmd.CommandText = createWords;
            sqlite_cmd.ExecuteNonQuery();

            //Insert Data On VocabList table
            sqlite_cmd.CommandText = "INSERT OR REPLACE INTO VocabList (VocabListId, VocabListName) VALUES (1, 'Manhattan Prep 3rd Edition');" +
                                     "INSERT OR REPLACE INTO VocabList(VocabListId, VocabListName) VALUES(2, 'ETS GRE Official Guide 3rd Edition');" +
                                     "INSERT OR REPLACE INTO VocabList(VocabListId, VocabListName) VALUES(3, 'Mangoosh GRE Vocab E-Book List');";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1, 'INCHOATE' , 'Learning',  1);" +
                                     "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(2, 'BESIEGE','Learning',  1);" +
                                     "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(3, 'AMALGAMATE','Learning',  1);";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (10001, 'SARTORIAL' , 'Learning',  2);" +
                                     "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(10002, 'EXOTIC','Learning',  2);" +
                                     "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(10003, 'DOGMATISM','Learning',  2);";
            sqlite_cmd.ExecuteNonQuery();

            dbConnection.Close();
        }

        //Gets all the vocabulary list
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

        //Gets all the words of the specific status
        public List<Words> GetWords(string wordStatus, int vocabListId)
        {
            List<Words> data = new List<Words>();
            dbConnection.Open();
            SQLiteCommand sqlite_cmd = dbConnection.CreateCommand();
            sqlite_cmd.CommandText = String.Format("SELECT * FROM Words WHERE Words.WordStatus = '{0}' AND Words.VocabListId = {1}", wordStatus, vocabListId);
            SQLiteDataReader reader = sqlite_cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Words word = new Words();
                    word.WordId = reader.GetInt32(0);
                    word.Word = reader.GetString(1);
                    word.WordStatus = reader.GetString(2);
                    word.VocabListId = reader.GetInt32(3);
                    data.Add(word);
                }
            }

            dbConnection.Close();
            return data;
        }

        //Updates wordStatus
        public void ClassifyWord(int wordId, string wordStatus)
        {
            dbConnection.Open();
            SQLiteCommand sqlite_cmd = dbConnection.CreateCommand();
            sqlite_cmd.CommandText = String.Format("UPDATE Words SET WordStatus = '{0}' WHERE WordId = {1}; ", wordStatus, wordId);
            SQLiteDataReader reader = sqlite_cmd.ExecuteReader();
            dbConnection.Close();
        }
    }
}
