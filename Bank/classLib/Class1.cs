using System.Security.Cryptography.X509Certificates;

namespace classLib
{
    public class Konto
    {
        private string klient;  //nazwa klienta
        private decimal bilans;  //aktualny stan środków na koncie
        private bool zablokowane = false; //stan konta

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

        public string Klient => klient; //nazwa klienta
        public virtual decimal Bilans => bilans; //aktualny stan środków na koncie
        public bool Zablokowane => zablokowane; //stan konta

        public void Zablokuj()
        {
            zablokowane = true;
        }

        public void Wplata(decimal wplata)
        {
            if (!zablokowane)
            {
                if (wplata <= 0)
                {
                    throw new ArgumentOutOfRangeException("Kwota musi być większa od 0.");
                }
                bilans += wplata;
                Console.WriteLine($"Wpłacono {wplata} zł. Nowy bilans: {bilans} zł.");
            }
            else
            {
                throw new Exception("Konto jest zablokowane.");
            }
        }

        public void Wyplata(decimal wyplata)
        {
            if (!zablokowane)
            {
                if (wyplata <= 0)
                {
                    throw new ArgumentOutOfRangeException("Kwota musi być większa od 0.");
                }
                if (wyplata > bilans)
                {
                    throw new ArgumentOutOfRangeException("Nie można wypłacić więcej niż dostępny bilans.");
                }
                bilans -= wyplata;
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

        public override decimal Bilans => base.Bilans + (debetWykorzystany ? 0 : jednorazowyLimitDebetowy);

        public new void Wplata(decimal wplata)
        {
            if (Zablokowane && base.Bilans + wplata < 0)
            {
                throw new Exception("Konto jest zablokowane.");
            }

            base.Wplata(wplata);
            if (base.Bilans >= 0)
            {
                debetWykorzystany = false;
                odblokujKonto();
            }
        }

        public new void Wyplata(decimal wyplata)
        {
            if (Zablokowane)
            {
                throw new Exception("Konto jest zablokowane.");
            }

            if (wyplata <= 0)
            {
                throw new ArgumentOutOfRangeException("Kwota musi być większa od 0.");
            }

            if (wyplata > base.Bilans + jednorazowyLimitDebetowy)
            {
                throw new ArgumentOutOfRangeException("Nie można wypłacić więcej niż dostępny bilans z limitem debetowym.");
            }

            if (wyplata > base.Bilans)
            {
               
                debetWykorzystany = true;
                Zablokuj();
            }

            base.Wyplata(wyplata);
        }


    }



}
