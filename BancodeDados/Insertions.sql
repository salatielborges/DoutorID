

/*
delete from Appointment
delete from Doctor
delete from Patient
delete from Department
delete from OtherStaff
delete from LoginTable
*/

USE DBProject
GO


INSERT INTO LoginTable VALUES ('salatiel@doutorid.com' ,'123' ,   3)


--DEPARTMENT INSERTION
insert into department values(1 , 'Cardiologia ',' Temos os melhores especialistas em coração da cidade. Competentes e experientes.')
insert into department values(2 , 'Ortopedia ',' Os cirurgiões ortopédicos usam meios cirúrgicos para tratar trauma musculoesquelético, infecções, tumores. Temos os melhores.')
insert into department values(3 , 'Pediatria Nose Throat' , 'Profissionais treinados e qualificados para atender adolescentes e crianças.')
insert into department values(4 , 'Fisioterapia ',' Fisioterapeutas trabalham através de terapias físicas, como exercícios e manipulação de ossos, articulações e tecidos musculares.' )
insert into department values(5 , 'Neurologia ',' Uma especialidade médica que lida com distúrbios do sistema nervoso. Ele lida com o diagnóstico e tratamento de todas as categorias de doenças.')



--LOGIN TABLE INSERTIION
INSERT INTO LoginTable(Email, Password, Type) VALUES('usuario1@gmail.com', '123', 2)
INSERT INTO LoginTable(Email, Password, Type) VALUES('usuario2@gmail.com', '123', 2)
INSERT INTO LoginTable(Email, Password, Type) VALUES('usuario3@gmail.com', '123',2)
INSERT INTO LoginTable(Email, Password, Type) VALUES('usuario4@gmail.com', '123', 2)
INSERT INTO LoginTable(Email, Password, Type) VALUES('usuario5@gmail.com', '123', 2)
INSERT INTO LoginTable(Email, Password, Type) VALUES('usuario6@gmail.com', '123', 2)
INSERT INTO LoginTable(Email, Password, Type) VALUES('usuario7@gmail.com', '123', 2)
INSERT INTO LoginTable(Email, Password, Type) VALUES('usuario8@gmail.com', '123', 2)
INSERT INTO LoginTable(Email, Password, Type) VALUES('usuario9@gmail.com', '123', 2)
INSERT INTO LoginTable(Email, Password, Type) VALUES('usuario10@gmail.com', '123', 2)

INSERT INTO LoginTable(Email, Password, Type) VALUES('admin1@gmail.com', '123', 1)
INSERT INTO LoginTable(Email, Password, Type) VALUES('admin2@gmail.com', '123', 1)
INSERT INTO LoginTable(Email, Password, Type) VALUES('admin3@gmail.com', '123', 1)



--DOCTOR INSERTIONS
DECLARE @ID INT
SELECT @ID = LoginID FROM LoginTable WHERE Email = 'medico1@gmail.com'
INSERT INTO Doctor VALUES(@ID, 'Medico 1', '156133213', 'Jardim America, Goiânia', '4-12-1996', 'M', 1, 2500, 30000, 4, 0, 'PHD EM CADA CAMPO CONHECIDO DA MEDICINA', 'ENDEREÇO', 10, 1)
SELECT @ID = LoginID FROM LoginTable WHERE Email = 'medico2@gmail.com'
INSERT INTO Doctor VALUES(@ID, 'Medico 2', '156133213', 'Jardim America, Goiânia', '12-12-1996', 'M', 1, 3000, 25000, 3.5, 0, 'PHD EM CADA CAMPO CONHECIDO DA MEDICINA', 'ENDEREÇO', 10, 1)
SELECT @ID = LoginID FROM LoginTable WHERE Email = 'medico3@gmail.com'
INSERT INTO Doctor VALUES(@ID, 'Medico 3', '156133213', 'Jardim America, Goiânia', '12-12-1996', 'M', 1, 1500, 20000, 5, 0, 'PHD EM CADA CAMPO CONHECIDO DA MEDICINA', 'ENDEREÇO', 10, 1)
SELECT @ID = LoginID FROM LoginTable WHERE Email = 'medico4@gmail.com'
INSERT INTO Doctor VALUES(@ID, 'Medico 4', '156133213', 'Jardim America, Goiânia', '05-04-1990', 'M', 1, 1000, 15000, 4.5, 0, 'PHD EM CADA CAMPO CONHECIDO DA MEDICINA', 'ENDEREÇO', 10, 1)
SELECT @ID = LoginID FROM LoginTable WHERE Email = 'medico5@gmail.com'
INSERT INTO Doctor VALUES(@ID, 'Medico 5', '156133213', 'Jardim America, Goiânia', '05-04-1990', 'M', 2, 1000, 15000, 4.5, 0, 'PHD EM CADA CAMPO CONHECIDO DA MEDICINA', 'ENDEREÇO', 10, 1)
SELECT @ID = LoginID FROM LoginTable WHERE Email = 'medico6@gmail.com'
INSERT INTO Doctor VALUES(@ID, 'Medico 6', '156133213', 'Jardim America, Goiânia', '05-04-1990', 'M', 2, 1000, 15000, 4.5, 0, 'PHD EM CADA CAMPO CONHECIDO DA MEDICINA', 'ENDEREÇO', 10, 1)
SELECT @ID = LoginID FROM LoginTable WHERE Email = 'medico7@gmail.com'
INSERT INTO Doctor VALUES(@ID, 'Medico 7', '156133213', 'Jardim America, Goiânia', '05-04-1990', 'M', 3, 1000, 15000, 4.5, 0, 'PHD EM CADA CAMPO CONHECIDO DA MEDICINA', 'ENDEREÇO', 10, 1)
SELECT @ID = LoginID FROM LoginTable WHERE Email = 'medico8@gmail.com'
INSERT INTO Doctor VALUES(@ID, 'Medico 8', '156133213', 'Jardim America, Goiânia', '05-04-1990', 'M', 3, 1000, 15000, 4.5, 0, 'PHD EM CADA CAMPO CONHECIDO DA MEDICINA', 'ENDEREÇO', 10, 1)
SELECT @ID = LoginID FROM LoginTable WHERE Email = 'medico9@gmail.com'
INSERT INTO Doctor VALUES(@ID, 'Medico 9', '156133213', 'Jardim America, Goiânia', '05-04-1990', 'M', 4, 1000, 15000, 4.5, 0, 'PHD EM CADA CAMPO CONHECIDO DA MEDICINA', 'ENDEREÇO', 10, 1)
SELECT @ID = LoginID FROM LoginTable WHERE Email = 'medico10@gmail.com'
INSERT INTO Doctor VALUES(@ID, 'Medico 10', '156133213', 'Jardim America, Goiânia', '05-04-1990', 'M', 5, 1000, 15000, 4.5, 0, 'PHD EM CADA CAMPO CONHECIDO DA MEDICINA', 'ENDEREÇO', 10, 1)


--PATIENT INSERTIONS
DECLARE @P_ID INT
SELECT @P_ID = LoginID FROM LoginTable WHERE Email='ABC@gmail.com'
INSERT INTO Patient VALUES(@P_ID, 'ABC', '61536516', 'ENJOY, LAHORE', '4-4-1996', 'M')
SELECT @P_ID = LoginID FROM LoginTable WHERE Email='DEF@gmail.com'
INSERT INTO Patient VALUES(@P_ID, 'DEF', '61536516', 'ENJOY, LAHORE', '4-4-1996', 'M')
SELECT @P_ID = LoginID FROM LoginTable WHERE Email='XYZ@gmail.com'
INSERT INTO Patient VALUES(@P_ID, 'XYZ', '61536516', 'ENJOY, LAHORE', '4-4-1996', 'M')


select * from OtherStaff

insert into OtherStaff values ('Mauro', '62999230447','Rua 1, Jardim America, Goiânia, Goiás', 'Guarda', 'M', '04/05/1990', 'CLT',5000)
insert into OtherStaff values ('Joana', '62999230447','Rua 1, Jardim America, Goiânia, Goiás', 'Guarda', 'M', '04/05/1990', 'CLT',5000)
insert into OtherStaff values ('Jose', '62999230447','Rua 1, Jardim America, Goiânia, Goiás', 'Segurança', 'M', '04/05/1990', 'CLT',5000)
insert into OtherStaff values ('Antonio', '62999230447','Rua 1, Jardim America, Goiânia, Goiás', 'Guarda', 'M', '04/05/1990', 'CLT',5000)
insert into OtherStaff values ('Danilo', '62999230447','Rua 1, Jardim America, Goiânia, Goiás', 'Guarda', 'M', '04/05/1990', 'CLT',5000)
insert into OtherStaff values ('Carlos', '62999230447','Rua 1, Jardim America, Goiânia, Goiás', 'Guarda', 'M', '04/05/1990', 'CLT',5000)



--Como inseri a data e a hora em um formato específico na tabela de compromissos e esse formato deve ser mantido
--for proper working

/*
--APPOINTMENT INSERTIONS 
DECLARE @DOCTOR_ID INT
DECLARE @PATIENT_ID INT
SELECT @DOCTOR_ID = LoginID FROM LoginTable WHERE Email='medico1@gmail.com'
SELECT @PATIENT_ID = LoginID FROM LoginTable WHERE Email='me@gmail.com'
INSERT INTO Appointment(DoctorID, PatientID, Date, Appointment_Status) VALUES(@DOCTOR_ID, @PATIENT_ID, '04/05/2020 10:00:00', 3)
SELECT @DOCTOR_ID = LoginID FROM LoginTable WHERE Email='medico2@gmail.com'
SELECT @PATIENT_ID = LoginID FROM LoginTable WHERE Email='DEF@gmail.com'
INSERT INTO Appointment(DoctorID, PatientID, Date, Appointment_Status) VALUES(@DOCTOR_ID, @PATIENT_ID, '04/05/2020 12:00:00', 1)
SELECT @DOCTOR_ID = LoginID FROM LoginTable WHERE Email='medico3@gmail.com'
SELECT @PATIENT_ID = LoginID FROM LoginTable WHERE Email='DEF@gmail.com'
INSERT INTO Appointment(DoctorID, PatientID, Date, Appointment_Status) VALUES(@DOCTOR_ID, @PATIENT_ID, '04/05/2020 16:00:00', 3)
*/

