using Microsoft.AspNetCore.Mvc;

namespace ZiekefondsReizen.Controllers
{
    [Authorize(Roles ="Verantwoordelijke")]
    public class ActiviteitController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        public ActiviteitController(IUnitOfWork contex, IMapper mapper)
        {
            _context = contex;
            _mapper = mapper;
        }

        //INDEX
        public async Task<ActionResult> Index()
        {
            var activiteiten = await _context.ActiviteitRepository.GetAllAsync();
            ActiviteitListViewModel model = new ActiviteitListViewModel();

            model.Activiteiten = _mapper.Map<List<ActiviteitVieuwModel>>(activiteiten);

            return View(model);
        }

        //TOEVOEGEN
        public IActionResult AddActiviteit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddActiviteit(ActiviteitCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Activiteit activiteit = _mapper.Map<Activiteit>(viewModel);
                await _context.ActiviteitRepository.AddAsync(activiteit);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        //BEWERKEN
        public async Task<IActionResult> EditActiviteit(int id)
        {
            var activiteit = await _context.ActiviteitRepository.GetByIdAsync(id);
            if (activiteit != null)
            {
                ActiviteitEditViewModel viewModel = _mapper.Map<ActiviteitEditViewModel>(activiteit);

                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult EditActiviteit(int id, ActiviteitEditViewModel viewModel)
        {
            if (id != viewModel.Id) return NotFound();
            if (!ModelState.IsValid) return View(viewModel);

            try
            {
                Activiteit activiteit = _mapper.Map<Activiteit>(viewModel);
                _context.ActiviteitRepository.Update(activiteit);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }

            return RedirectToAction("Index");
        }

        //DELETE
        public async Task<IActionResult> DeleteActiviteit(int id)
        {
            var activiteit = await _context.ActiviteitRepository.GetByIdAsync(id);

            if (activiteit == null) return NotFound();

            ActiviteitDeleteViewModel viewModel = _mapper.Map<ActiviteitDeleteViewModel>(activiteit);
            return View(viewModel);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteActiviteitConfirm(int id)
        {
            var activiteit = await _context.ActiviteitRepository.GetByIdAsync(id);

            if (activiteit != null)
            {
                _context.ActiviteitRepository.Delete(activiteit);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //DETAILS
        public async Task<IActionResult> DetailsActiviteit(int id)
        {
            Activiteit? activiteit = await _context.ActiviteitRepository.GetByIdAsync(id);
            if (activiteit == null) return RedirectToAction("Index");

            ActiviteitDetailsViewModel viewModel = _mapper.Map<ActiviteitDetailsViewModel>(activiteit);
            return View(viewModel);
        }

    }
}
