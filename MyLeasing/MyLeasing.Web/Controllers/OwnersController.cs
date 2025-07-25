using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyLeasing.Web.Data;
using MyLeasing.Web.Data.Entities;

namespace MyLeasing.Web.Controllers
{
    public class OwnersController : Controller
    {
        //private readonly DataContext _context;
        //private readonly IRepository _repository;
        private readonly IOwnerRepository _ownerRepository;

        public OwnersController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        // GET: Owners
        // public async Task<IActionResult> Index()
        public IActionResult Index()
        {
            //return View(await _context.Owners.ToListAsync());
            // return View(_repository.GetOwner());
            return View(_ownerRepository.GetAll());
        }

        // GET: Owners/Details/5
        //public async Task<IActionResult> Details(string id)
        //public IActionResult Details(string id)
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var owners = await _context.Owners
            // .FirstOrDefaultAsync(m => m.Document == id);
            //var owners = _repository.GetOwner(id);
            var owners =await _ownerRepository.GetByIdAsync(id);


            if (owners == null)
            {
                return NotFound();
            }

            return View(owners);
        }

        // GET: Owners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Owners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Document,FirstName,LastName,OwnerName,FixedPhone,CellPhone,Address")] Owners owners)
        {
            if (ModelState.IsValid)
            {
                if (!ModelState.IsValid)
                {
                    return View(owners);
                }

                // Verifica se já existe um Owner com o mesmo Document
                if (await _ownerRepository.ExistAsync(owners.Document))
                {
                    ModelState.AddModelError(string.Empty, "Já existe um proprietário com este número de documento.");
                    return View(owners);
                }

                // Concatena FirstName e LastName no OwnerName
                owners.OwnerName = $"{owners.FirstName} {owners.LastName}";

                //_context.Add(owners); // Só isso é suficiente para criação
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                //_repository.AddOwner(owners);
                // await _repository.SaveAllAsync();
                // return RedirectToAction(nameof(Index));

                await _ownerRepository.CreateAnsyc(owners);
               
                return RedirectToAction(nameof(Index));
            }
            return View(owners);
        }

        // GET: Owners/Edit/5
        // public async Task<IActionResult> Edit(string id)
        //public IActionResult Edit(string id)
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var owners = await _context.Owners.FindAsync(id);
            //var owners =  _repository.GetOwner(id);
            var owners =  await _ownerRepository.GetByIdAsync(id);
            if (owners == null)
            {
                return NotFound();
            }
            return View(owners);
        }

        // POST: Owners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Document,FirstName,LastName,OwnerName,FixedPhone,CellPhone,Address")] Owners owners)
        {
            if (id != owners.Document)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Atualiza OwnerName com FirstName + LastName
                    owners.OwnerName = $"{owners.FirstName} {owners.LastName}";

                    // _context.Update(owners);
                    //await _context.SaveChangesAsync();

                    // _repository.UpdateOwner(owners);
                    await _ownerRepository.UpdateAnsyc(owners);
                   // await _repository.SaveAllAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // if (!_context.Owners.Any(e => e.Document == owners.Document))
                    // if (!_repository.OwnerExists(owners.Document))
                    if (! await _ownerRepository.ExistAsync(owners.Document))
                    {
                        
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(owners);
        }

        // GET: Owners/Delete/5
        //public async Task<IActionResult> Delete(string id)
        // public IActionResult Delete(string id)
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var owners = await _ownerRepository.GetByIdAsync(id);
            //  var owners = _repository.GetOwner(id);
            //var owners = await _context.Owners
            // .FirstOrDefaultAsync(m => m.Document == id);
            if (owners == null)
            {
                return NotFound();
            }

            return View(owners);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            //var owners = await _context.Owners.FindAsync(id);
            // _context.Owners.Remove(owners);
            // await _context.SaveChangesAsync();

           // var owners = _repository.GetOwner(id);
          //  _repository.RemoveOwner(owners);
          //  await _repository.SaveAllAsync();
         //   return RedirectToAction(nameof(Index));


            var owners = await _ownerRepository.GetByIdAsync(id);           
            await _ownerRepository.DeleteAnsyc(owners);
            return RedirectToAction(nameof(Index));
        }

        /* private bool OwnersExists(string id)
         {
             return _context.Owners.Any(e => e.Document == id);
         }*/
    }
}
