﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit.Data.EntityFrameworkCore.Patterns;
using Havit.Data.Patterns.DataEntries;
using Havit.Data.Patterns.Repositories;

namespace MensaGymnazium.IntranetGen3.DataLayer.DataEntries
{
	[System.CodeDom.Compiler.GeneratedCode("Havit.Data.EntityFrameworkCore.CodeGenerator", "1.0")]
	public class SubjectCategoryEntries : DataEntries<MensaGymnazium.IntranetGen3.Model.SubjectCategory>, ISubjectCategoryEntries 
	{
		public MensaGymnazium.IntranetGen3.Model.SubjectCategory ForeignLanguage
        {
            get
            {
				if (foreignLanguage == null)
				{
					foreignLanguage = GetEntry(MensaGymnazium.IntranetGen3.Model.SubjectCategory.Entry.ForeignLanguage);
				}
				return foreignLanguage;
            }
        }
		private MensaGymnazium.IntranetGen3.Model.SubjectCategory foreignLanguage;

		public MensaGymnazium.IntranetGen3.Model.SubjectCategory Graduational
        {
            get
            {
				if (graduational == null)
				{
					graduational = GetEntry(MensaGymnazium.IntranetGen3.Model.SubjectCategory.Entry.Graduational);
				}
				return graduational;
            }
        }
		private MensaGymnazium.IntranetGen3.Model.SubjectCategory graduational;

		public MensaGymnazium.IntranetGen3.Model.SubjectCategory NotDefined
        {
            get
            {
				if (notDefined == null)
				{
					notDefined = GetEntry(MensaGymnazium.IntranetGen3.Model.SubjectCategory.Entry.NotDefined);
				}
				return notDefined;
            }
        }
		private MensaGymnazium.IntranetGen3.Model.SubjectCategory notDefined;

		public MensaGymnazium.IntranetGen3.Model.SubjectCategory Seminars
        {
            get
            {
				if (seminars == null)
				{
					seminars = GetEntry(MensaGymnazium.IntranetGen3.Model.SubjectCategory.Entry.Seminars);
				}
				return seminars;
            }
        }
		private MensaGymnazium.IntranetGen3.Model.SubjectCategory seminars;

		public MensaGymnazium.IntranetGen3.Model.SubjectCategory SpecialSeminars
        {
            get
            {
				if (specialSeminars == null)
				{
					specialSeminars = GetEntry(MensaGymnazium.IntranetGen3.Model.SubjectCategory.Entry.SpecialSeminars);
				}
				return specialSeminars;
            }
        }
		private MensaGymnazium.IntranetGen3.Model.SubjectCategory specialSeminars;

		public SubjectCategoryEntries(MensaGymnazium.IntranetGen3.DataLayer.Repositories.ISubjectCategoryRepository repository)
			: base(repository)
		{
		}
	}
}