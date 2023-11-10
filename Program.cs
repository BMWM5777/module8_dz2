using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module8_dz2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите данные для расчета коммунальных платежей:");

            Console.Write("Площадь помещения (в м2): ");
            double square = double.Parse(Console.ReadLine());

            Console.Write("Количество проживающих людей: ");
            int prozhivaushie = int.Parse(Console.ReadLine());

            Console.Write("Сезон (осень/зима - введите 'осень' или 'зима'): ");
            string season = Console.ReadLine().ToLower();

            Console.Write("Наличие льгот (ветеран труда или ветеран войны - введите 'да' или 'нет'): ");
            bool veteran = Console.ReadLine().ToLower() == "да";

            // Базовые тарифы
            double otoplenieRate = 10; // на 1 м2
            double waterRate = 5; // на 1 человека
            double gasRate = 15; // на 1 человека
            double remontRate = 8; // на 1 м2

            // Расчет начислений
            double otoplenieCost = square * otoplenieRate;
            double waterCost = prozhivaushie * waterRate;
            double gasCost = prozhivaushie * gasRate;
            double remontCost = square * remontRate;

            if (season == "осень" || season == "зима")
            {
                otoplenieCost *= 1.2; // Отопление дороже в осенне-зимний период
            }

            // Расчет льготной скидки
            double discount = 0;
            if (veteran)
            {
                discount = (otoplenieCost + remontCost) * 0.3; // Ветеранам труда 30% скидка
            }

            // Расчет итоговой суммы
            double totalCost = otoplenieCost + waterCost + gasCost + remontCost - discount;

            Console.WriteLine("Вид платежа\t\tНачислено\tЛьготная скидка\tИтого");
            Console.WriteLine("Отопление\t\t" + otoplenieCost + "\t\t" + discount + "\t\t" + (otoplenieCost - discount));
            Console.WriteLine("Вода\t\t\t" + waterCost + "\t\t0\t\t" + waterCost);
            Console.WriteLine("Газ\t\t\t" + gasCost + "\t\t0\t\t" + gasCost);
            Console.WriteLine("Ремонт\t\t\t" + remontCost + "\t\t" + discount + "\t\t" + (remontCost - discount));
            Console.WriteLine("Итого\t\t\t\t\t" + totalCost);

            Console.WriteLine("Итоговая сумма коммунальных платежей: " + totalCost);
        }
    }
}
