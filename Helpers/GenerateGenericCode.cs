namespace EasyTask.Helpers
{
    public static class GenerateGenericCode
    {
        public static string Generate(string Suffix)
        {
            var random = new Random();
            int number = random.Next(0, 999999);
            return $"{Suffix}{number:D6}";
        }
    }
}
