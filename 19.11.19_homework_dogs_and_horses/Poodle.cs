using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19._11._19_homework_dogs_and_horses
{
    class Poodle: Dog
    {
        public override string Name { get; set; } = default;
        public override string FavoriteDogFood { get; set; } = default;

        public virtual int NumberOfPonyTail { get; set; } = default;

        public override Bitmap Picture
        {
            get
            {
                Bitmap image = (Bitmap)Image.FromFile("_Library/poodle.jpg");
                return new Bitmap(image, new Size(image.Width / 3, image.Height / 3));
            }
            set { }
        }

        public Poodle(string name, string favoriteDogFood, int numberOfPonyTail): base(name, favoriteDogFood)
        {
            Name = name;
            FavoriteDogFood = favoriteDogFood;
            NumberOfPonyTail = numberOfPonyTail;
        }


        public override void Bark()
        {
            _mp3player.URL = "_Library/small-dog-barking_daniel-simion.mp3";
            _mp3player.controls.play();
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
