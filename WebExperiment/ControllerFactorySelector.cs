using System;
using WebExperiment.FunctionSelectors;

namespace WebExperiment
{
    public class ControllerFactorySelector<TRequest, TController>
    {
        private readonly Func<TRequest, TController> _controllerFactory;

        public ControllerFactorySelector(Func<TRequest, TController> controllerFactory)
        {
            _controllerFactory = controllerFactory;
        }

        public MethodSelector<TRequest, TController> WithDefault()
        {
            return new MethodSelector<TRequest, TController>(_controllerFactory);
        }

        public MethodSelector<TRequest, TAlternativeController> With<TAlternativeController>(Func<TRequest, TAlternativeController> controllerFactory)
        {
            return new MethodSelector<TRequest, TAlternativeController>(controllerFactory);
        }
    }

    public class ControllerFactorySelector<TRequest, TController, T1>
    {
        private readonly Func<TRequest, TController> _controllerFactory;

        public ControllerFactorySelector(Func<TRequest, TController> controllerFactory)
        {
            _controllerFactory = controllerFactory;
        }

        public MethodSelector<TRequest, TController, T1> WithDefault() =>
            new MethodSelector<TRequest, TController, T1>(_controllerFactory);

        public MethodSelector<TRequest, TAlternativeController, T1> With<TAlternativeController>(Func<TRequest, TAlternativeController> controllerFactory) =>
            new MethodSelector<TRequest, TAlternativeController, T1>(controllerFactory);
    }
    
    public class ControllerFactorySelector<TRequest, TController, T1, T2>
    {
        private readonly Func<TRequest, TController> _controllerFactory;

        public ControllerFactorySelector(Func<TRequest, TController> controllerFactory)
        {
            _controllerFactory = controllerFactory;
        }

        public MethodSelector<TRequest, TController, T1, T2> WithDefault() =>
            new MethodSelector<TRequest, TController, T1, T2>(_controllerFactory);

        public MethodSelector<TRequest, TAlternativeController, T1, T2> With<TAlternativeController>(Func<TRequest, TAlternativeController> controllerFactory) =>
            new MethodSelector<TRequest, TAlternativeController, T1, T2>(controllerFactory);
    }
    
    public class ControllerFactorySelector<TRequest, TController, T1, T2, T3>
    {
        private readonly Func<TRequest, TController> _controllerFactory;

        public ControllerFactorySelector(Func<TRequest, TController> controllerFactory)
        {
            _controllerFactory = controllerFactory;
        }

        public MethodSelector<TRequest, TController, T1, T2, T3> WithDefault() =>
            new MethodSelector<TRequest, TController, T1, T2, T3>(_controllerFactory);

        public MethodSelector<TRequest, TAlternativeController, T1, T2, T3> With<TAlternativeController>(Func<TRequest, TAlternativeController> controllerFactory) =>
            new MethodSelector<TRequest, TAlternativeController, T1, T2, T3>(controllerFactory);
    }
}
