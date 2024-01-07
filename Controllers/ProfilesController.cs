using Microsoft.AspNetCore.Mvc;
using split_me_backend.Contracts;
using System.Data;
using System.Data.SqlClient;

namespace split_me_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ProfilesController(IConfiguration configuration) { //TODO: use applicationdbcontext
            _configuration = configuration;
        }

        // GET: api/<ProfileController>
        [HttpGet]
        public IEnumerable<Profile> Get()
        {
            return new Profile[] { new Profile { Name = "Profile_1", NameSet = new List<string> { "Neena", "Jobel" } } };
        }

        // GET api/<ProfileController>/5
        [HttpGet("{id}")]
        public Profile Get(int id)
        {
            return new Profile { Name = "Profile_1", NameSet = new List<string> { "Neena", "Jobel" } };
        }

        // POST api/<ProfileController>
        [HttpPost]
        public void Post([FromBody] Profile profile)
        {
            //TODO: Handle validations
            var nameList = String.Join(",", profile.NameSet);
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = _configuration.GetConnectionString("Connection");
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[Profile_Insert]";
                command.Parameters.Add(new SqlParameter("@Name", profile.Name));
                command.Parameters.Add(new SqlParameter("@NameSet", nameList));

                SqlParameter ProfileIdOutput = new SqlParameter("@Id", SqlDbType.Int);//TODO: understand how id is inserted
                ProfileIdOutput.Direction = ParameterDirection.Output;
                command.Parameters.Add(ProfileIdOutput);

                command.ExecuteNonQuery();

                Console.WriteLine(profile.Id);
            }
        }

        // PUT api/<ProfileController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Profile profile)
        {
        }

        // DELETE api/<ProfileController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private static object ReplaceDbNulls(object value)
        {
            if (value is DateTime && (DateTime)value == DateTime.MinValue)
                return DBNull.Value;

            if (value == null)
                return DBNull.Value;

            if (value == DBNull.Value)
                return null;

            return value;
        }
    }
}
