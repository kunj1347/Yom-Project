using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using testing.Models;

namespace testing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index(SliderModel am , OfferModel om , about_imageModel im , PhotosModel pm, PostsModel pom , CommentModel cm)
        {
            DataSet ds = am.select();
            ViewBag.ds = ds.Tables[0];

            DataSet ds2 = om.select();
            ViewBag.ds2 = ds2.Tables[0];

            DataSet ds3 = im.select();
            ViewBag.ds3 = ds3.Tables[0];

            DataSet ds4 = pm.select();
            ViewBag.ds4 = ds4.Tables[0];

            DataSet ds5 = pom.select();
            ViewBag.ds5 = ds5.Tables[0];

			DataSet ds6 = cm.select();
			ViewBag.ds6 = ds6.Tables[0];

			return View();
        }

      
        public IActionResult about(TeamModel tm ,ClientsModel cm , CommentModel cmm)
        {
            DataSet ds = tm.select();
            ViewBag.ds = ds.Tables[0];

			DataSet ds2 = cm.select();
			ViewBag.ds2 = ds2.Tables[0];

			DataSet ds6 = cmm.select();
			ViewBag.ds6 = ds6.Tables[0];
		
            return View();
		}

        public IActionResult blog(ClassicModel cm)
        {
			DataSet ds = cm.select();
			ViewBag.ds = ds.Tables[0];
			return View();
        }
        public IActionResult blog_grid()
        {
            return View();
        }





        [HttpGet]
        public IActionResult blog_single(BlogsliderModel bm , BlogtextModel btm)
        {
			DataSet ds = bm.select();
			ViewBag.ds = ds.Tables[0];

			DataSet ds2 = btm.select();
			ViewBag.ds2 = ds2.Tables[0];

			return View();
        }
        [HttpPost]
        public IActionResult blog_single(CommentModel cm, int a)
        {
            string name = cm.name;  
            string country = cm.country;
            string city = cm.city;
            string msg = cm.msg;

            cm.insert( name, country, city, msg);

            return RedirectToAction("blog_single");
        }




        public IActionResult clients(AddclientsModel am)
        {
            DataSet ds = am.select();
            ViewBag.ds = ds.Tables[0];
            return View();
        }
        public IActionResult contact()
        {
            return View();
        }

        [HttpGet]
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(HomeModel hm)
        {
            DataSet ds = hm.select(hm.email, hm.password);
            ViewBag.login_data = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.login_data.Rows)
            {
                var id = dr["id"].ToString();
                TempData["id"] = id;
                return RedirectToAction("Index");
            }
            return RedirectToAction("login");
        }

        [HttpGet]
        public IActionResult register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult register(HomeModel hm)
        {
            string name = hm.name;

            string email = hm.email;

            string password = hm.password;

            hm.insert(name, email, password);

            return RedirectToAction("login");
        }
        


        public IActionResult services(ServicesModel sm , s_about_image sam)
        {
            DataSet ds = sm.select();
            ViewBag.ds = ds.Tables[0];


            DataSet ds2 = sam.select();
            ViewBag.ds2 = ds2.Tables[0];

            return View();
        }
        public IActionResult work_1columns(SingleModel sm , WorksliderModsel wsm , WorktextModel ws)
        {
			DataSet ds = sm.select();
			ViewBag.ds = ds.Tables[0];

            DataSet ds2 = wsm.select();
            ViewBag.ds2 = ds2.Tables[0];

            DataSet ds3 = ws.select();
            ViewBag.ds3 = ds3.Tables[0];



            return View();
        }
        public IActionResult work_3columns(ThreeModel tm)
		{
			DataSet ds = tm.select();
			ViewBag.ds = ds.Tables[0];
			return View();
        }
        public IActionResult work_4columns(FourModel fm)
        {
			DataSet ds = fm.select();
			ViewBag.ds = ds.Tables[0];
			return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
