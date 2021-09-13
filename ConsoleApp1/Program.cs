using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class AirportManager
    {
        class Airport
        {
            public string Name { get; set; }
            public string Status { get; set; }
            private uint _currentPassengers;
            private uint _currentPlanes = 0;
            private List<Plane> _planes = new List<Plane>();
            private uint _placesForPlanesLeft = 100;

            public Airport()
            {
                Console.WriteLine("Enter name of the airport: ");
                Name = Console.ReadLine();
                Console.WriteLine("Enter current working status of the airport: (working / closed) ");
                Status = Console.ReadLine();
            }

            ~Airport()
            {
                Console.WriteLine($"Airport {Name} was demolished. ");
            }

            public void SetCurrentPassengers(uint currentPassengers)
            {
                _currentPassengers = currentPassengers;
            }

            public void SetCurrentPlanes(uint currentPlanes)
            {
                _currentPlanes = currentPlanes;
            }

            public void SetPlanes(List<Plane> planes)
            {
                _planes = planes;
            }

            public void SetPlacesForPlanesLeft(uint placesForPlanesLeft)
            {
                _placesForPlanesLeft = placesForPlanesLeft;
            }

            public Airport(string name, string status)
            {
                Name = name;
                Status = status;
            }

            public static bool operator ==(Airport airport1, Airport airport2)
            {
                if ((airport1 != null && airport2 != null) && airport1.Name == airport2.Name)
                    if (airport1.Status == airport2.Status)
                        if (airport1.GetCurrentPassengers() == airport2.GetCurrentPassengers())
                            if (airport1.GetCurrentPlanes() == airport2.GetCurrentPlanes())
                                if (airport1.GetCurrenListOfPlanes() == airport2.GetCurrenListOfPlanes())
                                    if (airport1.GetPlacesForPlanesLeft() == airport2.GetPlacesForPlanesLeft())
                                        return true;
                return false;
            }

            public static bool operator !=(Airport airport1, Airport airport2)
            {
                if ((airport1 != null && airport2 != null) && 
                    ((airport1.Name != airport2.Name) || 
                     (airport1.Status != airport2.Status) || 
                     (airport1.GetCurrentPassengers() != airport2.GetCurrentPassengers()) || 
                     (airport1.GetCurrentPlanes() != airport2.GetCurrentPlanes()) || 
                     (airport1.GetCurrenListOfPlanes() != airport2.GetCurrenListOfPlanes()) || 
                     (airport1.GetPlacesForPlanesLeft() != airport2.GetPlacesForPlanesLeft()))) 
                    return true;
                return false;
            }

            public uint GetCurrentPassengers()
            {
                return _currentPassengers;
            }

            public uint GetCurrentPlanes()
            {
                return _currentPlanes;
            }

            public List<Plane> GetCurrenListOfPlanes()
            {
                return _planes;
            }

            public uint GetPlacesForPlanesLeft()
            {
                return _placesForPlanesLeft;
            }

            public void AddPlane(Plane plane)
            {
                if (_placesForPlanesLeft > 0 && CheckSerialNumber(plane))
                {
                    _planes.Add(plane);
                    _currentPlanes++;
                    _currentPassengers += plane.GetPassengersLoad();
                    _placesForPlanesLeft--;
                }
                else Console.WriteLine("Airport currently is full.");
            }

            public void DeletePlane(Plane plane)
            {
                        _placesForPlanesLeft++;
                        _currentPassengers -= plane.GetPassengersLoad();
                        _currentPlanes--;
                        _planes.Remove(plane);
            }

            public bool CheckSerialNumber(Plane chkPlane)
            {
                foreach (var plane in _planes)
                    if (chkPlane.GetSerialNumber() == plane.GetSerialNumber())
                        return false;
                return true;
            }

            public void Info()
            {
                Console.WriteLine($"\nBasic info about {Name} Airport:");
                Console.WriteLine($"Airport currently is {Status}.");
                Console.WriteLine($"Current load of passengers is {_currentPassengers}.");
                Console.WriteLine($"Parking places for planes left: {_placesForPlanesLeft}.");
                Console.WriteLine($"Current amount of planes is {_currentPlanes}.");
                Console.WriteLine("\n");
            }
        }

        class Plane
        {
            private string _serialNumber;
            private uint _loadOfPassengers;

            public uint GetPassengersLoad()
            {
                return _loadOfPassengers;
            }

            public string GetSerialNumber()
            {
                return _serialNumber;
            }

            public Plane(string serialNumber, uint loadOfPassengers)
            {
                _serialNumber = serialNumber;
                _loadOfPassengers = loadOfPassengers;
            }

            ~Plane()
            {
                Console.WriteLine($"Plane {_serialNumber} flew away.");
            }

            public Plane()
            {
                Console.WriteLine("Enter serial number of the plane: ");
                _serialNumber = Console.ReadLine();
                Console.WriteLine("Enter current load of passengers on this plane: ");
                if (uint.TryParse(Console.ReadLine(), out _loadOfPassengers)) ;
                else throw new Exception("Wrong number, write number in diapason[0; 350].");
            }

            public static bool operator ==(Plane plane1, Plane plane2)
            {
                if ((plane1 != null && plane2 != null) && plane1._serialNumber == plane2._serialNumber)
                    if (plane1._loadOfPassengers == plane2._loadOfPassengers)
                        return true;
                return false;
            }

            public static bool operator !=(Plane plane1, Plane plane2)
            {
                if ((plane1 != null && plane2 != null) && ((plane1._serialNumber != plane2._serialNumber) || (plane1._loadOfPassengers == plane2._loadOfPassengers)))
                    return true;
                return false;
            }

            public void LandInAirport(Airport airport)
            {
                airport.AddPlane(this);
            }
        }

        static void Main(string[] args)
        {
            var airport = new Airport();
            var plane1 = new Plane();
            airport.Info();
            airport.AddPlane(plane1);
            airport.Info();
            var plane2 = new Plane();
            plane2.LandInAirport(airport);
            var plane3 = new Plane("SN3", 300);
            airport.AddPlane(plane3);
            airport.Info();
            var plane4 = new Plane();
            airport.AddPlane(plane4);
            airport.Info();



        }
    }
}

// Made by Sh0uT 09.13.2021 