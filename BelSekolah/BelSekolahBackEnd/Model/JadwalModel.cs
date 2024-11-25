using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelSekolah.BelSekolahBackEnd.Model
{
    public class JadwalModel
    {
        public int HariID { get; set; }
        public string JenisJadwal { get; set; }
        public string Hari { get; set; }
        public string Waktu { get; set; }
        public string Keterangan { get; set; }
        public string SoundName { get; set; }
        public string SoundPath { get; set; }


        public List<JadwalModel> JadwalNormal { get; set; } = new List<JadwalModel>();
        public List<JadwalModel> JadwalKhusus { get; set; } = new List<JadwalModel>();
    }

}
