namespace LtCodes.Helpers
{
    public static class Helper
    {
        public static int GetControlNumber(int[] numbers, int firstMultiplier = 1)
        {
            return numbers
                .Select((item, index) => item * (((index + firstMultiplier - 1) % 9) + 1))
                .Sum() % 11;
        }

    }
}