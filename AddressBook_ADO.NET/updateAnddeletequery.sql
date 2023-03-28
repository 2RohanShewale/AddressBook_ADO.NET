CREATE PROCEDURE SpDeleteByFirstLastName
(
	@FirstName VARCHAR(20),
	@LastName VARCHAR(20)
)
AS BEGIN
DELETE FROM Contacts WHERE FirstName = @FirstName AND LastName = @LastName

End

CREATE PROCEDURE SpUpdateContact
(
	@FirstName VARCHAR(20),
	@LastName VARCHAR(20)
)
AS BEGIN
UPDATE Contacts SET FirstName = @FirstName WHERE LastName = @LastName

END
