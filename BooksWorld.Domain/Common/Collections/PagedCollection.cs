namespace BooksWorld.Domain.Common.Collections;

public class PagedCollection<T>
{
    private const int _Max_Pages_Count = 50;
    private int _pageSize;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value < _Max_Pages_Count ? value : _Max_Pages_Count;
    }

    public int  CurrentPage { get; private set; }
    public int  PagesCount  { get; private set; }
    public bool HasNext => CurrentPage < PagesCount;
    public bool HasPrevious => CurrentPage > 1;

    public IEnumerable<T> Collection { get; }

    // changed from 'public' to 'private'
    private PagedCollection(IEnumerable<T> collection, int pagesCount, int pageNumber, int pageSize)
    {
        CurrentPage = pageNumber;
        PageSize = pageSize;
        PagesCount = pagesCount;
        Collection = collection;
    }

    public static PagedCollection<T> ToPagedCollection(IEnumerable<T> items, int pageNumber, int pageSize)
    {
        var pagesCount = (int)Math.Ceiling(items.Count() / (double)pageSize);
        var pagedCollection = items.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        return new PagedCollection<T>(pagedCollection, pagesCount, pageNumber, pageSize);
    }
}