using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2._2
{
    public interface MusicInstrument
    {
        void MimickSound();
        void ShowName();
        void Description();
        void History();
    }
    class Violin : MusicInstrument
    {
        private const string Name = "Violin";

        public void ShowName()
        {
            Console.WriteLine($"Name of instrument: {Name}");
        }
        public void Description()
        {
            Console.WriteLine($"Description of {Name}: A small, stringed, bowed instrument with four strings tuned in perfect fifths. " +
                                            "It is held under the chin and played with a bow or plucked.");
        }
        public void History()
        {
            Console.WriteLine($"History of {Name}: Originating in 16th-century Italy, " +
                                        "the violin evolved from earlier stringed instruments like the viola da gamba.");
        }
        public void MimickSound()
        {
            Console.WriteLine($"Sound of {Name}: \"Screech\", \"Fiddle\", or \"Vee-vee\"");
        }
    }
    class Trombone : MusicInstrument
    {
        private const string Name = "Trombone";
        public void ShowName()
        {
            Console.WriteLine($"Name of instrument: {Name}");
        }
        public void Description()
        {
            Console.WriteLine($"Description of {Name}: A brass wind instrument with a telescoping slide mechanism that changes the pitch. " +
                                            "It has a cup-shaped mouthpiece and a conical bore.");
        }
        public void History()
        {
            Console.WriteLine($"History of {Name}: Developed in the 15th century in Italy, the trombone evolved from medieval sackbuts.");
        }
        public void MimickSound()
        {
            Console.WriteLine($"Sound of {Name}: \"Waa\", \"Brrr\", or \"Woooo\"");
        }
    }
    class Ukulele : MusicInstrument
    {
        private const string Name = "Ukulele";
        public void ShowName()
        {
            Console.WriteLine($"Name of instrument: {Name}");
        }
        public void Description()
        {
            Console.WriteLine($"Description of {Name}: A small, four-stringed, plucked string instrument from Hawaii, related to the guitar.");
        }
        public void History()
        {
            Console.WriteLine($"History of {Name}: Originated in the 19th century from Portuguese stringed instruments brought to Hawaii");
        }
        public void MimickSound()
        {
            Console.WriteLine($"Sound of {Name}: \"Twang\", \"Jang\", or \"Twangy\"");
        }
    }
    class Cello : MusicInstrument
    {
        private const string Name = "Cello";
        public void ShowName()
        {
            Console.WriteLine($"Name of instrument: {Name}");
        }
        public void Description()
        {
            Console.WriteLine($"Description of {Name}: A large, deep-bodied stringed instrument played upright between the knees, " +
                                            "with four strings tuned in perfect fifths.");
        }
        public void History()
        {
            Console.WriteLine($"History of {Name}: Developed in 16th-century Italy, the cello descends from early viols.");
        }
        public void MimickSound()
        {
            Console.WriteLine($"Sound of {Name}: \"Oom\", \"Moo\", or \"Humm\"");
        }
    }
}
