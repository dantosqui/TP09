
create procedure Login
@nombreUsuario nchar(100), @contraseña nchar(100)
as
begin
declare 
@idUsuario int, @contraseñacorrecta nchar(100)
select @idUsuario=idusuario,@contraseñacorrecta=contraseña from Usuario where username=@nombreUsuario

if (@contraseña=@contraseñacorrecta)
begin
print 'true'
end
else
begin
print 'false'
end

end;

create procedure registrarse
@username nchar(100), @contraseña nchar(100), @email nchar(100), @fechaNacimiento date, @sexo char(1), @foto nchar(3000)
as
begin

if not exists (select * from Usuario where username=@username)
begin
insert into Usuario values (@username,@contraseña,@email,@fechaNacimiento,getdate(),@sexo,@foto)
end
else

begin
print 'El usuario ya esta usado'
end

end;

exec registrarse 'nicoreifut', 'riverreifut', 'nicoreifut@chicaslindas.com', '1/6/2006', 'm', 'https://i.kym-cdn.com/entries/icons/facebook/000/042/184/handsomestaringeagle.jpg'


