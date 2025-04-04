using System.Security.Cryptography.X509Certificates;

namespace classLib
{
    public class Konto
    {
        protected string klient;  
        protected decimal bilans;  
        protected bool zablokowane = false; 

        public Konto(string klient, decimal bilansNaStart = 0)
        {
            this.klient = klient;
            this.bilans = bilansNaStart;
        }

        public Konto()
        {
            klient = "";
            bilans = 0;
        }

        public string Klient => klient; 
        public decimal Bilans => bilans; 
        public bool Zablokowane => zablokowane; 

        public void Zablokuj()
        {
            zablokowane = true;
        }

        public virtual void Wplata(decimal wplata)
        {
           
            if (wplata <= 0)
            {
            throw new ArgumentOutOfRangeException("Kwota musi być większa od 0.");
            }
            bilans += wplata;
            Console.WriteLine($"Wpłacono {wplata}, nowy bilans: {bilans} zł.");
            odblokujKonto();

        }

        public virtual void Wyplata(decimal wyplata)
        {
            if (!zablokowane)
            {
                if (wyplata <= 0)
                {
                    throw new ArgumentOutOfRangeException("Kwota musi być większa od 0.");
                }
                if (wyplata > bilans)
                {
                    zablokujKonto();
                    throw new ArgumentOutOfRangeException("Nie można wypłacić więcej niż dostępny bilans. Konto zablokowane");
                }
                bilans -= wyplata;
                Console.WriteLine($"Wypłacono {wyplata}, nowy bilans: {bilans}");
            }
            else
            {
                throw new Exception("Konto jest zablokowane.");
            }
          

        }

        public void zablokujKonto()
        {
            zablokowane = true;
        }

        public void odblokujKonto()
        {
            zablokowane = false;
        }

        public override string ToString()
        {
            return $"Nazwa: {klient}, Bilans: {bilans}, Status zablokowania: {zablokowane}";
        }
    }

    public class KontoPlus : Konto
    {
        private decimal jednorazowyLimitDebetowy;
        private bool debetWykorzystany = false;

        public KontoPlus(string klient, decimal bilansNaStart, decimal limitDebetowy) : base(klient, bilansNaStart)
        {
            jednorazowyLimitDebetowy = limitDebetowy;
        }

        public KontoPlus() : base()
        {
            jednorazowyLimitDebetowy = 0;
        }

        public decimal JednorazowyLimitDebetowy
        {
            get => jednorazowyLimitDebetowy;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Limit debetowy musi być większy lub równy 0.");
                }
                jednorazowyLimitDebetowy = value;
            }
        }

        public override void Wplata(decimal wplata)
        {
            base.Wplata(wplata);
            if (Bilans > 0)
            {
                debetWykorzystany = false;
            }
        }

        public override void Wyplata(decimal wyplata)
        {

            if (wyplata <= Bilans)
            {
                base.Wyplata(wyplata);
            }

            if (Zablokowane)
            {
                throw new Exception("Konto jest zablokowane.");
            }

            if (wyplata <= 0)
            {
                throw new ArgumentOutOfRangeException("Kwota musi być większa od 0.");
            }

            if (wyplata > Bilans)
            {
                if (debetWykorzystany == false)
                {
                    if (wyplata <= Bilans + JednorazowyLimitDebetowy)
                    {
                        bilans -= wyplata;
                        debetWykorzystany = true;
                        Zablokuj();
                    }
                    else
                    {
                        zablokujKonto();
                        throw new ArgumentOutOfRangeException("Nie można wypłacić więcej niż dostępny bilans z limitem debetowym.");
                    }
                }
            }
        }
        public override string ToString()
        {
            return $"Nazwa: {klient}, Bilans: {bilans}, Status zablokowania: {zablokowane}, Maksymalny debet: {jednorazowyLimitDebetowy}";
        }

    }

    public class KontoLimit
    {
        private KontoPlus kontoPlus;

        public KontoLimit(string klient, decimal bilansNaStart, decimal limitDebetowy)
        {
            kontoPlus = new KontoPlus(klient, bilansNaStart, limitDebetowy);
        }

        public KontoLimit()
        {
            kontoPlus = new KontoPlus();
        }

        public string Klient => kontoPlus.Klient;
        public decimal Bilans => kontoPlus.Bilans;
        public bool Zablokowane => kontoPlus.Zablokowane;
        public decimal JednorazowyLimitDebetowy
        {
            get => kontoPlus.JednorazowyLimitDebetowy;
            set => kontoPlus.JednorazowyLimitDebetowy = value;
        }

        public void Zablokuj()
        {
            kontoPlus.Zablokuj();
        }

        public void Wplata(decimal wplata)
        {
            kontoPlus.Wplata(wplata);
        }

        public void Wyplata(decimal wyplata)
        {
            kontoPlus.Wyplata(wyplata);
        }
        public override string ToString()
        {
            return kontoPlus.ToString();
        }
    }


}
