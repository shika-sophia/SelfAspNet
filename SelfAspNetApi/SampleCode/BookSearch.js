/*
 *@see SampleCode / ClientCallJs.aspx.cs
 * 
 */

$(function () {
    $('#btnSearch').click(function () {
        $.getJSON(`api/book/${$('#txtIsbn').val()}`,
            function (data) {
                let htmlText =
                    `<li>ISBN: ${data.isbn}</li>
                    <li>TITLE: ${data.title}</li>
                    <li>PRICE: ${data.price}</li>
                    <li>PUBLISHER: ${data.publisher}</li>
                    <li>PUBLISH DATE: ${data.publishDate}</li>
                    <li>CD-ROM: ${data.cdrom}</li>`;
                $('#result').html(htmlText);
            }//function(data)
        );//$.getJSON()
    });//$('#btnSearch').click()
});