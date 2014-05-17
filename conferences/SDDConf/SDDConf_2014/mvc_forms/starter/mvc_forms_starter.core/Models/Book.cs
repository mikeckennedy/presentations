using System;
using System.Collections.Generic;

namespace mvc_forms_starter.core.Models
{
	public class Book 
	{
		public int Id { get; set; }
		
		public string Name { get; set; }
		public string ImageUrl { get; set; }
		public float Price { get; set; }

		public int CategoryId { get; set; }

		public List<Comment> Comments { get; set; }
		
		public Book()
		{
			Comments = new List<Comment>();			
		}
	}
}
