using System.ComponentModel.DataAnnotations.Schema;

namespace Consimple_Test_Task.Models
{
    public class Purchase
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int TotalPrice { get; set; }
        public Client Client { get; set; }

        public Purchase()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
