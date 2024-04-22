using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;

namespace FireBase
{
    public class DLDatabase
    {
        IFirebaseClient client;


        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "AIzaSyC3rb4MPxeRtIxxPfHhDTXyrG7oFJ_NQcM",
            BasePath = "https://test-18e04-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };

        public List<SensorData> GetHistory()
        {
            List<SensorData> lst = new List<SensorData>();
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                var Result = client.Get("/Data/OrNmw6pZrzVw0f7tr6MCqpznAWH3/Pzem004TReadings");
                Dictionary<string, SensorData> sensorDataDict = JsonConvert.DeserializeObject<Dictionary<string, SensorData>>(Result.Body.ToString());

                if (sensorDataDict != null)
                {
                    foreach (var entry in sensorDataDict)
                    {
                        if (entry.Value.Current != "nan")
                        {
                            DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(entry.Value.ID).UtcDateTime;

                            SensorData _ss = new SensorData();
                            _ss.ID = entry.Value.ID;
                            _ss.UpdateTime = dateTime.AddHours(7).ToString("yyyy-MM-dd HH:mm:ss");
                            _ss.Current = entry.Value.Current;
                            _ss.Voltage = entry.Value.Voltage;
                            _ss.Frequency = entry.Value.Frequency;

                            _ss.Power = entry.Value.Power;
                            _ss.Energy = entry.Value.Energy;
                            _ss.PF = entry.Value.PF;

                            lst.Add(_ss);
                        }

                    }
                    lst = lst.OrderByDescending(s => s.ID).ToList();
                }
            }

            return lst;
        }

        public List<SensorData> GetHistoryByWeek()
        {
            List<SensorData> lst = new List<SensorData>();
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                var Result = client.Get("/Data/OrNmw6pZrzVw0f7tr6MCqpznAWH3/Pzem004TReadings");
                Dictionary<string, SensorData> sensorDataDict = JsonConvert.DeserializeObject<Dictionary<string, SensorData>>(Result.Body.ToString());

                if (sensorDataDict != null)
                {
                    foreach (var entry in sensorDataDict)
                    {
                        if (entry.Value.Current != "nan")
                        {
                            DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(entry.Value.ID).UtcDateTime;
                            ///Lấy lịch sử 7 giờ gần nhất trong ngày
                            if ((dateTime.Hour + 7) <= DateTime.Now.Hour && (dateTime.Hour + 7) >= DateTime.Now.Hour - 6 && dateTime.Date == DateTime.Now.Date)
                            {
                                SensorData _ss = new SensorData();
                                _ss.ID = entry.Value.ID;
                                _ss.UpdateTime = dateTime.AddHours(7).ToString("yyyy-MM-dd HH:mm:ss");
                                _ss.Current = entry.Value.Current;
                                _ss.Voltage = entry.Value.Voltage;
                                _ss.Frequency = entry.Value.Frequency;

                                _ss.Power = entry.Value.Power;
                                _ss.Energy = entry.Value.Energy;
                                _ss.PF = entry.Value.PF;

                                lst.Add(_ss);
                            }
                        }
                    }
                }
            }
            return lst;
        }
    }
}
