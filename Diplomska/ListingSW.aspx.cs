using System;
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
    public partial class ListingSW : System.Web.UI.Page
    {
<<<<<<< HEAD
       // static string connString = "SERVER=localhost;DATABASE=naucen_trud;UID=root;PWD=filip;Allow Zero Datetime=True;";

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
                            

                            //DropDownList corrw
                            string selectCorrAut = "SELECT id, CONCAT(name ,' ',surname) as fullName, email  from user_info WHERE email NOT LIKE ?email";
                            MySqlCommand cmd11 = new MySqlCommand(selectCorrAut, conn);
                            cmd11.Parameters.Add("?email", "admin@finki.com");
                            MySqlDataAdapter adapter11 = new MySqlDataAdapter(cmd11);
                            DataSet ds11 = new DataSet();
                            adapter11.Fill(ds11);

                            ddlCorrAut.DataSource = ds11;
                            ddlCorrAut.DataBind();

                            //GridView code
                            string sqlSelect = "SELECT sw.id, sw.title, concat( sw.autores,' ',sw.Corresponding_autor) as autors , sw.price, sw.date FROM science_work sw, created c, user_info u WHERE   sw.id=c.science_work_ID  and c.user_info_ID=u.id";
                            MySqlCommand cmd1 = new MySqlCommand(sqlSelect, conn);

                            MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);
                            DataSet ds1 = new DataSet();
                            adapter1.Fill(ds1);

                            gvScienceWork.DataSource = ds1;
                            gvScienceWork.DataBind();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                if (ddlCorrAut.SelectedValue == "0" )
                {
                          
                    string sqlSelectUsr = "SELECT sw.id, sw.title,concat( sw.autores,' ',  sw.Corresponding_autor) as autors, sw.price, sw.date FROM science_work sw, created c, user_info u WHERE   sw.id=c.science_work_ID  and c.user_info_ID=u.id ";
                    MySqlCommand cmd2 = new MySqlCommand(sqlSelectUsr, conn);
                   
                    MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd2);
                    DataSet ds1 = new DataSet();
                    adapter1.Fill(ds1);

                    gvScienceWork.DataSource = ds1;
                    gvScienceWork.DataBind();



                }
                else {

                    string sqlSelectUsr = "SELECT distinct sw.id, sw.title, concat( sw.autores,' ',sw.Corresponding_autor) as autors, sw.price, sw.date FROM science_work sw, created c, user_info u WHERE   sw.id=c.science_work_ID AND c.user_info_ID=u.id AND autores like '%" + ddlCorrAut.SelectedValue + "%' OR Corresponding_autor like '%" + ddlCorrAut.SelectedValue + "%' and sw.id=c.science_work_ID AND c.user_info_ID=u.id ";
                    MySqlCommand cmd2 = new MySqlCommand(sqlSelectUsr, conn);
               
                    MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd2);
                    DataSet ds1 = new DataSet();
                    adapter1.Fill(ds1);

                    gvScienceWork.DataSource = ds1;
                    gvScienceWork.DataBind();
                }
               
               
            }
            catch (Exception ex)
            {
                lblErr.Visible = true;
                lblErr.Text = ex.ToString();

            }
            finally {
                conn.Close();
            }
        }

      


        //delete gridview row
        protected void button_click(object sender, EventArgs e)
        {
            Button ibtn1 = sender as Button;
            int rowIndex = Convert.ToInt32(ibtn1.Attributes["RowIndex"]);

            try
            {

                conn.Open();

                string sqlDelete = "DELETE FROM  science_work WHERE id =@id";
                MySqlCommand cmd = new MySqlCommand(sqlDelete, conn);

                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(rowIndex.ToString()));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //lblEx.Text = ex.ToString();
            }
            finally
            {
                conn.Close();
                Response.Redirect("ListingSW.aspx");
            }


        }



          protected void button11_click(object sender, EventArgs e)
          {
              Button ibtn11 = sender as Button;
              int rowIndex = Convert.ToInt32(ibtn11.Attributes["RowIndex"]);

              Session["sessi"] = rowIndex;
              Response.Redirect("VerziiAdmin.aspx");

          }


          //gvScienceWork_RowCreated
          protected void gvScienceWork_RowCreated(object sender, GridViewRowEventArgs e)
          {
              if (e.Row.RowType == DataControlRowType.DataRow)
              {
                  e.Row.Attributes["onmouseover"] = "this.style.background='#D1DDF1';";

                  if ((e.Row.RowIndex % 2) == 0)  // if even row
                      e.Row.Attributes["onmouseout"] = "this.style.background='#EFF3FB';";
                  else  // alternate row
                      e.Row.Attributes["onmouseout"] = "this.style.background='White';";
                  }
          }

          protected void btnLoguot_Click(object sender, EventArgs e)
          {
              Session["New"] = null;
              Response.Redirect("Login.aspx");
          }
    }
}