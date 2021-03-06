﻿using Chaotica___LingoIO.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;

namespace Chaotica___LingoIO.ViewModels
{
    public class CoursesPageViewModel : ViewModelBase
    {

        public CoursesPageViewModel()
        {

        }

        private ObservableCollection<ChaoticaCourse> _Courses;

        public ObservableCollection<ChaoticaCourse> Courses
        {
            get
            {
                return this._Courses;
            }

            set
            {
                _Courses = value;
            }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            if (suspensionState.Any())
            {

            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
                //suspensionState[nameof(Value)] = Value;
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        public void GotoExamine(object sender)
        {
            //NavigationService.Navigate(typeof(Views.ExaminePage));
        }


    }
}
