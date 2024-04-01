namespace SpaceShooterGame
{
    partial class SpaceShooter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpaceShooter));
            this.pbPlayerShip = new System.Windows.Forms.PictureBox();
            this.TimeGameLoop = new System.Windows.Forms.Timer(this.components);
            this.EnemyFire = new System.Windows.Forms.Timer(this.components);
            this.pbPlayerHealth = new System.Windows.Forms.ProgressBar();
            this.lbHealth = new System.Windows.Forms.Label();
            this.move = new System.Windows.Forms.Timer(this.components);
            this.Score = new System.Windows.Forms.Label();
            this.pbEnemyHealth = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.metriod = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerShip)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPlayerShip
            // 
            this.pbPlayerShip.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayerShip.BackgroundImage = global::SpaceShooterGame.Properties.Resources.PngItem_851399;
            this.pbPlayerShip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPlayerShip.InitialImage = null;
            this.pbPlayerShip.Location = new System.Drawing.Point(319, 388);
            this.pbPlayerShip.Name = "pbPlayerShip";
            this.pbPlayerShip.Size = new System.Drawing.Size(100, 50);
            this.pbPlayerShip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPlayerShip.TabIndex = 0;
            this.pbPlayerShip.TabStop = false;
            this.pbPlayerShip.Click += new System.EventHandler(this.pbPlayerShip_Click);
            // 
            // TimeGameLoop
            // 
            this.TimeGameLoop.Enabled = true;
            this.TimeGameLoop.Tick += new System.EventHandler(this.TimeGameLoop_Tick);
            // 
            // EnemyFire
            // 
            this.EnemyFire.Enabled = true;
            this.EnemyFire.Interval = 2000;
            this.EnemyFire.Tick += new System.EventHandler(this.Enemy_Tick);
            // 
            // pbPlayerHealth
            // 
            this.pbPlayerHealth.Location = new System.Drawing.Point(306, 45);
            this.pbPlayerHealth.Name = "pbPlayerHealth";
            this.pbPlayerHealth.Size = new System.Drawing.Size(482, 15);
            this.pbPlayerHealth.TabIndex = 1;
            this.pbPlayerHealth.Value = 100;
            // 
            // lbHealth
            // 
            this.lbHealth.AutoSize = true;
            this.lbHealth.Font = new System.Drawing.Font("MV Boli", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHealth.Location = new System.Drawing.Point(152, 44);
            this.lbHealth.Name = "lbHealth";
            this.lbHealth.Size = new System.Drawing.Size(102, 17);
            this.lbHealth.TabIndex = 2;
            this.lbHealth.Text = "Player Health";
            // 
            // move
            // 
            this.move.Enabled = true;
            this.move.Interval = 50;
            this.move.Tick += new System.EventHandler(this.MoveEnemy_Tick);
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score.Location = new System.Drawing.Point(4, 16);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(106, 25);
            this.Score.TabIndex = 3;
            this.Score.Text = "Socre : 0";
            // 
            // pbEnemyHealth
            // 
            this.pbEnemyHealth.Location = new System.Drawing.Point(306, 16);
            this.pbEnemyHealth.Name = "pbEnemyHealth";
            this.pbEnemyHealth.Size = new System.Drawing.Size(482, 18);
            this.pbEnemyHealth.TabIndex = 4;
            this.pbEnemyHealth.Value = 100;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MV Boli", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(152, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Enemy Health";
            // 
            // metriod
            // 
            this.metriod.Enabled = true;
            this.metriod.Interval = 5000;
            this.metriod.Tick += new System.EventHandler(this.meteroid_Tick);
            // 
            // SpaceShooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SpaceShooterGame.Properties.Resources.space_2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbEnemyHealth);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.lbHealth);
            this.Controls.Add(this.pbPlayerHealth);
            this.Controls.Add(this.pbPlayerShip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SpaceShooter";
            this.Text = "SpaceShooter";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerShip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPlayerShip;
        private System.Windows.Forms.Timer TimeGameLoop;
        private System.Windows.Forms.Timer EnemyFire;
        private System.Windows.Forms.ProgressBar pbPlayerHealth;
        private System.Windows.Forms.Label lbHealth;
        private System.Windows.Forms.Timer move;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.ProgressBar pbEnemyHealth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer metriod;
    }
}

