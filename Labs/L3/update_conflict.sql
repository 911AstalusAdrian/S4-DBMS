select @@SPID
select @@TRANCOUNT
DBCC USEROPTIONS

delete from Book
insert into Book(id, title, author, book_language) values(1, 'Book1', 'Auth1', 'english')

alter database CinemaDB set allow_snapshot_isolation on

begin tran
declare @oldData varchar(50)
declare @newData varchar(50)
update Book set @oldData=book_language, book_language='spanish', @newData=book_language where id=1
waitfor delay '00:00:10'
exec sp_log_changes @oldData, @newData, 'Update Conflict 1: update', null
exec sp_log_locks 'Update Conflict P1: after update'
select * from Book
commit tran

-- query console 2
select @@SPID
select @@TRANCOUNT
DBCC USEROPTIONS

-- set transaction isolation level read uncommitted --solution
set transaction isolation level snapshot

begin tran
declare @oldData2 varchar(50)
declare @newData2 varchar(50)
update Book set @oldData2=book_language, book_language='french', @newData2=book_language where id=1
exec sp_log_changes @oldData2, @newData2, 'Update Conflict 2: update', null
exec sp_log_locks 'Update Conflict 2: after update'
select * from Book
commit tran