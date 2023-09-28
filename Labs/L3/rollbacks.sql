--table Movie(MovieID int primary key, Title varchar(50), Director varchar(30), Duration int)
--table Actor(ActorID int primary key, ActorFName varchar(30), ActorLName varchar(30), ActorDoB date, ActorBirthCountry varchar(100))
--table PlaysIn(actID int, movID int, primary key(actID, movID), foreign key (actID) references Actor(ActorID),foreign key (movID) references Movie(MovieID))
--select * from Movie
--select * from Actor
--select * from PlaysIn

--create a stored procedure that inserts data in tables that are in a m:n relationship; 
--if one insert fails, all the operations performed by the procedure must be rolled back (grade 3);

create or alter procedure addMovie(@title varchar(50), @director varchar(30), @duration int) as
	declare @maxid int
		set @maxid = 0
		SELECT TOP 1 @maxid = MovieID + 1 from Movie ORDER BY MovieID DESC
		if(@title is null)
		BEGIN
			RAISERROR('Movie title cannot be null', 24, 1);
		END
		if(@director is null)
		BEGIN
			RAISERROR('Movie director cannot be null', 24, 1);
		END
		if(@duration < 1)
		BEGIN
			RAISERROR('Movie duration cannot be less than 0', 24, 1);
		END
		INSERT INTO Movie (MovieID, Title, Director, Duration) VALUES (@maxid, @title, @director, @duration)
	EXEC sp_log_changes null, @title, 'Added to Movies', null
go

create or alter procedure addActor(@fname varchar(30), @lname varchar(30), @dob date, @country varchar(100)) as
	declare @maxid int
		set @maxid = 0
		SELECT TOP 1 @maxid = ActorID + 1 from Actor ORDER BY ActorID DESC
		if(@fname is null)
		BEGIN
			RAISERROR('Actor fName cannot be null', 24, 1);
		END
		if(@lname is null)
		BEGIN
			RAISERROR('Actor lName cannot be null', 24, 1);
		END
--		if ISDATE(@dob) = 0
--		BEGIN
--			RAISERROR('Actor DoB is invalid', 24, 1);
--		END
		if(@country is null)
		BEGIN
			RAISERROR('Actor Country cannot be null', 24, 1);
		END
		INSERT INTO Actor(ActorID, ActorFName, ActorLName, ActorDoB, ActorBirthCountry) VALUES(@maxid, @fname, @lname, @dob, @country)
	DECLARE @name varchar(100)
	SET @name = CONCAT(@fname, ' ', @lname)
	EXEC sp_log_changes null, @name, 'Added to Actors', null
go

create or alter procedure addPlaysIn(@fname varchar(30), @lname varchar(30), @title varchar(50)) as
	if (@fname is null)
	BEGIN
		RAISERROR('Actor fname null!', 24, 1);
	END
	if (@lname is null)
	BEGIN
		RAISERROR('Actor lname null!', 24, 1);
	END
	if (@title is null)
	BEGIN
		RAISERROR('Movie title null!', 24, 1);
	END
	DECLARE @actorid INT
	SET @actorid = (SELECT ActorID from Actor WHERE ActorFName = @fname AND ActorLName = @lname)
	DECLARE @movieid INT
	SET @movieid = (SELECT MovieID from Movie WHERE Title = @title)
	if(@actorid is null)
	BEGIN
		RAISERROR('Actor does not exist', 24, 1);
	END
	if(@movieid is null)
	BEGIN
		RAISERROR('Movie does not exist', 24, 1);
	END

	INSERT INTO PlaysIn(actID, movID) VALUES (@actorid, @movieid)
	DECLARE @data VARCHAR(100)
	SET @data = @fname + ' ' + @lname + ' ' + @title
	EXEC sp_log_changes null, @data, 'Connected Movie and Actor', null
go

create or alter procedure rollbackNoFail as
	begin tran
	begin try
		exec addMovie 'NewMovie', 'NewDirector', 145
		exec addActor 'actorF', 'actorL', '1-1-1999', 'Tuvalu'
		exec addPlaysIn 'actorF2', 'actorL2', 'NewMovie2'
	end try
	begin catch
		rollback tran
		return
	end catch
	commit tran
go

create or alter procedure rollbackFail as
	begin tran
	begin try
		exec addMovie 'NewMovie', 'anotherDirector', 140
		exec addActor 'actor2F', 'actor2L', '2-2-2000', 'Haiti'
		exec addPlaysIn 'actor2F', 'actor2L', 'NewMovie'
	end try
	begin catch
		rollback tran
		return
	end catch
	commit tran
go

create or alter procedure noRollbackNoFail as
	declare @errors int
	set @errors = 0

	begin try
		exec addMovie 'Movie2', 'Director2', 150
	end try
	begin catch
		set @errors = @errors + 1
	end catch

	begin try
		exec addActor 'fname1', 'lname1', '1-1-1990', 'Guatemala'
	end try
	begin catch
		set @errors = @errors + 1
	end catch

	if (@errors = 0) begin
		begin try 
			exec addPlaysIn 'fname1', 'lname1', 'Movie2'
		end try
		begin catch
		end catch
	end
go

create or alter procedure noRollbackFail as
		declare @errors int
	set @errors = 0

	begin try
		exec addMovie 'Movie2', 'Director2', 150
	end try
	begin catch
		set @errors = @errors + 1
	end catch

	begin try
		exec addActor 'fname1', 'lname1', '1-1-1990', 'Guatemala'
	end try
	begin catch
		set @errors = @errors + 1
	end catch

	if (@errors = 0) begin
		begin try 
			exec addPlaysIn 'fname1', 'lname1', 'Movie22'
		end try
		begin catch
		end catch
	end
go


select * from Actor
select * from Movie
select * from PlaysIn

delete from PlaysIn
delete from Actor
delete from Movie
exec addMovie 'NewMovie2', 'NewDirector', 145
exec addActor 'actorF2', 'actorL2', '1-1-1999', 'Tuvalu'

exec rollbackNoFail
exec rollbackFail
exec noRollbackNoFail
exec noRollbackFail