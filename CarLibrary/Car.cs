using System;
using System.Collections.Generic;

namespace CarLibrary
{
    public class Car : IInit, IComparable<Car>, ICloneable
    {

        //Поля
        protected string brand;
        protected int year;
        protected string color;
        protected decimal price;
        protected int clearance;
        public int idNumber;

        //Свойства объектов
        public string Brand { get; set; }

        public int Year
        {
            get
            { return year; }
            set
            {
                if (value < 1886 || value > 2025)
                {
                    throw new ArgumentException("Год выпуска автомобиля не может быть меньше 1886 и больше 2025");
                }
                else
                {
                    year = value;
                }
            }
        }
        public string Color { get; set; }
        public decimal Price
        {
            get
            { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Стоимость не может быть отрицательной");
                }
                price = value;
            }
        }
        public int Clearance
        {
            get
            { return clearance; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Клиренс не может быть отрицательным");
                }
                clearance = value;
            }
        }
        public IdNumber Id { get; set; }


        //Конструктор без параметров
        public Car() { }

        //Конструктор с параметрами
        public Car(string brand, int year, string color, decimal price, int clearance, int idNumber)
        {
            Brand = brand;
            Year = year;
            Color = color;
            Price = price;
            Clearance = clearance;
            Id = new IdNumber(idNumber);
            this.idNumber = idNumber;
        }

        //Конструктор копирования
        public Car(Car other)
        {
            Brand = other.Brand;
            Year = other.Year;
            Color = other.Color;
            Price = other.Price;
            Clearance = other.Clearance;
            Id = new IdNumber(other.idNumber);
        }

        //Метод просмотра объектов класса
        public virtual string Show()
        {
            if (this.GetType().Name == "PassengerCar")
            {
                Console.WriteLine("Тип автомобиля: Легковой автомобиль");
            }
            if (this.GetType().Name == "SUV")
            {
                Console.WriteLine("Тип автомобиля: Внедорожник");
            }
            if (this.GetType().Name == "Truck")
            {
                Console.WriteLine("Тип автомобиля: Грузовик");
            }
            return ($"Бренд: {Brand}, Год выпуска: {Year}, Цвет: {Color}, Стоимость: {Price}, Клиренс: {Clearance}, ID: {idNumber}");
        }

        //Метод для ввода информации об объектах с клавиатуры
        public virtual void Init()
        {

        }

        private static Random random = new Random();

        //Метод для формирования объектов с помощью ДСЧ
        public virtual void InitRandom()
        {
            string[] brands = { "Toyota", "Honda", "Nissan", "BMW", "LADA", "Mercedes-Benz", "Pagani", "Ford", "Alfa Romeo", "Datsun" };
            string[] colors = { "Белый", "Черный", "Синий", "Красный", "Желтый", "Зеленый", "Серый", "Фиолетовый"};
            string[] offroadTypes = {"Грунтовый", "Горный", "Грязевой", "Песочный", "Водный", "Грязевой"};

            Brand = brands[random.Next(brands.Length)];
            Year = random.Next(1889, 2025);
            Color = colors[random.Next(colors.Length)];
            Price = random.Next(0, 9999999);
            Clearance = random.Next(0, 300);
            idNumber = random.Next(1111,9999);
        }

        //Для сортировки по году
        public int CompareTo(Car other)
        {
            if (other == null)
            {
                return 1; 
            }
            return this.Year.CompareTo(other.Year);
            
        }

        //Для сортировки по стоимости
        public class CarPriceComparer : IComparer<Car>
        {
            public int Compare(Car x, Car y)
            {
                if (x == null || y == null)
                {
                    throw new ArgumentNullException("Объекты для сравнения не могут быть пустыми.");
                }
                return x.Price.CompareTo(y.Price);
            }
        }

        //IDNUMBER
        public class IdNumber
        {
            private int number;

            // Конструктор без параметров
            public IdNumber()
            {
                number = 0;
            }

            // Конструктор с параметром
            public IdNumber(int number)
            {
                Number = number; // Используем свойство для проверки
            }

            // Свойство для доступа к number с проверкой
            public int Number
            {
                get { return number; }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Значение номера не может быть меньше 0");
                    }
                    number = value;
                }
            }

            // Переопределение метода Equals
            public override bool Equals(object obj)
            {
                if (obj is IdNumber other)
                {
                    return this.number == other.number;
                }
                return false;
            }

            // Переопределение метода ToString
            public override string ToString()
            {
                return $"IdNumber: {number}";
            }
        }

        // Метод для глубокого клонирования
        public object Clone()
        {
            // Клонируем ссылочные поля вручную
            return new Car
            {
                Brand = this.Brand,
                Year = this.Year,
                Color = this.Color,
                Price = this.Price,
                Clearance = this.Clearance,
                Id = new IdNumber(this.Id.Number),
                idNumber = this.idNumber
            };
        }

        // Метод для поверхностного копирования
        public Car ShallowCopy()
        {
            return (Car)this.MemberwiseClone();
        }


        //Метод Equals
        public override bool Equals(object obj)
        {
            return obj is Car car &&
                   Brand == car.Brand &&
                   Year == car.Year &&
                   Color == car.Color &&
                   Price == car.Price &&
                   Clearance == car.Clearance;
        }
    }
}
