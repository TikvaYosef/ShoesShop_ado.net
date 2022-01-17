using ShoesShop_ado.net.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoesShop_ado.net.Controllers.API
{
    public class SportController : ApiController
    {
        string connectionstrin = "Data Source=desktop-5e70rm2;Initial Catalog=ShoesStoreDB;Integrated Security=True;Pooling=False";
        List<SportShoe> shoe = new List<SportShoe>();

        // GET: api/Sport
        public List<SportShoe> ShowAllSportShoes(List<SportShoe> shoe, string connectionstrin)
        {
            using (SqlConnection connection = new SqlConnection(connectionstrin))
            {
                connection.Open();
                string query = @"SELECT * FROM sportshoe ";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader datafromdb = command.ExecuteReader();
                if (datafromdb.HasRows)
                {
                    while (datafromdb.Read())
                    {
                        shoe.Add(new SportShoe(datafromdb.GetString(1), datafromdb.GetInt32(2), datafromdb.GetInt32(3)));

                    }
                }
                else
                {
                    Console.WriteLine("no rows in table");
                }
                connection.Close();


            }
                return shoe;
        }

        public IHttpActionResult Get()
        {
            List<SportShoe> shoes = ShowAllSportShoes(shoe, connectionstrin);
            return Ok(new { shoes });
        }






        // GET: api/Sport/5

        public List<SportShoe> ShowShoe(string connectionstrin, List<SportShoe> shoe,int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionstrin))
            {
                connection.Open();
                string query = $@"SELECT * FROM sportshoe WHERE Id = {id}";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader datafromdb = command.ExecuteReader();
                if (datafromdb.HasRows)
                {
                    while (datafromdb.Read())
                    {
                        shoe.Add(new SportShoe(datafromdb.GetString(1), datafromdb.GetInt32(2), datafromdb.GetInt32(3)));
                    }
                }
                else
                {
                     Console.WriteLine("no rows in table");
                }

            }

            return shoe;
        }

        public IHttpActionResult Get(int id)
        {
            List<SportShoe> shoes = ShowShoe(connectionstrin, shoe, id);
            return Ok(new { shoes });
        }




        // POST: api/Sport
        public IHttpActionResult Post([FromBody] SportShoe obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstrin))
                {
                    connection.Open();
                    string query = $@"INSERT INTO sportshoe (company,price,size) VALUES('{obj.company}',{obj.price},{obj.size})";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rowEffected = command.ExecuteNonQuery();
                    connection.Close();
                    
                    return Ok(rowEffected);
                }
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        // PUT: api/Sport/5
        public IHttpActionResult Put(int id, [FromBody] SportShoe obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstrin))
                {
                    connection.Open();
                    string query = $@"UPDATE sportshoe SET company = '{obj.company}',price = {obj.price},size = {obj.size} WHERE Id = {id} ";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rowEffected = command.ExecuteNonQuery();
                    connection.Close();

                    return Ok(rowEffected);
                }
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // DELETE: api/Sport/5
        public IHttpActionResult Delete(int id)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstrin))
                {
                    connection.Open();
                    string query = $@"Delete from sportshoe WHERE Id = {id} ";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rowEffected = command.ExecuteNonQuery();
                    connection.Close();

                    return Ok(rowEffected);
                }
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
