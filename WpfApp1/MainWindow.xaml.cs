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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // list for allactivites to be displayed
        List<Activity> AllActivities = new List<Activity>();
        // list for selected activities that are going to be moved from one listbox to the other.
        List<Activity> SelectedActivities = new List<Activity>();
        //filters the activities
        List<Activity> filteredActivities = new List<Activity>();

        public decimal totalcost = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        // runs on start up
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //creating the activities

            //land
            Activity l1 = new Activity("Treking", new DateTime(2019, 06, 01), 20, "Instructor led group trek through local mountains.", TypeOfActivity.Land);
            Activity l2 = new Activity("Mountain Biking", new DateTime(2019, 06, 02), 30, "Instructor led half day mountain biking. All equipment provided.", TypeOfActivity.Land);
            Activity l3 = new Activity("Absailing", new DateTime(2019, 06, 03), 40, "Experience the rush of adrenaline as you descend cliff faces from 10-500m.", TypeOfActivity.Land);
            //water
            Activity w1 = new Activity("Kayaking", new DateTime(2019, 06, 01), 40, "Half day lakeland kayak with island picnic.", TypeOfActivity.Water);
            Activity w2 = new Activity("Surfing", new DateTime(2019, 06, 02), 25, "2 hour surf lesson on the wild atlantic way", TypeOfActivity.Water);
            Activity w3 = new Activity("Sailing", new DateTime(2019, 06, 03), 25, "Full day lakeland sailing with island picnic.", TypeOfActivity.Water);
            //air
            Activity a1 = new Activity("Parachuting", new DateTime(2019, 06, 01), 100, "Experience the thrill of free fall while you tandem jump from an airplane.", TypeOfActivity.Air);
            Activity a2 = new Activity("Hang Gliding", new DateTime(2019, 06, 02), 80, "Soar on hot air currents and enjoy spectacular views of the coastal region.", TypeOfActivity.Air);
            Activity a3 = new Activity("Helicopter Tour", new DateTime(2019, 06, 03), 200, "Experience the ultimate in aerial sight-seeing as you tour the area in our modern helicopters", TypeOfActivity.Air);

            // Add to list
            //activities added to the all activities list
            AllActivities.Add(l1);
            AllActivities.Add(l2);
            AllActivities.Add(l3);
            AllActivities.Add(w1);
            AllActivities.Add(w2);
            AllActivities.Add(w3);
            AllActivities.Add(a1);
            AllActivities.Add(a2);
            AllActivities.Add(a3);

            AllActivities.Sort();

            //display in the listbox

            //sets the source for the list box to the all activities list
            lbxActivities.ItemsSource = AllActivities;
        }

        // runs when the add ( >> ) button is clicked 
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //finds which items have been selected
            Activity selectedActivity = lbxActivities.SelectedItem as Activity;

                     

            // null check
            if (selectedActivity != null)
            {
                // moves an activity from the left listbox to  the right listox when the add 
                //( >> ) button is clicked and an activity is selected
                AllActivities.Remove(selectedActivity);
                SelectedActivities.Add(selectedActivity);
                //shows the total cost for all selected activities.

                totalcost += selectedActivity.Cost;
                txtTotalcost.Text = "Total Cost: " + totalcost;
                //shows the description for the selected activity
                txtDescription.Text = selectedActivity.Description + " cost - " + selectedActivity.Cost;


                // refreshes the lists
                refreshLists();
                //sorts by date when they are moved from box to box
                SelectedActivities.Sort();


            }
            else
            {
                MessageBox.Show("Please select an activity");
            }



        }
        // runs when the remove ( << ) button is clicked
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            
            //finds which items have been selected
            Activity selectedActivity = lbxSelected.SelectedItem as Activity;

            //null check
            if (selectedActivity != null)
            {
                AllActivities.Add(selectedActivity);
                SelectedActivities.Remove(selectedActivity);
                totalcost -= selectedActivity.Cost;
                txtTotalcost.Text = "Total Cost: " + totalcost;
                //refreshes the lists
                refreshLists();
                //sorts by date when they are moved from box to box
                AllActivities.Sort();
            }
            else
            {
                MessageBox.Show("Please select an activity");
            }

        }

        // method to refresh the lists.
        private void refreshLists()
        {

            lbxActivities.ItemsSource = null;
            lbxActivities.ItemsSource = AllActivities;

            lbxSelected.ItemsSource = null;
            lbxSelected.ItemsSource = SelectedActivities;

        }

        //deals with all the radiobuttons
        private void rbAll_Click(object sender, RoutedEventArgs e)
        {
            filteredActivities.Clear();

            if (rbAll.IsChecked == true)
            {
                //list box displays all activities
                refreshLists();
            }
            else if (rbLand.IsChecked == true)
            {
                //list box will display only land activities
                foreach (Activity activity in AllActivities)
                {
                    if (activity.ActivityType == TypeOfActivity.Land)
                    {
                        filteredActivities.Add(activity);

                        lbxActivities.ItemsSource = null;
                        lbxActivities.ItemsSource = filteredActivities;
                    }
                }
            }
            else if (rbWater.IsChecked == true)
            {
                //lisbox will display only water activities 
                foreach (Activity activity in AllActivities)
                {
                    if (activity.ActivityType == TypeOfActivity.Water)
                    {
                        filteredActivities.Add(activity);

                        lbxActivities.ItemsSource = null;
                        lbxActivities.ItemsSource = filteredActivities;

                    }
                }
            }
            else if (rbAir.IsChecked == true)
            {
                //list box will display only air
                foreach (Activity activity in AllActivities)
                {
                    if (activity.ActivityType == TypeOfActivity.Air)
                    {

                        filteredActivities.Add(activity);

                        lbxActivities.ItemsSource = null;
                        lbxActivities.ItemsSource = filteredActivities;
                    }

                }

            }

        }
    }
}
