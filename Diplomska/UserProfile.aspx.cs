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
    public partial class UserProfile : System.Web.UI.Page
    {
<<<<<<< HEAD
        //static string connString = "SERVER=localhost;DATABASE=naucen_trud;UID=root;PWD=filip;";

        static string connString = ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString;
        // static string connString = "SERVER=db4free.net;DATABASE=naucentrud;UID=badzovski;PWD=Filip12#;";
=======
        //static string connString = "SERVER=localhost;DATABASE=naucen_trud;UID=root;PWD=filip;Allow Zero Datetime=True;";
        static string connString = "SERVER=db4free.net;DATABASE=naucentrud;UID=badzovski;PWD=Filip12#;";
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
        MySqlConnection conn = new MySqlConnection(connString);

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
            //Session["New"] = "filip@finki.com";
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
<<<<<<< HEAD
                        string sqlSelect = "select * from user_info  where email=?email";
=======
                        string sqlSelect = "select ui.*, l.Name as lab from user_info ui,labs l where email=?email and labs_id=l.id";
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
                        MySqlCommand cmd = new MySqlCommand(sqlSelect, conn);
                        cmd.Parameters.Add("?email", Session["New"].ToString());
                        cmd.ExecuteNonQuery();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);

                        lblSWTitle.Text = ds.Tables[0].Rows[0]["name"].ToString() + " " + ds.Tables[0].Rows[0]["surname"].ToString();
                        lblName1.Text = ds.Tables[0].Rows[0]["name"].ToString();
<<<<<<< HEAD
                        lblFacul.Text = ds.Tables[0].Rows[0]["faculty"].ToString();
                       
=======
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
                        lblSurname1.Text = ds.Tables[0].Rows[0]["surname"].ToString();
                        lblEmail1.Text = ds.Tables[0].Rows[0]["email"].ToString();
                        lblLab1.Text = ds.Tables[0].Rows[0]["lab"].ToString();


                    }
                    catch (Exception) { }
                    finally
                    {
                        conn.Close();
                    }


                }
                else {

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

        protected void btnModify_Click(object sender, EventArgs e)
        {
            tblUsrInfo.Visible = true;
            tblChangePass.Visible = false;
            lblName1.Visible = false;
            lblSurname1.Visible = false;
            lblEmail1.Visible = false;
<<<<<<< HEAD
            lblFacul.Visible = false;
            lblLab1.Visible = false;
=======
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
            lblLab1.Visible = false;
            txtName.Visible = true;
            txtSurname.Visible = true;
            txtEmail.Visible = true;
<<<<<<< HEAD
           // ddlLabs.Visible = true;
            txtLab1.Visible = true;
            txtFaculty.Visible = true;
=======
            ddlLabs.Visible = true;
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
            btnUpdate.Visible = true;
            btnCancel1.Visible = true;

            try
            {
                conn.Open();

                //ddlLabs 
<<<<<<< HEAD
              /**  string sqlSelectLab = "SELECT * FROM labs";
=======
                string sqlSelectLab = "SELECT * FROM labs";
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
                MySqlDataAdapter adapterLab = new MySqlDataAdapter(sqlSelectLab, conn);

                DataSet dsLab = new DataSet();
                adapterLab.Fill(dsLab);

                ddlLabs.DataSource = dsLab;
                ddlLabs.DataBind();
<<<<<<< HEAD
                **/
                string sqlSelect = "select *  from user_info where email=?email ";
=======

                string sqlSelect = "select ui.*, l.Name as lab from user_info ui,labs l where email=?email and labs_id=l.id";
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
                MySqlCommand cmd = new MySqlCommand(sqlSelect, conn);
                cmd.Parameters.Add("?email", Session["New"].ToString());
                cmd.ExecuteNonQuery();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                txtName.Text = ds.Tables[0].Rows[0]["name"].ToString();
                txtSurname.Text = ds.Tables[0].Rows[0]["surname"].ToString();
<<<<<<< HEAD
                txtFaculty.Text = ds.Tables[0].Rows[0]["faculty"].ToString();
                txtLab1.Text = ds.Tables[0].Rows[0]["lab"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["email"].ToString();
               // ddlLabs.SelectedIndex = ddlLabs.Items.IndexOf(ddlLabs.Items.FindByValue(ds.Tables[0].Rows[0]["labs_id"].ToString()));
=======
                txtEmail.Text = ds.Tables[0].Rows[0]["email"].ToString();
                ddlLabs.SelectedIndex = ddlLabs.Items.IndexOf(ddlLabs.Items.FindByValue(ds.Tables[0].Rows[0]["labs_id"].ToString()));
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
       
                
               
            }
            catch { }
            finally {
                conn.Close();
            }
        }

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            tblUsrInfo.Visible = false;
            tblChangePass.Visible = true;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Response.Redirect("UserProfile.aspx");
            tblUsrInfo.Visible = true;
            tblChangePass.Visible = false;
            lblName1.Visible = true;
            lblSurname1.Visible = true;
            lblEmail1.Visible = true;
            lblLab1.Visible = true;
            txtName.Visible = false;
            txtSurname.Visible = false;
            txtEmail.Visible = false;
<<<<<<< HEAD
            //Visible = false;
=======
            ddlLabs.Visible = false;
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
            btnUpdate.Visible = false;
            btnCancel1.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
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
                    //cmd1.Parameters.Add("?email", txtEmail.Text);
                    //cmd1.Parameters.Add("?lab", ddlLabs.SelectedValue);
                    cmd1.ExecuteNonQuery();
                    Response.Redirect("UserProfile.aspx");
                }
                else {
                    lblErr.Visible = true;
                    lblErr.Text = "Внесената лозинка не е иста!";
                }
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
        }

        protected void btnCancel1_Click(object sender, EventArgs e)
        {
            tblUsrInfo.Visible = true;
            tblChangePass.Visible = false;
            lblName1.Visible = true;
            lblSurname1.Visible = true;
            lblEmail1.Visible = true;
            lblLab1.Visible = true;
<<<<<<< HEAD
            lblFacul.Visible = true;
            txtName.Visible = false;
            txtSurname.Visible = false;
            txtEmail.Visible = false;
            txtFaculty.Visible = false;
            txtLab1.Visible = false;
         //   ddlLabs.Visible = false;
=======
            txtName.Visible = false;
            txtSurname.Visible = false;
            txtEmail.Visible = false;
            ddlLabs.Visible = false;
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
            btnUpdate.Visible = false;
            btnCancel1.Visible = false;
            lblErr.Visible = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
             {
                conn.Open();
                //update info in db
<<<<<<< HEAD
                string sqlUpdate = "Update user_info set name=?name, surname=?surname, email=?email, lab=?lab, faculty=?faculty where email=?email1";
=======
                string sqlUpdate = "Update user_info set name=?name, surname=?surname, email=?email, labs_id=?lab where email=?email1";
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
                MySqlCommand cmd1 = new MySqlCommand(sqlUpdate, conn);
                cmd1.Parameters.Add("?email1", Session["New"].ToString());
                cmd1.Parameters.Add("?name", txtName.Text);
                cmd1.Parameters.Add("?surname", txtSurname.Text);
                cmd1.Parameters.Add("?email", txtEmail.Text);
<<<<<<< HEAD
                cmd1.Parameters.Add("?lab", txtLab1.Text);
                cmd1.Parameters.Add("?faculty", txtFaculty.Text);
               // cmd1.Parameters.Add("?lab", ddlLabs.SelectedValue);
=======
                cmd1.Parameters.Add("?lab", ddlLabs.SelectedValue);
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
                cmd1.ExecuteNonQuery();

                string sqlUpdateEmail = "update science_work set Corresponding_autor = REPLACE(Corresponding_autor, ?email1, ?email), autores=REPLACE(autores, ?email1, ?email)  where Corresponding_autor like '%" + Session["New"].ToString() + "%' or autores like '%" + Session["New"].ToString() + "%'";
                MySqlCommand cmdUpdateCorrA = new MySqlCommand(sqlUpdateEmail, conn);
                cmdUpdateCorrA.Parameters.Add("?email1", Session["New"].ToString());               
                cmdUpdateCorrA.Parameters.Add("?email", txtEmail.Text);
                cmdUpdateCorrA.ExecuteNonQuery();

                Session["New"] = txtEmail.Text;
                Response.Redirect("UserProfile.aspx");
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
        }
    }
}