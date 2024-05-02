using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TTLProject2.Bussiness;
using TTLProject2.Entities;
using TTLProject2.Models;

namespace TTLProject2.Controllers
{
    public class QuanLyUserController : Controller
    {
        private readonly IReadataRepository _readataRepository;
        private readonly IWriteDataRepository _writeDataRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public QuanLyUserController(IReadataRepository readataRepository, IWriteDataRepository writeDataRepository, IWebHostEnvironment hostingEnvironment)
        {
            _readataRepository = readataRepository;
            _writeDataRepository = writeDataRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            UserRoleModel model = new UserRoleModel();
			var user = new List<User>();
			user.AddRange(await _readataRepository.GetAllUser());
			model.DanhSachUser = new SelectList(user, "Id", "Email");

			var role = new List<Role>();
			role.AddRange(await _readataRepository.GetAllRole());
			model.DanhSachVaiTro = new SelectList(role, "Id", "Name");

			return View(model);
        }
		[HttpPost]
		public async Task<IActionResult> PhanQuyen(UserRoleModel model)
		{
            try
            {
                ViewBag.Isvalid = true;
                model.UserId = model.UserId;
                model.RoleId = model.RoleId;

                try
                {
                    bool result;
                    string errorMsessage = "";
                    string successMessage = "";

                    if(await _readataRepository.CheckUserExistById(model.UserId))
                    {
                        errorMsessage = "Người dùng đã được phân quyền , vui lòng đến phần cập nhật phân quyền để chỉnh sửa ";
                        ViewBag.error = errorMsessage;
					}
                    else
                    {
						result = await _writeDataRepository.InsertUserRole(model);
						if (result)
						{
							successMessage = "Phân Quyền Thành Công";
							ViewBag.success = successMessage;
						}
						else
						{
							errorMsessage = "Phân Quyền Thất Bại ";
							ViewBag.error = errorMsessage;

						}
					}    
                   
                }catch (Exception ex)
                {
                    ViewBag.error = ex.Message;
                }
                
            }catch (Exception ex)
            {

				ModelState.AddModelError(string.Empty, ex.Message);
			}
			

			var user = new List<User>();
			user.AddRange(await _readataRepository.GetAllUser());
			model.DanhSachUser = new SelectList(user, "Id", "Email");

			var role = new List<Role>();
			role.AddRange(await _readataRepository.GetAllRole());
			model.DanhSachVaiTro = new SelectList(role, "Id", "Name");

            return Json(new { success = ViewBag.success, error = ViewBag.error }) ; 
		}

		[HttpGet]
        public async Task<IActionResult> UserGetList()
        {
            ViewData["Tab"] = "QuanTri";
            return Json(new { data = await _readataRepository.GetAllUser()});
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
			ViewData["Tab"] = "QuanTri";
			var result = await _writeDataRepository.DeleteUser(id);
			if (result)
			{
				ViewBag.Success = "Xóa Thành Công";
			}
			else
			{
				ViewBag.Error = "Xóa Thất bại";
			}


			return Json(new { success = ViewBag.Success, failed = ViewBag.Error });
		}
    }
}
