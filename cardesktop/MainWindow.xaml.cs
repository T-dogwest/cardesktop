using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cardesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            CarService carservice;
            InitializeComponent();
            LoadCar();
        }

        private void LoadCar()
        {
            try
            {
                CarService carService = new CarService();
                var cars = carService.GetCars();
                dataGrid.ItemsSource = cars;
            }catch (Exception ex)
            {
                MessageBox.Show($"Error:{ex.Message}");
            }
        }

        private void DELETE_CLICK(object sender, RoutedEventArgs e)
        {
            var car= dataGrid.SelectedItem as Car;
            if (car == null)
            {
                MessageBox.Show("Elöbb válassz ki egy elemet");
            }
            var result = MessageBox.Show("Biztos törölni akarod?", "Megerősítés", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try 
                {
                    CarService carService = new CarService();
                    carService.RemoveCar(car);
                    MessageBox.Show("sikeres törlés");
                    LoadCar();
                }
                catch ( Exception ex )
                {
                    MessageBox.Show($"Error:{ex.Message}");
                }
            }
        }
    }
}