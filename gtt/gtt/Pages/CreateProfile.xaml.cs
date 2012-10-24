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

namespace gtt.Pages
{
    public partial class AccountCreate : PhoneApplicationPage
    {
        public AccountCreate()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handler obsługi kliknięcia w ok
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            // Czy puste pole zostawiono
            if (name.Text == "")
            {
                nameLabel.Text = "Please, type your name/nick";
            }
            else if (name.Text.Length < 2)
            {
                nameLabel.Text = "Name should be longer than 2 signs";
            }
            else
            {
                // Zapisz w slowniku pamięci telefonu, pod kluczem name wartość
                //Game.GetInstance._AppMemory.SaveValue("name", name.Text);
                //Game.GetInstance._AppMemory.SaveValue("score", 0);
                DataManager.SaveUserData(name.Text);


                // Przypissz playerowi dane
                Player.GetInstance.name = name.Text;
                Player.GetInstance.score = 0;

                // Nawigacja do strony GamePage
                PhoneApplicationFrame root = Application.Current.RootVisual as PhoneApplicationFrame;
                root.Navigate(new Uri("/Pages/GamePage.xaml", UriKind.Relative)); 
            }

           
        }
    }
}