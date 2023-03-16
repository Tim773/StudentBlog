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
    /// Логика взаимодействия для MyProfile.xaml
    /// </summary>
    public partial class MyProfile : Window
    {
        public MyProfile(Person person)
        {
            InitializeComponent();

        }
        //Хз, что можно еще сделать в этом окне, пока не рассказано про бд. Тут и вывод можно сделать по входящему юзеру, 
        //и вывод текстового файла в фрейм, но с фреймами надо поработать сразу со студентами.
        private void changeInfo_Click(object sender, RoutedEventArgs e)
        {
            EditProfile editProfile = new EditProfile();
            editProfile.ShowDialog();
        }
    }
}
