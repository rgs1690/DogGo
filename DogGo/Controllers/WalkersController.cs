using DogGo.Models;
using DogGo.Models.ViewModels;
using DogGo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DogGo.Controllers
{


    public class WalkersController : Controller
    {
    private readonly IWalkerRepository _walkerRepo;
    private readonly IWalksRepository _walksRepo;
    private readonly IDogRepository _dogRepo;
    private readonly INeighborhoodRepository _neighborhoodRepo;
    private readonly IOwnerRepository _ownerRepo;


        // ASP.NET will give us an instance of our Walker Repository. This is called "Dependency Injection"
        public WalkersController(
        IWalkerRepository walkerRepository,
        IWalksRepository walksRepository,
        IDogRepository dogRepository,
        INeighborhoodRepository neighborhoodRepository,
        IOwnerRepository ownerRepository)
          
    {
            _walkerRepo = walkerRepository;
            _walksRepo = walksRepository;
            _dogRepo = dogRepository;   
            _neighborhoodRepo = neighborhoodRepository;
            _ownerRepo = ownerRepository;   
    }

        // GET: WalkersController
        public ActionResult Index()
        {   List<Walker> allWalkers = _walkerRepo.GetAllWalkers();
            int userId = GetCurrentUserId();
            Owner owner =_ownerRepo.GetOwnerById(userId);
            if (owner  != null)
            {

            List<Walker> walkers = _walkerRepo.GetWalkersInNeighborhood(owner.NeighborhoodId);

            return View(walkers);
            }
            else
            {
                return View(allWalkers);
            }


        }

        // GET: WalkersController/Details/5
        public ActionResult Details(int id)
        {
            Walker walker = _walkerRepo.GetWalkerById(id);
            List<Walks> walks = _walksRepo.GetWalksByWalkerId(walker.Id);
            Neighborhood neighborhood = walker.Neighborhood; 
           

            if (walker == null)
            {
                return NotFound();
            }
            WalkerProfileViewModel vm = new WalkerProfileViewModel()
            {
                Walker = walker,
                Walks = walks,
                Neighborhood = neighborhood
              

               
               
            };

            return View(vm);
           
        }

        // GET: WalkersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WalkersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WalkersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WalkersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WalkersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WalkersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }

    }

}
