using System;

namespace OBLBog
{
    public class Bog
    {

        private string _titel;
        private string _forfatter;
        private int _sidetal;
        private string _isbn13;

        public string Titel
        {
            get { return _titel; }
            set
            {
                CheckTitel(value); _titel = value;
            }
        }

        public string Forfatteer
        {
            get { return _forfatter; }
            set { _forfatter = value; }
        }

        public int Sidetal
        {
            get { return _sidetal; }
            set
            {
                CheckSideTal(value); _sidetal = value;
            }
        }

        public string Isbn13
        {
            get { return _isbn13; }
            set
            {
                CheckIsbn13(value); _isbn13 = value;
            }
        }


        public Bog(string titel, string forfatter, int sidetal, string isbn13)
        {
            CheckTitel(titel);
            CheckSideTal(sidetal);
            CheckIsbn13(isbn13);
            _titel = titel;
            _forfatter = forfatter;
            _sidetal = sidetal;
            _isbn13 = isbn13;
        }


        private static void CheckTitel(string titel)
        {
            if (2 > titel.Length)
            {
                throw new ArgumentException("Titel is not long enough");
            }
        }

        private static void CheckSideTal(int sidetal)
        {
            if (sidetal < 10 || sidetal > 1000)
            {
                throw new ArgumentException("Sidetal is outside the limitation");
            }
        }

        private static void CheckIsbn13(string isbn13)
        {
            if (isbn13.Length != 13)
            {
                throw new ArgumentException("The number must be exactly 13 long");
            }
        }

    }
}
