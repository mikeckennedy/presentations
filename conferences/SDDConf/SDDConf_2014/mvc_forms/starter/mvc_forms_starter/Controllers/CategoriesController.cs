using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_forms_starter.core.Models;

namespace mvc_forms_starter.Controllers
{
    public class CategoriesController : BaseController
    {
        public ActionResult Show(int id = -1)
        {
	        var cat = repository.Categories.SingleOrDefault(c => c.Id == id);
	        var books = repository.Books.Where(b => b.CategoryId == id);
	        if (cat == null)
	        {
		        return HttpNotFound();
	        }

			return View(books.ToArray());
        }

		[ValidateInput(false)]
		public ActionResult AddComment(string text, int id)
	    {
			var book = repository.Books.SingleOrDefault(b => b.Id == id);
		    book.Comments.Add(new Comment() {CommentText = text});
		    repository.Save();
		    return Redirect("/categories/show/" + id);
	    }

	    public ActionResult Book(int id = -1)
	    {
			var book = repository.Books.SingleOrDefault(b => b.Id == id);
		    return View(book);
	    }
    }
}