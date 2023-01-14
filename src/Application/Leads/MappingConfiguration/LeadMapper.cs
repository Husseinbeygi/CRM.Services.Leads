using Domain.Aggregates.Leads;
using Cyrus.DateTime;
using ViewModels.Lead;
using ViewModels.Lead.ValueObjects;

namespace Application.Leads.MappingConfiguration
{

	public static class LeadMapper
	{
		public static List<LeadsViewModel> Map(List<Lead> leads)
		{

			var res = new List<LeadsViewModel>();
			foreach (var item in leads)
			{
				res.Add(CoreMapper(item));
			}

			return res;
		}

		public static LeadsViewModel Map(Lead item)
		{
			var res = CoreMapper(item);

			return res;

		}

		private static LeadsViewModel CoreMapper(Lead item)
		{
			return new LeadsViewModel()
			{
				Code = item.Code,
				Salutaion = new ValueObject(item?.Salutation?.Value ?? 0, item?.Salutation?.Name ?? string.Empty),
				FirstName = item?.FirstName?.Value ?? string.Empty,
				LastName = item?.LastName?.Value ?? string.Empty,
				FullName = string.Concat(item?.Salutation?.Name, " ", item?.FirstName?.Value, " ", item?.LastName?.Value),
				AnnualRevenue = item?.AnnualRevenue ?? 0,
				City = item?.City ?? string.Empty,
				Company = item?.Company ?? string.Empty,
				Country = item?.Country ?? string.Empty,
				CreatedAt = item?.CreatedAt.ConvertToTimeZoneMilliseconds(-3.5),
				CreatedById = item?.CreatedById ?? Guid.Empty,
				Description = item?.Description ?? string.Empty,
				Email = item?.Email?.Value ?? string.Empty,
				Industry = new ValueObject(item?.Industry?.Value ?? 0, item?.Industry?.Name ?? string.Empty),
				LeadSource = new ValueObject(item?.LeadSource?.Value ?? 0, item?.LeadSource?.Name ?? string.Empty),
				LeadStatus = new ValueObject(item?.LeadStatus?.Value ?? 0, item?.LeadStatus?.Name ?? string.Empty),
				Mobile = item?.Mobile ?? string.Empty,
				ModifiedAt = item?.ModifiedAt.ConvertToTimeZoneMilliseconds(-3.5),
				ModifiedById = item?.ModifiedById ?? Guid.Empty,
				NumberOfEmployees = item?.NumberOfEmployees ?? 0,
				OwnerId = item?.OwnerId ?? Guid.Empty,
				Phone = item?.Phone ?? string.Empty,
				PostalCode = item?.PostalCode ?? string.Empty,
				Rating = new ValueObject(item?.Rating?.Value ?? 0, item?.Rating?.Name ?? string.Empty),
				State = item?.State ?? string.Empty,
				Street = item?.Street ?? string.Empty,
				TenantId = item?.TenantId ?? Guid.Empty,
				Title = item?.Title ?? string.Empty,
				Website = item?.Website ?? string.Empty,
				Id = item.Id,
				VersionNumber = item?.VersionNumber ?? 0,
				CreatedBy = string.Concat(item.CreatedBy.Fname, ".", item.CreatedBy.Lname) ?? string.Empty,
				ModifiedBy = string.Concat(item.ModifiedBy.Fname, ".", item.ModifiedBy.Lname) ?? string.Empty,
				Owner = string.Concat(item.Owner.Fname, ".", item.Owner.Lname) ?? string.Empty,
			};
		}
	}
}