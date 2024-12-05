using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelSekolah.BelSekolahBackEnd.Model
{
    public class RencanakanJadwalModel
    {
        public int RencanakanJadwalID { get; set; }
        public int HariID { get; set; }
        public string Tanggal { get; set; }
        public string Keterangan { get; set; }
    }
}
