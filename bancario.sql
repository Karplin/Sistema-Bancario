create database sistemabancario
use sistemabancario

create table ahorro
(
numero_cuenta   int  PRIMARY KEY,
balance         int,
);

create table super
(
numero_cuenta   int PRIMARY KEY,
balance         int,

);


create table prestamo
(
numero_prestamo int PRIMARY KEY,
monto           int,
tasa            int,

);

create table tarjeta
(
numero_tarjeta int PRIMARY KEY,
limite         int,

);

create table certificado
(
numero_certificado int PRIMARY KEY,
monto              int,
duracion           int,


);


