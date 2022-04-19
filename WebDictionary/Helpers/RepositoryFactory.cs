using DataAccessLayer;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDictionary.Helpers
{
    public class RepositoryFactory
    {
        static IRepositoryWord _repoWord;
        public static IRepositoryWord CreateRepo(string tip)
        {
            if (_repoWord == null)
            {
                if (tip == "WORD")
                {
                    lock (new object())
                    {
                        //_repoWord = new WordRepositoryJson();
                        var optionsBuilder = new DbContextOptionsBuilder<DictionaryDbContext>();
                        optionsBuilder.UseSqlServer("Server=DESKTOP-8MD6TH1\\SQLEXPRESS;Database=DictionaryDb;Trusted_Connection=True;MultipleActiveResultSets=true");
                     
                        DictionaryDbContext context = new DictionaryDbContext(optionsBuilder.Options);
                        _repoWord = new WordRepository(context);
                    }
                    return _repoWord;
                }
                else
                    return null;
            }
            else
                return _repoWord;
        }
    }
}
