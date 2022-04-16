/**
 *@title SelfAspNet / MailKitSample / MailKitCopySample.cs
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@reference ■ Qiita Blog /author: @tkc13687936
 *           更新日 2020年05月12日
 *           ◆C#でメール送信する
 *            https://qiita.com/tkc13687936/items/fbbc1339d0af1c26b004
 *            =>〔Reference / MailKit_Example.txt〕
 *            
 *@content MailKitによるメール送信の汎用コピーコード
 *@subject
 *
 *@see MailKitSample_API.txt
 *@author shika
 *@date 2022-04-16
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace SelfAspNet.MailKitSample
{
    public class MailKitCopySample
    {
        public void MailSenderForCopy()
        {
            var host = "smtp server name";
            var port = 587; // 25 or 465 or 587;

            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    //開発用のSMTPサーバが暗号化に対応していないときは、次の行をコメントアウト
                    //smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    smtp.Connect(host, port, MailKit.Security.SecureSocketOptions.Auto);
                    //認証設定
                    smtp.Authenticate("id", "password");

                    //送信するメールを作成する
                    var mail = new MimeKit.MimeMessage();
                    var builder = new MimeKit.BodyBuilder();
                    mail.From.Add(new MimeKit.MailboxAddress("", "送る人のメールアドレス"));
                    mail.To.Add(new MimeKit.MailboxAddress("", "配信先のメールアドレス"));
                    mail.Subject = "メールタイトル";
                    MimeKit.TextPart textPart = new MimeKit.TextPart("Plain");
                    textPart.Text = "メール本文";
                    string filename = "添付ファイルの名前";
                    //添付ファイルがあった時の処理
                    if (!string.IsNullOrEmpty(filename))
                    {
                        //Page.Server.MapPath(string) は 「aspx.cs」で有効
                        //ASP.NET限定「~」アプリルートを表す
                        //var filePath = Server.MapPath("~/App_Data/doc/" + filename);
                        var filePath = "/App_Data/doc/" + filename;
                        var mimeType = MimeKit.MimeTypes.GetMimeType(filePath);
                        var attachment = new MimeKit.MimePart(mimeType);
                        using (var file = File.OpenRead(filePath))
                        {
                            attachment.Content = new MimeKit.MimeContent(file);
                            attachment.ContentDisposition = new MimeKit.ContentDisposition();
                            attachment.ContentTransferEncoding = MimeKit.ContentEncoding.Base64;
                            attachment.FileName = Path.GetFileName(filePath);
                            var multipart = new MimeKit.Multipart("mixed");
                            multipart.Add(textPart);
                            multipart.Add(attachment);
                            mail.Body = multipart;
                            //メールを送信する
                            smtp.Send(mail);
                        }//using
                    }
                    else
                    {
                        var multipart = new MimeKit.Multipart("mixed");
                        multipart.Add(textPart);
                        mail.Body = multipart;
                        //メールを送信する
                        smtp.Send(mail);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                finally
                {
                    //SMTPサーバから切断する
                    smtp.Disconnect(true);
                }
            }//using
        }//MailSenderForCopy()
    }//class
}