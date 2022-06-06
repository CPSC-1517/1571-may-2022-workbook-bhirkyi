using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview.Data
{
    public class Employment
    {
        //An instance of this class will hold data about a presons employment
        //This code of this class is the definition of that data
        //The charcteristics (data) of the class 
        // will be the follwing
        //Title, SupervisoryLevel, Years of employment within the company

        //there are 4 components of a class definiton
        //data fields(data members)
        //property
        // constructor
        // behaviour (method)

        //data fileds
        //are storage are in your class
        //these are treated as variables
        //these may be public, private , public readonly
        private string _Title;
        private double _Years;
        //property
        // theser are acces techniques to rtrieve or set data in your class with out directyl rouchign the strage data field
        
        //A property is associated with a single instance of data
        // A property is public so it can be acces by an outsider user of the class
        //A property must have a get 
        // A property might have a set
        // if no set the property is not changable by the user, its readonly
        //          commonly used for calculated data of the class
        //the set can be either public or private 
        // public the user cab alter tge contents of the data
        // private only code within the calls can alter the contents of the class

        //fully implemented property
        // a) a decalred storage area (data field)
        // b) a decalred property signature (acces rdt propertyname)
        // c) a coded accessor (get) method : public 
        // d) an optional coded mutator (set) method : public or private
        // if the set is private the only way to place data into this proerty is 
        // via teh constructor or a behavior (method)

        // When: 
        //a) if you are storing the associate data in an explicitly delcared data field
        //b) if you are doing validation on incoming data 
        //c) creating a property that generates output from other data sources with in the class(readonly property);
        // this property would only have a accesor(get)

        public string Title
        {
            // a property is assoicated with a single piece of data
            get
            {
                //accessor
                //the get "method" will return the contents of a data field(s)
                //the rutern has syntax of return expression
                return _Title;
            }
            set
            {
                //mutator 
                //the set "coding block or "method"" recives an incoming value and places it into the associated data field
                //during the setting you might wish to validate the incoming data 
                //during the seeting you might wish to do some type of logical processing using the data to set anoter field
                // the incoming piece of data is referred to using the keyword "value"

                // ensure that the incoming data is  not null or empty or just whitespace

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is a required piece of data.");
                }

                //data is consider valid 
                _Title = value;
            }



        }
            // auto implemented property

            //these properties differ only in syntax
            //each propery is responsible for a single piece of data
            // these properties do NOT reference a declared private data memeber
            // the system generates an internal storage area of the return data type
            //the system manages the internal storage for the accessor and mutator
            // THERE IS NO ADDITIONAL LOGIC APPLOED TO THE DATA VALUE
            
            //using enums for this field will automatically restric the values
            //this property can contain

            // syntax access return propertyname {get; [private]set;}
        public SupervisoryLevel Level { get; set; }

        public double Years
        {
            get { return _Years; }
            set 
            { 
                if(!Utilities.IsZeroPostive(value))
                {
                    throw new ArgumentOutOfRangeException($"Years value {value} is invalid. Must be 0 or greater.");
                }
                _Years = value;
            }
        }

        //constructor

        //this is used to initialize the physical object (instance) during its creation
        //the result of creation is tp ensure that the coder gets an instance in a valid "known state"
        //if your class definition has no construcotr coded the data memebers and/or aout implemnted properties are st to the C# default
        // data type value
        //You can code one or more consturocts in your class definition
        //IF YOU CODE A CONSTRUCOR FOR THE CLASS YOU ARE RESPONSIBVLE FOR ALL CONSTRUCOTRS USED BY THE CLASS
        
        //generally, if you are going to code your own constuctor(s) you code two types
        //Default: this contsructor does not take in any parameters
        //         this constructor mimics the default system construcor
        // Gready: this constucotr has a list of parameters, one for each proeprt, declared for incoming data

        //syntax: accesstype classname([list of parameters]) {consturctor code bloc}
        
        //IMPORTANT: The constructor DOES NOT have return datatype
        //           You DO NOT call a constructor directly, it is caleed using: new command => new classname(paremeter...);



        // Default constructor

        public Employment()
        {
            //consturctor body
            //a) it can be empty: values will be set to C# defualts
            //b) you could assign literal values to your properties with this constructor

            //The values that you give your class data memebers/properties CAN be assigned
            //  directly to a data memeber
            //HOWEVER: if you have validated properties you should consider saving your data values via the property

            //You can code your validation logic within your consturctors BECAUSE objects run your constructor when it is created
            //placing your logic in the constructor could be done if your property has a private set OR if your public data member is a 
            //readonly data member
            //Private sets and readonly data members CAN NOT have their data altered directly 
            Level = SupervisoryLevel.TeamMember;
            Title = "Unknown";
        }


        //Greedy Constructor
        public Employment(string title, SupervisoryLevel level, double years)
        {

            //constructor body
            //a) a oarameter for each property
            //b)You Could do your validation in this constructor
            //c) validation for public readonly data members MUST Be done here
            // d) validation for properties with a private set MUST  be done here if not done in the property 

            //default parameters
            //WHY? it allows tge prograner to use your constructor/method without having to specify all arguments in the code to your constructor/method
            //
            //Location: end of parameter list
            // How many: as many as you wish
            //values for your default parameters MUST be a valid value
            //position and order of specfied defalut parameters are important when the programer uses the construcor/method
            // default parameters CAN be skipped, HOWEVER, you still must account for the skipped parameters in your argument call list using commas
            //by giving the default parameter an argument value on the call, the construcor/method 
            //defalut balues is overridden
            //syntax: datatype parametername = deafult value
            //example: years on this constructor is a deafault parameter
            //example: skipped dafaults
            // (string requiredparam, int requiredparam, int default, int default 3
            // int deaflut2 = 0, int default 3 = 1)
            Title = title;
            Level = level;
            Years = years;//eventually the data will be place in _Years
        }
        //Behaviours (method)
        // a behavior is any method in your class
        // behaviours can be provate (for use by the class only); public (for use by the outside user)
        // all rules about methods are in effect
        // a special method may be placed in your class to reflect thed ata stored by the instance(object) vased on this class definition
        // this method is part of system software and can be overriden by your own 
        // version of the method

        public override string ToString()
        {
            //this string is known as a "comma seperate values (csv)" string
            return $"{Title},{Level},{Years}";
        }
        public void SetEmployeeResponsibilityLevel(SupervisoryLevel level)
        {
            //this method in this example would not be necessary as the access to directly
            // the level(property) is public (set; )
            // HOWEVER: IF the Level Property had a private set; the outside user would not have direct access to changing the property.
            //THERFORE: a method (besides the constructor) would need to be supplied to allow 
            // the outside user the ability to altrer the property value (if they so desired)

            //this assignment uses the set; of the property
            Level = level;
        }

        //Parse
        // attempt to change the contents of string to another data type
        // no conition was checked before doing the change
        // example string 55; int = x int.Parse(string); success
        //         string bob; int x = int.Parse(string);aborted

        //bool TryParse(string, out resultvariable)
        // check to see if the Parse could actualy be done 
        // the result of the attempt was
        //a) true and the converted string value place into the resultvariable
        //b) false and no conversion of the string AND no abort

        //int resultvariable = 0;
        // if(TryParse(string, out resultvariable)

        //Classes are a developer defined datatype just like int, double, ...
        //Therefore should a classs be avle to take a string can convert it into an instance of the class
        //Can a class have thier own .Parse and .TryParse

        //string: "Boss, Owner,5.5" parsed into an instance of Employment

        //Employment.Parse(string)
        //The method will:
        // validate there are sufficient values for an instance
        // will use primitive datatype .Parse() to conver the individual values
        // will return a loaded instance of the Employment class
        // will use the FormatExceotion() if insufficent data is supplied 

        //as the instance is loaded on the return statment, the Employment constructor
        // will be used thus any error generated by the constructor shall still be created

        //THIS METHOD WILL NOT RETAIN ANY DATA
        //THIS METHOD WILL BE A SHARED METHOD (static)
        public static Employment Parse(string text)
        {
            //text is a string of csv value(comma seperated values)
            // value1,value2,value3,....
            //Step 1 seperate the tstring of values into individual string values
            // the result will be an array of string
            //each array element represents a value
            //the string class method .Split(delimiter) is used for this action
            // a delimiter can be ANY C# recognized charcter
            // on csv string, the delimiter charcter is a comma
            string[] pieces = text.Split(',');

            //step 2 verife that sufficent values exist to creat the Employment instance
            if(pieces.Length != 3)
            {
                throw new FormatException($"String not in expected format.");
            }

            //step 3 return a new instance of the Employment class 
            //create a new instance on the return statement
            // as the instnace is being created, the Employment construocr will be used
            //Any validation occuring during the excution of the construcor will still be done, whether the logic is in the consturctor OR in the 
            //individual property
            //use the primiteve. Parese() methods for C# datatypes ie int, double.
            return new Employment(pieces[0], (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), pieces[1]), double.Parse(pieces[2]));

        }


        //TryParse() method will receive a string and output an instance of Employment as anoutput parameter

        //syntax of a .TryParse : xxxx.TryParse(string, out resivingvariable)
        // int example int.TryParse(inputData, out myIntegerNumber)

        //xxx can be any datatype

        //Can xxx be an class; yes why a class is developer defined datatype
        //the method will return a boolean value indicating if the action with
        // the method was succesful
        //the action within the method will be to call the .Parse() method
        //this is the same conspet of Parsing primitive datatypes alerady in C#

        public static bool TryParse(string text, out Employment result)
        {
            //why the value null
            //the default value for any class instance(the object) is null
            result = null;
            bool valid = false;
            try
            {
                if(string.IsNullOrWhiteSpace(text))
                {
                    throw new ArgumentNullException("Parsing string is empty");
                }
                //action: try to parse the string using .Parse()
                result=Parse(text);
                valid = true;
            }
            catch(FormatException ex)
            {
                //DO NOT PRINT OUT THE ERROR
                //INSTED re throw the excetpiton 
                //think of this as a rely race, passing the baton
                //this method DOES NOT actualy handle the display of the error  
                //the dispaly of an error message is done by the driver routine (in our case the code in Program.cs)
                throw new FormatException(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException(ex.Message);
            }
            catch (Exception ex)
            {
                //to handle any other unexpected error
                throw new Exception($"TryParse Employmen unexpected error: {ex.Message}");
            }
            return valid;
        }


    }
}
