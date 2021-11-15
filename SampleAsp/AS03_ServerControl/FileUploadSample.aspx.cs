/**
 * @title SelfAspNet / SampleAsp / AS03_ServerControl / FileUploadSample.aspx.cs
 * @reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 * @content 第３章 FileUploadControl / p86 / List 3-3, 3-4
 * @parameter FileUpload upload = //FileUploadControl ID//;
 *            HttpPostedFile postFile = upload.PostedFile;
 *            
 * @subject One File Uploaded       / 単一ファイルのアップロード
 * @subject Multiple Files Uploaded / 複数ファイルのアップロード
 *          ◆System.Web.FileUpload
 *          bool upload.HasFile ファイルを入力したか
 *          HttpPostedFile        upload.PostedFile;
 *          IList<HttpPostedFile> upload.PostedFiles;
 *          void upload.SaveAs(string path); //保存
 *          
 *          ◆System.Web.HttpServerUtility Page.Server
 *          「~」チルダ: Application Rootを表す予約語
 *          string Page.Server.MapPath(path) 引数 pathを絶対パス(物理パス)に変換
 *          
 *          ◆System.Web.HttpPostedFile postFile
 *          string postFile.FileName;
 *          
 *          ◆System.IO.Path
 *          string Path.GetFileName(string path) ファイル名を取得 (拡張子は含まず)
 * 
 * @result ---- Result Image ----
 * @see ResultFile / FileUploadSample_Chrome.jpg
 * @see ResultFile / FileUploadSample_VS.jpg
 * @see ResultFile / FileUploadSample_selected.jpg
 * @see ResultFile / FileUploadSample_uploaded.jpg
 * 
 * @author shika
 * @date 2021-11-16
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.AS03_ServerControl
{
    public partial class FileUploadSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtFileUp_Click(object sender, EventArgs e)
        {
            //---- save directory ----
            //string dir = $"~/App_Data/image/";
            string dir = $"~/SampleAsp/ResultFile/";

            if (upload.HasFile)
            {
                //---- One File Uploaded ----
                if(upload.PostedFiles.Count == 1)
                {
                    HttpPostedFile postFile = upload.PostedFile;
                    string path = Server.MapPath(
                        $"{dir}{Path.GetFileName(postFile.FileName)}");
                    postFile.SaveAs(path);

                    LbFileUp.Text = $"[{postFile.FileName}] Uploaded.";
                }

                //---- Multiple Files Uploaded ----
                else
                {
                    var bld = new StringBuilder();
                    IList<HttpPostedFile> uploadList = upload.PostedFiles;

                    foreach(HttpPostedFile f in uploadList)
                    {
                        string path = Server.MapPath(
                            $"{dir}{Path.GetFileName(f.FileName)}");
                        f.SaveAs(path);

                        bld.Append($"{f.FileName}<br />");
                    }//foreach

                    LbFileUp.Text = $"{ bld.ToString() }";
                }
            }//if HasFile

        }//BtFileUp_Click()
    }//class
}

/*
【考察】FileUploadControl
@see ResultFile / FileUploadSample_atChrome.jpg
@see ResultFile / FileUploadSample_VS.jpg

VSデザインViewだとTextBoxが表示されるが
Google Chrome / MS Edgeだと 参照ボタンのみで、
「参照」の文字はなく「ファイルを選択」となる。

 */