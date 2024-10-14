using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Filters.Filter;

public class PerformansResourceFilter : Attribute, IResourceFilter
{
    private Stopwatch _stopwatch;
    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        _stopwatch = Stopwatch.StartNew();
    }

    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        var elapsedMiliseconds = _stopwatch.ElapsedMilliseconds;
        var descriptor = context?.ActionDescriptor as ControllerActionDescriptor;
        if (descriptor != null)
        {
            var actionName = descriptor.ActionName;
            var ctrlName = descriptor.ControllerName;

            Console.WriteLine($"Request çalışma süresi({ctrlName} - {actionName} - {elapsedMiliseconds})");

        }
    }
}
