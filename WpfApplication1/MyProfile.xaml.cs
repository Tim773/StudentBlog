﻿using System;
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
            dataFrame.Navigate(new Pages.MainPage());
            Person user = person;
            UserDataPull(user);

        }
        
        private void changeInfo_Click(object sender, RoutedEventArgs e)
        {
            EditProfile editProfile = new EditProfile();
            editProfile.ShowDialog();
        }

        private void UserDataPull(Person user)
        {
            Person activeUser = AppClass.entities.Person.
                Where(i => i.email == user.email).FirstOrDefault();
            userName.Text = activeUser.namePerson.ToString();
            userLastName.Text = activeUser.fNamePerson.ToString();
            userSrName.Text = activeUser.sNamePerson.ToString();
            //profilePic.Source = activeUser.photoPath; //данный вариант не работает


        }
    }
}
