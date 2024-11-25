using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelSekolah.BelSekolahBackEnd.Model
{
    public class JadwalNormal
    {
        public int JadwalNormalID { get; set; }
        public int IsTrue { get; set; }
        public string Waktu { get; set; }
        public string Hari { get; set; }
        public string Keterangan { get; set; }
        public string SoundName { get; set; }
        public byte[] Sound { get; set; }
    }
}
