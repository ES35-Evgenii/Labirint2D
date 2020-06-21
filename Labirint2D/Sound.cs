using System.Media;

namespace Labirint2D
{
    public static class Sound   //статический класс, тоесть один на весь проект
    {
        static SoundPlayer sound_fail = new SoundPlayer(Properties.Resources.Fail);     //переменная для воспроизведения fail
        static SoundPlayer sound_key = new SoundPlayer(Properties.Resources.Key);       //переменная для воспроизведения Key
        static SoundPlayer sound_start = new SoundPlayer(Properties.Resources.Start);   //переменная для воспроизведения Start
        static SoundPlayer sound_win = new SoundPlayer(Properties.Resources.Win);       //переменная для воспроизведения Win

        static bool sound_enabled = true;//переменная переключателя звука

        public static void sound_on()//функция включеннойй галочки звука
        {
            sound_enabled = true;
        }

        public static void sound_off()//функция выключенной галочки звука
        {
            sound_enabled = false;
        }

        public static void play_fail () //функция берет аудиофайл fail и воспроизводит его
        {
            if (sound_enabled == true)//если стоит галочка звука
                sound_fail.Play();
        }
        public static void play_key() //функция берет аудиофайл key и воспроизводит его
        {
            if (sound_enabled == true)//если стоит галочка звука
                sound_key.Play();
        }
        public static void play_start() //функция берет аудиофайл start и воспроизводит его
        {
            if (sound_enabled == true)//если стоит галочка звука
                sound_start.Play();
        }
        public static void play_win() //функция берет аудиофайл win и воспроизводит его
        {
            if (sound_enabled == true)//если стоит галочка звука
                sound_win.Play();
        }
    }
}
