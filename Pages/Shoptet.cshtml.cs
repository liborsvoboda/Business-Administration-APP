using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication.Pages
{
    public class ShoptetSelectionModel : PageModel
    {
        [EnableCors("CorsPolicy")]
        public void OnGet()
        {
        }
    }
}