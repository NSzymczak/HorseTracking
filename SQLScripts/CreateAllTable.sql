--Create all table

CREATE TABLE HorseTracking.dbo.UserType (
typeID INT NOT NULL PRIMARY KEY,
typeName varchar(50) NOT NULL
)

CREATE TABLE HorseTracking.dbo.PeopleDetails (
detailsID INT NOT NULL PRIMARY KEY,
name varchar(50) NOT NULL,
surname varchar(50) NOT NULL,
phoneNumber varchar(50) NOT NULL,
email varchar(50) NOT NULL,
city varchar(50) NOT NULL,
street varchar(50) NOT NULL,
number varchar(50) NOT NULL
)

CREATE TABLE HorseTracking.dbo.NutritionPlan (
nutritionPlanID INT NOT NULL PRIMARY KEY,
title int NOT NULL,
description varchar(50) NULL
)

CREATE TABLE HorseTracking.dbo.HorseStatus (
statusID INT NOT NULL PRIMARY KEY,
name varchar(50) NOT NULL
)

CREATE TABLE HorseTracking.dbo.HorseGender (
genderID INT NOT NULL PRIMARY KEY,
gender varchar(50) NOT NULL
)

CREATE TABLE HorseTracking.dbo.Forage (
forageID INT NOT NULL PRIMARY KEY,
name int NOT NULL,
producent varchar(50) NULL,
capacity varchar(50) NULL
)

CREATE TABLE HorseTracking.dbo.DoctorSpecialisation (
specialisationID INT NOT NULL PRIMARY KEY,
name varchar(50) NOT NULL
)

CREATE TABLE HorseTracking.dbo.Competition (
competitionID INT NOT NULL PRIMARY KEY,
competitor varchar(50) NOT NULL,
place varchar(50) NULL,
description varchar(MAX) NULL
)

CREATE TABLE HorseTracking.dbo.ActivityType (
activityTypeID INT NOT NULL PRIMARY KEY,
name varchar(50) NOT NULL,
color varchar(50) NOT NULL,
icon varchar(50) NULL
)

CREATE TABLE HorseTracking.dbo.Doctor (
doctorID INT NOT NULL PRIMARY KEY,
specialisationID int NOT NULL,
detailsID int NOT NULL,
FOREIGN KEY (specialisationID)
REFERENCES DoctorSpecialisation(specialisationID),
FOREIGN KEY (detailsID)
REFERENCES PeopleDetails(detailsID)
)

CREATE TABLE HorseTracking.dbo.Feeding (
feedID INT NOT NULL PRIMARY KEY,
nutritionPlanID int NOT NULL,
forageID int NOT NULL,
timeOfFeeding datetime NULL,
quantity float NULL,
FOREIGN KEY (nutritionPlanID)
REFERENCES NutritionPlan(nutritionPlanID),
FOREIGN KEY (forageID)
REFERENCES Forage(forageID)
)

CREATE TABLE HorseTracking.dbo.CompetitionResult (
resultID INT NOT NULL PRIMARY KEY,
competitionID int NOT NULL,
level varchar(50) NULL,
result varchar(50) NULL,
place int NULL,
FOREIGN KEY (competitionID)
REFERENCES Competition(competitionID)
)

CREATE TABLE HorseTracking.dbo.UserAcount (
userID INT NOT NULL PRIMARY KEY,
userTypeID int NOT NULL,
detailsID int NOT NULL,
acountLogin varchar(50) NOT NULL,
hash varchar(50) NOT NULL,
salt varchar(50) NOT NULL,
createdDate date 
FOREIGN KEY (userTypeID)
REFERENCES UserType(typeID),
FOREIGN KEY (detailsID)
REFERENCES PeopleDetails(detailsID)
)

CREATE TABLE HorseTracking.dbo.Horse (
horseID INT NOT NULL PRIMARY KEY,
genderID INT NOT NULL,
userID INT NOT NULL,
statusID INT NOT NULL,
name varchar(50) NOT NULL,
mother varchar(50) NULL,
father varchar(50) NULL,
birthdate date NULL,
race varchar(50) NULL,
breeder varchar(50) NULL,
passport varchar(50) NULL,
photo varchar(MAX),
status bit NOT NULL,
FOREIGN KEY (statusID)
REFERENCES HorseStatus(statusID),
FOREIGN KEY (genderID)
REFERENCES HorseGender(genderID),
FOREIGN KEY (userID)
REFERENCES UserAcount(userID)
)


CREATE TABLE HorseTracking.dbo.CustomNotification (
notificationID INT NOT NULL PRIMARY KEY,
userID int NOT NULL,
title varchar(50) NOT NULL,
description varchar(50) NULL,
sendDate date NOT NULL,
createdDate date NOT NULL,
turnOn bit NOT NULL,
FOREIGN KEY (userID)
REFERENCES UserAcount(userID)
)

CREATE TABLE HorseTracking.dbo.Visit (
careID INT NOT NULL PRIMARY KEY,
doctorID int NOT NULL,
horseID int NOT NULL,
visitDate datetime NOT NULL,
summary varchar(MAX) NULL,
artefactImage varchar(MAX) NULL,
FOREIGN KEY (doctorID)
REFERENCES Doctor(doctorID),
FOREIGN KEY (horseID)
REFERENCES Horse(horseID)
)

CREATE TABLE HorseTracking.dbo.Shared (
sharedID INT NOT NULL PRIMARY KEY,
horseID int NOT NULL,
userShareID int NOT NULL,
userScanID int NOT NULL,
endDate datetime NOT NULL,
code varchar(50) NOT NULL,
FOREIGN KEY (horseID)
REFERENCES Horse(horseID),
FOREIGN KEY (userShareID)
REFERENCES UserAcount(userID),
FOREIGN KEY (userScanID)
REFERENCES UserAcount(userID)
)


CREATE TABLE HorseTracking.dbo.Eat (
ID INT NOT NULL PRIMARY KEY,
nutritionPlanID int NOT NULL,
horseID int NOT NULL,
FOREIGN KEY (horseID)
REFERENCES Horse(horseID),
FOREIGN KEY (nutritionPlanID)
REFERENCES NutritionPlan(nutritionPlanID)
)

CREATE TABLE HorseTracking.dbo.Activity (
activityID INT NOT NULL PRIMARY KEY,
userID int NOT NULL,
activityTypeID int NOT NULL,
trainerID int NOT NULL,
horseID int NOT NULL,
date datetime NOT NULL,
description varchar(MAX) NULL,
time int NULL,
intensivity int NOT NULL,
satisfaction int  NOT NULL
FOREIGN KEY (userID)
REFERENCES UserAcount(userID),
FOREIGN KEY (activityTypeID)
REFERENCES ActivityType(activityTypeID),
FOREIGN KEY (trainerID)
REFERENCES UserAcount(userID),
FOREIGN KEY (horseID)
REFERENCES Horse(horseID)
)

CREATE TABLE HorseTracking.dbo.TakePart (
ID INT NOT NULL PRIMARY KEY,
horseID int NOT NULL,
competitionID int NOT NULL,
takePart bit,
FOREIGN KEY (horseID)
REFERENCES Horse(horseID),
FOREIGN KEY (competitionID)
REFERENCES Competition(competitionID)
)