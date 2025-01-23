using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BorrowService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Borrow, BorrowDTO>()
                    .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title))
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name));
                cfg.CreateMap<BorrowDTO, Borrow>();
            });
            var mapper = new Mapper(config);
            return mapper;
        }

        public static void Create(BorrowDTO b)
        {
            new BorrowRepo().Create(GetMapper().Map<Borrow>(b));
        }

        public static List<BorrowDTO> Get()
        {
            return GetMapper().Map<List<BorrowDTO>>(new BorrowRepo().Get());
        }

        public static void Update(BorrowDTO b)
        {
            new BorrowRepo().Update(GetMapper().Map<Borrow>(b));
        }

        public static void Delete(int id)
        {
            new BorrowRepo().Delete(id);
        }
    }
}

