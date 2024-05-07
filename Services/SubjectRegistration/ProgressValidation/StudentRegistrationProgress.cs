using System;

namespace MensaGymnazium.IntranetGen3.Services.SubjectRegistration.ProgressValidation;

/// <summary>
/// 
/// </summary>
/// <param name="IsRegistrationValid">
/// When true, the student has registered all of his subjects correctly,
/// meaning he meets all the signing criteria, or a combination of them,
/// that results in a valid registration
/// </param>
/// <param name="HoursPerWeekProgress">
/// Progress of the rule about weekly donated hours
/// </param>
/// <param name="CsOrCpRegistrationProgress">
/// Progress of the rule:
/// 'N musí být ze vzdělávacích oblastí „Člověk a
/// společnost“ či „Člověk a příroda“'
/// </param>
/// <param name="LanguageRegistrationProgress">
/// Progress of the rule about having a language
/// </param>
/// <param name="CanUseLanguageInsteadOfHoursPerWeek">
/// If true, the student may choose a language instead of completing the donated hours mark.
/// Applied to Sekunda (2023/2024) and stated:
/// '1 volitelný předmět (může být i druhý cizí 
/// jazyk s dotací 2 hodiny týdně)'
/// </param>
public record StudentRegistrationProgress(
	bool IsRegistrationValid,
	StudentHoursPerWeekProgress HoursPerWeekProgress,
	StudentCsOrCpRegistrationProgress CsOrCpRegistrationProgress,
	StudentLanguageRegistrationProgress LanguageRegistrationProgress,
	bool CanUseLanguageInsteadOfHoursPerWeek);
