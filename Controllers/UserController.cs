using System.Security.Cryptography.X509Certificates;
using Catedra1IDWM.Src.Data;
using Catedra1IDWM.Src.DTOs;
using Catedra1IDWM.Src.Interfaces;
using Catedra1IDWM.Src.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catedra1IDWM.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase 
    {
        private readonly DataContext _context;
        private readonly IUserRepository _userRepository;

        public UserController (DataContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.Usuarios.ToListAsync();
            return Ok(users);
        }

        [HttpPost("create-user")]
        public IActionResult CreateUser([FromBody] CreateUserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existingUser = _userRepository.ExistsByRut(user.Rut);
                if (existingUser != null)
                {
                    return Conflict("El RUT ya existe.");
                }

                _context.Usuarios.AddAsync(user);
                _context.SaveChangesAsync();
                return StatusCode(201, "Usuario creado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditUser(int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existingUser = await _userRepository.ExistsById(id);
                if (existingUser == null)
                {
                    return NotFound("Usuario no encontrado.");
                }

                existingUser.Rut = user.Rut;
                existingUser.Nombre = user.Nombre;
                existingUser.Correo = user.Correo;
                existingUser.Genero = user.Genero;
                existingUser.FechaNacimiento = user.FechaNacimiento;

                _context.Usuarios.Update(existingUser);
                return Ok("Usuario actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        [HttpPut]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var existingUser = await _userRepository.ExistsById(id);
                if (existingUser == null)
                {
                    return NotFound("Usuario no encontrado.");
                }

                _context.Usuarios.Remove(existingUser);
                await _context.SaveChangesAsync();
                return Ok("Usuario eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }
}