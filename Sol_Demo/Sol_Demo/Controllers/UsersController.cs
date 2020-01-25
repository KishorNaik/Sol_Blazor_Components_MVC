using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sol_Demo.Models;
using Sol_Demo.ViewModels;

namespace Sol_Demo.Controllers
{
    // https://chrissainty.com/using-blazor-components-in-an-existing-mvc-application/

    public class UsersController : Controller
    {

        public UsersController()
        {
            this.UserVM = new UsersViewModel();
        }


        [BindProperty]
        public UsersViewModel UserVM { get; set; }

        [BindProperty(SupportsGet =true)]
        public int Id { get; set; }

        private void AddListOfUsers()
        {
            List<UsersModel> listUserModel = new List<UsersModel>();
            listUserModel.Add(new UsersModel()
            {
                Id = 1,
                FirstName = "Kishor",
                LastName = "Naik"
            });
            listUserModel.Add(new UsersModel()
            {
                Id = 2,
                FirstName = "Eshaan",
                LastName = "Naik"
            });

            UserVM.UsersList = listUserModel;
        }

        private void SetTempData()
        {
            TempData["UserDetails"] = JsonConvert.SerializeObject(UserVM.UsersList);
            TempData.Keep();
        }

        public IActionResult Index()
        {

            AddListOfUsers();

            SetTempData();

            return View(UserVM);
        }

        [HttpGet("Users/Details/{Id}", Name ="UserDetails")]
        public IActionResult Details()
        {
            UserVM.Users =
                    (
                        JsonConvert
                            .DeserializeObject<List<UsersModel>>(TempData["UserDetails"] as string)
                    )
                    ?.AsEnumerable()
                    ?.FirstOrDefault((leUserModel) => leUserModel.Id == Id);

            TempData.Keep();

            return View(UserVM);
        }
    }
}