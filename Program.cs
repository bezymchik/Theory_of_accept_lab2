using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static string big_zavod = File.ReadAllText(@"D:\ЛП\4 курс 1 семестр\Теорія прийняття рішень\ЛР 2\ConsoleApp1\big_zavod.txt");
        static string small_zavod = File.ReadAllText(@"D:\ЛП\4 курс 1 семестр\Теорія прийняття рішень\ЛР 2\ConsoleApp1\small_zavod.txt");

        static IEnumerable<double> big_zavod_array = big_zavod
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(n => double.Parse(n));

        static IEnumerable<double> small_zavod_array = small_zavod
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => double.Parse(n));

        static void Main(string[] args)
        {
            double[] big_zavod_int = big_zavod_array.ToArray();
            double[] small_zavod_int = small_zavod_array.ToArray();    

            double[] result = Calculate(big_zavod_int, small_zavod_int);
            Console.Write($"EMV(A) = {result[0]}, EMV(B) = {result[1]}, EMV(D) = {result[3]}, EMV(E) = {result[4]}, EMV(2) = {result[6]}, EMV(C) = {result[2]}, EMV(1) = {result[5]}");
            Console.WriteLine();
        }

        static double[] Calculate(double[] big, double[] small)
        {
            double emv_A; double emv_B; double emv_C; double emv_D; double emv_E; double emv_first; double emv_second;

            double cost = big[0]; double income = big[1]; double probablity_income = 0.75; double losses = big[2]; double probablity_losses = 0.25;

            emv_A = probablity_income * (income * 5) + probablity_losses * (losses * 5) - cost;

            cost = small[0]; income = small[1]; losses = small[2];

            emv_B = probablity_income * (income * 5) + probablity_losses * (losses * 5) - cost;

            probablity_income = 0.9; probablity_losses = 0.1;  cost = big[0];  income = big[1];  losses = big[2];

            emv_D = probablity_income * (income * 4) + probablity_losses * (losses * 4) - cost;

            cost = small[0]; income = small[1]; losses = small[2];

            emv_E = probablity_income * (income * 4) + probablity_losses * (losses * 4) - cost;

            emv_second = Math.Max(emv_D, emv_E);

            probablity_income = 0.75; probablity_losses = 0.25;

            emv_C = probablity_income * emv_second + probablity_losses * 0;

            emv_first = Math.Max(emv_A, Math.Max(emv_B, emv_C));

            return new double[] { emv_A, emv_B, emv_C, emv_D, emv_E, emv_first, emv_second};
        }
    }
}
