CREATE PROCEDURE [dbo].[Profile_Insert]
	@Id int OUTPUT,
	@Name nvarchar(20),
	@NameSet varchar(max)
AS
BEGIN
	INSERT INTO dbo.Profiles ( 
	Name, 
	NameSet)
	VALUES (
	@Name, 
	@NameSet)
END;
GO