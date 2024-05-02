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

    public class Eqiupment
    {
        [JsonProperty("Air")]    //Điều hòa
        public int Air { get; set; }

        [JsonProperty("Fan")]    //Quạt
        public int Fan { get; set; }

        [JsonProperty("Lamp")]    //Bóng đèn
        public int Lamp { get; set; }

        [JsonProperty("Other")]    //Ổ kéo dài
        public int Other { get; set; }
      
    }

    public class CurrentParameter
    {

        [JsonProperty("CurrentEnergy")]    //Điện năng tiêu thụ
        public string CurrentEnergy { get; set; }

        [JsonProperty("CurrentPower")]    // Công suất tải W
        public string CurrentPower { get; set; }

        [JsonProperty("CurrentVoltage")]    // Điện áp cấp
        public string CurrentVoltage { get; set; }

        [JsonProperty("CrCurrent")]   //Cường độ dòng điện A
        public string CrCurrent { get; set; }
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

    public class SensorHistoryData
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
      

    }
}
