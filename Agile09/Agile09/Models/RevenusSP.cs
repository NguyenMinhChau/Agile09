using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agile09.Models
{
    public class RevenusSP
    {
        public DateTime Ngay { get; set; }
        public decimal TongGiaBan { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}