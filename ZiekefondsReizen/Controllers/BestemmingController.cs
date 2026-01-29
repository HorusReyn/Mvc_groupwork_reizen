using Microsoft.AspNetCore.Mvc;

namespace ZiekefondsReizen.Controllers
{
    [Authorize(Roles = "Verantwoordelijke")]
    public class BestemmingController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        public BestemmingController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //INDEX
        public async Task<ActionResult> Index()
        {
            var bestemmingen = await _context.BestemmingRepository.GetAllAsync();
            BestemmingListViewModel model = new BestemmingListViewModel();

            model.Bestemmingen = _mapper.Map<List<BestemmingViewModel>>(bestemmingen);

            return View(model);
        }
        //DETAILS
        public async Task<IActionResult> DetailsBestemming(int id)
        {
            Bestemming? bestemming = await _context.BestemmingRepository.GetBestemmingAsync(id);
            if (bestemming == null) return RedirectToAction("Index");

            BestemmingDetailsViewModel viewModel = _mapper.Map<BestemmingDetailsViewModel>(bestemming);
            return View(viewModel);
        }
        //TOEVOEGEN
        public IActionResult AddBestemming()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBestemming(BestemmingCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Bestemming bestemming = _mapper.Map<Bestemming>(viewModel);
                await _context.BestemmingRepository.AddAsync(bestemming);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        //BEWERKEN
        public async Task<IActionResult> EditBestemming(int id)
        {
            var bestemming = await _context.BestemmingRepository.GetByIdAsync(id);
            if (bestemming != null)
            {
                BestemmingEditViewModel viewModel = _mapper.Map<BestemmingEditViewModel>(bestemming);

                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult EditBestemming(int id, BestemmingEditViewModel viewModel)
        {
            if (id != viewModel.Id) return NotFound();
            if (!ModelState.IsValid) return View(viewModel);

            try
            {
                Bestemming bestemming = _mapper.Map<Bestemming>(viewModel);
                _context.BestemmingRepository.Update(bestemming);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }

            return RedirectToAction("Index");
        }
        //VERWIJDEREN
        public async Task<IActionResult> DeleteBestemming(int id)
        {
            var bestemming = await _context.BestemmingRepository.GetByIdAsync(id);

            if (bestemming == null) return NotFound();

            BestemmingDeleteViewModel viewModel = _mapper.Map<BestemmingDeleteViewModel>(bestemming);
            return View(viewModel);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteBestemmingConfirm(int id)
        {
            var bestemming = await _context.BestemmingRepository.GetByIdAsync(id);

            if (bestemming != null)
            {
                await _context.BestemmingRepository.DeleteBestemming(bestemming);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
