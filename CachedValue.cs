namespace Lesson4
{
    public record CachedValue<T>
    {
        public T? Value;
        public DateTime CreationTime;
        public int Timeout;
    }
}
