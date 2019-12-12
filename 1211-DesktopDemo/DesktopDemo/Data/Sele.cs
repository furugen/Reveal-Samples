using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDemo.Data
{
    public class Sele
    {
        public Sele(
            string EntryDate,
            string Productname,
            decimal Price,
            string NewOrRenew,
            string CustomerKind,
            string CustomerName,
            string Adress,
            int NumberOfSeles,
            decimal Proceeds,
            string SaleDate,
            string ViaBuyMethod,
            string Status,
            string Seler
            )
        {
            this.EntryDate = DateTime.Parse(EntryDate);
            this.Productname = Productname;
            this.Price = Price;
            this.NewOrRenew = NewOrRenew;
            this.CustomerKind = CustomerKind;
            this.CustomerName = CustomerName;
            this.Adress = Adress;
            this.NumberOfSeles = NumberOfSeles;
            this.Proceeds = Proceeds;
            this.ViaBuyMethod = ViaBuyMethod;
            this.SaleDate = DateTime.Parse(SaleDate);
            this.Status = Status;
            this.Seler = Seler;
        }

        public DateTime EntryDate { get; set; }
        public string Productname { get; set; }
        public decimal Price { get; set; }
        public string NewOrRenew { get; set; }
        public string CustomerKind { get; set; }
        public string CustomerName { get; set; }
        public string Adress { get; set; }
        public int NumberOfSeles { get; set; }
        public decimal Proceeds { get; set; }
        public DateTime SaleDate { get; set; }
        public string ViaBuyMethod { get; set; }
        public string Status { get; set; }
        public string Seler { get; set; }
    }
}
