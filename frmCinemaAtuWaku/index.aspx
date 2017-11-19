<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="frmCinemaAtuWaku.dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="css/bootstrap/bootstrap.min.css" type="text/css" >
    <link rel="stylesheet" href="css/animate.min.css" type="text/css" >
    <link href="css/light-bootstrap-dashboard.css" rel="stylesheet"/>
    <link href="css/custom-styles.css" rel="stylesheet"/>
    <title></title>
</head>
<body>
        <div class="wrapper">
            <div class="sidebar" data-color="red" data-image="images/fondo.jpg">
    	        <div class="sidebar-wrapper">
                    <div class="logo">
                        <a href="#" class="simple-text">
                            <img class="img-fluid" src="images/logo.png" />
                        </a>
                    </div>

                    <ul class="nav menu">
                        <li class="active">
                            <a href="#">
                                <p class="text-center">Vendedor</p>
                            </a>
                            <ul class="nav submenu">
                                <li>
                                    <a href="#">content</a>
                                </li>
                                <li>
                                    <a href="#">content</a>
                                </li>
                                <li>
                                    <a href="#">content</a>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a href="#">
                                <p class="text-center">Vendedor</p>
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <p class="text-center">Vendedor</p>
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
                        <div class="">
                            <ul class="nav navbar-nav navbar-right float-right">
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
                            <div class="col-md-5 offset-7">
                                <div class="content-bg">
                                    <h2 class="text-center"><strong>HOLA, ¿QUÉ DESEAS HACER?</strong></h2>
                                </div>
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
    <script src="js/custom.js"></script>
  </body>
</html>
