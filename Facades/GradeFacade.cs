using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;
using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Facades;

[Service]
[Authorize]
public class GradeFacade : IGradeFacade
{
	private readonly IGradeRepository gradeRepository;
	private readonly IUnitOfWork unitOfWork;

	public GradeFacade(IGradeRepository gradeRepository, IUnitOfWork unitOfWork)
	{
		this.gradeRepository = gradeRepository;
		this.unitOfWork = unitOfWork;
	}

	public async Task<List<GradeDto>> GetAllGradesAsync(CancellationToken cancellationToken = default)
	{
		var data = await gradeRepository.GetAllAsync(cancellationToken);

		return data
			.Select(g => new GradeDto()
			{
				Id = g.Id,
				Name = g.Name
			})
			.ToList();
	}

	[Authorize(Roles = nameof(Role.Administrator))]
	public async Task<List<GradeRegistrationCriteriaDto>> GetGradeRegistrationCriteriasAsync(CancellationToken cancellationToken = default)
	{
		// Only ever get 8 elements, so we can load all to memory
		var grades = await gradeRepository.GetAllAsync(cancellationToken);

		return grades
			.Select(g => new GradeRegistrationCriteriaDto()
			{
				GradeId =
					g.Id,

				CanUseForeignLanguageInsteadOfDonatedHours =
					g.RegistrationCriteria.CanUseForeignLanguageInsteadOfDonatedHours,

				RequiredAmountOfDonatedHoursInAreaCspOrCp =
					g.RegistrationCriteria.RequiredAmountOfDonatedHoursInAreaCspOrCp,

				RequiredTotalAmountOfDonatedHoursExcludingLanguage =
					g.RegistrationCriteria.RequiredTotalAmountOfDonatedHoursExcludingLanguage,

				RequiresCspOrCpValidation =
					g.RegistrationCriteria.RequiresCspOrCpValidation,

				RequiresForeignLanguage =
					g.RegistrationCriteria.RequiresForeginLanguage
			})
			.ToList();
	}

	[Authorize(Roles = nameof(Role.Administrator))]
	public async Task UpdateGradeRegistrationCriteriaAsync(GradeRegistrationCriteriaDto model, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(model is not null);
		if (model.CanUseForeignLanguageInsteadOfDonatedHours && model.RequiresForeignLanguage)
		{
			// Xopa: Maybe app logic is leaking and this should be a service?
			throw new InvalidOperationException("Ročník nemůže vyžadovat jazyk a zároveň ho využít namísto hodin v rozvrhu");
		}

		var grade = await gradeRepository.GetObjectAsync(model.GradeId, cancellationToken);

		MapRegistrationCriteriaFromDTO(model, grade.RegistrationCriteria);

		unitOfWork.AddForUpdate(grade);
		await unitOfWork.CommitAsync(cancellationToken);
	}

	private void MapRegistrationCriteriaFromDTO(GradeRegistrationCriteriaDto dto, GradeRegistrationCriteria criteria)
	{
		criteria.CanUseForeignLanguageInsteadOfDonatedHours = dto.CanUseForeignLanguageInsteadOfDonatedHours;
		criteria.RequiredAmountOfDonatedHoursInAreaCspOrCp = dto.RequiredAmountOfDonatedHoursInAreaCspOrCp;
		criteria.RequiredTotalAmountOfDonatedHoursExcludingLanguage = dto.RequiredTotalAmountOfDonatedHoursExcludingLanguage;
		criteria.RequiresCspOrCpValidation = dto.RequiresCspOrCpValidation;
		criteria.RequiresForeginLanguage = dto.RequiresForeignLanguage;
	}
}
