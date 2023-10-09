using CarParkingSystem.Models;

VehicleTracker vt = new VehicleTracker(10, "123 Fake St");
Vehicle vehicle1 = new Vehicle("A01 T22", true);
Vehicle vehicle2 = new Vehicle("A01 T22", true);

vt.AddVehicle(vehicle1);
vt.AddVehicle(vehicle2);


Console.WriteLine(vt.ParkedPassholders().Count());
Console.WriteLine(vt.SlotsAvailable);
Console.WriteLine(vt.Capacity);

Console.WriteLine(vt.PassholderPercentage());
