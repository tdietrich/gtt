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
    public partial class Help : PhoneApplicationPage
    {
        public Help()
        {
            InitializeComponent();

            // Obsluga zdarzenia kliknięcia w przycisk back
            BackKeyPress += new EventHandler<System.ComponentModel.CancelEventArgs>(Credits_BackKeyPress);
        }

        /// <summary>
        /// Handler dla kliknięcia w back w stronie creditsów
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Credits_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Jeżeli jest w historii poprzednia strona
            if (NavigationService.CanGoBack)
            {
                // Cofnij się
                NavigationService.GoBack();
            }
        }
    }
}