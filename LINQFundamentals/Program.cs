﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a list of vegetable products
            //GetVeggies();
            //XML Creation
            QueryXml();

            Console.ReadLine();
        }

        private static void QueryXml()
        {
         XDocument doc = new XDocument(
             new XElement("Processes",
                 from p in Process.GetProcesses()
                     orderby p.ProcessName ascending 
                     select new XElement("Process",
                         new XAttribute("Name", p.ProcessName),
                         new XAttribute("PID", p.Id))
                     ));
            IEnumerable<int> pids =
                from e in doc.Descendants("Process")
                where e.Attribute("Name").Value == "devenv"
                orderby (int) e.Attribute("PID") ascending
                select (int) e.Attribute("PID");

            foreach (var id in pids)
            {
                Console.WriteLine(id);
            }
        }

        private static void GetVeggies()
        {
            IEnumerable<VegetableFarm> vegetables = new List<VegetableFarm>()
            {
                new VegetableFarm {ID = 1, Name = "Mango", ExpiryDate = new DateTime(2016, 01, 05)},
                new VegetableFarm {ID = 2, Name = "Pinapple", ExpiryDate = new DateTime(2016, 01, 14)},
                new VegetableFarm {ID = 3, Name = "Orange", ExpiryDate = new DateTime(2016, 02, 01)},
                new VegetableFarm {ID = 4, Name = "Tomatoes", ExpiryDate = new DateTime(2015, 12, 29)},
                new VegetableFarm {ID = 5, Name = "Zuccini", ExpiryDate = new DateTime(2015, 12, 20)},
                new VegetableFarm {ID = 6, Name = "Okra", ExpiryDate = new DateTime(2016, 03, 03)}
            };

            //Query the List
            IEnumerable<VegetableFarm> query =
                from v in vegetables
                where v.ExpiryDate.Year < 2016
                orderby v.Name
                select v;

            //Get the Results after the query is defined
            foreach (VegetableFarm v in query)
            {
                Console.WriteLine(v.Name);
            }
        }
    }
}
