using System;
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
                Console.WriteLine(item.CaregoryName);
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
    }
}
