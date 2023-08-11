-- Create the "Paises" table
CREATE TABLE "Paises" (
    "Id" integer PRIMARY KEY,
    "Clave" varchar(10) NOT NULL,
    "Name" varchar(100) NOT NULL,
    "Description" varchar(250) NOT NULL,
    "CreatedBy" integer NOT NULL,
    "LastModifiedBy" integer,
    "CreatedDate" timestamp NOT NULL,
    "LastModifiedDate" timestamp
);

-- Create the "Estados" table
CREATE TABLE "Estados" (
    "Id" integer PRIMARY KEY,
    "PaisId" integer NOT NULL,
    "Clave" varchar(10) NOT NULL,
    "Name" varchar(100) NOT NULL,
    "Description" varchar(250) NOT NULL,
    "CreatedBy" integer NOT NULL,
    "LastModifiedBy" integer,
    "CreatedDate" timestamp NOT NULL,
    "LastModifiedDate" timestamp,
    CONSTRAINT "FK_Pais_Estados" FOREIGN KEY ("PaisId") REFERENCES "Paises" ("Id")
);

-- Create the "Municipios" table
CREATE TABLE "Municipios" (
    "Id" integer PRIMARY KEY,
    "EstadoId" integer NOT NULL,
    "Clave" varchar(10) NOT NULL,
    "Name" varchar(100) NOT NULL,
    "Description" varchar(250) NOT NULL,
    "CreatedBy" integer NOT NULL,
    "LastModifiedBy" integer,
    "CreatedDate" timestamp NOT NULL,
    "LastModifiedDate" timestamp,
    CONSTRAINT "FK_Estado_Municipios" FOREIGN KEY ("EstadoId") REFERENCES "Estados" ("Id")
);

-- Create the "CodigosPostales" table
CREATE TABLE "CodigosPostales" (
    "Id" integer PRIMARY KEY,
    "EstadoId" integer NOT NULL,
    "MunicipioId" integer NOT NULL,
    "Clave" varchar(10) NOT NULL,
    "Name" varchar(100) NOT NULL,
    "Description" varchar(250) NOT NULL,
    "CreatedBy" integer NOT NULL,
    "LastModifiedBy" integer,
    "CreatedDate" timestamp NOT NULL,
    "LastModifiedDate" timestamp,
    CONSTRAINT "FK_Estado_CodigosPostales" FOREIGN KEY ("EstadoId") REFERENCES "Estados" ("Id"),
    CONSTRAINT "FK_Municipio_CodigosPostales" FOREIGN KEY ("MunicipioId") REFERENCES "Municipios" ("Id")
);

-- Create the "Colonias" table
CREATE TABLE "Colonias" (
    "Id" integer PRIMARY KEY,
    "CodigoPostalId" integer NOT NULL,
    "Clave" varchar(10) NOT NULL,
    "Name" varchar(100) NOT NULL,
    "Description" varchar(250) NOT NULL,
    "CreatedBy" integer NOT NULL,
    "LastModifiedBy" integer,
    "CreatedDate" timestamp NOT NULL,
    "LastModifiedDate" timestamp,
    CONSTRAINT "FK_CodigoPostal_Colonias" FOREIGN KEY ("CodigoPostalId") REFERENCES "CodigosPostales" ("Id")
);