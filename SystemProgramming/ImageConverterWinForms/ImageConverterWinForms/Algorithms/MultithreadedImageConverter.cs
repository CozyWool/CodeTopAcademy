namespace ImageConverterWinForms.Algorithms;

public class MultithreadedImageConverter : BaseImageConverter, IImageConverter
{
    public Bitmap ConvertToGray(Bitmap bitmap)
    {
        var portions = new List<Portion>();
        var output = new Bitmap(bitmap.Width, bitmap.Height);
        var chunks = GetChunks(Environment.ProcessorCount, bitmap.Width);
        foreach (var (start, end) in chunks)
        {
            var rect = new Rectangle(start, 0, end - start, bitmap.Height);
            var portion = new Portion
            {
                Bitmap = bitmap.Clone(rect, bitmap.PixelFormat),
                Start = start
            };
            portions.Add(portion);
        }

        var tasks = new Task[Environment.ProcessorCount];
        for (var i = 0; i < tasks.Length; i++)
        {
            var b = portions[i].Bitmap;
            tasks[i] = new Task(() =>
            {
                for (var row = 0; row < b.Width; row++)
                {
                    for (var col = 0; col < b.Height; col++)
                    {
                        TransformPixel(b, row, col);
                    }
                }
            });
        }

        foreach (var task in tasks)
        {
            task.Start();
        }

        Task.WaitAll(tasks);
        using var g = Graphics.FromImage(output);
        foreach (var portion in portions)
        {
            g.DrawImage(portion.Bitmap, portion.Start, 0);
        }

        return output;
    }

    private static (int Start, int End)[] GetChunks(int processorCount, int width)
    {
        var size = (int)Math.Round((double)width / processorCount);
        var chunks = new List<(int Start, int End)>();
        for (var i = 0; i < width; i += size)
        {
            var end = i + size <= width ? i + size : width;
            chunks.Add((i, end));
        }

        return chunks.ToArray();
    }

    private class Portion
    {
        public Bitmap Bitmap { get; init; }

        public int Start { get; init; }
    }
}