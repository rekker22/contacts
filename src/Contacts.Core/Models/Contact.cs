namespace Contacts.Core.Models;

public record Contact(
    Guid Id,
    string Name,
    string Number,
    string Email
);