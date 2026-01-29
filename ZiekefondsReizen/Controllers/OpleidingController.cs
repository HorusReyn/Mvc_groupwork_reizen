using Microsoft.AspNetCore.Mvc;

namespace ZiekefondsReizen.Controllers
{
    [Authorize(Roles = "Monitor,Verantwoordelijke")]
    public class OpleidingController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        public OpleidingController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //INDEX

        public async Task<ActionResult> Index()
        {
            var opleidingen = await _context.OpleidingRepository.GetAllAsync();
            OpleidingListViewModel model = new OpleidingListViewModel();

            model.Opleidingen = _mapper.Map<List<OpleidingViewModel>>(opleidingen);

            return View(model);
        }
        //DETAILS
        public async Task<IActionResult> DetailsOpleiding(int id)
        {
            Opleiding? opleiding = await _context.OpleidingRepository.GetOpleidingAsync(id);
            if (opleiding == null) return RedirectToAction("Index");

            OpleidingDetailsViewModel viewModel = _mapper.Map<OpleidingDetailsViewModel>(opleiding);
            return View(viewModel);
        }
        //TOEVOEGEN
        [Authorize(Roles = "Verantwoordelijke")]
        public async Task<IActionResult> AddOpleiding()
        {
            var viewModel = new OpleidingCreateViewModel();

            viewModel.Begindatum = DateOnly.FromDateTime(DateTime.Now);
            viewModel.Einddatum = DateOnly.FromDateTime(DateTime.Now.AddDays(7));

            var opleidingen = await _context.OpleidingRepository.GetAllAsync();
            viewModel.Opleidingen = opleidingen.Select(b => new SelectListItem
            {
                Selected = false,
                Value = b.Id.ToString(),
                Text = b.Naam
            }).ToList();

            return View(viewModel);
        }
        [HttpPost]
        [Authorize(Roles = "Verantwoordelijke")]
        public async Task<IActionResult> AddOpleiding(OpleidingCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Opleiding opleiding = _mapper.Map<Opleiding>(viewModel);

                if (opleiding.OpleidingVereistId == 0) opleiding.OpleidingVereistId = null;

                await _context.OpleidingRepository.AddAsync(opleiding);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        //BEWERKEN
        [Authorize(Roles = "Verantwoordelijke")]
        public async Task<IActionResult> EditOpleiding(int id)
        {
            var opleiding = await _context.OpleidingRepository.GetByIdAsync(id);
            if (opleiding != null)
            {
                OpleidingEditViewModel viewModel = _mapper.Map<OpleidingEditViewModel>(opleiding);

                var opleidingen = await _context.OpleidingRepository.GetAllAsync();
                viewModel.Opleidingen = opleidingen
                    .Where(o => o.Id != id)
                    .Where(o => o.OpleidingVereistId != id)
                    .Select(b => new SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.Naam
                }).ToList();

                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [Authorize(Roles = "Verantwoordelijke")]
        public IActionResult EditOpleiding(int id, OpleidingEditViewModel viewModel)
        {
            if (id != viewModel.Id) return NotFound();
            if (!ModelState.IsValid) return View(viewModel);

            try
            {
                Opleiding opleiding = _mapper.Map<Opleiding>(viewModel);
                _context.OpleidingRepository.Update(opleiding);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }

            return RedirectToAction("Index");
        }
        //VERWIJDEREN
        [Authorize(Roles = "Verantwoordelijke")]
        public async Task<IActionResult> DeleteOpleiding(int id)
        {
            var opleiding = await _context.OpleidingRepository.GetByIdAsync(id);

            if (opleiding == null) return NotFound();

            OpleidingDeleteViewModel viewModel = _mapper.Map<OpleidingDeleteViewModel>(opleiding);
            return View(viewModel);
        }
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Verantwoordelijke")]
        public async Task<IActionResult> DeleteOpleidingConfirm(int id)
        {
            var opleiding = await _context.OpleidingRepository.GetByIdAsync(id);

            if (opleiding != null)
            {
                _context.OpleidingRepository.DeleteOpleiding(opleiding);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
