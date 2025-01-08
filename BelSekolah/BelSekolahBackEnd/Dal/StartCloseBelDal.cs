using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelSekolah.BelSekolahBackEnd.Model;
using BelSekolah.BelSekolahDatabase.Helper;
using Dapper;

namespace BelSekolah.BelSekolahBackEnd.Dal
{
    public class StartCloseBelDal
    {

        public void UpdateStartCloseBel(string start, string stop)
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = @"
                                    UPDATE  StartStopBel 
                                    SET 
                                    WaktuStartBel = @WaktuStartBel,
                                    WaktuStopBel = @WaktuStopBel";

                Conn.Execute(sql, new { WaktuStartBel = start, WaktuStopBel = stop });
            }
        }


        public StartStopBelModel? GetData()
        {
            using (var Conn = new SQLiteConnection(ConnStringHelper.GetConn()))
            {
                Conn.Open();

                const string sql = @"SELECT * FROM StartStopBel";

                return Conn.QueryFirstOrDefault<StartStopBelModel>(sql);
            }
        }
    }
}
