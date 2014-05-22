using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_forms_starter.core.Models;
using mvc_forms_starter.ViewModels;

namespace mvc_forms_starter.Controllers
{
	public class AdminController : BaseController
	{
		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public ActionResult AddCategory()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddCategory(Category category)
		{
			if (category.Name.ToLower().Contains("cat"))
			{
				this.ModelState.AddModelError("Name", "Enough with the lolcats buddy!");
			}

			if (!ModelState.IsValid)
			{
				return View(category);
			}

			repository.AddCategory(category);
			return Redirect("/");
		}

		[HttpGet]
		public ActionResult AddBook()
		{
			var vm = new CreateBookViewModel();

			vm.CategoryList =
				(from c in repository.Categories.ToArray()
				select new SelectListItem() {Text = c.Name, Value = c.Id.ToString()}).ToList();
			return View(vm);
		}

		[HttpPost]
		public ActionResult AddBook(Book book)
		{
			if (!ModelState.IsValid)
				return View(book);

			repository.AddBook(book, book.CategoryId);


			return Redirect("/categories/show/"+book.CategoryId);
		}
	}
}