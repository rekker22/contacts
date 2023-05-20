using System;

namespace Contacts.Desktop.Models;

public record Contact(
    Guid Id,
    string Name,
    string Number,
    string Email
);