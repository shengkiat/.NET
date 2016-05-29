-- DB version --

delete from DBVersion
go

insert into DBVersion ( DBVersion, CreateDT) values ('Schema revision 1.5.1', '2016-05-29')
go