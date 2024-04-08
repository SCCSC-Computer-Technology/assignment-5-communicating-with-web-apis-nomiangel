using Microsoft.AspNetCore.Mvc;
using NoemiAngeles_CPT206_LAB5.Models;
using System.Diagnostics;
using static NoemiAngeles_CPT206_LAB5.Models.Student_Profile;

namespace NoemiAngeles_CPT206_LAB5.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory clientFactory;
       
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory
            )
        {
            _logger = logger;
            clientFactory = httpClientFactory;
        }
        public async Task<IActionResult> PutStudentProfile(long id, StudentProfile studentProfile)
        {
            string uri;
            if (string.IsNullOrEmpty(studentProfile))
            {
                ViewData["Title"] = "All students";
                uri = "api/students/";

            }
            else
            {
                ViewData["Title"] = $"Students in {studentProfile}";
            }

            HttpClient client = clientFactory.CreateClient(name: "StudentProfileWebApi");
            HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: uri);
            HttpResponseMessage response = await client.SendAsync(request);
            IEnumerable<StudentProfile>? model =await response.Content.ReadFromJsonAsAsyncEnumerable<StudentProfile>();
            return View(model);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
