using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using Microsoft.AspNet;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Mime;
using main.Property;

namespace mainController.Controllers
{
    public class mainController : Controller
    {
        public JsonResult getAllExp()

        {
            SqlConnection S1 = new SqlConnection("Data Source=rasahr.com;Initial Catalog=Ostadyab;User ID=sa;Password=a@27437823");
            S1.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Exp", S1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            S1.Close();
            List<main.Property.Exp> L1 = new List<main.Property.Exp>();
            for (int i = 0; i <= dt1.Rows.Count - 1; i++)
            {
                main.Property.Exp pro = new main.Property.Exp();

                pro.ID = Int32.Parse(dt1.Rows[i]["ID"].ToString());
                pro.Name = dt1.Rows[i]["Name"].ToString();
              


                L1.Add(pro);
            }



            return Json(L1, JsonRequestBehavior.AllowGet);
         }
        public class ImageDTO
        {
            public string FileName { get; set; }

            public IFormFile Image { get; set; }
        }
       
        public void Post([FromBody]createUsers value)
        {
            SqlConnection S5 = new SqlConnection("Data Source=rasahr.com;Initial Catalog=Ostadyab;User ID=sa;Password=a@27437823");
            var query = "insert into Users(ID,Name,PhoneNumber,Fname,ExpID,Sex,Photo,Details,Expage,Username) value(@ID,@Name,@PhoneNumber,@Fname,@ExpID,@Sex,@Photo,@Details,@Expage,@Username)";
            SqlCommand insertcommand = new SqlCommand(query, S5);
            insertcommand.Parameters.AddWithValue("ID",value.ID);
            insertcommand.Parameters.AddWithValue("Name",value.Name);
            insertcommand.Parameters.AddWithValue("PhoneNumber", value.PhoneNumber);
            insertcommand.Parameters.AddWithValue("Fname", value.Fname);
            insertcommand.Parameters.AddWithValue("ExpID", value.ExpID);
            insertcommand.Parameters.AddWithValue("Sex", value.Sex);
            insertcommand.Parameters.AddWithValue("Photo", value.Photo);
            insertcommand.Parameters.AddWithValue("Details", value.Details);
            insertcommand.Parameters.AddWithValue("Expage", value.Expage);
            insertcommand.Parameters.AddWithValue("Username", value.Username);
            S5.Open();
            int result = insertcommand.ExecuteNonQuery();
            if(result > 0)
            {

                return;
            }
            else

            {

                return;
            }

        }

       

        public JsonResult getAllUsers()

         {
            SqlConnection S2 = new SqlConnection("Data Source=rasahr.com;Initial Catalog=Ostadyab;User ID=sa;Password=a@27437823");
            S2.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Users", S2);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            S2.Close();
            List<main.Property.Users> L2 = new List<main.Property.Users>();
            for (int i = 0; i <= dt1.Rows.Count - 1; i++)
            {
                main.Property.Users pro = new main.Property.Users();

                pro.ID = Int32.Parse(dt1.Rows[i]["ID"].ToString());
                pro.Name = dt1.Rows[i]["Name"].ToString();
                pro.Fname = dt1.Rows[i]["Fname"].ToString();
                pro.PhoneNumber = dt1.Rows[i]["PhoneNumber"].ToString();
                pro.ExpID =Int32.Parse( dt1.Rows[i]["ExpID"].ToString());
                pro.Sex = dt1.Rows[i]["Sex"].ToString();
                pro.Photo = dt1.Rows[i]["Photo"].ToString();
                pro.Details = dt1.Rows[i]["Details"].ToString();
                pro.Expage = dt1.Rows[i]["Expage"].ToString();
                pro.Username = dt1.Rows[i]["Username"].ToString();




                L2.Add(pro);
            }



            return Json(L2, JsonRequestBehavior.AllowGet);
          }
            public JsonResult getAllLogin()
        {
              SqlConnection S3= new SqlConnection("Data Source=rasahr.com;Initial Catalog=Ostadyab;User ID=sa;Password=a@27437823");
              S3.Open();
              SqlDataAdapter da1 = new SqlDataAdapter("select * from Login", S3);
              DataTable dt1 = new DataTable();
              da1.Fill(dt1);
              S3.Close();
              List<main.Property.Login> L3 = new List<main.Property.Login>();
              for (int i = 0; i <= dt1.Rows.Count - 1; i++)
            {
                main.Property.Login pro = new main.Property.Login();
                pro.ID = Int32.Parse(dt1.Rows[i]["ID"].ToString());
                pro.UserName = dt1.Rows[i]["UserName"].ToString();
                pro.Password = dt1.Rows[i]["Password"].ToString();

                L3.Add(pro);
            }
            return Json(L3, JsonRequestBehavior.AllowGet);
        }

    }

    internal class FromBodyAttribute : Attribute
    {
    }
}
