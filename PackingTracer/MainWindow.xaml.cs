using PackingTracer.Data.HourlyTarget;
using PackingTracer.Service.Services;
using System;
using System.Windows;

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
        }


        public DayPicture LoadDataFromDataBase(DateTime data)
        {
            DayPicture _daypicture = new DayPicture();
            DailyTargetService service = new DailyTargetService();
            _daypicture = service.GetDayResult(data);
            return _daypicture;
        }

        #region Screen - data
        private void ScreenDataRefresh(DayPicture dayPicture)
        {
            // Shift #1
            txtPcsH01_Shift1.Text = "" + dayPicture.OutputPerHour[6].Output;
            txtPcsH02_Shift1.Text = "" + dayPicture.OutputPerHour[7].Output;
            txtPcsH03_Shift1.Text = "" + dayPicture.OutputPerHour[8].Output;
            txtPcsH04_Shift1.Text = "" + dayPicture.OutputPerHour[9].Output;
            txtPcsH05_Shift1.Text = "" + dayPicture.OutputPerHour[10].Output;
            txtPcsH06_Shift1.Text = "" + dayPicture.OutputPerHour[11].Output;
            txtPcsH07_Shift1.Text = "" + dayPicture.OutputPerHour[12].Output;
            txtPcsH08_Shift1.Text = "" + dayPicture.OutputPerHour[13].Output;

            txtPcsSUM_Shift1.Text = "" + CalculateSum(dayPicture, 6, 13);

            // Shift #2
            txtPcsH01_Shift2.Text = "" + dayPicture.OutputPerHour[14].Output;
            txtPcsH02_Shift2.Text = "" + dayPicture.OutputPerHour[15].Output;
            txtPcsH03_Shift2.Text = "" + dayPicture.OutputPerHour[16].Output;
            txtPcsH04_Shift2.Text = "" + dayPicture.OutputPerHour[17].Output;
            txtPcsH05_Shift2.Text = "" + dayPicture.OutputPerHour[18].Output;
            txtPcsH06_Shift2.Text = "" + dayPicture.OutputPerHour[19].Output;
            txtPcsH07_Shift2.Text = "" + dayPicture.OutputPerHour[20].Output;
            txtPcsH08_Shift2.Text = "" + dayPicture.OutputPerHour[21].Output;

            txtPcsSUM_Shift2.Text = "" + CalculateSum(dayPicture, 14, 21);

            // Shift #3
            txtPcsH01_Shift3.Text = "" + dayPicture.OutputPerHour[22].Output;
            txtPcsH02_Shift3.Text = "" + dayPicture.OutputPerHour[23].Output;
            txtPcsH03_Shift3.Text = "" + dayPicture.OutputPerHour[0].Output;
            txtPcsH04_Shift3.Text = "" + dayPicture.OutputPerHour[1].Output;
            txtPcsH05_Shift3.Text = "" + dayPicture.OutputPerHour[2].Output;
            txtPcsH06_Shift3.Text = "" + dayPicture.OutputPerHour[3].Output;
            txtPcsH07_Shift3.Text = "" + dayPicture.OutputPerHour[4].Output;
            txtPcsH08_Shift3.Text = "" + dayPicture.OutputPerHour[5].Output;

            txtPcsSUM_Shift3.Text = "" + (CalculateSum(dayPicture, 22, 23) + CalculateSum(dayPicture, 0, 5));
        }
        #endregion

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
            // ToDo : Code Loading data base on picked date
            DateTime data = Convert.ToDateTime(dpDataPicker.Text);

            // loading data with hourly output.
            DayPic = LoadDataFromDataBase(data);

            // refresh screen with data
            ScreenDataRefresh(DayPic);

        }
    }
}
