select @@SPID
select @@TRANCOUNT
DBCC USEROPTIONS

delete from Book
insert into Book(id, title, author, book_language) values(1, 'Book1', 'Auth1', 'english')
insert into Book(id, title, author, book_language) values(2, 'Book2', 'Auth2', 'english')


-- Phantom Read Part1
begin tran
waitfor delay '00:00:10'
insert into Book(id, title, author, book_language) values(3, 'Book3', 'Auth3', 'spanish')
exec sp_log_changes null, 3, 'Phantom P1: insert', null
exec sp_log_locks 'Phantom P1: after insert'
commit tran

-- Phantom Read Part2
select @@SPID
select @@TRANCOUNT
DBCC USEROPTIONS

set transaction isolation level repeatable read
--set transaction isolation level serializable --solution
begin tran
select * from Book
exec sp_log_locks 'Phantom P2: between selects'
waitfor delay '00:00:10'
select * from Book
exec sp_log_locks 'Phantom P2: after both selects'
commit tran 