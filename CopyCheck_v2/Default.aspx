<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CopyCheck_v2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <style type="text/css">
         .auto-style1 {
            width: 500px;
            height: 300px;
            margin-right: 0px;
         }

         body {
            background-image: url('bg-2.png');
         }

         .auto-style2 {
            width: 100px;
            height: 20px;
            margin-right: 0px;
            font-size:larger;
         }

         .auto-style3 {
             width: 200px;
            height: 30px;
            margin-right: 0px;
            font-size:larger;
            font-weight: bold;
         }

         .gif-style {
             display: inline-block;
             float: right;
             vertical-align: top;
             position: relative;
             bottom: -100px;
         }

         .standard-style {
             font-style:oblique;
             font-size:larger;
         }

         .radiolist-style {
             position: relative;
             right: -500px;
             top: -70px;
             margin: 30px 30px;
             padding-bottom: 0px;
         }

    </style>

        <div class="jumbotron" style="background-color: aquamarine">
            <h1>CopyCheck</h1>
            <p class="lead">Anti-Plagiarism.</p>
            <asp:Image runat="server" class="gif-style" ImageUrl="~/Plagiarism.gif"></asp:Image>
        </div>
    
    <div class="form-group">
        <textarea class="auto-style1" rows="5" cols="15" id="text_source" style="resize: none;" placeholder="Please enter your text and press Check Plagiarism&nbsp;" runat="server"></textarea>
        <p>1000 words limit per search</p>
    </div>

    <div class="form-group"><br/><br/>
        <p class="standard-style">Or upload file (.txt, .doc, .docx, .pdf)</p>
        <input id="file1" type="file" accept=".docx,.doc,.txt,.pdf" runat="server"/>
    </div>

    <div class="radiolist-style">
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" class="radio">
        <asp:ListItem Value ="1">Text</asp:ListItem>
        <asp:ListItem Value ="2">File</asp:ListItem>
        </asp:RadioButtonList>
    </div>

    <hr/>
    <p class="standard-style">Against</p>
    <hr/>

    <br/>
    <div class="form-group" >
        <p class="standard-style">Upload File (.txt, .doc, .docx, .pdf)</p>
        <input id="file2" type="file" accept=".docx,.doc,.txt,.pdf" runat="server" multiple/>
    </div>

    <hr/>
    <div class="form-group">
        <br/>
        <asp:Button ID="CheckButton" CssClass="auto-style3" runat="server" Text="Jaccard" OnClick="CheckButton_Click" />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="CheckButton2" CssClass="auto-style3" runat="server" Text="Cosine Similarity" OnClick="CheckButton2_Click"/>

        <br/>
        <hr/>

        <div>
            <p class="standard-style">Result</p>
            <p>
                <asp:TextBox ID="Result" class="auto-style2" runat="server" ReadOnly="True"></asp:TextBox>
            </p>

        </div>
     </div>
</asp:Content>
