using System.Collections.Generic;
using Elsa.Services;
using ElsaServer.Data;

namespace ElsaServer.Bookmarks
{
    public class FileReceivedBookmarkProvider : BookmarkProvider<FileReceivedBookmark, FileReceived>
    {
        public override IEnumerable<BookmarkResult> GetBookmarks(BookmarkProviderContext<FileReceived> context)
        {
            return new[] { Result(new FileReceivedBookmark()) };
        }
    }
}
