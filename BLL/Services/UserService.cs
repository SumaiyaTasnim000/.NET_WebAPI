using AutoMapper;
using DAL.EF;
using DAL.Repos;
using BLL.DTOs; 
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class UserService
    {
        private static readonly UserRepo userRepo = new UserRepo();

        
        private static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
            });
            return new Mapper(config);
        }

        public static List<UserDTO> Get()
        {
            var users = userRepo.Get();
            return GetMapper().Map<List<UserDTO>>(users);
        }

        public static void Create(UserDTO userDto)
        {
            var user = GetMapper().Map<User>(userDto);
            userRepo.Add(user);
        }

        public static void Update(UserDTO userDto)
        {
            var user = GetMapper().Map<User>(userDto);
            userRepo.Update(user);
        }

        
        public static void Delete(int id)
        {
            userRepo.Delete(id);
        }
    }
}
