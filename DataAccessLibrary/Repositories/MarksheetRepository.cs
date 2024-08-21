using DTOs;
using System.Collections.Generic;
using System;
using System.Linq;
using DataAccessLibrary.Interfaces;
using AutoMapper;
//using System.Data.Entity;
using System.Reflection;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Runtime.Caching;

namespace DataAccessLibrary.Repositories
{
    //In the repository we will handle database operations related to our EKS_PUNTESTATE and Vraagleer tables
    //We need to get by marksheet number
    //get all records based on our marksheet number
    //get  subject code, number of questions and paper number from two tables second table is Vraagleer
    // Note PUNTESTATE is SCORESHEET
    //Once we finish with our repository we move to the Views and implement interfaces

    public class MarksheetRepository : IMarksheetRepository
    {
		#region PrivateProperties
		private readonly NSC_VraagpunteStelselEntities dbContext;
		MarksheetDTO marksheetDTO = new MarksheetDTO();
		#endregion

		#region Constructor
		public MarksheetRepository(NSC_VraagpunteStelselEntities context)
        {
            this.dbContext = context;
        }
		#region GetMarksheetDetails old
		//public MarksheetDTO GetMarksheetDetailsd(string psMsheet)
		//{
		//	// This function assumes dbContext is set up to execute raw SQL queries.

		//	// Constructing the SQL query using UNION ALL to check across multiple tables
		//	string query = @"
		//      SELECT TOP 1 'ACCN10' AS TableOrigin, [PS-Msheet] AS PS_Msheet, [PS-KODE] AS PS_KODE, [PS-ID-NO] AS PS_ID_NO, [PS-EKS-DAT] AS PS_EKS_DAT
		//      FROM [dbo].[EKS-VraagPunte-A-ACCN10] WHERE [PS-Msheet] = {0}
		//      UNION ALL
		//      SELECT TOP 1 'ACCN20', [PS-Msheet] AS PS_Msheet, [PS-KODE] AS PS_KODE, [PS-ID-NO] AS PS_ID_NO, [PS-EKS-DAT] AS PS_EKS_DAT
		//      FROM [dbo].[EKS-VraagPunte-A-ACCN20] WHERE [PS-Msheet] = {0}
		//      UNION ALL
		//      SELECT TOP 1 'ACCNZ10', [PS-Msheet] AS PS_Msheet, [PS-KODE] AS PS_KODE, [PS-ID-NO] AS PS_ID_NO, [PS-EKS-DAT] AS PS_EKS_DAT
		//      FROM [dbo].[EKS-VraagPunte-A-ACCNZ10] WHERE [PS-Msheet] = {0}
		//      UNION ALL
		//      SELECT TOP 1 'AFRFA10', [PS-Msheet] AS PS_Msheet, [PS-KODE] AS PS_KODE, [PS-ID-NO] AS PS_ID_NO, [PS-EKS-DAT] AS PS_EKS_DAT
		//      FROM [dbo].[EKS-VraagPunte-A-AFRFA10] WHERE [PS-Msheet] = {0}
		//      UNION ALL
		//      SELECT TOP 1 'AFRFA20', [PS-Msheet] AS PS_Msheet, [PS-KODE] AS PS_KODE, [PS-ID-NO] AS PS_ID_NO, [PS-EKS-DAT] AS PS_EKS_DAT
		//      FROM [dbo].[EKS-VraagPunte-A-AFRFA20] WHERE [PS-Msheet] = {0}
		//      UNION ALL
		//      SELECT TOP 1 'AFRFA30', [PS-Msheet] AS PS_Msheet, [PS-KODE] AS PS_KODE, [PS-ID-NO] AS PS_ID_NO, [PS-EKS-DAT] AS PS_EKS_DAT
		//      FROM [dbo].[EKS-VraagPunte-A-AFRFA30] WHERE [PS-Msheet] = {0}
		//      UNION ALL
		//      SELECT TOP 1 'AFRHL10', [PS-Msheet] AS PS_Msheet, [PS-KODE] AS PS_KODE, [PS-ID-NO] AS PS_ID_NO, [PS-EKS-DAT] AS PS_EKS_DAT
		//      FROM [dbo].[EKS-VraagPunte-A-AFRHL10] WHERE [PS-Msheet] = {0}
		//      UNION ALL
		//      SELECT TOP 1 'AFRHL20', [PS-Msheet] AS PS_Msheet, [PS-KODE] AS PS_KODE, [PS-ID-NO] AS PS_ID_NO, [PS-EKS-DAT] AS PS_EKS_DAT
		//      FROM [dbo].[EKS-VraagPunte-A-AFRHL20] WHERE [PS-Msheet] = {0}
		//      UNION ALL
		//      SELECT TOP 1 'AFRHL30', [PS-Msheet] AS PS_Msheet, [PS-KODE] AS PS_KODE, [PS-ID-NO] AS PS_ID_NO, [PS-EKS-DAT] AS PS_EKS_DAT
		//      FROM [dbo].[EKS-VraagPunte-A-AFRHL30] WHERE [PS-Msheet] = {0}
		//      -- Continue adding SELECT statements for each table
		//      ORDER BY TableOrigin;";

		//	// Execute the SQL query
		//	var records = dbContext.Database.SqlQuery<MarksheetDTO>(query, psMsheet).ToList();

		//	if (records != null)
		//	{
		//		return new MarksheetDTO
		//		{
		//			PS_Msheet = records.First().PS_Msheet,
		//			PS_KODE = records.First().PS_KODE,
		//			PS_ID_NO = records.First().PS_ID_NO, 
		//			PS_EKS_DAT = records.First().PS_EKS_DAT,
		//			Status = records.First().Status,
		//			VraestelKode = records.First().VraestelKode,
		//			VraestelNaam = records.First().VraestelNaam,
		//			Sentrum = records.First().Sentrum,
		//			// Add other fields as needed
		//		};
		//	}

		//	return null; 
		//}
		#endregion
		public MarksheetDTO GetMarksheetDetails(string psMsheet)
		{
			QuestionPaperRepository questionPaperRepository = new QuestionPaperRepository(dbContext);
			var getMarksheetTopValues =  GetMarksheetTopDetails(psMsheet);
			var questionPaperDetails = questionPaperRepository.GetQuestionPaperDetails(getMarksheetTopValues.PS_EKS_DAT.ToString(), getMarksheetTopValues.VraestelKode);
			//Type dbContextType = dbContext.GetType();
			PropertyInfo[] properties = dbContext.GetType().GetProperties();

			foreach (var property in properties)
			{
				Console.WriteLine($"Property Name: {property.Name}");
				Console.WriteLine($"Property Type: {property.PropertyType}");
				var propertyType = property.PropertyType.GetGenericArguments().FirstOrDefault();
				if (propertyType != null && propertyType.Name.Contains("VraagPunte") && propertyType.GetProperties().Any(p => p.Name == "PS_Msheet"))
				{
					// Found a DbSet<T> property with a PS_Msheet column
					dynamic dbSet = property.GetValue(dbContext, null);
					var dbSetType = typeof(DbSet<>).MakeGenericType(propertyType);
					// Query the DbSet<T> to find the psMsheet
					//Func<dynamic, bool> predicate = m => m.PS_Msheet == psMsheet;
					Func<dynamic, bool> predicate = m => m.PS_Msheet == psMsheet && m.PS_ID_NO == getMarksheetTopValues.PS_ID_NO;

					// Query the DbSet<T> to find the psMsheet
					var castedDbSet = Convert.ChangeType(dbSet, dbSetType);
					
					var enumerableDbSet = ((IEnumerable<object>)castedDbSet).Select(x => (dynamic)x);
					var marksheet = enumerableDbSet.FirstOrDefault(predicate);

					if (marksheet != null)
					{
						
						foreach (var prop in typeof(MarksheetDTO).GetProperties())
						{
							if (prop.Name.StartsWith("PS_VRAAG_"))
							{
								// Get the corresponding property from the marksheet object
								var marksheetProp = marksheet.GetType().GetProperty(prop.Name);

								// If the property exists on the marksheet object
								if (marksheetProp != null)
								{
									// Get the value from the marksheet object
									object marksheetPropValue = marksheetProp.GetValue(marksheet);

									// Assign the value or a default value (0 in this case) to the MarksheetDTO property
									prop.SetValue(marksheetDTO, (marksheetPropValue ?? 0).ToString().Trim() != "" ? Convert.ToSingle(marksheetPropValue) : (Single?)null);
								}
							
							}
						}

						return marksheetDTO;
					}
				}
			}
			return null;
		}
		#region Map entity old
		//private MarksheetDTO MapEntityToDTO(object entity, Type entityType)
		//{
		//	// Get all properties of the entity type
		//	var properties = entityType.GetProperties();

		//	// Create a new DTO instance
		//	var dto = new MarksheetDTO();

		//	// Map each property from the entity to the corresponding property in the DTO
		//	foreach (var property in properties)
		//	{
		//		// Check if the property has a corresponding property in the DTO
		//		var dtoProperty = dto.GetType().GetProperty(property.Name);
		//		if (dtoProperty != null)
		//		{
		//			// Map the value from the entity to the DTO property
		//			dtoProperty.SetValue(dto, property.GetValue(entity));
		//		}
		//	}

		//	return dto;
		//}
		#endregion
		#region  working GetExamNumberList
		//      public List<MarksheetDTO> GetExamNumberList(string psMsheets)
		//{
		//	QuestionPaperRepository questionPaperRepository = new QuestionPaperRepository(dbContext);
		//	var marksheetTopValues = GetMarksheetTopDetails(psMsheets);
		//	MarksheetDTO marksheetResultValue = GetMarksheetDetails(psMsheets);
		//	var questionPaperDetails = questionPaperRepository.GetQuestionPaperDetails(marksheetTopValues.PS_EKS_DAT.ToString(), marksheetTopValues.VraestelKode);

		//	List<MarksheetDTO> marksheetDTOs = new List<MarksheetDTO>();

		//	bool found = false;
		//	foreach (var property in dbContext.GetType().GetProperties())
		//	{
		//		var propertyType = property.PropertyType.GetGenericArguments().FirstOrDefault();
		//		if (propertyType != null && propertyType.Name.Contains("VraagPunte") && propertyType.GetProperties().Any(p => p.Name == "PS_Msheet"))
		//		{
		//			// look for a DbSet<T> property with a PS_Msheet column
		//			dynamic dbSet = property.GetValue(dbContext, null);
		//			var dbSetType = typeof(DbSet<>).MakeGenericType(propertyType);

		//			var enumerableDbSet = ((IEnumerable<object>)dbSet).Select(x => (dynamic)x);



		//			foreach (var marksheet in enumerableDbSet.Where(m => m.PS_Msheet == psMsheets ))
		//			{
		//				var marksheetDTO = new MarksheetDTO
		//				{
		//					PS_Msheet = marksheet.PS_Msheet ?? "",
		//					GetalVraeOpVraestel = questionPaperDetails.GetalVraeOpVraestel,
		//					PS_MarksheetSort = marksheet.PS_MarksheetSort ?? 0,
		//					PS_KAFTOTAAL = marksheet.PS_KAFTOTAAL ?? 0,
		//					PS_VRAESTELPUNT = marksheet.PS_VRAESTELPUNT ?? 0,
		//					PS_ChangedBy = marksheet.PS_ChangedBy ?? "",
		//					PS_DateLastChanged = marksheet.PS_DateLastChanged ?? "",
		//					PS_ID_NO = marksheet.PS_ID_NO ?? "",
		//					PS_GEKONTROLEERDEPUNT = marksheet.PS_GEKONTROLEERDEPUNT ?? 0,
		//					PS_KODE = marksheet.PS_KODE ?? "",
		//					PS_EKS_DAT = marksheet.PS_EKS_DAT ?? 0,

		//				};

		//				foreach (int i in Enumerable.Range(1, int.Parse(marksheetDTO.GetalVraeOpVraestel.ToString())))
		//				{
		//					string propName = $"PS_VRAAG_{i}";
		//					var prop = typeof(MarksheetDTO).GetProperty(propName);

		//					if (prop != null)
		//					{
		//						var marksheetProp = marksheet.GetType().GetProperty(propName);
		//						if (marksheetProp != null)
		//						{
		//							object marksheetPropValue = marksheetProp.GetValue(marksheet);
		//							prop.SetValue(marksheetDTO, (marksheetPropValue ?? 0).ToString().Trim() != "" ? Convert.ToSingle(marksheetPropValue) : (Single?)null);
		//						}
		//					}
		//				}
		//				marksheetDTOs.Add(marksheetDTO);
		//			}
		//			break;
		//		}
		//	}

		//	return marksheetDTOs;

		//}
		#endregion
		#region GetExamNumberList working V2
		//public List<MarksheetDTO> GetExamNumberList(string psMsheets)
		//{
		//    QuestionPaperRepository questionPaperRepository = new QuestionPaperRepository(dbContext);
		//    var marksheetTopValues = GetMarksheetTopDetails(psMsheets);
		//    MarksheetDTO marksheetResultValue = GetMarksheetDetails(psMsheets);
		//    var questionPaperDetails = questionPaperRepository.GetQuestionPaperDetails(marksheetTopValues.PS_EKS_DAT.ToString(), marksheetTopValues.VraestelKode);

		//    List<MarksheetDTO> marksheetDTOs = new List<MarksheetDTO>();

		//    bool found = false;
		//    foreach (var property in dbContext.GetType().GetProperties())
		//    {
		//        var propertyType = property.PropertyType.GetGenericArguments().FirstOrDefault();
		//        if (propertyType != null && propertyType.Name.Contains("VraagPunte") && propertyType.GetProperties().Any(p => p.Name == "PS_Msheet"))
		//        {
		//            // look for a DbSet<T> property with a PS_Msheet column
		//            dynamic dbSet = property.GetValue(dbContext, null);
		//            var dbSetType = typeof(DbSet<>).MakeGenericType(propertyType);
		//            var enumerableDbSet = ((IEnumerable<object>)dbSet).Select(x => (dynamic)x);
		//            // Log the psMsheets value and the count of enumerableDbSet
		//            Console.WriteLine($"psMsheets: {psMsheets}");
		//            Console.WriteLine($"enumerableDbSet count: {enumerableDbSet.Count()}");


		//            foreach (var marksheet in enumerableDbSet.Where(m => m.PS_Msheet == psMsheets))
		//            {
		//                var marksheetDTO = new MarksheetDTO
		//                {
		//                    PS_Msheet = marksheet.PS_Msheet ?? "",
		//                    GetalVraeOpVraestel = questionPaperDetails.GetalVraeOpVraestel,
		//                    PS_MarksheetSort = marksheet.PS_MarksheetSort ?? 0,
		//                    PS_KAFTOTAAL = marksheet.PS_KAFTOTAAL ?? 0,
		//                    PS_VRAESTELPUNT = marksheet.PS_VRAESTELPUNT ?? 0,
		//                    PS_ChangedBy = marksheet.PS_ChangedBy ?? "",
		//                    PS_DateLastChanged = marksheet.PS_DateLastChanged ?? "",
		//                    PS_ID_NO = marksheet.PS_ID_NO ?? "",
		//                    PS_GEKONTROLEERDEPUNT = marksheet.PS_GEKONTROLEERDEPUNT ?? 0,
		//                    PS_KODE = marksheet.PS_KODE ?? "",
		//                    PS_EKS_DAT = marksheet.PS_EKS_DAT ?? 0,
		//                    GetalKombinasiesVanKeuseVrae = questionPaperDetails.GetalKombinasiesVanKeuseVrae
		//                };

		//                for (int i = 1; i <= int.Parse(marksheetDTO.GetalVraeOpVraestel.ToString()); i++)
		//                {
		//                    string propName = $"PS_VRAAG_{i}";
		//                    var prop = typeof(MarksheetDTO).GetProperty(propName);
		//                    if (prop != null)
		//                    {
		//                        var marksheetProp = marksheet.GetType().GetProperty(propName);
		//                        if (marksheetProp != null)
		//                        {
		//                            object marksheetPropValue = marksheetProp.GetValue(marksheet);

		//                            if (marksheetDTO.GetalKombinasiesVanKeuseVrae > 0)
		//                            {
		//                                // Handle multiple-choice questions
		//                                HandleMultipleChoiceQuestions(marksheetDTO, marksheet, i, questionPaperDetails);
		//                            }
		//                            else
		//                            {
		//                                // Handle non-multiple-choice questions
		//                                prop.SetValue(marksheetDTO, (marksheetPropValue ?? 0).ToString().Trim() != "" ? Convert.ToSingle(marksheetPropValue) : (Single?)null);
		//                            }
		//                        }
		//                    }
		//                }

		//                marksheetDTOs.Add(marksheetDTO);
		//                //marksheetDTOs.Add(marksheetDTO);
		//            }

		//        }

		//    }

		//    return marksheetDTOs;
		//}
		#endregion
		#region Too slow
		//      public List<MarksheetDTO> GetExamNumberList(string psMsheets)
		//{
		//	QuestionPaperRepository questionPaperRepository = new QuestionPaperRepository(dbContext);
		//	var marksheetTopValues = GetMarksheetTopDetails(psMsheets);
		//	MarksheetDTO marksheetResultValue = GetMarksheetDetails(psMsheets);
		//	var questionPaperDetails = questionPaperRepository.GetQuestionPaperDetails(marksheetTopValues.PS_EKS_DAT.ToString(), marksheetTopValues.VraestelKode);

		//	List<MarksheetDTO> marksheetDTOs = new List<MarksheetDTO>();

		//	// Create a dictionary to map table names to DbSet properties
		//	var tableDbSets = new Dictionary<string, object>
		//	{
		//		{ "EKS-VraagPunte-A-ACCN10", dbContext.EKS_VraagPunte_A_ACCN10},
		//		{ "EKS-VraagPunte-A-ACCN20", dbContext.EKS_VraagPunte_A_ACCN20},
		//		{ "EKS-VraagPunte-A-ACCNZ10", dbContext.EKS_VraagPunte_A_ACCNZ10},
		//		{ "EKS-VraagPunte-A-AFRFA10", dbContext.EKS_VraagPunte_A_AFRFA10},
		//		{ "EKS-VraagPunte-A-AFRFA20", dbContext.EKS_VraagPunte_A_AFRFA20},
		//		{ "EKS-VraagPunte-A-AFRFA30", dbContext.EKS_VraagPunte_A_AFRFA30},
		//		{ "EKS-VraagPunte-A-AFRHL10", dbContext.EKS_VraagPunte_A_AFRHL10},
		//		{ "EKS-VraagPunte-A-AFRHL20", dbContext.EKS_VraagPunte_A_AFRHL20},
		//		{ "EKS-VraagPunte-A-AFRHL30", dbContext.EKS_VraagPunte_A_AFRHL30},
		//		{ "EKS-VraagPunte-A-AFRSA10", dbContext.EKS_VraagPunte_A_AFRSA10},
		//		{ "EKS-VraagPunte-A-AFRSA20", dbContext.EKS_VraagPunte_A_AFRSA20},
		//		{ "EKS-VraagPunte-A-AFRSA30", dbContext.EKS_VraagPunte_A_AFRSA30},
		//		{ "EKS-VraagPunte-A-AGRM10", dbContext.EKS_VraagPunte_A_AGRM10},
		//		{ "EKS-VraagPunte-A-AGRS10", dbContext.EKS_VraagPunte_A_AGRS10},
		//		{ "EKS-VraagPunte-A-AGRS20", dbContext.EKS_VraagPunte_A_AGRS20},
		//		{ "EKS-VraagPunte-A-AGRT10", dbContext.EKS_VraagPunte_A_AGRT10},
		//		{ "EKS-VraagPunte-A-ARBSA10", dbContext.EKS_VraagPunte_A_ARBSA10},
		//		{ "EKS-VraagPunte-A-ARBSA20", dbContext.EKS_VraagPunte_A_ARBSA20},
		//		{ "EKS-VraagPunte-A-BSTD10", dbContext.EKS_VraagPunte_A_BSTD10},
		//		{ "EKS-VraagPunte-A-BSTD20", dbContext.EKS_VraagPunte_A_BSTD20},
		//		{ "EKS-VraagPunte-A-BSTDZ10", dbContext.EKS_VraagPunte_A_BSTDZ10},
		//		{ "EKS-VraagPunte-A-CATN10", dbContext.EKS_VraagPunte_A_CATN10},
		//		{ "EKS-VraagPunte-A-CATN20", dbContext.EKS_VraagPunte_A_CATN20},
		//		{ "EKS-VraagPunte-A-CHNSA10", dbContext.EKS_VraagPunte_A_CHNSA10},
		//		{ "EKS-VraagPunte-A-CNST10", dbContext.EKS_VraagPunte_A_CNST10},
		//		{ "EKS-VraagPunte-A-CVTC10", dbContext.EKS_VraagPunte_A_CVTC10},
		//		{ "EKS-VraagPunte-A-CVTV10", dbContext.EKS_VraagPunte_A_CVTV10},
		//		{ "EKS-VraagPunte-A-CVTW10", dbContext.EKS_VraagPunte_A_CVTW10},
		//		{ "EKS-VraagPunte-A-DNCE10", dbContext.EKS_VraagPunte_A_DNCE10},
		//		{ "EKS-VraagPunte-A-DRMA10", dbContext.EKS_VraagPunte_A_DRMA10},
		//		{ "EKS-VraagPunte-A-DSGN10", dbContext.EKS_VraagPunte_A_DSGN10},
		//		{ "EKS-VraagPunte-A-ECON10", dbContext.EKS_VraagPunte_A_ECON10},
		//		{ "EKS-VraagPunte-A-ECON20", dbContext.EKS_VraagPunte_A_ECON20},
		//		{ "EKS-VraagPunte-A-ELTD10", dbContext.EKS_VraagPunte_A_ELTD10},
		//		{ "EKS-VraagPunte-A-ELTE10", dbContext.EKS_VraagPunte_A_ELTE10},
		//		{ "EKS-VraagPunte-A-ELTP10", dbContext.EKS_VraagPunte_A_ELTP10},
		//		{ "EKS-VraagPunte-A-ENGFA10", dbContext.EKS_VraagPunte_A_ENGFA10},
		//		{ "EKS-VraagPunte-A-ENGFA20", dbContext.EKS_VraagPunte_A_ENGFA20},
		//		{ "EKS-VraagPunte-A-ENGFA30", dbContext.EKS_VraagPunte_A_ENGFA30},
		//		{ "EKS-VraagPunte-A-ENGHL10", dbContext.EKS_VraagPunte_A_ENGHL10},
		//		{ "EKS-VraagPunte-A-ENGHL20", dbContext.EKS_VraagPunte_A_ENGHL20},
		//		{ "EKS-VraagPunte-A-ENGHL30", dbContext.EKS_VraagPunte_A_ENGHL30},
		//		{ "EKS-VraagPunte-A-ENGSA10", dbContext.EKS_VraagPunte_A_ENGSA10},
		//		{ "EKS-VraagPunte-A-ENGSA20", dbContext.EKS_VraagPunte_A_ENGSA20},
		//		{ "EKS-VraagPunte-A-ENGSA30", dbContext.EKS_VraagPunte_A_ENGSA30},
		//		{ "EKS-VraagPunte-A-EQNS10", dbContext.EKS_VraagPunte_A_EQNS10},
		//		{ "EKS-VraagPunte-A-FRHSA10", dbContext.EKS_VraagPunte_A_FRHSA10},
		//		{ "EKS-VraagPunte-A-FRHSA20", dbContext.EKS_VraagPunte_A_FRHSA20},
		//		{ "EKS-VraagPunte-A-GEOG10", dbContext.EKS_VraagPunte_A_GEOG10},
		//		{ "EKS-VraagPunte-A-GEOG20", dbContext.EKS_VraagPunte_A_GEOG20},
		//		{ "EKS-VraagPunte-A-GRDS10", dbContext.EKS_VraagPunte_A_GRDS10},
		//		{ "EKS-VraagPunte-A-GRDS20", dbContext.EKS_VraagPunte_A_GRDS20},
		//		{ "EKS-VraagPunte-A-GRMSA10", dbContext.EKS_VraagPunte_A_GRMSA10},
		//		{ "EKS-VraagPunte-A-GRMSA20", dbContext.EKS_VraagPunte_A_GRMSA20},
		//		{ "EKS-VraagPunte-A-HBRSA10", dbContext.EKS_VraagPunte_A_HBRSA10},
		//		{ "EKS-VraagPunte-A-HBRSA20", dbContext.EKS_VraagPunte_A_HBRSA20},
		//		{ "EKS-VraagPunte-A-HIST10", dbContext.EKS_VraagPunte_A_HIST10},
		//		{ "EKS-VraagPunte-A-HIST20", dbContext.EKS_VraagPunte_A_HIST20},
		//		{ "EKS-VraagPunte-A-HOSP10", dbContext.EKS_VraagPunte_A_HOSP10},
		//		{ "EKS-VraagPunte-A-INFT10", dbContext.EKS_VraagPunte_A_INFT10},
		//		{ "EKS-VraagPunte-A-INFT20", dbContext.EKS_VraagPunte_A_INFT20},
		//		{ "EKS-VraagPunte-A-LFSC10", dbContext.EKS_VraagPunte_A_LFSC10},
		//		{ "EKS-VraagPunte-A-LFSC20", dbContext.EKS_VraagPunte_A_LFSC20},
		//		{ "EKS-VraagPunte-A-MANSA10", dbContext.EKS_VraagPunte_A_MANSA10},
		//		{ "EKS-VraagPunte-A-MANSA20", dbContext.EKS_VraagPunte_A_MANSA20},
		//		{ "EKS-VraagPunte-A-MATH10", dbContext.EKS_VraagPunte_A_MATH10},
		//		{ "EKS-VraagPunte-A-MATH20", dbContext.EKS_VraagPunte_A_MATH20},
		//		{ "EKS-VraagPunte-A-MCTA10", dbContext.EKS_VraagPunte_A_MCTA10},
		//		{ "EKS-VraagPunte-A-MCTF10", dbContext.EKS_VraagPunte_A_MCTF10},
		//		{ "EKS-VraagPunte-A-MCTW10", dbContext.EKS_VraagPunte_A_MCTW10},
		//		{ "EKS-VraagPunte-A-MLIT10", dbContext.EKS_VraagPunte_A_MLIT10},
		//		{ "EKS-VraagPunte-A-MLIT20", dbContext.EKS_VraagPunte_A_MLIT20},
		//		{ "EKS-VraagPunte-A-MRSC10", dbContext.EKS_VraagPunte_A_MRSC10},
		//		{ "EKS-VraagPunte-A-MRSC20", dbContext.EKS_VraagPunte_A_MRSC20},
		//		{ "EKS-VraagPunte-A-MRTE10", dbContext.EKS_VraagPunte_A_MRTE10},
		//		{ "EKS-VraagPunte-A-MUSC10", dbContext.EKS_VraagPunte_A_MUSC10},
		//		{ "EKS-VraagPunte-A-RLGS10", dbContext.EKS_VraagPunte_A_RLGS10},
		//		{ "EKS-VraagPunte-A-RLGS20", dbContext.EKS_VraagPunte_A_RLGS20},
		//		{ "EKS-VraagPunte-A-RLGSZ10", dbContext.EKS_VraagPunte_A_RLGSZ10},
		//		{ "EKS-VraagPunte-A-RLGSZ20", dbContext.EKS_VraagPunte_A_RLGSZ20},
		//		{ "EKS-VraagPunte-A-SASHL10", dbContext.EKS_VraagPunte_A_SASHL10},
		//		{ "EKS-VraagPunte-A-SASHL20", dbContext.EKS_VraagPunte_A_SASHL20},
		//		{ "EKS-VraagPunte-A-SASHL30", dbContext.EKS_VraagPunte_A_SASHL30},
		//		{ "EKS-VraagPunte-A-SESHL10", dbContext.EKS_VraagPunte_A_SESHL10},
		//		{ "EKS-VraagPunte-A-SESHL20", dbContext.EKS_VraagPunte_A_SESHL20},
		//		{ "EKS-VraagPunte-A-SESHL30", dbContext.EKS_VraagPunte_A_SESHL30},
		//		{ "EKS-VraagPunte-A-SPES10", dbContext.EKS_VraagPunte_A_SPES10},
		//		{ "EKS-VraagPunte-A-SPNSA10", dbContext.EKS_VraagPunte_A_SPNSA10},
		//		{ "EKS-VraagPunte-A-SPNSA20", dbContext.EKS_VraagPunte_A_SPNSA20},
		//		{ "EKS-VraagPunte-A-TMAT10", dbContext.EKS_VraagPunte_A_TMAT10},
		//		{ "EKS-VraagPunte-A-TMAT20", dbContext.EKS_VraagPunte_A_TMAT20},
		//		{ "EKS-VraagPunte-A-TRNP710", dbContext.EKS_VraagPunte_A_TRNP710},
		//		{ "EKS-VraagPunte-A-TRSM10", dbContext.EKS_VraagPunte_A_TRSM10},
		//		{ "EKS-VraagPunte-A-TSCE10", dbContext.EKS_VraagPunte_A_TSCE10},
		//		{ "EKS-VraagPunte-A-TSCE20", dbContext.EKS_VraagPunte_A_TSCE20},
		//		{ "EKS-VraagPunte-A-URDFA10", dbContext.EKS_VraagPunte_A_URDFA10},
		//		{ "EKS-VraagPunte-A-URDFA20", dbContext.EKS_VraagPunte_A_URDFA20},
		//		{ "EKS-VraagPunte-A-URDFA30", dbContext.EKS_VraagPunte_A_URDFA30},
		//		{ "EKS-VraagPunte-A-URDSA10", dbContext.EKS_VraagPunte_A_URDSA10},
		//		{ "EKS-VraagPunte-A-URDSA20", dbContext.EKS_VraagPunte_A_URDSA20},
		//		{ "EKS-VraagPunte-A-VSLA10", dbContext.EKS_VraagPunte_A_VSLA10},
		//		{ "EKS-VraagPunte-A-XHOFA10", dbContext.EKS_VraagPunte_A_XHOFA10},
		//		{ "EKS-VraagPunte-A-XHOFA20", dbContext.EKS_VraagPunte_A_XHOFA20},
		//		{ "EKS-VraagPunte-A-XHOFA30", dbContext.EKS_VraagPunte_A_XHOFA30},
		//		{ "EKS-VraagPunte-A-XHOHL10", dbContext.EKS_VraagPunte_A_XHOHL10},
		//		{ "EKS-VraagPunte-A-XHOHL20", dbContext.EKS_VraagPunte_A_XHOHL20},
		//		{ "EKS-VraagPunte-A-XHOHL30", dbContext.EKS_VraagPunte_A_XHOHL30},
		//		{ "EKS-VraagPunte-A-XHOSA10", dbContext.EKS_VraagPunte_A_XHOSA10},
		//		{ "EKS-VraagPunte-A-XHOSA20", dbContext.EKS_VraagPunte_A_XHOSA20},
		//		{ "EKS-VraagPunte-A-XHOSA30", dbContext.EKS_VraagPunte_A_XHOSA30},
		//		{ "EKS-VraagPunte-A-ZULFA10", dbContext.EKS_VraagPunte_A_ZULFA10},
		//		{ "EKS-VraagPunte-A-ZULFA20", dbContext.EKS_VraagPunte_A_ZULFA20},
		//		{ "EKS-VraagPunte-A-ZULFA30", dbContext.EKS_VraagPunte_A_ZULFA30},
		//		{ "EKS-VraagPunte-A-ZULHL10", dbContext.EKS_VraagPunte_A_ZULHL10},
		//		{ "EKS-VraagPunte-A-ZULHL20", dbContext.EKS_VraagPunte_A_ZULHL20},
		//		{ "EKS-VraagPunte-A-ZULHL30", dbContext.EKS_VraagPunte_A_ZULHL30},
		//	};

		//	foreach (var tableDbSet in tableDbSets)
		//	{
		//		var enumerableDbSet = ((IEnumerable<object>)tableDbSet.Value).Select(x => (dynamic)x);

		//		foreach (var marksheet in enumerableDbSet.Where(m => m.PS_Msheet == psMsheets))
		//		{
		//			var marksheetDTO = new MarksheetDTO
		//			{
		//				PS_Msheet = marksheet.PS_Msheet ?? "",
		//				GetalVraeOpVraestel = questionPaperDetails.GetalVraeOpVraestel,
		//				PS_MarksheetSort = marksheet.PS_MarksheetSort ?? 0,
		//				PS_KAFTOTAAL = marksheet.PS_KAFTOTAAL ?? 0,
		//				PS_VRAESTELPUNT = marksheet.PS_VRAESTELPUNT ?? 0,
		//				PS_ChangedBy = marksheet.PS_ChangedBy ?? "",
		//				PS_DateLastChanged = marksheet.PS_DateLastChanged ?? "",
		//				PS_ID_NO = marksheet.PS_ID_NO ?? "",
		//				PS_GEKONTROLEERDEPUNT = marksheet.PS_GEKONTROLEERDEPUNT ?? 0,
		//				PS_KODE = marksheet.PS_KODE ?? "",
		//				PS_EKS_DAT = marksheet.PS_EKS_DAT ?? 0,
		//				GetalKombinasiesVanKeuseVrae = questionPaperDetails.GetalKombinasiesVanKeuseVrae
		//			};

		//			for (int i = 1; i <= int.Parse(marksheetDTO.GetalVraeOpVraestel.ToString()); i++)
		//			{
		//				string propName = $"PS_VRAAG_{i}";
		//				var prop = typeof(MarksheetDTO).GetProperty(propName);
		//				if (prop != null)
		//				{
		//					var marksheetProp = marksheet.GetType().GetProperty(propName);
		//					if (marksheetProp != null)
		//					{
		//						object marksheetPropValue = marksheetProp.GetValue(marksheet);
		//						if (marksheetDTO.GetalKombinasiesVanKeuseVrae > 0)
		//						{
		//							// Handle multiple-choice questions
		//							HandleMultipleChoiceQuestions(marksheetDTO, marksheet, i, questionPaperDetails);
		//						}
		//						else
		//						{
		//							// Handle non-multiple-choice questions
		//							prop.SetValue(marksheetDTO, (marksheetPropValue ?? 0).ToString().Trim() != "" ? Convert.ToSingle(marksheetPropValue) : (Single?)null);
		//						}
		//					}
		//				}
		//			}

		//			marksheetDTOs.Add(marksheetDTO);
		//		}
		//	}

		//	return marksheetDTOs;
		//}
		#endregion
		public List<MarksheetDTO> GetExamNumberList(string psMsheets)
		{
			QuestionPaperRepository questionPaperRepository = new QuestionPaperRepository(dbContext);
			var marksheetTopValues = GetMarksheetTopDetails(psMsheets);
			MarksheetDTO marksheetResultValue = GetMarksheetDetails(psMsheets);
			var questionPaperDetails = questionPaperRepository.GetQuestionPaperDetails(marksheetTopValues.PS_EKS_DAT.ToString(), marksheetTopValues.VraestelKode);

			List<MarksheetDTO> marksheetDTOs = new List<MarksheetDTO>();

			bool found = false;
			foreach (var property in dbContext.GetType().GetProperties())
			{
				var propertyType = property.PropertyType.GetGenericArguments().FirstOrDefault();
				if (propertyType != null && propertyType.Name.Contains("VraagPunte") && propertyType.GetProperties().Any(p => p.Name == "PS_Msheet"))
				{
					// look for a DbSet<T> property with a PS_Msheet column
					dynamic dbSet = property.GetValue(dbContext, null);
					var dbSetType = typeof(DbSet<>).MakeGenericType(propertyType);
					var enumerableDbSet = ((IEnumerable<object>)dbSet).Select(x => (dynamic)x);

					foreach (var marksheet in enumerableDbSet.Where(m => m.PS_Msheet == psMsheets))
					{
						var marksheetDTO = new MarksheetDTO
						{
							PS_Msheet = marksheet.PS_Msheet ?? "",
							GetalVraeOpVraestel = questionPaperDetails.GetalVraeOpVraestel,
							PS_MarksheetSort = marksheet.PS_MarksheetSort ?? 0,
							PS_KAFTOTAAL = marksheet.PS_KAFTOTAAL ?? 0,
							PS_VRAESTELPUNT = marksheet.PS_VRAESTELPUNT ?? 0,
							PS_ChangedBy = marksheet.PS_ChangedBy ?? "",
							PS_DateLastChanged = marksheet.PS_DateLastChanged ?? "",
							PS_ID_NO = marksheet.PS_ID_NO ?? "",
							PS_GEKONTROLEERDEPUNT = marksheet.PS_GEKONTROLEERDEPUNT ?? 0,
							PS_KODE = marksheet.PS_KODE ?? "",
							PS_EKS_DAT = marksheet.PS_EKS_DAT ?? 0,
							GetalKombinasiesVanKeuseVrae = questionPaperDetails.GetalKombinasiesVanKeuseVrae
						};

						for (int i = 1; i <= int.Parse(marksheetDTO.GetalVraeOpVraestel.ToString()); i++)
						{
							string propName = $"PS_VRAAG_{i}";
							var prop = typeof(MarksheetDTO).GetProperty(propName);
							if (prop != null)
							{
								var marksheetProp = marksheet.GetType().GetProperty(propName);
								if (marksheetProp != null)
								{
									object marksheetPropValue = marksheetProp.GetValue(marksheet);

									if (marksheetDTO.GetalKombinasiesVanKeuseVrae > 0)
									{
										// Handle multiple-choice questions
										HandleMultipleChoiceQuestions(marksheetDTO, marksheet, i, questionPaperDetails);
									}
									else
									{
										// Handle non-multiple-choice questions
										prop.SetValue(marksheetDTO, (marksheetPropValue ?? 0).ToString().Trim() != "" ? Convert.ToSingle(marksheetPropValue) : (Single?)null);
									}
								}
							}
						}

						marksheetDTOs.Add(marksheetDTO);
					}

					// Cache the MarksheetDTO objects
					CacheMarksheetDTOs(marksheetDTOs);

					// Save changes to the database
					UpdateDatabaseWithChanges(marksheetDTOs, enumerableDbSet);
				}
			}

			return marksheetDTOs;
		}

		private static readonly System.Runtime.Caching.MemoryCache _cache = new System.Runtime.Caching.MemoryCache("MarksheetCache");

		private void CacheMarksheetDTOs(List<MarksheetDTO> marksheetDTOs)
		{
			foreach (var marksheetDTO in marksheetDTOs)
			{
				string cacheKey = $"MarksheetDTO_{marksheetDTO.PS_Msheet}";
				var cacheItemPolicy = new CacheItemPolicy
				{
					AbsoluteExpiration = DateTimeOffset.Now.AddHours(1) // Cache for 1 hour
				};
				_cache.Set(cacheKey, marksheetDTO, cacheItemPolicy);
			}
		}

		public void PopulatePS_ID_NOs(List<MarksheetDTO> marksheetDTOs, List<string> ps_ID_NOs)
		{
			for (int i = 0; i < marksheetDTOs.Count; i++)
			{
				var marksheetDTO = marksheetDTOs[i];
				string cacheKey = $"MarksheetDTO_{marksheetDTO.PS_Msheet}";

				// Retrieve the cached MarksheetDTO object
				MarksheetDTO cachedMarksheetDTO = _cache.Get(cacheKey) as MarksheetDTO;
				if (cachedMarksheetDTO != null)
				{
					// Update the PS_ID_NO property of the cached MarksheetDTO object
					cachedMarksheetDTO.PS_ID_NO = ps_ID_NOs[i];

					// Update the cached MarksheetDTO object
					var cacheItemPolicy = new CacheItemPolicy
					{
						AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
					};
					_cache.Set(cacheKey, cachedMarksheetDTO, cacheItemPolicy);
				}
			}
		}

		private void UpdateDatabaseWithChanges(List<MarksheetDTO> marksheetDTOs, IEnumerable<dynamic> enumerableDbSet)
		{
			foreach (var marksheetDTO in marksheetDTOs)
			{
				var dbEntity = enumerableDbSet.FirstOrDefault(m => m.PS_Msheet == marksheetDTO.PS_Msheet);
				if (dbEntity != null)
				{
					// Update the properties of the database entity with the values from the DTO
					dbEntity.PS_KAFTOTAAL = marksheetDTO.PS_KAFTOTAAL;
					dbEntity.PS_VRAESTELPUNT = marksheetDTO.PS_VRAESTELPUNT;
					dbEntity.PS_ChangedBy = marksheetDTO.PS_ChangedBy;
					dbEntity.PS_DateLastChanged = marksheetDTO.PS_DateLastChanged;
					dbEntity.PS_GEKONTROLEERDEPUNT = marksheetDTO.PS_GEKONTROLEERDEPUNT;

					for (int i = 1; i <= int.Parse(marksheetDTO.GetalVraeOpVraestel.ToString()); i++)
					{
						string propName = $"PS_VRAAG_{i}";
						var prop = typeof(MarksheetDTO).GetProperty(propName);
						if (prop != null)
						{
							var dbEntityProp = dbEntity.GetType().GetProperty(propName);
							if (dbEntityProp != null)
							{
								var value = prop.GetValue(marksheetDTO);
								dbEntityProp.SetValue(dbEntity, value);
							}
						}
					}
				}
			}

			// Save changes to the database
			dbContext.SaveChanges();
		}


		private void HandleMultipleChoiceQuestions(MarksheetDTO marksheetDTO, dynamic marksheet, int currentQuestionNumber, DTOs.VraagleerDTO questionPaperDetails)
		{
			for (int i = 1; i <= marksheetDTO.GetalKombinasiesVanKeuseVrae; i++)
			{
				object startRangeObj = GetPropertyValue(questionPaperDetails, $"KeuseVraeEersteVrgNo{i}");
				object endRangeObj = GetPropertyValue(questionPaperDetails, $"KeuseVraeLaasteVrgNo{i}");
				object numQuestionsObj = GetPropertyValue(questionPaperDetails, $"KeuseVraeGetalVrae{i}");

				int startRange = TryParseInt(startRangeObj);
				int endRange = TryParseInt(endRangeObj);
				int numQuestions = TryParseInt(numQuestionsObj);

				if (currentQuestionNumber >= startRange && currentQuestionNumber <= endRange)
				{
					List<int> validQuestionNumbers = Enumerable.Range(startRange, endRange - startRange + 1).ToList();
					List<int> processedQuestionNumbers = new List<int>();

					for (int j = 0; j < numQuestions; j++)
					{
						int nextValidQuestionNumber = validQuestionNumbers.FirstOrDefault(qn => GetPropertyValue(marksheet, $"PS_VRAAG_{qn}") != null);
						if (nextValidQuestionNumber != 0 && nextValidQuestionNumber <= marksheetDTO.GetalVraeOpVraestel)
						{
							string validPropName = $"PS_VRAAG_{nextValidQuestionNumber}";
							var validProp = typeof(MarksheetDTO).GetProperty(validPropName);
							if (validProp != null)
							{
								object validPropValue = GetPropertyValue(marksheet, validPropName);
								validProp.SetValue(marksheetDTO, (validPropValue ?? 0).ToString().Trim() != "" ? Convert.ToSingle(validPropValue) : (Single?)null);

								// Remove the processed question number from the list
								validQuestionNumbers.Remove(nextValidQuestionNumber);
								processedQuestionNumbers.Add(nextValidQuestionNumber);

								// Exit the loop if nextValidQuestionNumber is equal to marksheetDTO.GetalVraeOpVraestel
								if (nextValidQuestionNumber == marksheetDTO.GetalVraeOpVraestel)
								{
									break;
								}
							}
						}
					}

					// Validation: Check if more than numQuestions are added between startRange and endRange
					if (processedQuestionNumbers.Count > numQuestions)
					{
						throw new Exception($"More than {numQuestions} questions were added between {startRange} and {endRange}.");
					}
				}
			}
		}

		private int TryParseInt(object value)
		{
			if (value == null)
            {
				return 0; // Return 0 or any other appropriate default value for null
			}
			else if (int.TryParse(value.ToString(), out int result))
            {
				return result;
			}
            else
            {
				return 0; // Return 0 or any other appropriate default value for invalid integers
			}
		}
		private object GetPropertyValue(dynamic obj, string propertyName)
		{
			var prop = obj.GetType().GetProperty(propertyName);
			return prop?.GetValue(obj);
		}

		#endregion
		public MarksheetDTO GetMarksheetTopDetails(string psMsheet)
		{
			// Get the relevant record directly
			var record = (from p in dbContext.Puntestates
						  join ep in dbContext.EKS_PUNTESTATE on p.Puntestaat equals ep.PS_Msheet
						  join v in dbContext.Vraestelles on p.VraestelKode equals v.VraestelK
						  where ep.PS_Msheet == psMsheet
						  select new
						  {
							  ep.PS_Msheet,
							  p.Status,
							  ep.PS_KODE,
							  p.VraestelKode,
							  v.VraestelNaam,
							  p.Sentrum,
							  ep.PS_ID_NO,
							  ep.PS_EKS_DAT
						  }).FirstOrDefault();

			if (record != null)
			{
				// Map the record to a DTO
				var marksheetDTO = new MarksheetDTO
				{
					PS_Msheet = record.PS_Msheet,
					Status = record.Status,
					PS_KODE = record.PS_KODE,
					VraestelKode = record.VraestelKode,
					VraestelNaam = record.VraestelNaam,
					Sentrum = record.Sentrum,
					PS_ID_NO = record.PS_ID_NO,
					PS_EKS_DAT = int.Parse(record.PS_EKS_DAT)
			};

				return marksheetDTO;
			}

			return null; 
		}



//		#region QueryOption1
//		public EKS_PUNTESTATE GetDetailsByMNoFromPunte(string marksheetno)
//        {
//            return dbContext.EKS_PUNTESTATE.Where(a => a.PS_Msheet == marksheetno).ToList().FirstOrDefault();
//        }
//        public Vraagleer GetVragRec(string subcode, short? pNumberPunte, string marksheet)
//        {
//            var PunteRecords = GetDetailsByMNoFromPunte(marksheet);
//            subcode = PunteRecords.PS_VAKKODE;
//            pNumberPunte = PunteRecords.PS_VRSTEL_NO;
//            return dbContext.Vraagleers.Where(a => a.Vakkode == subcode && a.VraestelNommer == pNumberPunte).ToList().FirstOrDefault();
//        }
//        #endregion

//        #region Option2List
//        //We will use LINQ and EF Core to join our two tables and get records from them
//        public MarksheetDTO GetScoresheetRecords(string marksheetnumber)
//        {
//			var tables = new List<Func<NSC_VraagpunteStelselEntities, IQueryable<dynamic>>> {
//				dbContext => dbContext.EKS_VraagPunte_A_ACCN10,
//				dbContext => dbContext.EKS_VraagPunte_A_ACCN20,
//				dbContext => dbContext.EKS_VraagPunte_A_ACCNZ10,
//				dbContext => dbContext.EKS_VraagPunte_A_AFRFA10,
//				dbContext => dbContext.EKS_VraagPunte_A_AFRFA20,
//				dbContext => dbContext.EKS_VraagPunte_A_AFRFA30,
//				dbContext => dbContext.EKS_VraagPunte_A_AFRHL10,
//				dbContext => dbContext.EKS_VraagPunte_A_AFRHL20,
//				dbContext => dbContext.EKS_VraagPunte_A_AFRHL30,
//				dbContext => dbContext.EKS_VraagPunte_A_AFRSA10,
//				dbContext => dbContext.EKS_VraagPunte_A_AFRSA20,
//				dbContext => dbContext.EKS_VraagPunte_A_AFRSA30,
//				dbContext => dbContext.EKS_VraagPunte_A_AGRM10,
//				dbContext => dbContext.EKS_VraagPunte_A_AGRS10,
//				dbContext => dbContext.EKS_VraagPunte_A_AGRS20,
//				dbContext => dbContext.EKS_VraagPunte_A_AGRT10,
//				dbContext => dbContext.EKS_VraagPunte_A_ARBSA10,
//				dbContext => dbContext.EKS_VraagPunte_A_ARBSA20,
//				dbContext => dbContext.EKS_VraagPunte_A_BSTD10,
//				dbContext => dbContext.EKS_VraagPunte_A_BSTD20,
//				dbContext => dbContext.EKS_VraagPunte_A_BSTDZ10,
//				dbContext => dbContext.EKS_VraagPunte_A_CATN10,
//				dbContext => dbContext.EKS_VraagPunte_A_CATN20,
//				dbContext => dbContext.EKS_VraagPunte_A_CHNSA10,
//				dbContext => dbContext.EKS_VraagPunte_A_CNST10,
//				dbContext => dbContext.EKS_VraagPunte_A_CVTC10,
//				dbContext => dbContext.EKS_VraagPunte_A_CVTV10,
//				dbContext => dbContext.EKS_VraagPunte_A_CVTW10,
//				dbContext => dbContext.EKS_VraagPunte_A_DNCE10,
//				dbContext => dbContext.EKS_VraagPunte_A_DRMA10,
//				dbContext => dbContext.EKS_VraagPunte_A_DSGN10,
//				dbContext => dbContext.EKS_VraagPunte_A_ECON10,
//				dbContext => dbContext.EKS_VraagPunte_A_ECON20,
//				dbContext => dbContext.EKS_VraagPunte_A_ELTD10,
//				dbContext => dbContext.EKS_VraagPunte_A_ELTE10,
//				dbContext => dbContext.EKS_VraagPunte_A_ELTP10,
//				dbContext => dbContext.EKS_VraagPunte_A_ENGFA10,
//				dbContext => dbContext.EKS_VraagPunte_A_ENGFA20,
//				dbContext => dbContext.EKS_VraagPunte_A_ENGFA30,
//				dbContext => dbContext.EKS_VraagPunte_A_ENGHL10,
//				dbContext => dbContext.EKS_VraagPunte_A_ENGHL20,
//				dbContext => dbContext.EKS_VraagPunte_A_ENGHL30,
//				dbContext => dbContext.EKS_VraagPunte_A_ENGSA10,
//				dbContext => dbContext.EKS_VraagPunte_A_ENGSA20,
//				dbContext => dbContext.EKS_VraagPunte_A_ENGSA30,
//				dbContext => dbContext.EKS_VraagPunte_A_EQNS10,
//				dbContext => dbContext.EKS_VraagPunte_A_FRHSA10,
//				dbContext => dbContext.EKS_VraagPunte_A_FRHSA20,
//				dbContext => dbContext.EKS_VraagPunte_A_GEOG10,
//				dbContext => dbContext.EKS_VraagPunte_A_GEOG20,
//				dbContext => dbContext.EKS_VraagPunte_A_GRDS10,
//				dbContext => dbContext.EKS_VraagPunte_A_GRDS20,
//				dbContext => dbContext.EKS_VraagPunte_A_GRMSA10,
//				dbContext => dbContext.EKS_VraagPunte_A_GRMSA20,
//				dbContext => dbContext.EKS_VraagPunte_A_HBRSA10,
//				dbContext => dbContext.EKS_VraagPunte_A_HBRSA20,
//				dbContext => dbContext.EKS_VraagPunte_A_HIST10,
//				dbContext => dbContext.EKS_VraagPunte_A_HIST20,
//				dbContext => dbContext.EKS_VraagPunte_A_HOSP10,
//				dbContext => dbContext.EKS_VraagPunte_A_INFT10,
//				dbContext => dbContext.EKS_VraagPunte_A_INFT20,
//				dbContext => dbContext.EKS_VraagPunte_A_LFSC10,
//				dbContext => dbContext.EKS_VraagPunte_A_LFSC20,
//				dbContext => dbContext.EKS_VraagPunte_A_MANSA10,
//				dbContext => dbContext.EKS_VraagPunte_A_MANSA20,
//				dbContext => dbContext.EKS_VraagPunte_A_MATH10,
//				dbContext => dbContext.EKS_VraagPunte_A_MATH20,
//				dbContext => dbContext.EKS_VraagPunte_A_MCTA10,
//				dbContext => dbContext.EKS_VraagPunte_A_MCTF10,
//				dbContext => dbContext.EKS_VraagPunte_A_MCTW10,
//				dbContext => dbContext.EKS_VraagPunte_A_MLIT10,
//				dbContext => dbContext.EKS_VraagPunte_A_MLIT20,
//				dbContext => dbContext.EKS_VraagPunte_A_MRSC10,
//				dbContext => dbContext.EKS_VraagPunte_A_MRSC20,
//				dbContext => dbContext.EKS_VraagPunte_A_MRTE10,
//				dbContext => dbContext.EKS_VraagPunte_A_MUSC10,
//				dbContext => dbContext.EKS_VraagPunte_A_RLGS10,
//				dbContext => dbContext.EKS_VraagPunte_A_RLGS20,
//				dbContext => dbContext.EKS_VraagPunte_A_RLGSZ10,
//				dbContext => dbContext.EKS_VraagPunte_A_RLGSZ20,
//				dbContext => dbContext.EKS_VraagPunte_A_SASHL10,
//				dbContext => dbContext.EKS_VraagPunte_A_SASHL20,
//				dbContext => dbContext.EKS_VraagPunte_A_SASHL30,
//				dbContext => dbContext.EKS_VraagPunte_A_SESHL10,
//				dbContext => dbContext.EKS_VraagPunte_A_SESHL20,
//				dbContext => dbContext.EKS_VraagPunte_A_SESHL30,
//				dbContext => dbContext.EKS_VraagPunte_A_SPES10,
//				dbContext => dbContext.EKS_VraagPunte_A_SPNSA10,
//				dbContext => dbContext.EKS_VraagPunte_A_SPNSA20,
//				dbContext => dbContext.EKS_VraagPunte_A_TMAT10,
//				dbContext => dbContext.EKS_VraagPunte_A_TMAT20,
//				dbContext => dbContext.EKS_VraagPunte_A_TRNP710,
//				dbContext => dbContext.EKS_VraagPunte_A_TRSM10,
//				dbContext => dbContext.EKS_VraagPunte_A_TSCE10,
//				dbContext => dbContext.EKS_VraagPunte_A_TSCE20,
//				dbContext => dbContext.EKS_VraagPunte_A_URDFA10,
//				dbContext => dbContext.EKS_VraagPunte_A_URDFA20,
//				dbContext => dbContext.EKS_VraagPunte_A_URDFA30,
//				dbContext => dbContext.EKS_VraagPunte_A_URDSA10,
//				dbContext => dbContext.EKS_VraagPunte_A_URDSA20,
//				dbContext => dbContext.EKS_VraagPunte_A_VSLA10,
//				dbContext => dbContext.EKS_VraagPunte_A_XHOFA10,
//				dbContext => dbContext.EKS_VraagPunte_A_XHOFA20,
//				dbContext => dbContext.EKS_VraagPunte_A_XHOFA30,
//				dbContext => dbContext.EKS_VraagPunte_A_XHOHL10,
//				dbContext => dbContext.EKS_VraagPunte_A_XHOHL20,
//				dbContext => dbContext.EKS_VraagPunte_A_XHOHL30,
//				dbContext => dbContext.EKS_VraagPunte_A_XHOSA10,
//				dbContext => dbContext.EKS_VraagPunte_A_XHOSA20,
//				dbContext => dbContext.EKS_VraagPunte_A_XHOSA30,
//				dbContext => dbContext.EKS_VraagPunte_A_ZULFA10,
//				dbContext => dbContext.EKS_VraagPunte_A_ZULFA20,
//				dbContext => dbContext.EKS_VraagPunte_A_ZULFA30,
//				dbContext => dbContext.EKS_VraagPunte_A_ZULHL10,
//				dbContext => dbContext.EKS_VraagPunte_A_ZULHL20,
//				dbContext => dbContext.EKS_VraagPunte_A_ZULHL30,
//};

//			IEnumerable<dynamic> result = null;

//			foreach (var tableFunc in tables)
//			{
//				var tableData = tableFunc(dbContext);
//				var puntestate = dbContext.Puntestates.ToList(); // Materialize the Puntestate table

//				foreach (var v in tableData)
//				{
//					var matchedP = puntestate.FirstOrDefault(p =>
//					RemoveDots(p.VraestelKode) == RemoveDots(v.PS_VRAESTELKODE) &&
//					p.Puntestaat == marksheetnumber);


//					if (matchedP != null)
//					{
//						result = new List<dynamic> { v };
//						goto EndOfLoop;
//					}
//				}
//			}

//		EndOfLoop:

//			if (result != null)
//			{
//				var resultList = result.ToList();
//				if (resultList.Count > 0)
//                {
//					dynamic firstResult = (dynamic)resultList[0];

//					marksheetDTO = new MarksheetDTO();
					
//					marksheetDTO.PS_GEKONTROLEERDEPUNT = GetValueOrDefault<float>(firstResult, "PS_GEKONTROLEERDEPUNT");
//					marksheetDTO.Hash = GetValueOrDefault <double>(firstResult, "Hash");
//					marksheetDTO.PS_ID_NO = GetValueOrDefault <string>(firstResult, "PS_ID_NO");
//					marksheetDTO.PS_KODE = GetValueOrDefault <string>(firstResult, "PS_KODE");
//					marksheetDTO.PS_Msheet = GetValueOrDefault <string>(firstResult, "PS_Msheet");
//					marksheetDTO.PS_KAFTOTAAL = GetValueOrDefault <float?>(firstResult, "PS_KAFTOTAAL");
//					//marksheetDTO.PS_VRAESTELKODE = GetValueOrDefault<string>(firstResult, "PS_VRAESTELKODE");
//					marksheetDTO.PS_EKS_DAT = GetValueOrDefault<int>(firstResult, "PS_EKS_DAT");
//					marksheetDTO.PS_VRAAG_1 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_1");
//					marksheetDTO.PS_VRAAG_2 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_2");
//					marksheetDTO.PS_VRAAG_3 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_3");
//					marksheetDTO.PS_VRAAG_4 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_4");
//					marksheetDTO.PS_VRAAG_5 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_5");
//					marksheetDTO.PS_VRAAG_6 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_6");
//					marksheetDTO.PS_VRAAG_7 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_7");
//					marksheetDTO.PS_VRAAG_8 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_8");
//					marksheetDTO.PS_VRAAG_9 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_9");
//					marksheetDTO.PS_VRAAG_10 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_10");
//					marksheetDTO.PS_VRAAG_11 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_11");
//					marksheetDTO.PS_VRAAG_12 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_12");
//					marksheetDTO.PS_VRAAG_13 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_13");
//					marksheetDTO.PS_VRAAG_14 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_14");
//					marksheetDTO.PS_VRAAG_15 = GetValueOrDefault <float?>(firstResult, "PS_VRAAG_15");
//					marksheetDTO.PS_MarksheetSort = GetValueOrDefault<Int32>(firstResult, "PS_MarksheetSort");
					
//				}
				

//            }
//			return marksheetDTO;
//		}
//		// Method to safely retrieve property value or return default value if property doesn't exist
//		T GetValueOrDefault<T>(dynamic obj, string propertyName)
//		{
//			if (obj.GetType().GetProperty(propertyName) != null)
//			{
//				return (T)obj.GetType().GetProperty(propertyName).GetValue(obj, null);
//			}
//			else
//			{
//				return default(T);
//			}
//		}
//		string RemoveDots(string input)
//		{
//			return input.Replace(".", "");
//		}

		////Let's check if the marksheet number exists?
		//public bool CheckMarksheetNumber(string MarksheetNumber)
  //      {
  //          bool marksheetExists = dbContext.EKS_PUNTESTATE.Any(m => m.PS_Msheet == MarksheetNumber);
  //          return marksheetExists;
  //      }

		////Get by marksheet number

		//public List<string> GetByMarksheet(string marksheet)
		//{
		//	return dbContext.EKS_PUNTESTATE
		//	  .Where(x => x.PS_Msheet == marksheet)
		//	  .Select(x => x.PS_ID_NO)
		//	  .ToList();
		//}
		//#endregion

		//#region SaveMarks
		//public void SaveMarks(string subCode, string SubMarks)
  //      {
  //          using (dbContext)
  //          {
  //              //Find the subject with the given subject code
  //              var subject = dbContext.Vraagleers.FirstOrDefault(s => s.Vakkode == subCode);
  //              if (subject != null)
  //              {
  //                  //Check first the next available mark column
  //                  int nextMarkNo = 1;
  //                  while (nextMarkNo <= 30)
  //                  {
  //                      string markColumnName = $"VraagMaks{nextMarkNo}";

  //                      //check to see if the mark column is empty
  //                      if (string.IsNullOrEmpty(subject.GetType().GetProperty(markColumnName)?.GetValue(subject) as string))
  //                      {
  //                          //Update the mark Column with the new mark
  //                          subject.GetType().GetProperty(markColumnName)?.SetValue(subject, SubMarks);
  //                          break;

  //                      }
  //                      nextMarkNo++;
  //                  }
  //                  //save changes
  //                  dbContext.SaveChanges();
  //              }
  //              else
  //              {
  //                  //error messages when module is not found will implement this later on
  //              }
  //          }
  //      }
  //      #endregion

    }
}
