using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flıpyy_bırd_proje_2
{
    public partial class Form1 : Form
    {
        int boruHızı=8;
        int gravity = 10;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Skor_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappybird.Top += gravity;
            boruAlt.Left -= boruHızı;
            boruUst.Left -= boruHızı;
            scoreText.Text = "Score= " + score;
            if (boruAlt.Left < -150)
            {
                boruAlt.Left = 800;
                score++;
            }
            if (boruUst.Left < -180)
            {
                boruUst.Left = 950;
                score++;
            }
            if(flappybird.Bounds.IntersectsWith(boruAlt.Bounds)||flappybird.Bounds.IntersectsWith(boruUst.Bounds)||flappybird.Bounds.IntersectsWith(zemin.Bounds))
            {
                endGame();
            }
            if(score>3)
            {
                boruHızı = 16;
            }
            if(flappybird.Top<-25)
            {
                endGame();
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
                
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }
        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text = "Game Over!!!";
        }
    }
}
