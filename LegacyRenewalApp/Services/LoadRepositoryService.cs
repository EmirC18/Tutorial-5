using System;

namespace LegacyRenewalApp.Services;

public class LoadRepositoryService
{
    public (Customer customer,SubscriptionPlan plan) SendRepository(string normalizedPlanCode,int customerId)
    {
        var customerRepository = new CustomerRepository();
        var planRepository = new SubscriptionPlanRepository();

        var customer = customerRepository.GetById(customerId);
        var plan = planRepository.GetByCode(normalizedPlanCode);

        if (!customer.IsActive)
        {
            throw new InvalidOperationException("Inactive customers cannot renew subscriptions");
        }
        return (customer, plan);
    }
}