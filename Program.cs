using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesFractions
{
    public class Fraction
    {   // attributs
        private int numerateur;
        private int denominateur;

        //Propriétés

        public int Numerateur
        {
            get
            {
                return numerateur;
            }

            set
            {
                numerateur = value;
            }
        }

        public int Denominateur
        {
            get
            {
                return denominateur;
            }

            set
            {
                denominateur = value;
            }
        }

        // Constructeur
        public Fraction(int _numerateur, int _denominateur)
        {
            try
            {
                this.numerateur = _numerateur;
                this.denominateur = _denominateur;
                double lafraction = (double)this.numerateur / this.Denominateur;
            }
            catch (ArithmeticException e)
            {
                Console.WriteLine("Division par zero impossible" + e.Message);

            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }


        }

        public Fraction(int _numerateur)
        {
            this.numerateur = _numerateur;
            this.denominateur = 1;
        }

        public Fraction()
        {
            this.numerateur = 0;
            this.denominateur = 1;
        }

        //Méthodes fraction

        public override string ToString()
        {
            string chaineFraction = "";
            if (this.Denominateur == 1)
            {
                chaineFraction += this.Numerateur;
            }

            else
            {

                if (this.denominateur < 0)
                {
                    if (this.numerateur > 0)
                    {
                        chaineFraction += (-this.numerateur) + "/" + (-this.denominateur);
                    }
                    else
                    {
                        chaineFraction += (-this.numerateur) + "/" + (-this.denominateur);

                    }


                }
                else
                {


                    chaineFraction += this.numerateur + "/" + this.denominateur;


                }

            }
            return chaineFraction;
        }



        public void inverse()
        {
            int temp = numerateur;
            numerateur = denominateur;
            denominateur = temp;
        }

        public void oppose()
        {
            Numerateur = (this.numerateur * (-1));
        }

        public bool SuperieurA(Fraction _autreFraction)
        {

            double temp1 = (double)Numerateur / Denominateur;
            double temp2 = (double)_autreFraction.Numerateur / _autreFraction.Denominateur;

            if (temp1 > temp2)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Fraction Somme(Fraction _autreFraction)
        {

            int num = (this.numerateur * _autreFraction.denominateur) + (_autreFraction.numerateur * this.denominateur);
            int denom = this.Denominateur * _autreFraction.Denominateur;

            Fraction Resultat = new Fraction(num, denom);
            Resultat.reduire();

            return Resultat;
        }

        private void reduire()
        {
            int diviseur = this.GetPGCD();
            this.Numerateur /= diviseur;
            this.Denominateur /= diviseur;

            if (this.numerateur < 0 && this.denominateur < 0)
            {
                this.Numerateur = -Numerateur;
                this.Denominateur = -Denominateur;

            }

            if (this.numerateur > 0 && this.denominateur < 0)
            {
                this.Numerateur = -Numerateur;
                this.Denominateur = -Denominateur;
            }

        }


        private int GetPGCD()
        {
            int a = this.numerateur;
            int b = this.denominateur;
            int pgcd = -1;
            if (a == 0) pgcd = b;
            else if (b == 0) pgcd = a;
            else
            {
                if (a < 0) a = -a;
                if (b < 0) b = -b;
                while (a != b)
                {
                    if (a < b)
                        b -= a;
                    else
                        a -= b;
                }
                pgcd = a;
            }
            return pgcd;
        }

    }



}