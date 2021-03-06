// See https://aka.ms/new-console-template for more information

//this class is by deafult in the namespace of the porjecrt:OOPsReview
using OOPsReview.Data;
using System.Text.Json;

//Conosle is a static class
//you cant not create your own instance of a static class

//Console.WriteLine("Hello, World!");

//an instance class needs to be created using teh new command and the class constructor
//one needs to declare a variable of datatype Employment

Employment myEmp = new Employment("Level 5 Programer", SupervisoryLevel.Supervisor, 15.9);// default constructor
Console.WriteLine(myEmp.ToString());// use the instance name to referance items within your class
Console.WriteLine($"{myEmp.Title},{myEmp.Level},{myEmp.Years}");

//                                    ARGUMENT 
myEmp.SetEmployeeResponsibilityLevel(SupervisoryLevel.DepartmentHead);
Console.WriteLine(myEmp.ToString());



//testing (simulate a Unit test )
//Unit test: 
//a) Arrange(setup of your test data)
Employment Job = null;

//passing a refernce of variable to a method
// a class is a refernce data store
//this passes the actual memory address of the data store to the method
//ANY changes done to the data store within the method will be reflected in the data store WHEN you return from the method

CreateJob( ref Job);
Console.WriteLine(Job.ToString());
//passing values arguments to a method AND receiving a value result back from the method 
//struct is a value data store
ResidentAddress Address = CreateAddress();
Console.WriteLine(Address.ToString());


//b) Act (execution of test you wish to preform)
//test that we can creata a Person (composite instance)
Person me = null;// a varible capable of holding a Person instance
me = CreatePerson(Job, Address);

//OR
//Person me = CreatePerson(Job, Address);


//c)Access (check your results)
Console.WriteLine($"{me.FirstName},{me.LastName}, lives at {me.Address.ToString()},having a job count of  {me.NumberOfPositions}");
Console.WriteLine("Jobs: output via foreach loop");
foreach (var item in me.EmploymentPositions)
{
    Console.WriteLine(item.ToString());
}

Console.WriteLine("Jobs: output via for loop");
for (int i = 0; i < me.EmploymentPositions.Count; i++)
{
    Console.WriteLine(me.EmploymentPositions[i].ToString());
}


//using Employment.Parse

string theRecord = "Boss, Owner, 5.5";

Employment theParsedRecord = Employment.Parse(theRecord);
Console.WriteLine(theParsedRecord.ToString());

//using Employment.TryParse
theParsedRecord = null;
if (Employment.TryParse(theRecord, out theParsedRecord))
{
    //do whatever logic you need to do with the valid data
    Console.WriteLine(theRecord.ToString());

}
//if the TryParse failed you would be handling it via your user findly error handling code

//File I/O

//writing a comma sperated value file

//string pathname = WriteCSVFile();

//read a comma separeted value file
const string PATHNAME = "../../../Employment.csv";
const string JSONPATHNAME = "../../../Employment.json";
List<Employment> jobs = ReadCSVFile(PATHNAME);
Console.WriteLine($"Results of reading the csv file at : {PATHNAME}");
foreach(Employment job in jobs)
{
    Console.WriteLine($"Title:{job.Title} Level: {job.Level} Year: {job.Years}");
}

//writing a JSON file
//me is built above
SaveAsJason(me, JSONPATHNAME);
//Read a JSON file
Person jsonME = ReadAsJson(JSONPATHNAME);
Console.WriteLine("Output from reading a json file:");
Console.WriteLine($"{jsonME.FirstName},{jsonME.LastName}, lives at {jsonME.Address.ToString()},having a job count of  {jsonME.NumberOfPositions}");
Console.WriteLine("Jobs: output via foreach loop");
foreach (var item in jsonME.EmploymentPositions)
{
    if(item.Years >0)
    Console.WriteLine(item.ToString());
}

Console.WriteLine("Jobs: output via for loop");



void CreateJob(ref Employment job)
{
    //sicnce the class may throw exections, you should have user friednly error handling
    try
    {
        job = new Employment();//deafult constructor; new command takes a constuctor as its reference
        //Because my properties have public set(mutators), I can set the values of the property from diver program
        job.Title = "Boss";
        job.Level = SupervisoryLevel.Owner;
        job.Years = 25.5;

        //OR
        //user the greedy constructor
        //job = new Employment("Boss", SupervisoryLevel.Owner, 25.5);



    }
    catch (ArgumentNullException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch(ArgumentOutOfRangeException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

ResidentAddress CreateAddress()
    {
        ResidentAddress address = new ResidentAddress(10706, "106 st", "", "", "Edmonton", "AB");
        return address;
    }

Person CreatePerson (Employment job, ResidentAddress address)
{
    //Person me = new Person("Bohdan", "Hirkyi",address, null);
    //one could add the jobs to the instance of Person (me) after the instance is created via the nehaviout AddEmployment(Employment emp)
    //me.AddEmployment(job);

    //OR
    //one could creat a List<T> and add to the list<T> before creating the PErson instance
    List<Employment> employments = new List<Employment>();// Create the List<T> instance
    employments.Add(job);//Add an element to the List<T>
    Person me = new Person("Bohdan", "Hirkyi", address, employments); // using greedy constractor 

    //create additional jobs and load to Person
    Employment employment = new Employment("New Hire", SupervisoryLevel.Entry, 0.6);
    me.AddEmployment(employment);

    employment = new Employment("Team Head", SupervisoryLevel.TeamLeader, 5.2);
    me.AddEmployment(employment);

    employment = new Employment("Department IT Head", SupervisoryLevel.DepartmentHead, 6.8);
    me.AddEmployment(employment);
    return me;
}

string WriteCSVFile()
{
    string pathname = "";
    try
    {
        List<Employment> jobs = new List<Employment>();
            jobs.Add(new Employment("trainee", SupervisoryLevel.Entry, 0.5));
            jobs.Add(new Employment("worker", SupervisoryLevel.TeamLeader, 3.5));
            jobs.Add(new Employment("lead", SupervisoryLevel.TeamLeader, 7.4));
            jobs.Add(new Employment("dh new projects", SupervisoryLevel.DepartmentHead, 1.0));

        //create a list of comma seperated value strings
        //the contents of each string will be 3 values of Employment
        List<string> csvline = new();

        //place all the instances of Employmnent in the collection of jobs
        // in the csvlibes using .ToString() of Employment Class

        foreach (var item in jobs)
        {
            csvline.Add(item.ToString());  
        }
        //write to a text file the csv lines
        //each line represents a Employment instance
        //you could use StreamWriter
        //HOWEEVER WITHIN THE FILE CLASS TEHRE IS A METHOD THAT OUTPUTS A LIST OF STRINGS ALLL with ONE COMMAND.
        //There is no need for Streamwriter isntance.
        //the path name is the minimum for the command
        //the file by default will be created in the same folder as your .exe file
        //YOU can alter the path name using relative addressing

        pathname = "../../../Employment.csv";
        File.WriteAllLines(pathname, csvline);
        Console.WriteLine($"check out the CSV file at: {Path.GetFullPath(pathname)}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    return Path.GetFullPath(pathname);
}

List<Employment> ReadCSVFile(string pathname)
{
    List<Employment> employments = new List<Employment>();
    //use this variuble repeatedly to hold a new instance of Employment
    // as i read and Parse the CSV file.
    Employment job = null;
    //this try/catch error handling is for system I/O errors while reading the file
    try
    {
        //Read the CSV file using File.ReadAllLines()
        //thus No need to creat a StreamReader.
        //ReadAllLines returns an aaray of strings each string representing one line in your CSV file
        string[] csvFileInput = File.ReadAllLines(pathname);


        //process EACH line in the file
        foreach(string csvLine in csvFileInput)
        {
            //as you process each line we will use the TryParse of Employment
            // this will return an instance of Employment IF the data is valid 
            //IF data is not valid Employment will throw various errors
            //we DO NOT want to stop processing the strings IF an error is discovered
            //THEREFORE we WILL have a try/catch WITHIN this loop
            try
            {
                //attempt to convert a comma separate value string into an instance of Employment(parse the data)
                bool converted = Employment.TryParse(csvLine, out job);
                //test if the parsing was successful
                //the way this logic is set up, the testing is unnecessary
                //why? IF THE PARSE FAILS AN ERROR WOULD HAVE BE THROWN
                //thus processing will have jumped to a catch
                //why do the test then
                //consider that on a successful parse you may have additional logic to perform.
                if(converted)
                {
                    employments.Add(job);
                }
            }
            catch(FormatException ex)
            {
                Console.WriteLine($"Format error: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Argument error: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Out of Range error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown error: {ex.Message}");
            }

        }


    }
    catch(IOException ex)
    {
        Console.WriteLine($"Reading CSV file error: {ex.Message}");
    }
    catch(Exception gnrl)
    {
        Console.WriteLine(gnrl.Message);
    }
    return employments;
}

void SaveAsJason(Person me, string pathname)
{
    // the term use to read and wite Json files is Serialization
    //the ckasses use are referred to as serializers
    //with writing we can make the file produce more readable format by using indentation
    //Json is very good at using objects and properties however it
    // needs help/promptaing to work better with fields: options INcludeFields
    // the term Serialize is generally used to indicate writing
    //instance instatiation 
    JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true,
        IncludeFields = true
    };
    try
    {
        //Serialize the instance of Person
        //produce a string of serialized data 
        string jsonstring = JsonSerializer.Serialize<Person>(me, options);
        //output the Json string to your file indicated in the path
        //use WriteAllText here because there is ONLY a SINGLE line of text unlike writing a csv file which has an array of strings (WriteAllLines)
        File.WriteAllText(pathname, jsonstring);
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

Person ReadAsJson(string pathname)
{
    Person person = null;
    try
    {
        //bring in the text form the file
        string jsonstring = File.ReadAllText(pathname);
        // use the deserializer to unpack the json string into
        // the expected structure <Person>
        person = JsonSerializer.Deserialize<Person>(jsonstring); 


    }
     catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    return person;
}
