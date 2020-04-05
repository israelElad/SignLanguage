using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using System;
 using System.Data;

 using MySql.Data;
 using MySql.Data.MySqlClient;



public class myDB : MonoBehaviour
{
    public string w;
    // Start is called before the first frame update
    void Start()
    {
       
        string cs = @"server=localhost;userid=root;password=vered1234;database=SignLanguageDB";
        MySqlConnection con = new MySqlConnection(cs);
        con.Open();

        string sql = "SELECT word FROM all";
        MySqlCommand cmd = new MySqlCommand(sql, con);

        MySqlDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
           
            w = rdr.GetString(0);
            break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
