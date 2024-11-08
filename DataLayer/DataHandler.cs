using CRUD_Using_Database.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;  //name space that allow us to do CRUD operations
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Using_Database
{
    internal class DataHandler
    {
        //create a string that will point to the database 
        string database = "Server =.; Initial Catalog = Store; Integrated Security = True";

        //Create object that will establish the connection
        SqlConnection connectToDatbase;

        //Create object that will execute SQL queries
        SqlCommand executeCommand;

        //create a method that will read data from database 

        //create a list that will store the values values read from a database 
        public List<Category> CategoryData = new List<Category>();
        public void Read()
        {
            //officially establish the connection
            connectToDatbase = new SqlConnection(database);
            //open the connection
            connectToDatbase.Open();

            //query the database 
            string query = @"SELECT * FROM Categories";
            //execute the query
            executeCommand = new SqlCommand(query, connectToDatbase);

            //Use SqlDataReader object to read the returned data row by row 
            SqlDataReader readData = executeCommand.ExecuteReader();

            //we can check if table has rows 
            if (readData.HasRows)
            {
                //SqlDataReader reads rows by rows, we need to loop
                while (readData.Read())
                {
                    //Console.WriteLine($"{readData.GetInt32(0)} --- {readData.GetString(1)}");
                    //we want to add each row to a list
                    //create an instance of Category and initialize it with a row
                    Category category = new Category()
                    {
                        CategoryId = readData.GetInt32(0),
                        CaregoryName = readData.GetString(1),
                    };
                    CategoryData.Add(category);
                }
            }
            else
            {
                Console.WriteLine("TABLE IS EMPTY");
            }

            connectToDatbase.Close();
        }

        public void InsertData(string category)
        {
            //officially establish a connection
            connectToDatbase = new SqlConnection (database);

            //open the connection
            connectToDatbase.Open();
            //create a query to insert data
            string query = $@"INSERT INTO Categories (CategoryName)
VALUES ('{category}')";

            //execute the query 
            executeCommand = new SqlCommand(query, connectToDatbase);

            //execute the ExecuteNonQuery() method in order to add to the database
            executeCommand.ExecuteNonQuery();

            //close the connection
            connectToDatbase.Close();
            
        }


        //this method will take user input to update existing data in the database
        public void UpdateDatabase(string category, int id)
        {
            //officially establish the connection
            connectToDatbase = new SqlConnection(database);
            //open the connection
            connectToDatbase.Open();

            //set up the query to update the existing database value
            string query = $@"UPDATE Categories
SET CategoryName = '{category}'
WHERE CategoryId = '{id}'";

            //execute the query 
            executeCommand = new SqlCommand(query, connectToDatbase);
            
            //execute the SqlCommand method that Updates the database
            executeCommand.ExecuteNonQuery();

            //close the connection
        }

        public void DeleteData(int categoryId)
        {
            //officially connect to database
            connectToDatbase = new SqlConnection(database);
            //open the connection

            //write query that will delete the row
            string query = $@"DELETE FROM Categories
WHERE CategoryId = '{categoryId}'";

            //execute the query 
            executeCommand = new SqlCommand();
            executeCommand.CommandText = query;
            executeCommand.Connection = connectToDatbase;
            connectToDatbase.Open();
            //execute the SqlCommand method that will execute the query 
            executeCommand.ExecuteNonQuery();
            //close the connection
            connectToDatbase.Close();
        }

        public int TotalData()
        {
            //officially connect to database
            connectToDatbase = new SqlConnection(database);
            //open the connection
            connectToDatbase.Open();

            //query that will return the total results
            string query = @"SELECT COUNT(*)
FROM Categories";

            //execute the query
            executeCommand = new SqlCommand(query, connectToDatbase);
            int totalDataRows = (int)executeCommand.ExecuteScalar();
            return totalDataRows;
        }
    }
}
