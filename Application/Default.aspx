<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ITCR.Application._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-4">
            <h2>Manage Citizens</h2>
            <p>See the Citizen list, update their data, create and or delete new Citizen records.
            </p>
            <p>
                <a class="btn btn-default" href="/Citizens">Go now &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Manage Roles</h2>
            <p>
                Add, change or delete Citizen Roles
            </p>
            <p>
                <a class="btn btn-default" href="/Roles">Go now &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Manage Species</h2>
            <p>
                Maintain the database of known species to be able to assign them to your citizens
            </p>
            <p>
                <a class="btn btn-default" href="/Species">Go now &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
