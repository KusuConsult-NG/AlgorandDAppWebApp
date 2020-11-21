using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlgorandWebApplicationDemo.Data;
using AlgorandWebApplicationDemo.Models;
using Algorand;

namespace AlgorandWebApplicationDemo.Controllers
{
    public class AccountAddressModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountAddressModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AccountAddressModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountAddressModel.ToListAsync());
        }

        // GET: AccountAddressModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountAddressModel = await _context.AccountAddressModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountAddressModel == null)
            {
                return NotFound();
            }

            return View(accountAddressModel);
        }

        // GET: AccountAddressModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountAddressModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AccountAddress,MnemonicKey")] AccountAddressModel accountAddressModel)
        {
            if (ModelState.IsValid)
            {
                Account account = new Account();
                accountAddressModel.AccountAddress = account.Address.ToString();
                accountAddressModel.MnemonicKey = account.ToMnemonic();
                _context.Add(accountAddressModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accountAddressModel);
        }

        // GET: AccountAddressModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountAddressModel = await _context.AccountAddressModel.FindAsync(id);
            if (accountAddressModel == null)
            {
                return NotFound();
            }
            return View(accountAddressModel);
        }

        // POST: AccountAddressModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AccountAddress,MnemonicKey")] AccountAddressModel accountAddressModel)
        {
            if (id != accountAddressModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountAddressModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountAddressModelExists(accountAddressModel.Id))
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
            return View(accountAddressModel);
        }

        // GET: AccountAddressModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountAddressModel = await _context.AccountAddressModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountAddressModel == null)
            {
                return NotFound();
            }

            return View(accountAddressModel);
        }

        // POST: AccountAddressModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountAddressModel = await _context.AccountAddressModel.FindAsync(id);
            _context.AccountAddressModel.Remove(accountAddressModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountAddressModelExists(int id)
        {
            return _context.AccountAddressModel.Any(e => e.Id == id);
        }
    }
}
