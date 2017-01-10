using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using Chaotica___LingoIO.Core;
using System.Collections.Generic;
using static Chaotica___LingoIO.Core.ChaoticaCore;
using System;
using Windows.UI.Xaml.Navigation;
using MySql.Data.MySqlClient;

namespace Chaotica___LingoIO.Views
{
    public sealed partial class VocabPage : Page
    {
        private ObservableCollection<ChaoticaWord> _VocabWords;
        
        public ObservableCollection<ChaoticaWord> VocabWords
        {

            get
            {
                return this._VocabWords;
            }

            set
            {
                _VocabWords = value;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        public VocabPage()
        {
            InitializeComponent();
            
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;

            this.VocabWords = ChaoticaCore.DataCached.VocabularyListCache;
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
