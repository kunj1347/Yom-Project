using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;
using System.Data;
using testing.Models;
using static System.Net.Mime.MediaTypeNames;

namespace testing.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public AdminController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminModel am)
        {
            DataSet ds = am.select(am.email, am.password);
            ViewBag.login_data = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.login_data.Rows)
            {
                var id = dr["id"].ToString();
                TempData["id"] = id;
                return RedirectToAction("dashboard");
            }
            return RedirectToAction("Index");
        }

        public IActionResult dashboard()
        {
            return View();
        }

        public IActionResult widgets()
        {
            return View();
        }

        [HttpGet]
        public IActionResult add_slider()
        {


            return View();
        }

        [HttpPost]
        public async Task<ActionResult> add_slider(SliderModel am)
        {
            string title = am.title;
            string discription = am.discription;

            if (am.image != null && am.image.Length > 0)
            {
                string filename = Path.GetFileName(am.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await am.image.CopyToAsync(str);
                }

                am.insert(title, discription, filename);
            }

            return RedirectToAction("add_slider");
        }

        public IActionResult view_slider(SliderModel am)
        {
            DataSet ds = am.select();
            ViewBag.ds = ds.Tables[0];
            return View();
        }

        public IActionResult chartjs()
        {
            return View();
        }

        public IActionResult flot()
        {
            return View();
        }

        public IActionResult inline()
        {
            return View();
        }

        public IActionResult uplot()
        {
            return View();
        }

        public IActionResult general()
        {
            return View();
        }

        public IActionResult icon()
        {
            return View();
        }

        public IActionResult buttons()
        {
            return View();
        }

        public IActionResult slider()
        {
            return View();
        }

        public IActionResult modals()
        {
            return View();
        }

        public IActionResult navbar()
        {
            return View();
        }

        public IActionResult timeline()
        {
            return View();
        }

        public IActionResult ribbons()
        {
            return View();
        }

        public IActionResult generalform()
        {
            return View();
        }

        public IActionResult advanced()
        {
            return View();
        }

        public IActionResult editors()
        {
            return View();
        }

        public IActionResult validation()
        {
            return View();
        }

        public IActionResult simple()
        {
            return View();
        }

        public IActionResult data()
        {
            return View();
        }

        public IActionResult jsgrid()
        {
            return View();
        }

        public IActionResult calendar()
        {
            return View();
        }

        public IActionResult gallery()
        {
            return View();
        }

        public IActionResult kanban()
        {
            return View();
        }

        public IActionResult mailbox()
        {
            return View();
        }

        public IActionResult compose()
        {
            return View();
        }

        public IActionResult read_mail()
        {
            return View();
        }

        public IActionResult invoice()
        {
            return View();
        }

        [HttpGet]
        public IActionResult delete(SliderModel sm, int id)
        {
            sm.Delete(id);
            return RedirectToAction("view_slider");
        }

        [HttpGet]
        public IActionResult update(SliderModel sm, int id)
        {
            DataSet ds = sm.update(id);
            ViewBag.ds = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["old_image_name"] = dr["img"].ToString();
            }

            return View();
        }



        [HttpPost]
        public async Task<ActionResult> update(SliderModel sm, int id, int a = 0)
        {
            string title = sm.title;
            string discription = sm.discription;

            var filename = "";

            if (sm.image != null && sm.image.Length > 0)
            {
                filename = Path.GetFileName(sm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await sm.image.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            sm.update_data(id, title, discription, filename);

            return RedirectToAction("view_slider");
        }


        //==========================================================================================================================================


        [HttpGet]
        public IActionResult add_offer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult add_offer(OfferModel om)
        {

            string title = om.title;
            string description = om.discription;
            string icon = om.icon;

            om.insert(title, description, icon);

            return RedirectToAction("add_offer");
        }

        public IActionResult view_offer(OfferModel om)
        {
            DataSet ds = om.select();
            ViewBag.ds = ds.Tables[0];
            return View();
        }

        public IActionResult delete_o(OfferModel om, int id)
        {
            om.Delete(id);
            return RedirectToAction("view_offer");
        }


        [HttpGet]
        public IActionResult update_o(OfferModel om, int id)
        {
            DataSet ds = om.update_o(id);
            ViewBag.ds = ds.Tables[0];
            return View();
        }

        [HttpPost]

        public IActionResult update_o(OfferModel om, int id, int a)
        {
            string title = om.title;
            string discription = om.discription;
            string icon = om.icon;


            om.update_data_o(id, title, discription, icon);
            return RedirectToAction("view_offer");
        }

        //==========================================================================================================================================

        [HttpGet]
        public IActionResult add_about_image()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> add_about_image(about_imageModel im)
        {
            string title = im.title;
            string discription1 = im.discription1;
            string discription2 = im.discription2;



            if (im.image != null && im.image.Length > 0)
            {
                string filename = Path.GetFileName(im.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await im.image.CopyToAsync(str);
                }

                im.insert(title, discription1, discription2, filename);
            }


            return RedirectToAction("add_about_image");
        }



        public IActionResult view_about_image(about_imageModel im)
        {
            DataSet ds = im.select();
            ViewBag.ds = ds.Tables[0];
            return View();
        }

        [HttpGet]
        public IActionResult delete_a(about_imageModel im, int id)
        {
            im.Delete(id);
            return RedirectToAction("view_about_image");
        }


        [HttpGet]
        public IActionResult update_a(about_imageModel im, int id)
        {
            DataSet ds = im.update_a(id);
            ViewBag.ds = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["old_image_name"] = dr["image"].ToString();
            }

            return View();
        }



        [HttpPost]
        public async Task<ActionResult> update_a(about_imageModel im, int id, int a = 0)
        {
            string title = im.title;
            string discription1 = im.discription1;
            string discription2 = im.discription2;



            var filename = "";

            if (im.image != null && im.image.Length > 0)
            {
                filename = Path.GetFileName(im.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await im.image.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            im.update_data_a(id, title, discription1, discription2, filename);

            return RedirectToAction("view_about_image");
        }



        //==========================================================================================================================================


        [HttpGet]
        public IActionResult add_photos()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> add_photos(PhotosModel pm)
        {
            string title = pm.title;
            string discription = pm.discription;



            if (pm.image != null && pm.image.Length > 0)
            {
                string filename = Path.GetFileName(pm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await pm.image.CopyToAsync(str);
                }

                pm.insert(title, discription, filename);
            }
            return RedirectToAction("add_photos");
        }


        public IActionResult view_photos(PhotosModel pm)
        {
            DataSet ds = pm.select();
            ViewBag.ds = ds.Tables[0];
            return View();
        }

        public IActionResult delete_p(PhotosModel pm, int id)
        {
            pm.Delete(id);
            return RedirectToAction("view_photos");
        }




        [HttpGet]
        public IActionResult update_p(PhotosModel pm, int id)
        {
            DataSet ds = pm.update(id);
            ViewBag.ds = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["old_image_name"] = dr["img"].ToString();
            }

            return View();
        }



        [HttpPost]
        public async Task<ActionResult> update_p(PhotosModel pm, int id, int a = 0)
        {
            string title = pm.title;
            string discription = pm.discription;



            var filename = "";

            if (pm.image != null && pm.image.Length > 0)
            {
                filename = Path.GetFileName(pm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await pm.image.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            pm.update_data(id, title, discription, filename);

            return RedirectToAction("view_photos");
        }

       

        [HttpGet]
        public IActionResult add_posts()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> add_posts(PostsModel pm)
        {
            string title = pm.title;
            string name = pm.name;
            string date = pm.date;
            string cat = pm.cat;
            string discription = pm.discription;

            if (pm.image != null && pm.image.Length > 0)
            {
                string filename = Path.GetFileName(pm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await pm.image.CopyToAsync(str);
                }

                pm.insert(title, name, date, cat, discription, filename);
            }





            return RedirectToAction("add_posts");
        }
        public IActionResult view_posts(PostsModel pm)
        {
            DataSet ds = pm.select();
            ViewBag.ds = ds.Tables[0];
            return View();
        }

        public IActionResult delete_po(PostsModel pm, int id)
        {
            pm.Delete(id);
            return RedirectToAction("view_posts");
        }




        [HttpGet]
        public IActionResult update_po(PostsModel pm, int id)
        {
            DataSet ds = pm.update(id);
            ViewBag.ds = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["old_image_name"] = dr["image"].ToString();
            }

            return View();
        }



        [HttpPost]
        public async Task<ActionResult> update_po(PostsModel pm, int id, int a = 0)
        {
            string title = pm.title;
            string name = pm.name;
            string date = pm.date;
            string cat = pm.cat;
            string discription = pm.discription;



            var filename = "";

            if (pm.image != null && pm.image.Length > 0)
            {
                filename = Path.GetFileName(pm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await pm.image.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            pm.update_data(id, title, name, date, cat, discription, filename);

            return RedirectToAction("view_posts");
        }





        //==========================================================================================================================================

        //Services



        [HttpGet]
        public IActionResult s_add_offer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult s_add_offer(ServicesModel sm)
        {

            string title = sm.title;
            string description = sm.discription;
            string icon = sm.icon;

            sm.insert(title, description, icon);

            return RedirectToAction("s_add_offer");
        }

        public IActionResult s_view_offer(ServicesModel sm)
        {
            DataSet ds = sm.select();
            ViewBag.ds = ds.Tables[0];
            return View();
        }

        public IActionResult delete_o_s(ServicesModel sm, int id)
        {
            sm.Delete(id);
            return RedirectToAction("s_view_offer");
        }

        [HttpGet]
        public IActionResult update_o_s(ServicesModel sm, int id)
        {
            DataSet ds = sm.update_o(id);
            ViewBag.ds = ds.Tables[0];
            return View();
        }

        [HttpPost]

        public IActionResult update_o_s(ServicesModel sm, int id, int a)
        {
            string title = sm.title;
            string discription = sm.discription;
            string icon = sm.icon;


            sm.update_data_o(id, title, discription, icon);
            return RedirectToAction("s_view_offer");
        }

        //==========================================================================================================================================



        [HttpGet]
        public IActionResult s_add_photos()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> s_add_photos(s_about_image sam)
        {

            string title = sam.title;
            string discription1 = sam.discription1;
            string discription2 = sam.discription2;



            if (sam.image != null && sam.image.Length > 0)
            {
                string filename = Path.GetFileName(sam.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await sam.image.CopyToAsync(str);
                }

                sam.insert(title, discription1, discription2, filename);
            }


            return RedirectToAction("s_add_photos");
        }

        public IActionResult s_view_photos(s_about_image sam)
        {
            DataSet ds = sam.select();
            ViewBag.ds = ds.Tables[0];
            return View();
        }

        public IActionResult delete_p_s(s_about_image sm, int id)
        {
            sm.Delete(id);
            return RedirectToAction("s_view_photos");
        }


        [HttpGet]
        public IActionResult update_a_s(s_about_image sam, int id)
        {
            DataSet ds = sam.update_a(id);
            ViewBag.ds = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["old_image_name"] = dr["image"].ToString();
            }

            return View();
        }



        [HttpPost]
        public async Task<ActionResult> update_a_s(s_about_image sam, int id, int a = 0)
        {
            string title = sam.title;
            string discription1 = sam.discription1;
            string discription2 = sam.discription2;



            var filename = "";

            if (sam.image != null && sam.image.Length > 0)
            {
                filename = Path.GetFileName(sam.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await sam.image.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            sam.update_data_a(id, title, discription1, discription2, filename);

            return RedirectToAction("s_view_photos");
        }




        //==========================================================================================================================================
        //Clients

        [HttpGet]
        public IActionResult add_clients()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> add_clients(AddclientsModel acm)
        {
            if (acm.image != null && acm.image.Length > 0)
            {
                string filename = Path.GetFileName(acm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await acm.image.CopyToAsync(str);
                }

                acm.insert(filename);
            }


            return RedirectToAction("add_clients");
        }

        public IActionResult view_clients(AddclientsModel am)
        {
            DataSet ds = am.select();
            ViewBag.ds = ds.Tables[0];
            return View();
        }


        public IActionResult delete_c(AddclientsModel am, int id)
        {
            am.Delete(id);
            return RedirectToAction("view_clients");
        }



        [HttpGet]
        public IActionResult update_c(AddclientsModel am, int id)
        {
            DataSet ds = am.update_c(id);
            ViewBag.ds = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["old_image_name"] = dr["image"].ToString();
            }

            return View();
        }



        [HttpPost]
        public async Task<ActionResult> update_c(AddclientsModel am, int id, int a = 0)
        {

            var filename = "";

            if (am.image != null && am.image.Length > 0)
            {
                filename = Path.GetFileName(am.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await am.image.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            am.update_image_c(id, filename);

            return RedirectToAction("view_clients");
        }






        [HttpGet]
        public IActionResult add_classic()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> add_classic(ClassicModel cm)
        {
            string title = cm.title;
            string name = cm.name;
            string date = cm.date;
            string cat = cm.cat;
            string discription = cm.discription;

            if (cm.image != null && cm.image.Length > 0)
            {
                string filename = Path.GetFileName(cm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await cm.image.CopyToAsync(str);
                }

                cm.insert(title, name, date, cat, discription, filename);
            }

            return RedirectToAction("add_classic");
        }


        public IActionResult view_classic(ClassicModel cm)
        {
            DataSet ds = cm.select();
            ViewBag.ds = ds.Tables[0];
            return View();
        }

        public IActionResult delete_blog(ClassicModel cm, int id)
        {
            cm.Delete(id);
            return RedirectToAction("view_classic");
        }




        [HttpGet]
        public IActionResult update_blog(ClassicModel cm, int id)
        {
            DataSet ds = cm.update(id);
            ViewBag.ds = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["old_image_name"] = dr["image"].ToString();
            }

            return View();
        }



        [HttpPost]
        public async Task<ActionResult> update_blog(ClassicModel cm, int id, int a = 0)
        {
            string title = cm.title;
            string name = cm.name;
            string date = cm.date;
            string cat = cm.cat;
            string discription = cm.discription;



            var filename = "";

            if (cm.image != null && cm.image.Length > 0)
            {
                filename = Path.GetFileName(cm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await cm.image.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            cm.update_data(id, title, name, date, cat, discription, filename);

            return RedirectToAction("view_classic");
        }


        //Team


        [HttpGet]
        public IActionResult add_team()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> add_team(TeamModel tm)
        {
            string name = tm.name;
            string post = tm.post;
            string discription = tm.discription;

            if (tm.image != null && tm.image.Length > 0)
            {
                string filename = Path.GetFileName(tm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await tm.image.CopyToAsync(str);
                }

                tm.insert( name,post, discription, filename);
            }

            return RedirectToAction("add_team");
        }



        public IActionResult view_team(TeamModel tm)
        {
            DataSet ds = tm.select();
            ViewBag.ds = ds.Tables[0];
            return View(); 
        }


        public IActionResult delete_t(TeamModel tm, int id)
        {
            tm.Delete(id);
            return RedirectToAction("view_team");
        }


        [HttpGet]
        public IActionResult update_team(TeamModel tm, int id)
        {
            DataSet ds = tm.update(id);
            ViewBag.ds = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["old_image_name"] = dr["image"].ToString();
            }

            return View();
        }



        [HttpPost]
        public async Task<ActionResult> update_team(TeamModel tm, int id, int a = 0)
        {
            string name = tm.name;
            string post = tm.post;
            string discription = tm.discription;


            var filename = "";

            if (tm.image != null && tm.image.Length > 0)
            {
                filename = Path.GetFileName(tm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await tm.image.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            tm.update_data(id, name, post, discription, filename);

            return RedirectToAction("view_team");
        }






		[HttpGet]
		public IActionResult add_clients_a()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> add_clients_a(ClientsModel cm)
		{

            if (cm.image != null && cm.image.Length > 0)
            {
                string filename = Path.GetFileName(cm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await cm.image.CopyToAsync(str);
                }

                cm.insert(filename);
            }


            return RedirectToAction("add_clients");

        }

		public IActionResult view_clients_a(ClientsModel cm)
		{
			DataSet ds = cm.select();
			ViewBag.ds = ds.Tables[0];
			return View();
		}


		public IActionResult delete_c_a(ClientsModel cm, int id)
		{
			cm.Delete(id);
			return RedirectToAction("view_clients_a");
		}



		[HttpGet]
		public IActionResult update_c_a(ClientsModel cm, int id)
		{
			DataSet ds = cm.update_c(id);
			ViewBag.ds = ds.Tables[0];

			foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
			{
				TempData["old_image_name"] = dr["image"].ToString();
			}

			return View();
		}



		[HttpPost]
		public async Task<ActionResult> update_c_a(ClientsModel cm, int id, int a = 0)
		{

			var filename = "";

			if (cm.image != null && cm.image.Length > 0)
			{
				filename = Path.GetFileName(cm.image.FileName);
				string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
				using (var str = new FileStream(fileupload, FileMode.Create))
				{
					await cm.image.CopyToAsync(str);
				}
			}

			if (filename == "")
			{
				filename = TempData.Peek("old_image_name").ToString();
			}

			cm.update_image_c(id, filename);

			return RedirectToAction("view_clients_a");
		}

        //three ==========================================================================================

		[HttpGet]
		public IActionResult add_three()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> add_three(ThreeModel tm)
		{
            string title = tm.title;
            string discription = tm.discription;



            if (tm.image != null && tm.image.Length > 0)
            {
                string filename = Path.GetFileName(tm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await tm.image.CopyToAsync(str);
                }

                tm.insert(title, discription, filename);
            }


            return RedirectToAction("add_three");
		}

		public IActionResult view_three(ThreeModel tm)
		{
			DataSet ds = tm.select();
			ViewBag.ds = ds.Tables[0];
			return View();
		}


		public IActionResult delete_three(ThreeModel tm, int id)
		{
			tm.Delete(id);
			return RedirectToAction("view_three");
		}



		[HttpGet]
		public IActionResult update_three(ThreeModel tm, int id)
		{
			DataSet ds = tm.update(id);
			ViewBag.ds = ds.Tables[0];

			foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
			{
				TempData["old_image_name"] = dr["image"].ToString();
			}

			return View();
		}



		[HttpPost]
		public async Task<ActionResult> update_three(ThreeModel tm, int id, int a = 0)
		{
            string title = tm.title;
            string discription = tm.discription;



            var filename = "";

            if (tm.image != null && tm.image.Length > 0)
            {
                filename = Path.GetFileName(tm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await tm.image.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            tm.update_data(id, title, discription, filename);

            return RedirectToAction("view_three");
		}



		//Four ====================================================================================================================================================


		[HttpGet]
		public IActionResult add_four()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> add_four(FourModel fm)
		{
			string title = fm.title;
			string discription = fm.discription;



			if (fm.image != null && fm.image.Length > 0)
			{
				string filename = Path.GetFileName(fm.image.FileName);
				string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

				using (var str = new FileStream(fileupload, FileMode.Create))
				{
					await fm.image.CopyToAsync(str);
				}

				fm.insert(title, discription, filename);
			}


			return RedirectToAction("add_four");
		}

		public IActionResult view_four(FourModel fm)
		{
			DataSet ds = fm.select();
			ViewBag.ds = ds.Tables[0];
			return View();
		}


		public IActionResult delete_four(FourModel fm, int id)
		{
			fm.Delete(id);
			return RedirectToAction("view_four");
		}



		[HttpGet]
		public IActionResult update_four(FourModel fm, int id)
		{
			DataSet ds = fm.update(id);
			ViewBag.ds = ds.Tables[0];

			foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
			{
				TempData["old_image_name"] = dr["image"].ToString();
			}

			return View();
		}



		[HttpPost]
		public async Task<ActionResult> update_four(FourModel fm, int id, int a = 0)
		{
			string title = fm.title;
			string discription = fm.discription;



			var filename = "";

			if (fm.image != null && fm.image.Length > 0)
			{
				filename = Path.GetFileName(fm.image.FileName);
				string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
				using (var str = new FileStream(fileupload, FileMode.Create))
				{
					await fm.image.CopyToAsync(str);
				}
			}

			if (filename == "")
			{
				filename = TempData.Peek("old_image_name").ToString();
			}

			fm.update_data(id, title, discription, filename);

			return RedirectToAction("view_four");
		}


		//Single post ============================================================================================================================================================================

		[HttpGet]
		public IActionResult add_single()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> add_single(SingleModel sm)
		{
			string title = sm.title;
			string discription = sm.discription;



			if (sm.image != null && sm.image.Length > 0)
			{
				string filename = Path.GetFileName(sm.image.FileName);
				string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

				using (var str = new FileStream(fileupload, FileMode.Create))
				{
					await sm.image.CopyToAsync(str);
				}

				sm.insert(title, discription, filename);
			}


			return RedirectToAction("add_single");
		}

		public IActionResult view_single(SingleModel sm)
		{
			DataSet ds = sm.select();
			ViewBag.ds = ds.Tables[0];
			return View();
		}


		public IActionResult delete_single(SingleModel sm, int id)
		{
			sm.Delete(id);
			return RedirectToAction("view_single");
		}



		[HttpGet]
		public IActionResult update_single(SingleModel sm, int id)
		{
			DataSet ds = sm.update(id);
			ViewBag.ds = ds.Tables[0];

			foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
			{
				TempData["old_image_name"] = dr["image"].ToString();
			}

			return View();
		}



		[HttpPost]
		public async Task<ActionResult> update_single(SingleModel sm, int id, int a = 0)
		{
			string title = sm.title;
			string discription = sm.discription;



			var filename = "";

			if (sm.image != null && sm.image.Length > 0)
			{
				filename = Path.GetFileName(sm.image.FileName);
				string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
				using (var str = new FileStream(fileupload, FileMode.Create))
				{
					await sm.image.CopyToAsync(str);
				}
			}

			if (filename == "")
			{
				filename = TempData.Peek("old_image_name").ToString();
			}

			sm.update_data(id, title, discription, filename);

			return RedirectToAction("view_single");
		}


		//==========================================================================================================================================================================


		[HttpGet]
		public IActionResult add_work_slider()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> add_work_slider(WorksliderModsel wsm)
		{
			if (wsm.image != null && wsm.image.Length > 0)
			{
				string filename = Path.GetFileName(wsm.image.FileName);
				string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

				using (var str = new FileStream(fileupload, FileMode.Create))
				{
					await wsm.image.CopyToAsync(str);
				}

				wsm.insert( filename);
			}





			return RedirectToAction("add_work_slider");
		}

		public IActionResult view_work_slider(WorksliderModsel wsm)
		{
			DataSet ds = wsm.select();
			ViewBag.ds = ds.Tables[0];
			return View();
		}

		public IActionResult delete_work(WorksliderModsel wsm, int id)
		{
			wsm.Delete(id);
			return RedirectToAction("view_work_slider");
		}



		[HttpGet]
		public IActionResult update_work(WorksliderModsel wsm, int id)
		{
			DataSet ds = wsm.update(id);
			ViewBag.ds = ds.Tables[0];

			foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
			{
				TempData["old_image_name"] = dr["image"].ToString();
			}

			return View();
		}



		[HttpPost]
		public async Task<ActionResult> update_work(WorksliderModsel wsm, int id, int a = 0)
		{

			var filename = "";

			if (wsm.image != null && wsm.image.Length > 0)
			{
				filename = Path.GetFileName(wsm.image.FileName);
				string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
				using (var str = new FileStream(fileupload, FileMode.Create))
				{
					await wsm.image.CopyToAsync(str);
				}
			}

			if (filename == "")
			{
				filename = TempData.Peek("old_image_name").ToString();
			}

			wsm.update_data(id, filename);

			return RedirectToAction("view_work_slider");
		}

        //Work Text ========================================================================================================================================


        [HttpGet]
        public IActionResult add_work_text()
        {
            return View();
        }

        [HttpPost]
        public IActionResult add_work_text(WorktextModel ws)
        {

            string title = ws.title;
            string name = ws.name;
            string date = ws.date;
            string cat = ws.cat;    
            string discription1 = ws.discription1;
            string heading = ws.heading;
            string discription2 = ws.discription2;

            ws.insert(title,name,date,cat, discription1,heading,discription2 );

            return RedirectToAction("add_work_text");
        }

        public IActionResult view_work_text(WorktextModel ws)
        {
            DataSet ds = ws.select();
            ViewBag.ds = ds.Tables[0];
            return View();
        }

        public IActionResult delete_work_text(WorktextModel ws, int id)
        {
            ws.Delete(id);
            return RedirectToAction("view_work_text");
        }

        [HttpGet]
        public IActionResult update_work_text(WorktextModel ws, int id)
        {
            DataSet ds = ws.update(id);
            ViewBag.ds = ds.Tables[0];
            return View();
        }

        [HttpPost]

        public IActionResult update_work_text(WorktextModel ws, int id, int a)
        {
            string title = ws.title;
            string name = ws.name;
            string date = ws.date;
            string cat = ws.cat;
            string discription1 = ws.discription1;
            string heading = ws.heading;
            string discription2 = ws.discription2;


            ws.update_data(id, title,name,date,cat, discription1, heading,discription2);
            return RedirectToAction("view_work_text");
        }

        //======================================================================================================================================================================================

        public IActionResult view_msg(CommentModel cm)
        {
            DataSet ds = cm.select();
            ViewBag.ds = ds.Tables[0];
            return View(); 
        }

        public IActionResult delete_msg(CommentModel cm, int id)
        {
            cm.Delete(id);
            return RedirectToAction("view_msg");
        }


        //===========================================================================================================================================================================================================

        [HttpGet]
        public IActionResult add_blog_slider()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> add_blog_slider(BlogsliderModel bm)
        {
            
                if (bm.image != null && bm.image.Length > 0)
                {
                    string filename = Path.GetFileName(bm.image.FileName);
                    string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

                    using (var str = new FileStream(fileupload, FileMode.Create))
                    {
                        await bm.image.CopyToAsync(str);
                    }

                    bm.insert(filename);
                }


                return RedirectToAction("add_blog_slider");
            }

        public IActionResult view_blog_slider(BlogsliderModel bm)
        {
            DataSet ds = bm.select();
            ViewBag.ds = ds.Tables[0];

            return View(); 
        }



        public IActionResult delete_blog_slider(BlogsliderModel bm, int id)
        {
            bm.Delete(id);
            return RedirectToAction("view_blog_slider");
        }



        [HttpGet]
        public IActionResult update_blog_slider(BlogsliderModel bm, int id)
        {
            DataSet ds = bm.update(id);
            ViewBag.ds = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["old_image_name"] = dr["image"].ToString();
            }

            return View();
        }



        [HttpPost]
        public async Task<ActionResult> update_blog_slider(BlogsliderModel bm, int id, int a = 0)
        {

            var filename = "";

            if (bm.image != null && bm.image.Length > 0)
            {
                filename = Path.GetFileName(bm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await bm.image.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            bm.update_data(id, filename);

            return RedirectToAction("view_blog_slider");
        }


		//======================================================================================================================================================================================================
		public IActionResult view_blog_text(BlogtextModel btm)
		{
			DataSet ds = btm.select();
			ViewBag.ds = ds.Tables[0];

			return View();
		}





        [HttpGet]
        public IActionResult update_blog_text(BlogtextModel btm, int id)
        {
            DataSet ds = btm.update(id);
            ViewBag.ds = ds.Tables[0];
            return View();
        }

        [HttpPost]

        public IActionResult update_blog_text(BlogtextModel btm, int id, int a)
        {
            string title = btm.title;
            string name = btm.name;
            string date = btm.date;
            string cat = btm.cat;
            string discription1 = btm.discription1;
            string heading = btm.heading;
            string discription2 = btm.discription2;


            btm.update_data(id, title, name, date, cat, discription1, heading, discription2);
            return RedirectToAction("view_blog_text");
        }


    }
}
