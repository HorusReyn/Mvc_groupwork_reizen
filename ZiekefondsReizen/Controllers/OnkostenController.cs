using Microsoft.AspNetCore.Mvc;
using ZiekefondsReizen.Models;
using ZiekefondsReizen.ViewModels;
using ZiekefondsReizen.Data.UnitOfWork;
using AutoMapper;

namespace ZiekefondsReizen.Controllers
{
    public class OnkostenController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public OnkostenController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // INDEX
        public async Task<ActionResult> Index()
        {
            var onkosten = await _context.OnkostenRepository.GetAllAsync();
            OnkostenListViewModel model = new OnkostenListViewModel
            {
                Onkosten = _mapper.Map<List<OnkostenViewModel>>(onkosten)
            };

            return View(model);
        }

        // DETAILS
        public async Task<IActionResult> DetailsOnkosten(int id)
        {
            Onkosten? onkost = await _context.OnkostenRepository.GetByIdAsync(id);
            if (onkost == null) return RedirectToAction("Index");

            OnkostenDetailsViewModel viewModel = _mapper.Map<OnkostenDetailsViewModel>(onkost);
            return View(viewModel);
        }

        // TOEVOEGEN (GET)
        public IActionResult AddOnkosten()
        {

            var viewModel = new OnkostenCreateViewModel();

            viewModel.Datum = DateTime.Now;
           
       
            return View(viewModel);
        }

        // TOEVOEGEN (POST)
        [HttpPost]
        public async Task<IActionResult> AddOnkosten(OnkostenCreateViewModel viewModel)
        {
            // Log de start van de methode
            Console.WriteLine("AddOnkosten POST method started");
            if (ModelState.IsValid)
            {
                Onkosten omkost = _mapper.Map<Onkosten>(viewModel);
                await _context.OnkostenRepository.AddAsync(omkost);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
            /*   if (!ModelState.IsValid)
               {
                   // Log alle validatiefouten
                   foreach (var modelStateKey in ModelState.Keys)
                   {
                       var value = ModelState[modelStateKey];
                       foreach (var error in value.Errors)
                       {
                           Console.WriteLine($"Error in {modelStateKey}: {error.ErrorMessage}");
                       }
                   }

                   return View(viewModel);
               }

               try
               {
                   // Map de ViewModel naar het Onkosten model
                   Onkosten onkosten = _mapper.Map<Onkosten>(viewModel);

                   // Log de gemapte waarden
                   Console.WriteLine($"Titel: {onkosten.titel}, Bedrag: {onkosten.bedrag}, Datum: {onkosten.datum}");

                   // Voeg toe aan de repository en sla wijzigingen op
                   await _context.OnkostenRepository.AddAsync(onkosten);
                    _context.SaveChanges(); // Gebruik de async versie van SaveChanges

                   Console.WriteLine("Onkosten succesvol toegevoegd");

                   return RedirectToAction("Index");
               }
               catch (Exception ex)
               {
                   // Log de foutmelding
                   Console.WriteLine($"Error tijdens opslaan: {ex.Message}");
                   ModelState.AddModelError(string.Empty, "Er is een fout opgetreden bij het opslaan van de onkosten.");
                   return View(viewModel);
               }*/
        }


        // BEWERKEN (GET)
        public async Task<IActionResult> EditOnkosten(int id)
        {
            var onkost = await _context.OnkostenRepository.GetByIdAsync(id);
            if (onkost != null)
            {
                OnkostenEditViewModel viewModel = _mapper.Map<OnkostenEditViewModel>(onkost);
                return View(viewModel);
            }

            return RedirectToAction("Index");
        }

        // BEWERKEN (POST)
        [HttpPost]
        public IActionResult EditOnkosten(int id, OnkostenEditViewModel viewModel)
        {
            if (id != viewModel.Id) return NotFound();
            if (!ModelState.IsValid) return View(viewModel);

            try
            {
                Onkosten onkost = _mapper.Map<Onkosten>(viewModel);
                _context.OnkostenRepository.Update(onkost);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }

            return RedirectToAction("Index");
        }

        // VERWIJDEREN (GET)
        public async Task<IActionResult> DeleteOnkosten(int id)
        {
            var onkost = await _context.OnkostenRepository.GetByIdAsync(id);
            if (onkost == null) return NotFound();

            OnkostenDeleteViewModel viewModel = _mapper.Map<OnkostenDeleteViewModel>(onkost);
            return View(viewModel);
        }

        // VERWIJDEREN (POST)
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteOnkostenConfirm(int id)
        {
            var onkost = await _context.OnkostenRepository.GetByIdAsync(id);
            if (onkost != null)
            {
                _context.OnkostenRepository.Delete(onkost);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
