﻿using RentACars.Common;


namespace RentACars.Helpers
{
    public interface IMailHelper
    {
        Response SendMail(string toName, string toEmail, string subject, string body);
    }
}