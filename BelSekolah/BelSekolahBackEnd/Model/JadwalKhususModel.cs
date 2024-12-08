using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelSekolah.BelSekolahBackEnd.Model
{
    public class JadwalKhususModel
    {
        public int JadwalKhususID { get; set; }
        public int HariID { get; set; }
        public string Waktu { get; set; }
        public string Keterangan { get; set; }
        public string SoundName { get; set; }
        public string SoundPath { get; set; }
        public int IsUjian { get; set; }
        public int RencanakanJadwalID { get; set; }
    }
}