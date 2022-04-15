/*
 * @title MailKitSample / MailKitGoogleSample.cs
 * @see MainMailKitSample.cs
 * @see Reference_MailKit / MailKit_CsharpMailSend.txt
 * 
 * ＊GMailで送信する
 * GMailのSMTPサーバを使ってメールを送信するサンプルコードです。
 * STARTTLSで送信します。
 * このサンプルでメールを送るには、Googleアカウントのセキュリティ設定を変更する必要があります。
 * ※セキュリティが低くなるので、自己責任でお願いします。
 *
 * 設定         内容
 * ２段階認証    オフ
 * 安全性の低いアプリのアクセス オン
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfAspNet.MailKitSample
{
    public class MailKitGoogleSample
    {
        public void MailSenderGoogle()
        {
            string host = "smtp.gmail.com";
            int port = 5;

            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                //(1)STARTTLSで接続する
                smtp.Connect(host, port,
                    MailKit.Security.SecureSocketOptions.StartTls);
                //(2)GMailメールのアカウントを指定して認証する
                smtp.Authenticate("<account> xxxxxxxx@gmail.com", " <password>");

                var mail = new MimeKit.MimeMessage();
                var builder = new MimeKit.BodyBuilder();

                mail.From.Add(
                    new MimeKit.MailboxAddress("", "xxxxxxxx@gmail.com"));
                mail.To.Add(
                    new MimeKit.MailboxAddress("", "<toAddress>"));
                mail.Subject = "メールの件名";

                builder.TextBody = "メールの本文です。\n\n以上";
                mail.Body = builder.ToMessageBody();

                smtp.Send(mail);
                smtp.Disconnect(true);
            }//using
        }//MailSenderGoogle()
    }//class
}