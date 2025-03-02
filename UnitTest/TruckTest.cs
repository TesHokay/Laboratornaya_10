using CarLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class TruckTest
    {
        [TestMethod]
        public void Constructor_WithParameters_SetsCapacityCorrectly()
        {
            // Arrange
            string brand = "Toyota";
            int year = 2020;
            string color = "Red";
            decimal price = 30000;
            int clearance = 150;
            int idNumber = 1234;
            int seats = 5;
            int maxSpeed = 200;
            int capacity = 5000;

            // Act
            var truck = new Truck(brand, year, color, price, clearance, idNumber, seats, maxSpeed, capacity);

            // Assert
            Assert.AreEqual(capacity, truck.Capacity);
        }

        [TestMethod]
        public void Constructor_WithNegativeCapacity_ThrowsArgumentException()
        {
            // Arrange
            string brand = "Toyota";
            int year = 2020;
            string color = "Red";
            decimal price = 30000;
            int clearance = 150;
            int idNumber = 1234;
            int seats = 5;
            int maxSpeed = 200;
            int capacity = -5000; // Некорректная грузоподъемность

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Truck(brand, year, color, price, clearance, idNumber, seats, maxSpeed, capacity));
        }

        [TestMethod]
        public void Show_ReturnsCorrectCapacity()
        {
            // Arrange
            var truck = new Truck("Toyota", 2020, "Red", 30000, 150, 1234, 5, 200, 5000);

            // Act
            var result = truck.Show();

            // Assert
            StringAssert.Contains(result, "Грузоподъемность: 5000");
        }

        [TestMethod]
        public void InitRandom_SetsCapacityWithinValidRange()
        {
            // Arrange
            var truck = new Truck();

            // Act
            truck.InitRandom();

            // Assert
            Assert.IsTrue(truck.Capacity >= 0 && truck.Capacity <= 999999999);
        }

        [TestMethod]
        public void Capacity_WithValidValue_SetsCorrectly()
        {
            // Arrange
            var truck = new Truck();

            // Act
            truck.Capacity = 5000;

            // Assert
            Assert.AreEqual(5000, truck.Capacity);
        }

        [TestMethod]
        public void Capacity_WithNegativeValue_ThrowsArgumentException()
        {
            // Arrange
            var truck = new Truck();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => truck.Capacity = -5000);
        }
    }

}