using CarLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public class SUV : PassengerCar
    {
        //Свойства
        public string AllWheelDrive { get; set; }
        public string OffRoadType { get; set; }

        //Конструктор без параметров
        public SUV() : base()
        {
            AllWheelDrive = "Нет";
            OffRoadType = null;
        }

        //Конструктор с параметрами
        public SUV(string brand, int year, string color, decimal price, int clearance, int idNumber, int seats, int maxSpeed, string allWheelDrive, string offRoadType) : base(brand, year, color, price, clearance, idNumber, seats, maxSpeed) 
        {
            AllWheelDrive = allWheelDrive;
            OffRoadType = offRoadType;
        }


        //Метод вывода
        public override string Show()
        {
            
            return ($"{base.Show()}, Полный привод: {AllWheelDrive}, Тип бездорожья: {OffRoadType}");
        }

        private static Random random = new Random();

        //Метод для формирования объектов с помощью ДСЧ
        public override void InitRandom()
        {
            string[] offroadTypes = { "Грунтовый", "Горный", "Грязевой", "Песочный", "Водный", "Грязевой" };
            string[] allWheelDrive = { "Да", "Нет" };

            base.InitRandom();

            AllWheelDrive = allWheelDrive[random.Next(allWheelDrive.Length)];
            OffRoadType = offroadTypes[random.Next(offroadTypes.Length)];
        }
    }
}


