using LibraryWebApplication.Enums;

namespace LibraryWebApplication.Models;

public class SortViewModel
{
    public SortState IdSort { get; set; }
    public SortState NameSort { get; set; }
    public SortState AuthorSort { get; set; }
    public SortState PublisherSort { get; set; }
    public SortState Current { get; set; }
    public bool Up { get; set; }

    public SortViewModel(SortState sortOrder)
    {
        NameSort = SortState.NameAsc;
        AuthorSort = SortState.AuthorAsc;
        PublisherSort = SortState.PublisherAsc;
        IdSort = SortState.IdAsc;

        Up = sortOrder is SortState.AuthorAsc or SortState.NameAsc or SortState.PublisherAsc or SortState.IdAsc;

        Current = sortOrder switch
        {
            SortState.IdDesc => IdSort = SortState.IdAsc,
            SortState.IdAsc => IdSort = SortState.IdDesc,
            SortState.NameAsc => NameSort = SortState.NameDesc,
            SortState.NameDesc => NameSort = SortState.NameAsc,
            SortState.AuthorAsc => AuthorSort = SortState.AuthorDesc,
            SortState.AuthorDesc => AuthorSort = SortState.AuthorAsc,
            SortState.PublisherAsc => PublisherSort = SortState.PublisherDesc,
            SortState.PublisherDesc => PublisherSort = SortState.PublisherAsc,
            _ => throw new ArgumentOutOfRangeException(nameof(sortOrder), sortOrder, null)
        };
        
    }
}