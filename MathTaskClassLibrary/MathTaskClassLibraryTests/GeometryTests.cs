using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathTaskClassLibrary;
using System;

//Перед созданием обятаельно сверь чтобы Целевые Платформы  были одинковые тут Net Core 4.7

namespace MathTaskClassLibraryTests
{
    [TestClass]
    public class GeometryTests
    {
        [TestMethod] //Обязательно писать перед написаниями функции
        public void CalculateAreaTest()
        {
            // Создаем переменные для последующего сравнения (Вместе с сразу прописанным результатом)
            int a = 5;
            int b = 3;
            int expected = 15;

            Geometry g = new Geometry(); //Тут мы просто  создаем обьект класса(в данном случае мы будем теперь обращться к Geometry как g)
            int actual = g.CalculateArea(a, b); //Создаем переменную в которую записываем результат нашей функции

            Assert.AreEqual(expected, actual); //Тут мы сравниваем (1 аргмент - сколько у насБ 2 по факту из функции)
        }

        [TestMethod]

        public void CalculateAreaInvalidDataTest1() //Тут практически тоже самое, только мы ьберем блоки трай кетч то есть если у нас возникнет исключение то выбьет ошибку(Безопасно)
        {
            bool catched = false;
            try
            {
                int a = -5;
                int b = 3;

                Geometry g = new Geometry();
                g.CalculateArea(a, b);
            }
            catch(ArgumentException e)
            {
                catched = true;
            }
            Assert.IsTrue(catched, "Не обработанны исключения!");//Тут эта функция ожидает провала функции, и если тест по коду провалился, то тест выполнен
        }

        [TestMethod]
        public void CalculateAreaInvalidDataTest2() //Ну а тут мы уже просто вызываем исключения из Assert, тут лучше прочто запомнить ка кэто делается
        {
            int a = -4;
            int b = 10;

            Geometry g = new Geometry();
            Assert.ThrowsException<ArgumentException>(() => g.CalculateArea(a, b)); //Тут так же как и во 2
        }
    }

    [TestClass]
    public class AlphabetTest
    {
        [TestMethod]

        public void AplhTesting() //Тут простое сравнение(a - 5 И expexted - 5 букв)
        {
            int a = 5;
            string expected = "ABCDE";

            Geometry g = new Geometry();
            string actual = g.GenerateAlphabetString(a); //Переходим в функцию

            Assert.AreEqual(expected, actual);//Сравниваем
        }
    }

    [TestClass]
    public class DiscTest
    {
        [TestMethod]

        public void CalculateDisk() //Тут высчитываем дискриминант и если a < 0 то тогда фунция вызовет ArgumentException, что правильно!
        {
            bool catched = false;
            try
            {
                double a = -1;
                double b = 0;
                double c = 4;

                Geometry g = new Geometry();
                g.SolveQuadraticEquation(a, b, c);
            }
            catch (ArgumentException e)
            {
                catched = true;
            }
            Assert.IsTrue(catched, "Не обработанны исключения!");
        }
    }


    [TestClass]
    public class YearTest
    {
        [TestMethod]

        public void CalculateYear()//Там функция проверяет, весокосный ли год
        {
            int a = -1;

            Geometry g = new Geometry();
            Assert.ThrowsException<ArgumentException>(() => g.GetDaysInYear(a)); //Тут функция завершит свое исполнение если год < 0, как и в данном случае (он ждет ThrowsException<ArgumentException>), то есть если бы было любое другое, то был бы провал
        }
    }

    [TestClass]
    public class EmailTest
    {
        [TestMethod]

        public void CheckEmail() //Тут так же банальное сравнение результата который думаешь ты - bool res = true; и как по факту - bool actual
        {
            bool res = true;
            string expected = "test@test.test";

            Geometry g = new Geometry();
            bool actual = g.ValidateEmail(expected);
            Assert.AreEqual(res, actual);
        }
    }

    [TestClass]
    public class StringTest //Тут тоже самое что и с прошлым, только тут высчитывают сумму
    {
        [TestMethod]

        public void CalculateNum()
        {
            string str = "12345";
            int result = 15;

            Geometry g = new Geometry();
            int res = g.CalculateDigitSum(str);
            Assert.AreEqual(result, res);
        }
    }
}
