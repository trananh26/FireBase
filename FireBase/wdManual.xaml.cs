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
using System.Windows.Shapes;

namespace FireBase
{
    /// <summary>
    /// Interaction logic for wdManual.xaml
    /// </summary>
    public partial class wdManual : Window
    {
        public wdManual()
        {
            InitializeComponent();
        }
        BLDatabase oBL = new BLDatabase();


        private void btnOpenLamp_Click(object sender, RoutedEventArgs e)
        {
            Eqiupment _eq = new Eqiupment();
            _eq = oBL.GetEqiupmentstate();

            if (_eq.Lamp == 1)
            {
                //Tắt đi
                _eq.Lamp = 0;
                oBL.SetEqiupmentState(_eq);
                btnOpenLamp.Content = "Tắt đèn";
            }
            else
            {
                //Bật lên
                _eq.Lamp = 1;
                oBL.SetEqiupmentState(_eq);
                btnOpenLamp.Content = "Bật đèn";
            }
            MessageBox.Show(_eq.Lamp == 1 ? "Tắt bóng đèn thành công" : "Bật bóng đèn thành công");
        }

        private void btnOpenFan_Click(object sender, RoutedEventArgs e)
        {
            Eqiupment _eq = new Eqiupment();
            _eq = oBL.GetEqiupmentstate();

            if (_eq.Fan == 1)
            {
                //Tắt đi
                _eq.Fan = 0;
                oBL.SetEqiupmentState(_eq);
                btnOpenFan.Content = "Tắt quạt";
            }
            else
            {
                //Bật lên
                _eq.Fan = 1;
                oBL.SetEqiupmentState(_eq);
                btnOpenFan.Content = "Bật quạt";
            }
            MessageBox.Show(_eq.Fan == 1 ? "Tắt quạt thành công" : "Bật quạt thành công");
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetButtonStatus();
        }

        private void GetButtonStatus()
        {
            Eqiupment _eq = new Eqiupment();
            _eq = oBL.GetEqiupmentstate();

            if (_eq != null)
            {
                btnOpenAir.Content = _eq.Air == 0 ? "Tắt điều hòa" : "Bật điều hòa";
                btnOpenFan.Content = _eq.Fan == 0 ? "Tắt quạt" : "Bật quạt";
                btnOpenLamp.Content = _eq.Lamp == 0 ? "Tắt bóng đèn" : "Bật bóng đèn";
                btnOpenOther.Content = _eq.Other == 0 ? "Tắt nguồn khác" : "Mở nguồn khác";
            }
        }

        private void btnOpenAir_Click(object sender, RoutedEventArgs e)
        {
            Eqiupment _eq = new Eqiupment();
            _eq = oBL.GetEqiupmentstate();

            if (_eq.Air == 1)
            {
                //Tắt đi
                _eq.Air = 0;
                oBL.SetEqiupmentState(_eq);
                btnOpenAir.Content = "Tắt điều hòa";
            }
            else
            {
                //Bật lên
                _eq.Air = 1;
                oBL.SetEqiupmentState(_eq);
                btnOpenAir.Content = "Bật điều hòa";
            }

            MessageBox.Show(_eq.Air == 1 ? "Tắt điều hòa thành công" : "Bật điều hòa thành công");

        }

        private void btnOpenOther_Click(object sender, RoutedEventArgs e)
        {
            Eqiupment _eq = new Eqiupment();
            _eq = oBL.GetEqiupmentstate();

            if (_eq.Other == 1)
            {
                //Tắt đi
                _eq.Other = 0;
                oBL.SetEqiupmentState(_eq);
                btnOpenOther.Content = "Tắt nguồn khác";
            }
            else
            {
                //Bật lên
                _eq.Other = 1;
                oBL.SetEqiupmentState(_eq);
                btnOpenOther.Content = "Bật nguồn khác";
            }
            MessageBox.Show(_eq.Other == 1 ? "Tắt nguồn khác thành công" : "Mở nguồn khác thành công");
        }
    }
}
