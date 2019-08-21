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
        private static string sqliteFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/greVocabsDatabase";  // set folder for database
        private static string sqlitePw = "password"; // set password for database

        public GREVocabsDatabase()
        {
            // check if database file exist. when not, create with password
            if (!File.Exists(sqliteFile))
            {
                dbConnection = new SQLiteConnection("Data Source=" + sqliteFile);
                dbConnection.SetPassword(sqlitePw);
                createDb();
            }

            dbConnection = new SQLiteConnection("Data Source=" + sqliteFile + ";Password=" + sqlitePw); // connect to database
        }

        public void createDb()
        {
            dbConnection.Open();

            SQLiteCommand sqlite_cmd = dbConnection.CreateCommand();

            //Delete createVocablist table
            //string deleteVocabList = "DROP TABLE VocabList";
            //sqlite_cmd.CommandText = deleteVocabList;
            //sqlite_cmd.ExecuteNonQuery();

            //Creates table VocabList 
            string createVocabList = "CREATE TABLE IF NOT EXISTS VocabList(VocabListId INTEGER PRIMARY KEY, VocabListName VARCHAR(50) NOT NULL)";
            sqlite_cmd.CommandText = createVocabList;
            sqlite_cmd.ExecuteNonQuery();

            //Delete CreateWords table
            //string deleteWords = "DROP TABLE Words";
            //sqlite_cmd.CommandText = deleteWords;
            //sqlite_cmd.ExecuteNonQuery();

            //Creates table Words
            string createWords = "CREATE TABLE IF NOT EXISTS Words(WordId INTEGER PRIMARY KEY, Word VARCHAR(20) NOT NULL, WordStatus VARCHAR(20) NOT NULL, NumOfTimeTested INT NULL," +
                                 "NumOfTimeAccurate INT NULL, Accuracy REAL Null, VocabListId INTEGER, FOREIGN KEY(VocabListId) REFERENCES VocabList(VocabListId))";
            sqlite_cmd.CommandText = createWords;
            sqlite_cmd.ExecuteNonQuery();

            //Delete QuestionsBank Table
            //string deleteQuestionsBank = "DROP TABLE QuestionsBank";
            //sqlite_cmd.CommandText = deleteQuestionsBank;
            //sqlite_cmd.ExecuteNonQuery();

            //Creates table QuestionsBank
            string createQuestionsBank = "CREATE TABLE IF NOT EXISTS QuestionsBank(QuestionID INTEGER PRIMARY KEY, Question VARCHAR(255) NOT NULL, Option1 VARCHAR(20) NOT NULL," +
                                        "Option2 VARCHAR(20) NOT NULL, Option3 VARCHAR(20) NOT NULL, Option4 VARCHAR(20) NOT NULL, Answer VARCHAR(20) NOT NULL, NumberOfTimeAsked INT NULL," +
                                        "NumOfCorrectAns INT NULL, Accuracy REAL Null, WordId INTEGER, FOREIGN KEY(WordId) REFERENCES Words(WordId))";
            sqlite_cmd.CommandText = createQuestionsBank;
            sqlite_cmd.ExecuteNonQuery();

            //Insert Data On VocabList table
            sqlite_cmd.CommandText = "INSERT OR REPLACE INTO VocabList (VocabListId, VocabListName) VALUES (1, 'Manhattan Prep 3rd Edition');" +
                                     "INSERT OR REPLACE INTO VocabList(VocabListId, VocabListName) VALUES(2, 'Barron 800 Essential Words for GRE');" +
                                     "INSERT OR REPLACE INTO VocabList(VocabListId, VocabListName) VALUES(3, 'GRE Most Frequent Words On Vocabulary.com');" +
                                     "INSERT OR REPLACE INTO VocabList(VocabListId, VocabListName) VALUES(4, 'ETS GRE Official Guide 3rd Edition');";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1, 'INCHOATE' , 'Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(2, 'BESIEGE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(3, 'AMALGAMATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(4, 'EFFRONTERY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(5, 'RAREFY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(6, 'DIATRIBE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(7, 'PRECIPITATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(8, 'DISABUSE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(9, 'AVER','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(10, 'BOLSTER','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(11, 'UNDERMINE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(12, 'DELIBERATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(13, 'ASSUAGE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(14, 'LACONIC','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(15, 'LUCID','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(16, 'ENERVATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(17, 'MOROSE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(18, 'EULOGY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(19, 'PLACATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(20, 'ANTAGONISM','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(21, 'SKEPTICAL','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(22, 'INTREPID','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(23, 'MOLLIFY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(24, 'ANOMALOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(25, 'MUNDANE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(26, 'ABASE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(27, 'BURGEON','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(28, 'SAP','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(29, 'OCCULT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(30, 'GAINSAY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(31, 'PITH','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(32, 'GIST','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(33, 'HACKNEYED','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(34, 'CORROBORATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(35, 'PLASTICITY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(36, 'EBULLIENCE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(37, 'PLETHORA','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(38, 'ARTLESS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(39, 'ARTIFICE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(40, 'DIN','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(41, 'PRECARIOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(42, 'DEFAULT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(43, 'TORTUOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(44, 'TENUOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(45, 'PROFUSE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(46, 'PROPITIATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(47, 'ZENITH','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(48, 'DESICCATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(49, 'MALEDICTION','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(50, 'VENERATION','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(51, 'SANCTION','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(52, 'COMPLAISANT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(53, 'UBIQUITOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(54, 'DISTEND','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(55, 'VACILLATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(56, 'PERFIDY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(57, 'DERIVATIVE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(58, 'FRACAS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(59, 'EXPLICIT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(60, 'PRESUMPTUOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(61, 'EXTRANEOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(62, 'SLIGHT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(63, 'VIGOR','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(64, 'TRANSPARENT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(65, 'PRISTINE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(66, 'CONFOUND','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(67, 'CONSOLE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(68, 'DISCRETE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(69, 'SPECIOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(70, 'APPROBATION','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(71, 'CONCUR','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(72, 'NADIR','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(73, 'TRACTABILITY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(74, 'IMPERMEABLE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(75, 'DENUNCIATION','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(76, 'LACKLUSTER','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(77, 'FOMENT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(78, 'COLLUDE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(79, 'VERACITY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(80, 'DIFFUSE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(81, 'INNOCUOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(82, 'AUDACIOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(83, 'EXCULPATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(84, 'ABATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(85, 'OBSTINATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(86, 'PRODIGIOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(87, 'STOLID','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(88, 'ALLEVIATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(89, 'LEVY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(90, 'EXACERBATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(91, 'COVERT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(92, 'APPRISE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(93, 'RECALCITRANT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(94, 'DERISION','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(95, 'TACITURN','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(96, 'BLITHE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(97, 'CONVOKE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(98, 'CATHOLIC','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(99, 'MARTINET','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(100, 'PONDEROUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(101, 'FLAG','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(102, 'SOMATIC','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(103, 'FLUKE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(104, 'DOFF','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(105, 'APOCRYPHAL','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(106, 'SCURVY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(107, 'APPOSITE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(108, 'SQUALID','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(109, 'GARRULOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(110, 'GAMBOL','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(111, 'FULMINATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(112, 'SALUBRIOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(113, 'ABSCISSION','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(114, 'GAUCHE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(115, 'TRUCULENT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(116, 'ASPERITY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(117, 'FINESSE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(118, 'GERMANE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(119, 'VISCID','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(120, 'GLIB','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(121, 'REQUITE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(122, 'GROUSE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(123, 'APPRECIABLE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(124, 'DILATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(125, 'SUBSIDE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(126, 'REDUNDANT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(127, 'ANTIPATHY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(128, 'CONVOLUTED','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(129, 'MITIGATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(130, 'SANGFROID','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(131, 'IMPLOSION','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(132, 'CONDONE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(133, 'CATALYST','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(134, 'INTEMPERANCE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(135, 'STALWART','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(136, 'AUGMENT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(137, 'ABRIDGE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(138, 'INDIFFERENT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(139, 'VERBOSE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(140, 'SQUELCH','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(141, 'EMACIATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(142, 'EXTEMPORE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(143, 'FORESTALL','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(144, 'ANALOGOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(145, 'QUIESCENCE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(146, 'ADULTERATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(147, 'NABOB','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(148, 'CARDINAL','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(149, 'NOISOME','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(150, 'PUISSANCE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(151, 'RUE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(152, 'DILATORY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(153, 'VERISIMILAR','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(154, 'HOODWINK ','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(155, 'MISANTHROPE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(156, 'TEETOTALER','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(157, 'APATHETIC','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(158, 'PEDANTIC','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(159, 'INDELIBLE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(160, 'SCOTCH','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(161, 'CODA','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(162, 'HOMOGENEOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(163, 'FATUOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(164, 'INVETERATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(165, 'PERMEABLE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(166, 'PHILANTHROPIC','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(167, 'OSTRACIZE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(168, 'PROPAGATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(169, 'FIDELITY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(170, 'ABSTAIN','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(171, 'INHIBIT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(172, 'FACETIOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(173, 'INGENUOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(174, 'AFFABLE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(175, 'ADHERE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(176, 'SLACK','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(177, 'DIVERGE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(178, 'FREQUENT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(179, 'FRINGE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(180, 'EGRESS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(181, 'ASCEND','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(182, 'LAUDABLE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(183, 'RENT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(184, 'VOLATILE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(185, 'ASEPTIC','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(186, 'SKULLDUGGERY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(187, 'PREDILECTION','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(188, 'DIVESTITURE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(189, 'PROLOGUE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(190, 'GOSSAMER','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(191, 'DORMANT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(192, 'GRATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(193, 'GRATUITOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(194, 'HEGEMONY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(195, 'RIFT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(196, 'GRIEVOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(197, 'EPHEMERAL','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(198, 'ASPERSION','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(199, 'PALATIAL','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(200, 'HALCYON','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(201, 'ERUDITE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(202, 'DIFFIDENT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(203, 'ESCHEW','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(204, 'ENCOMIUM ','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(205, 'SAVANT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(206, 'SEDULOUS ','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(207, 'HALLMARK','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(208, 'HAPLESS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(209, 'SINECURE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(210, 'HARROW','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(211, 'EXHAUSTIVE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(212, 'HAVEN','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(213, 'CLINCH','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(214, 'STYMIE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(215, 'ENIGMA','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(216, 'WELTER','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(217, 'SUPPLICATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(218, 'ZEALOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(219, 'HYPERBOLE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(220, 'TORRID','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(221, 'IDYLL','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(222, 'TRAVESTY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(223, 'TURPITUDE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(224, 'FERVOR','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(225, 'CACOPHONY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(226, 'FLEDGE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(227, 'IMPASSIVE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(228, 'IMPECUNIOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(229, 'WARMONGER','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(230, 'IMPEDE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(231, 'ABHOR','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(232, 'PREVARICATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(233, 'DIVULGE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(234, 'PRECURSOR','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(235, 'FALLOW','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(236, 'OSTENTATIOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(237, 'IMPROBITY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(238, 'CONVERSANCE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(239, 'QUANDARY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(240, 'PROPRIETY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(241, 'IMPUDENT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(242, 'DWINDLE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(243, 'IMPUGN','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(244, 'CAPRICIOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(245, 'INADVERTENT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(246, 'RECUMBENT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(247, 'IMPROMPTU','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(248, 'ABJURE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(249, 'PALLID','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(250, 'REFULGENT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(251, 'AGGREGATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(252, 'DIDACTIC ','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(253, 'CENSURE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(254, 'ANARCHY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(255, 'INCIPIENT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(256, 'INCURSION','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(257, 'ENGENDER','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(258, 'AUTONOMOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(259, 'EQUANIMITY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(260, 'INDETERMINATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(261, 'CORRUGATED','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(262, 'UNSEEMLY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(263, 'INDIGENCE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(264, 'INDIGENOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(265, 'SENTIENT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(266, 'ESOTERIC','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(267, 'CHICANERY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(268, 'ESTIMABLE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(269, 'ABERRANT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(270, 'CRASS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(271, 'INGRATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(272, 'CRAVEN','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(273, 'ANOMALY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(274, 'AVID','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(275, 'COALESCE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(276, 'SUMMARILY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(277, 'INSULARITY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(278, 'EXTENUATING','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(279, 'CRYPTIC','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(280, 'TIRADE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(281, 'DAMP','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(282, 'TOUT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(283, 'FALLACIOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(284, 'PRAGMATIC','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(285, 'DEBACLE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(286, 'TRIBUTE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(287, 'INUNDATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(288, 'TURBULENCE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(289, 'INVEIGLE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(290, 'FERMENT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(291, 'ALACRITY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(292, 'FETID','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(293, 'DECOROUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(294, 'JABBER','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(295, 'JIBE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(296, 'GIBE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(297, 'JOCULAR','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(298, 'FECUND','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(299, 'REFRACTORY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(300, 'LABILE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(301, 'BASE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(302, 'PETTIFOGGER','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(303, 'CONFABULATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(304, 'FETTER','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(305, 'VAUNT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(306, 'SOPHOMORIC','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(307, 'AMORTIZE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(308, 'COWER','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(309, 'DISSONANCE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(310, 'BALEFUL','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(311, 'DISTENDED','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(312, 'PARADOX','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(313, 'PRETERNATURAL','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(314, 'PREEN','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(315, 'LAMBASTE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(316, 'LASSITUDE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(317, 'DIVEST','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(318, 'LEVITY ','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(319, 'PRODIGAL','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(320, 'BANAL','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(321, 'LAGGARD','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(322, 'PROFLIGATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(323, 'EXIGENT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(324, 'PROFUNDITY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(325, 'LIBERTINE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(326, 'LETHARGY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(327, 'HUSBAND','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(328, 'FORD','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(329, 'LIMPID','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(330, 'PROSCRIBE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(331, 'LIST','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(332, 'PUNGENCY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(333, 'LOLL','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(334, 'LOQUACIOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(335, 'IMPUTE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(336, 'QUELL','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(337, 'PIQUE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(338, 'LULL','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(339, 'CANON','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(340, 'QUACK','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(341, 'LUMBER','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(342, 'MACERATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(343, 'DESULTORY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(344, 'EPICURE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(345, 'REBUFF','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(346, 'RECANT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(347, 'RECONDITE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(348, 'SOPORIFIC','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(349, 'BELIE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(350, 'REDOUBTABLE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(351, 'MEANDER','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(352, 'MENDACIOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(353, 'MERCURIAL','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(354, 'METAPHYSICAL','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(355, 'SALIENT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(356, 'METAMORPHOSE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(357, 'NORMATIVE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(358, 'SHYSTER','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(359, 'MIMETIC','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(360, 'CREPUSCULAR','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(361, 'SYNCRETISM','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(362, 'ECUMENICAL','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(363, 'ROCOCO','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(364, 'CASTIGATION','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(365, 'REPINE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(366, 'METEORIC','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(367, 'MINATORY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(368, 'ENDEMIC','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(369, 'ABROGATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(370, 'BROACH','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(371, 'DEPOSITION','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(372, 'ACCRETION','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(373, 'LIONIZE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(374, 'REVERE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(375, 'BOISTEROUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(376, 'OPPROBRIUM','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(377, 'SATE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(378, 'NASCENT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(379, 'EQUITABLE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(380, 'NATTY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(381, 'ACCOLADE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(382, 'SEAMY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(383, 'SEDULOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(384, 'EFFACE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(385, 'NEOLOGISM','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(386, 'SEMINAL','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(387, 'NEXUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(388, 'TACIT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(389, 'SUPINE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(390, 'CAUSTIC','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(391, 'NUGATORY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(392, 'MAELSTROM','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(393, 'BOMBASTIC','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(394, 'ESTRANGE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(395, 'OBSTINACY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(396, 'SINEWY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(397, 'BOOR','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(398, 'OCCLUDED','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(399, 'SLEW','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(400, 'CONTINENT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(401, 'CESSATION','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(402, 'ODIUM','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(403, 'SODDEN','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(404, 'SURFEIT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(405, 'SOLVENT','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(406, 'BREACH','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(407, 'ONEROUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(408, 'FERVID','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(409, 'MACHINCATIONS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(410, 'LETHARGIC','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(411, 'CHARY','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(412, 'SARDONIC','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(413, 'TENDENTIOUS','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(414, 'PUERILE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(415, 'BEDIZEN','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(416, 'INTERNECINE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(417, 'SCREED','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(418, 'SERE','Learning',  1);" +
                                    "INSERT OR REPLACE INTO Words (WordId, Word, WordStatus, VocabListId) VALUES(419, 'SEMIOTICS','Learning',  1);";

            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1001, 'ABATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1002, 'ABDICATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1003, 'ABERRANT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1004, 'ABEYANCE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1005, 'ABJECT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1006, 'ABJURE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1007, 'ABSCISSION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1008, 'ABSCOND' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1009, 'ABSTEMIOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1010, 'ABSTINENCE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1011, 'ABYSMAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1012, 'ACCRETION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1013, 'ACCRUE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1014, 'ADAMANT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1015, 'ADJUNCT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1016, 'ADMONISH' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1017, 'ADULTERATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1018, 'AESTHETIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1019, 'AFFECTED' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1020, 'AFFINITY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1021, 'AGGRANDIZE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1022, 'AGGREGATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1023, 'ALACRITY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1024, 'ALCHEMY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1025, 'ALLAY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1026, 'ALLEVIATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1027, 'ALLOY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1028, 'ALLURE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1029, 'AMALGAMATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1030, 'AMBIGUOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1031, 'AMBIVALENCE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1032, 'AMBROSIA' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1033, 'AMELIORATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1034, 'AMENABLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1035, 'AMENITY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1036, 'AMULET' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1037, 'ANACHRONISM' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1038, 'ANALGESIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1039, 'ANALOGOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1040, 'ANARCHY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1041, 'ANODYNE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1042, 'ANOMALOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1043, 'ANTECEDENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1044, 'ANTEDILUVIAN' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1045, 'ANTIPATHY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1046, 'APATHY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1047, 'APEX' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1048, 'APOGEE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1049, 'APOTHEGM' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1050, 'APPEASE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1051, 'APPELLATION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1052, 'APPOSITE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1053, 'APPRISE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1054, 'APPROBATION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1055, 'APPROPRIATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1056, 'ARABESQUE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1057, 'ARCHEOLOGY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1058, 'ARDOR' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1059, 'ARDUOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1060, 'ARGOT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1061, 'ARREST' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1062, 'ARTIFACT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1063, 'ARTLESS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1064, 'ASCETIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1065, 'ASPERITY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1066, 'ASPERSION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1067, 'ASSIDUOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1068, 'ASSUAGE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1069, 'ASTRINGENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1070, 'ASYLUM' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1071, 'ATAVISM' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1072, 'ATTENUATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1073, 'AUDACIOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1074, 'AUSTERE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1075, 'AUTONOMOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1076, 'AVARICE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1078, 'AVOCATION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1079, 'AVUNCULAR' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1080, 'AXIOMATIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1081, 'BACCHANALIAN' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1082, 'BANAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1083, 'BANTER' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1084, 'BARD' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1085, 'BAWDY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1086, 'BEATIFY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1087, 'BEHEMOTH' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1088, 'BELIE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1089, 'BENEFICENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1090, 'BIFURCATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1091, 'BLANDISHMENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1092, 'BLASE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1093, 'BOLSTER' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1094, 'BOORISH' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1095, 'BOVINE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1096, 'BRAZEN' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1097, 'BROACH' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1098, 'BUCOLIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1099, 'BURGEON' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1100, 'BURNISH' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1101, 'BUTTRESS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1102, 'CACOPHONOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1103, 'CADGE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1104, 'CALLOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1105, 'CALUMNY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1106, 'CANARD' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1107, 'CANT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1108, 'CANTANKEROUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1109, 'CAPRICIOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1110, 'CAPTIOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1111, 'CARDINAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1112, 'CARNAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1113, 'CARPING' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1114, 'CARTOGRAPHY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1115, 'CASTE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1116, 'CASTIGATION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1117, 'CATACLYSM' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1118, 'CATALYST' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1119, 'CATEGORICAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1120, 'CAUCUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1121, 'CAUSAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1122, 'CAUSTIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1123, 'CELESTIAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1124, 'CENTRIFUGAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1125, 'CENTRIPETAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1126, 'CHAMPION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1127, 'CHASTEN' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1128, 'CHICANERY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1129, 'CHIVALRY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1130, 'CHURLISH' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1131, 'CIRCUITOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1132, 'CLAIRVOYANT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1133, 'CLAMOR' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1134, 'CLIQUE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1135, 'CLOISTER' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1136, 'COAGULATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1137, 'COALESCE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1138, 'CODA' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1139, 'CODIFY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1140, 'COGNIZANT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1141, 'COLLAGE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1142, 'COMMENSURATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1143, 'COMPENDIUM' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1144, 'COMPLACENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1145, 'COMPLAISANT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1146, 'COMPLEMENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1147, 'COMPLIANT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1148, 'COMPUNCTION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1149, 'CONCAVE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1150, 'CONCILIATORY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1151, 'CONCOCT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1152, 'CONCOMITANT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1153, 'CONDONE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1154, 'CONFOUND' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1155, 'CONGENIAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1156, 'CONJUGAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1157, 'CONNOISSEUR' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1158, 'CONSCRIPT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1159, 'CONSECRATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1160, 'CONTEND' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1161, 'CONTENTIOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1162, 'CONTIGUOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1163, 'CONTINENCE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1164, 'CONTRITE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1165, 'CONTUMACIOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1166, 'CONUNDRUM' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1167, 'CONVENTION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1168, 'CONVERGE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1169, 'CONVEX' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1170, 'CONVIVIAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1171, 'CONVOLUTED' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1172, 'COPIOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1173, 'COQUETTE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1174, 'CORNUCOPIA' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1175, 'COSMOLOGY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1176, 'COVERT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1177, 'COVETOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1178, 'COZEN' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1179, 'CRAVEN' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1180, 'CREDENCE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1181, 'CREDO' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1182, 'DAUNT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1183, 'DEARTH' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1184, 'DEBAUCHERY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1185, 'DECORUM' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1186, 'DEFAME' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1187, 'DEFAULT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1188, 'DEFERENCE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1189, 'DEFUNCT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1190, 'DELINEATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1191, 'DEMOGRAPHIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1192, 'DEMOTIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1193, 'DEMUR' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1194, 'DENIGRATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1195, 'DENIZEN' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1196, 'DENOUEMENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1197, 'DERIDE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1198, 'DERIVATIVE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1199, 'DESICCATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1200, 'DESUETUDE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1201, 'DESULTORY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1202, 'DETERRENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1203, 'DETRACTION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1204, 'DIAPHANOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1205, 'DIATRIBE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1206, 'DICHOTOMY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1207, 'DIFFIDENCE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1208, 'DIFFUSE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1209, 'DIGRESSION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1210, 'DIRGE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1211, 'DISABUSE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1212, 'DISCERNING' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1213, 'DISCOMFIT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1214, 'DISCORDANT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1215, 'DISCREDIT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1216, 'DISCREPANCY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1217, 'DISCRETE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1218, 'DISCRETION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1219, 'DISINGENUOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1220, 'DISINTERESTED' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1221, 'DISJOINTED' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1222, 'DISMISS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1223, 'DISPARAGE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1224, 'DISPARATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1225, 'DISSEMBLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1226, 'DISSEMINATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1227, 'DISSIDENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1228, 'DISSOLUTION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1229, 'DISSONANCE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1230, 'DISTEND' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1231, 'DISTILL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1232, 'DISTRAIT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1233, 'DIVERGE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1234, 'DIVEST' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1235, 'DIVULGE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1236, 'DOCTRINAIRE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1237, 'DOCUMENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1238, 'DOGGEREL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1239, 'DOGMATIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1240, 'DORMANT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1241, 'DROSS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1242, 'DUPE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1243, 'EBULLIENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1244, 'ECLECTIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1245, 'EFFERVESCENCE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1246, 'EFFETE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1247, 'EFFICACY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1248, 'EFFRONTERY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1249, 'EGOISM' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1250, 'EGOTISTICAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1251, 'ELEGY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1252, 'ELICIT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1253, 'ELIXIR' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1254, 'ELYSIAN' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1255, 'EMACIATED' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1256, 'EMBELLISH' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1257, 'EMOLLIENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1258, 'EMPIRICAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1259, 'EMULATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1260, 'ENCOMIUM' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1261, 'ENDEMIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1262, 'ENERVATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1263, 'ENGENDER' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1264, 'ENHANCE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1265, 'ENTOMOLOGY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1266, 'ENUNCIATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1267, 'EPHEMERAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1268, 'EPISTEMOLOGY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1269, 'EQUABLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1270, 'EQUANIMITY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1271, 'EQUIVOCATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1272, 'ERRANT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1273, 'ESOTERIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1274, 'ESSAY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1275, 'ESTIMABLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1276, 'ETHNOCENTRIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1277, 'ETIOLOGY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1278, 'ETYMOLOGY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1279, 'EUGENICS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1280, 'EULOGY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1281, 'EUPHEMISM' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1282, 'EUPHORIA' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1283, 'EUTHANASIA' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1284, 'EVINCE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1285, 'EVOCATIVE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1286, 'EXACERBATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1287, 'EXACT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1288, 'EXECRABLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1289, 'EXHORT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1290, 'EXIGENCY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1291, 'EXISTENTIAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1292, 'EXORCISE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1293, 'EXPATIATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1294, 'EXPATRIATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1295, 'EXPIATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1296, 'EXPLICATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1297, 'EXPOSITORY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1298, 'EXTANT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1299, 'EXTEMPORANEOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1300, 'EXTIRPATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1301, 'EXTRANEOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1302, 'EXTRAPOLATION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1303, 'EXTRINSIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1304, 'FACILITATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1305, 'FACTOTUM' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1306, 'FALLACIOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1307, 'FALLOW' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1308, 'FATUOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1309, 'FAUNA' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1310, 'FAWNING' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1311, 'FELICITOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1312, 'FERAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1313, 'FERVOR' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1314, 'FETID' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1315, 'FIAT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1316, 'FIDELITY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1317, 'FILIBUSTER' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1318, 'FINESSE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1319, 'FISSURE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1320, 'FLAG' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1321, 'FLEDGING' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1322, 'FLORA' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1323, 'FLORID' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1324, 'FLOURISH' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1325, 'FLOUT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1326, 'FLUX' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1327, 'FOMENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1328, 'FORBEARANCE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1329, 'FORESTALL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1330, 'FORMIDABLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1331, 'FORSWEAR' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1332, 'FOUNDER' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1333, 'FRACTIOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1334, 'FRESCO' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1335, 'FRIEZE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1336, 'FROWARD' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1337, 'FRUGALITY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1338, 'FULSOME' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1339, 'FUSION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1340, 'FUTILE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1341, 'GENIALITY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1342, 'GERRYMANDER' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1343, 'GOAD' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1344, 'GOUGE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1345, 'GRANDILOQUENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1346, 'GREGARIOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1347, 'GUILELESS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1348, 'GUISE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1349, 'GULLIBLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1350, 'GUSTATORY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1351, 'HALLOWED' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1352, 'HARANGUE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1353, 'HARROWING' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1354, 'HERBIVOROUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1355, 'HERMETIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1356, 'HETERODOX' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1357, 'HIEROGLYPHICS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1358, 'HIRSUTE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1359, 'HISTRIONIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1360, 'HOMEOSTASIS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1361, 'HOMILY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1362, 'ICONOCLASTIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1363, 'IDOLATRY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1364, 'IGNEOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1365, 'IMBROGLIO' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1366, 'IMMUTABLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1367, 'IMPAIR' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1368, 'IMPERTURBABLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1369, 'IMPERVIOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1370, 'IMPINGE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1371, 'IMPLACABLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1372, 'IMPLAUSIBLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1373, 'IMPLICIT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1374, 'IMPLODE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1375, 'IMPRECATION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1376, 'INADVERTENTLY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1377, 'INCARNATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1378, 'INCONGRUITY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1379, 'INCONSEQUENTIAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1380, 'INCORPORATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1381, 'INDOLENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1382, 'INELUCTABLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1383, 'INERT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1384, 'INHERENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1385, 'INSENSIBLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1386, 'INSINUATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1387, 'INSIPID' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1388, 'INSOUCIANT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1389, 'INSUPERABLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1390, 'INTANGIBLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1391, 'INTERDICT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1392, 'INTERPOLATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1393, 'INTERREGNUM' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1394, 'INTIMATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1395, 'INTRACTABLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1396, 'INTRANSIGENCE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1397, 'INTROSPECTIVE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1398, 'INURED' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1399, 'INVECTIVE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1400, 'INVEIGH' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1401, 'INVIDIOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1402, 'IRASCIBLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1403, 'IRRESOLUTE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1404, 'ITINERANT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1405, 'ITINERARY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1406, 'JAUNDICED' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1407, 'JOCOSE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1408, 'JUGGERNAUT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1409, 'JUNTA' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1410, 'JUXTAPOSE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1411, 'KUDOS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1412, 'LASCIVIOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1413, 'LATENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1414, 'LAUD' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1415, 'LEVEE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1416, 'LIBERAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1417, 'LIBIDO' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1418, 'LILLIPUTIAN' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1419, 'LIMN' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1420, 'LINGUISTIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1421, 'LITANY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1422, 'LITERATI' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1423, 'LITIGATION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1424, 'LOG' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1425, 'LUCRE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1426, 'LUMINOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1427, 'LUSTROUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1428, 'MACHIAVELLIAN' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1429, 'MACHINATIONS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1430, 'MAGNANIMITY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1431, 'MALIGN' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1432, 'MALINGER' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1433, 'MALLEABLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1434, 'MAVERICK' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1435, 'MEGALOMANIA' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1436, 'MENAGERIE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1437, 'MENDICANT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1438, 'MERETRICIOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1439, 'MESMERIZE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1440, 'METAMORPHOSIS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1441, 'METAPHYSICS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1442, 'METEOROLOGICAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1443, 'METICULOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1444, 'METTLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1445, 'METTLESOME' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1446, 'MICROCOSM' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1447, 'MILITATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1448, 'MINUSCULE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1449, 'MINUTIA' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1450, 'MISCELLANY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1451, 'MISCREANT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1452, 'MISOGYNIST' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1453, 'MNEMONIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1454, 'MODICUM' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1455, 'MONOLITHIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1456, 'MOTLEY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1457, 'MULTIFARIOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1458, 'NECROMANCY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1459, 'NEGATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1460, 'NEOPHYTE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1461, 'NONPLUSSED' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1462, 'NOSTALGIA' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1463, 'NOSTRUM' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1464, 'OBDURATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1465, 'OBSEQUIOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1466, 'OBSEQUY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1467, 'OBVIATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1468, 'OCCLUDE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1469, 'OCCULT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1470, 'ODYSSEY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1471, 'OFFICIOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1472, 'OLFACTORY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1473, 'OLIGARCHY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1474, 'ONOMATOPOEIA' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1475, 'ORNITHOLOGIST' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1476, 'OSCILLATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1477, 'OVERWEENING' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1478, 'PAEAN' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1479, 'PALEONTHOLOGY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1480, 'PANEGYRIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1481, 'PARAGON' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1482, 'PARTISAN' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1483, 'PATHOLOGICAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1484, 'PATOIS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1485, 'PAUCITY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1486, 'PELLUCID' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1487, 'PENCHANT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1488, 'PENURY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1489, 'PEREGRINATION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1490, 'PEREMPTORY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1491, 'PERENNIAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1492, 'PERFIDIOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1493, 'PERFUNCTORY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1494, 'PERIGEE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1495, 'PERTURB' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1496, 'PERVASIVE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1497, 'PETULANT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1498, 'PHOENIX' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1499, 'PHYSIOGNOMY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1500, 'PIETY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1501, 'PIQUANT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1502, 'PLACID' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1503, 'PLAINTIVE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1504, 'PLATITUDE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1505, 'PLATONIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1506, 'PLUMB' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1507, 'PLUMMET' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1508, 'PLUTOCRACY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1509, 'POROUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1510, 'POSEUR' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1511, 'PRATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1512, 'PRATTLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1513, 'PREAMBLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1514, 'PRECEPT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1515, 'PREEMPT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1516, 'PREHENSILE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1517, 'PREMONITION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1518, 'PRESAGE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1519, 'PRIMORDIAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1520, 'PROBITY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1521, 'PROBLEMATIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1522, 'PROFOUND' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1523, 'PROHIBITIVE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1524, 'PROLIFERATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1525, 'PROPENSITY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1526, 'PROVIDENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1527, 'PUISSANT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1528, 'PUNCTILIOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1529, 'PUNGENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1530, 'PURPORT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1531, 'PUSILLANIMOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1532, 'QUAGMIRE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1533, 'QUAIL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1534, 'QUALIFIED' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1535, 'QUALM' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1536, 'QUERY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1537, 'QUIBBLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1538, 'QUIESCENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1539, 'RACONTEUR' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1540, 'RAIL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1541, 'RAIMENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1542, 'RAMIFICATION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1543, 'RAREFIED' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1544, 'RATIONALE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1545, 'REBU' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1546, 'RECLUSE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1547, 'REDOBTABLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1548, 'REFUTE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1549, 'REGALE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1550, 'RELEGATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1551, 'REMONSTRATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1552, 'RENEGE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1553, 'REPARATION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1554, 'REPRISE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1555, 'REPROACH' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1556, 'REPROBATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1557, 'REPUDIATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1558, 'RESCIND' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1559, 'RESOLUTION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1560, 'RESOLVE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1561, 'RETICENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1562, 'REVERENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1563, 'RIPOSTE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1564, 'RUBRIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1565, 'RUSE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1566, 'SAGE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1567, 'SALACIOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1568, 'SALUTARY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1569, 'SARTORIAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1570, 'SATIATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1571, 'SATURATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1572, 'SATURNINE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1573, 'SATYR' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1574, 'SAVOR' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1575, 'SCHEMATIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1576, 'SECRETE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1577, 'SEISMIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1578, 'SENSUAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1579, 'SENSUOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1580, 'SERVILE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1581, 'SEXTANT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1582, 'SHARD' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1583, 'SIDEREAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1584, 'SIMIAN' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1585, 'SIMILE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1586, 'SINGULAR' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1587, 'SINUOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1588, 'SKEPTIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1589, 'SOBRIETY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1590, 'SOLICITOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1591, 'SOLILOQUY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1592, 'SORDID' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1593, 'SPECTRUM' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1594, 'SPENDTHRIFT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1595, 'SPORADIC' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1596, 'SQUALOR' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1597, 'STACCATO' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1598, 'STANCH' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1599, 'STENTORIAN' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1600, 'STIGMA' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1601, 'STINT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1602, 'STIPULATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1603, 'STRATIFIED' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1604, 'STRIATED' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1605, 'STRICTURE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1606, 'STRIDENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1607, 'STRUT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1608, 'STULTIFY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1609, 'STUPEFY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1610, 'STYGIAN' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1611, 'SUBPOENA' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1612, 'SUBSTANTIATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1613, 'SUBSTANTIVE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1614, 'SUBSUME' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1615, 'SUBVERSIVE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1616, 'SUCCOR' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1617, 'SUFFRAGE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1618, 'SUNDRY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1619, 'SUPERSEDE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1620, 'SUPPLANT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1621, 'SUPPLIANT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1622, 'SUPPLICANT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1623, 'SUPPOSITION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1624, 'SYLLOGISM' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1625, 'SYLVAN' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1626, 'TALISMAN' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1627, 'TANGENTIAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1628, 'TAUTOLOGY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1629, 'TAXONOMY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1630, 'TENET' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1631, 'TERRESTRIAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1632, 'THEOCRACY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1633, 'THESPIAN' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1634, 'TIMBRE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1635, 'TIRADE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1636, 'TOADY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1637, 'TOME' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1638, 'TORPOR' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1639, 'TORQUE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1640, 'TRACTABLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1641, 'TRANSGRESSION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1642, 'TRANSIENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1643, 'TRANSLUCENT' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1644, 'TRAVAIL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1645, 'TREATISE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1646, 'TREMULOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1647, 'TREPIDATION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1648, 'TRUCULENCE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1649, 'TRYST' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1650, 'TUMID' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1651, 'TURBID' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1652, 'TURGID' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1653, 'TUTELARY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1654, 'UNCANNY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1655, 'UNDULATING' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1656, 'UNFEIGNED' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1657, 'UNTENABLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1658, 'UNTOWARD' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1659, 'USURY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1660, 'VACUOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1661, 'VALEDICTORY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1662, 'VAPID' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1663, 'VARIEGATED' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1664, 'VENAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1665, 'VENDETTA' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1666, 'VENERATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1667, 'VERACIOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1668, 'VERTIGO' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1669, 'VEXATION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1670, 'VIABLE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1671, 'VINDICTIVE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1672, 'VIRTUOSO' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1673, 'VISAGE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1674, 'VISCOUS' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1675, 'VITIATE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1676, 'VITUPERATIVE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1677, 'VIVISECTION' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1678, 'VOGUE' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1679, 'VORTEX' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1680, 'WARRANTED' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1681, 'WARY' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1682, 'WHIMSICAL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1683, 'WISTFUL' , 'Learning',  2);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (1684, 'ZEALOT' , 'Learning',  2);";


            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2001, 'DISSEMINATE' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2002, 'COAGULATE' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2003, 'DISSOLUTION' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2004, 'ABEYANCE' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2005, 'ABSCOND' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2006, 'COGENT' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2007, 'ABSTEMIOUS' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2008, 'COMMENSURATE' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2009, 'DISTILL' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2010, 'ADMONISH' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2011, 'COMPENDIUM' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2012, 'AESTHETIC' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2013, 'COMPLIANT' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2014, 'DOCUMENT' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2015, 'CONCILIATORY' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2016, 'DOGMATIC' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2017, 'DUPE' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2018, 'MALINGERER' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2019, 'CONNOISSEUR' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2020, 'EBULLIENT' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2021, 'AMBIGUOUS' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2022, 'CONTENTION' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2023, 'ECLECTIC' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2024, 'AMBIVALENCE' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2025, 'CONTENTIOUS' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2026, 'EFFICACY' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2027, 'AMELIORATE' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2028, 'CONTRITE' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2029, 'ANACHRONISM' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2030, 'ELEGY' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2031, 'CONVERGE' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2032, 'ELICIT' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2033, 'EMBELLISH' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2034, 'EMPIRICAL' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2035, 'DAUNT' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2036, 'EMULATE' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2037, 'APATHY' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2038, 'DECORUM' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2039, 'APPEASE' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2040, 'DEFERENCE' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2041, 'DELINEATE' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2042, 'ENHANCE' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2043, 'DENIGRATE' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2044, 'ARDUOUS' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2045, 'EQUIVOCATE' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2046, 'ASCETIC' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2047, 'ASSIDUOUS' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2048, 'DETERRENT' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2049, 'ATTENUATE' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2050, 'EUPHEMISM' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2051, 'DICHOTOMY' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2052, 'AUSTERE' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2053, 'DIFFIDENCE' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2054, 'PATE' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2055, 'EXIGENCY' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2056, 'DIGRESSION' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2057, 'EXTRAPOLATION' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2058, 'DIRGE' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2059, 'FACILITATE' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2060, 'BENEFICENT' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2061, 'DISCERNING' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2062, 'DISCORDANT' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2063, 'DISCREDIT' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2064, 'FAWNING' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2065, 'BOORISH' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2066, 'FELICITOUS' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2067, 'BURNISH' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2068, 'DISINGENUOUS' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2069, 'BUTTRESS' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2070, 'DISINTERESTED' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2071, 'FLEDGLING' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2072, 'CACOPHONOUS' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2073, 'DISJOINTED' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2074, 'FLOUT' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2075, 'PHLEGMATIC' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2076, 'DISMISS' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2077, 'DISPARATE' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2078, 'STRIATE' , 'Learning',  3);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (2079, 'UNWARRANTED' , 'Learning',  3);";


            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3001, 'PAPARAZZO' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3002, 'IMPROBABLE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3003, 'ANTINOMIAN' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3004, 'YEARN' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3005, 'RAVAGED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3006, 'ENTRENCHED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3007, 'UNSOUND' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3008, 'TACITURNITY' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3009, 'GRACIOUS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3010, 'VOLUBILITY' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3011, 'ABREAST' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3012, 'BESIEGED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3013, 'HYPOTHESIS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3014, 'DIFFERENTIATE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3015, 'DISSENT' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3016, 'MELDING' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3017, 'PROBE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3018, 'DISENTANGLEMENT' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3019, 'REMEDIAL' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3020, 'ECSTATIC' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3021, 'TRITE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3022, 'SYNOPTIC' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3023, 'CONFORMIST' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3024, 'PROLIXITY' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3025, 'MARVELOUSLY' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3026, 'RELENTLESS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3027, 'ENIGMATIC' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3028, 'DEBUNK' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3029, 'TUMULTUOUS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3030, 'TENDENTIOUSNESS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3031, 'DISAFFECTION' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3032, 'RENEWED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3033, 'CONSUMERISM' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3034, 'BOGUS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3035, 'INFUSION' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3036, 'WARRING' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3037, 'CLERICAL' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3038, 'EXTRAVAGANCE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3039, 'DEFERENTIAL' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3040, 'FRIVOLOUS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3041, 'DOGMATISM' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3042, 'CONTROVERSIAL' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3043, 'BELLIGERENT' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3044, 'PROPPED UP' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3045, 'DIDACTICISM' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3046, 'DIVERGENCE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3047, 'DISCERN' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3048, 'PRECARIOUSLY' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3049, 'VERITABLE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3050, 'GLEAMING' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3051, 'REQUISITE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3052, 'PROSAIC' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3053, 'CONSPICUOUS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3054, 'CRUDE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3055, 'AID' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3056, 'BETRAY' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3057, 'PERIPHERAL' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3058, 'STRIDING' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3059, 'STARLET' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3060, 'BOLSTERED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3061, 'INTERGALACTIC' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3062, 'VIGILANT' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3063, 'TEMPERANCE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3064, 'REVERENCE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3065, 'ANTITHETICAL' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3066, 'LURID' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3067, 'SCATHING' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3068, 'PROPHETIC' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3069, 'COPIOUS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3070, 'NOTORIETY' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3071, 'PLUTOCRATIC' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3072, 'TRIVIAL' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3073, 'OVERSHADOW' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3074, 'RESOLUTE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3075, 'ARBITRARY' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3076, 'NOVELTY' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3077, 'EMINENCE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3078, 'DISGRUNTLED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3079, 'FORSAKE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3080, 'OBLIGATION' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3081, 'MISNOMER' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3082, 'DISQUIETING' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3083, 'REVIVE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3084, 'TRIAGE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3085, 'COMPELLING' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3086, 'PRECLUDE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3087, 'OBSCURITIES' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3088, 'DISTORTED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3089, 'RELIANCE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3090, 'DETRIMENT' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3091, 'LUDDITE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3092, 'INTENSIFICATION' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3093, 'COMPLEMENTARY' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3094, 'AMPLE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3095, 'COMPELLED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3096, 'UNDISCOVERED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3097, 'IMPERCEPTIBLY' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3098, 'ROW' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3099, 'FESTERING' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3100, 'PERSUASIVE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3101, 'ANTEDATED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3102, 'VIGOROUS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3103, 'THRIVE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3104, 'VOCIFEROUS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3105, 'DICHOTOMIES' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3106, 'PORTRAYED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3107, 'RESTIVE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3108, 'ACQUISITIVE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3109, 'HEED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3110, 'INFANTILIZE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3111, 'ERRONEOUS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3112, 'UNFETTERED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3113, 'PREDICAMENT' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3114, 'UNPRECEDENTED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3115, 'THRIFT' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3116, 'ILLIBERALITY' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3117, 'ETHOS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3118, 'PECULIAR' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3119, 'SURPASS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3120, 'PENITENTIAL' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3121, 'REINED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3122, 'DISPASSIONATE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3123, 'DEBILITATING' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3124, 'OPPRESS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3125, 'CLOAKED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3126, 'INCONGRUOUS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3127, 'ASSERT' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3128, 'RUMINATION' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3129, 'FALTER' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3130, 'SCHISM' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3131, 'FACTION' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3132, 'LAX' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3133, 'EXACTING' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3134, 'LAYMAN' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3135, 'STANCE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3136, 'FORTHRIGHT' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3137, 'TRANSCEND' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3138, 'GRATIFYING' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3139, 'ENCHANTED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3140, 'CURTAILED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3141, 'SUBTLE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3142, 'ALIENATED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3143, 'CAPRICE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3144, 'MARGINALIZATION' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3145, 'MONOTONOUS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3146, 'INTELLECT' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3147, 'ESTRANGEMENT' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3148, 'COHERENT' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3149, 'STINGINESS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3150, 'FORTUITOUS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3151, 'CONFORMITY' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3152, 'IMMINENT' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3153, 'AGRARIAN' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3154, 'LIONIZED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3155, 'EXACERBATED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3156, 'BREVITY' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3157, 'TRANQUIL' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3158, 'CUTBACK' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3159, 'IMPRUDENT' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3160, 'INTRANSIGENT' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3161, 'OPERA' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3162, 'NUANCES' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3163, 'EXOTIC' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3164, 'BENIGN' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3165, 'ATTENUATION' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3166, 'PARADIGM' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3167, 'DEVATATING' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3168, 'TEMPO' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3169, 'AIRA' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3170, 'IMPARTIAL' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3171, 'ORTHODOX' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3172, 'PREPONDERANCE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3173, 'INVIGORATION' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3174, 'HUMDRUM' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3175, 'BANISH' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3176, 'APOSTLE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3177, 'PANACHE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3178, 'PLODDINGLY' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3179, 'OMNIPRESENT' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3180, 'CIRCUMSCRIBED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3181, 'ANICIPATE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3182, 'PITHY' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3183, 'MENACING' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3184, 'ABRIDGED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3185, 'INTRINSIC' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3186, 'HOLISTIC' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3187, 'INJUDICIOUS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3188, 'POLEMIC' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3189, 'FASTIDIOUSNESS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3190, 'MORONS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3191, 'CLOAK' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3192, 'FRACTIOUSNESS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3193, 'QUANDARIES' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3194, 'MANACLED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3195, 'CORROBOARATED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3196, 'ECCENTRIC' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3197, 'INCONCEIVABLE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3198, 'PELLUCIDITY' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3199, 'INIMICAL' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3200, 'CONSENSUS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3201, 'UNGAINLY' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3202, 'COGENCY' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3203, 'CEREBRAL' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3204, 'MATERIALISM' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3205, 'ALOOF' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3206, 'MALIGNANT' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3207, 'FORBIDDING' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3208, 'GAWKINESS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3209, 'SHAM' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3210, 'FAVOR' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3211, 'DISTINCTIVE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3212, 'PROVIDENTIAL' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3213, 'SUPERFLUOUS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3214, 'ASTOUNDING' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3215, 'POPULOUS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3216, 'DEFY' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3217, 'SIDESWIPE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3218, 'TRIFLING' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3219, 'AUTOMATONS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3220, 'EGALITARIAN' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3221, 'PREMATURE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3222, 'ACERBIC' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3223, 'INCESSANT' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3224, 'UNSPARING' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3225, 'AQUIFER' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3226, 'RECONCILE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3227, 'INCONCLUSIVE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3228, 'VIRULENCE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3229, 'COVERINGS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3230, 'CYNICAL' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3231, 'EUPHORIC' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3232, 'DISPOSITION' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3233, 'CHARISMA' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3234, 'CRESTFALLEN' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3235, 'RETROSPECTIVE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3236, 'FLEETING' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3237, 'AMELIORATED' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3238, 'SCRUPULOUS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3239, 'COMPLACENT' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3240, 'RUINOUS' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3241, 'STRIVE' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3242, 'OMNISCIENT' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3243, 'SKITTISH' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3244, 'ENTAIL' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3245, 'ACCORD' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3246, 'SYNTACTICAL' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3247, 'IMPETUOUSLY' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3248, 'QUIXOTIC' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3249, 'BRANDISH' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3250, 'IMPERIOUSLY' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3251, 'DETACHMENT' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3252, 'RATIONALITY' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3253, 'WIZARDRY' , 'Learning',  4);" +
                                    "INSERT OR REPLACE INTO Words(WordId, Word, WordStatus, VocabListId) VALUES (3254, 'INDISCERNIBLE' , 'Learning',  4);";


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
        //Gets all words
        public List<Words> GetAllWords()
        {
            List<Words> data = new List<Words>();
            dbConnection.Open();
            SQLiteCommand sqlite_cmd = dbConnection.CreateCommand();
            sqlite_cmd.CommandText = String.Format("SELECT * FROM Words");
            SQLiteDataReader reader = sqlite_cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Words word = new Words();
                    word.WordId = reader.GetInt32(0);
                    word.Word = reader.GetString(1);
                    word.WordStatus = reader.GetString(2);
                    word.NumOfTimeTested = Convert.IsDBNull(reader.GetValue(3)) ? 0 : Convert.ToInt32(reader.GetValue(3));
                    word.NumOfTimeAccurate = Convert.IsDBNull(reader.GetValue(4)) ? 0 : Convert.ToInt32(reader.GetValue(4));
                    word.Accuracy = Convert.IsDBNull(reader.GetValue(5)) ? 0 : Convert.ToDecimal(reader.GetValue(5));
                    word.VocabListId = reader.GetInt32(6);
                    data.Add(word);
                }
            }

            dbConnection.Close();
            return data;
        }

        //Gets all the words of the specific status
        public List<Words> GetWordsByStatus(string wordStatus, int vocabListId)
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
                    word.NumOfTimeTested = Convert.IsDBNull(reader.GetValue(3)) ? 0 : Convert.ToInt32(reader.GetValue(3));
                    word.NumOfTimeAccurate = Convert.IsDBNull(reader.GetValue(4)) ? 0 : Convert.ToInt32(reader.GetValue(4));
                    word.Accuracy = Convert.IsDBNull(reader.GetValue(5)) ? 0 : Convert.ToDecimal(reader.GetValue(5));
                    word.VocabListId = reader.GetInt32(6);
                    data.Add(word);
                }
            }

            dbConnection.Close();
            return data;
        }

        //Gets a word
        public Words GetWord(int wordId)
        {
            dbConnection.Open();
            SQLiteCommand sqlite_cmd = dbConnection.CreateCommand();
            sqlite_cmd.CommandText = String.Format("SELECT * FROM Words WHERE WordId = '{0}';", wordId);
            SQLiteDataReader reader = sqlite_cmd.ExecuteReader();
            Words word = new Words();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    word.WordId = reader.GetInt32(0);
                    word.Word = reader.GetString(1);
                    word.WordStatus = reader.GetString(2);
                    word.NumOfTimeTested = Convert.IsDBNull(reader.GetValue(3)) ? 0 : Convert.ToInt32(reader.GetValue(3));
                    word.NumOfTimeAccurate = Convert.IsDBNull(reader.GetValue(4)) ? 0 : Convert.ToInt32(reader.GetValue(4));
                    word.Accuracy = Convert.IsDBNull(reader.GetValue(5)) ? 0 : Convert.ToDecimal(reader.GetValue(5));
                    word.VocabListId = reader.GetInt32(6);
                }
            }
            dbConnection.Close();
            return word;

        }
        //Update a single Word
        public void UpdateWord(Words word)
        {
            dbConnection.Open();
            SQLiteCommand sqlite_cmd = dbConnection.CreateCommand();
            sqlite_cmd.CommandText = String.Format("UPDATE Words SET Word='{0}', WordStatus='{1}', NumOfTimeTested='{2}', NumOfTimeAccurate='{3}', Accuracy='{4}' WHERE WordId = {5}; ", word.Word, word.WordStatus, word.NumOfTimeTested, word.NumOfTimeAccurate, word.Accuracy, word.WordId);
            SQLiteDataReader reader = sqlite_cmd.ExecuteReader();
            dbConnection.Close();
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


        //Adds a question to the QuestionBank table
        public void SubmitQuestion(QuestionsBank question)
        {
            dbConnection.Open();
            SQLiteCommand sqlite_cmd = dbConnection.CreateCommand();
            sqlite_cmd.CommandText = String.Format("INSERT INTO QuestionsBank(Question,Option1,Option2,Option3,Option4,Answer,NumberOfTimeAsked,NumOfCorrectAns,Accuracy,WordId) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}', '{7}', '{8}', '{9}');", question.Question, question.Option1, question.Option2, question.Option3, question.Option4, question.Answer, question.NumberOfTimeAsked, question.NumOfCorrectAns, question.Accuracy, question.WordId);
            SQLiteDataReader reader = sqlite_cmd.ExecuteReader();
            dbConnection.Close();

        }

        //Updates question
        public void UpdateQuestion(QuestionsBank question)
        {
            dbConnection.Open();
            SQLiteCommand sqlite_cmd = dbConnection.CreateCommand();
            sqlite_cmd.CommandText = String.Format("UPDATE QuestionsBank SET Question='{0}', Option1='{1}', Option2='{2}', Option3='{3}', Option4='{4}', Answer='{5}', NumberOfTimeAsked='{6}', NumOfCorrectAns='{7}', Accuracy='{8}', WordId='{9}'  WHERE QuestionID = {10};", question.Question, question.Option1, question.Option2, question.Option3,question.Option4, question.Answer,question.NumberOfTimeAsked, question.NumOfCorrectAns, question.Accuracy, question.WordId, question.QuestionID);
            SQLiteDataReader reader = sqlite_cmd.ExecuteReader();
            dbConnection.Close();

        }



        //Gets all the questions
        public List<QuestionsBank> GetAllQuestions()
        {
            List<QuestionsBank> data = new List<QuestionsBank>();
            dbConnection.Open();
            SQLiteCommand sqlite_cmd = dbConnection.CreateCommand();
            sqlite_cmd.CommandText = String.Format("SELECT * FROM QuestionsBank");
            SQLiteDataReader reader = sqlite_cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    QuestionsBank question = new QuestionsBank();
                    question.QuestionID = Convert.ToInt32(reader.GetValue(0));
                    question.Question = reader.GetString(1);
                    question.Option1 = reader.GetString(2);
                    question.Option2 = reader.GetString(3);
                    question.Option3 = reader.GetString(4);
                    question.Option4= reader.GetString(5);
                    question.Answer = reader.GetString(6);
                    question.NumberOfTimeAsked = Convert.IsDBNull(reader.GetValue(7)) ? 0 : Convert.ToInt32(reader.GetValue(7));
                    question.NumOfCorrectAns = Convert.IsDBNull(reader.GetValue(8)) ? 0 : Convert.ToInt32(reader.GetValue(8));
                    question.Accuracy = Convert.IsDBNull(reader.GetValue(9)) ? 0 : Convert.ToDecimal(reader.GetValue(9));
                    question.WordId = Convert.ToInt32(reader.GetValue(10));
                    data.Add(question);
                }
            }

            dbConnection.Close();
            return data;
        }

        //Get a single question
        public QuestionsBank GetQuestion(int questionId)
        {
            dbConnection.Open();
            SQLiteCommand sqlite_cmd = dbConnection.CreateCommand();
            sqlite_cmd.CommandText = String.Format("SELECT * FROM QuestionsBank WHERE QuestionID = {0};", questionId);
            SQLiteDataReader reader = sqlite_cmd.ExecuteReader();
            QuestionsBank question = new QuestionsBank();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    question.QuestionID = Convert.ToInt32(reader.GetValue(0));
                    question.Question = reader.GetString(1);
                    question.Option1 = reader.GetString(2);
                    question.Option2 = reader.GetString(3);
                    question.Option3 = reader.GetString(4);
                    question.Option4 = reader.GetString(5);
                    question.Answer = reader.GetString(6);
                    question.NumberOfTimeAsked = Convert.IsDBNull(reader.GetValue(7)) ? 0 : Convert.ToInt32(reader.GetValue(7));
                    question.NumOfCorrectAns = Convert.IsDBNull(reader.GetValue(8)) ? 0 : Convert.ToInt32(reader.GetValue(8));
                    question.Accuracy = Convert.IsDBNull(reader.GetValue(9)) ? 0 : Convert.ToDecimal(reader.GetValue(9));
                    question.WordId = Convert.ToInt32(reader.GetValue(10));
                }
            }
            dbConnection.Close();
            return question;
        }

        //Deletes a question
        public void DeleteQuestion(int questionId)
        {
            dbConnection.Open();
            SQLiteCommand sqlite_cmd = dbConnection.CreateCommand();
            sqlite_cmd.CommandText = String.Format("DELETE FROM QuestionsBank WHERE QuestionID = {0};", questionId);
            SQLiteDataReader reader = sqlite_cmd.ExecuteReader();
            dbConnection.Close();
        }

    }
}
