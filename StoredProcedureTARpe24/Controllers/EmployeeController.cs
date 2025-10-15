using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StoredProcedureTARpe24.Data;
using StoredProcedureTARpe24.Models;

namespace StoredProcedureTARpe24.Controllers
{
    public class EmployeeController : Controller
    {
        public StoredProcDbContext _context;
        public IConfiguration _config;
        

        public EmployeeController(StoredProcDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DynamicSQL()
        {

            string connectionString = _config.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchEmployees";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Employee> model = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.Salary = Convert.ToInt32(sdr["Salary"]);
                    model.Add(details);
                }
                return View(model);

            }
        }

        [HttpPost]
        public IActionResult DynamicSQL(string FirstName, string LastName, string Gender, int Salary)
        {
            string connectionString = _config.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                StringBuilder sbCommand = new StringBuilder("SELECT * FROM Employees WHERE 1=1");

                if (!string.IsNullOrEmpty(FirstName))
                {
                    sbCommand.Append(" AND FirstName=@FirstName");
                    SqlParameter param = new SqlParameter("@FirstName", FirstName);
                    cmd.Parameters.Add(param);
                }

                if (!string.IsNullOrEmpty(LastName))
                {
                    sbCommand.Append(" AND LastName=@LastName");
                    SqlParameter param = new SqlParameter("@LastName", LastName);
                    cmd.Parameters.Add(param);
                }

                if (!string.IsNullOrEmpty(Gender))
                {
                    sbCommand.Append(" AND Gender=@Gender");
                    SqlParameter param = new SqlParameter("@Gender", Gender);
                    cmd.Parameters.Add(param);
                }


                if (Salary != 0)
                {
                    sbCommand.Append(" AND Salary=@Salary");
                    SqlParameter param = new SqlParameter("@Salary", Salary);
                    cmd.Parameters.Add(param);
                }
                cmd.CommandText = sbCommand.ToString();
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Employee> model = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.Salary = Convert.ToInt32(sdr["Salary"]);
                    model.Add(details);
                }
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult SearchResults()
        {

            string connectionString = _config.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchEmployees";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Employee> model = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.Salary = Convert.ToInt32(sdr["Salary"]);
                    model.Add(details);
                }
                return View(model);

            }
        }

        [HttpGet]
        public IActionResult SearchDynamicSQL()
        {

            string connectionString = _config.GetConnectionString("DefaultConnection");
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchEmployeesGoodDynamicSQL";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Employee> model = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.Salary = Convert.ToInt32(sdr["Salary"]);
                    model.Add(details);
                }

                return View(model);

            }
        }
        /* 
         create proc spSearchEmployeesGoodDynamicSQL
@FirstName nvarchar(100) = NULL,
@LastName nvarchar(100) = NULL,
@Gender nvarchar(50) = NULL,
@Salary int = NULL
as begin
	declare @sql nvarchar(max)
	declare @sqlParams nvarchar(max)							
																
	set @sql = 'Select * from Employees where 1 = 1'			
																
	if(@FirstName is not null)									
		set @sql = @sql + ' and FirstName=@FN'	
																
	if(@LastName is not null)									
		set @sql = @sql + ' and LastName=@LN'	
																
	if(@Gender is not null)										
		set @sql = @sql + ' and Gender=@Gen'		
																
	if(@Salary is not null)										
		set @sql = @sql + ' and Salary=@Sal'		
																
	execute sp_executeSQL @sql, N'@FN nvarchar(50),@LN nvarchar(50),@Gen nvarchar(50), @Sal int',
	@FN=@FirstName,@LN=@LastName,@Gen=@Gender, @Sal=@Salary
end
go
 
         
         */
        [HttpPost]
        public IActionResult SearchDynamicSQL(string FirstName, string LastName, string Gender, int Salary)
        {
            string connectionString = _config.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                StringBuilder sbCommand = new StringBuilder("SELECT * FROM Employees WHERE 1=1");

                if (!string.IsNullOrEmpty(FirstName))
                {
                    sbCommand.Append(" AND FirstName=@FirstName");
                    SqlParameter param = new SqlParameter("@FirstName", FirstName);
                    cmd.Parameters.Add(param);
                }

                if (!string.IsNullOrEmpty(LastName))
                {
                    sbCommand.Append(" AND LastName=@LastName");
                    SqlParameter param = new SqlParameter("@LastName", LastName);
                    cmd.Parameters.Add(param);
                }

                if (!string.IsNullOrEmpty(Gender))
                {
                    sbCommand.Append(" AND Gender=@Gender");
                    SqlParameter param = new SqlParameter("@Gender", Gender);
                    cmd.Parameters.Add(param);
                }


                if (Salary != 0)
                {
                    sbCommand.Append(" AND Salary=@Salary");
                    SqlParameter param = new SqlParameter("@Salary", Salary);
                    cmd.Parameters.Add(param);
                }
                cmd.CommandText = sbCommand.ToString();
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Employee> model = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.Salary = Convert.ToInt32(sdr["Salary"]);
                    model.Add(details);
                }
                return View(model);
            }
        }

    }
}
