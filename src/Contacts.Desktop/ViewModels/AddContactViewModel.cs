using System;
using System.Text.RegularExpressions;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Contacts.Core.Interfaces;
using Contacts.Core.Models;
using Contacts.Desktop.Messages;
using Microsoft.Extensions.DependencyInjection;

namespace Contacts.Desktop.ViewModels;

public partial class AddContactViewModel : ViewModelBase
{
    private readonly IContactsService _contactsService;
    private readonly Regex _isNumeric;
    private readonly Regex _isEmail;

    public AddContactViewModel()
    {
        _contactsService = App.Current.Services.GetService<IContactsService>()!;
        _isNumeric = new Regex(@"^\d+$");
        _isEmail = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
    }

    private string _name = null!;
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name is required");
            }
            SetProperty(ref _name, value);
        }
    }
    
    private string _number = null!;
    public string Number
    {
        get => _number;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Number is required");
            }
            if (!_isNumeric.IsMatch(value.Trim()))
            {
                throw new ArgumentException("Number is not valid");
            }
            SetProperty(ref _number, value);
        }
    }

    private string _email = null!;
    public string Email
    {
        get => _email;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Email is required");
            }
            if (!_isEmail.IsMatch(value.Trim()))
            {
                throw new ArgumentException("Email is not valid");
            }
            SetProperty(ref _email, value);
        }
    }

    [RelayCommand]
    private void SaveContact()
    {
        var contact = new Contact(Guid.NewGuid(), Name.Trim(), Number.Trim(), Email.Trim());
        _contactsService.Add(contact);
        Messenger.Send(new ContactAddedMessage(contact));
    }
}