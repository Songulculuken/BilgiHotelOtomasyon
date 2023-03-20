using System;
using System.Data.SqlClient;

namespace Bilgi_Hotel.Formlar
{
    internal class Baglanti
    {
        private string connectionString;

        public Baglanti(string connectionString)
        {
            this.connectionString = connectionString;
        }

        internal SqlDataReader SorguVeriOku(string v)
        {
            throw new NotImplementedException();
        }
    }
}