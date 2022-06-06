// See https://aka.ms/new-console-template for more information

//this class is by deafult in the namespace of the porjecrt:OOPsReview
using OOPsReview.Data;

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
