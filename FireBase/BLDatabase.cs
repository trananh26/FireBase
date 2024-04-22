using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iTextSharp.text.pdf.events.IndexEvents;

namespace FireBase
{
    public class BLDatabase
    {
        DLDatabase oDL = new DLDatabase();
        public List<SensorData> GetHistory()
        {
            return oDL.GetHistory();
        }

        public SensorData GetCurentParameter()
        {
            List<SensorData> lst = new List<SensorData>();
            lst = oDL.GetHistory();
            return lst.First();
        }

        public List<SensorData> GetHistoryByWeek()
        {
            List<SensorData> lst = new List<SensorData>();
            lst = oDL.GetHistoryByWeek();
            return lst;
        }
    }
}
