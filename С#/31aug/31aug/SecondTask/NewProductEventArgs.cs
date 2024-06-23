namespace _31aug.SecondTask
{
    public delegate void NewProductEventHandler(object sender, NewProductEventArgs e);
    public class NewProductEventArgs
    {
        public Product Product { get; set; }
        public NewProductEventArgs(Product product)
        {
            Product = product;
        }
    }
}
