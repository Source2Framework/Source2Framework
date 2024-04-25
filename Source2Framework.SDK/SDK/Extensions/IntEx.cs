namespace Source2Framework.Extensions
{
    public static partial class IntEx
    {
        public static float ViewAsFloat(this int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            return BitConverter.ToSingle(bytes, 0);
        }
    }
}
