using System.Data;
using Microsoft.AspNetCore.Mvc;
using piqe.Core;
using piqe.Models;

namespace piqe.API;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    public readonly ILogger<UsersController> _logger;
    public readonly IRepository<User> _repoUser;
    public UsersController(ILogger<UsersController> logger, IRepository<User> repoUser)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _repoUser = repoUser ?? throw new ArgumentNullException(nameof(repoUser));
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _repoUser.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _repoUser.GetByGuidAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserDTO userDTO)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                throw new DataException();
            }
            var newUser = await _repoUser.AddAsync(UserDTO.ToUser(userDTO));
            return Ok(newUser);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UserDTO userDTO)
    {
        try
        {
            if (id == Guid.Empty || default(Guid) == id)
            {
                throw new ArgumentException(nameof(id));
            }
            var originalUser = await _repoUser.GetByGuidAsync(id);
            if (originalUser == null)
            {
                throw new Exception("User not found.");
            }
            await _repoUser.UpdateAsync(UserDTO.ToUser(userDTO));
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            if (id == Guid.Empty || default(Guid) == id)
            {
                throw new ArgumentException(nameof(id));
            }
            var user = await _repoUser.GetByGuidAsync(id);
            await _repoUser.DeleteAsync(user);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return StatusCode(500, ex.Message);
        }
    }
}
