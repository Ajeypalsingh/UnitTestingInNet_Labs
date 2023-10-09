using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkingSystem.Models
{
    public class VehicleTracker
    {
        public string Address { get; set; }
        public int Capacity { get; set; }
        public int SlotsAvailable { get; set; }
        public Dictionary<int, Vehicle> VehicleList { get; set; } = new Dictionary<int, Vehicle>();

        public VehicleTracker(int capacity, string address)
        {
            Capacity = capacity;
            Address = address;
            VehicleList = new Dictionary<int, Vehicle>();
            SlotsAvailable = capacity;

            GenerateSlots();
        }

        public static string BadSearchMessage = "Error: Search did not yield any result.";
        public static string BadSlotNumberMessage = "Error: No slot with number ";
        public static string SlotsFullMessage = "Error: no slots available.";


        // Loop should start from 1 so that we can have only 10 slots 1 to 10 not 0 to 10
        public void GenerateSlots()
        {
            for (int i = 1; i <= Capacity; i++)
            {
                VehicleList.Add(i, null);
            }
        }

        public void AddVehicle(Vehicle vehicle)
        {
            foreach (KeyValuePair<int, Vehicle> slot in VehicleList)
            {
                if (slot.Value == null)
                {
                    VehicleList[slot.Key] = vehicle;
                    SlotsAvailable--;
                    return;
                }
            }
            throw new IndexOutOfRangeException(SlotsFullMessage);
        }

        public void RemoveVehicle(string licence)
        {
            try
            {
                int slot = VehicleList.First(v => v.Value.Licence == licence).Key;
                SlotsAvailable++;
                VehicleList[slot] = null;
            }
            catch
            {
                throw new NullReferenceException(BadSearchMessage);
            }
        }

        public bool RemoveVehicle(int slotNumber)
        {
            if (slotNumber > Capacity)
            {
                return false;
            }
            VehicleList[slotNumber] = null;
            SlotsAvailable++;
            return true;
        }

        public List<Vehicle> ParkedPassholders()
        {
            List<Vehicle> passHolders = new List<Vehicle>();
            passHolders.AddRange(VehicleList.Values.Where(v => v != null && v.Pass));
            return passHolders;
        }

        public int PassholderPercentage()
        {
            int passHolders = ParkedPassholders().Count();
            int totalParked = Capacity - SlotsAvailable;
            if (totalParked == 0) return 0;
            double percentage = ((double)passHolders / totalParked) * 100;
            return (int)percentage;
        }
    }
}
