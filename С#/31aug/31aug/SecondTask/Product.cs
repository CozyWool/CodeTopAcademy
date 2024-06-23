namespace _31aug.SecondTask
{
    public record Product(string Name, int Price)
    {
        public override string? ToString()
        {
            return $"{Name}({Price} р.)";
        }
    }
}
