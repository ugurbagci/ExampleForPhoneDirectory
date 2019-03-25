using PhoneApplication.DAL.ORM.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApplication.DAL.ORM.Entity
{
    public class AppUser:BaseEntity
    {
     
        public string FirstName { get; set; }      
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(LastName))
                {
                    return FirstName;
                }
                else
                {
                    return FirstName + " " + LastName;
                }
            }
        }
       
        public string PhoneNumber { get; set; }

        

    }
}
