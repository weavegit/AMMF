using Api.Controllers;
using Common.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TopicController : BaseController
    {
        public TopicController(IConfiguration config) : base(config)
        {
            _config = config;
        }
        [HttpGet]
        public List<TopicDto> Get()
        {
            List<TopicDto> Topics = [];
            try
            {
                var DBConnection = _config?.GetValue<string>("ConnectionStrings:DefaultConnection");

                string sqlCall = "[dbo].[GetAllWebinarTopics]";
                using (var connection = new SqlConnection(DBConnection))
                {
                    using (SqlCommand cmd = new(sqlCall, connection))
                    {
                        connection.Open();
                        using SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            if (sdr["TopicId"] != null && sdr["TopicName"] != null)
                            {
                                Topics.Add(new TopicDto(sdr["TopicId"]?.ToString(),
                                    sdr["TopicName"]?.ToString()));
                            }

                        }
                    }
                    connection.Close();
                }

                return Topics;

            }
            catch (Exception e)
            {
                return Topics;
            }
        }
    }
}
