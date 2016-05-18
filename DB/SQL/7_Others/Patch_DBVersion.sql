-- DB version --

delete from DBVersion
go

insert into DBVersion ( DBVersion, CreateDT) values ('Schema revision 1.5', '2016-05-18')
go