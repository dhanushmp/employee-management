using AutoMapper;
using EmployeeManagementSystem.Dto;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Helper
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<EmployeeDetail, EmployeeDetailDto>();
            CreateMap<EmployeeDesignationDetail, EmployeeDesignationDetailDto>();
            CreateMap<EmployeeDetailDto, EmployeeDetail>();
            CreateMap<EmployeeDesignationDetailDto, EmployeeDesignationDetail>();
            CreateMap<Leave, LeaveDto>();
            CreateMap<LeaveDto, Leave>();
            CreateMap<PaymentRule, PaymentRuleDto>();
            CreateMap<PaymentRuleDto, PaymentRule>();
            CreateMap<WorkingHour, WorkingHourDto>();
            CreateMap<WorkingHourDto, WorkingHour>();


        } 
    }
}
