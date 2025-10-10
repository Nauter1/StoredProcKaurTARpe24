using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StoredProcedureTARpe24.Data;
using StoredProcedureTARpe24.Models;

namespace StoredProcedureTARpe24.Controllers
{
    public class DepartmentController : Controller
    {
        public StoredProcDbContext _context;
        public IConfiguration _config;


        public DepartmentController(StoredProcDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        [HttpGet]
        public IActionResult Index()
        {
            string connectionString = _config.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchResults";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Department> model = new List<Department>();
                while (sdr.Read())
                {
                    var details = new Department();
                    details.Id = Convert.ToInt32(sdr["Id"]);
                    details.Name = sdr["Name"].ToString();
                    details.Employees = Convert.ToInt32(sdr["Employees"]);
                    details.Location = sdr["Location"].ToString();
                    details.Rating = Convert.ToInt32(sdr["Rating"]);
                    details.Money = Convert.ToInt32(sdr["Money"]);
                    details.Crimes = Convert.ToInt32(sdr["Crimes"]);
                    details.Comment = sdr["Comment"].ToString();
                    details.FavoriteMonth = sdr["FavoriteMonth"].ToString();
                    details.VacationDays = Convert.ToInt32(sdr["VacationDays"]);
                    model.Add(details);
                }
                return Json(model);

            }
        }
    }
}
