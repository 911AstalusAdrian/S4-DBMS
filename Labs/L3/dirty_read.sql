select @@SPID
select @@TRANCOUNT
DBCC USEROPTIONS

create table Book(
	id int primary key,
	title varchar(50),
	author varchar(100),
	book_language varchar(50)
)
--drop table Book
--delete from Book
--select * from Book

delete from Book
insert into Book(id, title, author, book_language) values(1, 'Book1', 'Auth1', 'english')
insert into Book(id, title, author, book_language) values(2, 'Book2', 'Auth2', 'english')

--dirty read Part1

--set transaction isolation level read uncommitted
set transaction isolation level read committed --sol
begin tran
select * from Book
exec sp_log_locks 'Dirty read P1: first select'
waitfor delay '00:00:10'
select * from Book
commit tran



--dirty read Part2
begin tran
declare @oldData varchar(30)
declare @newData varchar(30)
update Book set @oldData=book_language, book_language='french', @newData=book_language where id = 1
exec sp_log_changes @oldData, @newData, 'Dirty Read P2: update', null
exec sp_log_locks 'Dirty reads P2: after update'
waitfor delay '00:00:10'
rollback tran


delete from Book