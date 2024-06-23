namespace ImageConverterWinForms.Algorithms;

public abstract class BaseImageConverter
{
    protected static void TransformPixel(Bitmap bitmap, int row, int column)
    {
        var pixel = bitmap.GetPixel(row, column);
        var avgValue = (byte)((pixel.R + pixel.G + pixel.B) / 3.0f);
        var color = Color.FromArgb(avgValue, avgValue, avgValue);
        bitmap.SetPixel(row, column, color);
    }
}