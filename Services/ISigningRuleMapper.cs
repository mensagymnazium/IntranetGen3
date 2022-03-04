using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.Model;

namespace MensaGymnazium.IntranetGen3.Services
{
	public interface ISigningRuleMapper
	{
		SigningRuleDto MapToSigningRuleDto(SigningRule signingRule);

		void MapFromSigningRuleDto(SigningRuleDto signingRuleDto, SigningRule signingRule);

	}
}
