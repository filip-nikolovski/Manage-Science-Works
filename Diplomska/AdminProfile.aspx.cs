using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace Diplomska
{
    public partial class AdminProfile : System.Web.UI.Page
    {
        
             static string connString = "SERVER=localhost;DATABASE=naucen_trud;UID=root;PWD=filip;Allow Zero Datetime=True;";
             MySqlConnection conn = new MySqlConnection(connString);

        protected void Page_Load(object sender, EventArgs e)
        {
             if (Session["New"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Session["New"].ToString() == "admin@finki.com")
                {
                    lblLoged.Text = "You are logged in as ";
                    lblLogedAs.Text = Session["New"].ToString() + " ";
                    if (!IsPostBack)
                    {
                        try
                        {


                        }
                        catch (Exception ex)
                        {
                            lblErr.Visible = true;
                            lblErr.Text += ex.ToString();
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
                else
                {

                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btnLoguot_Click(object sender, EventArgs e)
        {
            Session["New"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try {
                conn.Open();

                string sel = "select * from user_info where email=?email1 and password=?oldPassword";
                MySqlCommand cmd11 = new MySqlCommand(sel, conn);
                cmd11.Parameters.Add("?email1", Session["New"].ToString());
                cmd11.Parameters.Add("?password", txtNewPass.Text);
                cmd11.Parameters.Add("?oldPassword", txtPass.Text);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd11);
                DataSet ds = new DataSet();
                ada.Fill(ds);


                if (ds.Tables[0].Rows.Count != 0)
                {

                    //update info in db
                    string sqlUpdate = "Update user_info set password=?password where email=?email1 and password=?oldPassword";
                    MySqlCommand cmd1 = new MySqlCommand(sqlUpdate, conn);
                    cmd1.Parameters.Add("?email1", Session["New"].ToString());
                    cmd1.Parameters.Add("?password", txtNewPass.Text);
                    cmd1.Parameters.Add("?oldPassword", txtPass.Text);
                    cmd1.ExecuteNonQuery();
                    Response.Redirect("AdminProfile.aspx");
                }
                else
                {
                    lblErr.Visible = true;
                    lblErr.Text = "Внесената лозинка не е иста!";
                }
            }
                catch(Exception){
                
                }
            finally{
            
                conn.Close();
            }
        
        }

        


        }
    }
