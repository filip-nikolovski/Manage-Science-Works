<%@ WebHandler Language="C#" Class="Upload" %>

using System;
using System.Web;
using System.IO;

using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.SessionState;
using System.Configuration;



public class Upload : IHttpHandler, IRequiresSessionState {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Expires = -1;

        //static string connString = "SERVER=localhost;DATABASE=naucen_trud;UID=root;PWD=filip;";

        static string connString = ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString;
       // static string connString = "SERVER=db4free.net;DATABASE=naucentrud;UID=badzovski;PWD=Filip12#;";
        MySqlConnection conn = new MySqlConnection(connString);
        conn.Open();

        context.Response.ContentType = "text/plain";

        string sessionValue = Convert.ToString(HttpContext.Current.Session["filename"]);

        string sqlSel = "SELECT v.*,sw.title from versions v,science_work sw where v.id_version = ?id and id_science_work = sw.id";
        MySqlCommand cmd = new MySqlCommand(sqlSel, conn);
        cmd.Parameters.Add("?id", sessionValue);
        cmd.ExecuteNonQuery();
        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adapter.Fill(ds);

       
        try
        {

            string sw = ds.Tables[0].Rows[0]["title"].ToString();
            string vName = ds.Tables[0].Rows[0]["version_name"].ToString();
            
            
            HttpPostedFile postedFile = context.Request.Files["Filedata"];
            
            string savepath = "";
           // string tempPath = "";
           // tempPath = context.Server.MapPath()
            savepath = context.Server.MapPath("~/uploads/projects/" +sw+"/"+ vName + "/sourcefiles");
            string filename = postedFile.FileName;
            if (!Directory.Exists(savepath))
                Directory.CreateDirectory(savepath);

            postedFile.SaveAs(savepath + @"\" + filename);
            context.Response.Write(savepath + "/" + filename);
            context.Response.StatusCode = 200;
        }
        catch (Exception ex)
        {
            context.Response.Write("Error: " + ex.Message);
        }

        conn.Close();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
}