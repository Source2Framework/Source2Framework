namespace Source2Framework.Extensions
{
    public static partial class UIntEx
    {
        public static float ViewAsFloat(this uint value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            return BitConverter.ToSingle(bytes, 0);
        }
    }
}
