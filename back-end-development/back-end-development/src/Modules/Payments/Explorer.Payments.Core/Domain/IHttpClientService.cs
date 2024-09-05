namespace Explorer.Payments.Core.Domain;

public interface IHttpClientService
{
    void SendEmail(string email);
}
