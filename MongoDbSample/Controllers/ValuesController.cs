using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDbSample.Infastructure;
using MongoDbSample.Models;

namespace MongoDbSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /*
         
             {
  "Id": null,
  "CreatedUser": {
    "UserId": "a741e294-c756-43a8-8061-f9d4b875c8e8",
    "ProfileImage": "chamith.png",
    "Name": "Chamith"
  },
  "Status": {
    "NumberOfComments": 0,
    "NumberOfLikes": 0,
    "NumberOfShared": 0
  },
  "CreatedOn": "0001-01-01T00:00:00",
  "Title": "Random 281c6ca4-b704-4b03-871f-9a9111585cd8"
}

             */

        PostRepository _postRepository;
        public ValuesController(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _postRepository.Get());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _postRepository.GetById(id));
        }

        [HttpGet("search")]
        public async Task<IActionResult> Get(int skip, int take, string searchBy, string searchByTerm, string orderBy, bool orderByTerm) {

            return Ok(await _postRepository.Get(skip, take, searchBy, searchByTerm, orderBy, orderByTerm));
        }
        [HttpGet("users/{userid}")]
        public async Task<IActionResult> GetByUserId(string userid)
        {
            return Ok(await _postRepository.GetByUserId(Guid.Parse(userid)));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Post value)
        {
            await _postRepository.Add(value);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Post value)
        {
            await _postRepository.Update(value);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _postRepository.Delete(id);
            return Ok();
        }
    }
}
