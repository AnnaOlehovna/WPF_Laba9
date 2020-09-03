using BusinessLayer.Models;
using System.Windows;

namespace Laba9.Dialogs
{

    public partial class EditCarWindow : Window
    {

        private CarDTO car;

        public EditCarWindow(CarDTO car, bool isEditMode)
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            this.car = car;
            DataContext = this.car;
            if (isEditMode)
            {
                Title = "Изменить транспорт";
            }
            else
            {
                Title = "Добавить транспорт";
            }
        }        

        private void BtnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
