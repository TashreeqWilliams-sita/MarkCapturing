﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MarkCapturing
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NSC_VraagpunteStelselEntities : DbContext
    {
        public NSC_VraagpunteStelselEntities()
            : base("name=NSC_VraagpunteStelselEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EKS_VraagPunte_A_ACCN10> EKS_VraagPunte_A_ACCN10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_ACCN20> EKS_VraagPunte_A_ACCN20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_ACCNZ10> EKS_VraagPunte_A_ACCNZ10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_AFRFA10> EKS_VraagPunte_A_AFRFA10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_AFRFA20> EKS_VraagPunte_A_AFRFA20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_AFRFA30> EKS_VraagPunte_A_AFRFA30 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_AFRHL10> EKS_VraagPunte_A_AFRHL10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_AFRHL20> EKS_VraagPunte_A_AFRHL20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_AFRHL30> EKS_VraagPunte_A_AFRHL30 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_AFRSA10> EKS_VraagPunte_A_AFRSA10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_AFRSA20> EKS_VraagPunte_A_AFRSA20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_AFRSA30> EKS_VraagPunte_A_AFRSA30 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_AGRM10> EKS_VraagPunte_A_AGRM10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_AGRS10> EKS_VraagPunte_A_AGRS10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_AGRS20> EKS_VraagPunte_A_AGRS20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_AGRT10> EKS_VraagPunte_A_AGRT10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_ARBSA10> EKS_VraagPunte_A_ARBSA10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_ARBSA20> EKS_VraagPunte_A_ARBSA20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_BSTD10> EKS_VraagPunte_A_BSTD10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_BSTD20> EKS_VraagPunte_A_BSTD20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_BSTDZ10> EKS_VraagPunte_A_BSTDZ10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_CATN10> EKS_VraagPunte_A_CATN10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_CATN20> EKS_VraagPunte_A_CATN20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_CHNSA10> EKS_VraagPunte_A_CHNSA10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_CNST10> EKS_VraagPunte_A_CNST10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_CVTC10> EKS_VraagPunte_A_CVTC10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_CVTV10> EKS_VraagPunte_A_CVTV10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_CVTW10> EKS_VraagPunte_A_CVTW10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_DNCE10> EKS_VraagPunte_A_DNCE10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_DRMA10> EKS_VraagPunte_A_DRMA10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_DSGN10> EKS_VraagPunte_A_DSGN10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_ECON10> EKS_VraagPunte_A_ECON10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_ECON20> EKS_VraagPunte_A_ECON20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_ELTD10> EKS_VraagPunte_A_ELTD10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_ELTE10> EKS_VraagPunte_A_ELTE10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_ELTP10> EKS_VraagPunte_A_ELTP10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_ENGHL10> EKS_VraagPunte_A_ENGHL10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_ENGHL30> EKS_VraagPunte_A_ENGHL30 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_ENGSA10> EKS_VraagPunte_A_ENGSA10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_ENGSA20> EKS_VraagPunte_A_ENGSA20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_ENGSA30> EKS_VraagPunte_A_ENGSA30 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_EQNS10> EKS_VraagPunte_A_EQNS10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_FRHSA10> EKS_VraagPunte_A_FRHSA10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_FRHSA20> EKS_VraagPunte_A_FRHSA20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_GEOG10> EKS_VraagPunte_A_GEOG10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_GEOG20> EKS_VraagPunte_A_GEOG20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_GRDS10> EKS_VraagPunte_A_GRDS10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_GRDS20> EKS_VraagPunte_A_GRDS20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_GRMSA10> EKS_VraagPunte_A_GRMSA10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_GRMSA20> EKS_VraagPunte_A_GRMSA20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_HBRSA10> EKS_VraagPunte_A_HBRSA10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_HBRSA20> EKS_VraagPunte_A_HBRSA20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_HIST10> EKS_VraagPunte_A_HIST10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_HIST20> EKS_VraagPunte_A_HIST20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_HOSP10> EKS_VraagPunte_A_HOSP10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_INFT10> EKS_VraagPunte_A_INFT10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_INFT20> EKS_VraagPunte_A_INFT20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_LFSC10> EKS_VraagPunte_A_LFSC10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_LFSC20> EKS_VraagPunte_A_LFSC20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_MANSA10> EKS_VraagPunte_A_MANSA10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_MANSA20> EKS_VraagPunte_A_MANSA20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_MATH10> EKS_VraagPunte_A_MATH10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_MATH20> EKS_VraagPunte_A_MATH20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_MCTA10> EKS_VraagPunte_A_MCTA10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_MCTF10> EKS_VraagPunte_A_MCTF10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_MCTW10> EKS_VraagPunte_A_MCTW10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_MRSC10> EKS_VraagPunte_A_MRSC10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_MRSC20> EKS_VraagPunte_A_MRSC20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_MRTE10> EKS_VraagPunte_A_MRTE10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_MUSC10> EKS_VraagPunte_A_MUSC10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_MUSC20> EKS_VraagPunte_A_MUSC20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_NTSC10> EKS_VraagPunte_A_NTSC10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_NTSC20> EKS_VraagPunte_A_NTSC20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_PHSC10> EKS_VraagPunte_A_PHSC10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_PHSC20> EKS_VraagPunte_A_PHSC20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_PRGFA10> EKS_VraagPunte_A_PRGFA10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_PRGFA20> EKS_VraagPunte_A_PRGFA20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_PRGFA30> EKS_VraagPunte_A_PRGFA30 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_PRGSA10> EKS_VraagPunte_A_PRGSA10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_PRGSA20> EKS_VraagPunte_A_PRGSA20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_RLGS10> EKS_VraagPunte_A_RLGS10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_RLGS20> EKS_VraagPunte_A_RLGS20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_RLGSZ10> EKS_VraagPunte_A_RLGSZ10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_RLGSZ20> EKS_VraagPunte_A_RLGSZ20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_SASHL10> EKS_VraagPunte_A_SASHL10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_SASHL20> EKS_VraagPunte_A_SASHL20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_SASHL30> EKS_VraagPunte_A_SASHL30 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_SESHL10> EKS_VraagPunte_A_SESHL10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_SESHL20> EKS_VraagPunte_A_SESHL20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_SESHL30> EKS_VraagPunte_A_SESHL30 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_SPES10> EKS_VraagPunte_A_SPES10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_SPNSA10> EKS_VraagPunte_A_SPNSA10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_SPNSA20> EKS_VraagPunte_A_SPNSA20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_TMAT10> EKS_VraagPunte_A_TMAT10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_TMAT20> EKS_VraagPunte_A_TMAT20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_TRNP710> EKS_VraagPunte_A_TRNP710 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_TRSM10> EKS_VraagPunte_A_TRSM10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_TSCE10> EKS_VraagPunte_A_TSCE10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_TSCE20> EKS_VraagPunte_A_TSCE20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_URDFA10> EKS_VraagPunte_A_URDFA10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_URDFA20> EKS_VraagPunte_A_URDFA20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_URDFA30> EKS_VraagPunte_A_URDFA30 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_URDSA10> EKS_VraagPunte_A_URDSA10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_URDSA20> EKS_VraagPunte_A_URDSA20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_VSLA10> EKS_VraagPunte_A_VSLA10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_XHOFA10> EKS_VraagPunte_A_XHOFA10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_XHOFA20> EKS_VraagPunte_A_XHOFA20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_XHOFA30> EKS_VraagPunte_A_XHOFA30 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_XHOHL10> EKS_VraagPunte_A_XHOHL10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_XHOHL20> EKS_VraagPunte_A_XHOHL20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_XHOHL30> EKS_VraagPunte_A_XHOHL30 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_XHOSA10> EKS_VraagPunte_A_XHOSA10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_XHOSA20> EKS_VraagPunte_A_XHOSA20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_XHOSA30> EKS_VraagPunte_A_XHOSA30 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_ZULHL10> EKS_VraagPunte_A_ZULHL10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_ZULHL20> EKS_VraagPunte_A_ZULHL20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_ZULHL30> EKS_VraagPunte_A_ZULHL30 { get; set; }
        public virtual DbSet<FOUT_BOODSKAPPE> FOUT_BOODSKAPPE { get; set; }
        public virtual DbSet<Intervalle> Intervalles { get; set; }
        public virtual DbSet<Sentrumadresly> Sentrumadreslys { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tariewe> Tariewes { get; set; }
        public virtual DbSet<tblActiveSubject> tblActiveSubjects { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vakke> Vakkes { get; set; }
        public virtual DbSet<Vakleer> Vakleers { get; set; }
        public virtual DbSet<Vraagleer> Vraagleers { get; set; }
        public virtual DbSet<VraagleerPreviousYear> VraagleerPreviousYears { get; set; }
        public virtual DbSet<VraagleerVraestelle> VraagleerVraestelles { get; set; }
        public virtual DbSet<Vraestelle> Vraestelles { get; set; }
        public virtual DbSet<VraestelVerpakking_datum> VraestelVerpakking_Data { get; set; }
        public virtual DbSet<BoxNommersPerVraestel> BoxNommersPerVraestels { get; set; }
        public virtual DbSet<Databasis_Path> Databasis_Path { get; set; }
        public virtual DbSet<DatabasisNommer> DatabasisNommers { get; set; }
        public virtual DbSet<DataCapturer> DataCapturers { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_ZULFA10> EKS_VraagPunte_A_ZULFA10 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_ZULFA20> EKS_VraagPunte_A_ZULFA20 { get; set; }
        public virtual DbSet<EKS_VraagPunte_A_ZULFA30> EKS_VraagPunte_A_ZULFA30 { get; set; }
        public virtual DbSet<EMDC> EMDCs { get; set; }
        public virtual DbSet<ExamDate> ExamDates { get; set; }
        public virtual DbSet<FoutWagwoord> FoutWagwoords { get; set; }
        public virtual DbSet<GeenKandidate> GeenKandidates { get; set; }
        public virtual DbSet<GetalKandidatePerVraestel> GetalKandidatePerVraestels { get; set; }
        public virtual DbSet<Grade12File> Grade12File { get; set; }
        public virtual DbSet<MONITOR_SERVERS> MONITOR_SERVERS { get; set; }
        public virtual DbSet<MONITOR_SERVERS_DETAIL> MONITOR_SERVERS_DETAIL { get; set; }
        public virtual DbSet<PNTA> PNTAs { get; set; }
        public virtual DbSet<Punte> Puntes { get; set; }
        public virtual DbSet<SentrumsGetalPerVak> SentrumsGetalPerVaks { get; set; }
        public virtual DbSet<Stats_CapturersReport> Stats_CapturersReport { get; set; }
        public virtual DbSet<Stats_VerifiersReport> Stats_VerifiersReport { get; set; }
        public virtual DbSet<temp> temps { get; set; }
        public virtual DbSet<Vraagleer2020> Vraagleer2020 { get; set; }
        public virtual DbSet<VraagOntledingPerSentrumEnVraestel_OBO> VraagOntledingPerSentrumEnVraestel_OBOS { get; set; }
        public virtual DbSet<VraagOntledingPerSentrumPerVraestel> VraagOntledingPerSentrumPerVraestels { get; set; }
        public virtual DbSet<VraagOntledingPerSentrumPerVraestel_Relatief> VraagOntledingPerSentrumPerVraestel_Relatiefs { get; set; }
        public virtual DbSet<VraagOntledingPerWKODPerVraestel> VraagOntledingPerWKODPerVraestels { get; set; }
        public virtual DbSet<VraestellePerKampu> VraestellePerKampus { get; set; }
        public virtual DbSet<VraestelLokale> VraestelLokales { get; set; }
        public virtual DbSet<VraestelLokaleKleur> VraestelLokaleKleurs { get; set; }
        public virtual DbSet<Wagwoord_888_Vaslegging> Wagwoord_888_Vaslegging { get; set; }
        public virtual DbSet<EKS_PUNTESTATE> EKS_PUNTESTATE { get; set; }
    }
}
