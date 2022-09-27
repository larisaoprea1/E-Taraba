using AutoMapper;
using ETaraba.Domain.Models;
using ETaraba.DTOs.UserDTOs;

namespace ETaraba.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<UserForCreationDTO, User>();
        }
    }
}
