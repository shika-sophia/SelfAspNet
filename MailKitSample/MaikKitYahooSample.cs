/*
 * @title MailKitSample / MailKitYahooSample.cs
 * @see MainMailKitSample.cs
 * @see Reference_MailKit / MailKit_CsharpMailSend.txt
 * 
 * ＊Yahooメールで送信する
 * YahooのSMTPサーバを使ってメールを送信するサンプルコードです。
 * SMTPS(over SSL)でメールを暗号化します。
 * ※ Yahoo Japanは STARTTLSには対応していない模様
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfAspNet.MailKitSample
{
    public class MaikKitYahooSample
    {
        public void MailSenderYahoo()
        {
            string host = "smtp.mail.yahoo.co.jp";
            int port = 465;

            using(var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                //(1)SMTPS(over SSL)で接続します。
                smtp.Connect(host, port,
                    MailKit.Security.SecureSocketOptions.SslOnConnect);
                //(2)Yahooメールのアカウント（メールアドレスの@より前の部分)を指定して認証する
                smtp.Authenticate("<account>xxxxxxxx@yahoo.co.jp", " <password>");

                var mail = new MimeKit.MimeMessage();
                var builder = new MimeKit.BodyBuilder();

                mail.From.Add(
                    new MimeKit.MailboxAddress("", "xxxxxxxx@yahoo.co.jp"));
                mail.To.Add(
                    new MimeKit.MailboxAddress("", "<toAddress>"));
                mail.Subject = "メールの件名";
                
                builder.TextBody = "メールの本文です。\n\n以上";
                mail.Body = builder.ToMessageBody();

                smtp.Send(mail);
                smtp.Disconnect(true);
            }//using
        }//MailSenderYahoo()
    }//class
}