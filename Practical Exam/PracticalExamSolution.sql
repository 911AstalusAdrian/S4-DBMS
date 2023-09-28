use PracticalExam

drop table Comments
drop table Grades
drop table StudentsAssigmnetns
drop table Assignments
drop table Students
drop table Groups



create table Groups(
	groupId int primary key,
	groupName varchar(50)
)

create table Students(
	studentId int primary key,
	registrationNumber int,
	studentName varchar(50),
	email varchar(50),
	groupId int references Groups(groupId)
)

create table Assignments(
	assignmentId int primary key,
	assignmentDesc varchar(50)
)

create table StudentsAssignments(
	id int primary key,
	studentId int references Students(studentId),
	assignmentId int references Assignments(assignmentId),
	unique(studentId, assignmentId)
)

create table Grades(
	gradeId int primary key,
	studentAssigmnentId int references StudentsAssignments(id),
	unique(studentAssigmnentId)
)

create table Comments(
	commentId int primary key,
	gradeId int references Grades(gradeId),
	commentText varchar(255)
)

--insert into Groups values
--(1, '921'),(2,'922'), (3,'923'), (4, '924'), (5, '925')
select * from Groups

--insert into Students values
--(1, 1000, 'John Doe', 'mail@mail', 1),
--(2, 1001, 'Jane Doe', 'mail1@mail2af', 3),
--(3, 1002, 'Mike Krack', 'anothermail@mail', 2),
--(4, 1003, 'Tom Ford', 'onemoremail@mail', 2),
--(5, 1004, 'Lewis Hamilton', 'toomanymails@mail', 1),
--(6, 1005, 'Alt Nume', 'imgettingtiredofmails@mail', 3),
--(7, 1006, 'Inca Un Nume', 'onelastmail@mail', 2),
--(8, 1007, 'Si inca Un Nume', 'nomoremails@mail', 3)
select * from Students