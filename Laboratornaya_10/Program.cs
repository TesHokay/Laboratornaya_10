using CarLibrary;
using System;
using DialClockLib;
using System.Collections;
using System.Collections.Generic;

namespace Laboratornaya_10
{
    public class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("|1 Задание| \n");

            //Ввод количества элементов массива
            int n = 0;
            bool IsChecked = true;
            do
            {
                Console.WriteLine("Введите количество элементов массива:");
                IsChecked = int.TryParse(Console.ReadLine(), out n);
                if (!IsChecked || n < 0 || n > 50)
                {
                    Console.WriteLine("Вы ввели не число, отрицательное или вещественное число, введите неотрицательное, натуральное число от 0 до 50:");
                    IsChecked = false;
                }

            }
            while (!IsChecked);

            //Формирование массива из объектов
            Car[] cars = new Car[n];

            for (int i = 0; i < cars.Length; i++)
            {
                if (i % 3 == 0)
                {
                    cars[i] = new PassengerCar();
                }
                if (i % 3 == 1)
                {
                    cars[i] = new SUV();
                }
                if (i % 3 == 2)
                {
                    cars[i] = new Truck();
                }
                cars[i].InitRandom();

            }

            Console.WriteLine("АВТОМОБИЛИ:");
            //Вывод элементов
            int num = 1;
            foreach (Car car in cars)
            {
                Console.WriteLine($"|{num}|");
                num += 1;
                Console.WriteLine(car.Show());
            }
            Console.WriteLine();
            Console.WriteLine("|2 Задание| \n");
            //Запросы
            Console.WriteLine("ЗАПРОСЫ:");
            Console.WriteLine("|1|");

            //Запрос самый дорогой внедорожник
            SUV mostExpensiveSUV = Requests.MostExpensiveSUV(cars);
            if (mostExpensiveSUV != null)
            {
                Console.WriteLine($"Самый дорогой внедорожник: {mostExpensiveSUV.Show()}");
            }
            else
            {
                Console.WriteLine("Самый дорогой внедорожник не найден");
            }

            Console.WriteLine();
            Console.WriteLine("|2|");

            //Запрос средняя скорость легковых автомобилей
            int averageSpeedPassengerCar = Requests.AverageSpeedPassengerCar(cars);
            if (averageSpeedPassengerCar != 0)
            {
                Console.WriteLine($"Средняя скорость легковых автомобилей: {averageSpeedPassengerCar}");
            }
            else
            {
                Console.WriteLine($"Легковые автомобили не найдены");
            }
            
            Console.WriteLine();
            Console.WriteLine("|3|");

            //Запрос суммарная стоимость всех автомобилей
            decimal priceAllCars = Requests.PriceAllCars(cars);
            if (averageSpeedPassengerCar != 0)
            {
                Console.WriteLine($"Стоимость всех автомобилей: {priceAllCars}");
            }
            else
            {
                Console.WriteLine($"Автомобили не найдены");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("|3 Задание| \n");

            //Создание смешанного массива
            Random random = new Random();

            Console.WriteLine("СМЕШАННЫЙ МАССИВ:");

            ArrayList mixedArray = new ArrayList();

            int countClock = 0;
            int countCar = 0;

            for (int i = 0; i < 5; i++)
            {
                if (i % 2 == 0)
                {
                    countCar++;
                    mixedArray.Add(cars[random.Next(0, cars.Length)]);
                }
                else
                {
                    DialClock clock1 = new DialClock(random.Next(0,23),random.Next(0,59));
                    countClock++;
                    mixedArray.Add(clock1);
                }
            }

            //Вывод смешанного массива
            num = 1;
            foreach (object obj in mixedArray)
            {
                Console.WriteLine($"|{num}|");
                if (obj is Car car)
                {
                    Console.WriteLine(car.Show());
                }
                else if (obj is DialClock clock)
                {
                    Console.WriteLine(clock);
                }
                num++;
            }

            Console.WriteLine($"Количество элементов DialClock: {countClock}");
            Console.WriteLine($"Количество элементов Car: {countCar}");

            // Сортировка массива по году выпуска
            Array.Sort(cars);


            // Вывод массива после сортировки
            num = 1;
            Console.WriteLine("\nМассив из 1 задания после сортировки по году выпуска (по возрастанию):\n");
            foreach (var car in cars)
            {
                Console.WriteLine($"|{num}|");
                Console.WriteLine(car.Show());
                num++;
            }

            // Бинарный поиск автомобиля с определенным годом выпуска
            int searchYear = 0;
            do
            {
                Console.WriteLine("Введите год выпуска автомобиля для поиска:");
                IsChecked = int.TryParse(Console.ReadLine(), out searchYear);
                if (!IsChecked || searchYear < 1889 || searchYear > 2025)
                {
                    Console.WriteLine("Вы ввели не число, отрицательное или вещественное число, введите неотрицательное, натуральное число от 1889 до 2025:");
                    IsChecked = false;
                }

            }
            while (!IsChecked);

            Car searchCar = new Car { Year = searchYear };
       
            int index = Array.BinarySearch(cars, searchCar);

            if (index >= 0)
            {
                Console.WriteLine($"\nАвтомобиль со стоимостью {searchYear} найден:");
                Console.WriteLine(cars[index].Show());
            }
            else
            {
                Console.WriteLine($"\nАвтомобиль со стоимостью {searchYear} не найден.");
            }

            // Сортировка массива по стоимости с использованием 
            Array.Sort(cars, new Car.CarPriceComparer());

            // Вывод отсортированного массива
            num = 1;
            Console.WriteLine("\nМассив после сортировки по стоимости:");
            foreach (var car in cars)
            {
                Console.WriteLine($"|{num}|");
                Console.WriteLine(car.Show());
                num++;
            }

            Car originalCar = new Car("Toyota", 2015, "Синий", 50000, 150, 1532);

            // Поверхностное копирование
            Car shallowCopyCar = originalCar.ShallowCopy();

            // Глубокое клонирование
            Car deepCopyCar = (Car)originalCar.Clone();

            // Вывод оригинального объекта
            Console.WriteLine("\nОригинальный объект:");
            Console.WriteLine(originalCar.Show());

            // Изменяем данные в оригинальном объекте
            originalCar.Brand = "Ford";
            originalCar.Id.Number = 5647;

            // Вывод поверхностной копии
            Console.WriteLine("\nПоверхностная копия:");
            Console.WriteLine(shallowCopyCar.Show());

            // Вывод глубокой копии
            Console.WriteLine("\nГлубокая копия:");
            Console.WriteLine(deepCopyCar.Show());

        }
    }
}
