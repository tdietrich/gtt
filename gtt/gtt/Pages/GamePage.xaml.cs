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
using FarseerPhysics.Collision;
using FarseerPhysics.Common;
using FarseerPhysics.Controllers;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using FarseerPhysics.Collision.Shapes;

namespace gtt.Pages
{
    public partial class GamePage : PhoneApplicationPage
    {
        public GamePage()
        {
            InitializeComponent();
            
            name.Text = Player.GetInstance.name;
            score.Text = Player.GetInstance.score.ToString();

            World world = new World(new Vector2(0, -1));
            Body myBody = BodyFactory.CreateBody(world, new Vector2(10, 0));
            CircleShape circleShape = new CircleShape(0.5f,1.0f);

            Fixture fixture = myBody.CreateFixture(circleShape);
            


        }



    }
}