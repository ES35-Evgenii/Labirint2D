using System;
using System.Windows.Forms;

namespace Labirint2D
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BoxSound_CheckedChanged(object sender, EventArgs e)//CheckBox / Событие CheckedChanged
        {
            if (boxSound.Checked)//еслли стоит галочка
            {
                boxSound.Text = "Sound ON";
                Sound.sound_on();
            }
            else //если нет галочки
            {
                boxSound.Text = "Sound OFF";
                Sound.sound_off();
            }
            Sound.play_key();
        }

        private void ButtonStart_Click(object sender, EventArgs e)//нажатие кнопки start
        {
            startLevel1();
        }

        private void startLevel1()
        {
            MessageBox.Show("Провести курсор мышки от блока старт до блока финиш не коснувшись" +
                    " стен лабиринта. Так же необходимо собрать желтые квадратики \"монетки\"", "Правила для прохождения 1 уровня");
            FormLevel1 level1 = new FormLevel1(); //создание 1 уровня (формы первого уровня)
            DialogResult dr = level1.ShowDialog(); //вызов новой формы таким образом, чтобы нельзя было выйти в предыдущую
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                Sound.play_win();
                startLevel2();
            }
        }

        private void startLevel2()
        {
            MessageBox.Show("Провести курсор мышки от блока старт до блока финиш не коснувшись" +
                    " стен лабиринта (даже, если они перемещаются). Так же необходимо добыть ключ, чтобы исчезла препятствующая" +
                    " прохождению стена", "Правила для прохождения 2 уровня");
            FormLevel2 level2 = new FormLevel2(); //создание 2 уровня (формы первого уровня)
            DialogResult dr = level2.ShowDialog(); //вызов новой формы таким образом, чтобы нельзя было выйти в предыдущую
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                Sound.play_win();
                startLevel3();
            }
        }

        private void startLevel3()
        {
            MessageBox.Show("Провести курсор мышки от блока старт до блока финиш не коснувшись" +
                    " стен лабиринта (даже, если они перемещаются). Без помощи телепорта уровень не пройти (блок зеленого цвета)"
                    , "Правила для прохождения 3 уровня");
            FormLevel3 level3 = new FormLevel3(); //создание 3 уровня (формы первого уровня)
            DialogResult dr = level3.ShowDialog(); //вызов новой формы таким образом, чтобы нельзя было выйти в предыдущую
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                Sound.play_win();
                MessageBox.Show("Победа!, Пройден 3 уровень, который на данный момент являеться последним!", "Сообщение");
                startLevel4(); //уровень не дописан
            }
        }

        private void startLevel4()
        {
            
        }
    }
}
