
select [PS-VRSTEL-NO] from [EKS-PUNTESTATE]

select * from [EKS-PUNTESTATE] where [PS-Msheet] = '032222631'

select * from Vraagleer where Vakkode = 'ENGHL'
 
--//Select Vakkode, Vrstelno, vraestelnommer = paper number, getalvraeopvraestel = NumOfQuestions

select p.[PS-Msheet], p.[PS-VAKKODE], v.Vakkode, v.VraestelNommer, v.GetalVraeOpVraestel as NumOfQuestions
from [EKS-PUNTESTATE] p
join Vraagleer v on p.[PS-VAKKODE] = v.Vakkode
where [PS-Msheet] = '032222637';


select * from Users where UserName = 'Abbas, Tasmeer'
select * from PasswordResetRequests

exec sp_updatestats	

select * from dbo.Wagwoord_888_Vaslegging

CREATE TABLE PasswordResetRequests (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(50) NOT NULL,
    RequestDateTime DATETIME NOT NULL,
    ResetToken NVARCHAR(255) NOT NULL,
    ResetTokenExpiry DATETIME NOT NULL,
    CONSTRAINT FK_PasswordResetRequests_Users FOREIGN KEY (UserName) REFERENCES Users(UserName)
);




ALTER TABLE Users
ADD IsPasswordResetRequested BIT NOT NULL DEFAULT 0,
    IsPasswordReset BIT NOT NULL DEFAULT 0,
    ResetToken NVARCHAR(255),
    ResetTokenExpiry DATETIME,
    NewPassword NVARCHAR(255);

ALTER TABLE Users
DROP COLUMN NewPassword;
