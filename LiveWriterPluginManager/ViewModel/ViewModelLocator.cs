using GalaSoft.MvvmLight.Ioc;
using LiveWriterPluginManager.Services;
using Microsoft.Practices.ServiceLocation;
using ScottIsAFool.Windows.MvvmLight.Extensions;

namespace LiveWriterPluginManager.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
            
            SimpleIoc.Default.RegisterIf<IZipService, ZipService>();
            SimpleIoc.Default.RegisterIf<IFileService, FileService>();
            SimpleIoc.Default.RegisterIf<ILiveWriterService, LiveWriterService>();

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AddPluginViewModel>();
            SimpleIoc.Default.Register<RemovePluginViewModel>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public AddPluginViewModel AddPlugin => ServiceLocator.Current.GetInstance<AddPluginViewModel>();
        public RemovePluginViewModel RemovePlugin => ServiceLocator.Current.GetInstance<RemovePluginViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}