
/* DELETE ALL REGISTS IF EXISTS*/
DELETE FROM [LI4].[dbo].[caracteristics];

/* CREATE NEW REGISTS */
INSERT INTO [LI4].[dbo].[caracteristics] VALUES(1,'bool','Compatible operating systems',null,null);
INSERT INTO [LI4].[dbo].[caracteristics] VALUES(2,'numeric','Cost',null,null);
INSERT INTO [LI4].[dbo].[caracteristics] VALUES(3,'qualitative','Interaction with the user','very bad',1);
INSERT INTO [LI4].[dbo].[caracteristics] VALUES(3,'qualitative','Interaction with the user','bad',2);
INSERT INTO [LI4].[dbo].[caracteristics] VALUES(3,'qualitative','Interaction with the user','acceptable',3);
INSERT INTO [LI4].[dbo].[caracteristics] VALUES(3,'qualitative','Interaction with the user','good',4);
INSERT INTO [LI4].[dbo].[caracteristics] VALUES(3,'qualitative','Interaction with the user','very good',5);
INSERT INTO [LI4].[dbo].[caracteristics] VALUES(3,'qualitative','Interaction with the user','excellent',6);
INSERT INTO [LI4].[dbo].[caracteristics] VALUES(4,'bool','Manuals and Tutorials',null,null);
INSERT INTO [LI4].[dbo].[caracteristics] VALUES(5,'bool','Examples through applications',null,null);
INSERT INTO [LI4].[dbo].[caracteristics] VALUES(6,'bool','on-line Help',null,null);
INSERT INTO [LI4].[dbo].[caracteristics] VALUES(7,'bool','Free version',null,null);

GO

