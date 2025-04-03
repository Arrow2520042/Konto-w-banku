using classLib;

namespace TestProject1
{
    [TestClass]
    public sealed class Test1
    {
        #region testy dla konta basic
        [TestMethod]
        public void KonstruktorKonto_InicjalizujePoprawnie()
        {
            string expectedKlient = "Jan Kowalski";
            decimal expectedBilans = 1000;

            var konto = new Konto(expectedKlient, expectedBilans);

            Assert.AreEqual(expectedKlient, konto.Klient);
            Assert.AreEqual(expectedBilans, konto.Bilans);
            Assert.IsFalse(konto.Zablokowane);
        }

        [TestMethod]
        public void DomyslnyKonstruktorKonto_InicjalizujePoprawnie()
        {
            var konto = new Konto();

            Assert.AreEqual("", konto.Klient);
            Assert.AreEqual(0, konto.Bilans);
            Assert.IsFalse(konto.Zablokowane);
        }

        [TestMethod]
        public void Wplata_DodajeDoBilansu()
        {
            var konto = new Konto("Jan Kowalski", 1000);
            decimal wplata = 500;
            decimal expectedBilans = 1500;

            konto.Wplata(wplata);

            Assert.AreEqual(expectedBilans, konto.Bilans);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Wplata_RzucaWyjatek_GdyKwotaJestNieprawidlowa()
        {
            var konto = new Konto("Jan Kowalski", 1000);
            decimal wplata = -500;

            konto.Wplata(wplata);
        }

        [TestMethod]
        public void Wyplata_OdejmujeZBilansu()
        {
            var konto = new Konto("Jan Kowalski", 1000);
            decimal wyplata = 500;
            decimal expectedBilans = 500;

            konto.Wyplata(wyplata);

            Assert.AreEqual(expectedBilans, konto.Bilans);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Wyplata_RzucaWyjatek_GdyKwotaPrzekraczaBilans()
        {
            var konto = new Konto("Jan Kowalski", 1000);
            decimal wyplata = 1500;

            konto.Wyplata(wyplata);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Wyplata_RzucaWyjatek_GdyKwotaJestNieprawidlowa()
        {
            var konto = new Konto("Jan Kowalski", 1000);
            decimal wyplata = -500;

            konto.Wyplata(wyplata);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Wplata_RzucaWyjatek_GdyKontoJestZablokowane()
        {
            var konto = new Konto("Jan Kowalski", 1000);
            konto.zablokujKonto();
            decimal wplata = 500;

            konto.Wplata(wplata);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Wyplata_RzucaWyjatek_GdyKontoJestZablokowane()
        {
            var konto = new Konto("Jan Kowalski", 1000);
            konto.zablokujKonto();
            decimal wyplata = 500;

            konto.Wyplata(wyplata);
        }

        [TestMethod]
        public void ZablokujKonto_UstawiaZablokowaneNaTrue()
        {
            var konto = new Konto("Jan Kowalski", 1000);

            konto.zablokujKonto();

            Assert.IsTrue(konto.Zablokowane);
        }

        [TestMethod]
        public void OdblokujKonto_UstawiaZablokowaneNaFalse()
        {
            var konto = new Konto("Jan Kowalski", 1000);
            konto.zablokujKonto();

            konto.odblokujKonto();

            Assert.IsFalse(konto.Zablokowane);
        }

        [TestMethod]
        public void Zablokuj_UstawiaZablokowaneNaTrue()
        {
            var konto = new Konto("Jan Kowalski", 1000);

            konto.Zablokuj();

            Assert.IsTrue(konto.Zablokowane);
        }

        [TestMethod]
        public void ToString_ZwracaPoprawnyCiagZnakow()
        {
            var konto = new Konto("Jan Kowalski", 1000);
            string expectedString = "Nazwa: Jan Kowalski, Bilans: 1000, Status zablokowania: False";

            string result = konto.ToString();

            Assert.AreEqual(expectedString, result);
        }
        #endregion

        #region testy dla konta premium

    }
}