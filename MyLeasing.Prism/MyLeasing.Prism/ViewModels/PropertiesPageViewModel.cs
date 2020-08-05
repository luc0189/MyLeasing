using DryIoc;
using MyLeasing.Common.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using Xamarin.Forms;

namespace MyLeasing.Prism.ViewModels
{
    public class PropertiesPageViewModel : ViewModelBase

    {
        private readonly INavigationService _navigationService;
        private OwnerResponse _owner;
        private ObservableCollection<PropertyItemVieModel> _properties;
        public PropertiesPageViewModel(
            INavigationService navigationService ):base(navigationService)
        {
            Title = "Properties";
            _navigationService = navigationService;
        }
        public ObservableCollection<PropertyItemVieModel> Properties
        {
            get => _properties;
            set => SetProperty(ref _properties, value);
           
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
            if (parameters.ContainsKey("owner"))
            {
                _owner = parameters.GetValue<OwnerResponse>("owner");
                Title = $"Properties of: {_owner.FullName}";
                Properties = new ObservableCollection<PropertyItemVieModel>(
                    _owner.Properties.Select(p => new PropertyItemVieModel(_navigationService)
                    {
                    Address= p.Address,
                    Contracts=p.Contracts,
                    HasParkingLot=p.HasParkingLot,
                    Id=p.Id,
                    IsAvailable=p.IsAvailable,
                    Neighborhood=p.Neighborhood,
                    Price=p.Price,
                    PropertyImages=p.PropertyImages,
                    PropertyType=p.PropertyType,
                    Remarks=p.Remarks,
                    Rooms=p.Rooms,
                    SquareMeters=p.SquareMeters,
                    Stratum=p.Stratum
                    
                    }).ToList());
            }
        }

    }
}
