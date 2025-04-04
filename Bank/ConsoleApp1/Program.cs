using System;
using classLib;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            #region konto basic symulacja
            var kontoBasic = new Konto("Jan Kowalski", 1000);
            Console.WriteLine(kontoBasic.ToString());
            try
            {
                kontoBasic.Wplata(500);
                Console.WriteLine(kontoBasic.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                kontoBasic.Wyplata(200);
                Console.WriteLine(kontoBasic.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                kontoBasic.Wyplata(2000);
                Console.WriteLine(kontoBasic.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(kontoBasic.ToString());
            kontoBasic.odblokujKonto();
            Console.WriteLine(kontoBasic.ToString());
            kontoBasic.zablokujKonto();
            Console.WriteLine(kontoBasic.ToString());
            #endregion
            //-------------------------------------------------
            #region kontoPlus symulacja
            var kontoPlus = new KontoPlus("Adam Adamski", 1000, 500);
            Console.WriteLine(kontoPlus.ToString());
            try
            {
                kontoPlus.Wplata(500);
                Console.WriteLine(kontoPlus.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                kontoPlus.Wyplata(200);
                Console.WriteLine(kontoPlus.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                kontoPlus.Wyplata(1500);
                Console.WriteLine(kontoPlus.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                kontoPlus.Wplata(300);
                Console.WriteLine(kontoPlus.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                kontoPlus.Wyplata(200000000000000000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(kontoPlus.ToString());
            #endregion
            //-------------------------------------------------
            #region kontoLimit symulacja
            var kontoLimit = new KontoLimit("Ewa Nowak", 1000, 500);
            Console.WriteLine(kontoLimit.ToString());
            try
            {
                kontoLimit.Wplata(500);
                Console.WriteLine(kontoLimit.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                kontoLimit.Wyplata(200);
                Console.WriteLine(kontoLimit.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                kontoLimit.Wyplata(1500);
                Console.WriteLine(kontoLimit.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                kontoLimit.Wplata(300);
                Console.WriteLine(kontoLimit.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                kontoLimit.Wyplata(200000000000000000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(kontoLimit.ToString());
            #endregion
        }
    }
}

