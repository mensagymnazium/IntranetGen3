﻿using FluentValidation;
using MensaGymnazium.IntranetGen3.Contracts.ModelMetadata;

namespace MensaGymnazium.IntranetGen3.Contracts;

public record SubjectDto : SubjectListItemDto
{
	public string Description { get; set; }

	public bool CanRegisterRepeatedly { get; set; }
	public int HoursPerWeek { get; set; }

	public class SubjectValidator : AbstractValidator<SubjectDto>
	{
		public SubjectValidator()
		{
			RuleFor(x => x.Name).NotEmpty().MaximumLength(SubjectMetadata.NameMaxLength).WithName("Název");
			RuleFor(x => x.Description).NotEmpty().MaximumLength(SubjectMetadata.DescriptionMaxLength).WithName("Popis");
			RuleFor(x => x.CategoryId).NotEmpty().WithName("Kategorie");
			RuleFor(x => x.ScheduleDayOfWeek).NotEmpty().WithName("Den");
			RuleFor(x => x.ScheduleSlotInDay).NotEmpty().WithName("Čas");
			RuleFor(x => x.HoursPerWeek).GreaterThan(0).LessThanOrEqualTo(4).WithName("Dotované hodiny");
		}
	}
}
