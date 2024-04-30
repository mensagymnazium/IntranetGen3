using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.DataLayer.Seeds.Core;

public class GraduationSubjectSeed : DataSeed<CoreProfile>
{
	public override void SeedData()
	{
		var data = new[]
		{
			new GraduationSubject() { Name = "český jazyk a literatura", Id = (int)GraduationSubject.Entry.CzechLanguageLiterature },
			new GraduationSubject() { Name = "matematika", Id = (int)GraduationSubject.Entry.Math },
			new GraduationSubject() { Name = "informatika a výpočetní technika", Id = (int)GraduationSubject.Entry.Informatics },
			new GraduationSubject() { Name = "fyzika", Id = (int)GraduationSubject.Entry.Physics },
			new GraduationSubject() { Name = "chemie", Id = (int)GraduationSubject.Entry.Chemistry },
			new GraduationSubject() { Name = "biologie", Id = (int)GraduationSubject.Entry.Biology },
			new GraduationSubject() { Name = "estetika - dějiny výtvarného umění", Id = (int)GraduationSubject.Entry.ArtHistory },
			new GraduationSubject() { Name = "dějepis", Id = (int)GraduationSubject.Entry.History },
			new GraduationSubject() { Name = "zeměpis", Id = (int)GraduationSubject.Entry.Geography },
			new GraduationSubject() { Name = "filozofie", Id = (int)GraduationSubject.Entry.Philosophy },
			new GraduationSubject() { Name = "psychologie", Id = (int)GraduationSubject.Entry.Psychology },
			new GraduationSubject() { Name = "sociologie", Id = (int)GraduationSubject.Entry.Sociology },
			new GraduationSubject() { Name = "ekonomie", Id = (int)GraduationSubject.Entry.Economy },
			new GraduationSubject() { Name = "právo", Id = (int)GraduationSubject.Entry.Law },
			new GraduationSubject() { Name = "politologie", Id = (int)GraduationSubject.Entry.PoliticalScience },
			new GraduationSubject() { Name = "anglický jazyk", Id = (int)GraduationSubject.Entry.English },
			new GraduationSubject() { Name = "druhý cizí jazyk", Id = (int)GraduationSubject.Entry.ForeignLanguage },
			new GraduationSubject() { Name = "člověk a svět práce", Id = (int)GraduationSubject.Entry.HumanWork },
		};

		Seed(For(data).PairBy(st => st.Id));
	}
}
