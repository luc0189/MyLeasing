using MyLeasing.Common.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLeasing.Prism.ViewModels
{
  public  class PropertyItemVieModel : PropertyResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _SelectPropertyCommand;

        public PropertyItemVieModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public DelegateCommand SelectPropertyCommand => _SelectPropertyCommand ?? (_SelectPropertyCommand = new DelegateCommand(SelectProperty));
        private  async void  SelectProperty()
        {
            var parameters = new NavigationParameters
            {
                { "property", this }
            };
            await _navigationService.NavigateAsync("PropertyPage",parameters);
        }
    }
}
