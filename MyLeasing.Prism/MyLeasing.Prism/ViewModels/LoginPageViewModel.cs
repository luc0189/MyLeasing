﻿using ImTools;
using MyLeasing.Common.Models;
using MyLeasing.Common.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLeasing.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private string _password;
        private bool _isRunning;
        private bool _isEnable;
        private DelegateCommand _loginCommand;

        public LoginPageViewModel(
            INavigationService navigationService,
            IApiService apiService): base(navigationService)
        {
            Title = "Login ";
            IsEnable = true;
            _navigationService = navigationService;
            _apiService = apiService;
        }
       
        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand=new DelegateCommand(Login));

      
        public string Email { get; set; }
        public string Password 
        { get => _password;
          set => SetProperty(ref _password, value);
        }
        public bool IsRunning 
        { get=> _isRunning;
          set=>SetProperty(ref _isRunning,value);
        }
        public bool IsEnable
        {
            get => _isEnable;
            set => SetProperty(ref _isEnable, value);
        }
        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Your must enter and Email","Accept");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Your must enter and Password", "Accept");
                return;
            }
            IsRunning = true;
            IsEnable = false;
            var url = App.Current.Resources["UrlAPI"].ToString();
            var connection = await _apiService.CheckConnectionAsync(url);
            if (!connection)
            {
                IsEnable = true;
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert("Error", "Check the internet connection.", "Accept");
                return;
            }

            var request = new TokenRequest
            {
                Password = Password,
                Username = Email
            };
            
            var response = await _apiService.GetTokenAsync(url, "Account", "/CreateToken", request);
            
            if (!response.IsSuccess)
            {
                IsEnable = true;
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert("Error", "User or password incorrect.", "Accept");
                Password = string.Empty;
                return;
            }
            var token = response.Result;
            var response2 = await _apiService.GetOwnerByEmailAsync
                (
                url,
                "api",
                "/Owners/GetOwnerByEmail",
                "bearer",
                token.Token,
                Email
                );
            if (!response2.IsSuccess)
            {
                
                await App.Current.MainPage.DisplayAlert("Error", "Problem. call Soport: 310795..", "Accept");
                IsEnable = false;
                IsRunning = true;
                return;
            }
            var owner = response2.Result;
            var parameters = new NavigationParameters
            {
                { "owner", owner }
            };
           
            await _navigationService.NavigateAsync("PropertiesPage",parameters);
           
            IsRunning = false;
            IsEnable = true;
        }

        
        }


    }

