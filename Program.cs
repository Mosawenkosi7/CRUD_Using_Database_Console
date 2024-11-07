﻿using CRUD_Using_Database.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Using_Database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Display ds = new Display();
            
            //display the category table
            ds.DisplayCategoryTable();

            //Insert category
            ds.AddCategory();

            //display the category table (NEW NEW ADDED CATEGORY)
            ds.DisplayCategoryTable();
        }
    }
}
