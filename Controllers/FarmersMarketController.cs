using FarmersMarketRESTAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
namespace FarmersMarketRESTAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FarmersMarketController : ControllerBase
    {


        private readonly IConfiguration _configuration;

        //FarmersMarketController constructor 
        public FarmersMarketController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllProduce")]

        public Response GetAllProduce()
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("farmersConnection"));
            DBApplication dBApplication = new DBApplication();
            response = dBApplication.GetAllProduce(con);
            return response;

        }
//----------------------------------------------------------------------------------------------------------------------

        //GetFruitbyId
        // search one studemt from database ..
        //Step 1 Create a type of request - [HttpGet]
        //Step 2 Create route that will execute this and pass the ID parameter  [Route("GetStudentbyId/{id}")]
        // Step 3 Create an instance of the Response ....Response response; response = new Response();
        // Step 4 Create the connection to the database 
        // Step 5 Create an instance  DBApplication to query the database by id and connect to database 
        //Step 5 Call the Method that will search for student by ID 

        [HttpGet]
        [Route("GetFruitbyId/{id}")]
        public Response GetFruitbyId(int id)
        {
            Response response; response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("farmersConnection"));
            DBApplication dBApplication = new DBApplication();
            response = dBApplication.GetFruitbyId(con, id);
            return response;
        }

        //-------------------------------------------------------------------------------------------------------------------//
        //AddStudent()
        // Insert new student
        //Step 1 Create a type of request - [HttpPost]
        //Step 2 Pass full Student class variable inside the method , from local machine to remote machine 
        // Step 3 Create an instance of the Response ....Response response; response = new Response();
        // Step 4 Create the connection to the database 
        // Step 5 Create an instance  DBApplication to query the database by id and connect to database 
        //Step 5 Call the Method that will search for student by ID 

        [HttpPost]
        [Route("AddFruits")]

        public Response AddFruits(Fruits fruits)
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("farmersConnection"));
            DBApplication dBApplication = new DBApplication();
            response = dBApplication.AddFruits(con, fruits);
            return response;
        }

//-------------------------------------------------------------------------------------------------------------------//
        //UpdateFruit()


        [HttpPut]
        [Route("UpdateFruits")]

        public Response UpdateFruits(Fruits fruits)
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("farmersConnection"));
            DBApplication dBApplication = new DBApplication();
            response = dBApplication.UpdateFruits(con, fruits);
            return response;
        }

//--------------------------------------------------------------------------------------------------------------------------
        //DeleteFruit()


        [HttpDelete]
        [Route("DeleteFruitbyid/{id}")]

        public Response DeleteStudentbyId(int id)
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("farmersConnection"));
            DBApplication dBApplication = new DBApplication();
            response = dBApplication.DeleteFruitbyid(con, id);
            return response;
        }
        //-------------------------------------------------------------------------------------------------------------------

        [HttpPut]
        [Route("BuyFruitbyid")]

        public Response BuyFruitbyid(Fruits fruits)
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("farmersConnection"));
            DBApplication dBApplication = new DBApplication();
            response = dBApplication.BuyFruitbyid(con, fruits);
            return response;
        }
    }

}
