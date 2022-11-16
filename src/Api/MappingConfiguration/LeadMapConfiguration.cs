using AutoMapper;

namespace Api.MappingConfiguration;

public class LeadMapConfiguration : Profile
{
	public LeadMapConfiguration()
	{
		CreateMap<ViewModels.Lead.LeadsViewModel, Domain.Aggregates.Leads.Lead>();

		CreateMap<ViewModels.Lead.LeadsViewModel, Domain.Aggregates.Leads.Lead>()
				.ReverseMap()
				.ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.FirstName.Value))
				.ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.LastName.Value))
				.ForMember(dest => dest.Rating, opts => opts.MapFrom(src => src.Rating.Value))
				.ForMember(dest => dest.Industry, opts => opts.MapFrom(src => src.Industry.Value))
				.ForMember(dest => dest.LeadSource, opts => opts.MapFrom(src => src.LeadSource.Value))
				.ForMember(dest => dest.LeadStatus, opts => opts.MapFrom(src => src.LeadStatus.Value))
				.ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email.Value))
				.ForMember(dest => dest.FullName, opts => opts.MapFrom(src => src.FullName.ToString()));

	}
}
