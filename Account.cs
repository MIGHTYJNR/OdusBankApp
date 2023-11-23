namespace OdusBankApp
{
    public class Account : BaseClass
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public int BVN { get; set; }
    }
}