/*
 * @subject ＊文字エンコーディングを指定してメールを送信
 * @see MainMailKitSample.cs
 * @see Reference_MailKit / MailKitCsharpSend.txt
 * 
 (1) の所で件名を、エンコーディング指定で設定しています。
注意すべきは、Headers.Addではなく、Headers.Replaceでヘッダを置換している所です。
MimeMessageクラスはインスタンスを作成する時点で、件名(Subjectヘッダ)が作成される為、
置換して内容を書き換えます。
※ Headers.Addを使ってしまうと、２重に Subjectヘッダが作成されてしまいます。

(2) では、本文を作成しています。
TextPartクラスに本文の内容を、エンコーディング指定で設定します。
また、"iso-2022-jp"の JISコードで送る為、ContentTransferEncodingに7bitを設定しています。

ネットを検索しても、MailKitで件名のエンコーディングを指定する方法が見つからず、正直苦労しました。
結局 MimeKitのソースを解析して、上のコードで送信出来ることが分かりました。
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SelfAspNet.MailKitSample
{
    public class MailKitEncodingSample
    {
        public void MailSenderEncoding()
        {
            string host = "<smtp server name>";
            int port = 587;
            Encoding enc = Encoding.GetEncoding("iso-2022-jp");

            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                smtp.Connect(host, port,
                    MailKit.Security.SecureSocketOptions.Auto);
                smtp.Authenticate("<id>", "<pass>");

                var mail = new MimeKit.MimeMessage();
                mail.From.Add(
                    new MimeKit.MailboxAddress("<formName>", "<fromAddress>"));
                mail.To.Add(
                    new MimeKit.MailboxAddress("<toName>", "<toAddress>"));

                //(1)エンコーディング指定で、件名を設定 (Headers.Replaceで既存のヘッダを置換するのがミソ)
                mail.Headers.Replace(MimeKit.HeaderId.Subject, enc, "メールの件名");

                //(2)本文もエンコーディング指定で設定
                MimeKit.TextPart textPart = new MimeKit.TextPart("plain");
                textPart.SetText(enc, "メールの本文です。\n\n以上");
                // "iso-2022-jp"で送るので、"Content-Transfer-Encoding"に"7bit"を指定
                textPart.ContentTransferEncoding = MimeKit.ContentEncoding.SevenBit;
                mail.Body = textPart;

                smtp.Send(mail);
                smtp.Disconnect(true);
            }//using
        }//MailSenderEncoding()
    }//class
}