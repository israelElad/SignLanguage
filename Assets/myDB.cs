using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using System;
 using System.Data;
using MySql.Data;
 using MySql.Data.MySqlClient;
using System.Linq;

namespace YoutubePlayer
{
    public class myDB : MonoBehaviour
    {
        private MySqlConnection con;
        private int i = 0;
        // Start is called before the first frame update
        void Start()
        {

            string cs = "Database = SignLanguageDB; Server = 127.0.0.1; Uid = root; Password = vered1234; pooling = false; CharSet = utf8; port = 3306";
            con = new MySqlConnection(cs);
            con.Open();   
        }
        public List<string> WordLottery()
        {
            List<string> wordlist = new List<string>();
            string sql = "SELECT word FROM SignLanguageDB.all ORDER BY RAND() LIMIT 30";
            MySqlCommand cmd = new MySqlCommand(sql, con);

            MySqlDataReader rdr = cmd.ExecuteReader();



            while (rdr.Read())
            {
                wordlist.Add(rdr.GetString(0));
            }
            rdr.Close();
            sql = "SELECT url FROM SignLanguageDB.all WHERE word=" + '\u0022' + wordlist[0] + '\u0022';
            cmd = new MySqlCommand(sql, con);
            rdr = cmd.ExecuteReader();
            string wordUrl = null;
            while (rdr.Read())
            {
                wordUrl = rdr.GetString(0);
                break;
            }
            rdr.Close();

            //reformat text to rtl
            for(var i=0; i< wordlist.Count; i++)
            {
                wordlist[i] = String.Join(" ", wordlist[i].Split(' ').Reverse());
                wordlist[i] = Reverse(wordlist[i]);
                wordlist[i] = SplitToLines(wordlist[i]);
            }

            GameObject.Find("Video Player").GetComponent<YoutubePlayer>().PlayVideoAsync(wordUrl);
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
