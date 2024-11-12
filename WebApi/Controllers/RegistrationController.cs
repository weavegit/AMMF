using Api.Controllers;
using Classes.Enum;
using Common.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace AmmfApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : BaseController
    {
        public RegistrationController(IConfiguration config) : base(config)
        {
            _config = config;
        }
        // POST api/<RegistrationController>
        [HttpPost]
        public Result Post([FromBody] RegistrationDto registration)
        {
            Result result = Result.Success;
            try
            {
                var DBConnection = _config?.GetValue<string>("ConnectionStrings:DefaultConnection");
                using (var sqlCon = new SqlConnection(DBConnection))
                {
                    sqlCon.Open();
                    SqlCommand sql_cmnd = new("[dbo].[InsertRegistrationForm]", sqlCon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sql_cmnd.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = registration.FirstName;
                    sql_cmnd.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = registration.LastName;
                    sql_cmnd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = registration.Email;
                    sql_cmnd.Parameters.AddWithValue("@Company", SqlDbType.NVarChar).Value = registration.Company;
                    sql_cmnd.Parameters.AddWithValue("@Title", SqlDbType.NVarChar).Value = registration.Title;
                    sql_cmnd.Parameters.AddWithValue("@Questions", SqlDbType.NVarChar).Value = registration.AnyQuestions;
                    sql_cmnd.Parameters.AddWithValue("@SelectedTopicId", SqlDbType.UniqueIdentifier).Value = registration.SelectedTopicId;
                    sql_cmnd.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            catch (Exception e)
            {
                result = Result.Fail;
            }
            return result;
        }
    }
}
