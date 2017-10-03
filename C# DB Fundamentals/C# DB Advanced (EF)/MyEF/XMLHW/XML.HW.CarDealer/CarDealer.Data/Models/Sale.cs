namespace CarDealer.Data.Models
{
    public partial class Sale
    {
        public int Id { get; set; }

        public double Discount { get; set; }

        public int Car_Id { get; set; }

        public int Customer_Id { get; set; }

        public virtual Car Car { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
