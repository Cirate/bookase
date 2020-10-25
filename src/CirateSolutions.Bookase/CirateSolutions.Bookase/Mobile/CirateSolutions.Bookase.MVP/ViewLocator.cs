using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CirateSolutions.Bookase.MVP.Interfaces;

namespace CirateSolutions.Bookase.MVP
{
        public class ViewLocator : IViewLocator
        {
            private Dictionary<Type, Type> _presenterToView;

            internal void Build(
                IEnumerable<Assembly> viewAssemblies,
                IEnumerable<Assembly> presenterAssemblies)
            {
                var viewTypes = viewAssemblies
                    .SelectMany(x => x.GetTypes())
                    .Where(
                        x =>
                            typeof(IView).IsAssignableFrom(x)
                            && !x.IsAbstract
                            && !x.IsInterface)
                    .ToArray();

                _presenterToView = presenterAssemblies
                    .SelectMany(x => x.GetTypes())
                    .Where(
                        x =>
                            x.IsInterface
                            && typeof(IPresenter).IsAssignableFrom(x)
                            && x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IPresenter<>)))
                    .Select(
                        presenterType =>
                        {
                            var viewInterfaceType = presenterType.GetInterfaces()
                                .Single(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IPresenter<>))
                                .GenericTypeArguments[0];
                            var viewType = viewTypes.Single(y => viewInterfaceType.IsAssignableFrom(y));
                            return (presenterType, viewType);
                        })
                    .ToDictionary(x => x.presenterType, x => x.viewType);
            }

            public Type GetViewType<TPresenter>() => GetViewType(typeof(TPresenter));
            public Type GetViewType(Type presenterType) => _presenterToView[presenterType];
    }
}