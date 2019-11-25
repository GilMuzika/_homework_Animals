using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace _19._11._19_homework_dogs_and_horses
{
    class Dog: Animal
    {
        public override string Name { get; set; } = default;


        public override bool IsAnimal { get; set; } = true;
        public virtual Bitmap Picture
        {
            get
            {
               Bitmap image = (Bitmap)Image.FromFile("_Library/Dog.jpg");
                return new Bitmap(image, new Size(image.Width / 3, image.Height / 3));
            }
            set {  }
        }

        public virtual string FavoriteDogFood { get; set; } = default;

        public Dog(string name, string favoriteFood): base(name)
        {
            Name = name;
            FavoriteDogFood = favoriteFood;
        }

        public override void MakeSound()
        {
            Bark();
        }

        public virtual void Bark()
        {
            _mp3player.URL = "_Library/labrador-barking-daniel_simon.mp3";
            _mp3player.controls.play();
        }

        public override string ToString()
        {
            return base.ToString();
        }


    }
}
