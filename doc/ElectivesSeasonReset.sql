SET XACT_ABORT ON
BEGIN TRANSACTION

	UPDATE dbo.ApplicationSettings
		SET
			SubjectRegistrationAllowedFrom = '2025-07-01 18:00',
			SubjectRegistrationAllowedTo = '2025-07-01 18:00'
		WHERE (Id = -1)

	DELETE FROM dbo.StudentSubjectRegistration

	-- Posun vazby ročníku na AAD skupinu
	UPDATE dbo.Grade SET AadGroupId = 'TODO' WHERE Id = -1 -- prima
	UPDATE dbo.Grade SET AadGroupId = 'b2aff005-e445-497c-8483-f3f4ea92b26b' WHERE Id = -2 -- sekunda
	UPDATE dbo.Grade SET AadGroupId = 'c237c715-8941-41db-a147-53e1bebb07cd' WHERE Id = -3 -- tercie
	UPDATE dbo.Grade SET AadGroupId = '77028406-7646-43d8-9f61-2a06f089891c' WHERE Id = -4 -- kvarta
	UPDATE dbo.Grade SET AadGroupId = '85aa6673-47ce-4910-b0ca-e7e03a46a70b' WHERE Id = -5 -- kvinta
	UPDATE dbo.Grade SET AadGroupId = '5fca5418-0c1f-4f57-9a0a-715bff302d63' WHERE Id = -6 -- sexta
	UPDATE dbo.Grade SET AadGroupId = 'e1291dff-a6c6-474c-8e6a-1d0c22c494ad' WHERE Id = -7 -- seprima
	UPDATE dbo.Grade SET AadGroupId = '25a6b0d1-7083-4388-9135-6a56b21e1130' WHERE Id = -8 -- oktáva

	-- Vymazání bývalých oktavánů (soft-delete)
	UPDATE dbo.Student SET Deleted = GETDATE() WHERE GradeId = -8

	-- Posun existujících studentů o ročník
	-- (Údaj se aktualizuje při přístupu studenta na intranet, ale pokud to neposuneme, tak se pak motají v seznamech stará data studentů, co se ještě nepřihlásili.)
	UPDATE dbo.Student SET GradeId = GradeId - 1 WHERE (Deleted IS NULL) AND (GradeId <> -8)

	-- Vymazání (soft-delete) uživatelských účtů studentů, kteří jsou smazáni
	UPDATE dbo.[User] SET Deleted = GETDATE()
		WHERE
			(Deleted IS NULL)
			AND (StudentId IN (SELECT Id FROM dbo.Student WHERE Deleted IS NOT NULL))

ROLLBACK TRANSACTION

