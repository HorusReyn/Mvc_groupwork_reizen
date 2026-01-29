using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZiekefondsReizen.Models;

namespace ZiekefondsReizen.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly ILogger<HomeController> _logger;
        public HomeController(IUnitOfWork contex, IMapper mapper, ILogger<HomeController> logger)
        {
            _context = contex;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {
            var groepsreizen = await _context.GroepsreisRepository.GetAvailableGroepsreizenAsync();
            HomeViewModel viewModel = new HomeViewModel();

            viewModel.Groepsreizen = _mapper.Map<List<HomeGroepsreisViewModel>>(groepsreizen);

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
