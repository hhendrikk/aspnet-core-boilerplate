namespace Infrastructure.Extensions;

public static class EnumerableExtensions
{
    public static void ForEach<T>(this IEnumerable<T> values, Action<T> action)
    {
        foreach (var value in values)
        {
            action(value);
        }
    }

    public static async Task ForEach<T>(this IEnumerable<T> values, Func<T, Task> action)
    {
        foreach (var value in values)
        {
            await action(value);
        }
    }
}