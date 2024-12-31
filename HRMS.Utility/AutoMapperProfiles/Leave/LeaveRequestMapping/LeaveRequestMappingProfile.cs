using AutoMapper;
using HRMS.Dtos.Leave.Leave.LeaveRequestDtos;
using HRMS.Dtos.Leave.Leave.LeaveResponseDtos;
using HRMS.Entities.Leave.Leave.LeaveRequestEntities;
using HRMS.Entities.Leave.Leave.LeaveResponseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Utility.AutoMapperProfiles.Leave.LeaveRequestMapping
{
    public class LeaveRequestMappingProfile : Profile

    {
        public LeaveRequestMappingProfile()

        {
            CreateMap<LeaveRequestCreateRequestDto, LeaveRequestCreateRequestEntity>();
            CreateMap<LeaveRequestReadRequestDto, LeaverequestReadRequestEntity>();
            CreateMap<LeaveRequestUpdateRequestDto, LeaveRequestUpdateRequestEntity>();
            CreateMap<LeaveRequestDeleteRequestDto, LeaveRequestDeleteRequestEntity>();

            // Map between request entities and response entities
            CreateMap<LeaveRequestCreateRequestEntity, LeaveRequestCreateResponseEntity>();
            CreateMap<LeaverequestReadRequestEntity, LeaveRequestReadResponseEntity>();
            CreateMap<LeaveRequestUpdateRequestEntity, LeaveRequestUpdateResponseEntity>();
            CreateMap<LeaveRequestDeleteRequestEntity, LeaveRequestDeleteResponseEntity>();

            // Map between response entities and DTOs
            CreateMap<LeaveRequestCreateResponseEntity, LeaveRequestCreateResponseDto>();
            CreateMap<LeaveRequestReadResponseEntity, LeaveRequestReadResponseDto>();
            CreateMap<LeaveRequestUpdateResponseEntity, LeaveRequestUpdateResponseDto>();
            CreateMap<LeaveRequestDeleteResponseEntity, LeaveRequestDeleteResponseDto>();
        }
    }
}
