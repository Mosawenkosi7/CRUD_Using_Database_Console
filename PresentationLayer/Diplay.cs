using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Using_Database.PresentationLayer
{
    internal class Diplay
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
    }
}
