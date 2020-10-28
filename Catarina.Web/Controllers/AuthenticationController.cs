//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Catarina.Core.Entities;
//using Catarina.Web.Models.Authentication;
//using Catarina.Web.Providers.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;

//namespace Catarina.Web.Controllers
//{
//    [Route( "[controller]/[action]" )]
//    [ApiController]
//    public class AuthenticationController : ControllerBase
//    {
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _claimsFactory;
//        private readonly SignInManager<ApplicationUser> _signInManager;
//        private readonly ILogger<AuthenticationController> _logger;
//        private readonly RoleManager<IdentityRole> _roleManager;
//        private readonly IRoleStore<IdentityRole> _roleStore;
        
//        public AuthenticationController( UserManager<ApplicationUser> userManager
//            , IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory
//            , SignInManager<ApplicationUser> signInManager
//            , ILogger<AuthenticationController> logger
//            , RoleManager<IdentityRole> roleManager
//            , IRoleStore<IdentityRole> roleStore )
//        {
//            _userManager = userManager;
//            _claimsFactory = claimsFactory;
//            _signInManager = signInManager;
//            _logger = logger;
//            _roleManager = roleManager;
//            _roleStore = roleStore;
//        }

//        [HttpPost]
//        public async Task<ActionResult> Login( LoginModel model)
//        {
//            try
//            {
//                var result = await _signInManager.PasswordSignInAsync( model.UserName, model.Password, model.IsPersistent, false );

//                if ( result.Succeeded )
//                {
//                    var user = await _userManager.FindByNameAsync( model.UserName );
//                    var userRoles = await _userManager.GetRolesAsync( user );
//                    var token = TokenProvider.Create( user, userRoles.ToArray() );

//                    return Ok(new { Token = token} );
//                }
//                else
//                    return Unauthorized();

//            }
//            catch ( Exception ex )
//            {
//                _logger.LogError( "ERROR: AuthenticationController - ${ex.Message}" );
//                return StatusCode( StatusCodes.Status500InternalServerError, ex );
//            }

//        }

//        [HttpGet]
//        public async Task<ActionResult> Logout()
//        {
//            try
//            {
//                await _signInManager.SignOutAsync();

//                return Ok();

//            }
//            catch ( Exception ex )
//            {
//                _logger.LogError( "ERROR: AuthenticationController - ${ex.Message}" );
//                return StatusCode( StatusCodes.Status500InternalServerError, ex );
//            }
//        }

//    }
//}
