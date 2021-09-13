using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApp1
{
    class Airportement
    {

        class Airport
        {
            public string name;
            public string status;
            protected uint _totalPassangers;
            protected uint _totalPlanes;
            protected List<Plane> Planes = new List<Plane>();

            public Airport()
            {
                Console.WriteLine("Enter name of the airport.");
                name = Console.ReadLine();
                Console.WriteLine("Enter current status of work of the airport. (working / closed)");
                status = Console.ReadLine();
            }

            public Airport(string __name, string __status)
            {
                name = __name;
                status = __status;
            }
            
            
            
        }


        class Plane : Airport
        {
            
        }
        
        
        
        
        
        
        
        
        
        
        
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}