using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCModel.Models
{
    public class Anggota
    {
        public int AnggotaId { get; set; }
        public string NamaAnggota { get; set; }
        public int Umur { get; set; }
        public string Alamat { get; set; }
        public string NoTelp { get; set; }
    }
}