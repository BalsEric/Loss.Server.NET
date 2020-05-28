using Loss.BLL.Services;
using Loss.DAL.Models;
using System.Collections.Generic;
using System.Web.Http;
using System;
using Loss.BLL.IServices;

namespace Loss.Controllers
{
	[RoutePrefix("api/user")]
	public sealed class UserController : ApiController
	{
		private readonly IUserService userService;

		public UserController()
		{
			userService = new UserService();
		}

		// GET api/user/all
		[Route("all")]
		[HttpGet]
		public IHttpActionResult Get()
		{
			try
			{
				return Ok(userService.Get());
			}
			catch (Exception)
			{
				return NotFound();
			}

		}

		// POST api/user/authentification
		[Route("authentification")]
		[HttpPost]
		public IHttpActionResult Login([FromBody]User user)
		{
			try
			{
				userService.Login(user);
				string guid = UserGuid.GetGuidByUsername(user.Username);
				if (guid == string.Empty)
				{
					return NotFound();
				}
				return Ok(guid);
			}
			catch (Exception)
			{
				return Unauthorized();
			}
		}


		// POST api/user/registration
		[Route("registration")]
		[HttpPost]
		public IHttpActionResult Add([FromBody]User user)
		{
			try
			{
				userService.Add(user);
				return Ok(200);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return NotFound();
			}
		}

		// GET api/user/{username}
		[Route("{username}")]
		[HttpGet]
		public IHttpActionResult GetUserByUsername(string username)
		{
			try
			{
				return Ok(userService.GetUserByUsername(username));
			}
			catch (Exception)
			{
				return NotFound();
			}
		}


	}
}
