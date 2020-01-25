using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.ViewModels
{
    public class UsersViewModel
    {
        public List<UsersModel> UsersList { get; set; }

        public UsersModel Users { get; set; }
    }
}
