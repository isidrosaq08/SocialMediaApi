using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Dtos;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRespository _postRespository;
        private readonly IMapper _mapper;

        public PostController(IPostRespository postRespository, IMapper mapper)
        {
            _postRespository = postRespository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postRespository.GetPosts();
            var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);
            return Ok(postsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRespository.GetPost(id);
            var postDto = _mapper.Map<PostDto>(post);
            return Ok(postDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _postRespository.AddPost(post);
            return Ok(post);
        }
    }
}
