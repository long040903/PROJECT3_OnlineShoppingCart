﻿using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace OnlineShoppingCart.Services
{
    public class MailKitEmailService : IEmailService
    {
        public async Task SendEmailAsync(string fromEmail, string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("", fromEmail));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;
            message.Body = new TextPart("html") { Text = body };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls); // Sử dụng STARTTLS
            await client.AuthenticateAsync("khanhcr2807@gmail.com", "josw xbql dlcj atxj"); // Thay bằng mật khẩu ứng dụng của bạn
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
