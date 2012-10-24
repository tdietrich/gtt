using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace gtt
{

    /// <summary>
    /// Klasa SINGLETON - przedstawiająca gracza.
    /// </summary>
    public class Player
    {

        #region Pola Klasy

        /// <summary>
        /// Nazwa playera/login
        /// </summary>
        public string name;

        /// <summary>
        /// Score playera
        /// </summary>
        public uint score;

        /// <summary>
        /// Instancja
        /// </summary>
        private static Player Instance;

        /// <summary>
        /// Obiekty synchronizujący, dla wielowątkowości.
        /// </summary>
        private static object SyncRoot = new Object();


        #endregion


        #region Funkcje
        /// <summary>
        /// Standardowy konstruktor
        /// </summary>
        private Player()
        {

        }

        /// <summary>
        /// Zwraca instancję tej klasy.
        /// </summary>
        public static Player GetInstance
        {
            get
            {
                lock (SyncRoot)
                {
                    if (Instance == null)
                    {
                        Instance = new Player();
                    }

                    return Instance;
                }
            }
        }

        /// <summary>
        /// Funkcja przypisuje dane playerowi
        /// </summary>
        /// <param name="name"></param>
        /// <param name="score"></param>
        public void LoadMyData(string name, uint score)
        {
            this.name = name;
            this.score = score;
        }


        #endregion 
    }
}
