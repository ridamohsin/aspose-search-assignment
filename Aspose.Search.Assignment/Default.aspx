<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Aspose.Search.Assignment._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" id="SearchInterface">
        <h1 class="lead margin-top-10">Perform Different types of Search</h1>
        <div class="panel panel-default">
            <div class="panel-body">
            <%--<form runat="server" class="form-inline">--%>
            <div class="form-group">
                <div class="col-md-3">
                    <asp:TextBox ID="SearchTerm1TextBox" CssClass="form-control search-term" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredSearchFieldValidator" runat="server" CssClass="required-second-term"
                        ControlToValidate="SearchTerm1TextBox"
                        ErrorMessage="Required. Please Enter the term to search."
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="BooleanStringValidator"
                        runat="server" ControlToValidate="SearchTerm1TextBox"
                        ErrorMessage="Not a boolean expression"
                        ForeColor="Red"
                        ClientValidationFunction="validateBoolean" Display="Dynamic"></asp:CustomValidator>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="SearchTerm2TextBox" CssClass="form-control search-term second-term" Visible="false" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredSearchField2Validator" runat="server"
                        ControlToValidate="SearchTerm2TextBox"
                        Visible="false"
                        ErrorMessage="Required. Please Enter the term to search."
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="BooleanStringValidator2"
                        runat="server" ControlToValidate="SearchTerm2TextBox"
                        ErrorMessage="Not a boolean expression"
                        ForeColor="Red"
                        ClientValidationFunction="validateBoolean"></asp:CustomValidator>
                 
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="SearchTypeDropDownList" CssClass="form-control searchtype-list" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SearchTypeChanged">
                    </asp:DropDownList>
                </div>
            </div>
            <p style="clear:both;"></p>
            <asp:Button ID="SearchSubmitButton" class="btn btn-primary" runat="server" Text="Search" OnClick="SearchSubmitButton_Click" />

            <%--</form>--%>
        </div>
            </div>
        <p style="clear:both;"></p>
        <div class="panel panel-default">
            <asp:ListView ID="ResultsListView" runat="server">
                <LayoutTemplate>
                    <table id="DocumentsRecords" class="table table-bordered table-hover" runat="server">
                        <thead class="thead-inverse">
                            <tr id="HeaderRow" runat="server">
                                <th id="searchTermHeader" runat="server">Searched Term</th>
                                <th id="fileNameHeader" runat="server">File Name</th>
                                <th id="hitCountHeader" runat="server">Hit Count</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr id="ItemPlaceholder" runat="server">
                            </tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Aspose.Search.Assignment.Helpers.UIBasedUtility.DisplayFileName((string) Eval("SearchTerm")) %></td>
                        <td><%# Aspose.Search.Assignment.Helpers.UIBasedUtility.DisplayFileName((string) Eval("FileName")) %></td>
                        <td><%# Aspose.Search.Assignment.Helpers.UIBasedUtility.DisplayHitCount((int) Eval("HitCount"))%></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <table class="emptyTable">
                        <tr>
                            <td>
                                <h1>No records available.</h1>
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
        </div>

    </div>
    <script src="Custom.js"></script>
</asp:Content>
