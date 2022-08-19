using System.ComponentModel.DataAnnotations;

namespace Webnovel.Models
{
	public class Webnovel
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string ?Name { get; set; }
		[Required]
		public int PageCount { get; set; }
		[Required]
		public string ?Genre { get; set; }
		[Required]
		public DateTime CreatedDate { get; set; } = DateTime.Now;
	}
}
