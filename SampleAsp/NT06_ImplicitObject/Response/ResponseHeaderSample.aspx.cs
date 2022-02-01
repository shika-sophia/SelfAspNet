/**
 *@title SelfAspNet / SampleAsp / NT06_ImplicitObject
 *       / Response / ResponseHeaderSample.aspx.cs
 *@target ResponseHeaderSample.aspx
 *@source SelfAspDB / Book
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第６章 6.2 Response / p321 / List 6.9
 *@subject ResponseHeaderを自己定義
 *         void Response.AppendHeader(string key, string value)
 *           //HTTP Headerを出力ストリームに追加
 *           
 *@subject 「.aspx」ASPページ
 *          <%@ Page ... 
 *             ContentType="application/octet-stream"
 *               バイナリーストリームを output? 実行結果は下記。
 *             ResponseEncoding="Shift-JIS" %>
 *             
 *          ResponseEncoding="": デフォルト値 UTF-8だが、Excelには Shift-JISが適す。
 *          CSV変換のため、空白、改行に意味を持つため、削除。
 *          HTMLタグは不要なので、<DOCTYPE><head><body><form>なども削除。
 *          
 *@subject 「.aspx.cs」Page_Load()
 *          Response.AppendHeader(
 *              "Content-Disposition", "attachment;filename=Book.csv");
 *              
 *         文字列にスペルミスがあっても、エラーは出ず、
 *         「ResponseHeaderSample.aspx」(Textのみ)同名のファイルを自動ダウンロード
 *         「ResponseHeaderSample_CSV.aspx」に改名
 *         正しく書くと、「Book.csv」を自動ダウンロード。
 *         
 *@result  ◆実行結果
 *         テキストの記述と異なり、確認画面は出ず、自動でダウンロード
 *         CSV形式の「Book.csv」
 *         ファイルを開くと自動で Excel起動、ファイルは消滅。
 *                       
 *@see Book_csv.jpg 
 *     (開くと消滅, VSフォルダ内に入っていることを見るだけ)
 *@see ResponseHeaderSample_CSV.aspx 
 *     (上記ファイルの内容はこちら、
 *      おそらく本来はバイナリーファイルだが、テキストエディタで開くと文字列化）
 *     
 *@author shika
 *@date 2022-02-01
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT06_ImplicitObject.Response
{
    public partial class ResponseHeaderSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AppendHeader(
                "Content-Disposition", "attachment;filename=Book.csv");
        }
    }//class
}