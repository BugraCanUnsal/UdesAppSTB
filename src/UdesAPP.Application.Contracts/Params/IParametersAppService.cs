using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace UdesAPP.Params
{
    public interface IParametersAppService : IApplicationService
    {
        Task<List<ParametersDto>> GetParametersByParamType(string paramType);
    }
}
