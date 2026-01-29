using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
namespace ZiekefondsReizen.Controllers
{
    [Authorize(Roles = "Gebruiker")]
    public class DeelnemerController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        public DeelnemerController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //Deelnemer Inschrijven
        public async Task<IActionResult> Index(int id)
        {
            DeelnemerViewModel viewModel = new DeelnemerViewModel();
            viewModel.GroepsreisId = id;

            Deelnemer deelnemer = _mapper.Map<Deelnemer>(viewModel);
            deelnemer.Groepsreis = await _context.GroepsreisRepository.GetGroepsreisAsync(deelnemer.GroepsreisId);

            var kinderen = await _context.KindRepository.GetAllViableKinderenAsync(deelnemer);
            viewModel.Kinderen = kinderen.Select(k => new SelectListItem
            {
                Value = k.Id.ToString(),
                Text = k.Naam + " " + k.Voornaam
            }).ToList();

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(int id, DeelnemerViewModel viewModel)
        {
            if (!ModelState.IsValid ) return View(viewModel);

            Deelnemer deelnemer = _mapper.Map<Deelnemer>(viewModel);
            deelnemer.GroepsreisId = id;

            await _context.DeelnemerRepository.AddAsync(deelnemer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


    }
}
