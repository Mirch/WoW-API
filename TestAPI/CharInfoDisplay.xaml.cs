using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestAPI
{
    /// <summary>
    /// Interaction logic for CharInfoDisplay.xaml
    /// </summary>
    public partial class CharInfoDisplay : Window
    {
        public CharInfoDisplay(Character character)
        {
            InitializeComponent();
            Title = character.Name;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            charNameLabel.Content = character.Name;
            levelLabel.Content += character.Level.ToString();
            classLabel.Content += JsonStuff.GetClass(character.Class).Name;
            raceLabel.Content += JsonStuff.GetRace(character.Race).Name;
        }
    }
}
