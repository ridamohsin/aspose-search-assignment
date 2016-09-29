<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Aspose.Search.Assignment._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <asp:TextBox ID="SearchKeyWordTextBox" runat="server"></asp:TextBox>
        
        <asp:DropDownList ID="SearchTypeDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SearchTypeChanged">
        </asp:DropDownList>
        
    <asp:Button ID="SearchSubmitButton" runat="server" Text="Search" OnClick="SearchSubmitButton_Click" />
        
    </div>
    <div class="panel panel-default">
       <asp:ListView ID="ResultsListView" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("FileName")%></td>
                            <td><%# Eval("HitCount")%></td>
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table id="tbl1" runat="server">
                            <tr id="tr1" runat="server">
                                <td id="td1" runat="server">FileName</td>
                                <td id="td2" runat="server">HitCount</td>
                            </tr>
                            <tr id="ItemPlaceholder" runat="server">  
                            </tr>
                        </table>
                    </LayoutTemplate>
                </asp:ListView>
    </div>
    

</asp:Content>
