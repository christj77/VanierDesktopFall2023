using Npgsql;
using System.Data;

namespace FarmersMarketRESTAPI.Models
{
    public class DBApplication
    {
// GetAllStudents() method to query to database 
        // repeat the steps used on wpf to get information from database 
        // because the adapter has made the connections , open , etc , just query the database 
        //after your connect to adapter 
        //Create a datatable to store all information being read 
        //Server will return data retrieved as a Response   
        //Create a Response List that will display , student List Response 
        // put condition to check if ( dt.Row.Count >0 ), that means there is a record in the database 
        //need a loop to add each of th student to the Student List <students>
        public Response GetAllProduce(NpgsqlConnection con)
        {
            string Query = "Select * from farmers";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            List<Fruits> fruit_list = new List<Fruits>();
            if (dt.Rows.Count > 0)
            {
                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    Fruits fruits = new Fruits();
                    fruits.productname = (string)dt.Rows[x]["productname"];
                    fruits.productid = (int)dt.Rows[x]["productid"];
                    fruits.amoutkg = (int)dt.Rows[x]["amoutkg"];
                    fruits.price = (decimal)dt.Rows[x]["price"];

                    fruit_list.Add(fruits);
                }
            }

            if (fruit_list.Count > 0)
            {
                response.statusCode = 200;
                response.messageCode = "Data retrieved successfully ";
                response.fruits = null;
                response.fruit_list = fruit_list;
            }
            else

            {
                response.statusCode = 100;
                response.messageCode = "Data failed to be retrieved or database is empty ";
                response.fruits = null;
                response.fruit_list = null;
            }
            return response;
        }
//------------------------------------------------------------------------------------------------------------------------//
        //GetStudentbyId(){}
        //Step 1 Create Query that will searcfh for information by ID string Query = "Select * from students where std_id='"+ id +"'";
        // Step 2 Create Npgsql Connection -NpgsqlDataAdapter da = new NpgsqlDataAdapter(Query, con);
        // Step 3 Create DataTable dt = new DataTable();
        // Step 4  da.Fill(dt);
        // Step 5 Response response = new Response();
        // Step 6  List<Students> students_list = new List<Students>();
        // Step 7  Verify data query search results 
        // Step 8  Catch students retrieved from database - Students student = new Students();If ....
        // Step 9 confirgure response if (students_list.Count > 0)      {    response.statusCode = 200;
        // Step 10 Return response

        public Response GetFruitbyId(NpgsqlConnection con, int id)
        {
            string Query = "Select * from farmers where productid='" + id + "'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            ////List<Students> students_list = new List<Students>();
            Fruits fruits = new Fruits();

            if (dt.Rows.Count > 0)
            {
                //for (int x = 0; x < dt.Rows.Count; x++)
                {

                    //Fruits fruits = new Fruits();
                    fruits.productname = (string)dt.Rows[0]["productname"];
                    fruits.productid = (int)dt.Rows[0]["productid"];
                    fruits.amoutkg = (int)dt.Rows[0]["amoutkg"];
                    fruits.price = (decimal)dt.Rows[0]["price"];
                    //students_list.Add(student);
                }
            }

            if (dt.Rows.Count > 0)
            {
                response.statusCode = 200;
                response.messageCode = "Data retrieved successfully ";
                response.fruits = fruits;
                response.fruit_list = null;
            }
            else

            {
                response.statusCode = 100;
                response.messageCode = "Data failed to be retrieved or database is empty ";
                response.fruits = null;
                response.fruit_list = null;
            }
            return response;

        }
 //---------------------------------------------------------------------------------------------------------------------       
        //AddFruits(){}
        //Step 1 Create Response instance 
        //Create Query that will insert new datastring Query = "Insert into  students values ( @std_name , std_id , std_email , std_depart , std_year";
        // Step 2 Create  NpgsqlCommand cmd = new NpgsqlCommand(Query, con);
        // Step 3 add new information collected from client -  cmd.Parameters.AddWithValue("@std_name",students.studentname);
        // Step 4  -Verify qeury is executed  int i = cmd.ExecuteNonQuery();
        // Step 5  if (i > 0)  {  response.statusCode = 200;     response.messageCode = "Student Data has been created  ";
        // Step 6   else     {response.statusCode = 100;
        // Step 7  return response;

        public Response AddFruits(NpgsqlConnection con, Fruits fruits)
        {
            con.Open();
            Response response = new Response();
            string Query = "Insert into  farmers values(@productname , @productId , @amoutkg , @price )";
            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@productname", fruits.productname);
            cmd.Parameters.AddWithValue("@productid", fruits.productid);
            cmd.Parameters.AddWithValue("@amoutkg", fruits.amoutkg);
            cmd.Parameters.AddWithValue("@price", fruits.price);
            

            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                response.statusCode = 200;
                response.messageCode = "Fruits Data has been created  ";
                response.fruits = fruits;
                response.fruit_list = null;
            }

            else

            {
                response.statusCode = 100;
                response.messageCode = "Failed to insert fruits";
                response.fruits = null;
                response.fruit_list = null;
            }
            con.Close();
            return response;
        }

//--------------------------------------------------------------------------------------------------------------------//

        //UpdateFruits(){}
        //open connection       con.Open();
        //Step 1 Create Response instance 
        //Create Query that will insert new datastring Query = "Insert into  students values ( @std_name , std_id , std_email , std_depart , std_year";
        // Step 2 Create  NpgsqlCommand cmd = new NpgsqlCommand(Query, con);
        // Step 3 add new information collected from client -  cmd.Parameters.AddWithValue("@std_name",students.studentname);
        // Step 4  -Verify qeury is executed  int i = cmd.ExecuteNonQuery();
        // Step 5  if (i > 0)  {  response.statusCode = 200;     response.messageCode = "Student Data has been created  ";
        // Step 6   else     {response.statusCode = 100;
        // Step 7  return response;

        public Response UpdateFruits(NpgsqlConnection con, Fruits  fruits)
        {
            con.Open();
            Response response = new Response();
            string Query = "Update farmers set  productname=@productname  , amoutkg=@amoutkg , price=@price  where productid=@productid";
             
            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@productname", fruits.productname);
            cmd.Parameters.AddWithValue("@productid", fruits.productid);
            cmd.Parameters.AddWithValue("@amoutkg", fruits.amoutkg);
            cmd.Parameters.AddWithValue("@price", fruits.price);



            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                response.statusCode = 200;
                response.messageCode = "Update of fruits  information successful  ";
                response.fruits = fruits;

            }

            else

            {
                response.statusCode = 100;
                response.messageCode = "Failed to update fruits ";


            }
            con.Close();
            return response;


        }

//--------------------------------------------------------------------------------------------------------------------//
        //DeleteFruits

        public Response DeleteFruitbyid(NpgsqlConnection con, int id)
        {
            con.Open();
            Response response = new Response();
            string Query = "delete from  farmers where productid = '" + id + "' ";
            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);
            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                response.statusCode = 200;
                response.messageCode = "Fruit  successfully deleted   ";
            }

            else
            {
                response.statusCode = 100;
                response.messageCode = "Failed to delete Fruit ";
            }

            con.Close();
            return response;

        }

        //------------------------------------------------------------------------------------------------------------------



        public Response BuyFruitbyid(NpgsqlConnection con, Fruits fruits)
        {
            con.Open();
            Response response = new Response();
            string Query = "Update farmers set  productname=@productname  , amoutkg=@amoutkg , price=@price  where productid=@productid";

            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@productname", fruits.productname);
            cmd.Parameters.AddWithValue("@productid", fruits.productid);
            cmd.Parameters.AddWithValue("@amoutkg", fruits.amoutkg);
            cmd.Parameters.AddWithValue("@price", fruits.price);



            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                response.statusCode = 200;
                response.messageCode = "Update of fruits  information successful  ";
                response.fruits = fruits;

            }

            else

            {
                response.statusCode = 100;
                response.messageCode = "Failed to update fruits ";


            }
            con.Close();
            return response;


        }

    }
}
