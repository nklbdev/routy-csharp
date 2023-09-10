using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Views;

public delegate Task View(HttpListenerResponse response, CancellationToken cancellationToken);
