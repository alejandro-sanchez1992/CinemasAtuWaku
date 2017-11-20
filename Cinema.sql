create database DB_Cinemas_Atu_Waku;

use DB_Cinemas_Atu_Waku;

create table TBL_Estados
(
id_estado int NOT NULL IDENTITY(1,1),
estado varchar(50),
CONSTRAINT PK_Estados PRIMARY KEY (id_estado),
);

create table TBL_Ciudad
(
id_ciudad int NOT NULL IDENTITY(1,1),
nombre_ciudad varchar(30),
ubicacion varchar (50),
id_estado int,
CONSTRAINT PK_Ciudad PRIMARY KEY (id_ciudad),
CONSTRAINT FK_Estado_Ciudad FOREIGN KEY(id_estado) REFERENCES TBL_Estados(id_estado)
);

create table TBL_Sucursal
(
	id_sucursal int NOT NULL IDENTITY(1,1),
	nombre_sucursal varchar(50),
	id_ciudad int,
	direccion_sucursal varchar(80),
	telefono_sucursal varchar(15),
	email_sucursal varchar(80),
	CONSTRAINT PK_Sucursal PRIMARY KEY (id_sucursal),
	CONSTRAINT FK_CiudadSucur FOREIGN KEY (id_ciudad) REFERENCES TBL_Ciudad(id_ciudad)
);

create table TBL_Proveedor
(
id_proveedor int NOT NULL IDENTITY(1,1),
nombre_empresa varchar (50),
telefono varchar (30),
email varchar (100),
CONSTRAINT PK_Proveedor PRIMARY KEY (id_proveedor)
);

create table TBL_Producto
(
	id_prodct int NOT NULL IDENTITY(1,1),
	id_proveedor int,
	nombre_prodct varchar(50),
	descripcion_prodct varchar(100),
	valor_prodct float,
	cantidad_product  int,
	id_estado int,
	CONSTRAINT PK_Producto PRIMARY KEY (id_prodct),
	CONSTRAINT FK_ProdctProveedor FOREIGN KEY (id_proveedor) REFERENCES TBL_Proveedor(id_proveedor),
	CONSTRAINT FK_Est_Product FOREIGN KEY(id_estado) REFERENCES TBL_Estados(id_estado)
);

create table TBL_Peliculas
(
	id_pelicula int NOT NULL IDENTITY(1,1),
	tituloPeli  varchar (30),
	descripcion_pelicula varchar(15),
	idioma_pelicula varchar(15),
	director_pelicula varchar(30),
	duracion_pelicula int,
	id_estado int,
	CONSTRAINT PK_Pelicula PRIMARY KEY (id_pelicula),
	CONSTRAINT FK_Estado_Pelicula FOREIGN KEY(id_estado) REFERENCES TBL_Estados(id_estado)
);

create table TBL_TipoUsuario
(
	id_TipoUsuario int NOT NULL IDENTITY(1,1),
	NombreUsuario varchar(30),
	CONSTRAINT PK_TipoUsuario PRIMARY KEY (id_TipoUsuario)
);

CREATE TABLE TBL_Usuarios
(
	cedula int,
	nombre varchar (50),
	apellido varchar(50),
	email varchar (100),
	direccion varchar(100),
	telefono varchar(100),
	id_tipoUsuario int,
	user_password varchar(20),
	id_estado int,
	CONSTRAINT PK_Usuario PRIMARY KEY (cedula),
	CONSTRAINT FK_Tp_Usuarios FOREIGN KEY (id_tipoUsuario) REFERENCES TBL_TipoUsuario (id_TipoUsuario),
	CONSTRAINT FK_Estado_User FOREIGN KEY (id_estado) REFERENCES TBL_Estados(id_estado)
);

create table TBL_detalle_Fact
(
	id_detalle int NOT NULL IDENTITY(1,1),
	id_prodct int,
	id_pelicula int,
	cantidad_prodct int,
	descripcion varchar(100),
	precio float,
	subtotal float,
	CONSTRAINT PK_Detalle PRIMARY KEY (id_detalle),
	CONSTRAINT FK_Detalle_Pelic FOREIGN KEY (id_pelicula) REFERENCES TBL_Peliculas(id_pelicula),
	CONSTRAINT FK_Detalle_Prod FOREIGN KEY (id_prodct) REFERENCES TBL_Producto(id_prodct),
);

create table TBL_Factura 
(
	id_factura int NOT NULL IDENTITY(1,1),
	id_detalle int,
	cedula_vendedor int,
	fechaFactura date,
	cedula_cliente int,
	metodo_pago varchar(30),
	iva float,
	total float,
	id_estado int,
	CONSTRAINT PK_Factura PRIMARY KEY (id_factura),
	CONSTRAINT FK_Detalle_Factura FOREIGN KEY (id_detalle) REFERENCES TBL_detalle_Fact(id_detalle),
	CONSTRAINT FK_Vend_Fact FOREIGN KEY (cedula_vendedor) REFERENCES TBL_Usuarios(cedula),
	CONSTRAINT FK_Client_Fact FOREIGN KEY (cedula_cliente) REFERENCES TBL_Usuarios(cedula),
	CONSTRAINT FK_Estado_Factura FOREIGN KEY(id_estado) REFERENCES TBL_Estados(id_estado)
);



--INSERTAR REGISTROS

Insert into TBL_Estados
(estado) Values
('Activo'),
('Inactivo');

Insert into TBL_TipoUsuario
(NombreUsuario) Values
('Super Administrador'),
('Administrador'),
('Vendedor'),
('Cliente');

Insert into TBL_Usuarios
(cedula, nombre, apellido, email, direccion, telefono, id_tipoUsuario, user_password, id_estado)
Values
(1020451189, 'Alejandro', 'Sanchez', 'alejosanosp@hotmail.com', 'Calle 105F N70-36', '3162118090', 3, 'alejo12345', 1);


select * from TBL_Usuarios