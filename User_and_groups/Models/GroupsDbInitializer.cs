using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace User_and_groups.Models
{
    public class GroupsDbInitializer : DropCreateDatabaseAlways<AllDbContext>
    {
        protected override void Seed(AllDbContext context)
        {
            Users u1 = new Users { NameUsers = "Егор" };
            Users u2 = new Users { NameUsers = "Матвей" };
            Users u3 = new Users { NameUsers = "Олег" };
            Users u4 = new Users { NameUsers = "Валентин" };


            context.Users.Add(u1);
            context.Users.Add(u2);
            context.Users.Add(u3);
            context.Users.Add(u4);

            Groups g1 = new Groups
            {
                NameGroups = "Информационные системы",
                Users = new List<Users>() { u1, u2, u3 }
            };
            Groups g2 = new Groups
            {

                NameGroups = "Алгоритмы и структуры данных",
                Users = new List<Users>() { u2, u4 }
            };
            Groups g3 = new Groups
            {
                NameGroups = "Основы HTML и CSS",
                Users = new List<Users>() { u3, u4, u1 }
            };

            context.Groups.Add(g1);
            context.Groups.Add(g2);
            context.Groups.Add(g3);

            base.Seed(context);
        }
    }
}