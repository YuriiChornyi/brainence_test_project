using System.ComponentModel.DataAnnotations;

namespace brainence_test_project.Models
{
    public class Sentence
    {
        [Key]
        public int Id { get; set; }
        public string SentenceInRevert { get; set; }
        public string Word { get; set; }
        public int Count { get; set; }
    }
}