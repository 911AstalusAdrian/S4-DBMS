use PracticalExam

begin tran

update Groups
set groupName = '999'
where groupId = 5

waitfor delay '00:00:05'

update Groups
set GroupName = '998'
where groupId = 4

commit tran
