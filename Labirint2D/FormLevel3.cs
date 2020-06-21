using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labirint2D
{
    public partial class FormLevel3 : Form
    {
        public FormLevel3()
        {
            InitializeComponent();
        }

        private void startGame()    //функция для подготовки нашей формы к запуску
        {
            timer.Enabled = false;
            Point point = labelStart.Location; //записываем координаты labelStart в переменную point
            point.Offset(labelStart.Width / 2, labelStart.Height / 2); // смещаем позицию курсора на середину labelStart
            Cursor.Position = PointToScreen(point); //размещение курсора на поле Старт
            Sound.play_start(); //вызов мелодии
            labelFlash1.Visible = true;//одна мерцающая стенка видна
            labelFlash2.Visible = false;//одна мерцающая стенка не видна
        }

        private void finishGame() //функция окончания игры
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK; //не особо понятно, но эта строка закрывает форму FormLevel1
        }

        private void restartGame() //функция запускающая игру сначала
        {
            Sound.play_fail();
            DialogResult dr = MessageBox.Show("Произошло прикасание со стенами! \n Еще попробуем?", "Вы проиграли",
                MessageBoxButtons.YesNo);
            if (dr == System.Windows.Forms.DialogResult.Yes) //если нажата кнопка ОК
                startGame(); //запуск игры сначала
            else
                this.DialogResult = System.Windows.Forms.DialogResult.Abort; //не особо понятно, но эта строка закрывает форму FormLevel1
        }

        private void Label3_MouseEnter(object sender, EventArgs e)
        {
            restartGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            labelFlash1.Visible = !labelFlash1.Visible;
            labelFlash2.Visible = !labelFlash2.Visible;
        }

        private void LabelTeleportIN_MouseEnter(object sender, EventArgs e)//телепорт вход
        {
            timer.Enabled = true;
            Point point = labelTeleportOut.Location; //записываем координаты labelStart в переменную point
            point.Offset(labelTeleportOut.Width / 2, labelTeleportOut.Height / 2); // смещаем позицию курсора на середину labelStart
            Cursor.Position = PointToScreen(point); //размещение курсора на поле Старт
        }

        private void FormLevel3_Shown(object sender, EventArgs e)
        {
            startGame();
        }

        private void LabelFinish_MouseEnter(object sender, EventArgs e)
        {
            finishGame();
        }
    }
}
