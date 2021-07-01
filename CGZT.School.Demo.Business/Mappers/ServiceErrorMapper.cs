using CGZT.School.Demo.Contracts.Common;
using CGZT.School.Demo.Entities;
using CGZT.School.Demo.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Business.Mappers
{
    /// <summary>
    /// Service Errror Mapper
    /// </summary>
    public class ServiceErrorMapper : IMapper<IList<Message>, ServiceResponse>
    {
        /// <summary>
        /// Maps the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        public ServiceResponse Map(IList<Message> input) => new ServiceResponse
        {
            IsError = true,
            Messages = input
        };
    }
}
