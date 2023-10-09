using CarParkingSystem.Models;

namespace CarParkSystemUnitTests
{
    [TestClass]
    public class CarParkingUnitTest
    {
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(7)]
        [DataRow(8)]
        [DataRow(9)]
        [DataRow(10)]
        public void VehicleList_WhenInitialized_SlotIsEmpty(int slotNumber)
        {
            // Arrange
            VehicleTracker vt = new VehicleTracker(10, "123 Fake St");

            // Act
            Vehicle slotValue = vt.VehicleList[slotNumber];

            // Assert
            Assert.IsNull(slotValue);
        }

        [TestMethod]
        public void AddVehicle_WhenSlotAvailable_VehicleAdded()
        {
            // Arrange
            VehicleTracker vt = new VehicleTracker(10, "123 Fake St");
            Vehicle vehicle = new Vehicle("A01 T22", true);

            // Act
            vt.AddVehicle(vehicle);

            // Assert
            Assert.AreEqual(vehicle, vt.VehicleList[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Error: no slots available.")]
        public void AddVehicle_WhenNoSlotsAvailable_ThrowsException()
        {
            // Arrange
            VehicleTracker vt = new VehicleTracker(1, "123 Fake St");
            Vehicle vehicle1 = new Vehicle("A01 T22", true);
            Vehicle vehicle2 = new Vehicle("B01 T22", true);
            vt.AddVehicle(vehicle1);

            // Act
            vt.AddVehicle(vehicle2); 

            // Assert 
            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                vt.AddVehicle(vehicle2);
            });
        }

        [TestMethod]
        public void RemoveVehicle_WhenLicenseProvided_VehicleRemoved()
        {
            // Arrange
            VehicleTracker vt = new VehicleTracker(10, "123 Fake St");
            Vehicle vehicle = new Vehicle("A01 T22", true);
            vt.AddVehicle(vehicle);

            // Act
            vt.RemoveVehicle("A01 T22");

            // Assert
            Assert.IsNull(vt.VehicleList[1]);
        }

        [TestMethod]
        public void RemoveVehicle_WhenInvalidLicenseProvided_ThrowsException()
        {
            // Arrange
            VehicleTracker vt = new VehicleTracker(10, "123 Fake St");

            // Act & Assert
            Assert.ThrowsException<NullReferenceException>(() =>
            {
                vt.RemoveVehicle("INVALID LICENCE");
            });
        }

        [TestMethod]
        public void RemoveVehicle_WhenSlotNumberProvided_VehicleRemoved()
        {
            // Arrange
            VehicleTracker vt = new VehicleTracker(10, "123 Fake St");
            Vehicle vehicle = new Vehicle("A01 T22", true);
            vt.AddVehicle(vehicle);

            // Act
            bool success = vt.RemoveVehicle(1);

            // Assert
            Assert.IsTrue(success);
            Assert.IsNull(vt.VehicleList[1]);
        }

        [TestMethod]
        public void RemoveVehicle_WhenInvalidSlotNumberProvided_ReturnsFalse()
        {
            // Arrange
            VehicleTracker vt = new VehicleTracker(10, "123 Fake St");

            // Act
            bool success = vt.RemoveVehicle(11); 

            // Assert
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void ParkedPassholders_WithMixedVehicles_ReturnsPassholderList()
        {
            // Arrange
            VehicleTracker vt = new VehicleTracker(10, "123 Fake St");
            Vehicle vehicle1 = new Vehicle("A01 T22", true);
            Vehicle vehicle2 = new Vehicle("B01 T22", false);
            Vehicle vehicle3 = new Vehicle("A41 T22", true);
            vt.AddVehicle(vehicle1);
            vt.AddVehicle(vehicle2);
            vt.AddVehicle(vehicle3);

            // Act
            List<Vehicle> passHolders = vt.ParkedPassholders();

            // Assert
            Assert.AreEqual(2, passHolders.Count);
            Assert.AreEqual("A01 T22", passHolders[0].Licence);
        }

        [TestMethod]
        public void PassholderPercentage_WithMultipleVehicles_ReturnsCorrectPercentage()
        {
            // Arrange
            VehicleTracker vt = new VehicleTracker(10, "123 Fake St");
            Vehicle vehicle1 = new Vehicle("A01 T22", true);
            Vehicle vehicle2 = new Vehicle("B01 T22", true);
            Vehicle vehicle3 = new Vehicle("C01 T22", false);
            Vehicle vehicle4 = new Vehicle("D01 T22", false);
            vt.AddVehicle(vehicle1);
            vt.AddVehicle(vehicle2);
            vt.AddVehicle(vehicle3);
            vt.AddVehicle(vehicle4);

            // Act
            int percentage = vt.PassholderPercentage();

            // Assert
            Assert.AreEqual(50, percentage);
        }
    }
}