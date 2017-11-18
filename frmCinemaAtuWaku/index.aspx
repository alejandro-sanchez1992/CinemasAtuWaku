<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="frmCinemaAtuWaku.dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="css/bootstrap/bootstrap.min.css" type="text/css" >
    <link rel="stylesheet" href="css/animate.min.css" type="text/css" >
    <link href="css/light-bootstrap-dashboard.css" rel="stylesheet"/>
    <title></title>
</head>
<body>
        <div class="wrapper">
            <div class="sidebar" data-color="red" data-image="images/fondo.jpg">
    	        <div class="sidebar-wrapper">
                    <div class="logo">
                        <a href="http://www.creative-tim.com" class="simple-text">
                            Cinemas Atu Waku
                        </a>
                    </div>

                    <ul class="nav">
                        <li class="active">
                            <a href="index.html">
                                <i class="pe-7s-graph"></i>
                                <p>Vendedor</p>
                            </a>
                        </li>
                    </ul>
    	        </div>
            </div>
            <div class="main-panel">
                <nav class="navbar navbar-default navbar-fixed">
                    <div class="container-fluid">
                        <div class="navbar-header">
                            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navigation-example-2">
                                <span class="sr-only">Toggle navigation</span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </button>
                            <a class="navbar-brand" href="#">Bienvenido al Sistema</a>
                        </div>
                        <div class="collapse navbar-collapse">
                            <ul class="nav navbar-nav navbar-right">
                                <li class="nav-item">
                                   <a href="">
                                       <p>Cuenta | Alejandro</p>
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a href="#">
                                        <p>Salir</p>
                                    </a>
                                </li>
						        <li class="separator hidden-lg"></li>
                            </ul>
                        </div>
                    </div>
                </nav>


                <div class="content">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-12">
                                <h2 class="text-center">Hola Que Deseas Hacer!!</h2>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 text-center">
                                <a href="" class="btn btn-info">Registrar Venta</a>
                                <a href="" class="btn btn-succes">Registrar Usuario</a>
                            </div>
                            <div class="col-md-6 text-center">
                                <a href="" class="btn btn-info">Productos</a>
                                <a href="" class="btn btn-info">Registrar Venta</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    <script src="js/jquery-3.1.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap/bootstrap.min.js"></script>
    <script src="js/light-bootstrap-dashboard.js"></script>
  </body>
</html>
