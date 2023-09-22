namespace Consimple_Test_Task.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public List<Purchase>? Purchases { get; set; }
    }
}
