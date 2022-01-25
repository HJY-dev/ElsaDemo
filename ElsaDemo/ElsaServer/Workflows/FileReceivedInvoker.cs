using Elsa.Services;
using Elsa.Services.Models;
using ElsaServer.Bookmarks;
using ElsaServer.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ElsaServer.Workflows
{
    public class FileReceivedInvoker : IFileReceivedInvoker
    {
        private readonly IWorkflowLaunchpad _workflowLaunchpad;

        public FileReceivedInvoker(IWorkflowLaunchpad workflowLaunchpad)
        {
            _workflowLaunchpad = workflowLaunchpad;
        }

        public async Task<IEnumerable<CollectedWorkflow>> DispatchWorkflowsAsync(CancellationToken cancellationToken = default)
        {
            var context = new WorkflowsQuery(nameof(FileReceived), new FileReceivedBookmark());
            return await _workflowLaunchpad.CollectAndDispatchWorkflowsAsync(context, null, cancellationToken);
        }

        public async Task<IEnumerable<CollectedWorkflow>> ExecuteWorkflowsAsync(CancellationToken cancellationToken = default)
        {
            var context = new WorkflowsQuery(nameof(FileReceived), new FileReceivedBookmark());
            return await _workflowLaunchpad.CollectAndExecuteWorkflowsAsync(context, null, cancellationToken);
        }

        public async Task<IEnumerable<CollectedWorkflow>> DispatchWorkflowsAsync(FileModel file, CancellationToken cancellationToken = default)
        {
            var context = new WorkflowsQuery(nameof(FileReceived), new FileReceivedBookmark());
            return await _workflowLaunchpad.CollectAndDispatchWorkflowsAsync(context, file, cancellationToken);
        }

        public async Task<IEnumerable<CollectedWorkflow>> ExecuteWorkflowsAsync(FileModel file, CancellationToken cancellationToken = default)
        {
            var context = new WorkflowsQuery(nameof(FileReceived), new FileReceivedBookmark());
            return await _workflowLaunchpad.CollectAndExecuteWorkflowsAsync(context, file, cancellationToken);
        }
    }
}
