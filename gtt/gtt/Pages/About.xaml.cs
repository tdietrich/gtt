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
    /// <summary>
    /// To jeest strona Creditsów
    /// </summary>
    public partial class Credits : PhoneApplicationPage
    {
        public Credits()
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
            // Jezeli w historii nawigacji jest poprzednia strona
            if (NavigationService.CanGoBack)
            {
                // Cofnij się
                NavigationService.GoBack();
            }
        }
    }
}