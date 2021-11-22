/**
 *@title SelfAspNet / SampleAsp /
 *@target
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content
 *@subject
 *
 *@author shika
 *@date
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfAspNet.Models
{
    public class DocTemplate
    {
        //static void Main(string[] args)
        public void Main(string[] args)
        {
            //new CsharpBegin.Utility.FileDocumentDiv.FileDocExecute().ReadWriteExe();
        }//Main()
    }//class
}

/*
【考察】SelfAspNet -> CsharpBegin参照
クラスそのものは参照可だが、static Main()で実行しても、
CsharpBegin内には static Main()がないため、ビルドエラーとなる。

 */