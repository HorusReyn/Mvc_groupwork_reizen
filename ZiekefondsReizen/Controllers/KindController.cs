using Microsoft.AspNetCore.Mvc;

namespace ZiekefondsReizen.Controllers
{
    [Authorize(Roles = "Gebruiker")]
    public class KindController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        public KindController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ActionResult> Index()
        {
            var kinderen = await _context.KindRepository.GetAllAsync();
            KindListViewModel model = new KindListViewModel();

            model.Kinderen = _mapper.Map<List<KindViewModel>>(kinderen);

            return View(model);
        }

        public async Task<IActionResult> AddKind()
        {
            var viewModel = new KindCreateViewModel();

            viewModel.Geboortedatum = DateOnly.FromDateTime(DateTime.Now);

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddKind(KindCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Kind kind = _mapper.Map<Kind>(viewModel);
                await _context.KindRepository.AddAsync(kind);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public async Task<IActionResult> EditKind(int id)
        {
            var kind = await _context.KindRepository.GetByIdAsync(id);
            if (kind != null)
            {
                KindEditViewModel viewModel = _mapper.Map<KindEditViewModel>(kind);

                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult EditKind(int id, KindEditViewModel viewModel)
        {
            if (id != viewModel.Id) return NotFound();
            if (!ModelState.IsValid) return View(viewModel);

            try
            {
                Kind kind = _mapper.Map<Kind>(viewModel);
                _context.KindRepository.Update(kind);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteKind(int id)
        {
            var kind = await _context.KindRepository.GetKindAsync(id);

            if (kind == null) return NotFound();

            KindDeleteViewModel viewModel = _mapper.Map<KindDeleteViewModel>(kind);
            return View(viewModel);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteKindConfirm(int id)
        {
            var kind = await _context.KindRepository.GetKindAsync(id);

            if (kind != null)
            {
                _context.KindRepository.Delete(kind);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DetailsKind(int id)
        {
            Kind? kind = await _context.KindRepository.GetKindAsync(id);
            if (kind == null) return RedirectToAction("Index");

            KindDetailsViewModel viewModel = _mapper.Map<KindDetailsViewModel>(kind);
            return View(viewModel);
        }
    }
}
