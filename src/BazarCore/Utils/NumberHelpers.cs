namespace BazarCore.Utils
{
    public static class NumberHelpers
    {
        public static string FormatNumberToMoney(this float money) =>
      money.ToString("N2").Replace(",",".") + " KZ";
    }
}
