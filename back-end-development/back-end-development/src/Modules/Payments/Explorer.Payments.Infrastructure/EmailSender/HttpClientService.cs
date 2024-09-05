using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using Explorer.Payments.Core.Domain;

namespace Explorer.Payments.Infrastructure.EmailSender;

public class HttpClientService : IHttpClientService
{


    public void SendEmail(string email)
    {
        try
        {
            string fromMail = "ftngrupa7@gmail.com";
            string fromPassword = "msojuultbqzudgsa";

            MailMessage message1 = new MailMessage();
            message1.From = new MailAddress(fromMail);
            message1.Subject = $"Uspesno kupljena tura!";
            message1.To.Add(new MailAddress(email));

            // HTML content
            string htmlContent = @"
        <!DOCTYPE html>
<html>
<head>
    <style>
        body {
            font-family: 'Arial', sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
            color: #333;
        }
        .header {
            background-color: #28a745; /* Green shade */
            color: white;
            padding: 40px;
            text-align: center;
            border-bottom: 5px solid #218838; /* Darker green */
        }
        .header h1 {
            margin: 0;
            font-size: 28px; /* Slightly larger */
        }
        .content {
            background: white;
            padding: 50px;
            margin: 30px auto; /* Centered with auto */
            border-radius: 10px;
            box-shadow: 0 6px 12px rgba(0, 0, 0, 0.1);
            max-width: 600px; /* Max width */
        }
        .footer {
            text-align: center;
            padding: 25px;
            font-size: 16px;
            color: #555;
            background-color: #e9ecef; /* Light gray */
            border-top: 4px solid #ced4da; /* Gray border */
        }
        .button {
            background-color: #28a745; /* Green shade */
            color: white;
            padding: 15px 30px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            border-radius: 5px;
            margin-top: 25px;
            font-size: 18px;
            font-weight: bold;
            border: none;
            transition: background-color 0.3s;
        }
        a.button:hover {
            background-color: #218838; /* Darker green */
        }
    </style>
</head>
<body>
    <div class=""header"">
        <h1>Successfully purchased!</h1>
    </div>

    <div class=""content"">
        <p>Hello,</p>
        <p>We're excited to confirm your recent tour purchase with us. Prepare for an adventure.</p>
        <p>If you have any questions or need further details, our support team is just a message away. We are dedicated to making your experience smooth and enjoyable.</p>
        <a href=""http://localhost:4200/"" class=""button"">Explore More</a>
    </div>

    <div class=""footer"">
        &copy; 2024 Explorer Company. Embrace the Journey. All rights reserved. | <a href=""http://localhost:4200/"">Terms & Conditions</a>
    </div>
</body>
</html>";

            message1.Body = htmlContent;
            message1.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true
            };

            smtpClient.Send(message1);
        }
        catch (Exception ex)
        {
            // Handle exceptions
        }
    }



}