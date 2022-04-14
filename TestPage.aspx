<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="Recruiting_API.TestPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <input type="button" value="Download Word File" onclick="DownloadFile('Sample.docx')" />
    <input type="button" value="Download Excel File" onclick="DownloadFile('Sample.xlsx')" />
    <input type="button" value="Download PDF File" onclick="DownloadFile('Resume_yoga.pdf')" />

<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    function DownloadFile(fileName) {
        $.ajax({
            type: "POST",
            url: "TestPage.aspx/DownloadFile",
            data: '{fileName: "' + fileName + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                //Convert Base64 string to Byte Array.
                var bytes = Base64ToBytes(r.d);
 
                //Convert Byte Array to BLOB.
                var blob = new Blob([bytes], { type: "application/octetstream" });
 
                //Check the Browser type and download the File.
                var isIE = false || !!document.documentMode;
                if (isIE) {
                    window.navigator.msSaveBlob(blob, fileName);
                } else {
                    var url = window.URL || window.webkitURL;
                    link = url.createObjectURL(blob);
                    var a = $("<a />");
                    a.attr("download", fileName);
                    a.attr("href", link);
                    $("body").append(a);
                    a[0].click();
                    $("body").remove(a);
                }
            }
        });
    };
    function Base64ToBytes(base64) {
        var s = window.atob(base64);
        var bytes = new Uint8Array(s.length);
        for (var i = 0; i < s.length; i++) {
            bytes[i] = s.charCodeAt(i);
        }
        return bytes;
    };
</script>
</asp:Content>
