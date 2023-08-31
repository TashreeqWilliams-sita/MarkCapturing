SELECT * FROM Vraagleer

select * from [EKS-PUNTESTATE]

select * from [EKS-PUNTESTATE] where [EKS-PUNTESTATE].[PS-Msheet] = '0332222631'

select [PS-Msheet], Vakkode, GetalVraeOpVraestel as giveitaname
from [EKS-PUNTESTATE] itsnamepunte
join Vraagleer itsnamevrag on itsnamepunte.[PS-VAKKODE] = itsnamevrag.Vakkode
where [PS-Msheet] = '0332222631'

select * from [User]