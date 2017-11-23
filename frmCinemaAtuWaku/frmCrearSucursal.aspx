<%@ Page Title="" Language="C#" MasterPageFile="~/mdiPrincipal.Master" AutoEventWireup="true" CodeBehind="frmCrearSucursal.aspx.cs" Inherits="frmCinemaAtuWaku.frmCrearSucursal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="row justify-content-center">
                    <div class="col-md-11 mt-3">
                        <div class="card">
                            <div class="header">
                                <h4 class="title">Crear Nueva Sucursal</h4>
                            </div>
                            <div class="content">
                                <form runat="server" runat="server">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Nombre Sucursal</label>
                                                <asp:TextBox runat="server" ID="txtNomSucursal" CssClass="form-control" placeholder="Ingrese Nombre Sucursal"/>  
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Seleccione Ciudad</label>
                                                <asp:DropDownList runat="server" class="form-control" ID="ddlCiudad">
                                                    <asp:ListItem Text="Medellin" />
                                                    <asp:ListItem Text="Bogota" />
                                                    <asp:ListItem Text="Cali" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Dirección</label>
                                                <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control" placeholder="Ingrese Dirección"/> 
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Teléfono Sucursal</label>
                                                <asp:TextBox runat="server" ID="txtTelSucursal" CssClass="form-control" placeholder="Teléfono Sucursal"/> 
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Correo Eletronico Sucursal</label>
                                                <asp:TextBox runat="server" ID="txtSucurEmail" CssClass="form-control" placeholder="Ingrese Correo"/> 
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
