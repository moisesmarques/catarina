using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Catarina.Web.Providers.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(
            EmailSettings emailSettings,
            ILogger<EmailSender> logger )
        {
            _emailSettings = emailSettings;
            _logger = logger;
        }

        public async Task SendEmailAsync( string email, string subject, string message )
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add( new MailboxAddress( _emailSettings.From ) );
            emailMessage.To.Add( new MailboxAddress( email ) );
            emailMessage.Subject = message;
            emailMessage.Body = new TextPart( MimeKit.Text.TextFormat.Text ) { Text = message };

            using ( var client = new SmtpClient() )
            {
                try
                {
                    client.ServerCertificateValidationCallback = ( s, c, h, e ) => true;
                    client.Connect( _emailSettings.SmtpServer, _emailSettings.Port, SecureSocketOptions.Auto );
                    client.AuthenticationMechanisms.Remove( "XOAUTH2" );
                    client.Authenticate( _emailSettings.UserName, _emailSettings.Password );

                    await client.SendAsync( emailMessage );
                }
                catch(Exception ex)
                {
                    _logger.LogError( "ERROR: AccountController - ${ex.Message}" );
                    throw;
                }
                finally
                {
                    client.Disconnect( true );
                    client.Dispose();
                }
            }
        }

        //private bool ServerCertificateValidationCallback( object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors )
        //{
        //    if ( sslPolicyErrors == SslPolicyErrors.None )
        //        return true;

        //    // Note: The following code casts to an X509Certificate2 because it's easier to get the
        //    // values for comparison, but it's possible to get them from an X509Certificate as well.
        //    if ( certificate is X509Certificate2 certificate2 )
        //    {
        //        var cn = certificate2.GetNameInfo( X509NameType.SimpleName, false );
        //        var fingerprint = certificate2.Thumbprint;
        //        var serial = certificate2.SerialNumber;
        //        var issuer = certificate2.Issuer;

        //        return cn == "imap.gmail.com" && issuer == "CN=GTS CA 1O1, O=Google Trust Services, C=US" &&
        //        serial == "0096768414983DDE9C0800000000320A68" &&
        //        fingerprint == "A53BA86C137D828618540738014F7C3D52F699C7";
        //    }

        //    return false;
        //}
    }
}
