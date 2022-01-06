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