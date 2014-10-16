﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Citizens.aspx.cs" Inherits="ITCR.Application.Citizens" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ClientIDMode="Static" runat="server" ID="hidBlockUI"  Value="false"/>
    <asp:Panel runat="server" ID="pnlError" CssClass="panel-danger" Visible="false">
        <asp:Label runat="server" ID="lblError" CssClass="alert-danger"></asp:Label>
    </asp:Panel>

    <asp:GridView CssClass="table table-striped" Width="75%" runat="server" ID="CitizensGrid" CellSpacing="-1" GridLines="None"
        ItemType="ITCR.Domain.Entities.Citizen" DataKeyNames="CitizenId"
        AutoGenerateColumns="False"
        AllowPaging="True" AllowSorting="True" PageSize="20"
        SelectMethod="CitizensGridGetRows"
        DeleteMethod="CitizensGridDelete" AutoGenerateDeleteButton="True"
        OnRowCommand="CitizensGrid_OnRowCommand">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnSelectRow" runat="server" CommandArgument='<%# Eval("CitizenId") %>'
                        CommandName="CustomEdit" Text="Edit" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:DynamicField DataField="Name" />
            <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Specie" SortExpression="">
                <EditItemTemplate>
                    <asp:DropDownList runat="server" SelectMethod="GetSpeciesCombo" ID="ddlSpecie" DataValueField="SpecieId" DataTextField="Description" />
                </EditItemTemplate>
                <ItemTemplate>
                    <p><%#DataBinder.Eval(Container.DataItem, "Specie.Description")%></p>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Role" SortExpression="">
                <EditItemTemplate>
                    <asp:DropDownList runat="server" SelectMethod="GetRolesCombo" ID="ddlRole" DataValueField="RoleId" DataTextField="Description" />
                </EditItemTemplate>
                <ItemTemplate>
                    <p><%#DataBinder.Eval(Container.DataItem, "Role.Description")%></p>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Status" SortExpression="">
                <EditItemTemplate>
                    <asp:DropDownList runat="server" SelectMethod="GetStatusCombo" ID="ddlStatus" DataValueField="StatusId" DataTextField="Description" />
                </EditItemTemplate>
                <ItemTemplate>
                    <p><%#DataBinder.Eval(Container.DataItem, "Status")%></p>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            No roles found.
        </EmptyDataTemplate>
        <SortedAscendingHeaderStyle CssClass="asc" />
        <SortedDescendingHeaderStyle CssClass="desc" />
        <PagerStyle CssClass="pager" />
    </asp:GridView>
    <asp:Panel runat="server" ID="pnlAdd">
        <p><b>Add new citizen</b></p>
        <asp:TextBox runat="server" ID="txtNewName"></asp:TextBox>
        <asp:DropDownList runat="server" SelectMethod="GetSpeciesCombo" ID="ddlNewSpecie" DataValueField="SpecieId" DataTextField="Description" />
        <asp:DropDownList runat="server" SelectMethod="GetRolesCombo" ID="ddlNewRole" DataValueField="RoleId" DataTextField="Description" />
        <asp:DropDownList runat="server" SelectMethod="GetStatusCombo" ID="ddlNewStatus" DataValueField="StatusId" DataTextField="StatusId" />
        <asp:Button runat="server" ID="btnAddRole" OnClick="btnAddCitizen_Click" Text="Add Citizen" />
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlUpdate" Visible="false">
        <p><b>Update citizen</b></p>
        <asp:HiddenField runat="server" ID="hidUpdateCitizenId"/>
        <asp:TextBox runat="server" ID="txtUpdateName"></asp:TextBox>
        <asp:DropDownList runat="server" SelectMethod="GetSpeciesCombo" ID="ddlUpdateSpecie" DataValueField="SpecieId" DataTextField="Description" />
        <asp:DropDownList runat="server" SelectMethod="GetRolesCombo" ID="ddlUpdateRole" DataValueField="RoleId" DataTextField="Description" />
        <asp:DropDownList runat="server" SelectMethod="GetStatusCombo" ID="ddlUpdateStatus" DataValueField="StatusId" DataTextField="StatusId" />
        <asp:Button runat="server" ID="btnUpdateCitizen" OnClick="btnUpdateCitizen_Click" Text="Update"/>
        <asp:Button runat="server" ID="btnCancelUpdateCitizen" OnClick="btnCancelUpdateCitizen_Click" Text="Cancel"/>
        
    </asp:Panel>
    
    

</asp:Content>