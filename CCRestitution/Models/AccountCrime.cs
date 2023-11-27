using System.ComponentModel.DataAnnotations.Schema;

namespace CCRestitution.Models
{
    public class AccountCrime
    {
        public int AccountCrimeId { get; set; }
        public int AccountId { get; set; }
        [ForeignKey(nameof(Crime))]
        public int Id { get; set; }
        public Crime Crime { get; set; }
    }
}
