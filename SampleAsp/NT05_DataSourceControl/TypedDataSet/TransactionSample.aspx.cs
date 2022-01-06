/**
 *@title SelfAspNet / SampleAsp / NT05_DataSourceControl
 *       / TypedDataSet / TransactionSample.aspx.cs
 *@target TransactionSample.aspx
 *@target AlbumDataSet.xsd / AlbumTableAdapter
 *@source SelfAspDB / Album
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 5.3.5 トランザクション処理 / p273 / List 5-16
 *@subject AlbumHistoryテーブルの作成
 *           -> @see SampleSql / AlbumHistory_tb.sql
 *@sublect AlbumDataSet.xsd / AlbumTableAdapter の追加
 *@subject TransactionSample.aspx.cs イベントハンドラーの追加
 *         <asp:GridView>内
 *           OnRowDeleting="" -> [新しいイベントの作成]
 *           -> OnRowDeleting="gridTransaction_RowDeleting"
 *           -> TransactionSample.gridTransaction_RowDeleting()が自動生成
 *         下記のようにコードを記述 (List 5-16)
 *         
 *@prepare 【準備】
 *          ◆自動トランザクション
 *          ＊[System.Transactions]をプロジェクトの参照に追加
 *              [VS]ソリューション -> プロジェクト 右クリック
 *              -> [追加] -> [参照] -> [アセンブリ] -> [フレームワーク]
 *              -> [System.Transactions]にチェック -> [OK]
 *          
 *          ◆分散トランザクション
 *          ＊MS-DTC: Distributed Transaction Coordinator
 *              [PC] -> [コントロールパネル] -> [システムとセキュリティ]
 *              -> [管理ツール] -> [サービス] 
 *              -> [Distributed Transaction Coordinator] 右クリック
 *              -> [開始] -> (実行中)を確認
 *              
 *@see SampleSql / AlbumHistory_tb.sql
 *@author shika
 *@date 2022-01-06
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT05_DataSourceControl.TypedDataSet
{
    public partial class TransactionSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gridTransaction_RowDeleting(
            object sender, GridViewDeleteEventArgs e)
        {
            using (var ts = new TransactionScope())
            {
                var adapter = new AlbumDataSetTableAdapters.AlbumTableAdapter();
                adapter.Delete(e.Keys["id"].ToString());
                int affected = adapter.InsertHistory(
                    e.Keys["id"].ToString(), e.Values["comment"].ToString());

                if(affected > 0)
                {
                    ts.Complete();
                }
            }//using

            e.Cancel = true;
            gridTransaction.DataBind();
        }//gridTransaction_RowDeleting()
    }//class
}

/*
//==== AlbumDataSet.xsd / AlbumDataSet.Designer.cs ====
public virtual int InsertHistory(string Id, string comment) {
    global::System.Data.SqlClient.SqlCommand command = this.CommandCollection[2];
    if ((Id == null)) {
        throw new global::System.ArgumentNullException("Id");
    }
    else {
        command.Parameters[0].Value = ((string)(Id));
    }
            
    if ((comment == null)) {
        command.Parameters[2].Value = global::System.DBNull.Value;
    }
    else {
        command.Parameters[2].Value = ((string)(comment));
    }
            
    global::System.Data.ConnectionState previousConnectionState = command.Connection.State;
    if (((command.Connection.State & global::System.Data.ConnectionState.Open) 
                != global::System.Data.ConnectionState.Open)) {
        command.Connection.Open();
    }
    int returnValue;
    try {
        returnValue = command.ExecuteNonQuery();
    }
    finally {
        if ((previousConnectionState == global::System.Data.ConnectionState.Closed)) {
            command.Connection.Close();
        }
    }
    return returnValue;
}
 */