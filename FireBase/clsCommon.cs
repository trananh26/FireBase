using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireBase
{
    public class clsCommon
    {
    }


    public class SensorData
    {
        [JsonProperty("epoch_time")]    //thời  gian cập nhật
        public long ID { get; set; }

        public string UpdateTime { get; set; }

        [JsonProperty("current")]   //Cường độ dòng điện A
        public string Current { get; set; }

        [JsonProperty("energy")]    // Điện năng tiêu thụ KWh
        public string Energy { get; set; }

        [JsonProperty("power")]    // Công suất tải W
        public string Power { get; set; }

        [JsonProperty("voltage")]    // Điện áp cấp
        public string Voltage { get; set; }

        [JsonProperty("frequency")]    // Tần số HZ
        public string Frequency { get; set; }

        [JsonProperty("pf")]    // Hệ số công suất
        public string PF { get; set; }
       
    }
}
