using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Webnovel.Models
{
	public class Webnovel
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[DisplayName("Title")]
		public string ?Name { get; set; }
		[Required]
		[DisplayName("Pages")]
		public int PageCount { get; set; }
		[Required]
		public string ?Genre { get; set; }
		[Required]
		public DateTime CreatedDate { get; set; } = DateTime.Now;
	}
}
