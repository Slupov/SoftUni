namespace _05.Border_Control
{
   public interface IBuyer
   {
        string Name { get; }

        string Age { get; }

        int Food { get; set; }

        int BuyFood();
   }
}
