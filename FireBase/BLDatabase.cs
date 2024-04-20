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
            return oDL.GetDataTable();
        }
    }
}
