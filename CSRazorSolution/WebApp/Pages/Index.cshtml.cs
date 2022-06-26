using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages

{
    //this web page Model class inhertis from PageModel
    public class IndexModel : PageModel
    {
        //this defualt page usese a sytem class called ILogger<T>
        //this is composition
        //this is a local field
        private readonly ILogger<IndexModel> _logger;

        //constructor
        //this construcotr recives an injection of a service
        //this injection is refered to as Injection Dependency
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        //this is a local property
       public string MyName { get; set; }

        //this  is a class Behaviour(method)
        //this method OnGet() executes for any Get Request

        public void OnGet()
        {
            //once in the request method, you are in control of what is being processed on the web page for the current request
            //the code within this method is the work that i wish to be done


            Random rnd = new Random();
            int value = rnd.Next(0,100); //100 is not included
            if(value % 2 == 0 )
            {
                MyName = $"Bohdan ({value}) welcome to the wide wild world pf Razor Pages";
            }
            else
            {
                MyName = null;
            }

            //control is returned to the web server
        }
    }
}