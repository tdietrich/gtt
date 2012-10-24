using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;


namespace gtt
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Ustalenie, że gra nie będzie zmieniać orientacji ekranu, w zależności od położenia telefonu.
            SupportedOrientations = SupportedPageOrientation.Portrait;
             
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            // Jeżeli player ma profil
            if (GameModel.GetInstance.CheckIfPlayerHasProfile())
            {
                NavigationService.Navigate(new Uri("/Pages/GamePage.xaml", UriKind.Relative));
            }

            // Jeżeli go nie ma
            else
            {
                NavigationService.Navigate(new Uri("/Pages/CreateProfile.xaml", UriKind.Relative));
               
            }
        }
    }
}