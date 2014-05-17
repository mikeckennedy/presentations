using System;
using System.Collections.Generic;

namespace mvc_forms_starter.core.Models
{
	public class Comment
	{
		public string Username { get; set; }
		public string CommentText { get; set; }
		public List<int> Votes { get; set; }

		public Comment()
		{
			Votes = new List<int>();
		}
	}
}
