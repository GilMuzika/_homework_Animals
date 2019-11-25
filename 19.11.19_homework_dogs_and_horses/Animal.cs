using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _19._11._19_homework_dogs_and_horses
{
    abstract class Animal
    {
        protected WMPLib.WindowsMediaPlayer _mp3player = new WMPLib.WindowsMediaPlayer();
        public virtual string Name { get; set; } = default;

        public virtual bool IsAnimal { get; set; } = false;

        public Animal(string name)
        {
            this.Name = name;
        }

        public abstract void MakeSound();

        public override string ToString()
        {
            FieldInfo[] fieldsinfo = this.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            PropertyInfo[] propertiesinfo = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo[] methodsinfo = this.GetType().GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            string fields = string.Join("", fieldsinfo.Select(x => $"{x.Name}: {x.GetValue(this)}\n"));
            string properties = string.Join("", propertiesinfo.Select(x => $"{x.Name}: {x.GetValue(this)}\n"));
            //string methods = string.Join("", methodsinfo.Select(x => $"{x.Name}: {x.Invoke(this, null)}\n"));

            return fields + properties;// + methods;
        }

        
    }
}
