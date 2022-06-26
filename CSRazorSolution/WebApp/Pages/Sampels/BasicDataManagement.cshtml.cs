using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Sampels
{
    public class BasicDataManagementModel : PageModel
    {
        //BindProperty - is an annotation that handles two way data transfer
        //two-way? means output to form for display AND input from from for processing
        [BindProperty]
        public int Num { get; set; }

        [BindProperty]
        public string MassText { get; set; }
        [BindProperty]
        public int FavouriteCourse { get; set; }   
        public string FeedBack { get; set; }

        public string ErrorMsg { get; set;}
        public void OnGet()
        {
            if(Num == 0)
            {
                FeedBack = "executing the OnGet Requset";
            }
            else
            {
                FeedBack = $"You entered the value {Num} ONGET";
            }
        }
        public void  OnPost()
        {
            if(Num == 0)
            {
                FeedBack = $"excuting value zero";
            }
            else
            {
              FeedBack = $"You entered the value {Num}; your mass text is {MassText} and i like {FavouriteCourse} course";
            }
            
        }
        public void OnPostSecondButton()
        {
            if (Num == 0)
            {
                FeedBack = $"excuting the secondbutton";
            }
            else if(FavouriteCourse == 0)
            {
                FeedBack = $"You did not select a favourite course";
            }
            else
            {
                FeedBack = $"You entered the value {Num}; your mass text is {MassText} and i like {FavouriteCourse} course";
            }

        }
    }
}
 