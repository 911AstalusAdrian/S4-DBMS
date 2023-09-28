select @@SPID
select @@TRANCOUNT
DBCC USEROPTIONS

delete from Book
insert into Book(id, title, author, book_language) values(1, 'Book1', 'Auth1', 'english')
insert into Book(id, title, author, book_language) values(2, 'Book2', 'Auth2', 'english')

-- Deadlock Part1
begin tran
declare @oldData varchar(30)
declare @newData varchar(30)
update Book set @oldData=book_language, book_language='french', @newData=book_language where id=1
exec sp_log_changes @oldData, @newData, 'Deadlock P1: Update 1', null
exec sp_log_locks 'Deadlock 1: between updates'
waitfor delay '00:00:10'
update Book set @oldData=book_language, book_language='french', @newData=book_language where id=2
exec sp_log_changes @oldData, @newData, 'Deadlock P1: Update 2', null
commit tran

-- Deadlock Part2
select @@TRANCOUNT
select @@SPID


set deadlock_priority high
begin tran
declare @oldData2 varchar(30)
declare @newData2 varchar(30)
update Book set @oldData2=book_language, book_language='spanish', @newData2=book_language where id=2
exec sp_log_changes @oldData2, @newData2, 'Deadlock P2: Update 1', null
exec sp_log_locks 'Deadlock 2: between updates'
waitfor delay '00:00:05'
update Book set @oldData2=book_language, book_language='spanish', @newData2=book_language where id=1
exec sp_log_changes @oldData2, @newData2, 'Deadlock P2: Update 2', null
commit tran

select * from Book