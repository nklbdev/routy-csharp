using System.Net;
using System.Threading.Tasks;

namespace WebExperiment
{
    public delegate Task Responder(HttpListenerResponse response);
}