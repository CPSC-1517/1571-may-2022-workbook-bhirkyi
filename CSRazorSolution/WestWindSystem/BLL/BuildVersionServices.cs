using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    //this class needs to allow access from software that is outside of the class library project.
    //therefore, this class will have access type of public 
    public class BuildVersionServices
    {
        #region setup the context connection variable and class constructor

        //variable to hold an instance of context class
        private readonly WestWindContext _context;
        // constructor to create an instace of the registered context class
        internal BuildVersionServices(WestWindContext regcontext)
        {
            _context = regcontext;
        }
        #endregion

        #region Services : Query

        //Query means to look for something

        //create a method (service) that will retrieve the BuildVersion record
        //this method will be class from the PL web application page(PageModel file)
        //this method must be public 
        // this method becomes part of the class Library's public interface
        public BuildVersion GetBuildVersion()
        {
            //we need to access the DbSet<T> in the context class that has been set up to transport the data from the database to 
            //our application

            //_context is the instace of the DAL context class 
            //BuildVersion is the property in the class for the sql table
            //BuildVersions via the entity BuildVersion
            //By default  all records of the sql table will returned to the DbSet<T>
            //this means that your resiveing variable MUST be a List<T>
            //However we can use additional methods within Linq to restrict the amount of data to be returned 
            //FirstOrDefault() restriction the amount of data to a single record therefore i do not need a List<T> just and instace of T
            //  First:get the first record on the table that matches the request condition
            //  Default: if no record is found matching the request condtion return a null
            //In our Linq query we have no filtering conditions.

            BuildVersion info = _context.BuildVersions.FirstOrDefault();
            return info;
        }


        #endregion
    }
}
