﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
<<<<<<< HEAD
using System.Configuration;
=======
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a

namespace Diplomska
{
    public partial class Index : System.Web.UI.Page
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
        protected DataSet dsHolidays;


        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.Attributes.Add("enctype", "multipart/form-data");

            if (!IsPostBack)
            {

            //addWork.Visible = false;
<<<<<<< HEAD
            //Session["New"] = "filip@finki.com";
            if (Session["New"] == null)
            {
                Response.Redirect("Login.aspx");
=======
           // Session["New"] = "filip@finki.com";
            if (Session["New"] == null)
            {
                 Response.Redirect("Login.aspx");
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
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

                            string sqlSelect = "SELECT sw.id, sw.title,concat( sw.autores,' ',sw.Corresponding_autor) as autores , sw.price, sw.date   FROM  science_work sw, created c, user_info u WHERE sw.autores LIKE '%" + Session["New"].ToString() + "%' AND sw.id=c.science_work_ID  and c.user_info_ID=u.id OR sw.Corresponding_autor LIKE '%" + Session["New"].ToString() + "%' AND sw.id=c.science_work_ID  and c.user_info_ID=u.id";
                            MySqlCommand cmd = new MySqlCommand(sqlSelect, conn);

                            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            if (ds.Tables[0].Rows.Count != 0)
                            {
                                gvList.DataSource = ds;
                                gvList.DataBind();
                            }
                            else
                            {

                                lblTitleEmpty.Text = "Немате научни трудови.";
                            }


                            //popup code
                            string em = "admin@finki.com";
                            //conn.Open();
                            string sqlSelect1 = "SELECT id, CONCAT(name ,' ',surname) as fullName FROM user_info WHERE email NOT LIKE ?email and email not like ?user and accsepted <> 2";
                            MySqlCommand cmd1 = new MySqlCommand(sqlSelect1, conn);

                            cmd1.Parameters.Add("?email", em);
                            cmd1.Parameters.Add("?user", Session["New"].ToString());

                            MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);
                            DataSet ds1 = new DataSet();
                            adapter1.Fill(ds1);

                            cblCorispondingAutors.DataSource = ds1;
                            cblCorispondingAutors.DataBind();


                            //code za kalendar ... (aside)
                            //code za event remider greeedView
                            string sqlSel = "SELECT DISTINCT h.id, CONCAT(full_name,'-',Holiday) as hol, HolidayDate FROM holidays h, conference c, science_work sw WHERE h.conference_ID = c.id AND c.science_work_id = sw.id AND sw.autores LIKE  '%" + Session["New"].ToString() + "%' and HolidayDate>=CURDATE( ) +0 and HolidayDate<=DATE_ADD(NOW(), INTERVAL 5 DAY) OR h.conference_ID = c.id AND c.science_work_id = sw.id AND sw.Corresponding_autor LIKE  '%" + Session["New"].ToString() + "%' and HolidayDate>=CURDATE( ) +0 and HolidayDate<=DATE_ADD(NOW(), INTERVAL 5 DAY) ORDER BY HolidayDate ASC";

                            MySqlCommand cmdReminder = new MySqlCommand(sqlSel, conn);
                            // cmdReminder.Parameters.Add("?HolidayDate", DateTime.Now.ToString("yyyy-MM-dd"));
                            MySqlDataAdapter ad = new MySqlDataAdapter(cmdReminder);
                            DataSet das = new DataSet();
                            ad.Fill(das);

                            gvReminder.DataSource = das;
                            gvReminder.DataBind();

                            //calendar code
                            Calendar1.VisibleDate = DateTime.Today;
                            FillHolidayDataSet();

                        }
                        catch (Exception ex)
                        {
                            lblEx.Text = ex.ToString();
                        }
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


        /**  Kode za aside **/

        //calendar code
        protected void FillHolidayDataSet()
        {
            DateTime firstDate = new DateTime(Calendar1.VisibleDate.Year, Calendar1.VisibleDate.Month, 1);
            DateTime lastDate = GetFirstDayOfNextMonth();
            dsHolidays = GetCurrentMonthData(firstDate, lastDate);
        }

        protected DateTime GetFirstDayOfNextMonth()
        {

            int monthNumer, yearNumber;
            if (Calendar1.VisibleDate.Month == 12)
            {
                monthNumer = 1;
                yearNumber = Calendar1.VisibleDate.Year + 1;

            }
            else
            {
                monthNumer = Calendar1.VisibleDate.Month + 1;
                yearNumber = Calendar1.VisibleDate.Year;

            }
            DateTime lastDate = new DateTime(yearNumber, monthNumer, 1);
            return lastDate;
        }

        protected DataSet GetCurrentMonthData(DateTime firstDate, DateTime lastDate)
        {
            DataSet dsMonth = new DataSet();

            string connString = "SERVER=localhost;DATABASE=naucen_trud;UID=root;PWD=filip;";
            MySqlConnection dbConnection = new MySqlConnection(connString);
            string query = "Select HolidayDate from holidays h, conference c, science_work sw where h.conference_ID=c.id and c.science_work_id=sw.id and sw.autores LIKE '%" + Session["New"].ToString() + "%' and HolidayDate >= ?firstDate and HolidayDate<?lastDate OR sw.Corresponding_autor LIKE '%" + Session["New"].ToString() + "%' and h.conference_ID=c.id and c.science_work_id=sw.id and HolidayDate >= ?firstDate and HolidayDate<?lastDate";
            MySqlCommand dbCommand = new MySqlCommand(query, dbConnection);
            dbCommand.Parameters.Add("?firstDate", firstDate);
            dbCommand.Parameters.Add("?lastDate", lastDate);

            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(dbCommand);

            try
            {
                sqlDataAdapter.Fill(dsMonth);
            }
            catch { }
            return dsMonth;
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            e.Day.IsSelectable = false;

            DataSet ds = GetData();
            string link = "<a href='ViewEvent.aspx?eventID=";
            string s = e.Day.Date.ToShortDateString();

            Panel p1 = new Panel();
            string ss = "";

            foreach (DataRow row in ds.Tables[0].Rows)
            {

                string scheduledDate = Convert.ToDateTime(row["HolidayDate"]).ToShortDateString();
                if (scheduledDate.Equals(s))
                {
                    e.Cell.Style["background"] = "#2FBDF1";
                    LinkButton lb = new LinkButton();
                    lb.Text = link + (int)row["id"] + "'>" + row["Holiday"] as String + "</a>" + "<BR>";
                    //ok ^

                    p1.Attributes.Add("style", "display:none;");
                    p1.Attributes.Add("style", "display:none;");
                    p1.Controls.Add(lb);
                    Panel1.Controls.Add(p1);


                    ss = e.Day.Date.ToString("yyyy-MM-dd");
                    e.Cell.Attributes.Add("onmouseover", "ShowInfo('" + p1.ClientID + "','" + ss + "')");
                }
            }
        }

        private DataSet GetData()
        {
            //conn.Open();
            string sql = "select * from holidays";
            MySqlDataAdapter ad = new MySqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            return ds;
            //conn.Close();
        }


        protected void Calendar1_VisibleMonthChanged(object sender,
   MonthChangedEventArgs e)
        {
            FillHolidayDataSet();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            FillHolidayDataSet();
        }


        //gvReminder
        protected void gvReminder_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.background='#D1DDF1';";

                if ((e.Row.RowIndex % 2) == 0)  // if even row
                    e.Row.Attributes["onmouseout"] = "this.style.background='#EFF3FB';";
                else  // alternate row
                    e.Row.Attributes["onmouseout"] = "this.style.background='White';";
                e.Row.ToolTip = "Click to view the event";
                e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.gvReminder, "Select$" + e.Row.RowIndex);
            }
        }

        protected void gvReminder_SelectedIndexChanged(object sender, EventArgs e)
        {

            Session["Reminder"] = gvReminder.SelectedDataKey.Value.ToString();
            Response.Redirect("ViewEvent.aspx");

        }


        /**  Kode za aside **/






        protected void Button1_Click(object sender, EventArgs e)
        {

            Session["New"] = null;
            Response.Redirect("Login.aspx");

        }

        protected void gvList_RowCreated(object sender, GridViewRowEventArgs e)
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


        protected void btnVersions_clisk(object sender, EventArgs e)
        {

            Button btnVersions = sender as Button;
            int rowIndex = Convert.ToInt32(btnVersions.Attributes["RowIndex"]);

            Session["sess"] = rowIndex.ToString();
            Response.Redirect("Versions.aspx");
        }

        protected void button_click(object sender, EventArgs e)
        {
            Button ibtn1 = sender as Button;
            int rowIndex = Convert.ToInt32(ibtn1.Attributes["RowIndex"]);

            //Use this rowIndex in your code
            lblEx.Text = rowIndex.ToString();

            try
            {

                conn.Open();

                string sqlSelect = "SELECT * from science_work WHERE id=?id";
                MySqlCommand cmd1 = new MySqlCommand(sqlSelect, conn);
                cmd1.Parameters.AddWithValue("?id", Convert.ToInt32(rowIndex.ToString()));
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd1);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                string swName = ds.Tables[0].Rows[0]["title"].ToString();
                DeleteDirectoryExist(Server.MapPath("~/uploads/projects/" + swName));


<<<<<<< HEAD
                string sqlDelete = "DELETE FROM  science_work WHERE id =?id";
                MySqlCommand cmd = new MySqlCommand(sqlDelete, conn);

                cmd.Parameters.Add("?id", Convert.ToInt32(rowIndex));
=======
                string sqlDelete = "DELETE FROM  science_work WHERE id =@id";
                MySqlCommand cmd = new MySqlCommand(sqlDelete, conn);

                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(rowIndex.ToString()));
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lblEx.Text = ex.ToString();
            }
            finally
            {
                conn.Close();
                Response.Redirect("Index.aspx");
            }


        }




        //button details 
        protected void btnDetails_click(object sender, EventArgs e)
        {
       
            Button btnDetails = sender as Button;
            int rowIndex = Convert.ToInt32(btnDetails.Attributes["RowIndex"].ToString());        

            ModalPopupExtender2.Show();
            btnDetails.Attributes.Add("onclick", "return ShowModalPopup1()");
            try
            {
                conn.Open();
                string sqlSel = "select * from science_work where id=?id";
                MySqlCommand cmd = new MySqlCommand(sqlSel, conn);
                cmd.Parameters.Add("?id", rowIndex);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                lblPopUpSWDetails.Text = "Детали";
                lblPopTitle.Text = ds.Tables[0].Rows[0]["title"].ToString();
                lblPopAutors.Text = ds.Tables[0].Rows[0]["autores"].ToString();
                lblPopCorrAutors.Text = ds.Tables[0].Rows[0]["Corresponding_autor"].ToString();
                lblPopPrice.Text = ds.Tables[0].Rows[0]["price"].ToString();
                lblPopDate.Text = ds.Tables[0].Rows[0]["date"].ToString();
                lblPopAcc.Text = ds.Tables[0].Rows[0]["accepted"].ToString();
                lblPopDescription.Text = ds.Tables[0].Rows[0]["description"].ToString();

               

            }
            catch { }
            finally
            {
                conn.Close();
            }
            //Use this rowIndex in your code
        }








        protected void Button2_Click(object sender, EventArgs e)
        {


            string file_name;
            int file_size;
            string file_path;
            try{
            conn.Open();


            string sqlInsert = "INSERT INTO science_work (title, price, date, accepted, description, Corresponding_autor, autores) VALUES(?title, ?price, ?date, ?accepted, ?description, ?Corresponding_autor, ?autores)";
            MySqlCommand cmd = new MySqlCommand(sqlInsert, conn);

            cmd.Parameters.Add("?title", txtTitle.Text);
            cmd.Parameters.Add("?price", txtPrice.Text);
            cmd.Parameters.Add("?date", System.DateTime.Now.ToString("yyyy-MM-dd"));
            cmd.Parameters.Add("?accepted", rblAcc.SelectedValue);
            cmd.Parameters.Add("?description", txtDescription.Text);
            cmd.Parameters.Add("?Corresponding_autor", TextBox1.Text);
            cmd.Parameters.Add("?autores", Session["New"].ToString());
            cmd.ExecuteNonQuery();


            string sqlUsrID = "SELECT id from user_info where email=?email";
            MySqlCommand cmdUsrID = new MySqlCommand(sqlUsrID, conn);
            cmdUsrID.Parameters.Add("?email", Session["New"].ToString());
            cmdUsrID.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmdUsrID);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            int usrID = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());



            string sqlInsert2 = "INSERT  INTO created (user_info_ID, science_work_ID) values  (?user_info_ID, ?science_work_ID)";
            MySqlCommand cmd2 = new MySqlCommand(sqlInsert2, conn);

            cmd2.Parameters.Add("?user_info_ID", usrID);
            cmd2.Parameters.Add("?science_work_ID", Convert.ToInt32(cmd.LastInsertedId));
            cmd2.ExecuteNonQuery();


             }
             catch (Exception ex)
              {

            //     lblEx.Text = ex.ToString();
              }
              finally
              {

            conn.Close();
            // addWork.Visible = false;
            Response.Redirect("Index.aspx");
              }


        }


        static int rID;
        static string sw;
        //edit button code
        protected void btnEdit_click(object sender, EventArgs e)
        {
            // btnConfirmAdd.Visible = false;
            btnUpdate.Visible = true;
            Button2.Visible = false;
            Button btnEdit = sender as Button;
            int rowIndex = Convert.ToInt32(btnEdit.Attributes["RowIndex"].ToString());
            rID = rowIndex;


            try
            {
                conn.Open();
                string sqlSelect = "SELECT id, title, description, price, DATE_FORMAT(date, GET_FORMAT(DATE,'ISO'))as date, Corresponding_autor, accepted from science_work where id=?id";
                MySqlCommand cmd = new MySqlCommand(sqlSelect, conn);
                cmd.Parameters.Add("?id", rowIndex);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                sw = ds.Tables[0].Rows[0]["title"].ToString();

                lblTitle1.Text = "Уреди Труд";

                txtTitle.Text = ds.Tables[0].Rows[0]["title"].ToString();
                txtDescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
                txtPrice.Text = ds.Tables[0].Rows[0]["price"].ToString();
                TextBox1.Text = ds.Tables[0].Rows[0]["Corresponding_autor"].ToString();
                rblAcc.SelectedIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["accepted"].ToString());

            }
            catch { }
            finally
            {
                conn.Close();

            }


        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
              try
             {

            conn.Open();


            string sqlUpdate = "UPDATE science_work SET  title=?title, price=?price, accepted=?accepted, description=?description, Corresponding_autor=?Corresponding_autor, autores=?autores  WHERE id=?id";
            MySqlCommand cmd = new MySqlCommand(sqlUpdate, conn);

            cmd.Parameters.Add("?title", txtTitle.Text);
            cmd.Parameters.Add("?price", txtPrice.Text);
           // cmd.Parameters.Add("?date", txtDate.Text);
            cmd.Parameters.Add("?accepted", rblAcc.SelectedValue);
            cmd.Parameters.Add("?description", txtDescription.Text);
            cmd.Parameters.Add("?Corresponding_autor", TextBox1.Text);
            cmd.Parameters.Add("?autores", Session["New"].ToString());
            cmd.Parameters.Add("?id", rID);

            cmd.ExecuteNonQuery();

            string sqlUpdatePath = "UPDATE versions set file_path = REPLACE(file_path, ?file_path, ?file_pathNew) where id_science_work=?id_science_work and file_path like '%"+sw+"%'";
            MySqlCommand updatePath = new MySqlCommand(sqlUpdatePath, conn);
            updatePath.Parameters.AddWithValue("?id_science_work", rID);
            updatePath.Parameters.AddWithValue("?file_path",sw);
            updatePath.Parameters.AddWithValue("?file_pathNew",txtTitle.Text);
            updatePath.ExecuteNonQuery();

            
              if (Directory.Exists(Server.MapPath("~/uploads/projects/" + sw)) == true) {

                  string original = Server.MapPath("~/uploads/projects/" + sw);
                  string rinamed = Server.MapPath("~/uploads/projects/" + txtTitle.Text);
                  Directory.Move(@original, @rinamed);

           
               }

             }
              catch (Exception ex)
              {

            //     lblMsg.Text = ex.ToString();
             }
              finally
             {
            btnUpdate.Visible = false;
            Button2.Visible = true;
            conn.Close();

            Response.Redirect("Index.aspx");
            
            }
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
                lblEx.Text = e.Message;
            }
        }

        protected void DeleteDirectoryExist(string NewDirectory)
        {
            try
            {
                if (Directory.Exists(NewDirectory))
                {
                    Directory.Delete(NewDirectory, true);
                }
            }
            catch (Exception e)
            {
                lblEx.Text = e.Message;
            }
        }

        //popup  chose corr.autor
        protected void Button11_Click(object sender, EventArgs e)
        {
            string autor = "";
            string fullName = "";
            string email = "";
            foreach (ListItem item in cblCorispondingAutors.Items)
            {
                if (item.Selected == true)
                {




                    try
                    {

                        conn.Open();
                        string selectAutor = "Select name, surname,email from user_info where id =?id";
                        MySqlCommand cmd = new MySqlCommand(selectAutor, conn);
                        cmd.Parameters.Add("?id", item.Value);

                        cmd.ExecuteNonQuery();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataSet sd = new DataSet();
                        adapter.Fill(sd);

                        fullName += sd.Tables[0].Rows[0]["name"] + " " + sd.Tables[0].Rows[0]["surname"] + ", ";
                        email += sd.Tables[0].Rows[0]["email"] + ", ";



                        autor += item.Value + ", ";
                    }
                    catch (Exception) { }
                    finally
                    {
                        conn.Close();

                    }


                }


            }

            TextBox1.Text = email;

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblTitle1.Text = "Креирај Труд";
            btnUpdate.Visible = false;
            Button2.Visible = true;
        }



    }
}