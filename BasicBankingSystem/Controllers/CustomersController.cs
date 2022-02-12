using BankCore.Dtos;
using BankCore.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicBankingSystem.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepo customerRepo;

        public CustomersController(ICustomerRepo customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            return View(customerRepo.GetAll());
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View(customerRepo.GetbyId(id));
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {           
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddCustomerDto model)
        {
            try
            {
                customerRepo.Add(new BankCore.Models.Customer {FirstName=model.FirstName,LastName=model.LastName,Balance=model.Balance,Email=model.Email });

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(customerRepo.GetbyId(id));
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,  AddCustomerDto model)
        {
            try
            {
                customerRepo.Update(new BankCore.Models.Customer { Id = id, FirstName = model.FirstName, LastName = model.LastName, Email = model.Email, Balance = model.Balance });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(customerRepo.GetbyId(id));
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                customerRepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: CustomerController/Transfer/5
        public ActionResult Transfer(int id)
        {

            return View(new  TransferViewModel{ Sender=customerRepo.GetbyId(id) ,Receivers=customerRepo.FindAll(c=>c.Id!=id)});
        }

        // POST: CustomerController/Transfer/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Transfer(int Id, TransferViewModel model)
        {
            try
            {
                customerRepo.Transfer(Id,model.ReceiverId,model.Amount);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
