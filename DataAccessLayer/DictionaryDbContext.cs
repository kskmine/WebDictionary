using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class DictionaryDbContext:DbContext
    {
        public DictionaryDbContext(DbContextOptions<DictionaryDbContext> options):base(options)
        {

        }
        public DbSet<Word> _Words { get; set; }
    }
}
