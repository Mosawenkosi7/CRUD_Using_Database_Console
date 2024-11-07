using CRUD_Using_Database.PresentationLayer;
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
            DataHandler handler = new DataHandler();
            handler.Read();
            foreach (Category item in handler.CategoryData)
            {
                Console.WriteLine(item.CaregoryName);
            }
        }
    }
}
