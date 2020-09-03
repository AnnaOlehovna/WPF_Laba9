using BusinessLayer.Models;
using BusinessLayer.Services;
using DataLayer.Interfaces;
using Laba9.Dialogs;
using System.Collections.ObjectModel;
using System.Windows;

namespace Laba9
{
    public partial class MainWindow : Window
    {
        ObservableCollection<TransportDTO> transports;
        ITransportsService transportService;

        public MainWindow()
        {
            InitializeComponent();
            transportService = new TransportsService("TransportDbConnection");
            transports = transportService.GetAll();
            cBoxTransport.DataContext = transports;
        }

        private void Button_Add_Transport_Click(object sender, RoutedEventArgs e)
        {
            TransportDTO newTransport = new TransportDTO();

            EditTransportWindow dialog = new EditTransportWindow(newTransport, false);
            var result = dialog.ShowDialog();
            if (result == true)
            {                
                transportService.CreateTransport(newTransport);
                dialog.Close();
                UpdateControls();
            }

        }

        private void Button_Edit_Transport_Click(object sender, RoutedEventArgs e)
        {            

            if (cBoxTransport.SelectedItem != null)
            {
                TransportDTO newTransport = cBoxTransport.SelectedItem as TransportDTO;

                EditTransportWindow dialog = new EditTransportWindow(newTransport, true);
                var result = dialog.ShowDialog();
                if (result == true)
                {                   
                    transportService.UpdateTransport(newTransport);
                    dialog.Close();
                    UpdateControls();
                }
            }
            else
            {
                MessageBox.Show("Выберите транспорт для изменения", "Маленькая ошибочка!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void Button_Delete_Transport_Click(object sender, RoutedEventArgs e)
        {
            if (cBoxTransport.SelectedItem != null)
            {
                transportService.DeleteTransport(((TransportDTO)cBoxTransport.SelectedItem).TransportId);
                UpdateControls();
                cBoxTransport.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Выберите транспорт для удаления", "Маленькая ошибочка!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void Button_Add_Car_Click(object sender, RoutedEventArgs e)
        {
            CarDTO newCar = new CarDTO();

            EditCarWindow dialog = new EditCarWindow(newCar, false);
            var result = dialog.ShowDialog();
            if (result == true)
            {
                var transport = (TransportDTO)cBoxTransport.SelectedItem;
                transportService.AddCarToTransport(transport.TransportId, newCar);
                dialog.Close();
                UpdateControls();
            }

        }

        private void Button_Edit_Car_Click(object sender, RoutedEventArgs e)
       {            

            if (lbCars.SelectedItem != null)
            {
                CarDTO editedCar = lbCars.SelectedItem as CarDTO;

                EditCarWindow dialog = new EditCarWindow(editedCar, true);
                var result = dialog.ShowDialog();
                if (result == true)
                {
                    var transport = (TransportDTO)cBoxTransport.SelectedItem;
                    transportService.UpdateCar(transport.TransportId, editedCar);
                    dialog.Close();
                    UpdateControls();
                }
            }
            else
            {
                MessageBox.Show("Выберите транспорт для изменения", "Маленькая ошибочка!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void Button_Delete_Car_Click(object sender, RoutedEventArgs e)
        {
            if (lbCars.SelectedItem != null)
            {
                transportService.RemoveCarFromTransport(((TransportDTO)cBoxTransport.SelectedItem).TransportId, ((CarDTO)lbCars.SelectedItem).CarId);
                UpdateControls();
            }
            else
            {
                MessageBox.Show("Выберите транспорт для удаления", "Маленькая ошибочка!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }       

        private void UpdateControls()
        {
            int index = cBoxTransport.SelectedIndex;
            transportService = new TransportsService("TransportDbConnection");
            transports = transportService.GetAll();
            cBoxTransport.DataContext = transports;
            cBoxTransport.SelectedIndex = index;
        }
    }
}
