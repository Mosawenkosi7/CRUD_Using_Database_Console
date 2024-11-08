﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Using_Database.PresentationLayer
{
    internal class Display
    {
        DataHandler handler = new DataHandler();
        
        public void DisplayCategoryTable()
        {
            handler.Read();
            foreach (var item in handler.CategoryData)
            {
                Console.WriteLine($"{item.CategoryId} =====  {item.CaregoryName}");
            }
        }

        public void AddCategory()
        {
            Console.Write("Hello, please enter the category you want to add: ");
            string category = Console.ReadLine();
            handler.InsertData(category);

            //category have been added
            Console.WriteLine("The category HAS been added");

        }

        public void UpdateCategory()
        {
            Console.Clear();
            DisplayCategoryTable(); //display the category

            //display the category table
            Console.Write("Enter category Id to update: ");
            int categoryId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter new category name: ");
            string categoryName = Console.ReadLine();

            //call the method that update the category details
            handler.UpdateDatabase(categoryName,categoryId);
        }

        public void DeleteCategory()
        {
            //display the category to the user
            DisplayCategoryTable();
            Console.WriteLine("");
            //ask user for category id they want to delete
            Console.Write("Enter id of the category to delete: ");
            int categoryId = Convert.ToInt32(Console.ReadLine());
            handler.DeleteData(categoryId);
        }

        public void TotalRows()
        {
            int total = handler.TotalData();
            Console.Write($"The total rows of Categories table are: {total}\n");
           
        }
    }


}
