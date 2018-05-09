using System.Linq;

namespace brainence_test_project.Models.Data
{
    public static class RevertHelper
    {
        public static string Revert(string reverted)
        {
           return new string(reverted.Select(x => x).Reverse().ToArray());
        }
    }
}