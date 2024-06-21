public class Good
{
    public Good(string title)
    {
        if (title == string.Empty)
            throw new ArgumentOutOfRangeException(nameof(title));

        Title = title;
    }

    public string Title { get; }
}