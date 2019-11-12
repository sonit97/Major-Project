using DATNWEB.Areas.Admin.Models;
using DATNWEB.Common;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DATNWEB.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ThanhVienDAO();
                var ktra = dao.Login(model.TaiKhoan, model.MatKhau);
                if (ktra == 1)
                {

                    var user = dao.GetbyID(model.TaiKhoan);
                    var usetSession = new UserLogin();
                    usetSession.TenTaiKhoan = user.TaiKhoan;
                    usetSession.UsetID = user.MaThanhVien;
                    usetSession.HoTen = user.Hoten;
                    usetSession.MaLoaiTV = user.MaLoaiTV;
                    //Session["Admin"] = usetSession;
                  Session.Add(Commonconstants.USER_SESSION, usetSession);
                    return RedirectToAction("Index", "Homee");

                }
                else if (ktra == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else  if (ktra == -1)
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng");
                }
                else if (ktra == -2)
                {
                    ModelState.AddModelError("", "Bạn không có quyền admin");
                }


            }
            return View("Index");

        }
          public ActionResult Logout()
        {
           // Session["Admin"] = null;
         Session[Commonconstants.USER_SESSION] = null;
            return RedirectToAction("Index","Login");
        }

        }
    }
