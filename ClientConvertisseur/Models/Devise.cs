using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseur.Models
{
    public class Devise
    {
        private int id;
        private string? nomDevise;
        private double taux;
        public Devise()
        {

        }
        public Devise(int Id, string? NomDevise, double Taux)
        {
            this.id = Id;
            this.nomDevise = NomDevise;
            this.taux = Taux;
        }

        public double Taux
        {
            get { return taux; }
            set { taux = value; }
        }

        public string? NomDevise
        {
            get { return nomDevise; }
            set { nomDevise = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
