--Insert Sample Data to all table
--INSERT INTO table_name (column1, column2, column3, ...)
--VALUES (value1, value2, value3, ...);


INSERT INTO HorseTracking.dbo.UserTypes (typeID,typeName)
VALUES (1,'admin')
INSERT INTO HorseTracking.dbo.UserTypes (typeID,typeName)
VALUES (2,'appOwner')
INSERT INTO HorseTracking.dbo.UserTypes (typeID,typeName)
VALUES (3,'horseOwner')
INSERT INTO HorseTracking.dbo.UserTypes (typeID,typeName)
VALUES (4,'trainer')

INSERT INTO HorseTracking.dbo.PeopleDetails (detailID,name,surname,phoneNumber,email,city,street,number)
VALUES (1,'Asia','Nowak','+48123890123','asianowak@gmail.com','Opole','Oleska','12')
INSERT INTO HorseTracking.dbo.PeopleDetails (detailID,name,surname,phoneNumber,email,city,street,number)
VALUES (2,'Karolina','Kowalska','+48234890567','karolinakowalska@gmail.com','Opole','Katowicka','22A')
INSERT INTO HorseTracking.dbo.PeopleDetails (detailID,name,surname,phoneNumber,email,city,street,number)
VALUES (3,'Pawe�','Tomczyk','+48789567321','paweltomczyk@gmail.com','Opole','Krakowska','15')
INSERT INTO HorseTracking.dbo.PeopleDetails (detailID,name,surname,phoneNumber,email,city,street,number)
VALUES (4,'Zbyszek','D�b','+48876543876','zbyszekdab@gmail.com','Prudnik','D�browskiego','22')
INSERT INTO HorseTracking.dbo.PeopleDetails (detailID,name,surname,phoneNumber,email,city,street,number)
VALUES (5,'Kasia','Grab','+48678123098','kasiagrab@gmail.com','Moszna',' ','12')
INSERT INTO HorseTracking.dbo.PeopleDetails (detailID,name,surname,phoneNumber,email,city,street,number)
VALUES (6,'Tomek','Kowalik','+48456789321','tomek11@gmail.com','Leszno','Opolska','12')

INSERT INTO HorseTracking.dbo.NutritionPlans (nutritionPlanID, title, description, icon, color)
VALUES (1,'Marchewka+','Plan na codzie�',1,'#FE7F00')
INSERT INTO HorseTracking.dbo.NutritionPlans (nutritionPlanID, title, description, icon, color)
VALUES (2,'Zdrowy brzuszek','Plan na zdrowy brzuch',2,'#00a000')
INSERT INTO HorseTracking.dbo.NutritionPlans (nutritionPlanID, title, description, icon, color)
VALUES (3,'WysokoEnergetyczny','Plan na sezon sportowy',3,'#FF0000')

INSERT INTO HorseTracking.dbo.Status (statusID,name)
VALUES (1, 'active')
INSERT INTO HorseTracking.dbo.Status (statusID,name)
VALUES (2, 'inactive')
INSERT INTO HorseTracking.dbo.Status (statusID,name)
VALUES (3, 'sent')
INSERT INTO HorseTracking.dbo.Status (statusID,name)
VALUES (4, 'shared')

INSERT INTO HorseTracking.dbo.HorseGenders (genderID,gender)
VALUES (1,'mare')
INSERT INTO HorseTracking.dbo.HorseGenders (genderID,gender)
VALUES (2,'stallion')
INSERT INTO HorseTracking.dbo.HorseGenders (genderID,gender)
VALUES (3,'gelding')


INSERT INTO HorseTracking.dbo.MealNames(mealNameID,mealName)
VALUES(1,'Rano')
INSERT INTO HorseTracking.dbo.MealNames(mealNameID,mealName)
VALUES(2,'Po�udnie')
INSERT INTO HorseTracking.dbo.MealNames(mealNameID,mealName)
VALUES(3,'Wiecz�r')

INSERT INTO HorseTracking.dbo.UnitOfMeasures(unitID,unitName)
VALUES(1,'kilogram')
INSERT INTO HorseTracking.dbo.UnitOfMeasures(unitID,unitName)
VALUES(2,'dekagram')
INSERT INTO HorseTracking.dbo.UnitOfMeasures(unitID,unitName)
VALUES(3,'gram')
INSERT INTO HorseTracking.dbo.UnitOfMeasures(unitID,unitName)
VALUES(4,'liter')
INSERT INTO HorseTracking.dbo.UnitOfMeasures(unitID,unitName)
VALUES(5,'mililiter')
INSERT INTO HorseTracking.dbo.UnitOfMeasures(unitID,unitName)
VALUES(6,'bala')
INSERT INTO HorseTracking.dbo.UnitOfMeasures(unitID,unitName)
VALUES(7,'sztuka')
INSERT INTO HorseTracking.dbo.UnitOfMeasures(unitID,unitName)
VALUES(8,'miarka')

INSERT INTO HorseTracking.dbo.Specialisations (specialisationID,name)
VALUES(1, 'Kowal')
INSERT INTO HorseTracking.dbo.Specialisations (specialisationID,name)
VALUES(2, 'Weterynarz')
INSERT INTO HorseTracking.dbo.Specialisations (specialisationID,name)
VALUES(3, 'Fizjoterapeuta')
INSERT INTO HorseTracking.dbo.Specialisations (specialisationID,name)
VALUES(4, 'Gastrolog')
INSERT INTO HorseTracking.dbo.Specialisations (specialisationID,name)
VALUES(5, 'Ortopeda')

INSERT INTO  HorseTracking.dbo.Competitions (competitionID,spot,rank,date,description)
VALUES (1,'Opole','regionalne','2023-03-03','brak')
INSERT INTO  HorseTracking.dbo.Competitions (competitionID,spot,rank,date,description)
VALUES (2,'Opole','regionalne','2023-04-10','brak')

INSERT INTO HorseTracking.dbo.Forages (forageID,name, unitID, producent,capacity)
VALUES (1, 'owies', 1,'',2)
INSERT INTO HorseTracking.dbo.Forages (forageID,name, unitID, producent,capacity)
VALUES (2, 'musli',1, 'xyz',1)
INSERT INTO HorseTracking.dbo.Forages (forageID,name, unitID, producent,capacity)
VALUES (3, 'marchewka',1, 'Grocery',10)
INSERT INTO HorseTracking.dbo.Forages (forageID,name, unitID, producent,capacity)
VALUES (4, 'sieczka',1, '',10)

INSERT INTO HorseTracking.dbo.Professionals (professionalID,specialisationID,detailID)
VALUES (1,1,3)
INSERT INTO HorseTracking.dbo.Professionals (professionalID,specialisationID,detailID)
VALUES (2,2,4)

INSERT INTO HorseTracking.dbo.Meals(mealID,hour,nutritionPlanID,mealNameID)
VALUES (1,'6:00',1,1)
INSERT INTO HorseTracking.dbo.Meals(mealID,hour,nutritionPlanID,mealNameID)
VALUES (2,'12:00',1,2)
INSERT INTO HorseTracking.dbo.Meals(mealID,hour,nutritionPlanID,mealNameID)
VALUES (3,'18:00',1,3)
INSERT INTO HorseTracking.dbo.Meals(mealID,hour,nutritionPlanID,mealNameID)
VALUES (4,'6:00',2,1)
INSERT INTO HorseTracking.dbo.Meals(mealID,hour,nutritionPlanID,mealNameID)
VALUES (5,'12:00',2,2)
INSERT INTO HorseTracking.dbo.Meals(mealID,hour,nutritionPlanID,mealNameID)
VALUES (6,'18:00',2,3)


INSERT INTO HorseTracking.dbo.Portions(portionID,forageID,unitID,mealID,amount) --pol miarki owsa sniadanie marchew+
VALUES (1,1,8,1,0.5)
INSERT INTO HorseTracking.dbo.Portions(portionID,forageID,unitID,mealID,amount)
VALUES (2,1,8,2,0.5)
INSERT INTO HorseTracking.dbo.Portions(portionID,forageID,unitID,mealID,amount)
VALUES (3,1,8,3,0.5)
INSERT INTO HorseTracking.dbo.Portions(portionID,forageID,unitID,mealID,amount) --marchewki sniadanie marchew+
VALUES (4,3,7,1,5)
INSERT INTO HorseTracking.dbo.Portions(portionID,forageID,unitID,mealID,amount)
VALUES (5,3,7,2,5)
INSERT INTO HorseTracking.dbo.Portions(portionID,forageID,unitID,mealID,amount)
VALUES (6,3,7,3,5)

INSERT INTO HorseTracking.dbo.Portions(portionID,forageID,unitID,mealID,amount) --pol miarki owsa sniadanie zdrowy brzuch
VALUES (7,1,8,4,0.5)
INSERT INTO HorseTracking.dbo.Portions(portionID,forageID,unitID,mealID,amount)
VALUES (8,1,8,5,0.5)
INSERT INTO HorseTracking.dbo.Portions(portionID,forageID,unitID,mealID,amount)
VALUES (9,1,8,6,0.5)
INSERT INTO HorseTracking.dbo.Portions(portionID,forageID,unitID,mealID,amount) --sieczka sniadanie zdrowy brzuch
VALUES (10,4,8,4,1)
INSERT INTO HorseTracking.dbo.Portions(portionID,forageID,unitID,mealID,amount)
VALUES (11,4,8,5,1)
INSERT INTO HorseTracking.dbo.Portions(portionID,forageID,unitID,mealID,amount)
VALUES (12,4,8,6,1)



INSERT INTO HorseTracking.dbo.UserAcounts (userID,typeID,detailID,login,hash,salt,createdDateTime)
VALUES(1,1,1,'admin','aaa','bb','2023-01-01')
INSERT INTO HorseTracking.dbo.UserAcounts (userID,typeID,detailID,login,hash,salt,createdDateTime)
VALUES(2,2,2,'appowner','aaa','bb','2023-01-01')
INSERT INTO HorseTracking.dbo.UserAcounts (userID,typeID,detailID,login,hash,salt,createdDateTime)
VALUES(3,3,5,'horseowner','aaa','bb','2023-01-01')
INSERT INTO HorseTracking.dbo.UserAcounts (userID,typeID,detailID,login,hash,salt,createdDateTime)
VALUES(4,4,6,'trener1','aaa','bb','2023-01-01')
INSERT INTO HorseTracking.dbo.UserAcounts (userID,typeID,detailID,login,hash,salt,createdDateTime)
VALUES(5,4,3,'trener2','aaa','bb','2023-01-01')

INSERT INTO HorseTracking.dbo.Horses (horseID,genderID,userID,statusID,name,mother,father,birthday,race,breeder,passport,photo)
VALUES(1,1,3,1,'Wichawa','Wiecha','Wiwat','2018-03-21','ma�opolak','SK Prudnik','jfdsifsios','')
INSERT INTO HorseTracking.dbo.Horses (horseID,genderID,userID,statusID,name,mother,father,birthday,race,breeder,passport,photo)
VALUES(2,1,3,1,'D�agirra','D�aga','Irches','2018-03-21','ma�opolak','SK Prudnik','jfdsifsios','')
INSERT INTO HorseTracking.dbo.Horses (horseID,genderID,userID,statusID,name,mother,father,birthday,race,breeder,passport,photo)
VALUES(3,1,3,1,'El Maura','El D�aha','Eulamar','2018-03-21','sp','SK Prudnik','jfdsifsios','')


INSERT INTO HorseTracking.dbo.Visits (visitID,professionalID,horseID,visitDate, summary,image,cost)
VALUES (1,1,1,'2023-03-01','','',100)
INSERT INTO HorseTracking.dbo.Visits (visitID,professionalID,horseID,visitDate, summary,image,cost)
VALUES (2,1,1,'2023-03-04','','',100)



INSERT INTO HorseTracking.dbo.Diets (dietID,nutritionPlanID,horseID,isActive)
VALUES (1,1,1, 1)
INSERT INTO HorseTracking.dbo.Diets (dietID,nutritionPlanID,horseID,isActive)
VALUES (2,2,2, 1)
INSERT INTO HorseTracking.dbo.Diets (dietID,nutritionPlanID,horseID,isActive)
VALUES (3,2,3, 0)

INSERT INTO HorseTracking.dbo.Activities (activityID,userID,activityType,trainerID,horseID,date,description,time,intensivity,satisfaction)
VALUES(1,1,1,4,1,'2023-03-01','',null,2,3)
INSERT INTO HorseTracking.dbo.Activities (activityID,userID,activityType,trainerID,horseID,date,description,time,intensivity,satisfaction)
VALUES(2,1,1,4,1,'2023-03-02','',null,4,3)
INSERT INTO HorseTracking.dbo.Activities (activityID,userID,activityType,trainerID,horseID,date,description,time,intensivity,satisfaction)
VALUES(3,1,1,4,1,'2023-03-03','',null,0,3)
INSERT INTO HorseTracking.dbo.Activities (activityID,userID,activityType,trainerID,horseID,date,description,time,intensivity,satisfaction)
VALUES(4,1,1,4,1,'2023-03-04','',null,4,5)

INSERT INTO HorseTracking.dbo.Participations(participationID,horseID,competitionID,level,result,place)
VALUES (1,1,1,'90cm','0pkt',1)
