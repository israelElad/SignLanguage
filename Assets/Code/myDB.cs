using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;

namespace YoutubePlayer
{
    public class myDB : MonoBehaviour
    {
        private IDbConnection con;
        private string connection;
        // Start is called before the first frame update
        void Start()
        {
            String db_path = "C:/SignLanguage/DB.db";
            connection = "URI=file:" + db_path;
        }
        public List<string> WordLottery()
        {
            List<string> wordlist = new List<string>();
            con = new SqliteConnection(connection);
            con.Open();
            IDbCommand cmnd_read = con.CreateCommand();
            IDataReader reader;
            string query = "SELECT word FROM my_Table ORDER BY random() LIMIT 30";
            cmnd_read.CommandText = query;
            reader = cmnd_read.ExecuteReader();

            while (reader.Read())
            {
                wordlist.Add(reader.GetString(0));
            }
            con.Close();

            con = new SqliteConnection(connection);
            con.Open();
            query = "SELECT url FROM my_Table WHERE word=\"" + wordlist[0] + "\"";
            cmnd_read = con.CreateCommand();
            cmnd_read.CommandText = query;
            reader = cmnd_read.ExecuteReader();
            string wordUrl = null;
            while (reader.Read())
            {
                wordUrl = reader.GetString(0);
                break;
            }
            con.Close();
            GameObject.Find("Video Player").GetComponent<YoutubePlayer>().PlayVideoAsync(wordUrl);

            //reformat text to rtl
            for (var i = 0; i < wordlist.Count; i++)
            {
                //reverse word order
                wordlist[i] = String.Join(" ", wordlist[i].Split(' ').Reverse());
                wordlist[i] = Reverse(wordlist[i]);
                wordlist[i] = SplitToLines(wordlist[i]);
            }

            return wordlist;
        }

        public static string Reverse(string s)
        {
            s = new String(s.Select(x => x == '(' ? ')' : (x == ')' ? '(' : x)).ToArray());
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private string SplitToLines(string word)
        {
            word = word.Replace(" / ", "/");
            return word.Replace(' ', '\n');
        }

    }
}
