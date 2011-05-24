
/* DELETE ALL REGISTS IF EXISTS*/
DELETE FROM [LI4].[dbo].[user];
GO

/* CREATE NEW REGISTS */
INSERT INTO [LI4].[dbo].[user] VALUES ('simple_database' ,'simple_database' ,'miguelpintodacosta@gmail.com',CURRENT_TIMESTAMP);
INSERT INTO [LI4].[dbo].[user] VALUES ('extra_database' ,'extra_database' ,'miguelpintodacosta@gmail.com',CURRENT_TIMESTAMP);
INSERT INTO [LI4].[dbo].[user] VALUES ('miguelcosta' ,'83' ,'miguelpintodacosta@gmail.com',CURRENT_TIMESTAMP);
INSERT INTO [LI4].[dbo].[user] VALUES ('hugofrade' ,'102' ,'emanspace@gmail.com',CURRENT_TIMESTAMP);
INSERT INTO [LI4].[dbo].[user] VALUES ('anasampaio' ,'97' ,'anaisamp@gmail.com',CURRENT_TIMESTAMP);
INSERT INTO [LI4].[dbo].[user] VALUES ('tiagoabreu' ,'fcp' ,'tiagoalvesabreu@gmail.com',CURRENT_TIMESTAMP);
GO


