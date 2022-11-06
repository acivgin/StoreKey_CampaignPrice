namespace StoreKey_CampaignPrice.Business
{
    public class Product
    {
        public int EAN { get; set; }
        public string Name { get; set; }
        public decimal CampaignPrice { get; set; }
        public decimal OriginalPrice { get; set; }
        public CampaingTypeEnum CampaingType { get; set; }
    }
}
