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
    public partial class FormLevel1 : Form
    {
        int box_left = 3; //переменная для подсчета собранных монеток

        public FormLevel1()
        {
            InitializeComponent();
        }

        private void startGame()    //функция для подготовки нашей формы к запуску
        {
            Point point = labelStart.Location; //записываем координаты labelStart в переменную point
            point.Offset(labelStart.Width / 2, labelStart.Height / 2); // смещаем позицию курсора на середину labelStart
            Cursor.Position = PointToScreen(point); //размещение курсора на поле Старт
            Sound.play_start(); //вызов мелодии
            box_left = 3; //осталось три монетки
            labelMonet1.Visible = true;//устанавливаем видимость монетки 1
            labelMonet2.Visible = true;//устанавливаем видимость монетки 2
            labelMonet3.Visible = true;//устанавливаем видимость монетки 3
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

        private void FormLevel1_Shown(object sender, EventArgs e) //событие, которое возникает при первом отображении формы
        {
            startGame();    //запускаем функцию подготовки формы
        }

        private void LabelFinish_MouseEnter(object sender, EventArgs e)//событие, которое происходит, когда мышка входит в видимую часть labelFinish
        {
            if (box_left == 0) //если собраны все монетки
            {
                finishGame(); //функция окончания игры
            }
        }

        private void Label5_MouseEnter(object sender, EventArgs e)//событие, которое происходит, когда мышка входит в видимую часть labelов, котороые являются стенами
        {
            restartGame(); //функция запускающая игру сначала
        }

        private void LabelMonet3_MouseEnter(object sender, EventArgs e) //событие наезда на монетки, которое учитывает на какую именно монетку был совершен наезд
        {
            ((Label)sender).Visible = false; //исчезговение монетки, на которую был заезд
            Sound.play_key();
            box_left--; //уменьшаем количество оставшихся монет
        }
    }
}
