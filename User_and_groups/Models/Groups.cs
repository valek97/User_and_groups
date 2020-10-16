using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace User_and_groups.Models
{
    public class Groups
    {
        [Key]
        public int IdGroups { get; set; }
        public string NameGroups { get; set; }

        public  ICollection<Users> Users{ get; set; }

        public Groups()
        {
            Users = new List<Users>();
        }
    }
}