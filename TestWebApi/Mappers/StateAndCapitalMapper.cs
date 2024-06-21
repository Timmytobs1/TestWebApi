
using TestWebApi.Dtos.StateAndCapital;
using TestWebApi.Models;

namespace TestWebApi.Mappers
{
    public static class StateAndCapitalMapper
    {
        public static StateAndCapitalDto ToDto(this StateAndCapital stateandcapitalModel)
        {
            return new StateAndCapitalDto
            {
                StateName = stateandcapitalModel.StateName,
                CapitalName = stateandcapitalModel.CapitalName,

            };
        }

        public static StateAndCapital ToStateCapitalFromAddDTO(this StateAndCapitalDto stateandcapitalModel)
        {
            return new StateAndCapital
            {
                StateName = stateandcapitalModel.StateName,
                CapitalName = stateandcapitalModel.CapitalName,

            };
        }

        public static StateDto ToStateDto(this StateAndCapital stateandcapitalModel)
        {
            return new StateDto
            {
                StateName = stateandcapitalModel.StateName,

            };
        }

        public static CapitalDto ToCapitalDto(this StateAndCapital stateandcapitalModel)
        {
            return new CapitalDto
            {
                CapitalName = stateandcapitalModel.CapitalName,

            };
        }
    }
}
