using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdesAPP.Repositories;
using Volo.Abp.Application.Services;

namespace UdesAPP.Params
{
    [Authorize("UdesAPP.HostPermission")]
    public class ParametersAppService : ApplicationService, IParametersAppService
    {
        private readonly ParametersManager _parametersManager;

        public ParametersAppService(ParametersManager parametersManager)
        {
            _parametersManager = parametersManager;
        }
        public async Task<List<ParametersDto>> GetParametersByParamType(string paramType)
        {
            List<Param> parameters = await _parametersManager.GetParametersByParamType(paramType);
            return ObjectMapper.Map<List<Param>, List<ParametersDto>>(parameters);
        }
    }
}
