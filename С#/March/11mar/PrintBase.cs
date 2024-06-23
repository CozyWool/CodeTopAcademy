namespace _11mar
{
    public abstract class PrintBase
    {
        public abstract void Print(string message);

        public virtual string GetPrinterType() { return "Console"; }
    }
}
