using System.Collections.Generic;
using System.Linq;
using Abp.Authorization;
using Abp.MultiTenancy;
using PepperMintDemo.Authorization;

namespace PepperMintDemo.DashboardCustomization.Definitions
{
    public class DashboardConfiguration
    {
        public List<DashboardDefinition> DashboardDefinitions { get; } = new List<DashboardDefinition>();

        public List<WidgetDefinition> WidgetDefinitions { get; } = new List<WidgetDefinition>();

        public List<WidgetFilterDefinition> WidgetFilterDefinitions { get; } = new List<WidgetFilterDefinition>();

        public DashboardConfiguration()
        {
            #region FilterDefinitions

            // These are global filter which all widgets can use
            var dateRangeFilter = new WidgetFilterDefinition(
                PepperMintDemoDashboardCustomizationConsts.Filters.FilterDateRangePicker,
                "FilterDateRangePicker"
            );

            WidgetFilterDefinitions.Add(dateRangeFilter);

            // Add your filters here

            #endregion

            #region WidgetDefinitions

            // Define Widgets

            #region TenantWidgets

            var simplePermissionDependencyForTenantDashboard = new SimplePermissionDependency(AppPermissions.Pages_Tenant_Dashboard);

            var dailySales = new WidgetDefinition(
                PepperMintDemoDashboardCustomizationConsts.Widgets.Tenant.DailySales,
                "WidgetDailySales",
                side: MultiTenancySides.Tenant,
                usedWidgetFilters: new List<string> { dateRangeFilter.Id },
                permissionDependency: simplePermissionDependencyForTenantDashboard
            );

            var generalStats = new WidgetDefinition(
                PepperMintDemoDashboardCustomizationConsts.Widgets.Tenant.GeneralStats,
                "WidgetGeneralStats",
                side: MultiTenancySides.Tenant,
                permissionDependency: new SimplePermissionDependency(
                    requiresAll: true,
                    AppPermissions.Pages_Tenant_Dashboard,
                    AppPermissions.Pages_Administration_AuditLogs
                )
            );

            var profitShare = new WidgetDefinition(
                PepperMintDemoDashboardCustomizationConsts.Widgets.Tenant.ProfitShare,
                "WidgetProfitShare",
                side: MultiTenancySides.Tenant,
                permissionDependency: simplePermissionDependencyForTenantDashboard
            );

            var memberActivity = new WidgetDefinition(
                PepperMintDemoDashboardCustomizationConsts.Widgets.Tenant.MemberActivity,
                "WidgetMemberActivity",
                side: MultiTenancySides.Tenant,
                permissionDependency: simplePermissionDependencyForTenantDashboard
            );
            
            var regionalStats = new WidgetDefinition(
                PepperMintDemoDashboardCustomizationConsts.Widgets.Tenant.RegionalStats,
                "WidgetRegionalStats",
                side: MultiTenancySides.Tenant,
                permissionDependency: simplePermissionDependencyForTenantDashboard
            );

            var salesSummary = new WidgetDefinition(
                PepperMintDemoDashboardCustomizationConsts.Widgets.Tenant.SalesSummary,
                "WidgetSalesSummary",
                usedWidgetFilters: new List<string>() { dateRangeFilter.Id },
                side: MultiTenancySides.Tenant,
                permissionDependency: simplePermissionDependencyForTenantDashboard
            );
            
            var topStats = new WidgetDefinition(
                PepperMintDemoDashboardCustomizationConsts.Widgets.Tenant.TopStats,
                "WidgetTopStats",
                side: MultiTenancySides.Tenant,
                permissionDependency: simplePermissionDependencyForTenantDashboard
            );

            WidgetDefinitions.Add(generalStats);
            WidgetDefinitions.Add(dailySales);
            WidgetDefinitions.Add(profitShare);
            WidgetDefinitions.Add(memberActivity);
            WidgetDefinitions.Add(regionalStats);
            WidgetDefinitions.Add(topStats);
            WidgetDefinitions.Add(salesSummary);
            // Add your tenant side widgets here

            #endregion

            #region HostWidgets

            var simplePermissionDependencyForHostDashboard = new SimplePermissionDependency(AppPermissions.Pages_Administration_Host_Dashboard);

            var incomeStatistics = new WidgetDefinition(
                PepperMintDemoDashboardCustomizationConsts.Widgets.Host.IncomeStatistics,
                "WidgetIncomeStatistics",
                side: MultiTenancySides.Host,
                permissionDependency: simplePermissionDependencyForHostDashboard
            );

            var hostTopStats = new WidgetDefinition(
                PepperMintDemoDashboardCustomizationConsts.Widgets.Host.TopStats,
                "WidgetTopStats",
                side: MultiTenancySides.Host,
                permissionDependency: simplePermissionDependencyForHostDashboard
            );

            var editionStatistics = new WidgetDefinition(
                PepperMintDemoDashboardCustomizationConsts.Widgets.Host.EditionStatistics,
                "WidgetEditionStatistics",
                side: MultiTenancySides.Host,
                permissionDependency: simplePermissionDependencyForHostDashboard
            );

            var subscriptionExpiringTenants = new WidgetDefinition(
                PepperMintDemoDashboardCustomizationConsts.Widgets.Host.SubscriptionExpiringTenants,
                "WidgetSubscriptionExpiringTenants",
                side: MultiTenancySides.Host,
                permissionDependency: simplePermissionDependencyForHostDashboard
            );

            var recentTenants = new WidgetDefinition(
                PepperMintDemoDashboardCustomizationConsts.Widgets.Host.RecentTenants,
                "WidgetRecentTenants",
                side: MultiTenancySides.Host,
                usedWidgetFilters: new List<string>() { dateRangeFilter.Id },
                permissionDependency: simplePermissionDependencyForHostDashboard
            );

            WidgetDefinitions.Add(incomeStatistics);
            WidgetDefinitions.Add(hostTopStats);
            WidgetDefinitions.Add(editionStatistics);
            WidgetDefinitions.Add(subscriptionExpiringTenants);
            WidgetDefinitions.Add(recentTenants);

            // Add your host side widgets here

            #endregion

            #endregion

            #region DashboardDefinitions

            // Create dashboard
            var defaultTenantDashboard = new DashboardDefinition(
                PepperMintDemoDashboardCustomizationConsts.DashboardNames.DefaultTenantDashboard,
                new List<string>
                {
                    generalStats.Id, dailySales.Id, profitShare.Id, memberActivity.Id, regionalStats.Id, topStats.Id, salesSummary.Id
                });

            DashboardDefinitions.Add(defaultTenantDashboard);

            var defaultHostDashboard = new DashboardDefinition(
                PepperMintDemoDashboardCustomizationConsts.DashboardNames.DefaultHostDashboard,
                new List<string>
                {
                    incomeStatistics.Id,
                    hostTopStats.Id,
                    editionStatistics.Id,
                    subscriptionExpiringTenants.Id,
                    recentTenants.Id
                });

            DashboardDefinitions.Add(defaultHostDashboard);

            // Add your dashboard definition here

            #endregion

        }

    }
}
