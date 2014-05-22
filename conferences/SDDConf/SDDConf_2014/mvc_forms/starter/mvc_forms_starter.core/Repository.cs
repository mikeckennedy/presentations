using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using mvc_forms_starter.core.Models;
using Newtonsoft.Json;

namespace mvc_forms_starter.core
{
	public class Repository
	{
		public List<Book> Books { get; set; }
		public List<Category> Categories { get; set; }

		public Repository()
		{
			Books = new List<Book>();
			Categories = new List<Category>();
		}

		public void Save()
		{
			string file = HttpContext.Current.Server.MapPath("~/App_Data/data.json");
			string json_data = JsonConvert.SerializeObject(this,Formatting.Indented);
			File.WriteAllText(file, json_data,Encoding.UTF8);
		}

		public static Repository Create()
		{
			string file = HttpContext.Current.Server.MapPath("~/App_Data/data.json");
			if (!File.Exists(file))
				return new Repository();

			string json_text = File.ReadAllText(file);
			return JsonConvert.DeserializeObject<Repository>(json_text);
		}

		public void AddCategory(Category category)
		{
			this.Categories.Add(category);
			category.Id = this.Categories.Max(c => c.Id) + 1;
			this.Save();
		}

		public void AddBook(Book book, int categoryId)
		{
			this.Books.Add(book);
			book.Id = this.Books.Max(b => b.Id) + 1;
			book.CategoryId = categoryId;
			this.Save();
		}

	}
}
