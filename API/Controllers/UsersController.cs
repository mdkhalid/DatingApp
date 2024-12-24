using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(DataContext _context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id){
            var user = await _context.Users.FindAsync(id);
            if(user== null) return NotFound("User not found");
            return Ok(user);
        }
    }
}