using System;

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

        /// <summary>
        /// Gets the root view model.
        /// </summary>
        /// <returns></returns>
        protected abstract TRootViewModel GetRootViewModel();        

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
        public Type RootModelType => typeof(TRootViewModel);

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
        public TRootViewModel RootViewModel => _rootViewModel ?? (_rootViewModel = GetRootViewModel());

        /// <summary>
        /// Module ID.
        /// </summary>
        public string Id => GetId();

        /// <summary>
        /// Module display name.
        /// </summary>
        public string Name => GetName();

        /// <summary>
        /// Module display order.
        /// </summary>
        public int Order => GetOrder();                
    }
}