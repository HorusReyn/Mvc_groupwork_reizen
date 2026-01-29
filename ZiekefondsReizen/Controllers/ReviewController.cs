using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ZiekefondsReizen.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        public ReviewController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //INDEX
        public async Task<ActionResult> Index(int? id)
        {
            var reviews = await _context.ReviewRepository.GetAllReviewsAsync();
            ReviewListViewModel model = new ReviewListViewModel();

            model.Reviews = _mapper.Map<List<ReviewViewModel>>(reviews);

            return View(model);
        }
        //DETAILS
        public async Task<IActionResult> DetailsReview(int id)
        {
            Review? review = await _context.ReviewRepository.GetReviewAsync(id);
            if (review == null) return RedirectToAction("Index");

            ReviewDetailsViewModel viewModel = _mapper.Map<ReviewDetailsViewModel>(review);
            return View(viewModel);
        }
        //TOEVOEGEN
        [Authorize(Roles = "Gebruiker")]
        public async Task<IActionResult> AddReview(int id)
        {
            Bestemming? bestemming = await _context.BestemmingRepository.GetByIdAsync(id);
            if (bestemming != null)
            {
                ReviewCreateViewModel viewModel = new ReviewCreateViewModel();
                viewModel.BestemmingId = id;
                viewModel.Bestemming = bestemming;

                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Index", "Groepsreis");
            }
        }
        [HttpPost]
        [Authorize(Roles = "Gebruiker")]
        public async Task<IActionResult> AddReview(ReviewCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Review review = _mapper.Map<Review>(viewModel);
                
                await _context.ReviewRepository.AddAsync(review);
                _context.SaveChanges();
                return RedirectToAction("Index", "Groepsreis");
            }
            return View(viewModel);
        }
        //DELETE
        [Authorize(Roles = "Beheerder")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _context.ReviewRepository.GetReviewAsync(id);

            if (review == null) return NotFound();

            ReviewDeleteViewModel viewModel = _mapper.Map<ReviewDeleteViewModel>(review);
            return View(viewModel);
        }
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Beheerder")]
        public async Task<IActionResult> DeleteReviewConfirm(int id)
        {
            var review = await _context.ReviewRepository.GetReviewAsync(id);

            if (review != null)
            {
                _context.ReviewRepository.Delete(review);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
