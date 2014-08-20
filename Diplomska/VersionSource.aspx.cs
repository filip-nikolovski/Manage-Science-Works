using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;
using Ionic.Zip;


namespace Diplomska
{
    public partial class VersionSource : System.Web.UI.Page
    {

        static string connString = "SERVER=localhost;DATABASE=naucen_trud;UID=root;PWD=filip;Allow Zero Datetime=True;";
        MySqlConnection conn = new MySqlConnection(connString);
        protected DataSet dsHolidays;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // Session["New"] = "filip@finki.com";
               // Session["Source"] = "116";
                if (Session["New"] == null)
                {
                    Response.Redirect("Login.aspx");
                    //Response.Redirect("Events.aspx");
                }
                else
                {
                    if (Session["New"].ToString() != "admin@finki.com")
                    {

                        lblLogedAs.Text = "You are logged in as ";
                        lblLogedAs1.Text = Session["New"].ToString() + " ";



                          try
                           {
                        conn.Open();


                        Session.Add("filename", Session["Source"].ToString());
                        

                        //TITLE CODE
                        string selectTit = "Select v.*,sw.title from versions v,science_work sw where id_version = ?id and id_science_work = sw.id";
                        MySqlCommand cmdSelect = new MySqlCommand(selectTit, conn);
                        cmdSelect.Parameters.AddWithValue("?id", Session["Source"].ToString());
                        cmdSelect.ExecuteNonQuery();
                        MySqlDataAdapter adapterSelect = new MySqlDataAdapter(cmdSelect);
                        DataSet dsSel = new DataSet();

                        adapterSelect.Fill(dsSel);

                        lblSWTitle.Text ="source files ../"+ dsSel.Tables[0].Rows[0]["version_name"].ToString();
                        lblNav.Text = dsSel.Tables[0].Rows[0]["version_name"].ToString();

                        string sw = dsSel.Tables[0].Rows[0]["title"].ToString();
                        string vName = dsSel.Tables[0].Rows[0]["version_name"].ToString();

                        //GRIDVIEW FILES CODE
                        CreateDirectoryIfNotExist(Server.MapPath("~/uploads/projects/" +sw+"/"+ vName+"/sourcefiles"));
                        string[] filePaths = Directory.GetFiles(Server.MapPath("~/uploads/projects/" +sw+"/"+ vName + "/sourcefiles"));
                        //string[] filePaths = Directory.GetFiles(Server.MapPath("~/Files/"));
                        List<ListItem> files = new List<ListItem>();

                        foreach (string filePath in filePaths)
                        {
                            files.Add(new ListItem(Path.GetFileName(filePath), filePath));
                        }
                        GridView1.DataSource = files;
                        GridView1.DataBind();

                         }
                         catch (Exception) { }
                          finally
                          {
                        conn.Close();
                         }

                
                    }
                    else
                    {

                        Response.Redirect("Login.aspx");
                    }
                }
               
            }

        }


       

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["New"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void DownloadFiles(object sender, EventArgs e)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                zip.AddDirectoryByName("Files");
                foreach (GridViewRow row in GridView1.Rows)
                {
                    if ((row.FindControl("chkSelect") as CheckBox).Checked)
                    {
                        string filePath = (row.FindControl("lblFilePath") as Label).Text;
                        zip.AddFile(filePath, "Files");
                    }
                }
                Response.Clear();
                Response.BufferOutput = false;
                string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                Response.ContentType = "application/zip";
                Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                zip.Save(Response.OutputStream);
                Response.End();

                lblerr.Text = "Sucess!";
            }
        }


        protected void btnDownloadAll_Click(object sender, EventArgs e)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                zip.AddDirectoryByName("Files");
                foreach (GridViewRow row in GridView1.Rows)
                {
                  
                        string filePath = (row.FindControl("lblFilePath") as Label).Text;
                        zip.AddFile(filePath, "Files");
                    
                }
                Response.Clear();
                Response.BufferOutput = false;
                string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                Response.ContentType = "application/zip";
                Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                zip.Save(Response.OutputStream);
                Response.End();

                lblerr.Text = "Sucess!";
            }
        }

        protected void DownloadFile(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }

        protected void DeleteFile(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            File.Delete(filePath);
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void CreateDirectoryIfNotExist(string NewDirectory)
        {
            try
            {
                if (!Directory.Exists(NewDirectory))
                {
                    Directory.CreateDirectory(NewDirectory);
                }
            }
            catch (Exception e)
            {
                lblerr.Text = e.Message;
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.background='#D1DDF1';";

                e.Row.Attributes["onmouseout"] = "this.style.background='#F7F6F3';";
               }
        }

   
    }
}