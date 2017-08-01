namespace _3.Wild_Farm.Food
{
    abstract class Food
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        protected int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }
}