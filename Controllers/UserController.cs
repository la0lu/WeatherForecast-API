using APICLass.Data.Entities;
using APICLass.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APICLass.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody]AddUserDto model)
        {
            if(ModelState.IsValid)
            {
                var user = new AppUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.Phonenumber,
                    UserName = model.Email //$"{model.FirstName}{ model.LastName.Substring(0, 4)}"
                };

                var identityResult = await _userManager.CreateAsync(user, model.Password);
               
                if (identityResult.Succeeded)
                {
                    var userToReturn = new ReturnUserDto
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Phonenumber = user.PhoneNumber
                    };

                   return Ok(userToReturn);

                }

                foreach(var err in identityResult.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
                
            }
            return BadRequest(ModelState);
        }


        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var users = _userManager.Users.ToList();
            var usersToReturn = new List<ReturnUserDto>();

            if (users.Any())
            {
              foreach(var user in users)
              {
                    usersToReturn.Add(new ReturnUserDto
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Phonenumber = user.PhoneNumber
                    });

              }
                
            }
            
            return Ok(usersToReturn);

        }
    }
}
