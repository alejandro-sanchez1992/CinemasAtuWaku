<%@ Page Title="" Language="C#" MasterPageFile="~/mdiPrincipal.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="frmCinemaAtuWaku.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .main-panel {
            background: url(images/header-bg.jpg) no-repeat 0px 0px;
            background-size: cover;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            -ms-background-size: cover;
            background-position-x: -65px;
            min-height: 630px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="content">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-4 offset-8">
                                <div class="content-bg">
                                    <h2 class="text-center"><strong>HOLA, ¿QUÉ DESEAS HACER?</strong></h2>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
</asp:Content>
