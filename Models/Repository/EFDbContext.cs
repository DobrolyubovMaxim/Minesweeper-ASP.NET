using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Minesweper.Models.Repository
{
    public class EFDbContext : DbContext
    {
        public DbSet<Highscores> Highscores { get; set; }

        //public EFDbContext()
        //{
        //    // Указывает EF, что если модель изменилась,
        //    // нужно воссоздать базу данных с новой структурой
        //    Database.SetInitializer(
        //        new DropCreateDatabaseIfModelChanges<EFDbContext>());
        //}
    }
}