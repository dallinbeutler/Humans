using RandomNameGeneratorLibrary;
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
            //people.Add(new WpfApplication1.Person("Dallin"));
            listView.ItemsSource = people;
            comboBox.ItemsSource = people;
            
        }

        //person add
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (randNameCheck.IsChecked == false)
                people.Add(new WpfApplication1.Person(textBox.Text));
            else
            {
                var personGenerator = new PersonNameGenerator();
                if (gendercheck.IsChecked == true)
                    people.Add(new WpfApplication1.Person(personGenerator.GenerateRandomMaleFirstAndLastName()));
                else
                    people.Add(new WpfApplication1.Person(personGenerator.GenerateRandomFemaleFirstAndLastName()));
            }

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
                    inVal = (float)(r.NextDouble()*2) -1;
                }
                else
                    inVal = (float)slider.Value;
                people[listView.SelectedIndex].addOpinion(topicbox.Text,inVal);
                tbupdate(0);
            }
        }

        private void listView_MouseUp(object sender, MouseButtonEventArgs e)
        {
            tbupdate(0);
        }
        public void tbupdate(int first)
        {
            if(first == 0) { 
                textBlock.Text = ((Person)listView.SelectedItem).ToString();
                textBlock.Text += "\n\n" + ((Person)listView.SelectedItem).opinionToString();
            }
            else
                otherinfobox.Text = ((Person)comboBox.SelectedItem).ToString();
                otherinfobox.Text += "\n\n" + ((Person)comboBox.SelectedItem).opinionToString();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedIndex != -1)
            {
                foreach (Opinion op in people[listView.SelectedIndex].opinions)
                {
                    foreach(Person p in people)
                    {
                        if (!p.Equals(people[listView.SelectedIndex]))
                        {
                            foreach (Opinion opp in p.opinions)
                            {
                                interact(people[listView.SelectedIndex], p, op, opp);
                            }
                        }
                    }
                }
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            tbupdate(1);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            foreach (Opinion op in people[listView.SelectedIndex].opinions)
            {
                foreach (Opinion op2 in people[comboBox.SelectedIndex].opinions)
                {

                    interact(people[listView.SelectedIndex], people[comboBox.SelectedIndex], op, op2);

                }
            }
        }//button



        void interact(Person p1, Person p2, Opinion o1, Opinion o2)
        {
            if (o1.topic == o2.topic)
            {
                float changeThis = o2.feelings * p2.charisma * p1.malleability;
                float changeOther = o1.feelings * p1.charisma * p2.malleability;
                o1.feelings += changeThis;
                o1.feelings += changeOther;
                myConsole.Text += "\n" + people[listView.SelectedIndex].name +
                    "(" + changeThis + ") interacted with " + people[comboBox.SelectedIndex].name +
                    "(" + changeOther + ") about " + o1.topic;
                tbupdate(0);
                tbupdate(1);
            }
        }
    }//class
}//workspace
