using Elsa.Attributes;
using Elsa.Services;

namespace ElsaServer.Data
{
    [Trigger(
       Category = "Elsa Guides",
       Description = "Triggers when a msg is received"
   )]
    public class MgsReceived: Activity
    {
    }
}
