using System;

namespace CarLibrary
{
    public class Truck : PassengerCar
    {
        //Поля
        protected int capacity;
        
        //Свойства
        public int Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Грузоподъемность не может быть отрицательной");
                }
                else
                {
                    capacity = value;
                }
            }
        }

        //Конструктор без параметров
        public Truck(): base()
        {
            Capacity = 0;
        }

        //Конструктор с параметрами
        public Truck(string brand, int year, string color, decimal price, int clearance, int idNumber, int seats, int maxSpeed, int capacity) : base(brand, year, color, price, clearance, idNumber, seats, maxSpeed)
        {
            Capacity = capacity;
        }

        //Метод вывода
        public override string Show()
        {
            return ($"{base.Show()}, Грузоподъемность: {Capacity}");
        }

        private static Random random = new Random();

        //Метод для формирования объектов с помощью ДСЧ
        public override void InitRandom()
        {
            base.InitRandom();

            Capacity = random.Next(0, 999999999);
        }
    }
}

