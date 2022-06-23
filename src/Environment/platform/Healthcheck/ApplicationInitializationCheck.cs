﻿using Microsoft.Extensions.Diagnostics.HealthChecks;
using Sitecore.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Mvp.Environment.Sitecore.Healthcheck
{
    public class ApplicationInitializationCheck : IHealthCheck
    {
        public ApplicationInitializationCheck() { }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var machineName = "CM"; /*Environment.GetEnvironmentVariable("Sitecore_InstanceName") ?? Environment.MachineName;*/

            if ((string)HttpContext.Current.Cache.Get("APPINIT") == "1")
            {
                return HealthCheckResult.Unhealthy($"Warmup is in progress for {machineName}");
            }
            
            if (HttpContext.Current != null && (HttpContext.Current.Cache["APPINIT"] != null || !string.IsNullOrEmpty(HttpContext.Current.Cache["APPINIT"].ToString())))
            {
                 return HealthCheckResult.Unhealthy($"Warmup is in progress for {machineName} (null check)");
            }


            return HealthCheckResult.Healthy($"Warmup is complete for {machineName}");
            }
    }
}