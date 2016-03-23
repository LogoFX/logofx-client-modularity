using System;
using Solid.Practices.IoC;

namespace LogoFX.Client.Modularity
{
    /// <summary>
    /// Represents ui module without root view model.
    /// Used to clear the root view model in the extending module.
    /// </summary>
    public abstract class UiModuleBase
    {
        /// <summary>
        /// Clears the root view model.
        /// </summary>
        public abstract void ClearRoot();
    }

    /// <summary>
    /// Represents ui module with root view model.
    /// </summary>
    /// <typeparam name="TRootViewModel">The type of the root view model.</typeparam>
    public abstract class UiModuleBase<TRootViewModel> : UiModuleBase, IUiModule<TRootViewModel>
        where TRootViewModel : class, IRootViewModel
    {
        private TRootViewModel _rootViewModel;
        private IIocContainerResolver _iocContainer;

        /// <summary>
        /// Gets the root view model.
        /// </summary>
        /// <returns></returns>
        protected virtual TRootViewModel GetRootViewModel()
        {
            return _rootViewModel ?? (_rootViewModel = _iocContainer.Resolve<TRootViewModel>());
        }

        /// <summary>
        /// Clears the root view model.
        /// </summary>
        public override void ClearRoot()
        {
            _rootViewModel = null;
        }

        /// <summary>
        /// Gets the type of the root view model.
        /// </summary>
        public Type RootModelType
        {
            get { return typeof(TRootViewModel); }
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <returns></returns>
        protected abstract string GetId();

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns></returns>
        protected abstract string GetName();

        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <returns></returns>
        protected abstract int GetOrder();

        /// <summary>
        /// Gets the root view model.
        /// </summary>
        public TRootViewModel RootViewModel
        {
            get { return GetRootViewModel(); }
        }

        /// <summary>
        /// Module ID.
        /// </summary>
        public string Id
        {
            get { return GetId(); }
        }

        /// <summary>
        /// Module display name.
        /// </summary>
        public string Name
        {
            get { return GetName(); }
        }

        /// <summary>
        /// Module display order.
        /// </summary>
        public int Order
        {
            get { return GetOrder(); }
        }

        /// <summary>
        /// Registers composition module into IoC container.
        /// </summary>
        /// <param name="iocContainer">IoC container.</param>
        public void RegisterModule(IIocContainer iocContainer)
        {
            RegisterCore(iocContainer);
            RegisterOverride(iocContainer);
        }

        private void RegisterCore(IIocContainer iocContainer)
        {
            _iocContainer = iocContainer;
        }

        /// <summary>
        /// Override this method to inject custom logic during module registration.
        /// </summary>
        /// <param name="iocContainer">The ioc container.</param>
        public virtual void RegisterOverride(IIocContainer iocContainer)
        {

        }
    }
}