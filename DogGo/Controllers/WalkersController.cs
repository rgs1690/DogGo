using DogGo.Models;
using DogGo.Models.ViewModels;
using DogGo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogGo.Controllers
{


    public class WalkersController : Controller
    {
    private readonly IWalkerRepository _walkerRepo;
    private readonly IWalksRepository _walksRepo;
    private readonly IDogRepository _dogRepo;
    private readonly INeighborhoodRepository _neighborhoodRepo;


        // ASP.NET will give us an instance of our Walker Repository. This is called "Dependency Injection"
        public WalkersController(
        IWalkerRepository walkerRepository,
        IWalksRepository walksRepository,
        IDogRepository dogRepository,
        INeighborhoodRepository neighborhoodRepository)
          
    {
            _walkerRepo = walkerRepository;
            _walksRepo = walksRepository;
            _dogRepo = dogRepository;   
            _neighborhoodRepo = neighborhoodRepository;
    }

        // GET: WalkersController
        public ActionResult Index()
        {
            List<Walker> walkers = _walkerRepo.GetAllWalkers();

            return View(walkers);
        }

        // GET: WalkersController/Details/5
        public ActionResult Details(int id)
        {
            Walker walker = _walkerRepo.GetWalkerById(id);
            List<Walks> walks = _walksRepo.GetWalksByWalkerId(walker.Id);
            List<Neighborhood> neighborhoods = _neighborhoodRepo.GetAll();
            List<Dog> dogs = _dogRepo.GetAllDogs();
            Dog dog = _dogRepo.GetDogById(id);

            if (walker == null)
            {
                return NotFound();
            }
            WalkerProfileViewModel vm = new WalkerProfileViewModel()
            {
                Walker = walker,
                Walks = walks,
               Neightborhoods = neighborhoods,
               Dogs = dogs

               
               
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
    }
}
