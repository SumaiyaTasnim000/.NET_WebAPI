using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL.Repos;
using System.Collections.Generic;

namespace BLL.Services
{
    public class BooksService
    {
        private static readonly BooksRepo repo = new BooksRepo();

        public static List<BooksDTO> Get()
        {
            var books = repo.Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Books, BooksDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<List<BooksDTO>>(books);
        }

        public static BooksDTO Get(int id)
        {
            var book = repo.Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Books, BooksDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<BooksDTO>(book);
        }

        public static void Create(BooksDTO s)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BooksDTO, Books>());
            var mapper = new Mapper(config);
            var book = mapper.Map<Books>(s);
            repo.Create(book);
        }

        public static void Update(BooksDTO s)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BooksDTO, Books>());
            var mapper = new Mapper(config);
            var book = mapper.Map<Books>(s);
            repo.Update(book);
        }

        public static void Delete(int id)
        {
            repo.Delete(id);
        }

        public static List<BooksDTO> Search(string title, string author, string genre)
        {
            var books = repo.Search(title, author, genre);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Books, BooksDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<List<BooksDTO>>(books);
        }
    }
}
