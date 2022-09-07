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
        public MainWindow()
        {
            InitializeComponent();

            giveMeData();
        }

        // ToDo: Add c# wpf component to present gathered data for -4 days 

        public void giveMeData()
        {
            DailyTargetService service = new DailyTargetService();
            service.GetDayResult();
        }


        private void LoadData(object sender, RoutedEventArgs e)
        {
            // ToDo : Code Loading data base on picked date

        }


        private void ScreenRefresh()
        {
            // ToDo : Hard code results for each shift
        }

    }
}
