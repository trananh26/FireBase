using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireBase
{
    public class BLDatabase
    {
        DLDatabase oDL= new DLDatabase();
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

        public Eqiupment GetEqiupmentstate()
        {
            return oDL.GetEqiupmentstate();
        }

        /// <summary>
        /// Set lại trạng thái output
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        public void SetEqiupmentState(Eqiupment eqiupment)
        {

            oDL.SetEqiupmentState(eqiupment);
        }

        public SensorData GetHistoryOfFirstDay()
        {
            return oDL.GetHistoryOfFirstDay();
        }
    }
}
