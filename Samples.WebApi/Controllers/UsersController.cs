using System;
using Microsoft.AspNetCore.Mvc;
using Samples.WebApi.Models;

namespace Samples.WebApi.Controller
{

    [Route("api/[controller]")]
    public class UsersController : Microsoft.AspNetCore.Mvc.Controller
    {

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = new User() { Id = id, Name = "Name:" + id, Sex = "Male" };
            return new ObjectResult(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user){
            if(user == null){
                return BadRequest();
            }

            // TODO：新增操作
            user.Id = new Random().Next(1, 10);
            return CreatedAtAction("Get", new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user){
            if(user == null){
                return BadRequest();
            }

            // TODO: 更新操作
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id){
            // TODO: 删除操作
            
        }
    }
}