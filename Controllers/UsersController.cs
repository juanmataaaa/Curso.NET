using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private static List<User> _users = new List<User>
    {
        new User { Id = 1, Name = "TechHive User", Email = "hola@techhive.com" }
    };

    [HttpGet]
    public ActionResult<List<User>> GetAll()
    {
        try 
        {
            // Simulación de optimización: devolvemos la lista directamente
            return Ok(_users);
        }
        catch (Exception)
        {
            return StatusCode(500, "Error al recuperar la lista de usuarios");
        }
    }

    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
        try 
        {
            var user = _users.Find(u => u.Id == id);
            // Corregimos el error de "búsqueda fallida": ahora damos un mensaje claro
            if (user == null) return NotFound(new { message = $"Usuario con ID {id} no encontrado" });
            return Ok(user);
        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno al buscar el usuario");
        }
    }

    [HttpPost]
    public ActionResult Create(User user)
    {
        // Añadimos validación: si el modelo no es válido (ej. email mal escrito), devuelve error
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            _users.Add(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }
        catch (Exception)
        {
            return StatusCode(500, "Error al intentar añadir el usuario");
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, User user)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            var index = _users.FindIndex(u => u.Id == id);
            if (index == -1) return NotFound(new { message = "No se puede actualizar un usuario inexistente" });
            
            _users[index] = user;
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, "Error al actualizar el usuario");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var user = _users.Find(u => u.Id == id);
            if (user == null) return NotFound(new { message = "El usuario ya no existe o no se pudo encontrar" });
            
            _users.Remove(user);
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, "Error al eliminar el usuario");
        }
    }
}