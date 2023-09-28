select @@SPID
select @@TRANCOUNT
DBCC USEROPTIONS

delete from Book
insert into Book(id, title, author, book_language) values(1, 'Book1', 'Auth1', 'english')
insert into Book(id, title, author, book_language) values(2, 'Book2', 'Auth2', 'english')

--nrr Part1

insert into Book(id, title, author, book_language) values(3, 'Book3', 'Auth3', 'english')
begin tran
declare @oldData varchar(30)
declare @newData varchar(30)
waitfor delay '00:00:10'
update Book set @oldData=book_language, book_language='french', @newData=book_language where title='Book3'
exec sp_log_changes @oldData, @newData, 'Non-Repeatable Reads P1: update', null
exec sp_log_locks 'Non-Repeatable Reads P1: after update'
commit tran

--nrr Part2
select @@SPID
select @@TRANCOUNT
DBCC USEROPTIONS

set transaction isolation level read committed
--set transaction isolation level repeatable read --solution
begin tran
select * from Book
exec sp_log_locks 'Non-Repeatable Reads 2: between selects'
waitfor delay '00:00:10'
select * from Book
exec sp_log_locks 'Non-Repeatable Reads 2: after both selects'
commit tran 
