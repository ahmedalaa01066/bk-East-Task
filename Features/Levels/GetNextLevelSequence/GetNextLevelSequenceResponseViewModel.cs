using AutoMapper;
using EasyTask.Features.Users.Login;

namespace EasyTask.Features.Levels.GetNextLevelSequence
{
    public record GetNextLevelSequenceResponseViewModel
    ( int Sequence );
    public class GetNextLevelSequenceResponseViewModelProfile : Profile
    {
        public GetNextLevelSequenceResponseViewModelProfile()
        {
            CreateMap<int, GetNextLevelSequenceResponseViewModel>()
                .ConstructUsing(Sequence => new GetNextLevelSequenceResponseViewModel(Sequence));
        }
    }
}
