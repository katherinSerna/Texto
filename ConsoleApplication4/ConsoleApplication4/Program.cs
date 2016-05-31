using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1

{
    //Nombre de la alumna: Katherin Serna Meza
    //Materia: Programacion Orientada a Objetos
    //Unidad: 5 y 6

    class Product
    {

        public string Code;
        public string Description;
        public decimal Price;

        public Product(string c, string d, decimal p)
        {

            Code = c; Description = d; Price = p;
        }

        public override string ToString()
        {

            return String.Format("{0}-{1}-${2}", Code, Description, Price);
            //return base.ToString();
        }

    }


    class ProductDB
    {

        const string dir = @"C:\Users\Katherin\Desktop";
        
        const string path = dir + @"Products.txt";

        public static List<Product> GetProducts()
        {

            StreamReader textIn =

                    new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read));

            List<Product> products = new List<Product>();
            while (textIn.Peek() != -1)
            {

                string row = textIn.ReadLine();
                string[] columns = row.Split('|');
                products.Add(new Product(columns[0], columns[1], Convert.ToDecimal(columns[2])));

                // products.Add(new) Programita(columns[0],columns [1] , Convert.ToDecimal(columns[2])));

            }
            return products;
        }



        public static void SaveProducts(List<Product> products)
        {

            StreamWriter textOut =

                new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write));

            foreach (Product p in products)
            {


                textOut.Write(p.Code + "|");
                textOut.Write(p.Description + "|");
                textOut.WriteLine(p.Price);
            }

            textOut.Close();


        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            List<Product> P = new List<Product>();

            P.Add(new Product("AAA","XBOX ONE",6000.50m));
            P.Add(new Product("AAB","PS4", 7500.50m));
            P.Add(new Product("AAC", "WiiU", 5000.50m));

            ProductDB.SaveProducts(P);
            P = ProductDB.GetProducts();
            foreach (Product p in P)
                Console.WriteLine(p);

            Console.ReadKey();

        }
    }
}
