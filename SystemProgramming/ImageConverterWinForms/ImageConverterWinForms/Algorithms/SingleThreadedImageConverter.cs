namespace ImageConverterWinForms.Algorithms;

public class SingleThreadedImageConverter : BaseImageConverter, IImageConverter
{
    public Bitmap ConvertToGray(Bitmap bitmap)
    {
        var output = (Bitmap)bitmap.Clone();
        for (var i = 0; i < bitmap.Width; i++)
        {
            for (var j = 0; j < bitmap.Height; j++)
            {
                TransformPixel(output, i, j);
            }
        }

        return output;
    }
}