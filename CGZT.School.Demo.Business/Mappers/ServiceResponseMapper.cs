using CGZT.School.Demo.Contracts.Common;
using CGZT.School.Demo.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Business.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="CGZT.School.Demo.Contracts.Common.IMapper{System.Object, CGZT.School.Demo.Entities.Common.ServiceResponse}" />
    public class ServiceResponseMapper : IMapper<Object, ServiceResponse>
    {
        /// <summary>
        /// Maps the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public ServiceResponse Map(object input)
        {
            return new ServiceResponse
            {
                ReturnObject = input,
                IsError = false
            };
        }
    }
}
