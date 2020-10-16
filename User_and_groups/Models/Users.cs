using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace User_and_groups.Models
{
    public class Users
    {
        [Key]
        public int IdUsers { get; set; }
        public string NameUsers { get; set; }

        public virtual ICollection<Groups> Groups { get; set; }

        public Users()
        {
            Groups = new List<Groups>();
        }
    }
}