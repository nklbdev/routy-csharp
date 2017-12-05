using System;
using System.Net;
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
        
        protected override void OnStart(string[] args)
        {
            base.OnStart(args);

            var ioc = new IoC();

            new Server(ResourceCollector<HttpListenerRequest, HttpListenerResponse>.Root(ioc.Resolve<HomeController>,
                    get: h => h.Handle(q => q, c => c.WithDefault().By(a => a.Index)),
                    nested: root => root
                        .Named("about",
                            get: h => h.Handle(q => q, c => c.WithDefault().By(a => a.About)))
                        .Named("news", r => ioc.Resolve<NewsController>(r),
                            get: h => h
                                .Handle(q => q
                                        .Single<int?>("page", s => int.Parse(s), null)
                                        .Single<bool?>("order", s => bool.Parse(s), null),
                                    c => c.WithDefault().By(a => a.Index))
                                .Handle(q => q
                                        .Single("page", int.Parse, 0)
                                        .Single("order", bool.Parse, false),
                                    c => c.WithDefault().ByAsync(a => a.IndexAsync))
                                .Handle(q => q
                                        .Single("page", int.Parse, 0)
                                        .Single("order", bool.Parse, false),
                                    c => c.WithDefault().ByAsyncCanc(a => a.IndexAsync))
                                .Handle(q => q
                                        .Single("page", int.Parse, 0),
                                    c => c.With(ioc.Resolve<ArticleController>).By(a => a.Index))
                                .Handle(q => q
                                        .Single("page", int.Parse, 0),
                                    c => c.With(ioc.Resolve<ArticleController>).ByAsync(a => a.IndexAsync))
                                .Handle(q => q
                                        .Single("page", int.Parse, 0),
                                    c => c.With(ioc.Resolve<ArticleController>).ByAsyncCanc(a => a.IndexAsync)),
                            post: h => h.Handle(q => q.Single("title", s => s).Single("content", s => s),
                                c => c.WithDefault().By(a => a.Add)),
                            nested: news => news
                                .Valued(int.Parse,
                                    get: h => h
                                        .Handle(q => q, c => c.WithDefault().By(a => a.Get)),
                                    put: h => h.Handle(q => q
                                            .Single("title", s => s)
                                            .Single("content", s => s),
                                        c => c.WithDefault().By(a => a.Change)),
                                    delete: h => h.Handle(q => q, c => c.WithDefault().By(a => a.Delete)),
                                    nested: cNews => cNews
                                        .Named("comments", r => ioc.Resolve<CommentController>(r),
                                            get: h => h.Handle(q => q
                                                    .Single<int?>("page", s => int.Parse(s), 0),
                                                c => c.WithDefault().By(a => a.Index)),
                                            post: h => h.Handle(q => q
                                                    .Single("title", s => s).Single("content", s => s),
                                                c => c.WithDefault().By(a => a.Add)),
                                            nested: comment => comment
                                                .Valued(int.Parse,
                                                    get: h => h.Handle(q => q, c => c.WithDefault().By(a => a.Get)),
                                                    put: h => h.Handle(q => q
                                                            .Single("content", s => s),
                                                        c => c.WithDefault().By(a => a.Change)),
                                                    delete: h =>
                                                        h.Handle(q => q, c => c.WithDefault().By(a => a.Delete))))))
                        .Named("articles", ioc.Resolve<ArticleController>,
                            get: h => h.Handle(q => q.Single("page", int.Parse, 0),
                                c => c.WithDefault().By(a => a.Index)),
                            post: h => h.Handle(q => q.Single("title", s => s).Single("content", s => s),
                                c => c.WithDefault().By(a => a.Add)),
                            nested: article => article
                                .Valued(int.Parse,
                                    get: h => h.Handle(q => q, c => c.WithDefault().By(a => a.Get)),
                                    put: h => h.Handle(q => q.Single("title", s => s).Single("content", s => s),
                                        c => c.WithDefault().By(a => a.Change)),
                                    delete: h => h.Handle(q => q, c => c.WithDefault().By(a => a.Delete))))
                )
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