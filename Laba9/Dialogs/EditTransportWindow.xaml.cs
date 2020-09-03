using BusinessLayer.Models;
using System.Windows;

namespace Laba9.Dialogs
{

    public partial class EditTransportWindow : Window
    {

        private TransportDTO transportDTO;
        public EditTransportWindow(TransportDTO transport, bool isEditMode)
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            this.transportDTO = transport;
            DataContext = this.transportDTO;
            if (isEditMode)
            {
                Title = "Изменить тип транспорта";
            }
            else
            {
                Title = "Добавить тип транспорта";
            }
        }

        private void BtnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
