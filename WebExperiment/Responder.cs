using System.Threading.Tasks;

namespace WebExperiment
{
    public delegate Task Responder<in TResponse>(TResponse response);
}