using Explorer.BuildingBlocks.Core.Domain;
using System.Net.Mail;

namespace Explorer.Stakeholders.Core.Domain;

public class Person : Entity
{
    public long UserId { get;  init; }
    public string Name { get; init; }
    public string Surname { get; init; }
    public string Email { get; init; }
    public string Motto { get; init; }
    public string Biography { get; init; }
    public string Image { get; init; }
    public decimal Latitude { get; init; }
    public decimal Longitude { get; init; }
    public ApplicationRate ApplicationRate { get; init; }

    public Person(long userId, string name, string surname, string email, string motto, string biography, string image, decimal latitude, decimal longitude)
    {
        UserId = userId;
        Name = name;
        Surname = surname;
        Email = email;
        Motto = motto;
        Biography = biography;
        Image = image;
        Latitude = latitude;
        Longitude = longitude;
        Validate();
    }

    public Person(Person person)
    {
        UserId = person.UserId;
        Name = person.Name;
        Surname = person.Surname;
        Email = person.Email;
        Latitude = person.Latitude;
        Longitude = person.Longitude;
        Validate();
    }

    private void Validate()
    {
        if (UserId == 0) throw new ArgumentException("Invalid UserId");
        if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid Name");
        if (string.IsNullOrWhiteSpace(Surname)) throw new ArgumentException("Invalid Surname");
        if (!MailAddress.TryCreate(Email, out _)) throw new ArgumentException("Invalid Email");
    }
}