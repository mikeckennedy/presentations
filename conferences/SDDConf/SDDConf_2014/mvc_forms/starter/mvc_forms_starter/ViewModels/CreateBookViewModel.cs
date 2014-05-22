using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_forms_starter.core.Models;

namespace mvc_forms_starter.ViewModels
{
	public class CreateBookViewModel
	{
		public List<SelectListItem> CategoryList { get; set; }
		public Book Book { get; set; }

		public CreateBookViewModel()
		{
			this.Book = new Book();
		}
	}
}