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

        /// <inheritdoc />
        public override void ClearRoot()
        {
            _rootViewModel = null;
        }

        /// <inheritdoc />        
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

        /// <inheritdoc />       
        public TRootViewModel RootViewModel => _rootViewModel ?? (_rootViewModel = GetRootViewModel());

        /// <inheritdoc />
        public string Id => GetId();

        /// <inheritdoc />       
        public string Name => GetName();

        /// <inheritdoc />       
        public int Order => GetOrder();                
    }
}