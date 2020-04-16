using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using System;
 using System.Data;
using System.Collections.Generic;
using MySql.Data;
 using MySql.Data.MySqlClient;



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

            GameObject.Find("Video Player").GetComponent<YoutubePlayer>().PlayVideoAsync(wordUrl);
            return wordlist;
        }

        // Update is called once per frame
        void Update()
        {
            if (i%1000 == 0)
            {
                WordLottery();
                i = i % 1000;
            }
            i++;
        }
    }
}
