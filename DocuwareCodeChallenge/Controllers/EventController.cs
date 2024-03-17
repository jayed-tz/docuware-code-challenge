using System;
using DocuwareCodeChallenge.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace DocuwareCodeChallenge.Controllers
{
    [ApiController]
    [Route("events")]
    public class EventController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public string Get()
        {
            return "Auth works";
        }
    }
}

