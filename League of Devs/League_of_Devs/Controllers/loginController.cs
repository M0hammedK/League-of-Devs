﻿using Microsoft.AspNetCore.Mvc;
using League_of_Devs.Models;
using League_of_Devs.DateBase;

namespace League_of_Devs.Controllers
{
	public class loginController : Controller
	{
		public static AccountsModel User;
		public IActionResult login()
		{
			return View();
		}
		public IActionResult register()
		{
			ViewBag.msg = "";
			return View();
		}

		[HttpPost]
		public IActionResult login(AccountsModel account)
		{
			List<AccountsModel> accounts = new List<AccountsModel>();
			using Data data = new Data();
			accounts = data.accounts.Where(x => x.Email == account.Email).ToList();
			if(accounts.Count != 0)
            {
				if(accounts[0].Password == account.Password)
                {
					User = accounts[0];
					return RedirectToAction("index", "Home");
                }
            }
			ViewBag.msg = "Email Or Password is not correct. Try again";
			return View();
		}
		
		[HttpPost]
		public IActionResult Register(AccountsModel account)
		{
			List<AccountsModel> accounts = new List<AccountsModel>();
			using Data data=new Data();
			accounts=data.accounts.Where(x =>x.Email==account.Email).ToList();
			if (accounts.Count == 0)
			{
				if (account.Password == account.Password2)
				{
					data.accounts.Add(account);
					data.SaveChanges();
					return RedirectToAction("login", "login");

				}
				else ViewBag.msg = "passwords don't match";


			} else ViewBag.msg = "Email is already registerd";
		
			return View();
		}
	}
}
