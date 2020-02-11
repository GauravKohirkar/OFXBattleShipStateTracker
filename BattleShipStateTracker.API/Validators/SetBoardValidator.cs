using BattleShipStateTracker.Data.CommandsDto;
using FluentValidation;

namespace BattleShipStateTracker.API.Validators
{
    public class SetBoardValidator : AbstractValidator<SetBoardDto>
    {
        public SetBoardValidator()
        {
            RuleFor(x => x)
                .NotNull();

            RuleFor(x => x.MatchId)
                .GreaterThan(0);

            RuleFor(x => x.SizeX)
                .GreaterThanOrEqualTo(8)
                .LessThanOrEqualTo(10);
                

            RuleFor(x => x.SizeY)
                .GreaterThanOrEqualTo(8)
                .LessThanOrEqualTo(10);
        }
    }
}
