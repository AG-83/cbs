/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Commands.Validation;
using Domain.Projects;
using FluentValidation;

namespace Domain.HealthRisks
{
    public class AddProjectHealthRiskValidator : CommandInputValidatorFor<AddProjectHealthRisk>
    {
        public AddProjectHealthRiskValidator(IProjectHealthRiskRules projectHealthRiskRules)
        {
            RuleFor(_ => _.ProjectId)
                .Must(projectHealthRiskRules.IsWithinNumberOfHealthRisksLimit)
                .WithMessage("Project does not allow health risks to be added");
            RuleFor(_ => _)
                .Must(p => projectHealthRiskRules.IsHealthRiskUniqueWithinProject(p.HealthRiskId, p.ProjectId))
                .WithMessage("Project does not allow health risks to be added");
            RuleFor(_ => _)
                .Must(p => projectHealthRiskRules.IsHealthRiskExisting(p.HealthRiskId))
                .WithMessage("Project does not allow health risks to be added");
        }
    }
}