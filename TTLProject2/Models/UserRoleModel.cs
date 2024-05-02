using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TTLProject2.Models
{
	public class UserRoleModel
	{
		[Required(ErrorMessage ="Bạn Chưa Chọn Người dùng ")]
		[Display(Name = "UserId")]
		public string? UserId { get; set; }

		[Required(ErrorMessage = "Bạn Chưa Chọn Vai Trò")]
		[Display(Name = "RoleId")]
		public string? RoleId { get; set;}

		public SelectList? DanhSachUser {  get; set; }

		public SelectList? DanhSachVaiTro { get; set; }
	}
}
