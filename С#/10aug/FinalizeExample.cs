public class FinalizeExample : IDisposable
{
    bool isDisposed = false;
    ~FinalizeExample()
    {
        //Console.WriteLine("~FinalizeExample. Освобождение неуправляемых ресурсов");
        Dispose(false);
    }

    public void Dispose()
    {
        //Console.WriteLine("Dispose. Освобождение неуправляемых ресурсов");
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void ExplicitThrow()
    {
        throw new NotImplementedException();
    }

    private void Dispose(bool disposing)
    {
        if(!isDisposed)
        {
            if (disposing)
            {
                Console.WriteLine("Освобождение управляемых ресурсов");
            }
            Console.WriteLine("Освобождение неуправляемых ресурсов");
        }

        isDisposed = true;
    }
}