using System;
using System.Net;
using System.Net.Mail;

class Program
{
    static void Main(string[] args)
    {
        string fromMail = "senderMailAddress@gmail.com";
        string fromPassword = "abcd efgh ijkl mnop";  //will be a 16 digit code

        String toMail = "receivingMailAddress@gmail.com";

        MailMessage mailMessage = new MailMessage();

        mailMessage.From = new MailAddress(fromMail);

        mailMessage.To.Add(toMail);
        //(Or) mailMessage.To.Add(new MailAddress("receivingMailAddress@gmail.com"));

        mailMessage.Subject = "Sample Mail from gmail SMTP mailer";
        mailMessage.Body = "This is a sample email sent from a C# application using Gmail SMTP mailer.";

        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

        smtpClient.Port = 587;
        smtpClient.Credentials = new NetworkCredential(fromMail, fromPassword);
        smtpClient.EnableSsl = true;

        try
        {
            smtpClient.Send(mailMessage);
            Console.WriteLine("Wohoon!.. Mail sent successfully!!");
            Console.WriteLine("Please check your mailbox");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to send email. Error message: {ex.Message}");
        }


    }

}