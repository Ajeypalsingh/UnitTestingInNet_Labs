using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkingSystem.Models
{
    public class Vehicle
    {
        public string Licence { get; set; }
        public bool Pass { get; set; }
        public Vehicle(string licence, bool pass)
        {
            Licence = licence;
            Pass = pass;
        }
    }
}
