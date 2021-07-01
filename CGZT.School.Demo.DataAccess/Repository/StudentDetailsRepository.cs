using CGZT.School.Demo.Contracts.Repository;
using CGZT.School.Demo.DataContext.DemoDataModels;
using CGZT.School.Demo.DataContext.DemoDbContext;
using CGZT.School.Demo.Entities.DTO.StudentTeacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.DataAccess.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="CGZT.School.Demo.DataAccess.Repository.GenericDataRepository{CGZT.School.Demo.DataContext.DemoDataModels.DemoTStudent, CGZT.School.Demo.Entities.DTO.Student.Student}" />
    /// <seealso cref="CGZT.School.Demo.Contracts.Repository.IStudentDetailsRepository" />
    public class StudentDetailsRepository : GenericDataRepository<DemoTStudent, Students>, IStudentDetailsRepository
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentDetailsRepository"/> class.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public StudentDetailsRepository(DemoEntities entities) : base(entities)
        {
        }

        /// <summary>
        /// Gets all student detail asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Students>> GetAllStudentDetailAsync()
        {
            return await base.GetAllAsync();
        }

        /// <summary>
        /// Adds the student detail.
        /// </summary>
        /// <param name="cmodityDetail">The cmodity detail.</param>
        /// <returns></returns>
        public Students AddStudentDetail(Students cmodityDetail)
        {
            return base.InsertModel(cmodityDetail);
        }

        /// <summary>
        /// Updates the student detail.
        /// </summary>
        /// <param name="cmodityDetail">The cmodity detail.</param>
        /// <returns></returns>
        public Students UpdateStudentDetail(Students cmodityDetail)
        {
            return base.UpdateModel(cmodityDetail);
        }

        /// <summary>
        /// Selects the specific student detail.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Students SelectSpecificStudentDetail(int id)
        {
            return base.SingleOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Selects the specific student detail by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public Students SelectSpecificStudentDetailByEmail(string email)
        {
            return base.SingleOrDefault(p => p.Email.ToLower() == email.ToLower());
        }

        /// <summary>
        /// Determines whether [is exist student detail] [the specified name].
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        ///   <c>true</c> if [is exist student detail] [the specified name]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsExistStudentDetail(string name)
        {
            return base.Any(p => p.Name.ToLower() == name.ToLower());
        }

    }
}
