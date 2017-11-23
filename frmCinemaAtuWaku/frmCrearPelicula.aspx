<%@ Page Title="" Language="C#" MasterPageFile="~/mdiPrincipal.Master" AutoEventWireup="true" CodeBehind="frmCrearPelicula.aspx.cs" Inherits="frmCinemaAtuWaku.frmCrearPelicula" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="row justify-content-center">
                    <div class="col-md-11 mt-3">
                        <div class="card">
                            <div class="header">
                                <h4 class="title">Crear Nueva Pelicula</h4>
                            </div>
                            <div class="content">
                                <form runat="server" runat="server">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Titulo Pelicula</label>
                                                <asp:TextBox runat="server" ID="txtPelicula" CssClass="form-control" placeholder="Titulo Pelicula"/>  
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Descripción Pelicula</label>
                                                <asp:TextBox runat="server" ID="txtDescripcionPel" CssClass="form-control" placeholder="Descripción Pelicula" TextMode="MultiLine" Height="85" /> 
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Idioma Pelicula</label>
                                                <asp:TextBox runat="server" ID="txtIdiomaPel" CssClass="form-control" placeholder="Idioma Pelicula"/> 
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Duración Pelicula</label>
                                                <asp:TextBox runat="server" ID="txtDuraciónPel" CssClass="form-control" placeholder="Duración Pelicula"/> 
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Estado Pelicula</label>
                                                <asp:DropDownList runat="server" class="form-control" ID="ddlEstadPel">
                                                    <asp:ListItem Text="Activo" />
                                                    <asp:ListItem Text="Inactivo" />
                                                </asp:DropDownList> 
                                            </div>
                                        </div>
                                    </div>

                                    <asp:Button Text="Enviar Datos" runat="server" cssClass="btn btn-info btn-fill pull-right"/>
                                    <div class="clearfix"></div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
</asp:Content>
