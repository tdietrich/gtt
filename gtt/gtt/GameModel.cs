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
using FarseerPhysics;



namespace gtt
{
    /// <summary>
    /// Klasa przygotowana pod głowna klasę gry - silnik fizyczny etc.
    /// Na razie smieci tu mogą być - TESTOWANIE SILNIKA FIZYCZNEGO
    /// </summary>
    public class GameModel
    {

        #region Pola Klasy

        /// <summary>
        /// Instancja
        /// </summary>
        private static GameModel Instance;

        /// <summary>
        /// Obiekty synchronizujący, dla wielowątkowości.
        /// </summary>
        private static object SyncRoot = new Object();

        #endregion



        #region Funkcje

        /// <summary>
        /// Sprawdza czy w slowniku zapisano juz pole name, jezeli nie zwraca false
        /// </summary>
        /// <returns></returns>
        public bool CheckIfPlayerHasProfile()
        {
            DataManager.SeekForPlayerData();

            if (DataManager.CreatePlayer)
            {
                return false;
            }
            else return true;

        }


        /// <summary>
        /// Standardowy konstruktor
        /// </summary>
        public GameModel()
        {
           
        }


        /// <summary>
        /// Zwraca instancję tej klasy.
        /// </summary>
        public static GameModel GetInstance
        {
            get
            {
                lock (SyncRoot)
                {
                    if (Instance == null)
                    {
                        Instance = new GameModel();
                    }

                    return Instance;
                }
            }
        }

        #endregion 
    }
}
