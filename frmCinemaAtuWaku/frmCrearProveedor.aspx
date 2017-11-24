<%@ Page Title="" Language="C#" MasterPageFile="~/mdiPrincipal.Master" AutoEventWireup="true" CodeBehind="frmCrearProveedor.aspx.cs" Inherits="frmCinemaAtuWaku.frmCrearProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="row justify-content-center">
                    <div class="col-md-11 mt-3">
                        <div class="card">
                            <div class="header">
                                <h4 class="title">Crear Proveedor</h4>
                            </div>
                            <div class="content">
                                <form runat="server" runat="server">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Proveedor / Empresa</label>
                                                <asp:TextBox runat="server" ID="txtProveedor" CssClass="form-control" placeholder="Ingrese Proveedor"/>  
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Teléfono Proveedor</label>
                                                <asp:TextBox runat="server" ID="txtTelProveedor" CssClass="form-control" placeholder="Ingrese Teléfono Proveedor"/> 
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Correo Eletronico Proveedor</label>
                                                <asp:TextBox runat="server" ID="txtEmailProveedor" CssClass="form-control" placeholder="Ingrese Correo Proveedor"/>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-8">
                                            <div class="form-group">
                                                <asp:Label ID="lblMensaje" runat="server" Visible="false" CssClass="p-2 mb-2 mt-2 bg-info text-white rounded"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:Button ID="btnEnviarProvee" Text="Enviar Datos" runat="server" cssClass="btn btn-info btn-fill pull-right" OnClick="btnEnviarProvee_Click" />
                                    <asp:Button Text="Limpiar Campos" runat="server" cssClass="btn btn-default btn-fill pull-right mr-3"/>
                                    <div class="clearfix"></div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
</asp:Content>
