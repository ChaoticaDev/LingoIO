using Windows.UI.Xaml;
using System.Threading.Tasks;
using Chaotica___LingoIO.Services.SettingsServices;
using Windows.ApplicationModel.Activation;
using Template10.Controls;
using Template10.Common;
using System;
using System.Linq;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Controls;
using Chaotica___LingoIO.Core;
using Chaotica___LingoIO.Views;

namespace Chaotica___LingoIO
{
    /// Documentation on APIs used in this page:
    /// https://github.com/Windows-XAML/Template10/wiki

    [Bindable]
    sealed partial class App : BootStrapper
    {
        
        public static ChaoticaLanguage LearningLanguage = ChaoticaLanguage.Spanish;

        public static int LearningLanguageID
        {
            get
            {
                return LearningLanguage == ChaoticaLanguage.Spanish ? 2 : LearningLanguage == ChaoticaLanguage.English ? 1 : LearningLanguage == ChaoticaLanguage.German ? 3 : 2;
            }
        }

        public App()
        {
            InitializeComponent();
            Shell.DB.Connect();
            SplashFactory = (e) => new Views.Splash(e);

            #region app settings

            // some settings must be set in app.constructor
            var settings = SettingsService.Instance;
            RequestedTheme = settings.AppTheme;
            CacheMaxDuration = settings.CacheMaxDuration;
            ShowShellBackButton = settings.UseShellBackButton;
            AutoSuspendAllFrames = true;
            AutoRestoreAfterTerminated = true;
            AutoExtendExecutionSession = true;

            #endregion
        }

        public override UIElement CreateRootElement(IActivatedEventArgs e)
        {
            var service = NavigationServiceFactory(BackButton.Attach, ExistingContent.Exclude);
            return new ModalDialog
            {
                DisableBackButtonWhenModal = true,
                Content = new Views.Shell(service),
                ModalContent = new Views.Busy(),
            };
        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            // TODO: add your long-running task here
            await NavigationService.NavigateAsync(typeof(Views.MainPage));
        }
    }
}

