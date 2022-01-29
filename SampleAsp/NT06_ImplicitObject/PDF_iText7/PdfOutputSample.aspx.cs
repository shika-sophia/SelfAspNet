/**
 *@title SelfAspNet / SampleAsp / NT06_ImplicitObject
 *       / PDF_iText7 / PdfOutputSample.aspx.cs
 *@target PdfOutputSample.aspx
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content Chapter6 Implicit Object / 6.2 Response
 *         / 6.2.3 Output Binary Data // p.315 / List 6-7
 *prepare Install iText7
 *        [VS] -> [MENU] -> [Tools] -> [NuGet Package Manager] -> [Console]
 *        PM> Install-Package itext7
 *        => @see InstallPackage_iText7.txt
 *        
 *@subject 「.aspx.cs」 Event Handler
 *         ◆iText7 Library [Lite]
 *         new Document(PdfDocument)
 *           └ new PdfDocument(PdfWriter)
 *              └ new PdfWriter(System.IO.Stream)
 *         
 *         PdfFont PdfFontFactory.CreateTtcFont(
 *             string ttcPath, //@"C:\Windows\Fonts\msgothic.ttc"
 *             int ttcIndex,   //index of purpose font in same file above.
 *             PdfEncodings,   //PdfEncodings.IDENTITY_H / IDENTITY_V 
 *                               as letter direction is horizontal / virtical.
 *             PdfFontFactory.EmbeddingStrategy,
 *             bool cache)
 *             
 *         Document document.SetFont(PdfFont)
 *         Document document.Add(IBlockElement)
 *         void     document.Close()
 *         
 *         new Paragraph(string text)
 *         new Text(string text)
 *         Paragraph paragraph.Add(ILeafElement)
 *         Text text.SetFont(PdfFont)
 *         Text text.SetFontSize(float)
 *         Text text.SetColor(Color)
 *         
 *@subject 「.aspx」 Asp Page
 *          ＊use when static fixed 
 *          <%@ Page ... ContentType="application/pdf" %>
 *                                       
 *          ＊use when dynamic variable
 *          Response.CintentType(string) 
 *
 *@see PdfOutputSample.jpg
 *@author shika
 *@date 2022-01-29
 */

using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT06_ImplicitObject.PDF_iText7
{
    public partial class PdfOutputSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //---- create new PDF Document ----
            Document doc = new Document(
                new PdfDocument(
                    new PdfWriter(Response.OutputStream)
                )
            );

            //---- define font ----
            PdfFont font = PdfFontFactory.CreateTtcFont(
                @"C:\Windows\Fonts\msgothic.ttc",
                ttcIndex: 1,
                PdfEncodings.IDENTITY_H, 
                PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED,
                cached: true);
            doc.SetFont(font);

            //---- add Document to Paragaph and Text ----
            doc.Add(
                new Paragraph("Hello ")
                .Add(new Text("World!").SetFontSize(20))
             );

            //---- closing ----
            doc.Close();
            Response.End();
        }//Page_Load()
    }//class
}