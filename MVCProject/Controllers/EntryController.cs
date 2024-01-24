using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class EntryController : Controller
    {
        public IConfiguration Configuration { get; }
        public EntryController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Login l) {
            string connectionString = Configuration["ConnectionStrings:StudentManagementConnection"];
            using (var con = new SqlConnection(connectionString))
            {

              

                using (var cmd = new SqlCommand("select dbo.login_check(@username,@pwd)", con))
                {
                    cmd.Parameters.AddWithValue("@username", l.UserName);
                    cmd.Parameters.AddWithValue("@pwd", l.Pwd);


                    con.Open();
                    int c = Convert.ToInt32(cmd.ExecuteScalar());

                    if (c == 1)
                    {

                        Console.WriteLine("welcome User");
                        return RedirectToAction("Index", "StudentManagement");


                    }
                    else
                    {
                        Console.WriteLine("Account No or Password is wrong!!!");


                    }
                }

            }
            return View(l);

        }

        public ActionResult signup() {

            return View();
        }

        [HttpPost]
        public ActionResult signup(Login l) {

            string connectionString = Configuration["ConnectionStrings:StudentManagementConnection"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = $"insert into user_login values('{l.UserName}','{l.Pwd}')";
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
    }
}
