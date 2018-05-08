using Microsoft.EntityFrameworkCore;

namespace brainence_test_project.Models.Data
{
    public class SentenceContext:DbContext
    {
        public SentenceContext(DbContextOptions<SentenceContext> options) : base(options)
        {
        }

        public DbSet<Sentence> Sentences { get; set; }
    }
}