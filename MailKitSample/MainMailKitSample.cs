/**
 *@title SelfAspNet / MailKitSample / MainMailKitSample.cs
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@reference ◆MailKitの使い方! エンコーディング指定や添付ファイをメールで送信する方法[C#/VB Tips]
 *           https://www.sukerou.com/2018/10/vb-c-mailkit.html
 *           2021年2月10日水曜日
 *           
 *@content MailKitクラスライブラリのサンプルコード
 *         | ASP.NET 4.5- | 
 *         2017-04 System.Net.Mail.SmtpClientは、.NET標準ではなくなり、
 *         attribute [Obstlete] (非推奨, 廃止予定)と Microsoft Documentで発表
 *         MaiKit(外部ライブラリ)で代替することを推奨。
 *
 *@see MimeKitSample_API.txt
 *@see /Reference_MailKit
 *@author shika
 *@date 2022-04-14, 04-15
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfAspNet.MailKitSample
{
    public class MainMailKitSample
    { 
        //static void Main(string[] args)
        //public void Main(string[] args)
        //{
        //   //should start by IIS Express (Web Server). 
        //}//Main()
        
        public void MailSenderUtf8()
        {
            string host = "<smtp server name>";
            int port = 587;

            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                smtp.Connect(host, port,
                    MailKit.Security.SecureSocketOptions.Auto);
                //smtp.Authenticate("<id>", "<pass>");
                
                var mail = new MimeKit.MimeMessage();
                var builder = new MimeKit.BodyBuilder();

                mail.From.Add(
                    new MimeKit.MailboxAddress("<formName>", "<fromAddress>"));
                mail.To.Add(
                    new MimeKit.MailboxAddress("<toName>", "<toAddress>"));
                mail.Subject = "title";
                builder.TextBody = "mail body";
                
                mail.Body = builder.ToMessageBody();

                smtp.Send(mail);
                smtp.Disconnect(true);
            }//using
        }//MailSenderUtf8()
    }//class
}