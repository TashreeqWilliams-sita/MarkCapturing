select [PS-VRSTEL-NO] from [EKS-PUNTESTATE]

select * from [EKS-PUNTESTATE] where [PS-Msheet] = '032222631'

select * from Vraagleer where Vakkode = 'ENGHL'

--//Select Vakkode, Vrstelno, vraestelnommer = paper number, getalvraeopvraestel = NumOfQuestions

select p.[PS-Msheet], p.[PS-VAKKODE], v.Vakkode, v.VraestelNommer, v.GetalVraeOpVraestel as NumOfQuestions
from [EKS-PUNTESTATE] p
join Vraagleer v on p.[PS-VAKKODE] = v.Vakkode
where [PS-Msheet] = '032222637';

exec sp_updatestats	