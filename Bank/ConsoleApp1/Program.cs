using System;
using classLib;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
         
            Konto konto = new Konto("Jan Kowalski", 1000);
            Console.WriteLine(konto.ToString());

         
            try
            {
                konto.Wplata(500);
                Console.WriteLine(konto.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
            try
            {
                konto.Wyplata(300);
                Console.WriteLine(konto.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

         
            konto.Zablokuj();
            Console.WriteLine(konto.ToString());

            try
            {
                konto.Wplata(200);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

       
            konto.odblokujKonto();
            Console.WriteLine(konto.ToString());

            
            KontoPlus kontoPlus = new KontoPlus("Anna Nowak", 500, 1000);
            Console.WriteLine(kontoPlus.ToString());

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
                kontoPlus.Wyplata(100);
                Console.WriteLine(kontoPlus.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Próba wypłaty przekraczającej limit debetowy (powinna rzucić wyjątek)
            try
            {
                kontoPlus.Wyplata(444000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            
        }
    }
}

