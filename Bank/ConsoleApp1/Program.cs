using classLib;

var konto1 = new Konto("Jan Kowalski", 1000);
konto1.zablokujKonto();
Console.WriteLine(konto1.ToString());