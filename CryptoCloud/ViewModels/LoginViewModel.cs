using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoCloud.Models;
using CryptoCloud.Services;
using CryptoCloud.Validators;
using CryptoCloud.Views;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoCloud.ViewModels
{
    public class LoginViewModel : ViewModel
    {
        private readonly MainWindowNavigator mainWindowNavigator;
        private readonly UserModelValidator validator;

        private readonly ILogger logger;

        public ICommand LoginButtonCommand { get; set; }

        public UserModel User { get; set; } = new UserModel();

        public LoginViewModel(MainWindowNavigator mainWindowNavigator, UserModelValidator validator, ILoggerFactory loggerFactory)
        {
            LoginButtonCommand = new AsyncRelayCommand(LoginButtonCommandHandler);
            this.mainWindowNavigator = mainWindowNavigator;
            this.validator = validator;

            logger = loggerFactory.CreateLogger<LoginViewModel>();
        }

        private async Task LoginButtonCommandHandler()
        {
            logger.LogDebug($"Trying to validate user: {{ email = {User.Email}, password = {User.Password} }}");

            var clientValidation = validator.Validate(User);

            bool serverValidationIsOk = await ValidateLoginOnServerAsync(User);

            if (serverValidationIsOk && clientValidation.IsValid)
            {
                logger.LogInformation($"User validation success.");

                mainWindowNavigator.NavigateToView<LinkDiskViewModel>();
            }
            else
            {
                var errors = string.Join('\n', clientValidation.Errors.Select(x => x.ErrorMessage));
                logger.LogWarning($"User validation failure. Error: {errors}");

                ShowUpError(clientValidation.Errors);
            }
        }

        public InputErrorViewModel EmailErrorViewModel { get; set; }
        public InputErrorViewModel PasswordErrorViewModel { get; set; }

        private void ShowUpError(List<ValidationFailure> errors)
        {
            EmailErrorViewModel = new InputErrorViewModel
            {
                Errors = errors.Where(x => x.PropertyName == nameof(User.Email)).Select(x => x.ErrorMessage).Take(1).ToList(),
                IsShown = true
            };

            PasswordErrorViewModel = new InputErrorViewModel
            {
                Errors = errors.Where(x => x.PropertyName == nameof(User.Password)).Select(x => x.ErrorMessage).Take(1).ToList(),
                IsShown = true
            };

            OnPropertyChanged(nameof(EmailErrorViewModel));
            OnPropertyChanged(nameof(EmailErrorViewModel.IsShown));
            OnPropertyChanged(nameof(PasswordErrorViewModel));
            OnPropertyChanged(nameof(PasswordErrorViewModel.IsShown));
        }

        private Task<bool> ValidateLoginOnServerAsync(UserModel user)
        {
            // some network work
            return Task.FromResult(true);
        }
    }
}
