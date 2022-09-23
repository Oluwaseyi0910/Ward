using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoyalKiddiesWard.Application.Services.Interfaces;
using System.Security.Claims;

namespace RoyalKiddiesWard.API.Controllers
{
    [Route("simple-auth")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IUserService _userService;

        public OperationController(IUserService userService)
        {
            _userService = userService;
        }

       

    }
    }

