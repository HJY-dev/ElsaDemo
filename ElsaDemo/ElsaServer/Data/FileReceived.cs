using Elsa.ActivityResults;
using Elsa.Attributes;
using Elsa.Services;
using Elsa.Services.Models;

namespace ElsaServer.Data
{
    [Trigger(
       Category = "Elsa Guides",
       Description = "Triggers when a file is received"
   )]
    public class FileReceived: Activity
    {
        protected override IActivityExecutionResult OnExecute()
        {
            return Suspend();
        }

        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
            return context.WorkflowExecutionContext.IsFirstPass ? Done() : Suspend();
        }


        protected override IActivityExecutionResult OnResume()
        {
            return Done();
        }

    }
}
