using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PepperMintDemo.MultiTenancy.HostDashboard.Dto;

namespace PepperMintDemo.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}