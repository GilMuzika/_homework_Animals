using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19._11._19_homework_dogs_and_horses
{
    class Wolf: Dog
    {
        public override string Name { get; set; } = default;
        public override string FavoriteDogFood { get; set; } = default;
        public virtual string NameOfPack { get; set; } = default;
        public override Bitmap Picture
        {
            get
            {
                Bitmap image = (Bitmap)Image.FromFile("_Library/wolf.jpg");
                return new Bitmap(image, new Size(image.Width / 5, image.Height / 5));
            }
            set { }
        }

        public Wolf(string name, string favoriteDogFood, string nameOfPack): base(name, favoriteDogFood)
        {
            Name = name;
            FavoriteDogFood = favoriteDogFood;
            NameOfPack = nameOfPack;
        }

        public override void MakeSound()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
