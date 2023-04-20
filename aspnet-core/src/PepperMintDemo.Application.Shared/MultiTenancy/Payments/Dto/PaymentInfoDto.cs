using PepperMintDemo.Editions.Dto;

namespace PepperMintDemo.MultiTenancy.Payments.Dto
{
    public class PaymentInfoDto
    {
        public EditionSelectDto Edition { get; set; }

        public decimal AdditionalPrice { get; set; }

        public bool IsLessThanMinimumUpgradePaymentAmount()
        {
            return AdditionalPrice < PepperMintDemoConsts.MinimumUpgradePaymentAmount;
        }
    }
}
