using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MVCPerpustakaan.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Tanggal Order")]
        public DateTime OrderDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Tanggal Kembalian")]
        public DateTime? ReturnDate { get; set; }

        public string Username { get; set; }
        [Display(Name = "User")]
        public virtual User User { get; set; }

        [Display(Name = "Status Order")]
        public bool Closed { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }

    public class OrderDetail
    {
        public int ID { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int BukuId { get; set; }
        public virtual Buku Buku { get; set; }
    }
}