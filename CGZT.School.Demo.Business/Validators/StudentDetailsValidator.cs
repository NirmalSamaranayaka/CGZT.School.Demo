using CGZT.School.Demo.Contracts.Common;
using CGZT.School.Demo.Contracts.MessageHandlers;
using CGZT.School.Demo.Contracts.Repository;
using CGZT.School.Demo.Entities;
using CGZT.School.Demo.Entities.DTO.StudentTeacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Business.Validators
{
    public class StudentDetailsValidator : IValidator<Students>
    {
        private readonly IStudentDetailsErrorMessageHandler _studentDetailsErrorMessageHandler;

        private readonly IStudentDetailsRepository _studentDetailsRepository;

        public StudentDetailsValidator(IStudentDetailsErrorMessageHandler studentDetailsErrorMessageHandler, IStudentDetailsRepository studentDetailsRepository)
        {
            _studentDetailsErrorMessageHandler = studentDetailsErrorMessageHandler;
            _studentDetailsRepository = studentDetailsRepository;
        }

        /// <summary>
        /// Validates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="messages">The messages.</param>
        /// <returns>
        /// validation status
        /// </returns>
        bool IValidator<Students>.Validate(Students obj, out IList<Message> messages)
        {
            bool isNewUser = obj.Id == 0 ? true : false;

            messages = new List<Message>();

            var existingUserObj = _studentDetailsRepository.SelectSpecificStudentDetailByEmail(obj.Email);

            if (isNewUser)
            {

                if (existingUserObj != null)
                {
                    messages.Add(_studentDetailsErrorMessageHandler.StudentDetailAlreadyExists());
                }

            }
            else
            {

                if (existingUserObj != null && existingUserObj.Id != obj.Id)
                {
                    messages.Add(_studentDetailsErrorMessageHandler.StudentDetailAlreadyExists());

                }

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

        ~StudentDetailsValidator()
        {
            Dispose(false);
        }
    }

}
