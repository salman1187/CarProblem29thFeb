using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //apr - sept
            //apr 30
            //may 31
            //jun 30
            //july 31
            //aug 31
            //sep 30
            Month30 april = new Month30 { Name = "april"};
            Month31 may = new Month31 { Name = "may" };
            Month30 june = new Month30{ Name = "june"};
            Month31 july = new Month31{ Name = "july"};
            Month31 august = new Month31{ Name = "august"};
            Month30 september = new Month30{ Name = "september"};
            List<Month> months = new List<Month> { april, may, june, july, august, september };
            int totalRetail = 0;
            int totalCorporate = 0;
            Console.WriteLine("No. of vehicles sold each month: ");
            foreach(Month m in months)
            {
                if(m is  Month30 m1)
                {
                    m1.Calculate();
                    Console.WriteLine($"{m1.Name} - {m1.VehiclesSold}");
                }
                else if(m is Month31 m2)
                {
                    m2.Calculate();
                    totalRetail += m2.RetailVehicles;
                    totalCorporate += m2.CorporateVehicles;
                    Console.WriteLine($"{m2.Name} - {m2.VehiclesSold}");
                }
            }

            Console.WriteLine("No. of vehicles sold to retail customers: " + totalRetail);
            Console.WriteLine("No. of vehicles sold to corporate customers: " + totalCorporate);
            august.Calculate();
            september.Calculate();
            Console.WriteLine($"No. of Vehicles sold from aug 15th to sept 15th: {(august.VehiclesSold - (september.VehiclesSold) / 2) + september.VehiclesSold/2}");

        }
    }
    public interface Month
    {
        string Name { get; set; }   
        int days { get; set; }
        int VehiclesSold { get; set; }
        int RetailVehicles {  get; set; }
        int CorporateVehicles { get; set; }

    }
    public class Month30 : Month
    {
        public string Name { get; set; }
        public int days { get; set; } = 30;
        public int VehiclesSold { get; set; }
        public int RetailVehicles { get; set; }
        public int CorporateVehicles { get; set; }
        public void Calculate()
        {
            int count = 2;
            VehiclesSold = 1;
            RetailVehicles = 1;
            CorporateVehicles = 0;  
            for(int i=2; i<=days;  i++)
            {
                VehiclesSold += count;
                if (i % 5 == 0)
                    CorporateVehicles += VehiclesSold;
                else
                    RetailVehicles += VehiclesSold;
                count = count + 2;
            }
        }
    }
    public class Month31 : Month
    {
        public string Name { get; set; }
        public int days { get; set; } = 31;
        public int VehiclesSold { get; set; }
        public int RetailVehicles { get; set; }
        public int CorporateVehicles { get; set; }
        public void Calculate()
        {
            int count = 2;
            VehiclesSold = 1;
            RetailVehicles = 1;
            CorporateVehicles = 0;
            for (int i = 2; i <= days; i++)
            {
                VehiclesSold += count;
                if (i % 5 == 0)
                    CorporateVehicles += VehiclesSold;
                else
                    RetailVehicles += VehiclesSold;
                count = count + 2;
            }
        }
    }

}
