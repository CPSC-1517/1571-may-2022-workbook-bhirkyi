using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview.Data
{
    public class Person
    {
        //example of a composite class 
        //a composite class uses ohter classes/structs in its definition
        //a conposite class is reconized with the phrase "has a " class
        //this class of Person has a resedient address
        //this class has a  List<T> where <T> represents a datatype and in this 
        //class <T> is a collection of Employment instances

        //each instance of this class will represent an individual
        //this class will define the following characteristics of a person
        //FirstName, LastName, the current resident addressm List of employment positions


        private string _FirstName;
        private string _LastName;

        public string FirstName
        {
            get { return _FirstName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First Name is required");
                }
                _FirstName = value;
            }
        }


        public string LastName
        {
            get { return _LastName; }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last Name is required");
                }
                _LastName = value;
            }
        }

        //composition actually uses the other struct/class as a property/field within the defintion of the class being specified(created)
        //in this exampel Addrss is a field (data member)

        //this fields is not a property
        //the data type is a developer defined data type (struct)

        public ResidentAddress Address;

        public List<Employment> EmploymentPositions { get; private set; }

        //this propery will compile cleanly
        // this property will ruen a vlaue IF EmploymentPositions has a Instance  of List<T>
        //this property will abort IF EmploymentPositions has not be set to an isntance of List<T>

        public int NumberOfPositions { get { return EmploymentPositions.Count; }}

        //public Person()
        //{
        //    //the system will automatically assign default system values to out data members accordingly to there datatype 

        //    //string -> null
        //    //objects -> null

        //    //FirstName and LastName has validation voiding a null value
        //    FirstName = "Unknown";
        //    LastName = "Unknown";
        //    //if one tried to reference an instance data and thei isntace is null then one would get a exception: null excepition
        //    //even though you have no instances to store, you will at least have someplace to put data ONCe its supplied
        //    EmploymentPositions = new List<Employment>();

        //}

        //Option 2
        //DO not code a "default" constructor
        //Code only "Greedy" constructor 
        //If only a greedy constucotir exists for the class the only way to possibly create an instance for the class within
        // the program would be to use the construcotr when he class
        //instance is created

        public Person(string firstname, string lastname, ResidentAddress address, List<Employment> employmentpositions)
        {
            FirstName = firstname;
            LastName = lastname;
            Address = address;
            if(employmentpositions != null)
                EmploymentPositions = employmentpositions;

            //allow a null value and the class to have an empty List<T>
            else
                EmploymentPositions = new List<Employment>();
        }

        public void ChangeName(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }
        public void AddEmployment(Employment employment)
        {
            if(employment == null)
            {
                throw new ArgumentNullException("You must supply an employment record for it to be added to this person");
            }
            EmploymentPositions.Add(employment);
        }
    }
}

