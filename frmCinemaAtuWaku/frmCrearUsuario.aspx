<%@ Page Title="" Language="C#" MasterPageFile="~/mdiPrincipal.Master" AutoEventWireup="true" CodeBehind="frmCrearUsuario.aspx.cs" Inherits="frmCinemaAtuWaku.frmCrearUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="row justify-content-center">
                    <div class="col-md-11 mt-3">
                        <div class="card">
                            <div class="header">
                                <h4 class="title">Crear Nuevo Usuario</h4>
                            </div>
                            <div class="content">
                                <form runat="server" runat="server">
                                    <div class="row">
                                        <div class="col-md-5">
                                            <div class="form-group">
                                                <label>Número de Documento</label>
                                                <asp:TextBox runat="server" ID="txtDocumento" CssClass="form-control" placeholder="Ingrese documento"/>  
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label>Tipo de Usuario</label>
                                                <asp:DropDownList runat="server" class="form-control" ID="ddlTipoUSuario">
                                                    <asp:ListItem Text="Administrador" />
                                                    <asp:ListItem Text="Vendedor" />
                                                    <asp:ListItem Text="Cliente" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label>Corro Electronico</label>
                                                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Correo"/>  
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Nombre</label>
                                                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" placeholder="Ingrese su nombre"/> 
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Apellido</label>
                                                <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" placeholder="Ingrese su Apellido"/> 
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
                                        <%if (this.ddlTipoUSuario.SelectedIndex == 1)
                                            { %>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Contraseña</label>
                                                <asp:TextBox runat="server" ID="txtPassword1" CssClass="form-control" placeholder="Ingrese Contraseña"/> 
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Confirmar Contraseña</label>
                                                <asp:TextBox runat="server" ID="txtPassword2" CssClass="form-control" placeholder="Confirmar Contraseña"/> 
                                            </div>
                                        </div>
                                        <% } %>                                       
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Teléfono / Celular</label>
                                                <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" placeholder="Ingrese N° Teléfono"/> 
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Estado Usuario</label>
                                                <asp:DropDownList runat="server" class="form-control" ID="ddlEstado">
                                                    <asp:ListItem Text="Activo" />
                                                    <asp:ListItem Text="Inactivo" />
                                                    <asp:ListItem Text="Cliente" />
                                                </asp:DropDownList>
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
                                    <asp:Button ID="btnEnviarUsuario" Text="Enviar Datos" runat="server" cssClass="btn btn-info btn-fill pull-right" OnClick="btnEnviarUsuario_Click" />
                                    <div class="clearfix"></div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
</asp:Content>
