using CarLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class SUVTest
    {
        [TestClass]
        public class SUVTests
        {
            [TestMethod]
            public void Constructor_WithParameters_SetsAllWheelDriveCorrectly()
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
                string allWheelDrive = "Да";
                string offRoadType = "Горный";

                // Act
                var suv = new SUV(brand, year, color, price, clearance, idNumber, seats, maxSpeed, allWheelDrive, offRoadType);

                // Assert
                Assert.AreEqual(allWheelDrive, suv.AllWheelDrive);
            }

            [TestMethod]
            public void Constructor_WithParameters_SetsOffRoadTypeCorrectly()
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
                string allWheelDrive = "Да";
                string offRoadType = "Горный";

                // Act
                var suv = new SUV(brand, year, color, price, clearance, idNumber, seats, maxSpeed, allWheelDrive, offRoadType);

                // Assert
                Assert.AreEqual(offRoadType, suv.OffRoadType);
            }

            [TestMethod]
            public void Show_ReturnsCorrectAllWheelDrive()
            {
                // Arrange
                var suv = new SUV("Toyota", 2020, "Red", 30000, 150, 1234, 5, 200, "Да", "Горный");

                // Act
                var result = suv.Show();

                // Assert
                StringAssert.Contains(result, "Полный привод: Да");
            }

            [TestMethod]
            public void Show_ReturnsCorrectOffRoadType()
            {
                // Arrange
                var suv = new SUV("Toyota", 2020, "Red", 30000, 150, 1234, 5, 200, "Да", "Горный");

                // Act
                var result = suv.Show();

                // Assert
                StringAssert.Contains(result, "Тип бездорожья: Горный");
            }

            [TestMethod]
            public void InitRandom_SetsAllWheelDriveCorrectly()
            {
                // Arrange
                var suv = new SUV();

                // Act
                suv.InitRandom();

                // Assert
                Assert.IsTrue(suv.AllWheelDrive == "Да" || suv.AllWheelDrive == "Нет");
            }

            [TestMethod]
            public void InitRandom_SetsOffRoadTypeCorrectly()
            {
                // Arrange
                var suv = new SUV();

                // Act
                suv.InitRandom();

                // Assert
                Assert.IsTrue(new[] { "Грунтовый", "Горный", "Грязевой", "Песочный", "Водный", "Грязевой" }.Contains(suv.OffRoadType));
            }

            [TestMethod]
            public void AllWheelDrive_WithValidValue_SetsCorrectly()
            {
                // Arrange
                var suv = new SUV();

                // Act
                suv.AllWheelDrive = "Да";

                // Assert
                Assert.AreEqual("Да", suv.AllWheelDrive);
            }

            [TestMethod]
            public void OffRoadType_WithValidValue_SetsCorrectly()
            {
                // Arrange
                var suv = new SUV();

                // Act
                suv.OffRoadType = "Горный";

                // Assert
                Assert.AreEqual("Горный", suv.OffRoadType);
            }

        }

    }
}
