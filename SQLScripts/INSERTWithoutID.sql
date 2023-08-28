--Insert Sample Data to all table
--INSERT INTO table_name (column1, column2, column3, ...)
--VALUES (value1, value2, value3, ...);



INSERT INTO HorseTracking.dbo.PeopleDetails (name,surname,phoneNumber,email,city,street,number)
VALUES ('Asia','Nowak','+48123890123','asianowak@gmail.com','Opole','Oleska','12')
INSERT INTO HorseTracking.dbo.PeopleDetails (name,surname,phoneNumber,email,city,street,number)
VALUES ('Karolina','Kowalska','+48234890567','karolinakowalska@gmail.com','Opole','Katowicka','22A')
INSERT INTO HorseTracking.dbo.PeopleDetails (name,surname,phoneNumber,email,city,street,number)
VALUES ('Pawe�','Tomczyk','+48789567321','paweltomczyk@gmail.com','Opole','Krakowska','15')
INSERT INTO HorseTracking.dbo.PeopleDetails (name,surname,phoneNumber,email,city,street,number)
VALUES ('Zbyszek','D�b','+48876543876','zbyszekdab@gmail.com','Prudnik','D�browskiego','22')
INSERT INTO HorseTracking.dbo.PeopleDetails (name,surname,phoneNumber,email,city,street,number)
VALUES ('Kasia','Grab','+48678123098','kasiagrab@gmail.com','Moszna',' ','12')
INSERT INTO HorseTracking.dbo.PeopleDetails (name,surname,phoneNumber,email,city,street,number)
VALUES ('Tomek','Kowalik','+48456789321','tomek11@gmail.com','Leszno','Opolska','12')

INSERT INTO HorseTracking.dbo.NutritionPlans (title, description, icon, color)
VALUES ('Marchewka+','Plan na codzie�',1,'#FE7F00')
INSERT INTO HorseTracking.dbo.NutritionPlans (title, description, icon, color)
VALUES ('Zdrowy brzuszek','Plan na zdrowy brzuch',2,'#00a000')
INSERT INTO HorseTracking.dbo.NutritionPlans (title, description, icon, color)
VALUES ('WysokoEnergetyczny','Plan na sezon sportowy',3,'#FF0000')

INSERT INTO HorseTracking.dbo.MealNames(mealName)
VALUES('Rano')
INSERT INTO HorseTracking.dbo.MealNames(mealName)
VALUES('Po�udnie')
INSERT INTO HorseTracking.dbo.MealNames(mealName)
VALUES('Wiecz�r')

INSERT INTO HorseTracking.dbo.Specialisations (name)
VALUES('Kowal')
INSERT INTO HorseTracking.dbo.Specialisations (name)
VALUES('Weterynarz')
INSERT INTO HorseTracking.dbo.Specialisations (name)
VALUES('Fizjoterapeuta')
INSERT INTO HorseTracking.dbo.Specialisations (name)
VALUES('Gastrolog')
INSERT INTO HorseTracking.dbo.Specialisations (name)
VALUES('Ortopeda')

INSERT INTO  HorseTracking.dbo.Competitions (spot,rank,date,description)
VALUES ('Opole','regionalne','2023-03-03','brak')
INSERT INTO  HorseTracking.dbo.Competitions (spot,rank,date,description)
VALUES ('Opole','regionalne','2023-04-10','brak')

INSERT INTO HorseTracking.dbo.Forages (name, unitID, producent,capacity)
VALUES ('owies', 1,'',2)
INSERT INTO HorseTracking.dbo.Forages (name, unitID, producent,capacity)
VALUES ('musli',1, 'xyz',1)
INSERT INTO HorseTracking.dbo.Forages (name, unitID, producent,capacity)
VALUES ('marchewka',1, 'Grocery',10)
INSERT INTO HorseTracking.dbo.Forages (name, unitID, producent,capacity)
VALUES ('sieczka',1, '',10)

INSERT INTO HorseTracking.dbo.Professionals (specialisationID,detailID)
VALUES (1,3)
INSERT INTO HorseTracking.dbo.Professionals (specialisationID,detailID)
VALUES (2,4)

INSERT INTO HorseTracking.dbo.Meals(hour,nutritionPlanID,mealNameID)
VALUES ('6:00',1,1)
INSERT INTO HorseTracking.dbo.Meals(hour,nutritionPlanID,mealNameID)
VALUES ('12:00',1,2)
INSERT INTO HorseTracking.dbo.Meals(hour,nutritionPlanID,mealNameID)
VALUES ('18:00',1,3)
INSERT INTO HorseTracking.dbo.Meals(hour,nutritionPlanID,mealNameID)
VALUES ('6:00',2,1)
INSERT INTO HorseTracking.dbo.Meals(hour,nutritionPlanID,mealNameID)
VALUES ('12:00',2,2)
INSERT INTO HorseTracking.dbo.Meals(hour,nutritionPlanID,mealNameID)
VALUES ('18:00',2,3)


INSERT INTO HorseTracking.dbo.Portions(forageID,unitID,mealID,amount) --pol miarki owsa sniadanie marchew+
VALUES (1,8,1,0.5)
INSERT INTO HorseTracking.dbo.Portions(forageID,unitID,mealID,amount)
VALUES (1,8,2,0.5)
INSERT INTO HorseTracking.dbo.Portions(forageID,unitID,mealID,amount)
VALUES (1,8,3,0.5)
INSERT INTO HorseTracking.dbo.Portions(forageID,unitID,mealID,amount) --marchewki sniadanie marchew+
VALUES (3,7,1,5)
INSERT INTO HorseTracking.dbo.Portions(forageID,unitID,mealID,amount)
VALUES (3,7,2,5)
INSERT INTO HorseTracking.dbo.Portions(forageID,unitID,mealID,amount)
VALUES (3,7,3,5)

INSERT INTO HorseTracking.dbo.Portions(forageID,unitID,mealID,amount) --pol miarki owsa sniadanie zdrowy brzuch
VALUES (1,8,4,0.5)
INSERT INTO HorseTracking.dbo.Portions(forageID,unitID,mealID,amount)
VALUES (1,8,5,0.5)
INSERT INTO HorseTracking.dbo.Portions(forageID,unitID,mealID,amount)
VALUES (1,8,6,0.5)
INSERT INTO HorseTracking.dbo.Portions(forageID,unitID,mealID,amount) --sieczka sniadanie zdrowy brzuch
VALUES (4,8,4,1)
INSERT INTO HorseTracking.dbo.Portions(forageID,unitID,mealID,amount)
VALUES (4,8,5,1)
INSERT INTO HorseTracking.dbo.Portions(forageID,unitID,mealID,amount)
VALUES (4,8,6,1)

INSERT INTO HorseTracking.dbo.UserAcounts (typeID,detailID,login,hash,salt,createdDateTime)
VALUES(1,1,'admin','aaa','bb','2023-01-01')
INSERT INTO HorseTracking.dbo.UserAcounts (typeID,detailID,login,hash,salt,createdDateTime)
VALUES(2,2,'appowner','aaa','bb','2023-01-01')
INSERT INTO HorseTracking.dbo.UserAcounts (typeID,detailID,login,hash,salt,createdDateTime)
VALUES(3,5,'horseowner','aaa','bb','2023-01-01')
INSERT INTO HorseTracking.dbo.UserAcounts (typeID,detailID,login,hash,salt,createdDateTime)
VALUES(4,6,'trener1','aaa','bb','2023-01-01')
INSERT INTO HorseTracking.dbo.UserAcounts (typeID,detailID,login,hash,salt,createdDateTime)
VALUES(4,3,'trener2','aaa','bb','2023-01-01')

INSERT INTO HorseTracking.dbo.Horses (genderID,userID,statusID,name,mother,father,birthday,race,breeder,passport,photo)
VALUES(1,3,1,'Wichawa','Wiecha','Wiwat','2018-03-21','ma�opolak','SK Prudnik','jfdsifsios','')
INSERT INTO HorseTracking.dbo.Horses (genderID,userID,statusID,name,mother,father,birthday,race,breeder,passport,photo)
VALUES(1,3,1,'D�agirra','D�aga','Irches','2018-03-21','ma�opolak','SK Prudnik','jfdsifsios','')
INSERT INTO HorseTracking.dbo.Horses (genderID,userID,statusID,name,mother,father,birthday,race,breeder,passport,photo)
VALUES(1,3,1,'El Maura','El D�aha','Eulamar','2018-03-21','sp','SK Prudnik','jfdsifsios','')

INSERT INTO HorseTracking.dbo.Visits (professionalID,horseID,visitDate, summary,image,cost)
VALUES (1,1,'2023-03-01','','',100)
INSERT INTO HorseTracking.dbo.Visits (professionalID,horseID,visitDate, summary,image,cost)
VALUES (1,2,'2023-03-06','','',100)
INSERT INTO HorseTracking.dbo.Visits (professionalID,horseID,visitDate, summary,image,cost)
VALUES (2,3,'2023-03-01','','',100)
INSERT INTO HorseTracking.dbo.Visits (professionalID,horseID,visitDate, summary,image,cost)
VALUES (2,2,'2023-03-05','','',100)

INSERT INTO HorseTracking.dbo.Diets (nutritionPlanID,horseID,isActive)
VALUES (1,1, 1)
INSERT INTO HorseTracking.dbo.Diets (nutritionPlanID,horseID,isActive)
VALUES (2,2, 1)
INSERT INTO HorseTracking.dbo.Diets (nutritionPlanID,horseID,isActive)
VALUES (2,3, 0)

INSERT INTO HorseTracking.dbo.Activities (userID,activityType,trainerID,horseID,date,description,time,intensivity,satisfaction)
VALUES(1,1,4,1,'2023-03-01','',null,2,3)
INSERT INTO HorseTracking.dbo.Activities (userID,activityType,trainerID,horseID,date,description,time,intensivity,satisfaction)
VALUES(1,1,4,1,'2023-03-02','',null,4,3)
INSERT INTO HorseTracking.dbo.Activities (userID,activityType,trainerID,horseID,date,description,time,intensivity,satisfaction)
VALUES(1,1,4,1,'2023-03-03','',null,0,3)
INSERT INTO HorseTracking.dbo.Activities (userID,activityType,trainerID,horseID,date,description,time,intensivity,satisfaction)
VALUES(1,1,4,1,'2023-03-04','',null,4,5)

INSERT INTO HorseTracking.dbo.Contests(level,name,competitionID)
VALUES ('90cm','dok�adno�ci',1)

INSERT INTO HorseTracking.dbo.Participations(horseID,contestID,result,place)
VALUES (1,1,'0pkt',1)

