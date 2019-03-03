using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenParcialTotal.ViewComponents
{
    public class IdiomaViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var loc = HttpContext.Features.Get<IRequestCultureFeature>();

            ViewBag.IdiomaSel = loc.RequestCulture.UICulture.Name;

            var idiomas = new List<SelectListItem>();
            idiomas.Add(new SelectListItem { Value = "en-US", Text = "English" });
            idiomas.Add(new SelectListItem { Value = "es-ES", Text = "Spanish" });
    

            return View(idiomas);
        }


    }
}
