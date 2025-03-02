using CarLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class CarTest
    {
        [TestMethod]
        public void Constructor_WithParameters_SetsBrandCorrectly()
        {
            // Arrange
            string brand = "Toyota";
            int year = 2020;
            string color = "Red";
            decimal price = 30000;
            int clearance = 150;
            int idNumber = 1234;

            // Act
            var car = new Car(brand, year, color, price, clearance, idNumber);

            // Assert
            Assert.AreEqual(brand, car.Brand);
        }

        [TestMethod]
        public void Constructor_WithNegativeYear_ThrowsArgumentException()
        {
            // Arrange
            string brand = "Toyota";
            int year = -2020; // Некорректный год
            string color = "Red";
            decimal price = 30000;
            int clearance = 150;
            int idNumber = 1234;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Car(brand, year, color, price, clearance, idNumber));
        }

        [TestMethod]
        public void Show_ReturnsCorrectBrand()
        {
            // Arrange
            var car = new Car("Toyota", 2020, "Red", 30000, 150, 1234);

            // Act
            var result = car.Show();

            // Assert
            StringAssert.Contains(result, "Бренд: Toyota");
        }

        [TestMethod]
        public void Show_ReturnsCorrectYear()
        {
            // Arrange
            var car = new Car("Toyota", 2020, "Red", 30000, 150, 1234);

            // Act
            var result = car.Show();

            // Assert
            StringAssert.Contains(result, "Год выпуска: 2020");
        }

        [TestMethod]
        public void InitRandom_SetsYearWithinValidRange()
        {
            // Arrange
            var car = new Car();

            // Act
            car.InitRandom();

            // Assert
            Assert.IsTrue(car.Year >= 1889 && car.Year <= 2025);
        }

        [TestMethod]
        public void InitRandom_SetsPriceWithinValidRange()
        {
            // Arrange
            var car = new Car();

            // Act
            car.InitRandom();

            // Assert
            Assert.IsTrue(car.Price >= 0 && car.Price <= 9999999);
        }

        [TestMethod]
        public void Equals_WithSameProperties_ReturnsTrue()
        {
            // Arrange
            var car1 = new Car("Toyota", 2020, "Red", 30000, 150, 1234);
            var car2 = new Car("Toyota", 2020, "Red", 30000, 150, 1234);

            // Act
            var result = car1.Equals(car2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_WithDifferentProperties_ReturnsFalse()
        {
            // Arrange
            var car1 = new Car("Toyota", 2020, "Red", 30000, 150, 1234);
            var car2 = new Car("Ford", 2021, "Blue", 25000, 160, 5678);

            // Act
            var result = car1.Equals(car2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Clone_CreatesDeepCopy()
        {
            // Arrange
            var originalCar = new Car("Toyota", 2020, "Red", 30000, 150, 1234);

            // Act
            var clonedCar = (Car)originalCar.Clone();

            // Assert
            Assert.AreEqual(originalCar.Brand, clonedCar.Brand);
        }

        [TestMethod]
        public void ShallowCopy_CreatesShallowCopy()
        {
            // Arrange
            var originalCar = new Car("Toyota", 2020, "Red", 30000, 150, 1234);

            // Act
            var shallowCopyCar = originalCar.ShallowCopy();

            // Assert
            Assert.AreEqual(originalCar.Brand, shallowCopyCar.Brand);
        }

        [TestMethod]
        public void CompareTo_SortsByYear()
        {
            // Arrange
            var car1 = new Car("Toyota", 2020, "Red", 30000, 150, 1234);
            var car2 = new Car("Ford", 2019, "Blue", 25000, 160, 5678);

            // Act
            var result = car1.CompareTo(car2);

            // Assert
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void CarPriceComparer_SortsByPrice()
        {
            // Arrange
            var car1 = new Car("Toyota", 2020, "Red", 30000, 150, 1234);
            var car2 = new Car("Ford", 2019, "Blue", 25000, 160, 5678);
            var comparer = new Car.CarPriceComparer();

            // Act
            var result = comparer.Compare(car1, car2);

            // Assert
            Assert.IsTrue(result > 0);
        }
    }
}
