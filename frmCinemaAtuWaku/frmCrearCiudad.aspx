<%@ Page Title="" Language="C#" MasterPageFile="~/mdiPrincipal.Master" AutoEventWireup="true" CodeBehind="frmCrearCiudad.aspx.cs" Inherits="frmCinemaAtuWaku.frmCrearCiudad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="row justify-content-center">
                    <div class="col-md-11 mt-3">
                        <div class="card">
                            <div class="header">
                                <h4 class="title">Crear Ciudad</h4>
                            </div>
                            <div class="content">
                                <form runat="server" runat="server">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Nombre Ciudad</label>
                                                <asp:TextBox runat="server" ID="txtNomCiudad" CssClass="form-control" placeholder="Ingrese Nombre Ciudad"/>  
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Ubicación Ciudad</label>
                                                <asp:TextBox runat="server" ID="txtUbicacion" CssClass="form-control" placeholder="Ingrese Ubicación de la Ciudad"/>  
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Estado</label>
                                                <asp:DropDownList runat="server" class="form-control" ID="ddlEstadoCiu">
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
