using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooterGame
{
    public partial class FormGameOver : Form
    {

        public FormGameOver(Image BackGroundScreen)
        {
            InitializeComponent();
            this.BackgroundImage = BackGroundScreen;


        }

        private void FormGameOver_Load(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            SpaceShooter.Game.Close();
            this.Close();
            
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            this.Close();
            SpaceShooter spaceShooter = new SpaceShooter();
            spaceShooter.Show();
        }
    }
}
