using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19._11._19_homework_dogs_and_horses
{
    class Horse : Animal
    {
        public override string Name { get; set; } = default;
        public bool RacingHorse { get; set; } = default;

        public override bool IsAnimal { get; set; } = true;

        public virtual Bitmap Picture
        {
            get
            {
                Bitmap image = (Bitmap)Image.FromFile("_Library/horse.jpg");
                return new Bitmap(image, new Size(image.Width / 3, image.Height / 3));
            }
            set { }
        }

        public Horse(string name, bool racingHorse) : base(name)
        {
            Name = name; RacingHorse = racingHorse;
        }


        public override void MakeSound()
        {
            Neight();
        }

        public virtual void Neight()
        {
            _mp3player.URL = "_Library/Horse Neigh-SoundBible.com-1740540960.mp3";
            _mp3player.controls.play();
        }

        public override string ToString()
        {
            return base.ToString();
        }


    }
}
