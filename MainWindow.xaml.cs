using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> people = new ObservableCollection<Person>();
        public MainWindow()
        {
            InitializeComponent();
            people.Add(new WpfApplication1.Person("Dallin"));
            listView.ItemsSource = people;
        }

        //person add
        private void button_Click(object sender, RoutedEventArgs e)
        {
            people.Add(new WpfApplication1.Person(textBox.Text));
            Console.Out.WriteLine(people.Count);
            //listView.SourceUpdated();
        }

        //opinion add
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if(listView.SelectedIndex != -1)
            {
                float inVal;
                if (randomfeelingscheck.IsChecked == true)
                {
                    Random r = new Random();
                    inVal = (float)r.NextDouble();
                }
                else
                    inVal = (float)slider.Value;
                people[listView.SelectedIndex].addOpinion(topicbox.Text,inVal);
                tbupdate();
            }
        }

        private void listView_MouseUp(object sender, MouseButtonEventArgs e)
        {
            tbupdate();
        }
        public void tbupdate()
        {
            textBlock.Text = ((Person)listView.SelectedItem).ToString();
            textBlock.Text += "\n\n" + ((Person)listView.SelectedItem).opinionToString();
        }
    }
}
