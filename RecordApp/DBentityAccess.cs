using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordApp
{
    public class DBentityAccess
    {

        public recordsDBEntities db = new recordsDBEntities();

        public void AddPlayer(string name, string imagePath)
        {            
             db.spNewUser(name, imagePath);
             db.SaveChanges();
        }
        public void AddGame()
        {
           
        }
        public void DisplayGames()
        {

        }
        



    }
}
