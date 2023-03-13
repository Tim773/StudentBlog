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

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();

        }


        private void enter_Click(object sender, RoutedEventArgs e)
        {
            //Дописать авторизацию к паре про бд.

            //Вызов окна профиля, создание его экземпляра
            MyProfile myProfile = new MyProfile();
            //Вызов метода ShowDialog из созданного экземпляра
            myProfile.ShowDialog();

        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {   
            
            //Вызов окна регистрации, создание его экземпляра
            MainWindow mainWindow = new MainWindow();
            //Вызов метода ShowDialog из созданного экземпляра
            mainWindow.ShowDialog();
        }





    }
}
