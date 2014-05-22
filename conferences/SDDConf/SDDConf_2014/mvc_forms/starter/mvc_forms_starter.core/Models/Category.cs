using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace mvc_forms_starter.core.Models
{
	//[MetadataType()]
	public class Category 
	{
		public int Id { get; set; }
		[Required] public string Name { get; set; }
		[Required] 
		[DisplayName("image")]
		public string ImageUrl { get; set; }
	}
}