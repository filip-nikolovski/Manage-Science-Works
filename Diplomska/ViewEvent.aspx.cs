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
    public partial class ViewEvent : System.Web.UI.Page
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
        static string idH = "";

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


                    //code za kalendar ... (aside)
                    //code za event remider greeedView
                    string sqlSel = "SELECT DISTINCT h.id, CONCAT(full_name,' - ',Holiday) as hol, HolidayDate  FROM holidays h, conference c, science_work sw WHERE h.conference_ID = c.id AND c.science_work_id = sw.id AND sw.autores LIKE  '%" + Session["New"].ToString() + "%' and HolidayDate>=CURDATE( ) +0 and HolidayDate<=DATE_ADD(NOW(), INTERVAL 5 DAY) OR h.conference_ID = c.id AND c.science_work_id = sw.id AND sw.Corresponding_autor LIKE  '%" + Session["New"].ToString() + "%' and HolidayDate>=CURDATE( ) +0 and HolidayDate<=DATE_ADD(NOW(), INTERVAL 5 DAY) ORDER BY HolidayDate ASC";

                    MySqlCommand cmdReminder = new MySqlCommand(sqlSel, conn);
                    MySqlDataAdapter ad = new MySqlDataAdapter(cmdReminder);
                    DataSet das = new DataSet();
                    ad.Fill(das);

                    gvReminder.DataSource = das;
                    gvReminder.DataBind();

                    //calendar code
                    Calendar1.VisibleDate = DateTime.Today;
                    FillHolidayDataSet();

                    //MAIN CONTENT CODE

                    if (Session["Reminder"] == null || Session["Reminder"].ToString() == "")
                    {

                        idH = Request.QueryString["eventID"].ToString();
                    }
                    else {
                        idH = Session["Reminder"].ToString();
                    }

                   
                        

                    
                 

                    string selectReINFO = "select sw.title, c.full_name, c.place, h.HolidayDate, h.Holiday FROM holidays h, conference c, science_work sw WHERE h.conference_ID=c.id AND c.science_work_id=sw.id AND h.id=?id";
                    MySqlCommand cmdEvent = new MySqlCommand(selectReINFO, conn);
                    cmdEvent.Parameters.Add("?id", idH);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmdEvent);
                    DataSet dsRem = new DataSet();
                    adapter.Fill(dsRem);
                    cmdReminder.ExecuteNonQuery();
                   
                    lblSWTitle.Text = "Научен труд: " + dsRem.Tables[0].Rows[0]["title"].ToString();
                    lblConfTitle.Text = "Конференција: " + dsRem.Tables[0].Rows[0]["full_name"].ToString();
                    lblEvent.Text = "Настан: " + dsRem.Tables[0].Rows[0]["Holiday"].ToString();
                    lblDate.Text = "Дата на настанот: " + dsRem.Tables[0].Rows[0]["HolidayDate"].ToString();
                    lblPlace.Text = "Место на настанот: " + dsRem.Tables[0].Rows[0]["place"].ToString();

                    lblNav.Text = dsRem.Tables[0].Rows[0]["title"].ToString();

                    //code za ddlSW
                    string selectScienceSork = "SELECT c.*, CONCAT(title,' - ',full_name) as fname from conference c,science_work sw where sw.id=c.science_work_id  and sw.autores LIKE '%" + Session["New"].ToString() + "%' OR sw.Corresponding_autor LIKE '%" + Session["New"].ToString() + "%' and sw.id=c.science_work_id";
                    MySqlCommand cmdDDL = new MySqlCommand(selectScienceSork, conn);
                    MySqlDataAdapter adapterDDL = new MySqlDataAdapter(cmdDDL);
                    DataSet dsDDL = new DataSet();
                    adapterDDL.Fill(dsDDL);

                    ddlSW.DataSource = dsDDL;
                    ddlSW.DataBind();
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
                //lblErr.Text = Session["Reminder"].ToString();
            }

        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                conn.Open();
                string sqlDelete = "DELETE from holidays where id=?id";
                MySqlCommand cmd = new MySqlCommand(sqlDelete, conn);
                cmd.Parameters.Add("?id", idH);
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally
            {
                conn.Close();
                Response.Redirect("Events.aspx");
            }
        }


        protected void btnModify_Click(object sender, EventArgs e)
        {

            try
            {
                conn.Open();
                string sqlSelect = "SELECT id, Holiday, DATE_FORMAT(HolidayDate, GET_FORMAT(DATE,'ISO')) as HolidayDate, conference_ID from holidays where id=?id";
                MySqlCommand cmd = new MySqlCommand(sqlSelect, conn);
                cmd.Parameters.Add("?id", idH);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                // txtHoliday.Text = ds.Tables[0].Rows[0]["Holiday"].ToString();
                ddlSW.SelectedIndex = ddlSW.Items.IndexOf(ddlSW.Items.FindByValue(ds.Tables[0].Rows[0]["conference_ID"].ToString()));
                ddlEvent.SelectedIndex = ddlEvent.Items.IndexOf(ddlEvent.Items.FindByText(ds.Tables[0].Rows[0]["Holiday"].ToString()));
                txtEventDate.Text = ds.Tables[0].Rows[0]["HolidayDate"].ToString();

            }
            catch { }
            finally
            {
                conn.Close();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                conn.Open();
                string sqlUpdate = "UPDATE holidays set HolidayDate=?HolidayDate, Holiday=?Holiday WHERE id=?id";
                MySqlCommand cmd1 = new MySqlCommand(sqlUpdate, conn);


                cmd1.Parameters.Add("?HolidayDate", txtEventDate.Text);
                cmd1.Parameters.Add("?Holiday", ddlEvent.SelectedItem.Text);
                cmd1.Parameters.Add("?id", idH);
                cmd1.ExecuteNonQuery();


                if (ddlEvent.SelectedValue == "date_abstract")
                {
                    string insertEvent = "UPDATE conference set date_abstract=?date_abstract where id=?id";
                    MySqlCommand cmd = new MySqlCommand(insertEvent, conn);
                    cmd.Parameters.Add("?date_abstract", txtEventDate.Text);
                    cmd.Parameters.Add("?id", ddlSW.SelectedValue);
                    cmd.ExecuteNonQuery();
                }
                else if (ddlEvent.SelectedValue == "date_full_paper")
                {
                    string insertEvent = "UPDATE conference set date_full_paper=?date_full_paper where id=?id";
                    MySqlCommand cmd = new MySqlCommand(insertEvent, conn);
                    cmd.Parameters.Add("?date_full_paper", txtEventDate.Text);
                    cmd.Parameters.Add("?id", ddlSW.SelectedValue);
                    cmd.ExecuteNonQuery();
                }
                else if (ddlEvent.SelectedValue == "date_izvestuvajne")
                {
                    string insertEvent = "UPDATE conference set date_izvestuvajne=?date_izvestuvajne where id=?id";
                    MySqlCommand cmd = new MySqlCommand(insertEvent, conn);
                    cmd.Parameters.Add("?date_izvestuvajne", txtEventDate.Text);
                    cmd.Parameters.Add("?id", ddlSW.SelectedValue);
                    cmd.ExecuteNonQuery();
                }
<<<<<<< HEAD
                else if (ddlEvent.SelectedValue == "date_camera_ready")
=======
                else if (ddlEvent.SelectedValue == "date_camera_redy")
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
                {
                    string insertEvent = "UPDATE conference set date_camera_redy=?date_camera_redy where id=?id";
                    MySqlCommand cmd = new MySqlCommand(insertEvent, conn);
                    cmd.Parameters.Add("?date_camera_redy", txtEventDate.Text);
                    cmd.Parameters.Add("?id", ddlSW.SelectedValue);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    string insertEvent = "UPDATE conference set date_konferencija=?date_konferencija where id=?id";
                    MySqlCommand cmd = new MySqlCommand(insertEvent, conn);
                    cmd.Parameters.Add("?date_konferencija", txtEventDate.Text);
                    cmd.Parameters.Add("?id", ddlSW.SelectedValue);
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
            finally
            {
                conn.Close();
                Response.Redirect("Events.aspx");
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



        //************** LOGOUT BUTTON***************
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["New"] = null;
            Response.Redirect("Login.aspx");
        }

     
        // ************ASIDE AND NAVIGATION CODE***********************
        //**********************  END   *******************************
        // ************ASIDE AND NAVIGATION CODE***********************




  

    }
}