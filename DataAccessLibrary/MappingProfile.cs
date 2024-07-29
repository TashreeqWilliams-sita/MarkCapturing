using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTOs;

namespace DataAccessLibrary
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

			CreateMap<vw_Marksheets_ACCN10, MarksheetDTO>();

			CreateMap<vw_Marksheets_ACCN20, MarksheetDTO>();

			CreateMap<vw_Marksheets_ACCNZ10, MarksheetDTO>();

			CreateMap<vw_Marksheets_AFRFA10, MarksheetDTO>();

			CreateMap<vw_Marksheets_AFRFA20, MarksheetDTO>();

			CreateMap<vw_Marksheets_AFRFA30, MarksheetDTO>();

			CreateMap<vw_Marksheets_AFRHL10, MarksheetDTO>();

			CreateMap<vw_Marksheets_AFRHL20, MarksheetDTO>();

			CreateMap<vw_Marksheets_AFRHL30, MarksheetDTO>();

			CreateMap<vw_Marksheets_AFRSA10, MarksheetDTO>();

			CreateMap<vw_Marksheets_AFRSA20, MarksheetDTO>();

			CreateMap<vw_Marksheets_AFRSA30, MarksheetDTO>();

			CreateMap<vw_Marksheets_AGRM10, MarksheetDTO>();

			CreateMap<vw_Marksheets_AGRS10, MarksheetDTO>();

			CreateMap<vw_Marksheets_AGRS20, MarksheetDTO>();

			CreateMap<vw_Marksheets_AGRT10, MarksheetDTO>();

			CreateMap<vw_Marksheets_ARBSA10, MarksheetDTO>();

			CreateMap<vw_Marksheets_ARBSA20, MarksheetDTO>();

			CreateMap<vw_Marksheets_BSTD10, MarksheetDTO>();

			CreateMap<vw_Marksheets_BSTD20, MarksheetDTO>();

			CreateMap<vw_Marksheets_BSTDZ10, MarksheetDTO>();

			CreateMap<vw_Marksheets_CATN10, MarksheetDTO>();

			CreateMap<vw_Marksheets_CATN20, MarksheetDTO>();

			CreateMap<vw_Marksheets_CHNSA10, MarksheetDTO>();

			CreateMap<vw_Marksheets_CNST10, MarksheetDTO>();

			CreateMap<vw_Marksheets_CVTC10, MarksheetDTO>();

			CreateMap<vw_Marksheets_CVTV10, MarksheetDTO>();

			CreateMap<vw_Marksheets_CVTW10, MarksheetDTO>();

			CreateMap<vw_Marksheets_DNCE10, MarksheetDTO>();

			CreateMap<vw_Marksheets_DRMA10, MarksheetDTO>();

			CreateMap<vw_Marksheets_DSGN10, MarksheetDTO>();

			CreateMap<vw_Marksheets_ECON10, MarksheetDTO>();

			CreateMap<vw_Marksheets_ECON20, MarksheetDTO>();

			CreateMap<vw_Marksheets_ELTD10, MarksheetDTO>();

			CreateMap<vw_Marksheets_ELTE10, MarksheetDTO>();

			CreateMap<vw_Marksheets_ELTP10, MarksheetDTO>();

			CreateMap<vw_Marksheets_ENGFA10, MarksheetDTO>();

			CreateMap<vw_Marksheets_ENGFA20, MarksheetDTO>();

			CreateMap<vw_Marksheets_ENGFA30, MarksheetDTO>();

			CreateMap<vw_Marksheets_ENGHL10, MarksheetDTO>();

			CreateMap<vw_Marksheets_ENGHL20, MarksheetDTO>();

			CreateMap<vw_Marksheets_ENGHL30, MarksheetDTO>();

			CreateMap<vw_Marksheets_ENGSA10, MarksheetDTO>();

			CreateMap<vw_Marksheets_ENGSA20, MarksheetDTO>();

			CreateMap<vw_Marksheets_ENGSA30, MarksheetDTO>();

			CreateMap<vw_Marksheets_EQNS10, MarksheetDTO>();

			CreateMap<vw_Marksheets_FRHSA10, MarksheetDTO>();

			CreateMap<vw_Marksheets_FRHSA20, MarksheetDTO>();

			CreateMap<vw_Marksheets_GEOG10, MarksheetDTO>();

			CreateMap<vw_Marksheets_GEOG20, MarksheetDTO>();

			CreateMap<vw_Marksheets_GRDS10, MarksheetDTO>();

			CreateMap<vw_Marksheets_GRDS20, MarksheetDTO>();

			CreateMap<vw_Marksheets_GRMSA10, MarksheetDTO>();

			CreateMap<vw_Marksheets_GRMSA20, MarksheetDTO>();

			CreateMap<vw_Marksheets_HBRSA10, MarksheetDTO>();

			CreateMap<vw_Marksheets_HBRSA20, MarksheetDTO>();

			CreateMap<vw_Marksheets_HIST10, MarksheetDTO>();

			CreateMap<vw_Marksheets_HIST20, MarksheetDTO>();

			CreateMap<vw_Marksheets_HOSP10, MarksheetDTO>();

			CreateMap<vw_Marksheets_INFT10, MarksheetDTO>();

			CreateMap<vw_Marksheets_INFT20, MarksheetDTO>();

			CreateMap<vw_Marksheets_LFSC10, MarksheetDTO>();

			CreateMap<vw_Marksheets_LFSC20, MarksheetDTO>();

			CreateMap<vw_Marksheets_MANSA10, MarksheetDTO>();

			CreateMap<vw_Marksheets_MANSA20, MarksheetDTO>();

			CreateMap<vw_Marksheets_MATH10, MarksheetDTO>();

			CreateMap<vw_Marksheets_MATH20, MarksheetDTO>();

			CreateMap<vw_Marksheets_MCTA10, MarksheetDTO>();

			CreateMap<vw_Marksheets_MCTF10, MarksheetDTO>();

			CreateMap<vw_Marksheets_MCTW10, MarksheetDTO>();

			CreateMap<vw_Marksheets_MLIT10, MarksheetDTO>();

			CreateMap<vw_Marksheets_MLIT20, MarksheetDTO>();

			CreateMap<vw_Marksheets_MRSC10, MarksheetDTO>();

			CreateMap<vw_Marksheets_MRSC20, MarksheetDTO>();

			CreateMap<vw_Marksheets_MRTE10, MarksheetDTO>();
	
			CreateMap<vw_Marksheets_MUSC10, MarksheetDTO>();

			CreateMap<vw_Marksheets_MUSC20, MarksheetDTO>();

			CreateMap<vw_Marksheets_NTSC10, MarksheetDTO>();

			CreateMap<vw_Marksheets_NTSC20, MarksheetDTO>();

			CreateMap<vw_Marksheets_PHSC10, MarksheetDTO>();

			CreateMap<vw_Marksheets_PHSC20, MarksheetDTO>();

			CreateMap<vw_Marksheets_PRGFA10, MarksheetDTO>();

			CreateMap<vw_Marksheets_PRGFA20, MarksheetDTO>();

			CreateMap<vw_Marksheets_PRGFA30, MarksheetDTO>();

			CreateMap<vw_Marksheets_PRGSA10, MarksheetDTO>();

			CreateMap<vw_Marksheets_PRGSA20, MarksheetDTO>();

			CreateMap<vw_Marksheets_RLGS10, MarksheetDTO>();

			CreateMap<vw_Marksheets_RLGS20, MarksheetDTO>();

			CreateMap<vw_Marksheets_RLGSZ10, MarksheetDTO>();

			CreateMap<vw_Marksheets_RLGSZ20, MarksheetDTO>();

			CreateMap<vw_Marksheets_SASHL10, MarksheetDTO>();

			CreateMap<vw_Marksheets_SASHL20, MarksheetDTO>();

			CreateMap<vw_Marksheets_SASHL30, MarksheetDTO>();

			CreateMap<vw_Marksheets_SESHL10, MarksheetDTO>();

			CreateMap<vw_Marksheets_SESHL20, MarksheetDTO>();

			CreateMap<vw_Marksheets_SESHL30, MarksheetDTO>();

			CreateMap<vw_Marksheets_SPES10, MarksheetDTO>();

			CreateMap<vw_Marksheets_SPNSA10, MarksheetDTO>();

			CreateMap<vw_Marksheets_SPNSA20, MarksheetDTO>();

			CreateMap<vw_Marksheets_TMAT10, MarksheetDTO>();

			CreateMap<vw_Marksheets_TMAT20, MarksheetDTO>();

			CreateMap<vw_Marksheets_TRNP710, MarksheetDTO>();

			CreateMap<vw_Marksheets_TRSM10, MarksheetDTO>();

			CreateMap<vw_Marksheets_TSCE10, MarksheetDTO>();

			CreateMap<vw_Marksheets_TSCE20, MarksheetDTO>();

			CreateMap<vw_Marksheets_URDFA10, MarksheetDTO>();

			CreateMap<vw_Marksheets_URDFA20, MarksheetDTO>();

			CreateMap<vw_Marksheets_URDFA30, MarksheetDTO>();

			CreateMap<vw_Marksheets_URDSA10, MarksheetDTO>();

			CreateMap<vw_Marksheets_URDSA20, MarksheetDTO>();

			CreateMap<vw_Marksheets_VSLA10, MarksheetDTO>();

			CreateMap<vw_Marksheets_XHOFA10, MarksheetDTO>();

			CreateMap<vw_Marksheets_XHOFA20, MarksheetDTO>();

			CreateMap<vw_Marksheets_XHOFA30, MarksheetDTO>();

			CreateMap<vw_Marksheets_XHOHL10, MarksheetDTO>();

			CreateMap<vw_Marksheets_XHOHL20, MarksheetDTO>();

			CreateMap<vw_Marksheets_XHOHL30, MarksheetDTO>();

			CreateMap<vw_Marksheets_XHOSA10, MarksheetDTO>();

			CreateMap<vw_Marksheets_XHOSA20, MarksheetDTO>();

			CreateMap<vw_Marksheets_XHOSA30, MarksheetDTO>();

			CreateMap<vw_Marksheets_ZULFA10, MarksheetDTO>();

			CreateMap<vw_Marksheets_ZULFA20, MarksheetDTO>();

			CreateMap<vw_Marksheets_ZULFA30, MarksheetDTO>();

			CreateMap<vw_Marksheets_ZULHL10, MarksheetDTO>();

			CreateMap<vw_Marksheets_ZULHL20, MarksheetDTO>();

			CreateMap<vw_Marksheets_ZULHL30, MarksheetDTO>();



		}
	}

}
