using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Catarina.Core.Entities;
using Catarina.Web.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catarina.Web.Controllers
{
    [Route( "[controller]/[action]" )]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _claimsFactory;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IEmailSender _emailSender;

        public AccountController( UserManager<ApplicationUser> userManager
            , IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory 
            , SignInManager<ApplicationUser> signInManager
            , ILogger<AccountController> logger
            , IEmailSender emailSender )
        {
            _userManager = userManager;
            _claimsFactory = claimsFactory;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            try
            {
                var applicationUser = new ApplicationUser { UserName = model.Email, Email = model.Email };

                var result = await _userManager.CreateAsync( applicationUser, model.Password );

                if ( result.Succeeded )
                {
                    return Ok();
                }
                else
                    return BadRequest( result.Errors );

            }catch(Exception ex )
            {
                _logger.LogError( "ERROR: AccountController - ${ex.Message}" );
                return StatusCode( StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPost]
        [Authorize(Roles="admin")]
        public async Task<ActionResult> ChangePassword(ChangePasswordModel model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                var roles = await _userManager.GetRolesAsync(user);

                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword );

                if ( result.Succeeded )
                    return Ok();
                else
                    return BadRequest( result.Errors );

            }
            catch ( Exception ex )
            {
                _logger.LogError( "ERROR: AccountController - ${ex.Message}" );
                return StatusCode( StatusCodes.Status500InternalServerError, ex.Message );
            }
        }

        [HttpPost]
        public async Task<ActionResult> GetEmailConfirmation(GetEmailConfirmationModel model )
        {
            try
            {
                var applicationUser = await _userManager.FindByNameAsync( model.Email );

                if ( applicationUser != null )
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync( applicationUser );

                    var confirmationLink = Url.Action( nameof( ConfirmEmail ), "Account", new { token, email = model.Email }, Request.Scheme );

                    await _emailSender.SendEmailAsync( model.Email, "Catarina Demo App - Confirm your account", confirmationLink );

                    return Ok();
                }
                else
                    return BadRequest( "Email not found." );

            }
            catch ( Exception ex )
            {
                _logger.LogError( "ERROR: AccountController - ${ex.Message}" );
                return StatusCode( StatusCodes.Status500InternalServerError, ex.Message );
            }
        }

        [HttpGet]
        public async Task<ActionResult> ConfirmEmail([FromQuery]ConfirmMailModel model)
        {
            try
            {
                var applicationUser = await _userManager.FindByNameAsync( model.Email );

                var result = await _userManager.ConfirmEmailAsync( applicationUser, model.Token );

                if ( result.Succeeded )
                    return Ok();
                else
                    return BadRequest( result.Errors );

            }
            catch ( Exception ex )
            {
                _logger.LogError( "ERROR: AccountController - ${ex.Message}" );
                return StatusCode( StatusCodes.Status500InternalServerError, ex.Message );
            }
        }


    }
}
