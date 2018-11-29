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
using TestEntityFramework.ViewModel;

namespace TestEntityFramework.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewStudentWindow.xaml
    /// </summary>
    public partial class AddNewStudentWindow : Window
    {
        public AddNewStudentWindow()
        {
            InitializeComponent();
            AddNewStudentViewModel addNewStudentViewModel = new AddNewStudentViewModel();
            this.DataContext = addNewStudentViewModel;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
