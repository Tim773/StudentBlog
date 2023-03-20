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
       private Person user;
        public MyProfile(Person person)
        {
            InitializeComponent();
            user = person;

        }
        
        private void changeInfo_Click(object sender, RoutedEventArgs e)
        {
            EditProfile editProfile = new EditProfile();
            editProfile.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Person activeUser = AppClass.entities.Person.Where(i => i.email == user.email).FirstOrDefault();
            userName.Text = activeUser.namePerson.ToString();
            userLastName.Text = activeUser.fNamePerson.ToString();

        }
    }
}
