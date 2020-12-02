using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserRepository(DataContext context, IMapper mapper) 
        {
            _mapper = mapper;
             _context = context;
        }

        public async Task<MemberDto> GetMemberByIdAsync(int id)
        {
            return await _context.Users
                    .Where(x => x.Id == id)
                    .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync();
        }

        public async Task<MemberDto> GetMemberByUserNameAsync(string username)
        {
            return await _context.Users
                    .Where(x => x.UserName == username)
                    .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync();
        }

        public Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            AppUser appUser = await _context.Users.FindAsync(id);
            return appUser;
        }
        public async Task<AppUser> GetUserByUserNameAsync(string username)
        {
            AppUser appUser = await _context.Users.Include(p => p.Photos).SingleOrDefaultAsync(x => x.UserName == username);
            return appUser;
        }
        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            List<AppUser> lists = await _context.Users.Include(p => p.Photos).ToListAsync();
            return lists;
        }
        public async Task<bool> SaveAllAsync() => await _context.SaveChangesAsync() > 0;
        public void Update(AppUser user) => _context.Entry(user).State = EntityState.Modified;
    }
}