/*
 * @title MailKitSample / MailKitAttachmentSample.cs
 * @see MainMailKitSample.cs
 * @see Reference_MailKit / MailKit_CsharpMailSend.txt
 * 
 * @subject ＊添付ファイルを送信する
 * Mailkitで添付ファイルを送信するサンプルコードです。
 * ファイルの添付には、MimeKit.MimePartクラスを使用します。
 * 
 * (1) 添付ファイルの設定には、MimeKit.MimePartクラスを使用します。
 *     コンストラクタには、送信するファイルのMimeTypeを指定し、
 *   それ以降のプロパティで送信するフィアルの情報を設定していきます。
 *
 * (2) メールの本文と添付ファイルを合わせて送る為に、
 *     MimeKit.Multipartクラスに TextPartと MimePartを設定します。
 *
 * (3)メール本文と添付ファイルを設定したMimeKit.Multipartを、
 *    MimeKit.MimeMessageのBodyに指定して、メールを送信します。
 *
 * ファイルの拡張子に合わせたMimeTypeを設定する
 * 上で紹介したサンプルコードは、送信する添付ファイルのMimeTypeがimage/png固定で書かれおり、
 * 汎用性がありません。
 * 複数の拡張子を添付ファイルで送信する場合、
 * MimeTypeをファイルの拡張子から動的に設定する必要があります。
 *
 * MailKitには、ファイルの拡張子からMimeTypeを取得する
 * MimeKit.MimeTypes.GetMimeTypeメソッドが用意されており、
 * 以下のコードを書くことで複数の拡張子に対応可能です。
 *
 * var filePath = "image.jpg";    
 * //ファイルの拡張子からMIMEタイプを取得する
 * var mimeType = MimeKit.MimeTypes.GetMimeType(filePath);  //=> image/jpeg
 * var attachment = new  MimeKit.MimePart(mimeType);
 *
 * MimeKit.MimeTypes.GetMimeTypeメソッドが対応している拡張子は、
 * MailKitのソースコードに書かれてましたので、以下のリンクに対応している拡張子をまとめました。
 * MailKitのGetMimeTypeでMIMEタイプに変換できる拡張子一覧
 * =>〔@see Reference_MailKit / MailKit_CsharpMailSend.txt〕
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SelfAspNet.MailKitSample
{
    public class MailKitAttachmentSample
    {
        public void MailSenderAttachment()
        {
            string filePath = "image.jpg";
            string fileName = Path.GetFileName(filePath);

            string host = "<smtp server name>";
            int port = 587;

            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                smtp.Connect(host, port,
                    MailKit.Security.SecureSocketOptions.Auto);
                smtp.Authenticate("<id>", "<pass>");

                var mail = new MimeKit.MimeMessage();

                //(0)//ファイルの拡張子からMIMEタイプを取得する
                string mimeType = MimeKit.MimeTypes.GetMimeType(filePath);  //=> image/jpeg

                //(1)添付ファイルを設定
                //MimeKit.MimePart attach = new MimeKit.MimePart("image/png");
                MimeKit.MimePart attach = new MimeKit.MimePart(mimeType);

                attach.Content = new MimeKit.MimeContent(
                    File.OpenRead(filePath));
                attach.ContentDisposition = new MimeKit.ContentDisposition();
                attach.ContentTransferEncoding = MimeKit.ContentEncoding.Base64;
                attach.FileName = fileName;

                //メールの本文を設定
                MimeKit.TextPart textPart = new MimeKit.TextPart("plain");
                textPart.Text = "メール本文\n\n以上";

                //(2)Multipartオブジェクトの作成
                MimeKit.Multipart multi = new MimeKit.Multipart("mixed");
                multi.Add(textPart);
                multi.Add(attach);

                //(3)Bodyに、添付ファイルとメール本文を格納したMultipartオブジェクトを設定
                mail.Subject = "メール件名";
                mail.Body = multi;
                smtp.Send(mail);  //メールを送信
                smtp.Disconnect(true);
            }//using

        }//MailSenderAttachment()
    }//class
}