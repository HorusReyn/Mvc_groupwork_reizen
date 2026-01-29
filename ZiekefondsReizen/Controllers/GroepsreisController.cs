using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ZiekefondsReizen.Controllers
{
    public class GroepsreisController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        public GroepsreisController(IUnitOfWork contex, IMapper mapper)
        {
            _context = contex;
            _mapper = mapper;
        }

        //INDEX
        public async Task<ActionResult> Index()
        {
            var groepsreizen = await _context.GroepsreisRepository.GetAllGroepsreizenAsync();
            GroepsreisListViewModel model = new GroepsreisListViewModel();

            model.Groepsreisen = _mapper.Map<List<GroepsreisViewModel>>(groepsreizen);

            return View(model);
        }
        //DETAILS
        public async Task<IActionResult> DetailsGroepsreis(int id)
        {
            Groepsreis? groepsreis = await _context.GroepsreisRepository.GetGroepsreisAsync(id);
            if (groepsreis == null) return RedirectToAction("Index");

            GroepsreisDetailsViewModel viewModel = _mapper.Map<GroepsreisDetailsViewModel>(groepsreis);

            if (viewModel.Deelnemers == null) viewModel.Deelnemers = new List<Deelnemer>();

            return View(viewModel);
        }
        //TOEVOEGEN
        [Authorize(Roles = "Verantwoordelijke")]
        public async Task<IActionResult> AddGroepsreis()
        {
            var viewModel = new GroepsreisCreateViewModel();

            viewModel.Begindatum = DateOnly.FromDateTime(DateTime.Now);
            viewModel.Einddatum = DateOnly.FromDateTime(DateTime.Now.AddDays(7));

            var bestellingen = await _context.BestemmingRepository.GetAllAsync();
            viewModel.Bestemmingen = bestellingen.Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Naam
            }).ToList();

            return View(viewModel);
        }
        [HttpPost]
        [Authorize(Roles = "Verantwoordelijke")]
        public async Task<IActionResult> AddGroepsreis(GroepsreisCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Groepsreis groepsreis = _mapper.Map<Groepsreis>(viewModel);
                await _context.GroepsreisRepository.AddAsync(groepsreis);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        //BEWERKEN
        [Authorize(Roles = "Verantwoordelijke")]
        public async Task<IActionResult> EditGroepsreis(int id)
        {
            var groepsreis = await _context.GroepsreisRepository.GetGroepsreisAsync(id);
            if (groepsreis != null)
            {
                GroepsreisEditViewModel viewModel = _mapper.Map<GroepsreisEditViewModel>(groepsreis);

                var bestellingen = await _context.BestemmingRepository.GetAllAsync();
                viewModel.Bestemmingen = bestellingen.Select(b => new SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.Naam
                });

                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [Authorize(Roles = "Verantwoordelijke")]
        public IActionResult EditGroepsreis(int id, GroepsreisEditViewModel viewModel)
        {
            if (id != viewModel.Id) return NotFound();
            if (!ModelState.IsValid) return View(viewModel);

            try
            {
                Groepsreis groepsreis = _mapper.Map<Groepsreis>(viewModel);
                _context.GroepsreisRepository.Update(groepsreis);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }

            return RedirectToAction("Index");
        }
        //VERWIJDER
        [Authorize(Roles = "Verantwoordelijke")]
        public async Task<IActionResult> DeleteGroepsreis(int id)
        {
            var groepsreis = await _context.GroepsreisRepository.GetGroepsreisAsync(id);

            if (groepsreis == null) return NotFound();

            GroepsreisDeleteViewModel viewModel = _mapper.Map<GroepsreisDeleteViewModel>(groepsreis);
            return View(viewModel);
        }
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Verantwoordelijke")]
        public async Task<IActionResult> DeleteGroepsreisConfirm(int id)
        {
            var groepsreis = await _context.GroepsreisRepository.GetGroepsreisAsync(id);

            if (groepsreis != null)
            {
                _context.GroepsreisRepository.Delete(groepsreis);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
       

    }
}
