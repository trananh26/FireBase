using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FireBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BLDatabase oBL = new BLDatabase();
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMinutes(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            DispatcherTimer timerX = new DispatcherTimer();
            timerX.Interval = TimeSpan.FromSeconds(1);
            timerX.Tick += TimerX_Tick; ;
            timerX.Start();
        }

        private void TimerX_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "     ";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            GetCurrentParam();
            GetParamForChart();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetCurrentParam();
            GetParamForChart();
        }

        private void GetParamForChart()
        {
            List<SensorData> lst = new List<SensorData>();
            lst = oBL.GetHistoryByWeek();

        }

        private void GetCurrentParam()
        {
            SensorData _ss = new SensorData();
            _ss = oBL.GetCurentParameter();

            lblVolt.Text = _ss.Voltage;
            lblAmpe.Text = _ss.Current;
            lblWoat.Text = _ss.Power;

            lblPf.Text = _ss.PF;


            //Lấy thông số ngày đầu của tháng
            SensorData _ss1 = new SensorData();
            _ss1 = oBL.GetHistoryOfFirstDay();
            if (_ss1 != null)
            {
                lblKWoatH.Text = (int.Parse(_ss1.Energy) - int.Parse(_ss.Energy)).ToString();
            }
            else
                lblKWoatH.Text = "0";

        }

        private void btnControl_Click(object sender, RoutedEventArgs e)
        {
            wdManual frm = new wdManual();
            frm.ShowDialog();
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            wdHistory frm = new wdHistory();
            frm.ShowDialog();
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
