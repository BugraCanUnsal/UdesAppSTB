using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using UdesAPP.Params;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace UdesAPP.Repositories
{
    public class ParametersManager : IDomainService
    {
        public readonly IRepository<Param> _parameterRepository;

        public ParametersManager(IRepository<Param> parameterRepository)
        {
            _parameterRepository = parameterRepository;
        }

        public async Task<List<Param>> GetParametersByParamType(string paramType) {

            List<Param> parameters = await _parameterRepository.GetListAsync();
            if (parameters != null && !String.IsNullOrEmpty(paramType))
            {
                List<Param> parameter = parameters.FindAll(x=> x.Paramtype == paramType);
                if (parameter != null) { return await Task.FromResult(parameter); }
            }
            return await Task.FromResult(parameters);
        }
    }
}
