using Classes.Enum;
using Common.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace UI.Pages
{
    public class IndexModel : PageModel
    {
        private string Url_Lcl = "https://localhost:7070";

        [BindProperty]
        public required RegistrationViewModel RegistrationForm { get; set; }
        public string? UserMessage { get; set; }
        public async Task<IActionResult> OnGet()
        {
            ViewData["Title"] = "Online Webinar Registration";

            using (var client = new HttpClient())
            {
                var obj = await client.GetAsync(Url_Lcl + "/api/topic/");
                if (obj.StatusCode == 0)
                {

                }
            }


            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewData["Title"] = "Online Webinar Registration";
                    return Page();
                }

                using var client = new HttpClient();
                var json = JsonConvert.SerializeObject(RegistrationForm.GetDto());
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                if (data != null)
                {
                    var response = await client.PostAsync(Url_Lcl + "/api/registration/", data);
                    var resultStr = response.Content.ReadAsStringAsync().Result;
                    Enum.TryParse(resultStr, out Result myStatus);
                    Result result = myStatus;
                    if (result == Result.Success)
                    {
                        UserMessage = "Thank you for registering your interest.";
                    }
                    else
                    {
                        UserMessage = "Please try again.";
                    }
                }
            }
            catch (Exception)
            {
                UserMessage = "There has been an unexpected error.";
            }
            return Page();
        }
    }
}
