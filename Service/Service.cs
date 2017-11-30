using System;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using Service.Controllers;
using WebExperiment;

namespace Service
{
    public class Service: ServiceBase
    {
        private Task _serv;
        private readonly CancellationTokenSource _cts;
        
        public Service()
        {
            ServiceName = "Service name";
            EventLog.Log = "Application";
            
            // These Flags set whether or not to handle that specific
            // type of event. Set to true if you need it, false otherwise.
            CanHandlePowerEvent = true;
            CanHandleSessionChangeEvent = true;
            CanPauseAndContinue = true;
            CanShutdown = true;
            CanStop = true;
            
            _cts = new CancellationTokenSource();
        }

        static void Main()
        {
            Run(new Service());
        }
        
        private static Response GetStaticPage() { throw new NotImplementedException(); }
        private static async Task<Response> GetStaticPageAsync() { throw new NotImplementedException(); }
        private static async Task<Response> GetStaticPageAsync(CancellationToken ct) { throw new NotImplementedException(); }
        
        private static Response GetNewsById(int newsId) { throw new NotImplementedException(); }
        private static async Task<Response> GetNewsByIdAsync(int newsId) { throw new NotImplementedException(); }
        private static async Task<Response> GetNewsByIdAsync(int newsId, CancellationToken ct) { throw new NotImplementedException(); }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            
            var ioc = new IoC();
            new Server(ResourceCollector.Root(ioc.Resolve<HomeController>,
                    get: h => h.WithDefault().By(a => a.Index),
                    nested: root => root
                        .Named("about",
                            get: h => h.WithDefault().By(a => a.Index))
                        .Named("news", ioc.Resolve<NewsController>,
                            get: h => h
                                .WithNothing().By(GetStaticPage)
                                .WithNothing().ByAsync(GetStaticPageAsync)
                                .WithNothing().ByAsyncCanc(GetStaticPageAsync)
                                .WithDefault().By<int?, bool?>(a => a.Index)
                                .WithDefault().ByAsync<int?, bool?>(a => a.IndexAsync)
                                .WithDefault().ByAsyncCanc<int?, bool?>(a => a.IndexAsync)
                                .With(ioc.Resolve<ArticleController>).By<int?>(a => a.Index)
                                .With(ioc.Resolve<ArticleController>).ByAsync<int?>(a => a.IndexAsync)
                                .With(ioc.Resolve<ArticleController>).ByAsyncCanc<int?>(a => a.IndexAsync),
                            post: h => h.WithDefault().By<string, string>(a => a.Add),
                            nested: news => news
                                .Valued<int>(
                                    get: h => h
                                        .WithNothing().By(GetNewsById)
                                        .WithNothing().ByAsync(GetNewsByIdAsync)
                                        .WithNothing().ByAsyncCanc(GetNewsByIdAsync)
                                        .WithDefault().By(a => a.Get),
                                    put: h => h.WithDefault().By<string, string>(a => a.Change),
                                    delete: h => h.WithDefault().By(a => a.Delete)))
                        .Named("articles", ioc.Resolve<ArticleController>,
                            get: h => h.WithDefault().By<int?>(a => a.Index),
                            post: h => h.WithDefault().By<string, string>(a => a.Add),
                            nested: article => article
                                .Valued<int>(
                                    get: h => h.WithDefault().By(a => a.Get),
                                    put: h => h.WithDefault().By<string, string>(a => a.Change),
                                    delete: h => h.WithDefault().By(a => a.Delete)))
                ).Build()
            ).Run(_cts.Token).Wait();
        }

        protected override void OnStop()
        {
            base.OnStop();
            _cts.Cancel();
//            try
//            {
                _serv.Wait();
//            }
//            catch (Exception e)
//            {
//                // handle exception
//            }
        }
        
        protected override void Dispose(bool disposing) { base.Dispose(disposing); }
        protected override void OnPause() { base.OnPause(); }
        protected override void OnContinue() { base.OnContinue(); }
        protected override void OnShutdown() { base.OnShutdown(); }
        protected override void OnCustomCommand(int command) { base.OnCustomCommand(command); }
        protected override bool OnPowerEvent(PowerBroadcastStatus powerStatus) { return base.OnPowerEvent(powerStatus); }
        protected override void OnSessionChange( SessionChangeDescription changeDescription) { base.OnSessionChange(changeDescription); }
    }
}