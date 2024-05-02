using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using FireSharp;
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
            try
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
                                dateTime = dateTime.AddHours(7);
                                SensorData _ss = new SensorData();
                                _ss.ID = entry.Value.ID;
                                _ss.UpdateTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
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
            catch (Exception)
            {
                return null;
            }
        }

        public List<SensorData> GetHistoryByWeek()
        {
            try
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
                                dateTime = dateTime.AddHours(7);

                                ///Lấy lịch sử 7 ngày gần nhất
                                if (dateTime.Day <= DateTime.Now.Day && dateTime.Day >= (DateTime.Now.Day - 7) && dateTime.Date == DateTime.Now.Date)
                                {
                                    SensorData _ss = new SensorData();
                                    _ss.ID = entry.Value.ID;
                                    _ss.UpdateTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
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
                lst = lst.OrderBy(s => s.ID).ToList();
                return lst;
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>
        /// Kéo trạng thái thiết bị trên firebase về
        /// </summary>
        /// <returns></returns>
        public Eqiupment GetEqiupmentstate()
        {
            Eqiupment eqiupment = new Eqiupment();
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                var Result = client.Get("/Control");
                Dictionary<string, string> State = JsonConvert.DeserializeObject<Dictionary<string, string>>(Result.Body.ToString());
                if (State != null)
                {
                    foreach (var key in State)
                    {
                        if (key.Key == "Air")
                            eqiupment.Air = key.Value;

                        if (key.Key == "Fan")
                            eqiupment.Fan = key.Value;

                        if (key.Key == "Lamp")
                            eqiupment.Lamp = key.Value;

                        if (key.Key == "Other")
                            eqiupment.Other = key.Value;

                        if (key.Key == "CurrentEnergy")
                            eqiupment.CurrentEnergy = key.Value;
                    }
                }
            }
            return eqiupment;
        }

        /// <summary>
        /// Đẩy yêu cầu cập nhật trạng thái lên firebase
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public async void SetEqiupmentState(Eqiupment eqiupment)
        {
            FirebaseResponse response = await client.UpdateTaskAsync("Control", eqiupment);

        }

        /// <summary>
        /// Lấy ịch sử ngày đầu tiên của tháng
        /// </summary>
        /// <returns></returns>
        public SensorData GetHistoryOfFirstDay()
        {
            try
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
                                dateTime = dateTime.AddHours(7);
                                ///Lấy lịch sử tháng
                                if (dateTime.Month == DateTime.Now.Month)
                                {
                                    SensorData _ss = new SensorData();
                                    _ss.ID = entry.Value.ID;
                                    _ss.UpdateTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
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
                lst = lst.OrderBy(s => s.ID).ToList();
                return lst.First();

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
