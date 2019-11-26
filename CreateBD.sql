--Creacion de estructuras
CREATE TABLE Usuario
(codUsuario varchar(50),
password varchar(max),
PRIMARY KEY (codUsuario));

CREATE TABLE EstadoCuenta
(codUsuario varchar(50),
bloqueada char(1),
baja char(1),
cantidadReintentos int,
PRIMARY KEY (codUsuario));

CREATE TABLE Rol
(codigo varchar(30) NOT NULL,
descripcion varchar(50),
PRIMARY KEY (codigo));

CREATE TABLE UsuarioRol
(codUsuario varchar(50),
codRol varchar(30),
PRIMARY KEY (codUsuario, codRol));

CREATE TABLE Funcionalidad
(codFuncionalidad varchar(30),
descFuncionalidad varchar(50),
PRIMARY KEY (codFuncionalidad));

CREATE TABLE FuncionalidadRol
(codFuncionalidad varchar(30),
codRol varchar(30),
PRIMARY KEY (codFuncionalidad, codRol));

CREATE TABLE Factura
(numero [numeric](18, 0) not null,
fecha datetime,
cliente [numeric](7, 0),
proveedor [numeric](3, 0),
PRIMARY KEY (numero));

CREATE TABLE Proveedor
(idProveedor [numeric](3, 0) not null IDENTITY(1,1),
razonSocial varchar(100),
domicilio varchar(100),
telefono [numeric](18, 0),
cuit varchar(20),
rubro varchar(10),
PRIMARY KEY (idProveedor));

CREATE TABLE Rubro
(id [numeric](3, 0) not null IDENTITY(1,1),
nombre nvarchar(100),
PRIMARY KEY (id));

declare @rubroNombre nvarchar(100)
declare CUR cursor for 
		SELECT distinct(provee_rubro)
		from gd_esquema.Maestra
		where provee_rubro is not null;

OPEN CUR
	fetch CUR into @rubroNombre
	while @@FETCH_STATUS = 0
	BEGIN
	insert into rubro(nombre) values (@rubroNombre)
	fetch CUR into @rubroNombre
	end	
	CLOSE CUR
	DEALLOCATE CUR
	
--Data de la app

Insert into Usuario values ('admin','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918');

Insert into Rol values ('PV','Proveedor');
Insert into Rol values ('ADM','Administrativo');
Insert into Rol values ('CL','Cliente');

Insert into Funcionalidad values ('PP','Pago a Proveedores');
Insert into Funcionalidad values ('CC','Carga Credito');
Insert into Funcionalidad values ('OF','Ofertas');
Insert into Funcionalidad values ('ES','Estadisticas');

--creacion de FK

ALTER TABLE EstadoCuenta
ADD FOREIGN KEY (codUsuario) REFERENCES Usuario(codUsuario); 

ALTER TABLE UsuarioRol
ADD FOREIGN KEY (codUsuario) REFERENCES Usuario(codUsuario); 

ALTER TABLE UsuarioRol
ADD FOREIGN KEY (codRol) REFERENCES Rol(codigo); 

ALTER TABLE FuncionalidadRol
ADD FOREIGN KEY (codFuncionalidad) REFERENCES Funcionalidad(codFuncionalidad); 

ALTER TABLE FuncionalidadRol
ADD FOREIGN KEY (codRol) REFERENCES Rol(codigo); 

ALTER TABLE Factura
ADD FOREIGN KEY (proveedor) REFERENCES Proveedor(idProveedor);