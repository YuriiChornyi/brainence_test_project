using Microsoft.EntityFrameworkCore.Internal;

namespace brainence_test_project.Models.Data
{
    public static class DbInit
    {
        public static void Initialize(SentenceContext context)
        {
            context.Database.EnsureCreated();

            if (context.Sentences.Any())
            {
                return;
            }

            var sentences = new Sentence[]
            {
                new Sentence
                {
                    SentenceInRevert = @".калруб хісв до йишітязваЗ,
                    йинроворп елз єесв ан ьсвадУ,
                    казок идук ьтох ьцеполх І йинротом кобурап вуб йенЕ",
                    Word = "козак",
                    Count = 1
                },
                new Sentence
                {
                    SentenceInRevert = @".вавикан їорТ з иматя'П
                    ,віцнал ,яриг кя ,хинеламсО
                    ,віцняорт хикяед ишварбаЗ
                    ;вад угят ,уброт ишвязв ,ніВ
                    ,юонг утрикс їен з илиборЗ
                    ,юорТ ишвилапс кя ,икерг оН",
                    Word = "накивав",
                    Count = 1
                }
            };
            foreach (var s in sentences)
            {
                context.Sentences.Add(s);
            }

            context.SaveChanges();
        }
    }
}