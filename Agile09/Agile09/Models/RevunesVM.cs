using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Agile09.Models
{
    public class RevunesVM
    {
        [DataType(DataType.Date)]
        public DateTime Ngay { get; set; }
        public decimal TongGiaBan { get; set; }
        public decimal DoanhThu { get; set; }
    }
}