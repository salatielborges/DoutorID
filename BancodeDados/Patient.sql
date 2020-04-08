
use DBProject
go

create procedure RetrievePatientData

@ID int,
@name varchar(30) output,
@phone char(11) output,
@address varchar(40) output,
@birthDate varchar (10) output,
@age int output,
@gender char(1) output

as
begin
	select @name=Name, @phone=Phone, @address=Address, @gender=Gender, @age=DATEDIFF(YEAR, BirthDate, GETDATE()), @birthDate = BirthDate from Patient where PatientID = @ID
end




GO
create procedure RetrieveBillHistory

@pID int,
@count int OUTPUT

as
begin

	select CONVERT(VARCHAR(11),[date],106) as [Date],  [Name] as [Doctor's Name], Bill_Amount as [Bill Amount], Bill_Status as [Bill Status]
	from Appointment A join Doctor D on A.DoctorID = D.DoctorID
	where PatientID = @pID AND Appointment_Status = 3

	select @count = count(*) from Appointment where PatientID = @pID and Appointment_Status = 3
end



GO
create procedure RetrieveCurrentAppointment

@pID int,
@dName varchar(30) OUTPUT,
@timings varchar(30) OUTPUT,
@count int OUTPUT

as
begin

	
	
	if (exists (select* from Appointment where PatientID = @pID AND Appointment_Status = 2))
	begin
		declare @day datetime, @month datetime, @year datetime
		set @day = datepart (day,getdate())
		set @month = datepart (month, getdate())
		set @year = datepart (year, getdate())

		declare @Aday datetime, @Amonth datetime, @Ayear datetime

		select @Aday = datepart(day,[date]), @Amonth = datepart(MONTH,[date]), @Ayear = datepart(YEAR,[date]) from Appointment where PatientID = @pID AND Appointment_Status = 2

		select @dName = name, @timings = CONVERT(VARCHAR(19),[date]) from Appointment A join Doctor D on A.DoctorID = D.DoctorID
																		   where PatientID = @pID AND appointment_Status = 2
		
		--If the appointment is outdated then delete it
		if (@Aday != @day OR @Amonth != @month OR @Ayear != @year)
		begin
			delete from Appointment where PatientID = @pID AND Appointment_Status = 2
			set @count = 3
		end

		else
		begin
			set @count = 2
		end
	end

	else
	begin
		if (exists (select * from Appointment where PatientID = @pid and Appointment_Status = 1))
		begin
				select @dName = name, @timings = CONVERT(VARCHAR(19),[date]) from Appointment A join Doctor D on A.DoctorID = D.DoctorID
																		   where PatientID = @pID AND appointment_Status = 1
				set @count = 1
		end

		else
		begin
				set @count = 0
		end
	end
end


GO
create procedure RetrieveTreatmentHistory

@pID int,
@count int OUTPUT

as
begin

	select CONVERT(VARCHAR(11),[date],106) as [Date], [Name] as [Doctor's Name], Disease as [Diagnosed Disease], Progress as [Progress Made], Prescription
	from Appointment A join Doctor D on A.DoctorID = D.DoctorID
	where PatientID = @pID and Appointment_Status = 3

	select @count = count(*) from Appointment where PatientID = @pID and Appointment_Status = 3
end



GO
create view deptInfo
as
select DeptName, [Description], count(Dept.deptNo) as [Number of Doctors] 
from Department Dept join Doctor D on Dept.DeptNo = D.DeptNo
where D.status != 0
group by Dept.DeptNo, DeptName, [Description] 



GO
create procedure RetrieveDeptDoctorInfo

@deptName varchar(30)

as
begin

	select DoctorID, [Name] as [Doctor's Name], Specialization, deptName as [DeptName]
	from Department Dept join Doctor D on Dept.DeptNo = D.DeptNo
	where DeptName = @deptName AND D.status != 0
	
end



GO
create procedure RetrieveDoctorData


@dID int,

@name varchar(30) output,
@phone char(11) output,
@gender varchar(2) output,
@charges float output,
@RI float output,
@PTreated int output,
@qualification varchar(100) output,
@specialization varchar(100) output,
@workE int output,
@age int output

as
begin
	select @name=Name, @phone=Phone, @gender=Gender,@charges = charges_per_visit, @RI = ReputeIndex, @PTreated = Patients_Treated, @qualification = qualification, @specialization = specialization, @workE = Work_Experience, @age=DATEDIFF(YEAR, BirthDate, GETDATE()) from Doctor where DoctorID = @dID
end






GO
create FUNCTION [dbo].[fnSplitString] 
( 
    @string NVARCHAR(MAX), 
    @delimiter CHAR(1) 
) 
RETURNS @output TABLE(splitdata NVARCHAR(MAX) 
) 
BEGIN 
    DECLARE @start INT, @end INT 
    SELECT @start = 1, @end = CHARINDEX(@delimiter, @string) 
    WHILE @start < LEN(@string) + 1 BEGIN 
        IF @end = 0  
            SET @end = LEN(@string) + 1
       
        INSERT INTO @output (splitdata)  
        VALUES(SUBSTRING(@string, @start, @end - @start)) 
        SET @start = @end + 1 
        SET @end = CHARINDEX(@delimiter, @string, @start)
        
    END 
    RETURN 
END



GO
create procedure RetrieveFreeSlots

@dID int,
@pID int,
@count int OUTPUT

as
begin

declare @month int, @year int, @day int
declare @hoursList varchar(100)


set @month = DATEPART(MONTH, GETDATE())
set @year  = DATEPART(YEAR, GETDATE())
set @day   = DATEPART(DAY, GETDATE())


declare @currentHour int

set @currentHour = 9
set @count = 0
set @hoursList = ''

declare @tempT varchar (10)
declare @tempHour int

set @tempHour = 0

	while (@currentHour != 18)
	begin
			if (
				not exists (select* from Appointment 
							where
							DATEPART(YEAR, [DATE]) = @year AND  DATEPART(MONTH, [DATE]) = @month AND DATEPART(DAY, [DATE]) = @day
							AND DoctorID = @dID
							AND DATEPART(Hour, [DATE]) = @currentHour
							)
				)

			begin

				set @count = @count + 1

				if (@currentHour < 12)
				begin
					set @tempT = ':00 AM'
					set @tempHour = @currentHour
				end
				
				else if (@currentHour = 12)
				begin
					set @tempT = ':00 PM'
					set @tempHour = @currentHour
				end		

				else
				begin
					set @tempT = ':00 PM'
					set @tempHour = @currentHour - 12
				end
								

				SELECT @hoursList = @hoursList + CAST(@tempHour AS VARCHAR(5))  + @tempT + ','

			end
				
		    set @currentHour = @currentHour + 1
	end


	select convert (varchar(100), splitdata) as [Free Slots] from dbo.fnSplitString(@hoursList,',')
end


GO
create procedure insertInAppointmentTable

@pid int,
@dId int,
@freeSlot int

as
begin

	if (@freeSlot < 9)
		set @freeSlot = @freeSlot + 12

	declare @date varchar (100)
	select @date = CONVERT(VARCHAR(11),GETDATE(),6)
	select @date = @date + ' ' + cast (@freeSlot as varchar(30)) + ':00'
	
	declare @dateA datetime
	select @dateA = CONVERT(datetime, @date)

	insert into Appointment values (@dId,@pId,@dateA,2,NULL,NULL,2,1,NULL,NULL,NULL,NULL)  --Trigger (1) will be called here.
end



GO
create procedure RetrievePatientNotifications

@pID int,
@dName varchar(30) OUTPUT,
@timings varchar(30) OUTPUT,
@count int OUTPUT

as
begin


	if (exists (select* from Appointment where PatientID = @pID AND PatientNotification = 2))
	begin

		declare @aStatus int, @aID int
		select @aStatus = Appointment_Status, @aID = AppointID from Appointment where PatientID = @pID AND PatientNotification = 2

		if(@aStatus = 1 or @aStatus = 3)
		begin

			if (@aStatus = 3)
			begin
				set @count = 3
			end

			else
			begin
				set @count = 1
			end

			select @dName = name, @timings = CONVERT(VARCHAR(19),[date]) from Appointment A join Doctor D on A.DoctorID = D.DoctorID
																	   where @aID = AppointID			
			--Mark that notification as Seen
			update Appointment
			set patientNotification = 1
			where AppointID = @aID

		end

		else if (@aStatus = 4)
		begin
			select @dName = name, @timings = CONVERT(VARCHAR(19),[date]) from Appointment A join Doctor D on A.DoctorID = D.DoctorID
																		   where @aID = AppointID

			set @count = 2

			--Delete the rejected appointment
			delete from Appointment where AppointID = @aID
		end

		else
		begin
			set @count = 0
		end
	end

	else
	begin
		set @count = 0
	end
end


GO
create procedure retrievePendingFeedback

@pID int,
@dName varchar(30) OUTPUT,
@timings varchar(30) OUTPUT,
@aID int OUTPUT,
@count int OUTPUT

as
begin

	if (exists (select* from Appointment where PatientID=@pID AND feedbackStatus = 2 AND Appointment_Status = 3))
	begin
		  set @count = 1

		  select @dName = name, @timings = CONVERT(VARCHAR(19),[date]), @aID = AppointID from Appointment A join Doctor D on A.DoctorID = D.DoctorID
																		   where PatientID = @pID AND (feedbackStatus = 2) AND Appointment_Status = 3
	end

	else
	begin
			set @count = 0
	end
end



GO
create procedure storeFeedback

@aID int

as
begin

	declare @dID int
	select @dID = DoctorID from Appointment where AppointID = @aID

	declare @RI float, @PT int

	select @RI = ReputeIndex, @PT = Patients_Treated from Doctor where DoctorID = @dID

	declare @avg float

	select @avg = (@RI * (@PT-1)) / @PT


	update Doctor
	set ReputeIndex = @avg
	where DoctorID = @dID

	update Appointment
	set FeedbackStatus = 1
	where AppointID = @aID

end




GO
create trigger OneAppointment on Appointment
instead of insert
as

begin
	
	declare @dID int, @pID int, @d datetime
	
	select @dID = DoctorID, @pID = PatientID, @d = [Date] from inserted

	if (not exists (select * from Appointment where PatientID = @pID AND (Appointment_Status = 2 OR Appointment_Status = 1 )))
	
	begin
			insert into Appointment values (@dId,@pId,@d,2,NULL,NULL,2,1,NULL,NULL,NULL,NULL)
			print ('Pedido enviado para marcar a consulta :)')
	end

	else
		print ('Você já solicitou uma consulta hoje. Você não pode solicitar mais de uma consulta por dia!')
end


