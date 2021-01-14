using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Classes
{
    public class Options
    {

        long id;
        string name;
        string description;
        int idZone;

        public long Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int IdZone { get => idZone; set => idZone = value; }
    }
}