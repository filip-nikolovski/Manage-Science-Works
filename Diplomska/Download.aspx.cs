﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
<<<<<<< HEAD
using System.Configuration;
=======
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a

namespace Diplomska
{
    public partial class Download : System.Web.UI.Page
    {

        //static string connString = "SERVER=localhost;DATABASE=naucen_trud;UID=root;PWD=filip;";
<<<<<<< HEAD

        static string connString = ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString;
       // static string connString = "SERVER=db4free.net;DATABASE=naucentrud;UID=badzovski;PWD=Filip12#;";
=======
        static string connString = "SERVER=db4free.net;DATABASE=naucentrud;UID=badzovski;PWD=Filip12#;";
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
        MySqlConnection conn = new MySqlConnection(connString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                try
                {
                    conn.Open();
                    string sqlSelect = "SELECT id_version, version_name, file_path FROM versions";
                    MySqlCommand cmd = new MySqlCommand(sqlSelect, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    gvDownload.DataSource = ds;
                    gvDownload.DataBind();

                   // cmd.ExecuteNonQuery();

                }
                catch (Exception ex) { 
                    lblException.Text = ex.ToString(); 
                }

            }
        }
    }
}