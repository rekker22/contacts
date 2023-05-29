using System;
using CommunityToolkit.Mvvm.ComponentModel;
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

    public AddContactViewModel()
    {
        _contactsService = App.Current.Services.GetService<IContactsService>()!;
    }

    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private string _number;

    [ObservableProperty]
    private string _email;

    [RelayCommand]
    private void SaveContact()
    {
        var contact = new Contact(Guid.NewGuid(), Name, Number, Email);
        _contactsService.Add(new Contact(Guid.NewGuid(), Name, Number, Email));
        Messenger.Send(new ContactAddedMessage(contact));
    }
}