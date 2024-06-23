namespace _31aug.FirstTask
{
    public delegate void PropertyEventHandler(object sender, PropertyEventArgs e);
    public class PropertyEventArgs
    {
        public string PropertyName { get; set; }
        public PropertyEventArgs(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}
