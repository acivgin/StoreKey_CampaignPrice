namespace StoreKey_CampaignPrice.Business
{
    public class CheckoutManager
    {
        public List<Product> generateProductListCombineCampaign(int itemsLength)
        {
            List<Product> productsCombinationList = new();
            var random = new Random();
            for (int i = 1; i <= itemsLength; i++)
            {
                var product = new Product
                {
                    EAN = random.Next(100000000, 999999999),
                    CampaignPrice = 30m,
                    OriginalPrice = 45m,
                    CampaingType = CampaingTypeEnum.Combination
                };
                productsCombinationList.Add(product);
            }
            return productsCombinationList;
        }

        public List<Product> generateProductListVolumeCampaign()
        {
            return new List<Product>
            {
                new Product
                {
                    EAN = 111000111,
                    Name = "Coca Cola",
                    CampaignPrice = 30m,
                    OriginalPrice = 16.95m,
                },
                new Product
                {
                    EAN = 111000111,
                    Name = "Coca Cola",
                    CampaignPrice = 30m,
                    OriginalPrice = 16.95m,
                },
                new Product
                {
                    EAN = 111000111,
                    Name = "Coca Cola",
                    CampaignPrice = 30m,
                    OriginalPrice = 16.95m,
                },
                new Product
                {
                    EAN = 333000333,
                    Name = "Cheese",
                    CampaignPrice = 15m,
                    OriginalPrice = 9.95m,
                },
                new Product
                {
                    EAN = 222000222,
                    Name = "Coffee",
                    CampaignPrice = 20m,
                    OriginalPrice = 12.95m,
                },
                new Product
                {
                    EAN = 222000222,
                    Name = "Coffee",
                    CampaignPrice = 20m,
                    OriginalPrice = 12.95m,
                }
            };
        }


        public decimal getCampaignPrice(CampaingTypeEnum campaingType, int lentghOfItems = 2, string productName = "")
        {
            var products = campaingType == CampaingTypeEnum.Combination ?
                generateProductListCombineCampaign(lentghOfItems) :
                generateProductListVolumeCampaign().Where(p => p.Name == productName).ToList();

            if (products == null || !products.Any()) return 0;

            if (products.Count == 1)
                return products[0].OriginalPrice; //???


            List<Product> originalList = products.GetClone();

            if (products.Count() % 2 == 0)
            {
                return products.Sum(p => p.CampaignPrice) / 2;
            }
            else
            {
                products.RemoveAt(products.Count() - 1);
                return products.Sum(p => p.CampaignPrice) / 2 + originalList.Last().OriginalPrice;
            }

        }
        //public decimal calculateVolumeCampaignPrice(string productName = "")
        //{
        //    var products = generateProductListVolumeCampaign();

        //    if (!products.Any()) return 0;


        //    var anonymousList = products
        //          .GroupBy(p => p.EAN)
        //          .Select(g => new
        //          {
        //              id = g.Key,
        //              productInCampaign = g.Count() % 2 == 0
        //          });
        //    var resultList = (from product in products
        //                      from item in anonymousList.Where(i => i.productInCampaign)
        //                      where product.EAN == item.id && product.Name == productName
        //                      select product)?.DistinctBy(i => i.EAN)?.ToList();

        //    if (resultList == null || !resultList.Any()) return 0;

        //    return resultList.FirstOrDefault(p => p.Name == productName).CampaignPrice;

        //}
    }
}