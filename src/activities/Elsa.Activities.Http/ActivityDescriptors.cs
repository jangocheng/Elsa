using System.Collections.Generic;
using Elsa.Activities.Http.Activities;
using Elsa.Models;
using Microsoft.Extensions.Localization;

namespace Elsa.Activities.Http
{
    public class ActivityDescriptors : ActivityDescriptorProviderBase
    {
        public ActivityDescriptors(IStringLocalizer<ActivityDescriptors> localizer)
        {
            T = localizer;
        }

        private IStringLocalizer<ActivityDescriptors> T { get; }
        private LocalizedString Category => T["HTTP"];

        protected override IEnumerable<ActivityDescriptor> Describe()
        {
            yield return ActivityDescriptor.ForTrigger<HttpRequestTrigger>(
                Category,
                T["HTTP Request Trigger"],
                T["Triggers when an incoming HTTP request is received."],
                T["Done"]);
            
            yield return ActivityDescriptor.ForAction<HttpRequestAction>(
                Category,
                T["HTTP Request"],
                T["Execute a HTTP request."],
                T["Done"]);
        }
    }
}