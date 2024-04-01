using EZInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace SpaceShooterGame
{
    public partial class SpaceShooter : Form
    {
        public static SpaceShooter Game;
        List<PictureBox> playerFires = new List<PictureBox>();
        List<PictureBox> MeteriodList = new List<PictureBox>();
        List<PictureBox> enemyFires = new List<PictureBox>();
        int enemyFirstFire = 0;
        int enemyLastFire = 0;
        PictureBox enemyBlack;
        PictureBox enemy2;
        Random rand = new Random();
        string enemyDirection = "MovingLeft";
        string enemy2Direction = "MovingRight";
        bool isEnemyBlackAlive = true;
        bool isEnemy2Alive = true;
        int score = 0;
        bool isBomb = false;
        bool isFire = false;
        public SpaceShooter()
        {
            InitializeComponent();
            Game=this;
      
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           


            enemyBlack = createEnemy(SpaceShooterGame.Properties.Resources.enemy2);
            enemy2 = createEnemy(SpaceShooterGame.Properties.Resources.enemy2);
            this.Controls.Add(enemyBlack);
            this.Controls.Add(enemy2);


        }

        private void TimeGameLoop_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                if ((pbPlayerShip.Left + pbPlayerShip.Width + 30) < this.Width)
                {
                    pbPlayerShip.Left = pbPlayerShip.Left + 25;
                }
            }
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                if (pbPlayerShip.Left >= 20)
                {
                    pbPlayerShip.Left = pbPlayerShip.Left - 25;
                }

            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                if (pbPlayerShip.Top >= 20)
                {
                    pbPlayerShip.Top = pbPlayerShip.Top - 25;
                }
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                if ((pbPlayerShip.Top + pbPlayerShip.Height + 70) < this.Height)
                    pbPlayerShip.Top = pbPlayerShip.Top + 25;
            }

            if (Keyboard.IsKeyPressed(Key.Space) || Keyboard.IsKeyPressed(Key.Control))
            {
                Image bullet;

                if (Keyboard.IsKeyPressed(Key.Control))
                {
                    bullet = SpaceShooterGame.Properties.Resources.BigBomb;
                    isBomb = true;
                }
                else
                {
                    bullet = SpaceShooterGame.Properties.Resources.Fire4;
                    isFire = true;
                }
                PictureBox pbfire = createFire(bullet, pbPlayerShip);
                playerFires.Add(pbfire);
                this.Controls.Add(pbfire);
            }



        }


        private PictureBox createEnemy(Image img)
        {
            PictureBox pbEnemy = new PictureBox();
            int left = rand.Next(30, this.Width);
            int top = rand.Next(5, img.Height + 20);

            pbEnemy.Left = left;
            pbEnemy.Top = top;
            pbEnemy.Width = img.Width;
            pbEnemy.Height = img.Height;
            pbEnemy.BackColor = Color.Transparent;
            pbEnemy.Image = img;
            return pbEnemy;
        }
        private PictureBox createFire(Image FireImage, PictureBox source)
        {
            PictureBox pbFire = new PictureBox();
            pbFire.Image = FireImage;
            pbFire.Width = FireImage.Width;
            pbFire.Height = FireImage.Height;
            pbFire.BackColor = Color.Transparent;
            System.Drawing.Point fireLocation;
            fireLocation = new System.Drawing.Point();
            fireLocation.X = source.Left + (source.Width / 2) - 5;
            fireLocation.Y = source.Top;
            pbFire.Location = fireLocation;
            return pbFire;
        }

        private PictureBox createMeteor(Image FireImage)
        {
            PictureBox pbFire = new PictureBox();
            pbFire.Image = FireImage;
            pbFire.Width = FireImage.Width;
            pbFire.Height = FireImage.Height;
            pbFire.BackColor = Color.Transparent;
            System.Drawing.Point fireLocation;
            fireLocation = new System.Drawing.Point();
            fireLocation.X = pbFire.Left + (pbFire.Width / 2) - 5;
            fireLocation.Y = pbFire.Top;
            pbFire.Location = fireLocation;
            return pbFire;
        }

        private void moveEnemy(PictureBox enemy, ref string enemyDirection)
        {
            if (enemyDirection == "MovingRight")
            {
                enemy.Left = enemy.Left + 10;
            }
            if (enemyDirection == "MovingLeft")
            {
                enemy.Left = enemy.Left - 10;
            }
            if ((enemy.Left + enemy.Width) > this.Width)
            {
                enemyDirection = "MovingLeft";
            }
            if (enemy.Left <= 2)
            {
                enemyDirection = "MovingRight";
            }
        }


        private void Enemy_Tick(object sender, EventArgs e)
        {


            if (enemyFirstFire >= enemyLastFire)
            {
                Image bullet = SpaceShooterGame.Properties.Resources.Rocket;
                if (isEnemyBlackAlive)
                {
                    PictureBox pbfire = createFire(bullet, enemyBlack);
                    enemyFires.Add(pbfire);
                    this.Controls.Add(pbfire);
                    enemyLastFire = 0;

                }

            }

            if (enemyFirstFire >= enemyLastFire)
            {
                Image bullet = SpaceShooterGame.Properties.Resources.Rocket;
                if (isEnemy2Alive)
                {
                    PictureBox pbfire = createFire(bullet, enemy2);
                    enemyFires.Add(pbfire);
                    this.Controls.Add(pbfire);
                    enemyLastFire = 0;

                }

            }



        }

        private void MoveEnemy_Tick(object sender, EventArgs e)
        {//////////

            foreach (PictureBox bullet in playerFires)
            {
                bullet.Top = bullet.Top - 15;
            }
            for (int idx = 0; idx < playerFires.Count; idx++)
            {
                if (playerFires[idx].Bottom < 0)
                {
                    playerFires.Remove(playerFires[idx]);

                }

            }
            foreach (PictureBox bullet in playerFires)
            {

                foreach (PictureBox pbMeteor in MeteriodList)
                {
                    if (pbMeteor.Bounds.IntersectsWith(bullet.Bounds))
                    {
                        score += 5;
                        Score.Text = "Score : " + score.ToString();
                        pbMeteor.Top = this.Height + 2000;
                        this.Controls.Remove(pbMeteor);
                        this.Controls.Remove(bullet);
                    }
                }

                if (bullet.Bounds.IntersectsWith(enemyBlack.Bounds) || bullet.Bounds.IntersectsWith(enemy2.Bounds))
                {
                    if (bullet.Bounds.IntersectsWith(enemy2.Bounds))
                    {
                        this.Controls.Remove(enemy2);
                        isEnemy2Alive = false;

                    }
                    if (bullet.Bounds.IntersectsWith(enemyBlack.Bounds))
                    {
                        this.Controls.Remove(enemyBlack);

                        isEnemyBlackAlive = false;

                    }
                  

                    score += 1;
                    Score.Text = "Score : " + score.ToString();
                    this.Controls.Remove(bullet);
                    if (isFire)
                    {
                        pbEnemyHealth.Value -= 5;
                        isFire = false;

                    }
                    if (isBomb)
                    {
                        if (pbEnemyHealth.Value < 10)
                        {
                            pbEnemyHealth.Value = 0;
                        }
                        else
                        {
                            pbEnemyHealth.Value -= 10;
                            isBomb = false;
                        }


                    }
                    if (pbEnemyHealth.Value == 0)
                    {
                        TimeGameLoop.Enabled = false;
                        EnemyFire.Enabled = false;
                        move.Enabled = false;
                        metriod.Enabled = false;

                        Image img = SpaceShooterGame.Properties.Resources.Win;
                        FormGameOver gameOver = new FormGameOver(img);
                        gameOver.Show();
                        this.Hide();   
                    }


                }
            }



            ///////////////
            moveEnemy(enemyBlack, ref enemyDirection);
            moveEnemy(enemy2, ref enemy2Direction);

            if (!isEnemyBlackAlive)
            {
                enemyBlack = createEnemy(SpaceShooterGame.Properties.Resources.enemy2);
                this.Controls.Add(enemyBlack);
                isEnemyBlackAlive = true;
            }

            if (!isEnemy2Alive)
            {
                enemy2 = createEnemy(SpaceShooterGame.Properties.Resources.enemy2);
                this.Controls.Add(enemy2);
                isEnemy2Alive = true;
            }

            foreach (PictureBox bullet in enemyFires)
            {
                bullet.Top = bullet.Top + 15;
            }

            for (int idx = 0; idx < enemyFires.Count; idx++)
            {
                if (enemyFires[idx].Bottom < 0)
                {
                    enemyFires.Remove(enemyFires[idx]);
                }
            }
      

            foreach (PictureBox bullet in enemyFires)
            {

                foreach (PictureBox pbMeteor in MeteriodList)
                {
                    if (pbMeteor.Bounds.IntersectsWith(pbPlayerShip.Bounds))
                    {
                        pbPlayerHealth.Value = 0;
                    }
                }

                if (bullet.Bounds.IntersectsWith(pbPlayerShip.Bounds))
                {

                    if (pbPlayerHealth.Value > 0)
                    {
                        pbPlayerHealth.Value -=10;
                        this.Controls.Remove(bullet);

                    }

                }
              
            }
            if (pbPlayerHealth.Value == 0)
            {
                move.Enabled = false;
                EnemyFire.Enabled = false;
                TimeGameLoop.Enabled = false;
                metriod.Enabled = false;
                score = 0;
                Image img = SpaceShooterGame.Properties.Resources.Gameover__2_;
                FormGameOver gameOver = new FormGameOver(img);
                Thread.Sleep(800);
                gameOver.Show();
                this.Hide();

            }
            foreach (PictureBox Meteor in MeteriodList)
            {
                Meteor.Top = Meteor.Top + 15;
                if (Meteor.Bottom <= 2)
                {
                    this.Controls.Remove(Meteor);
                    MeteriodList.Remove(Meteor);
                }
            }



        }

        private void meteroid_Tick(object sender, EventArgs e)
        {

            Image img = SpaceShooterGame.Properties.Resources.meteor1;
            PictureBox pbMeteor = createMeteor(img);
            MeteriodList.Add(pbMeteor);
            int left = rand.Next(30, this.Width);
            pbMeteor.Left = left;
            this.Controls.Add(pbMeteor);



        }

        private void pbPlayerShip_Click(object sender, EventArgs e)
        {

        }
    }
}
