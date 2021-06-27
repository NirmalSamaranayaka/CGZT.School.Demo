using CGZT.School.Demo.Contracts.Common;
using CGZT.School.Demo.Contracts.MessageHandlers;
using CGZT.School.Demo.Contracts.Repository;
using CGZT.School.Demo.Entities;
using CGZT.School.Demo.Entities.DTO.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Business.Validators
{

    public class TeacherDetailsValidator : IValidator<Teacher>
    {
        private readonly ITeacherDetailsErrorMessageHandler _teacherDetailsErrorMessageHandler;

        private readonly ITeacherDetailsRepository _teacherDetailsRepository;

        public TeacherDetailsValidator(ITeacherDetailsErrorMessageHandler teacherDetailsErrorMessageHandler, ITeacherDetailsRepository teacherDetailsRepository)
        {
            _teacherDetailsErrorMessageHandler = teacherDetailsErrorMessageHandler;
            _teacherDetailsRepository = teacherDetailsRepository;
        }

        /// <summary>
        /// Validates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="messages">The messages.</param>
        /// <returns>
        /// validation status
        /// </returns>
        bool IValidator<Teacher>.Validate(Teacher obj, out IList<Message> messages)
        {
            messages = new List<Message>();

            if (_teacherDetailsRepository.SelectSpecificTeacherDetailByEmail(obj.Email))
            {
                messages.Add(_teacherDetailsErrorMessageHandler.TeacherDetailAlreadyExists());
            }

            if (messages.Count > 0)
            {
                return false;
            }

            return messages.Count == 0;
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~TeacherDetailsValidator()
        {
            Dispose(false);
        }
    }


}
