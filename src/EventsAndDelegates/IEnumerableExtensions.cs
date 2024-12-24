namespace EventsAndDelegates;

public static class IEnumerableExtensions
{
    public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
    {
        if (collection is null || !collection.Any())
            throw new ArgumentException("Collection must be not empty");

        return collection.OrderByDescending(convertToNumber).FirstOrDefault()!;
    }
}
