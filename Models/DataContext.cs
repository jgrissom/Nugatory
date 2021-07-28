using Microsoft.EntityFrameworkCore;

namespace Nugatory.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<WordColor> WordColors { get; set; }

        public WordColor AddWord(WordColor wordColor)
        {
            this.Add(wordColor);
            this.SaveChanges();
            return wordColor;
        }
    }
}
