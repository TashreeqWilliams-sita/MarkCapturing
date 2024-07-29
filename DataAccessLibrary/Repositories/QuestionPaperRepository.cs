using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using DTOs;


public class QuestionPaperRepository
{
    private readonly NSC_VraagpunteStelselEntities dbContext;
    //private readonly VraagleerDTO _vraagleerDTO;
    Vraagleer questionPaper = new Vraagleer();
    VraagleerDTO vraagleerDTO = new VraagleerDTO();
    List<int?> combinationMaxMarks = new List<int?>();

    public QuestionPaperRepository(NSC_VraagpunteStelselEntities dbContext/*, VraagleerDTO vraagleerDTO*/)
    {
        this.dbContext = dbContext;
        //_vraagleerDTO = vraagleerDTO;
    }

    
    public void CreateOrUpdateQuestionPaper(string eksamen, string vraestelKode, int vraestelMaksimum, short? getalVraeOpVraestel)
    {
       
        var existingPaper = dbContext.Set<Vraagleer>().FirstOrDefault(q => q.Eksamen == eksamen && q.VraestelKode == vraestelKode);

        if (existingPaper != null)
        {
            existingPaper.VraestelMaksimum = vraestelMaksimum;
            existingPaper.GetalVraeOpVraestel = getalVraeOpVraestel;
        }
        else
        {
            var newPaper = new Vraagleer
            {
                Eksamen = eksamen,
                VraestelKode = vraestelKode,
                VraestelMaksimum = vraestelMaksimum,
                GetalVraeOpVraestel = getalVraeOpVraestel
            };
            dbContext.Set<Vraagleer>().Add(newPaper);
        }

        dbContext.SaveChanges();
    }

    public VraagleerDTO GetQuestionPaper(string eksamen, string vraestelKode)
    {
        return dbContext.Set<VraagleerDTO>().FirstOrDefault(q => q.Eksamen == eksamen && q.VraestelKode == vraestelKode);
    }
    public List<string> GetEksamenList()
    {
        return dbContext.Set<Vraagleer>().Select(q => q.Eksamen).ToList();
    }
    //get all subject code list
    public List<string> GetVraestelKodeList()
    {
        return dbContext.Set<Vraagleer>().Select(q => q.VraestelKode).ToList();
    }
    public int? GetMaxMark(string eksamen, string vraestelKode)
    {
        string eksamenStr = eksamen?.ToString();
        string vraestelKodeStr = vraestelKode?.ToString();
        Console.WriteLine($"Eksamen: {eksamenStr}, VraestelKode: {vraestelKodeStr}");

        var questionPaper = dbContext.Set<Vraagleer>()
            .FirstOrDefault(q => q.Eksamen == eksamenStr && q.VraestelKode == vraestelKodeStr);

        if (questionPaper != null)
        {
            return questionPaper.VraestelMaksimum;
        }
        else
        {
            // You can handle the case where the question paper doesn't exist.
            // For example, throw an exception or return a default value.
            throw new InvalidOperationException("Question paper not found.");
        }
    }
    public int? GetQuestionNo(string eksamen, string vraestelKode)
    {
        string eksamenStr = eksamen?.ToString();
        string vraestelKodeStr = vraestelKode?.ToString();

        var questionPaper = dbContext.Set<Vraagleer>()
            .FirstOrDefault(q => q.Eksamen == eksamenStr && q.VraestelKode == vraestelKodeStr);

        if (questionPaper != null)
        {
            return questionPaper.GetalVraeOpVraestel;
        }
        else
        {
            // You can handle the case where the question paper doesn't exist.
            // For example, throw an exception or return a default value.
            throw new InvalidOperationException("Question paper not found.");
        }
    }
    public int? GetSelectionAmount(string eksamen, string vraestelKode)
    {
        string eksamenStr = eksamen?.ToString();
        string vraestelKodeStr = vraestelKode?.ToString();

        var questionPaper = dbContext.Set<Vraagleer>()
            .FirstOrDefault(q => q.Eksamen == eksamenStr && q.VraestelKode == vraestelKodeStr);

        if (questionPaper != null)
        {
            return questionPaper.GetalKombinasiesVanKeuseVrae;
        }
        else
        {
            // You can handle the case where the question paper doesn't exist.
            // For example, throw an exception or return a default value.
            throw new InvalidOperationException("Question paper not found.");
        }
    }
    public void UpdateVraestelMaksimum(object eksamen, object vraestelKode, int newMaxMark)
    {
        string eksamenStr = eksamen?.ToString();
        string vraestelKodeStr = vraestelKode?.ToString();
        // Find the record in the database based on eksamen and vraestelKode
        var questionPaper = dbContext.Set<Vraagleer>().FirstOrDefault(q => q.Eksamen == eksamenStr && q.VraestelKode == vraestelKodeStr);

        if (questionPaper != null)
        {
            // Update the VraestelMaksimum property
            questionPaper.VraestelMaksimum = newMaxMark;

            // Save changes to the database
            dbContext.SaveChanges();
        }
    }
    public void UpdateGetalVraeOpVraestel(object eksamen, object vraestelKode, short? getalVraeOpVraestel)
    {
        string eksamenStr = eksamen?.ToString();
        string vraestelKodeStr = vraestelKode?.ToString();
        // Find the record in the database based on eksamen and vraestelKode
        var questionPaper = dbContext.Set<Vraagleer>().FirstOrDefault(q => q.Eksamen == eksamenStr && q.VraestelKode == vraestelKodeStr);

        if (questionPaper != null)
        {
            // Update the VraestelMaksimum property
            questionPaper.GetalVraeOpVraestel = getalVraeOpVraestel;

            // Save changes to the database
            dbContext.SaveChanges();
        }
    }
    public void UpdateGetalKombinasiesTeBeantwoord(object eksamen, object vraestelKode, short? getalKombinasiesTeBeantwoord)
    {
        string eksamenStr = eksamen?.ToString();
        string vraestelKodeStr = vraestelKode?.ToString();
        // Find the record in the database based on eksamen and vraestelKode
        var questionPaper = dbContext.Set<Vraagleer>().FirstOrDefault(q => q.Eksamen == eksamenStr && q.VraestelKode == vraestelKodeStr);

        if (questionPaper != null)
        {
            // Update the VraestelMaksimum property
            questionPaper.GetalKombinasiesVanKeuseVrae = getalKombinasiesTeBeantwoord;

            // Save changes to the database
            dbContext.SaveChanges();
        }
    }
    public VraagleerDTO UpdateCombinationTotalTextboxes(string eksamen, string vraestelKode)
    {
        var vraagleerData = dbContext.Vraagleers
            .Where(q => q.Eksamen == eksamen && q.VraestelKode == vraestelKode)
            .Select(q => new
            {
                q.VraestelKode,
                KeuseVraeGetalVrae1 = q.KeuseVraeGetalVrae1 ?? 0,
                KeuseVraeEersteVrgNo1 = q.KeuseVraeEersteVrgNo1 ?? 0,
                KeuseVraeLaasteVrgNo1 = q.KeuseVraeLaasteVrgNo1 ?? 0,
                KeuseVraeGetalVrae2 = q.KeuseVraeGetalVrae2 ?? 0,
                KeuseVraeEersteVrgNo2 = q.KeuseVraeEersteVrgNo2 ?? 0,
                KeuseVraeLaasteVrgNo2 = q.KeuseVraeLaasteVrgNo2 ?? 0,
                KeuseVraeGetalVrae3 = q.KeuseVraeGetalVrae3 ?? 0,
                KeuseVraeEersteVrgNo3 = q.KeuseVraeEersteVrgNo3 ?? 0,
                KeuseVraeLaasteVrgNo3 = q.KeuseVraeLaasteVrgNo3 ?? 0,
                KeuseVraeGetalVrae4 = q.KeuseVraeGetalVrae4 ?? 0,
                KeuseVraeEersteVrgNo4 = q.KeuseVraeEersteVrgNo4 ?? 0,
                KeuseVraeLaasteVrgNo4 = q.KeuseVraeLaasteVrgNo4 ?? 0,
                KeuseVraeGetalVrae5 = q.KeuseVraeGetalVrae5 ?? 0,
                KeuseVraeEersteVrgNo5 = q.KeuseVraeEersteVrgNo5 ?? 0,
                KeuseVraeLaasteVrgNo5 = q.KeuseVraeLaasteVrgNo5 ?? 0,
                KeuseVraeGetalVrae6 = q.KeuseVraeGetalVrae6 ?? 0,
                KeuseVraeEersteVrgNo6 = q.KeuseVraeEersteVrgNo6 ?? 0,
                KeuseVraeLaasteVrgNo6 = q.KeuseVraeLaasteVrgNo6 ?? 0,
                VraagMaksValues = new List<float?> { q.VraagMaks1, q.VraagMaks2, q.VraagMaks3, q.VraagMaks4,
                q.VraagMaks5, q.VraagMaks6, q.VraagMaks7, q.VraagMaks8, q.VraagMaks9, q.VraagMaks10,q.VraagMaks11, 
                q.VraagMaks12, q.VraagMaks13, q.VraagMaks14, q.VraagMaks15, q.VraagMaks16, q.VraagMaks17, q.VraagMaks18,
                q.VraagMaks19, q.VraagMaks20, q.VraagMaks21, q.VraagMaks22, q.VraagMaks23, q.VraagMaks24, q.VraagMaks25,
                q.VraagMaks26, q.VraagMaks27, q.VraagMaks28, q.VraagMaks29, q.VraagMaks30 }
            })
            .FirstOrDefault();

        if (vraagleerData == null)
        {
            return null; // Or handle the not found situation appropriately
        }

        Func<int, int, int, float?> calculateSumForRange = (start, count, total) =>
        {
            // Adjusts the number of items taken based on the specified 'count' and the total number of available items from 'start'
            int adjustedCount = Math.Min(count, total - start + 1);
            return vraagleerData.VraagMaksValues
                   .Skip(start - 1)
                   .Take(adjustedCount)
                   .Sum();
        };

        int sumGroup1 = (int)Math.Round(calculateSumForRange(vraagleerData.KeuseVraeEersteVrgNo1, vraagleerData.KeuseVraeGetalVrae1, vraagleerData.KeuseVraeLaasteVrgNo1) ?? 0);
        int sumGroup2 = (int)Math.Round(calculateSumForRange(vraagleerData.KeuseVraeEersteVrgNo2, vraagleerData.KeuseVraeGetalVrae2, vraagleerData.KeuseVraeLaasteVrgNo2) ?? 0);
        int sumGroup3 = (int)Math.Round(calculateSumForRange(vraagleerData.KeuseVraeEersteVrgNo3, vraagleerData.KeuseVraeGetalVrae3, vraagleerData.KeuseVraeLaasteVrgNo3) ?? 0);
        int sumGroup4 = (int)Math.Round(calculateSumForRange(vraagleerData.KeuseVraeEersteVrgNo4, vraagleerData.KeuseVraeGetalVrae4, vraagleerData.KeuseVraeLaasteVrgNo4) ?? 0);
        int sumGroup5 = (int)Math.Round(calculateSumForRange(vraagleerData.KeuseVraeEersteVrgNo5, vraagleerData.KeuseVraeGetalVrae5, vraagleerData.KeuseVraeLaasteVrgNo5) ?? 0);
        int sumGroup6 = (int)Math.Round(calculateSumForRange(vraagleerData.KeuseVraeEersteVrgNo6, vraagleerData.KeuseVraeGetalVrae6, vraagleerData.KeuseVraeLaasteVrgNo6) ?? 0);


        vraagleerDTO = new VraagleerDTO
        {
        //    VraestelKode = vraagleerData.VraestelKode,
        //    Eksamen = eksamen,
            CombinationMaxMarks = new List<int?> { sumGroup1, sumGroup2, sumGroup3, sumGroup4, sumGroup5, sumGroup6 } 
        };

        return vraagleerDTO;
    }


    private void DisplayOrUpdateUI(VraagleerDTO vraagleerDTO)
    {
        // Implementation to update the UI based on the provided vraagleerDTO
        // This might include setting text boxes, labels, etc.
    }

    private void HandleMissingQuestionPaper()
    {
        // Implementation to handle the scenario when a question paper is not found
        // Could be showing a message box or updating status labels
    }


    public VraagleerDTO GetQuestionPaperDetails(string eksamen, string vraestelKode)
    {
        //List<int?> combinationMaxMarks = new List<int?>();
        UpdateCombinationTotalTextboxes(eksamen, vraestelKode);
        questionPaper = dbContext.Set<Vraagleer>()
            .Where(q => q.Eksamen == eksamen.ToString() && q.VraestelKode == vraestelKode.ToString())
            .FirstOrDefault();

        if (questionPaper != null)
        {
            vraagleerDTO = new VraagleerDTO
            {
                VraestelKode = questionPaper.VraestelKode,
                Eksamen = questionPaper.Eksamen,
                GetalVraeOpVraestel = questionPaper.GetalVraeOpVraestel,
                CombinationMaxMarks = vraagleerDTO.CombinationMaxMarks,
                //Question number
                VraagNaam1 = questionPaper.VraagNaam1 ?? "1",
                VraagNaam2 = questionPaper.VraagNaam2 ?? "2",
                VraagNaam3 = questionPaper.VraagNaam3 ?? "3",
                VraagNaam4 = questionPaper.VraagNaam4 ?? "4",
                VraagNaam5 = questionPaper.VraagNaam5 ?? "5",
                VraagNaam6 = questionPaper.VraagNaam6 ?? "6",
                VraagNaam7 = questionPaper.VraagNaam7 ?? "7",
                VraagNaam8 = questionPaper.VraagNaam8 ?? "8",
                VraagNaam9 = questionPaper.VraagNaam9 ?? "9",
                VraagNaam10 = questionPaper.VraagNaam10 ?? "10",
                VraagNaam11 = questionPaper.VraagNaam11 ?? "11",
                VraagNaam12 = questionPaper.VraagNaam12 ?? "12",
                VraagNaam13 = questionPaper.VraagNaam13 ?? "13",
                VraagNaam14 = questionPaper.VraagNaam14 ?? "14",
                VraagNaam15 = questionPaper.VraagNaam15 ?? "15",
                VraagNaam16 = questionPaper.VraagNaam16 ?? "16",
                VraagNaam17 = questionPaper.VraagNaam17 ?? "17",
                VraagNaam18 = questionPaper.VraagNaam18 ?? "18",
                VraagNaam19 = questionPaper.VraagNaam19 ?? "19",
                VraagNaam20 = questionPaper.VraagNaam20 ?? "20",
                VraagNaam21 = questionPaper.VraagNaam21 ?? "21",
                VraagNaam22 = questionPaper.VraagNaam22 ?? "22",
                VraagNaam23 = questionPaper.VraagNaam23 ?? "23",
                VraagNaam24 = questionPaper.VraagNaam24 ?? "24",
                VraagNaam25 = questionPaper.VraagNaam25 ?? "25",
                VraagNaam26 = questionPaper.VraagNaam26 ?? "26",
                VraagNaam27 = questionPaper.VraagNaam27 ?? "27",
                VraagNaam28 = questionPaper.VraagNaam28 ?? "28",
                VraagNaam29 = questionPaper.VraagNaam29 ?? "29",
                VraagNaam30 = questionPaper.VraagNaam30 ?? "30",
                // Question Total
                VraagMaks1 = questionPaper.VraagMaks1 ?? 0,
                VraagMaks2 = questionPaper.VraagMaks2 ?? 0,
                VraagMaks3 = questionPaper.VraagMaks3 ?? 0,
                VraagMaks4 = questionPaper.VraagMaks4 ?? 0,
                VraagMaks5 = questionPaper.VraagMaks5 ?? 0,
                VraagMaks6 = questionPaper.VraagMaks6 ?? 0,
                VraagMaks7 = questionPaper.VraagMaks7 ?? 0,
                VraagMaks8 = questionPaper.VraagMaks8 ?? 0,
                VraagMaks9 = questionPaper.VraagMaks9 ?? 0,
                VraagMaks10 = questionPaper.VraagMaks10 ?? 0,
                VraagMaks11 = questionPaper.VraagMaks11 ?? 0,
                VraagMaks12 = questionPaper.VraagMaks12 ?? 0,
                VraagMaks13 = questionPaper.VraagMaks13 ?? 0,
                VraagMaks14 = questionPaper.VraagMaks14 ?? 0,
                VraagMaks15 = questionPaper.VraagMaks15 ?? 0,
                VraagMaks16 = questionPaper.VraagMaks16 ?? 0,
                VraagMaks17 = questionPaper.VraagMaks17 ?? 0,
                VraagMaks18 = questionPaper.VraagMaks18 ?? 0,
                VraagMaks19 = questionPaper.VraagMaks19 ?? 0,
                VraagMaks20 = questionPaper.VraagMaks20 ?? 0,
                VraagMaks21 = questionPaper.VraagMaks21 ?? 0,
                VraagMaks22 = questionPaper.VraagMaks22 ?? 0,
                VraagMaks23 = questionPaper.VraagMaks23 ?? 0,
                VraagMaks24 = questionPaper.VraagMaks24 ?? 0,
                VraagMaks25 = questionPaper.VraagMaks25 ?? 0,
                VraagMaks26 = questionPaper.VraagMaks26 ?? 0,
                VraagMaks27 = questionPaper.VraagMaks27 ?? 0,
                VraagMaks28 = questionPaper.VraagMaks28 ?? 0,
                VraagMaks29 = questionPaper.VraagMaks29 ?? 0,
                VraagMaks30 = questionPaper.VraagMaks30 ?? 0,


                //radio button for each question number
                TelVirVraestelMaks1 = questionPaper.TelVirVraestelMaks1 ?? false,
                TelVirVraestelMaks2 = questionPaper.TelVirVraestelMaks2 ?? false,
                TelVirVraestelMaks3 = questionPaper.TelVirVraestelMaks3 ?? false,
                TelVirVraestelMaks4 = questionPaper.TelVirVraestelMaks4 ?? false,
                TelVirVraestelMaks5 = questionPaper.TelVirVraestelMaks5 ?? false,
                TelVirVraestelMaks6 = questionPaper.TelVirVraestelMaks6 ?? false,
                TelVirVraestelMaks7 = questionPaper.TelVirVraestelMaks7 ?? false,
                TelVirVraestelMaks8 = questionPaper.TelVirVraestelMaks8 ?? false,
                TelVirVraestelMaks9 = questionPaper.TelVirVraestelMaks9 ?? false,
                TelVirVraestelMaks10 = questionPaper.TelVirVraestelMaks10 ?? false,
                TelVirVraestelMaks11 = questionPaper.TelVirVraestelMaks11 ?? false,
                TelVirVraestelMaks12 = questionPaper.TelVirVraestelMaks12 ?? false,
                TelVirVraestelMaks13 = questionPaper.TelVirVraestelMaks13 ?? false,
                TelVirVraestelMaks14 = questionPaper.TelVirVraestelMaks14 ?? false,
                TelVirVraestelMaks15 = questionPaper.TelVirVraestelMaks15 ?? false,
                TelVirVraestelMaks16 = questionPaper.TelVirVraestelMaks16 ?? false,
                TelVirVraestelMaks17 = questionPaper.TelVirVraestelMaks17 ?? false,
                TelVirVraestelMaks18 = questionPaper.TelVirVraestelMaks18 ?? false,
                TelVirVraestelMaks19 = questionPaper.TelVirVraestelMaks19 ?? false,
                TelVirVraestelMaks20 = questionPaper.TelVirVraestelMaks20 ?? false,
                TelVirVraestelMaks21 = questionPaper.TelVirVraestelMaks21 ?? false,
                TelVirVraestelMaks22 = questionPaper.TelVirVraestelMaks22 ?? false,
                TelVirVraestelMaks23 = questionPaper.TelVirVraestelMaks23 ?? false,
                TelVirVraestelMaks24 = questionPaper.TelVirVraestelMaks24 ?? false,
                TelVirVraestelMaks25 = questionPaper.TelVirVraestelMaks25 ?? false,
                TelVirVraestelMaks26 = questionPaper.TelVirVraestelMaks26 ?? false,
                TelVirVraestelMaks27 = questionPaper.TelVirVraestelMaks27 ?? false,
                TelVirVraestelMaks28 = questionPaper.TelVirVraestelMaks28 ?? false,
                TelVirVraestelMaks29 = questionPaper.TelVirVraestelMaks29 ?? false,
                TelVirVraestelMaks30 = questionPaper.TelVirVraestelMaks30 ?? false,

                GetalKombinasiesVanKeuseVrae = questionPaper.GetalKombinasiesVanKeuseVrae,

                KeuseVraeEersteVrgNo1 = questionPaper.KeuseVraeEersteVrgNo1,
                KeuseVraeEersteVrgNo2 = questionPaper.KeuseVraeEersteVrgNo2,
                KeuseVraeEersteVrgNo3 = questionPaper.KeuseVraeEersteVrgNo3,
                KeuseVraeEersteVrgNo4 = questionPaper.KeuseVraeEersteVrgNo4,
                KeuseVraeEersteVrgNo5 = questionPaper.KeuseVraeEersteVrgNo5,
                KeuseVraeEersteVrgNo6 = questionPaper.KeuseVraeEersteVrgNo6,

                KeuseVraeLaasteVrgNo1 = questionPaper.KeuseVraeLaasteVrgNo1,
                KeuseVraeLaasteVrgNo2 = questionPaper.KeuseVraeLaasteVrgNo2,
                KeuseVraeLaasteVrgNo3 = questionPaper.KeuseVraeLaasteVrgNo3,
                KeuseVraeLaasteVrgNo4 = questionPaper.KeuseVraeLaasteVrgNo4,
                KeuseVraeLaasteVrgNo5 = questionPaper.KeuseVraeLaasteVrgNo5,
                KeuseVraeLaasteVrgNo6 = questionPaper.KeuseVraeLaasteVrgNo6,

                KeuseVraeGetalVrae1 = questionPaper.KeuseVraeGetalVrae1,
                KeuseVraeGetalVrae2 = questionPaper.KeuseVraeGetalVrae2,
                KeuseVraeGetalVrae3 = questionPaper.KeuseVraeGetalVrae3,
                KeuseVraeGetalVrae4 = questionPaper.KeuseVraeGetalVrae4,
                KeuseVraeGetalVrae5 = questionPaper.KeuseVraeGetalVrae5,
                KeuseVraeGetalVrae6 = questionPaper.KeuseVraeGetalVrae6,

            };
            
            return vraagleerDTO;

        }
        else
        {
            return null;
        }




    }
    public void SaveQuestionPaperDetails(string eksamen, string vraestelKode, VraagleerDTO vraagleerDTO)
    {
        //vraagleerDTO = GetQuestionPaperDetails(eksamen, vraestelKode);


        var existingDetails = dbContext.Set<Vraagleer>()
           .Where(q => q.Eksamen == eksamen && q.VraestelKode == vraestelKode)
           .FirstOrDefault();
       

            if (existingDetails != null)
            {
                // Update the properties of the existing entity with the modified values
                //existingDetails.GetalVraeOpVraestel = vraagleerDTO.GetalVraeOpVraestel;
                existingDetails.VraagNaam1 = vraagleerDTO.VraagNaam1;
                existingDetails.VraagNaam2 = vraagleerDTO.VraagNaam2;
                existingDetails.VraagNaam3 = vraagleerDTO.VraagNaam3;
                existingDetails.VraagNaam4 = vraagleerDTO.VraagNaam4;
                existingDetails.VraagNaam5 = vraagleerDTO.VraagNaam5;
                existingDetails.VraagNaam6 = vraagleerDTO.VraagNaam6;
                existingDetails.VraagNaam7 = vraagleerDTO.VraagNaam7;
                existingDetails.VraagNaam8 = vraagleerDTO.VraagNaam8;
                existingDetails.VraagNaam9 = vraagleerDTO.VraagNaam9;
                existingDetails.VraagNaam10 = vraagleerDTO.VraagNaam10;
                existingDetails.VraagNaam11 = vraagleerDTO.VraagNaam11;
                existingDetails.VraagNaam12 = vraagleerDTO.VraagNaam12;
                existingDetails.VraagNaam13 = vraagleerDTO.VraagNaam13;
                existingDetails.VraagNaam14 = vraagleerDTO.VraagNaam14;
                existingDetails.VraagNaam15 = vraagleerDTO.VraagNaam15;
                existingDetails.VraagNaam16 = vraagleerDTO.VraagNaam16;
                existingDetails.VraagNaam17 = vraagleerDTO.VraagNaam17;
                existingDetails.VraagNaam18 = vraagleerDTO.VraagNaam18;
                existingDetails.VraagNaam19 = vraagleerDTO.VraagNaam19;
                existingDetails.VraagNaam20 = vraagleerDTO.VraagNaam20;
                existingDetails.VraagNaam21 = vraagleerDTO.VraagNaam21;
                existingDetails.VraagNaam22 = vraagleerDTO.VraagNaam22;
                existingDetails.VraagNaam23 = vraagleerDTO.VraagNaam23;
                existingDetails.VraagNaam24 = vraagleerDTO.VraagNaam24;
                existingDetails.VraagNaam25 = vraagleerDTO.VraagNaam25;
                existingDetails.VraagNaam26 = vraagleerDTO.VraagNaam26;
                existingDetails.VraagNaam27 = vraagleerDTO.VraagNaam27;
                existingDetails.VraagNaam28 = vraagleerDTO.VraagNaam28;
                existingDetails.VraagNaam29 = vraagleerDTO.VraagNaam29;
                existingDetails.VraagNaam30 = vraagleerDTO.VraagNaam30;

                existingDetails.VraagMaks1 = vraagleerDTO.VraagMaks1;
                existingDetails.VraagMaks2 = vraagleerDTO.VraagMaks2;
                existingDetails.VraagMaks3 = vraagleerDTO.VraagMaks3;
                existingDetails.VraagMaks4 = vraagleerDTO.VraagMaks4;
                existingDetails.VraagMaks5 = vraagleerDTO.VraagMaks5;
                existingDetails.VraagMaks6 = vraagleerDTO.VraagMaks6;
                existingDetails.VraagMaks7 = vraagleerDTO.VraagMaks7;
                existingDetails.VraagMaks8 = vraagleerDTO.VraagMaks8;
                existingDetails.VraagMaks9 = vraagleerDTO.VraagMaks9;
                existingDetails.VraagMaks10 = vraagleerDTO.VraagMaks10;
                existingDetails.VraagMaks11 = vraagleerDTO.VraagMaks11;
                existingDetails.VraagMaks12 = vraagleerDTO.VraagMaks12;
                existingDetails.VraagMaks13 = vraagleerDTO.VraagMaks13;
                existingDetails.VraagMaks14 = vraagleerDTO.VraagMaks14;
                existingDetails.VraagMaks15 = vraagleerDTO.VraagMaks15;
                existingDetails.VraagMaks16 = vraagleerDTO.VraagMaks16;
                existingDetails.VraagMaks17 = vraagleerDTO.VraagMaks17;
                existingDetails.VraagMaks18 = vraagleerDTO.VraagMaks18;
                existingDetails.VraagMaks19 = vraagleerDTO.VraagMaks19;
                existingDetails.VraagMaks20 = vraagleerDTO.VraagMaks20;
                existingDetails.VraagMaks21 = vraagleerDTO.VraagMaks21;
                existingDetails.VraagMaks22 = vraagleerDTO.VraagMaks22;
                existingDetails.VraagMaks23 = vraagleerDTO.VraagMaks23;
                existingDetails.VraagMaks24 = vraagleerDTO.VraagMaks24;
                existingDetails.VraagMaks25 = vraagleerDTO.VraagMaks25;
                existingDetails.VraagMaks26 = vraagleerDTO.VraagMaks26;
                existingDetails.VraagMaks27 = vraagleerDTO.VraagMaks27;
                existingDetails.VraagMaks28 = vraagleerDTO.VraagMaks28;
                existingDetails.VraagMaks29 = vraagleerDTO.VraagMaks29;
                existingDetails.VraagMaks30 = vraagleerDTO.VraagMaks30;

                existingDetails.TelVirVraestelMaks1 = vraagleerDTO.TelVirVraestelMaks1;
                existingDetails.TelVirVraestelMaks2 = vraagleerDTO.TelVirVraestelMaks2;
                existingDetails.TelVirVraestelMaks3 = vraagleerDTO.TelVirVraestelMaks3;
                existingDetails.TelVirVraestelMaks4 = vraagleerDTO.TelVirVraestelMaks4;
                existingDetails.TelVirVraestelMaks5 = vraagleerDTO.TelVirVraestelMaks5;
                existingDetails.TelVirVraestelMaks6 = vraagleerDTO.TelVirVraestelMaks6;
                existingDetails.TelVirVraestelMaks7 = vraagleerDTO.TelVirVraestelMaks7;
                existingDetails.TelVirVraestelMaks8 = vraagleerDTO.TelVirVraestelMaks8;
                existingDetails.TelVirVraestelMaks9 = vraagleerDTO.TelVirVraestelMaks9;
                existingDetails.TelVirVraestelMaks10 = vraagleerDTO.TelVirVraestelMaks10;
                existingDetails.TelVirVraestelMaks11 = vraagleerDTO.TelVirVraestelMaks11;
                existingDetails.TelVirVraestelMaks12 = vraagleerDTO.TelVirVraestelMaks12;
                existingDetails.TelVirVraestelMaks13 = vraagleerDTO.TelVirVraestelMaks13;
                existingDetails.TelVirVraestelMaks14 = vraagleerDTO.TelVirVraestelMaks14;
                existingDetails.TelVirVraestelMaks15 = vraagleerDTO.TelVirVraestelMaks15;
                existingDetails.TelVirVraestelMaks16 = vraagleerDTO.TelVirVraestelMaks16;
                existingDetails.TelVirVraestelMaks17 = vraagleerDTO.TelVirVraestelMaks17;
                existingDetails.TelVirVraestelMaks18 = vraagleerDTO.TelVirVraestelMaks18;
                existingDetails.TelVirVraestelMaks19 = vraagleerDTO.TelVirVraestelMaks19;
                existingDetails.TelVirVraestelMaks20 = vraagleerDTO.TelVirVraestelMaks20;
                existingDetails.TelVirVraestelMaks21 = vraagleerDTO.TelVirVraestelMaks21;
                existingDetails.TelVirVraestelMaks22 = vraagleerDTO.TelVirVraestelMaks22;
                existingDetails.TelVirVraestelMaks23 = vraagleerDTO.TelVirVraestelMaks23; 
                existingDetails.TelVirVraestelMaks24 = vraagleerDTO.TelVirVraestelMaks24;
                existingDetails.TelVirVraestelMaks25 = vraagleerDTO.TelVirVraestelMaks25; 
                existingDetails.TelVirVraestelMaks26 = vraagleerDTO.TelVirVraestelMaks26;
                existingDetails.TelVirVraestelMaks27 = vraagleerDTO.TelVirVraestelMaks27; 
                existingDetails.TelVirVraestelMaks28 = vraagleerDTO.TelVirVraestelMaks28;
                existingDetails.TelVirVraestelMaks29 = vraagleerDTO.TelVirVraestelMaks29;
                existingDetails.TelVirVraestelMaks30 = vraagleerDTO.TelVirVraestelMaks30;

                existingDetails.KeuseVraeEersteVrgNo1 = vraagleerDTO.KeuseVraeEersteVrgNo1;
                existingDetails.KeuseVraeEersteVrgNo2 = vraagleerDTO.KeuseVraeEersteVrgNo2;
                existingDetails.KeuseVraeEersteVrgNo3 = vraagleerDTO.KeuseVraeEersteVrgNo3;
                existingDetails.KeuseVraeEersteVrgNo4 = vraagleerDTO.KeuseVraeEersteVrgNo4;
                existingDetails.KeuseVraeEersteVrgNo5 = vraagleerDTO.KeuseVraeEersteVrgNo5;
                existingDetails.KeuseVraeEersteVrgNo6 = vraagleerDTO.KeuseVraeEersteVrgNo6;

                existingDetails.KeuseVraeLaasteVrgNo1 = vraagleerDTO.KeuseVraeLaasteVrgNo1;
                existingDetails.KeuseVraeLaasteVrgNo2 = vraagleerDTO.KeuseVraeLaasteVrgNo2;
                existingDetails.KeuseVraeLaasteVrgNo3 = vraagleerDTO.KeuseVraeLaasteVrgNo3;
                existingDetails.KeuseVraeLaasteVrgNo4 = vraagleerDTO.KeuseVraeLaasteVrgNo4;
                existingDetails.KeuseVraeLaasteVrgNo5 = vraagleerDTO.KeuseVraeLaasteVrgNo5;
                existingDetails.KeuseVraeLaasteVrgNo6 = vraagleerDTO.KeuseVraeLaasteVrgNo6;

                existingDetails.KeuseVraeGetalVrae1 = vraagleerDTO.KeuseVraeGetalVrae1;
                existingDetails.KeuseVraeGetalVrae2 = vraagleerDTO.KeuseVraeGetalVrae2;
                existingDetails.KeuseVraeGetalVrae3 = vraagleerDTO.KeuseVraeGetalVrae3;
                existingDetails.KeuseVraeGetalVrae4 = vraagleerDTO.KeuseVraeGetalVrae4;
                existingDetails.KeuseVraeGetalVrae5 = vraagleerDTO.KeuseVraeGetalVrae5;
                existingDetails.KeuseVraeGetalVrae6 = vraagleerDTO.KeuseVraeGetalVrae6;


            // Save changes to the database
            //dbContext.SaveChanges();
        }
            else
            {
            // Insert new details
            var newDetails = new Vraagleer
            {
                Eksamen = vraagleerDTO.Eksamen,
                VraestelKode = vraagleerDTO.VraestelKode,
                VraagNaam1 = vraagleerDTO.VraagNaam1,
                VraagNaam2 = vraagleerDTO.VraagNaam2,
                VraagNaam3 = vraagleerDTO.VraagNaam3,
                VraagNaam4 = vraagleerDTO.VraagNaam4,
                VraagNaam5 = vraagleerDTO.VraagNaam5,
                VraagNaam6 = vraagleerDTO.VraagNaam6,
                VraagNaam7 = vraagleerDTO.VraagNaam7,
                VraagNaam8 = vraagleerDTO.VraagNaam8,

                // Set other properties accordingly using object initialization
                // ...
            };

            dbContext.Set<Vraagleer>().Add(newDetails);
            }
            // Save changes to the database
            dbContext.SaveChanges();

    }



}
