
CREATE TABLE Usuario
(codUsuario varchar(50),
password varchar(max),
PRIMARY KEY (codUsuario));

CREATE TABLE EstadoCuenta
(codUsuario varchar(50),
bloqueada char(1),
cantidadReintentos int,
PRIMARY KEY (codUsuario));

CREATE TABLE Rol
(codigo varchar(30),
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

Insert into Usuario values ('admin','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918');

Insert into Rol values ('PV','Proveedor');
Insert into Rol values ('ADM','Administrativo');
Insert into Rol values ('CL','Cliente');

Insert into Funcionalidad values ('PP','Pago a Proveedores');
Insert into Funcionalidad values ('CC','Carga Credito');
Insert into Funcionalidad values ('OF','Ofertas');
Insert into Funcionalidad values ('ES','Estadisticas');

