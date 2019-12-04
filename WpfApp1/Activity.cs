using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    //enum for each type of activity
    public enum TypeOfActivity {Air,Water,Land}

    class Activity : IComparable<Activity>
    {
        //props
        public string Name { get; set; }
        public DateTime ActivityDate { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public TypeOfActivity ActivityType { get; set; }


        //ctors
        public Activity(string name, DateTime activityDate, decimal cost, string description, TypeOfActivity activityType)
        {
            Name = name;
            ActivityDate = activityDate;
            Cost = cost;
            Description = description;
            ActivityType = activityType;
        }

        //methods

        public override string ToString()
        {
            return $"{Name} - {ActivityDate.ToShortDateString()}";
        }

        public int CompareTo(Activity other) 
        {
            return this.ActivityDate.CompareTo(other.ActivityDate);
        }


    }


}
