using CarLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class PassengerCarTest
    {
        [TestMethod]
        public void Constructor_WithParameters_SetsSeatsCorrectly()
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

            // Act
            var passengerCar = new PassengerCar(brand, year, color, price, clearance, idNumber, seats, maxSpeed);

            // Assert
            Assert.AreEqual(seats, passengerCar.Seats);
        }

        [TestMethod]
        public void Show_ReturnsCorrectSeats()
        {
            // Arrange
            var passengerCar = new PassengerCar("Toyota", 2020, "Red", 30000, 150, 1234, 5, 200);

            // Act
            var result = passengerCar.Show();

            // Assert
            StringAssert.Contains(result, "Количество мест: 5");
        }

        [TestMethod]
        public void Show_ReturnsCorrectMaxSpeed()
        {
            // Arrange
            var passengerCar = new PassengerCar("Toyota", 2020, "Red", 30000, 150, 1234, 5, 200);

            // Act
            var result = passengerCar.Show();

            // Assert
            StringAssert.Contains(result, "Максимальная скорость: 200");
        }

        [TestMethod]
        public void InitRandom_SetsSeatsWithinValidRange()
        {
            // Arrange
            var passengerCar = new PassengerCar();

            // Act
            passengerCar.InitRandom();

            // Assert
            Assert.IsTrue(passengerCar.Seats >= 0 && passengerCar.Seats <= 100);
        }

        [TestMethod]
        public void InitRandom_SetsMaxSpeedWithinValidRange()
        {
            // Arrange
            var passengerCar = new PassengerCar();

            // Act
            passengerCar.InitRandom();

            // Assert
            Assert.IsTrue(passengerCar.MaxSpeed >= 0 && passengerCar.MaxSpeed <= 400);
        }

        [TestMethod]
        public void Seats_WithValidValue_SetsCorrectly()
        {
            // Arrange
            var passengerCar = new PassengerCar();

            // Act
            passengerCar.Seats = 5;

            // Assert
            Assert.AreEqual(5, passengerCar.Seats);
        }

        [TestMethod]
        public void Seats_WithInvalidValue_ThrowsArgumentException()
        {
            // Arrange
            var passengerCar = new PassengerCar();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => passengerCar.Seats = -5);
        }

        [TestMethod]
        public void MaxSpeed_WithValidValue_SetsCorrectly()
        {
            // Arrange
            var passengerCar = new PassengerCar();

            // Act
            passengerCar.MaxSpeed = 200;

            // Assert
            Assert.AreEqual(200, passengerCar.MaxSpeed);
        }

        [TestMethod]
        public void MaxSpeed_WithInvalidValue_ThrowsArgumentException()
        {
            // Arrange
            var passengerCar = new PassengerCar();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => passengerCar.MaxSpeed = 500);
        }
    }
}
