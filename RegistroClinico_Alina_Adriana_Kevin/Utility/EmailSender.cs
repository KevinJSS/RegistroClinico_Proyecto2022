﻿using Microsoft.AspNetCore.Identity.UI.Services;

namespace RegistroClinico_Alina_Adriana_Kevin.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
