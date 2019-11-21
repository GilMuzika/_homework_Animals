using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19._11._19_homework_dogs_and_horses
{
    public partial class Form1 : Form
    {
   
        
        public Form1()
        {
            InitializeComponent();
            createAnimal();
            initialiseControls();
        }

        private void initialiseControls()
        {
            cmbCreateNewAnimal.Items.AddRange(GetAnimalClasses().Select(x => (object)x.Name).ToArray());
            cmbCreateNewAnimal.SelectedIndex = 0;
        }

        private ComboItem createAnimal()
        {



            string name = txtAnimalName.Text;
            string favoriteDogFood = txtDogFavoriteDogFood.Text;
            bool isRacingHorse = chkHorseIsRacing.Checked;
            int numberOfPonyTails = (int)numDogPoodleNumberOfPonyTails.Value;
            string nameOfPack = txtDogWolfNameOfPack.Text;

            ComboItem item = null;

            switch (cmbCreateNewAnimal.SelectedIndex)
            {
                case 0: //Dog
                    item = new ComboItem(Activator.CreateInstance(GetAnimalClasses()[cmbCreateNewAnimal.SelectedIndex], name, favoriteDogFood) as Dog, GetAnimalClasses()[cmbCreateNewAnimal.SelectedIndex]);                    
                    break;
                case 1: //Horse
                    item = new ComboItem(Activator.CreateInstance(GetAnimalClasses()[cmbCreateNewAnimal.SelectedIndex], name, isRacingHorse) as Horse, GetAnimalClasses()[cmbCreateNewAnimal.SelectedIndex]);
                    break;
                case 2: //Poodle
                    item = new ComboItem(Activator.CreateInstance(GetAnimalClasses()[cmbCreateNewAnimal.SelectedIndex], name, favoriteDogFood, numberOfPonyTails) as Poodle, GetAnimalClasses()[cmbCreateNewAnimal.SelectedIndex]);
                    break;
                case 3: //Wolf
                    item = new ComboItem(Activator.CreateInstance(GetAnimalClasses()[cmbCreateNewAnimal.SelectedIndex], name, favoriteDogFood, nameOfPack) as Wolf, GetAnimalClasses()[cmbCreateNewAnimal.SelectedIndex]);
                    break;
            }


            return item;
        }








        Type[] GetAnimalClasses()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            return asm.GetTypes()
                .Where(type => type.Namespace == this.GetType().Namespace && type.GetProperty("IsAnimal") != null && type.IsAbstract == false)
                .ToArray();
        }



        private void btnCreateAnimal_Click(object sender, EventArgs e)
        {
            cmbAllTheAnimals.Items.Add(createAnimal());
        }

        private void cmbAllTheAnimals_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Animal animal = _animals[cmbAllTheAnimals.SelectedIndex];
            Animal animal = (cmbAllTheAnimals.SelectedItem as ComboItem).Item as Animal;

            switch ((cmbAllTheAnimals.SelectedItem as ComboItem).ItemType.Name)
            {
                
                case "Dog":
                    animal = ((cmbAllTheAnimals.SelectedItem as ComboItem).Item) as Dog;
                    pbcAnimal.Width = (animal as Dog).Picture.Width;
                    pbcAnimal.Height = (animal as Dog).Picture.Height;
                    pbcAnimal.Image = (animal as Dog).Picture;

                    Label dogName = new Label();
                    dogName.Location = new Point(pbcAnimal.Location.X, pbcAnimal.Location.Y + pbcAnimal.Height + 10);
                    dogName.Text = (animal as Dog).Name;
                    this.Controls.Add(dogName);

                    Label favoriteDogFood = new Label();
                    favoriteDogFood.Location = new Point(dogName.Location.X, dogName.Location.Y + dogName.Height + 5);
                    favoriteDogFood.Text = (animal as Dog).FavoriteDogFood;
                    this.Controls.Add(favoriteDogFood);


                    break;
                case "Horse":
                    animal = ((cmbAllTheAnimals.SelectedItem as ComboItem).Item) as Horse;
                    pbcAnimal.Width = (animal as Horse).Picture.Width;
                    pbcAnimal.Height = (animal as Horse).Picture.Height;
                    pbcAnimal.Image = (animal as Horse).Picture;

                    string isRacing = string.Empty;
                    if (chkHorseIsRacing.Checked) isRacing = $" is a racing horse";
                    else isRacing = $" is't a racing horse";

                    Label horseName = new Label();
                    horseName.AutoSize = true;
                    horseName.Location = new Point(pbcAnimal.Location.X, pbcAnimal.Location.Y + pbcAnimal.Height + 10);
                    horseName.Text = $"{(animal as Horse).Name}, {isRacing}";
                    this.Controls.Add(horseName);



                    break;
                case "Poodle":
                    animal = ((cmbAllTheAnimals.SelectedItem as ComboItem).Item) as Poodle;
                    pbcAnimal.Width = (animal as Poodle).Picture.Width;
                    pbcAnimal.Height = (animal as Poodle).Picture.Height;
                    pbcAnimal.Image = (animal as Poodle).Picture;


                    Label poodleName = new Label();
                    poodleName.Location = new Point(pbcAnimal.Location.X, pbcAnimal.Location.Y + pbcAnimal.Height + 10);
                    poodleName.Text = (animal as Poodle).Name;
                    this.Controls.Add(poodleName);

                    Label favoritePoodleFood = new Label();
                    favoritePoodleFood.Location = new Point(poodleName.Location.X, poodleName.Location.Y + poodleName.Height + 5);
                    favoritePoodleFood.Text = (animal as Dog).FavoriteDogFood;
                    this.Controls.Add(favoritePoodleFood);

                    Label numberOfPonyTails = new Label();
                    numberOfPonyTails.Location = new Point(favoritePoodleFood.Location.X, favoritePoodleFood.Location.Y + favoritePoodleFood.Height + 5);
                    numberOfPonyTails.Text = (animal as Poodle).NumberOfPonyTail.ToString();
                    this.Controls.Add(numberOfPonyTails);

                    break;
                case "Wolf":
                    animal = ((cmbAllTheAnimals.SelectedItem as ComboItem).Item) as Wolf;
                    pbcAnimal.Width = (animal as Wolf).Picture.Width;
                    pbcAnimal.Height = (animal as Wolf).Picture.Height;
                    pbcAnimal.Image = (animal as Wolf).Picture;

                    Label wolfName = new Label();
                    wolfName.Location = new Point(pbcAnimal.Location.X, pbcAnimal.Location.Y + pbcAnimal.Height + 10);
                    wolfName.Text = (animal as Wolf).Name;
                    this.Controls.Add(wolfName);

                    Label favoriteWolfFood = new Label();
                    favoriteWolfFood.Location = new Point(wolfName.Location.X, wolfName.Location.Y + wolfName.Height + 5);
                    favoriteWolfFood.Text = (animal as Wolf).FavoriteDogFood;
                    this.Controls.Add(favoriteWolfFood);

                    Label nameOfPack = new Label();
                    nameOfPack.Location = new Point(favoriteWolfFood.Location.X, favoriteWolfFood.Location.Y + favoriteWolfFood.Height + 5);
                    nameOfPack.Text = (animal as Wolf).NameOfPack;
                    this.Controls.Add(nameOfPack);

                    break;


            }
            



            pbcAnimal.Visible = true;
            


            



            





        }

        private void cmbCreateNewAnimal_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            switch(cmbCreateNewAnimal.SelectedIndex)
            {
                case 0:
                    
                    chkHorseIsRacing.Visible = false;
                    numDogPoodleNumberOfPonyTails.Visible = false;
                    txtDogWolfNameOfPack.Visible = false;
                    break;
                case 1:
                    txtDogFavoriteDogFood.Visible = false;
                    numDogPoodleNumberOfPonyTails.Visible = false;
                    txtDogWolfNameOfPack.Visible = false;
                    break;
                case 2:
                    chkHorseIsRacing.Visible = false;
                    numDogPoodleNumberOfPonyTails.Visible = false;
                    txtDogWolfNameOfPack.Visible = false;
                    break;
                case 3:
                    chkHorseIsRacing.Visible = false;
                    numDogPoodleNumberOfPonyTails.Visible = false;
                    break;
            }
            */
        }
    }
}
