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
            for (int i = 0; i < 10; i++)
            {
                foreach (Control s in this.Controls)
                {
                    if (s.Tag != null && s.Tag.Equals("!@#")) { s.Visible = false; this.Controls.Remove(s); }
                }
            }


            //Animal animal = _animals[cmbAllTheAnimals.SelectedIndex];
            Animal animal = (cmbAllTheAnimals.SelectedItem as ComboItem).Item as Animal;


             var allProperties =  (cmbAllTheAnimals.SelectedItem as ComboItem).ItemType.GetMethods();
            string propertyNames = string.Empty;
            foreach (var s in allProperties) propertyNames += $"{s.Name}\n";


            if((cmbAllTheAnimals.SelectedItem as ComboItem).ItemType.GetMethod("MakeSound") != null)
            {
                MethodInfo makeSound = (cmbAllTheAnimals.SelectedItem as ComboItem).ItemType.GetMethod("MakeSound");

                Button btnMakeSound = new Button();
                btnMakeSound.Tag = "!@#";
                btnMakeSound.Location = new Point(pbcAnimal.Location.X, this.ClientRectangle.Height - 50);
                btnMakeSound.AutoSize = true;
                Dictionary<string, string> dctAnimalSoungs = new Dictionary<string, string>();
                dctAnimalSoungs.Add("Dog", "barking");
                dctAnimalSoungs.Add("Horse", "neighing");
                dctAnimalSoungs.Add("Poodle", "barking");
                dctAnimalSoungs.Add("Wolf", "growling");

                ToolTip toolTip1 = new ToolTip();
                toolTip1.AutoPopDelay = 5000;
                toolTip1.InitialDelay = 1;
                toolTip1.ReshowDelay = 500;
                toolTip1.ShowAlways = true;
                toolTip1.IsBalloon = true;
                toolTip1.SetToolTip(btnMakeSound, "Please turn on your speakers");

                btnMakeSound.Text = $"The {(cmbAllTheAnimals.SelectedItem as ComboItem).ItemType.Name} {(cmbAllTheAnimals.SelectedItem as ComboItem).ItemType.GetProperty("Name")?.GetValue((cmbAllTheAnimals.SelectedItem as ComboItem).Item)} {dctAnimalSoungs[(cmbAllTheAnimals.SelectedItem as ComboItem).ItemType.Name]}";

                btnMakeSound.Click += (object sender2, EventArgs e2) => { makeSound?.Invoke((cmbAllTheAnimals.SelectedItem as ComboItem).Item, null); };

                this.Controls.Add(btnMakeSound);

                
            }


            if ((cmbAllTheAnimals.SelectedItem as ComboItem).ItemType.GetProperty("Picture") != null)
            {
                pbcAnimal.Width = ((cmbAllTheAnimals.SelectedItem as ComboItem).ItemType.GetProperty("Picture").GetValue((cmbAllTheAnimals.SelectedItem as ComboItem).Item) as Bitmap).Width;
                pbcAnimal.Height = ((cmbAllTheAnimals.SelectedItem as ComboItem).ItemType.GetProperty("Picture").GetValue((cmbAllTheAnimals.SelectedItem as ComboItem).Item) as Bitmap).Height;
                pbcAnimal.Image = (cmbAllTheAnimals.SelectedItem as ComboItem).ItemType.GetProperty("Picture").GetValue((cmbAllTheAnimals.SelectedItem as ComboItem).Item) as Bitmap;                
            }

            if ((cmbAllTheAnimals.SelectedItem as ComboItem).ItemType.GetProperty("Name") != null)
            {
                Label animalName = new Label();
                animalName.Location = new Point(pbcAnimal.Location.X, pbcAnimal.Location.Y + pbcAnimal.Height + 10);
                animalName.Text = (cmbAllTheAnimals.SelectedItem as ComboItem).ItemType.GetProperty("Name").GetValue((cmbAllTheAnimals.SelectedItem as ComboItem).Item).ToString();
                animalName.AutoSize = true;
                animalName.Tag = "!@#";
                this.Controls.Add(animalName);

                if ((cmbAllTheAnimals.SelectedItem as ComboItem).ItemType.GetProperty("RacingHorse") != null)
                {
                    string isRacing = string.Empty;
                    if (chkHorseIsRacing.Checked) isRacing = $" is a racing horse";
                    else isRacing = $" is't a racing horse";

                    animalName.Text += isRacing;
                }

            }

            if ((cmbAllTheAnimals.SelectedItem as ComboItem).ItemType.GetProperty("FavoriteDogFood") != null)
            {
                Label favoriteDogFood = new Label();
                favoriteDogFood.Location = new Point(pbcAnimal.Location.X, pbcAnimal.Location.Y + pbcAnimal.Height + 30);
                favoriteDogFood.Text = (cmbAllTheAnimals.SelectedItem as ComboItem).ItemType.GetProperty("FavoriteDogFood").GetValue((cmbAllTheAnimals.SelectedItem as ComboItem).Item).ToString();
                favoriteDogFood.Tag = "!@#";
                this.Controls.Add(favoriteDogFood);
            }

            if ((cmbAllTheAnimals.SelectedItem as ComboItem).ItemType.GetProperty("NumberOfPonyTail") != null)
            {
                Label numberOfPonyTails = new Label();
                numberOfPonyTails.Location = new Point(pbcAnimal.Location.X, pbcAnimal.Location.Y + pbcAnimal.Height + 60);
                numberOfPonyTails.AutoSize = true;
                numberOfPonyTails.Tag = "!@#";
                numberOfPonyTails.Name = "numberOfPonyTails";
                numberOfPonyTails.Text = (cmbAllTheAnimals.SelectedItem as ComboItem).ItemType.GetProperty("NumberOfPonyTail").GetValue((cmbAllTheAnimals.SelectedItem as ComboItem).Item).ToString();
                this.Controls.Add(numberOfPonyTails);                
            }

            if ((cmbAllTheAnimals.SelectedItem as ComboItem).ItemType.GetProperty("NameOfPack") != null)
            {
                Label nameOfPack = new Label();
                nameOfPack.Location = new Point(pbcAnimal.Location.X, pbcAnimal.Location.Y + pbcAnimal.Height + 60);
                nameOfPack.AutoSize = true;
                nameOfPack.Tag = "!@#";
                nameOfPack.Name = "nameOfPack";
                nameOfPack.Text = (cmbAllTheAnimals.SelectedItem as ComboItem).ItemType.GetProperty("NameOfPack").GetValue((cmbAllTheAnimals.SelectedItem as ComboItem).Item).ToString();
                this.Controls.Add(nameOfPack);                
            }

               //MessageBox.Show(propertyNames);
     
            pbcAnimal.Visible = true;
            


            



            





        }

        private void cmbCreateNewAnimal_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (Control s in this.Controls)
            {
                //if (s.Tag != null && s.Tag.Equals("!@#")) { this.Controls.Remove(s); }
                if (s.Tag != null && s.Tag.Equals("leftInterface")) s.Visible = false;
            }
            lblAnimalName.Visible = true; txtAnimalName.Visible = true;

            switch(cmbCreateNewAnimal.SelectedIndex)
            {
                case 0:
                    lblDogFavoriteDogFood.Visible = true; txtDogFavoriteDogFood.Visible = true;
                    txtAnimalName.Text = "Doggy";
                    txtDogFavoriteDogFood.Text = "PediGree Pal";
                    break;
                case 1:
                    lblHorseIsRacing.Visible = true; chkHorseIsRacing.Visible = true;
                    txtAnimalName.Text = "Black Moon";
                    chkHorseIsRacing.Checked = true;
                    break;
                case 2:
                    lblDogPoodleNumberOfPonyTails.Visible = true; numDogPoodleNumberOfPonyTails.Visible = true;
                    lblDogFavoriteDogFood.Visible = true; txtDogFavoriteDogFood.Visible = true;
                    txtAnimalName.Text = "Toy-Toy";
                    txtDogFavoriteDogFood.Text = "FoodForPoodles";
                    numDogPoodleNumberOfPonyTails.Value = 10;
                    break;
                case 3:
                    lblDogWolfNameOfPack.Visible = true; txtDogWolfNameOfPack.Visible = true;
                    lblDogFavoriteDogFood.Visible = true; txtDogFavoriteDogFood.Visible = true;
                    txtAnimalName.Text = "Grey NightMare";
                    txtDogFavoriteDogFood.Text = "my prey, my game";
                    txtDogWolfNameOfPack.Text = "Wolves of Tambov";
                    break;
            }
            
        }

    }
}
