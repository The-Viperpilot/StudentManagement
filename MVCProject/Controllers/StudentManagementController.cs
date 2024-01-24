using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVCProject.Migrations;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class StudentManagementController : Controller
    {
        public IConfiguration Configuration { get;}
        // GET: StudentManagementController
        public StudentManagementController(IConfiguration config)
        {
            Configuration = config;
        }


        
        public ActionResult Index()
        {
            List<StudentManagement> sm = new List<StudentManagement>();
            string connectionString = Configuration["ConnectionStrings:StudentManagementConnection"];
           //string connectionString = "Data Source=(localdb)\\Local;Initial Catalog=KARTHICK;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string sql = "select * from StudentManages";
                SqlCommand cmd = new SqlCommand(sql,con);
                using(SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        StudentManagement students = new StudentManagement();
                        students.StudentId = Convert.ToInt32(sdr["StudentId"]);
                        students.StudentName = Convert.ToString(sdr["StudentName"]);
                        students.StudentAge = Convert.ToInt32(sdr["StudentAge"]);
                        students.StudentGender = Convert.ToString(sdr["StudentGender"]);
                        students.StudentGrade = Convert.ToString(sdr["StudentGrade"]);
                        students.StudentEmail = Convert.ToString(sdr["StudentEmail"]);
                        students.StudentPhoneNumber = Convert.ToInt32(sdr["StudentPhoneNumber"]);
                        sm.Add(students);
                    }
                    con.Close();
                }
            }
            return View(sm);
        }

        // GET: StudentManagementController/Details/5
        public ActionResult Details(int id)
        {
            StudentManagement students = new StudentManagement();
            string connectionString = Configuration["ConnectionStrings:StudentManagementConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"select * from StudentManages where StudentId='{id}'";
                SqlCommand cmd = new SqlCommand(sql, connection);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {

                        students.StudentId = Convert.ToInt32(sdr["StudentId"]);
                        students.StudentName = Convert.ToString(sdr["StudentName"]);
                        students.StudentAge = Convert.ToInt32(sdr["StudentAge"]);
                        students.StudentGender = Convert.ToString(sdr["StudentGender"]);
                        students.StudentGrade = Convert.ToString(sdr["StudentGrade"]);
                        students.StudentEmail = Convert.ToString(sdr["StudentEmail"]);
                        students.StudentPhoneNumber = Convert.ToInt32(sdr["StudentPhoneNumber"]);

                    }
                    connection.Close();
                }

            }
            return View(students);
        }

        // GET: StudentManagementController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentManagementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentManagement manage)
        {
            try
            {
                string connectionString = Configuration["ConnectionStrings:StudentManagementConnection"];
                using(SqlConnection con = new SqlConnection(connectionString))
                {
                    string sql = $"insert into StudentManages(StudentName,StudentAge,StudentGender,StudentGrade,StudentEmail,StudentPhoneNumber) values('{manage.StudentName}','{manage.StudentAge}','{manage.StudentGender}','{manage.StudentGrade}','{manage.StudentEmail}','{manage.StudentPhoneNumber}')";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    
                }
                ViewBag.result = "success";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentManagementController/Edit/5
        public ActionResult Edit(int id)
        {
            StudentManagement students = new StudentManagement();
            string connectionString = Configuration["ConnectionStrings:StudentManagementConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"select * from StudentManages where StudentId='{id}'";
                SqlCommand cmd = new SqlCommand(sql, connection);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {

                        students.StudentId = Convert.ToInt32(sdr["StudentId"]);
                        students.StudentName = Convert.ToString(sdr["StudentName"]);
                        students.StudentAge = Convert.ToInt32(sdr["StudentAge"]);
                        students.StudentGender = Convert.ToString(sdr["StudentGender"]);
                        students.StudentGrade = Convert.ToString(sdr["StudentGrade"]);
                        students.StudentEmail = Convert.ToString(sdr["StudentEmail"]);
                        students.StudentPhoneNumber = Convert.ToInt32(sdr["StudentPhoneNumber"]);

                    }
                    connection.Close();
                }

            }
            return View(students);
        }

        // POST: StudentManagementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StudentManagement students)
        {
            string connectionString = Configuration["ConnectionStrings:StudentManagementConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Update StudentManages SET StudentName='{students.StudentName}',StudentAge='{students.StudentAge}',StudentGender={students.StudentGender},StudentGrade='{students.StudentGrade}' ,StudentEmail='{students.StudentEmail}',StudentPhoneNumber='{students.StudentPhoneNumber}' where StudentId='{id}' ";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {


                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: StudentManagementController/Delete/5
        public ActionResult Delete(int id)
        {
            StudentManagement students = new StudentManagement();
            string connectionString = Configuration["ConnectionStrings:StudentManagementConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"select * from StudentManages where StudentId='{id}'";
                SqlCommand cmd = new SqlCommand(sql, connection);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {

                        students.StudentId = Convert.ToInt32(sdr["StudentId"]);
                        students.StudentName = Convert.ToString(sdr["StudentName"]);
                        students.StudentAge = Convert.ToInt32(sdr["StudentAge"]);
                        students.StudentGender = Convert.ToString(sdr["StudentGender"]);
                        students.StudentGrade = Convert.ToString(sdr["StudentGrade"]);
                        students.StudentEmail = Convert.ToString(sdr["StudentEmail"]);
                        students.StudentPhoneNumber = Convert.ToInt32(sdr["StudentPhoneNumber"]);

                    }
                    connection.Close();
                }

            }
            return View(students);
        }

        // POST: StudentManagementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            string connectionString = Configuration["ConnectionStrings:StudentManagementConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Delete from StudentManages where StudentId='{id}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }
                return RedirectToAction("Index");
            }
        }
    }
}
