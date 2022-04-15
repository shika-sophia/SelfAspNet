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
 */
#region -> MailKit API 〔NT 122 App1-〕
/*
 *@require VS [Menu] -> [Project] -> [NuGet] -> "MailKit" install
 *
 *@class   ==== MainMailKitSample.cs ==== (here)
 *@subject MailKitクラス 〔NT 122 app1-〕
 *         MailKit.Net.Smtp.SmtpClient smtp =
 *              new MailKit.Net.Smtp.SmtpClient()
 *         void smtp.Connect(string host, [int port], 
 *             [MailKit.Security.SecureSocketOptions])
 *                SecureSocketOptions.Auto
 *                SecureSocketOptions.SslOnConnect SMTPS (SSL通信)
 *                SecureSocketOptions.StartTls     STARTTLS (SSL通信)
 *         void smtp.Autenticate(string id, string password)
 *         void smtp.Send(MimeKit.MimeMessage)
 *         void smtp.Disconnect(bool quit)
 *         void smtp.Dispose()
 *         
 *@subject MimeKitクラス
 *         MimeKit.MimeMessage mail =
 *             new MimeKit.MimeMessage()
 *         MimeKit.MailboxAddress : InternetAddress
 *             new MailboxAddress(string name, string address)
 *             ※ alias(=エイリアス 別名)を利用は nameに設定
 *             
 *         MimeKit.InternetAddressList mail.From
 *         MimeKit.InternetAddressList mail.To
 *         void   mail.From.Add(MimeKit.InternetAddress)
 *         void   mail.To.Add(MimeKit.InternetAddress)
 *         string mail.Subject
 *         MimeKit.MimeEntity
 *                mail.Body = builder.ToMessgaeBody()
 *                
 *@subject BodyBuilder
 *         MimeKit.BodyBuilder builder =
 *             new MimeKit.BodyBuilder()
 *         string builder.TextBody
 *         string builder.HtmlBody
 *         MimeKit.MimeEntity builder.ToMessgaeBody()
 *         
 *@class   ==== MailKitEncodingSample.cs ====
 *@subject System.Text.Encoding
 *         Encoding Encoding.GetEncoding(string)
 *         Encoding Encoding.UTF8 //MimeKit デフォルト
 *
 *@subject MimeKitクラス
 *         MimeKit.HeaderList mail.Headers
 *         void headers.Add(MimeKit.HeaderId, string)
 *         void headers.Replace(MimeKit.HeaderId, Encoding, string)
 *             enum MimeKit.HeaderId
 *             int? MimeKit.HeaderId.Subject = 113
 *             
 *         ※ MimeKitMessageクラスのインスタンス生成時に
 *            Subjectヘッダーが生成されるので、
 *            Add()をすると二重にSubjectが生成される。
 *            Replace()で Encodingと 代替文字列を指定して置換すべき
 *            
 *@subject TextPartクラス
 *         MimeKit.TextPart textPart =
 *             new MimeKit.TextPart(string subtype) "plain" | "html"
 *         void textPart.SetText(Encoding, string text)
 *         MimeKit.ConnectEncoding
 *              textPart.ContentTransferEncoding 送信時の文字コード？
 *         
 */
#endregion
/*
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