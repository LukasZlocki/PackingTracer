using PackingTracer.Data.HourlyTarget;
using PackingTracer.Service.Services;
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

namespace PackingTracer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DayPicture DayPic = new DayPicture();

        public MainWindow()
        {
            InitializeComponent();

            // loading data with hourly output.
            DayPic = LoadDataFromDataBase();

            // refresh screen with data
            ScreenDataRefresh(DayPic);


        }

        // ToDo: Add c# wpf component to present gathered data for -4 days 

        public DayPicture LoadDataFromDataBase()
        {
            DayPicture _daypicture = new DayPicture();
            DailyTargetService service = new DailyTargetService();
            _daypicture = service.GetDayResult();
            return _daypicture;
        }


        private void LoadData(object sender, RoutedEventArgs e)
        {
            // ToDo : Code Loading data base on picked date

        }

        private void ScreenDataRefresh(DayPicture dayPicture)
        {
            // ToDo : Hard code results for each shift

            // Shift #1

            txtPcsH01_Shift1.Text = "" + dayPicture.OutputPerHour[6].Output + " " + dayPicture.OutputPerHour[6].Hour;
            txtPcsH02_Shift1.Text = "" + dayPicture.OutputPerHour[7].Output + " " + dayPicture.OutputPerHour[7].Hour;
            txtPcsH03_Shift1.Text = "" + dayPicture.OutputPerHour[8].Output + " " + dayPicture.OutputPerHour[8].Hour;
            txtPcsH04_Shift1.Text = "" + dayPicture.OutputPerHour[9].Output + " " + dayPicture.OutputPerHour[9].Hour;
            txtPcsH05_Shift1.Text = "" + dayPicture.OutputPerHour[10].Output + " " + dayPicture.OutputPerHour[10].Hour;
            txtPcsH06_Shift1.Text = "" + dayPicture.OutputPerHour[11].Output + " " + dayPicture.OutputPerHour[11].Hour;
            txtPcsH07_Shift1.Text = "" + dayPicture.OutputPerHour[12].Output + " " + dayPicture.OutputPerHour[12].Hour;
            txtPcsH08_Shift1.Text = "" + dayPicture.OutputPerHour[13].Output + " " + dayPicture.OutputPerHour[13].Hour;

            txtPcsSUM_Shift1.Text = "" + CalculateSum(dayPicture, 6, 13);

            // Shift #2
            txtPcsH01_Shift2.Text = "" + dayPicture.OutputPerHour[14].Output + " " + dayPicture.OutputPerHour[14].Hour;
            txtPcsH02_Shift2.Text = "" + dayPicture.OutputPerHour[15].Output + " " + dayPicture.OutputPerHour[15].Hour;
            txtPcsH03_Shift2.Text = "" + dayPicture.OutputPerHour[16].Output + " " + dayPicture.OutputPerHour[16].Hour;
            txtPcsH04_Shift2.Text = "" + dayPicture.OutputPerHour[17].Output + " " + dayPicture.OutputPerHour[17].Hour;
            txtPcsH05_Shift2.Text = "" + dayPicture.OutputPerHour[18].Output + " " + dayPicture.OutputPerHour[18].Hour;
            txtPcsH06_Shift2.Text = "" + dayPicture.OutputPerHour[19].Output + " " + dayPicture.OutputPerHour[19].Hour;
            txtPcsH07_Shift2.Text = "" + dayPicture.OutputPerHour[20].Output + " " + dayPicture.OutputPerHour[20].Hour;
            txtPcsH08_Shift2.Text = "" + dayPicture.OutputPerHour[21].Output + " " + dayPicture.OutputPerHour[21].Hour;

            txtPcsSUM_Shift2.Text = "" + CalculateSum(dayPicture, 14, 21);

            // Shift #3
            txtPcsH01_Shift3.Text = "" + dayPicture.OutputPerHour[22].Output + " " + dayPicture.OutputPerHour[22].Hour;
            txtPcsH02_Shift3.Text = "" + dayPicture.OutputPerHour[23].Output + " " + dayPicture.OutputPerHour[23].Hour;
            txtPcsH03_Shift3.Text = "" + dayPicture.OutputPerHour[0].Output + " " + dayPicture.OutputPerHour[0].Hour;
            txtPcsH04_Shift3.Text = "" + dayPicture.OutputPerHour[1].Output + " " + dayPicture.OutputPerHour[1].Hour;
            txtPcsH05_Shift3.Text = "" + dayPicture.OutputPerHour[2].Output + " " + dayPicture.OutputPerHour[2].Hour;
            txtPcsH06_Shift3.Text = "" + dayPicture.OutputPerHour[3].Output + " " + dayPicture.OutputPerHour[3].Hour;
            txtPcsH07_Shift3.Text = "" + dayPicture.OutputPerHour[4].Output + " " + dayPicture.OutputPerHour[4].Hour;
            txtPcsH08_Shift3.Text = "" + dayPicture.OutputPerHour[5].Output + " " + dayPicture.OutputPerHour[5].Hour;

            txtPcsSUM_Shift3.Text = "" + (CalculateSum(dayPicture, 22, 23) + CalculateSum(dayPicture, 0, 5));

        }

        // Calculate sum of hourly outputs from given hour range
        private int CalculateSum(DayPicture dp, int start, int end)
        {
            int _sum = 0;
            for (int i = start; i < end+1; i++)
            {
                _sum = _sum + dp.OutputPerHour[i].Output;
            }
            return _sum;
        }

        private void btnLoadData(object sender, RoutedEventArgs e)
        {

        }
    }
}
