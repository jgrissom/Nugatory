using System.Linq;
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

        public void DeleteWord(int id)
        {
            this.Remove(this.WordColors.FirstOrDefault(wc => wc.Id == id));
            this.SaveChanges();
        }
    }
}
