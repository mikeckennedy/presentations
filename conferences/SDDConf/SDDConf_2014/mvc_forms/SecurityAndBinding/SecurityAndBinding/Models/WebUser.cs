using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecurityAndBinding.Models
{
	public class WebUser
	{
		public int Id { get; set; }
		[Required] public string Name { get; set; }
		[Required] public string Email { get; set; }
		public bool? IsAdmin { get; set; }

		public static WebUser[] All()
		{
			return allUsers;
		}

		public static WebUser Current
		{
			get { return allUsers[1]; }
			set { allUsers[1] = value; }
		}

		private static WebUser[] allUsers =
			new[]
				{
					new WebUser()
					{
						Id = 1,
						Name = "solarcatfish",
						IsAdmin = true,
						Email = "solarcatfish@learninglineapp.com"
					},
					new WebUser()
					{
						Id = 2,
						Name = "michael",
						IsAdmin = false,
						Email = "mk@learninglineapp.com"
					},
					new WebUser() 
					{
						Id = 3,
						Name = "sarah",
						IsAdmin = false,
						Email = "sh@learninglineapp.com"
					},
				};

		internal static void Save(WebUser otherUser)
		{
			// Ah, the things you do with a fake db.

			int index = allUsers.ToList().FindIndex(u => u.Id == otherUser.Id);
			WebUser realRef = allUsers[index];
			
			if (otherUser.IsAdmin != null)
				realRef.IsAdmin = otherUser.IsAdmin;
			
			if (otherUser.Name != null)
				realRef.Name = otherUser.Name;
			
			if (otherUser.Email != null)
				realRef.Email = otherUser.Email;
		}
	}
}