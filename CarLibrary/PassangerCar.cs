using System;

namespace CarLibrary
{
    public class PassengerCar : Car
    {
        //Поля
        protected int seats;
        protected int maxSpeed;

        //Свойства
        public int Seats
        {
            get
            {
                return seats;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Количество мест не может быть отрицательным или больше 100");
                }
                else
                {
                    seats = value;
                }
            }
        }
        public int MaxSpeed
        {
            get
            {
                return maxSpeed;
            }
            set
            {
                if (value < 0 || value > 400)
                {
                    throw new ArgumentException("Максимальная скорость не может быть отрицательной или больше 400");
                }
                else
                {
                    maxSpeed = value;
                }
            }
        }

        //Конструктор без параметров
        public PassengerCar() : base()
        {
            Seats = 0;
            MaxSpeed = 0;
        }

        //Конструктор с параметрами
        public PassengerCar(string brand, int year, string color, decimal price, int clearance, int idNumber, int seats, int maxSpeed):base(brand, year, color, price, clearance, idNumber)
        {
            Seats = seats;
            MaxSpeed = maxSpeed;
        }

        //Метод вывода
        public override string Show()
        {
            return ($"{base.Show()}, Количество мест: {Seats}, Максимальная скорость: {MaxSpeed}");
        }

        private static Random random = new Random();

        //Метод для формирования объектов с помощью ДСЧ
        public override void InitRandom()
        {
            base.InitRandom();

            Seats = random.Next(0, 100);
            MaxSpeed = random.Next(0, 400);
        }
    }
}
