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
razonSocial nvarchar(100) UNIQUE,
domicilio nvarchar(100),
ciudad nvarchar(255),
telefono [numeric](18, 0),
mail nvarchar(100),
codigoPostal [numeric](4, 0),
contacto nvarchar(150),
cuit nvarchar(20) UNIQUE,
baja nvarchar(1)DEFAULT 'N',
rubro [numeric](3, 0),
PRIMARY KEY (idProveedor));

CREATE TABLE Rubro
(id [numeric](3, 0) not null IDENTITY(1,1),
nombre nvarchar(100),
PRIMARY KEY (id));

--Cursores

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
	
	
declare @proveeRazonSocial nvarchar(100),
		@proveeDomicilio nvarchar(100),
		@proveeCiudad nvarchar(255),
		@proveeTelefono numeric(18,0),
		@proveeCuit nvarchar(20),
		@proveeRubro nvarchar(100),
		@proveeCodRubro [numeric](3, 0)

declare CUR cursor for 
		SELECT distinct Provee_RS, Provee_Dom, Provee_ciudad, Provee_telefono, provee_cuit, provee_rubro 
		from gd_esquema.Maestra
		where provee_rubro is not null;

OPEN CUR
	fetch CUR into @proveeRazonSocial,@proveeDomicilio,@proveeCiudad,@proveeTelefono,@proveeCuit,@proveeRubro
	while @@FETCH_STATUS = 0
	BEGIN
	select @proveeCodRubro = id from rubro where nombre = @proveeRubro
	insert into Proveedor(razonSocial,domicilio,ciudad,telefono,cuit,rubro) 
	values (@proveeRazonSocial,@proveeDomicilio,@proveeCiudad,@proveeTelefono,@proveeCuit,@proveeCodRubro)
	fetch CUR into @proveeRazonSocial,@proveeDomicilio,@proveeCiudad,@proveeTelefono,@proveeCuit,@proveeRubro
	end	
	CLOSE CUR
	DEALLOCATE CUR
	
	
	
CREATE TABLE TipoPago
(codigo [numeric](3, 0) not null IDENTITY(1,1),
descripcion nvarchar(100),
PRIMARY KEY (codigo));

--Cursores

declare @tipoPago nvarchar(100)
declare CUR cursor for 
		SELECT distinct(Tipo_Pago_Desc)
		from gd_esquema.Maestra
		where tipo_pago_desc is not null;

OPEN CUR
	fetch CUR into @tipoPago
	while @@FETCH_STATUS = 0
	BEGIN
	insert into TipoPago(descripcion) values (@tipoPago)
	fetch CUR into @tipoPago
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

ALTER TABLE Proveedor
ADD FOREIGN KEY (rubro) REFERENCES Rubro(id);