select * from administracion.empleado;
insert into  administracion.Empleado values('ADMIN',1140840913,'Administrador','General',null,'4vHrBgsvH3+FjnuGkNTjtQ==');
insert into  administracion.Empleado values('DESARROLLADOR',1140840913,'Rodolfo Felipe','Pineda','Mejia','4vHrBgsvH3+FjnuGkNTjtQ==');
select * from administracion.perfil;
insert into administracion.perfil values('Administrador','ADMINISTRADOR');
insert into administracion.perfil values('Participante','PARTICIPANTE');
select * from administracion.empleadoperfil;
insert into administracion.empleadoperfil values('ADMIN',1);
insert into administracion.empleadoperfil values('DESARROLLADOR',2);