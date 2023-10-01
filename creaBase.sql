CREATE DATABASE OrdenesCompra;

CREATE TABLE Usuario(
usuario_correo  VARCHAR (150) NOT NULL,
usuario_contraseña VARCHAR (100) NOT NULL);

CREATE TABLE OrdenCompra(
id_oc				INT NOT NULL IDENTITY (1,1),
cliente_oc			VARCHAR (100) NOT NULL,
cantidad_oc			INT NOT NULL,
descripcion_oc		VARCHAR (150) NOT NULL,
producto_oc			VARCHAR (150) NOT NULL,
monto_oc			INT NOT NULL,
descuentos_oc		INT NOT NULL,
monto_total_oc		INT NOT NULL,
fecha_oc			DATE NOT NULL,
rut_cli_oc			VARCHAR (15) NOT NULL,
rut_prov_oc			VARCHAR (15) NOT NULL,
tel_cli_oc			INT NOT NULL,
tel_prov_oc			INT NOT NULL,
correo_cli_oc		VARCHAR (150) NOT NULL,
correo_prov_oc		VARCHAR (150) NOT NULL,
dir_cli_oc			VARCHAR (150) NOT NULL,
dir_prov_oc			VARCHAR (150) NOT NULL);

ALTER TABLE OrdenCompra ADD CONSTRAINT PK_OC PRIMARY KEY (id_oc);
