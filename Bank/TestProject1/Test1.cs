using classLib;

namespace classLibTests
{
    [TestClass]
    public class KontoTests
    {
        [TestMethod]
        public void TestKontoConstructor()
        {
            var konto = new Konto("Jan Kowalski", 1000);
            Assert.AreEqual("Jan Kowalski", konto.Klient);
            Assert.AreEqual(1000, konto.Bilans);
            Assert.IsFalse(konto.Zablokowane);
        }

        [TestMethod]
        public void TestKontoDefaultConstructor()
        {
            var konto = new Konto();
            Assert.AreEqual("", konto.Klient);
            Assert.AreEqual(0, konto.Bilans);
            Assert.IsFalse(konto.Zablokowane);
        }

        [TestMethod]
        public void TestWplata()
        {
            var konto = new Konto("Jan Kowalski", 1000);
            konto.Wplata(500);
            Assert.AreEqual(1500, konto.Bilans);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestWplataNegativeAmount()
        {
            var konto = new Konto("Jan Kowalski", 1000);
            konto.Wplata(-500);
        }

        [TestMethod]
        public void TestWyplata()
        {
            var konto = new Konto("Jan Kowalski", 1000);
            konto.Wyplata(500);
            Assert.AreEqual(500, konto.Bilans);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestWyplataMoreThanBalance()
        {
            var konto = new Konto("Jan Kowalski", 1000);
            konto.Wyplata(1500);
        }

        [TestMethod]
        public void TestZablokuj()
        {
            var konto = new Konto("Jan Kowalski", 1000);
            konto.Zablokuj();
            Assert.IsTrue(konto.Zablokowane);
        }

        [TestMethod]
        public void TestOdblokujKonto()
        {
            var konto = new Konto("Jan Kowalski", 1000);
            konto.Zablokuj();
            konto.odblokujKonto();
            Assert.IsFalse(konto.Zablokowane);
        }

        [TestMethod]
        public void TestToString()
        {
            var konto = new Konto("Jan Kowalski", 1000);
            var expected = "Nazwa: Jan Kowalski, Bilans: 1000, Status zablokowania: False";
            Assert.AreEqual(expected, konto.ToString());
        }
    }

    [TestClass]
    public class KontoPlusTests
    {
        [TestMethod]
        public void TestKontoPlusConstructor()
        {
            var konto = new KontoPlus("Jan Kowalski", 1000, 500);
            Assert.AreEqual("Jan Kowalski", konto.Klient);
            Assert.AreEqual(1000, konto.Bilans);
            Assert.AreEqual(500, konto.JednorazowyLimitDebetowy);
            Assert.IsFalse(konto.Zablokowane);
        }

        [TestMethod]
        public void TestKontoPlusDefaultConstructor()
        {
            var konto = new KontoPlus();
            Assert.AreEqual("", konto.Klient);
            Assert.AreEqual(0, konto.Bilans);
            Assert.AreEqual(0, konto.JednorazowyLimitDebetowy);
            Assert.IsFalse(konto.Zablokowane);
        }

        [TestMethod]
        public void TestKontoPlusWplata()
        {
            var konto = new KontoPlus("Jan Kowalski", 1000, 500);
            konto.Wplata(500);
            Assert.AreEqual(1500, konto.Bilans);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestKontoPlusWplataNegativeAmount()
        {
            var konto = new KontoPlus("Jan Kowalski", 1000, 500);
            konto.Wplata(-500);
        }

        [TestMethod]
        public void TestKontoPlusWyplata()
        {
            var konto = new KontoPlus("Jan Kowalski", 1000, 500);
            konto.Wyplata(1200);
            Assert.AreEqual(-200, konto.Bilans);
            Assert.IsTrue(konto.Zablokowane);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestKontoPlusWyplataMoreThanLimit()
        {
            var konto = new KontoPlus("Jan Kowalski", 1000, 500);
            konto.Wyplata(1600);
            Assert.IsTrue(konto.Zablokowane);
        }

        [TestMethod]
        public void TestKontoPlusToString()
        {
            var konto = new KontoPlus("Jan Kowalski", 1000, 500);
            var expected = "Nazwa: Jan Kowalski, Bilans: 1000, Status zablokowania: False, Maksymalny debet: 500";
            Assert.AreEqual(expected, konto.ToString());
        }
    }

    [TestClass]
    public class KontoLimitTests
    {
        [TestMethod]
        public void TestKontoLimitConstructor()
        {
            var konto = new KontoLimit("Jan Kowalski", 1000, 500);
            Assert.AreEqual("Jan Kowalski", konto.Klient);
            Assert.AreEqual(1000, konto.Bilans);
            Assert.AreEqual(500, konto.JednorazowyLimitDebetowy);
            Assert.IsFalse(konto.Zablokowane);
        }

        [TestMethod]
        public void TestKontoLimitDefaultConstructor()
        {
            var konto = new KontoLimit();
            Assert.AreEqual("", konto.Klient);
            Assert.AreEqual(0, konto.Bilans);
            Assert.AreEqual(0, konto.JednorazowyLimitDebetowy);
            Assert.IsFalse(konto.Zablokowane);
        }

        [TestMethod]
        public void TestKontoLimitWplata()
        {
            var konto = new KontoLimit("Jan Kowalski", 1000, 500);
            konto.Wplata(500);
            Assert.AreEqual(1500, konto.Bilans);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestKontoLimitWplataNegativeAmount()
        {
            var konto = new KontoLimit("Jan Kowalski", 1000, 500);
            konto.Wplata(-500);
        }

        [TestMethod]
        public void TestKontoLimitWyplata()
        {
            var konto = new KontoLimit("Jan Kowalski", 1000, 500);
            konto.Wyplata(1200);
            Assert.AreEqual(-200, konto.Bilans);
            Assert.IsTrue(konto.Zablokowane);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestKontoLimitWyplataMoreThanLimit()
        {
            var konto = new KontoLimit("Jan Kowalski", 1000, 500);
            konto.Wyplata(1600);
            Assert.IsTrue(konto.Zablokowane);
        }

        [TestMethod]
        public void TestKontoLimitToString()
        {
            var konto = new KontoLimit("Jan Kowalski", 1000, 500);
            var expected = "Nazwa: Jan Kowalski, Bilans: 1000, Status zablokowania: False, Maksymalny debet: 500";
            Assert.AreEqual(expected, konto.ToString());
        }
    }
}
