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

namespace AutoTrack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Vehicle> vehicles;
        Vehicle? vhcl;
        public MainWindow()
        {
            vehicles = new List<Vehicle>()
            {
                new GasVehicle(1, "Toyota Corolla", 200.0, 15.0, 1.50),
                new ElectricVehicle(2, "Tesla Model 3", 300.0, 75, 0.15)
            };

            InitializeComponent();

            GetAllVehicles();
        }

        private void GetAllVehicles()
        {
            lstbox_showVehicles.ItemsSource = null;
            lstbox_showVehicles.ItemsSource = vehicles;
        }

        private void ClearInputs()
        {
            txt_id.Clear();
            txt_model.Clear();
            txt_baseCost.Clear();
            txt_field1.Clear();
            txt_field2.Clear();
            txt_totalCost.Clear(); 
            rdo_gas.IsChecked = null;
            rdo_electric.IsChecked = null;
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Clac_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txt_id.Text, out int id))
            {
                MessageBox.Show("Please enter a valid ID.");
                return;
            }

            string model = txt_model.Text;

            if (string.IsNullOrWhiteSpace(model))
            {
                MessageBox.Show("Please enter vehicle model.");
                return;
            }

            if (!double.TryParse(txt_baseCost.Text, out double baseCost))
            {
                MessageBox.Show("Please enter a valid Base Cost.");
                return;
            }

            if (!double.TryParse(txt_field1.Text, out double field1))
            {
                MessageBox.Show("Please enter a valid Field 1 value.");
                return;
            }

            if (!double.TryParse(txt_field2.Text, out double field2))
            {
                MessageBox.Show("Please enter a valid Field 2 value.");
                return;
            }


            if (rdo_gas.IsChecked == true)
            {
                vhcl = new GasVehicle(id, model, baseCost, field1, field2);
            }
            else if (rdo_electric.IsChecked == true)
            {
                vhcl = new ElectricVehicle(id, model, baseCost, field1, field2);
            }
            else
            {
                MessageBox.Show("Please select Gas or Electric vehicle.");
                return;
            }


            if (vhcl != null)
            {
                vehicles.Add(vhcl);
                txt_totalCost.Text = vhcl.CalculateOperatingCost().ToString("C");
            }

            GetAllVehicles();
        }



        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            Vehicle? selectedVehicle = lstbox_showVehicles.SelectedItem as Vehicle;

            if (selectedVehicle == null)
            {
                MessageBox.Show("Please select a vehicle to delete.");
                return;
            }

            vehicles.Remove(selectedVehicle);

            MessageBox.Show("Vehicle removed successfully.", "Success");

            GetAllVehicles();

            ClearInputs();
        }

        private void lstbox_showVehicles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Vehicle? selectedVhcl = lstbox_showVehicles.SelectedItem as Vehicle;

            if (selectedVhcl == null)
                return;

            txt_id.Text = selectedVhcl.Id.ToString();
            txt_model.Text = selectedVhcl.Model;
            txt_baseCost.Text = selectedVhcl.BaseCost.ToString();

            if (selectedVhcl is GasVehicle gvhcl)
            {
                txt_field1.Text = gvhcl.FuelEfficiency.ToString();
                txt_field2.Text = gvhcl.FuelCostPerLiter.ToString();
                rdo_gas.IsChecked = true;
            }
            else if (selectedVhcl is ElectricVehicle evhcl)
            {
                txt_field1.Text = evhcl.BatteryCapacity.ToString();
                txt_field2.Text = evhcl.ElectricityRate.ToString();
                rdo_electric.IsChecked = true;
            }

            txt_totalCost.Text = selectedVhcl.CalculateOperatingCost().ToString("C");
        }

        private void rdo_gas_Checked(object sender, RoutedEventArgs e)
        {
            lbl_field1.Content = "Fuel Efficiency:";
            lbl_field2.Content = "Fuel Cost/Liter:";
        }

        private void rdo_electric_Checked(object sender, RoutedEventArgs e)
        {
            lbl_field1.Content = "Battery Capacity:";
            lbl_field2.Content = "Electricity Rate:";
        }
    }
}