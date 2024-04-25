namespace Source2Framework.Models
{
    public class WinLinux<T>
    {
        [JsonPropertyName("Windows")]
        public T Windows { get; private set; }

        [JsonPropertyName("Linux")]
        public T Linux { get; private set; }

        public WinLinux(T windows, T linux)
        {
            this.Windows = windows;
            this.Linux = linux;
        }

        public T Get()
        {
            return Constants.IsWindows ? Windows : Linux;
        }
    }
}
