using Elsa.Services.Models;
using ElsaServer.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ElsaServer.Workflows
{
    public interface IFileReceivedInvoker
    {
        Task<IEnumerable<CollectedWorkflow>> DispatchWorkflowsAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<CollectedWorkflow>> ExecuteWorkflowsAsync(CancellationToken cancellationToken = default);

        Task<IEnumerable<CollectedWorkflow>> DispatchWorkflowsAsync(FileModel file, CancellationToken cancellationToken = default);
        Task<IEnumerable<CollectedWorkflow>> ExecuteWorkflowsAsync(FileModel file, CancellationToken cancellationToken = default);
    }
}
