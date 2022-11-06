using StoreKey_CampaignPrice.Business;

namespace StoreKey_CampaignPrice.Test
{
    [TestClass]
    public class CampaignPriceTests
    {
        CheckoutManager checkout = new CheckoutManager();

        #region Combo Campaign List
             [TestMethod]
        public void returnOriginalPriceIfOnlyOneProductInList()
        {
            var campaignPrice = checkout.getCampaignPrice(CampaingTypeEnum.Combination, 1);
            Assert.AreEqual(45, campaignPrice);
        }


        [TestMethod]
        public void returnCampaignPriceForTwoProducts()
        {
            var campaignPrice = checkout.getCampaignPrice(CampaingTypeEnum.Combination, 2);
            Assert.AreEqual(30, campaignPrice);
        }

        [TestMethod]
        public void returnCampaignPriceForThreeProducts()
        {
            var campaignPrice = checkout.getCampaignPrice(CampaingTypeEnum.Combination, 3);
            Assert.AreEqual(75, campaignPrice);
        }

        [TestMethod]
        public void returnCampaignPriceForFourProducts()
        {
            var campaignPrice = checkout.getCampaignPrice(CampaingTypeEnum.Combination, 4);
            Assert.AreEqual(60, campaignPrice);
        }


        [TestMethod]
        public void returnCampaignPriceForFiveProducts()
        {
            var campaignPrice = checkout.getCampaignPrice(CampaingTypeEnum.Combination, 5);
            Assert.AreEqual(105, campaignPrice);
        }

        #endregion


        #region Volume Campaign Price

        [TestMethod]
        public void getCampaignPriceForTwoProducts_Coffee()
        {
            var campaignPrice = checkout.getCampaignPrice(CampaingTypeEnum.Volume, 2, "Coffee");

            Assert.AreEqual(20m, campaignPrice);
        }

        [TestMethod]
        public void getCampaignPriceForTwoProducts_CocaCola()
        {
            var campaignPrice = checkout.getCampaignPrice(CampaingTypeEnum.Volume, 3, "Coca Cola");

            Assert.AreEqual(46.95m, campaignPrice);
        }

        [TestMethod]
        public void getCampaignPriceForTwoProducts_Cheese()
        {
            var campaignPrice = checkout.getCampaignPrice(CampaingTypeEnum.Volume, 2, "Cheese");
            Assert.AreEqual(9.95m, campaignPrice);
        }

        #endregion

    }



}