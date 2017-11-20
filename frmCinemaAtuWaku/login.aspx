<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="frmCinemaAtuWaku.dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <title></title>
</head>
<body>
 <div class="wrapper">
	<div class="container">
		<div class="items">
			<h1>Bienvenido al Sistema</h1>
			<h2>CINEMAS ATU WAKU</h2>
			
			<form class="form" method="post" runat="server">
                <asp:TextBox runat="server" ID="txtUsuario" CssClass="" placeholder="Usuario"/>  
                <asp:TextBox runat="server" ID="txtPassword" Visible="True" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                <asp:Button ID="btnLoginButton" runat="server" Text="Entrar" />
			</form>
		</div>
	</div>
	
	<ul class="bg-bubbles">
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
	</ul>
</div>
 
    <script src="js/jquery-3.1.1.min.js"></script>
    <script  src="js/index.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>

</body>
</html>
