using CarLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laboratornaya_10
{
    public class Requests
    {
        //Самый дорогой внедорожник
        public static SUV MostExpensiveSUV(Car[] cars)
        {
            SUV mostExpensive = null;
            foreach (Car car in cars)
            {
                if (car is SUV suv)
                {
                    if (mostExpensive == null || suv.Price > mostExpensive.Price)
                    {
                        mostExpensive = suv;
                    }
                }
            }
            return mostExpensive;
        }

        //Средняя скорость легковых автомобилей
        public static int AverageSpeedPassengerCar(Car[] cars)
        {
            int summ = 0;
            int count = 0;
            int averageSpeed = 0;

            foreach (Car car in cars)
            {
                if (car is PassengerCar passengerCar)
                {
                    summ += passengerCar.MaxSpeed;
                    count++;
                }
            }
            averageSpeed = summ / count;
            return averageSpeed;
        }

        //Суммарная стоимость всех автомобилей
        public static decimal PriceAllCars(Car[] cars)
        {
            decimal summ = 0;

            foreach (Car car in cars)
            {
                summ += car.Price;
            }
            return summ;
        }
    }
}
