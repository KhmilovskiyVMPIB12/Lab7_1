using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MathTaskClassLibrary
{
    public class Geometry
    {
        public int CalculateArea(int a,int b) //Тут просто если числа меньше 0, то бросаем исключение, в противном случае, все отлично!
        {
            if (a < 0 || b < 0) throw new ArgumentException();
            return a * b;
        }

        public string GenerateAlphabetString(int N) //Тут промежуток выводимых чисел, сколько введешь, столько и выведется
        {
            if (N < 1 || N > 26)
            {
                throw new ArgumentException("Вводное значение должно быть между 1 и 26"); //Как раз тут бросаем исклчение, если условие не верно!
            }

            char startChar = 'A'; //С какой буквы начинаем
            char endChar = (char)(startChar + N - 1); //Тут на какой заканчиваем

            string alphabetString = string.Empty;
            for (char c = startChar; c <= endChar; c++) //Тут обычный перебор и добавление по букве
            {
                alphabetString += c; 
            }

            return alphabetString;//тут возвращаем занчение
        }

        public double[] SolveQuadraticEquation(double a, double b, double c)
        {
            if (a < 0) throw new ArgumentException(); //Тут так же бросаем исключение если a < 0

            double discriminant = b * b - 4 * a * c; //Высичтываем дискриминант

            if (Math.Abs(discriminant) < 1e-10) //Тут возвращаем занчение которое в любом случае будет больше 0 (Math.Abs) и проверяем больше ли оно 0
            {
                double root = -b / (2 * a);
                return new double[] { root };//Ну а тут если у нас один корень, то возвращаем новый массив с 1 корнем
            }
            else if (discriminant > 0)
            {
                double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);//тут то же самое что и там, Но тут 2 корня возведенные в квадрат (Math.Sqrt)
                double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                return new double[] { root1, root2 };//Возврашем наши 2 корня записанные в массив
            }
            else
            {
                return new double[0];//Ну а если корень меньше 0, то возвращем 0, что приводит к завершению функции
            }
        }

        public int GetDaysInYear(int year)
        {
            if (year <= 0)
            {
                throw new ArgumentException("Год должен буть больше 0!");//Если год меньше 0 то бросаем исключение
            }

            if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0) //Тут простые вычисления
            {
                return 366; //если правда, то возвращем что это - Весокосный год
            }
            else
            {
                return 365; //а если нет, то обычный год!
            }
        }

        public bool ValidateEmail(string email) // Тут принимаем Email,в стрингах
        {
            string pattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";//Ну тут я прям так не обьясню, тут нужно понимание
            return Regex.IsMatch(email, pattern);//Тут сравниваем введенное значение с тес то должно получиться
        }

        public int CalculateDigitSum(string numberString)//Тут просто принимаем  числа в троке
        {
            int sum = 0;
            foreach (char digitChar in numberString) //Перебираем их в чаре
            {
                if (char.IsDigit(digitChar)) //Ну а тут проверка на то что это число(Функция - IsDigit)
                {
                    int digit = int.Parse(digitChar.ToString()); //Приводим к Строке и пытаемся конвертировать в инт
                    sum += digit; //Складываем все полученные числа
                }
            }
            return sum; //Ну и возвращем по типу функции int - целое число
        }
    }
}
