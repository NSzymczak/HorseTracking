drop TABLE if exists HorseTracking.dbo.Shareds 
drop TABLE if exists HorseTracking.dbo.Participations
drop TABLE if exists HorseTracking.dbo.Contests
drop TABLE if exists HorseTracking.dbo.Competitions
drop TABLE if exists HorseTracking.dbo.Diets
drop TABLE if exists HorseTracking.dbo.Portions 
drop TABLE if exists HorseTracking.dbo.Forages
drop TABLE if exists HorseTracking.dbo.UnitOfMeasures
drop TABLE if exists HorseTracking.dbo.Meals
drop TABLE if exists HorseTracking.dbo.MealNames
drop TABLE if exists HorseTracking.dbo.NutritionPlans
drop TABLE if exists HorseTracking.dbo.Visits 
drop TABLE if exists HorseTracking.dbo.Professionals
drop TABLE if exists HorseTracking.dbo.Specialisations
drop TABLE if exists HorseTracking.dbo.Notifications
drop TABLE if exists HorseTracking.dbo.Activities 
drop TABLE if exists HorseTracking.dbo.Horses
drop TABLE if exists HorseTracking.dbo.HorseGenders
drop TABLE if exists HorseTracking.dbo.Status;
drop TABLE if exists HorseTracking.dbo.UserAcounts
drop TABLE if exists HorseTracking.dbo.UserTypes
drop TABLE if exists HorseTracking.dbo.PeopleDetails

--Create all table

CREATE TABLE HorseTracking.dbo.UserTypes (
typeID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
typeName varchar(20) NOT NULL
)

CREATE TABLE HorseTracking.dbo.PeopleDetails (
detailID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
name varchar(40) NULL,
surname varchar(40) NOT NULL,
phone varchar(20) NULL,
email varchar(320) NULL,
city varchar(200) NULL,
street varchar(90) NULL,
number varchar(10) NULL,
postalCode varchar(10) NULL,
)

CREATE TABLE HorseTracking.dbo.UserAcounts (
userID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
typeID int NOT NULL,
detailID int NOT NULL,
login varchar(50) NOT NULL,
hash varchar(50) NOT NULL,
salt varchar(50) NOT NULL,
createdDateTime datetime
FOREIGN KEY (typeID)
REFERENCES UserTypes(typeID),
FOREIGN KEY (detailID)
REFERENCES PeopleDetails(detailID)
)

CREATE TABLE HorseTracking.dbo.NutritionPlans (
nutritionPlanID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
userID INT NOT NULL,
title varchar(50) NOT NULL,
description varchar(MAX) NULL,
icon int NULL, 
color varchar(7) NULL,
FOREIGN KEY (userID)
REFERENCES UserAcounts(userID),
)

CREATE TABLE HorseTracking.dbo.Status (
statusID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
name varchar(20) NOT NULL
)

CREATE TABLE HorseTracking.dbo.HorseGenders (
genderID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
gender varchar(10) NOT NULL
)

CREATE TABLE HorseTracking.dbo.MealNames(
mealNameID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
mealName varchar(20) NOT NULL)

CREATE TABLE HorseTracking.dbo.Meals(
mealID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
hour varchar(10) NULL,
mealNameID int NOT NULL,
nutritionPlanID int NOT NULL,
FOREIGN KEY (nutritionPlanID)
REFERENCES NutritionPlans(nutritionPlanID),
FOREIGN KEY (mealNameID)
REFERENCES MealNames(mealNameID)
)

CREATE TABLE HorseTracking.dbo.UnitOfMeasures(
unitID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
unitName varchar(30) NOT NULL
)

CREATE TABLE HorseTracking.dbo.Specialisations (
specialisationID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
name varchar(85) NOT NULL
)

CREATE TABLE HorseTracking.dbo.Competitions (
competitionID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
spot varchar(200) NULL,
rank varchar(50) NULL,
date date NOT NULL,
description varchar(MAX) NULL
)

CREATE TABLE HorseTracking.dbo.Forages (
forageID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
name varchar(92) NOT NULL,
unitID int NOT NULL,
producent varchar(57) NULL,
capacity float NULL
FOREIGN KEY (unitID)
REFERENCES UnitOfMeasures(unitID),
)

CREATE TABLE HorseTracking.dbo.Professionals (
professionalID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
degree varchar(20) NULL,
specialisationID int NOT NULL,
detailID int NOT NULL,
FOREIGN KEY (specialisationID)
REFERENCES Specialisations(specialisationID),
FOREIGN KEY (detailID)
REFERENCES PeopleDetails(detailID)
)

CREATE TABLE HorseTracking.dbo.Portions (
portionID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
forageID int NOT NULL,
unitID int NOT NULL,
mealID int NOT NULL,
amount float NOT NULL,
FOREIGN KEY (mealID)
REFERENCES Meals(mealID),
FOREIGN KEY (forageID)
REFERENCES Forages(forageID),
FOREIGN KEY (unitID)
REFERENCES UnitOfMeasures(unitID)
)

CREATE TABLE HorseTracking.dbo.Contests (
contestID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
level varchar(50) NULL,
name varchar(50) NULL,
competitionID INT NOT NULL,
FOREIGN KEY (competitionID)
REFERENCES Competitions(competitionID)
)

CREATE TABLE HorseTracking.dbo.Horses (
horseID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
genderID INT NOT NULL,
userID INT NOT NULL,
statusID INT NOT NULL,
name varchar(60) NOT NULL,
mother varchar(60) NULL,
father varchar(60) NULL,
birthday date NULL,
race varchar(50) NULL,
breeder varchar(60) NULL,
passport varchar(20) NULL,
photo varchar(MAX),
FOREIGN KEY (statusID)
REFERENCES Status(statusID),
FOREIGN KEY (genderID)
REFERENCES HorseGenders(genderID),
FOREIGN KEY (userID)
REFERENCES UserAcounts(userID)
)


CREATE TABLE HorseTracking.dbo.Notifications (
notificationID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
userID int NOT NULL,
horseID int NULL,
title varchar(30) NOT NULL,
description varchar(MAX) NULL,
sendDate date NOT NULL,
createdDate date NOT NULL,
turnOn bit NOT NULL,
FOREIGN KEY (userID)
REFERENCES UserAcounts(userID),
FOREIGN KEY (horseID)
REFERENCES Horses(horseID)
)

CREATE TABLE HorseTracking.dbo.Visits (
visitID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
professionalID int NOT NULL,
horseID int NOT NULL,
visitDate datetime NOT NULL,
summary varchar(MAX) NULL,
image varchar(MAX) NULL,
cost float NULL,
FOREIGN KEY (professionalID)
REFERENCES Professionals(professionalID),
FOREIGN KEY (horseID)
REFERENCES Horses(horseID)
)

CREATE TABLE HorseTracking.dbo.Shareds (
sharedID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
horseID int NOT NULL,
userShareID int NOT NULL,
userScanID int NOT NULL,
endDate datetime NOT NULL,
startDate datetime NOT NULL,
code varchar(50) NOT NULL,
FOREIGN KEY (horseID)
REFERENCES Horses(horseID),
FOREIGN KEY (userShareID)
REFERENCES UserAcounts(userID),
FOREIGN KEY (userScanID)
REFERENCES UserAcounts(userID)
)


CREATE TABLE HorseTracking.dbo.Diets (
dietID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
nutritionPlanID int NOT NULL,
horseID int NOT NULL,
isActive bit NOT NULL,
FOREIGN KEY (horseID)
REFERENCES Horses(horseID),
FOREIGN KEY (nutritionPlanID)
REFERENCES NutritionPlans(nutritionPlanID)
)

CREATE TABLE HorseTracking.dbo.Activities (
activityID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
userID int NOT NULL,
activityType int NOT NULL,
trainerID int NULL,
horseID int NOT NULL,
date datetime NOT NULL,
description varchar(MAX) NULL,
time int NULL,
intensivity int NOT NULL,
satisfaction int  NOT NULL
FOREIGN KEY (userID)
REFERENCES UserAcounts(userID),
FOREIGN KEY (trainerID)
REFERENCES UserAcounts(userID),
FOREIGN KEY (horseID)
REFERENCES Horses(horseID)
)

CREATE TABLE HorseTracking.dbo.Participations (
participationID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
horseID int NOT NULL,
contestID int NOT NULL,
result varchar(MAX) NULL,
place int NULL,
FOREIGN KEY (horseID)
REFERENCES Horses(horseID),
FOREIGN KEY (contestID)
REFERENCES Contests(contestID)
)