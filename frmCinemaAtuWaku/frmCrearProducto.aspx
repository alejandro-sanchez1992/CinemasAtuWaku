<%@ Page Title="" Language="C#" MasterPageFile="~/mdiPrincipal.Master" AutoEventWireup="true" CodeBehind="frmCrearProducto.aspx.cs" Inherits="frmCinemaAtuWaku.frmCrearProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="row justify-content-center">
                    <div class="col-md-11 mt-3">
                        <div class="card">
                            <div class="header">
                                <h4 class="title">Crear Nuevo Producto</h4>
                            </div>
                            <div class="content">
                                <form runat="server" runat="server">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Seleccione Proveedor</label>
                                                <asp:DropDownList runat="server" class="form-control" ID="ddlProveedor">
                                                    <asp:ListItem Text="Postobon" />
                                                    <asp:ListItem Text="Colombina" />
                                                </asp:DropDownList> 
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Nombre del Producto</label>
                                                <asp:TextBox runat="server" ID="txtNomProduct" CssClass="form-control" placeholder="Nombre Producto"/> 
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Descripción Producto</label>
                                                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" placeholder="Descripción Producto" TextMode="MultiLine" Height="85" /> 
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Valor Producto</label>
                                                <asp:TextBox runat="server" ID="txtValor" CssClass="form-control" placeholder="Valor Producto"/> 
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Cantidad Producto</label>
                                                <asp:TextBox runat="server" ID="txtCantProduct" CssClass="form-control" placeholder="Cantidad Producto"/> 
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Estado Producto</label>
                                                <asp:DropDownList runat="server" class="form-control" ID="ddlEstadoProduct">
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
