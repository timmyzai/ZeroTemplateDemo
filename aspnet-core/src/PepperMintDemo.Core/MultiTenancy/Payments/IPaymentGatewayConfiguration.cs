﻿using Abp.Dependency;

namespace PepperMintDemo.MultiTenancy.Payments
{
    public interface IPaymentGatewayConfiguration: ITransientDependency
    {
        bool IsActive { get; }

        bool SupportsRecurringPayments { get; }

        SubscriptionPaymentGatewayType GatewayType { get; }
    }
}
