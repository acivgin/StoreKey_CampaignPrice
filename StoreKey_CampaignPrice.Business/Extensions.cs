namespace StoreKey_CampaignPrice.Business
{
    public static class Extensions
    {
        public static List<T> GetClone<T>(this List<T> source)
        {
            return source.GetRange(0, source.Count);
        }
    }
}
