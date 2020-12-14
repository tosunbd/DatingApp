using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {        
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper) 
        { 
            _mapper = mapper;
            _userRepository = userRepository; 
        }

        //api/users
        // [HttpGet(Name = "GetUsers")]
        // public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        // {
        //     var users = await _userRepository.GetUsersAsync();
        //     var usersToRetun = _mapper.Map<IEnumerable<MemberDto>>(users);
        //     return Ok(usersToRetun);
        // }

        //api/users/3        
        // [HttpGet("{id:int}", Name = "GetUserById")]
        // public async Task<ActionResult<MemberDto>> GetUserById(int id)
        // {
        //     var user = await _userRepository.GetUserByIdAsync(id);            
        //     var usersToRetun = _mapper.Map<MemberDto>(user);
        //     return usersToRetun;
        // }

        //api/users/username
        //[HttpGet("username:alpha}")]
        // [HttpGet("{username:alpha}", Name = "GetUserByUserName")]
        // public async Task<ActionResult<MemberDto>> GetUserByUserName(string username)
        // {
        //     var user = await _userRepository.GetUserByUserNameAsync(username);
        //     var usersToRetun = _mapper.Map<MemberDto>(user);
        //     return usersToRetun;
        // }

        [HttpGet]
        //[HttpGet(Name = "GetMembers")]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetMembersAsync()
        {
            var users = await _userRepository.GetMembersAsync();
            return Ok(users);
        }

        //api/users/3
        //[HttpGet("{id:int}")]
        [HttpGet("{id:int}", Name = "GetMemberById")]
        public async Task<ActionResult<MemberDto>> GetMemberById(int id)
        {
            return await _userRepository.GetMemberByIdAsync(id);
        }

        //api/users/username
        //[HttpGet("{username:alpha}")]
        [HttpGet("{username:alpha}", Name = "GetMemberByUserName")]
        public async Task<ActionResult<MemberDto>> GetMemberByUserName(string username)
        {
            return await _userRepository.GetMemberByUserNameAsync(username);
        }

    }
}