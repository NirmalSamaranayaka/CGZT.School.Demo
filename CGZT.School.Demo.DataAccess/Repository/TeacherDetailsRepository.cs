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
    /// <seealso cref="CGZT.School.Demo.DataAccess.Repository.GenericDataRepository{CGZT.School.Demo.DataContext.DemoDataModels.DemoTTeacher, CGZT.School.Demo.Entities.DTO.Teacher.Teacher}" />
    /// <seealso cref="CGZT.School.Demo.Contracts.Repository.ITeacherDetailsRepository" />
    public class TeacherDetailsRepository : GenericDataRepository<DemoTTeacher, Teacher>, ITeacherDetailsRepository
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TeacherDetailsRepository"/> class.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public TeacherDetailsRepository(DemoEntities entities) : base(entities)
        {
        }

        /// <summary>
        /// Gets all teacher detail asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Teacher>> GetAllTeacherDetailAsync()
        {
            return await base.GetAllAsync();
        }

        /// <summary>
        /// Adds the teacher detail.
        /// </summary>
        /// <param name="cmodityDetail">The cmodity detail.</param>
        /// <returns></returns>
        public Teacher AddTeacherDetail(Teacher cmodityDetail)
        {
            return base.InsertModel(cmodityDetail);
        }

        /// <summary>
        /// Updates the teacher detail.
        /// </summary>
        /// <param name="cmodityDetail">The cmodity detail.</param>
        /// <returns></returns>
        public Teacher UpdateTeacherDetail(Teacher cmodityDetail)
        {
            return base.UpdateModel(cmodityDetail);
        }

        /// <summary>
        /// Selects the specific teacher detail.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Teacher SelectSpecificTeacherDetail(int id)
        {
            return base.SingleOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Selects the specific teacher detail by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public Teacher SelectSpecificTeacherDetailByEmail(string email)
        {
            return base.SingleOrDefault(p => p.Email.ToLower() == email.ToLower());
        }

        /// <summary>
        /// Determines whether [is exist teacher detail] [the specified name].
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        ///   <c>true</c> if [is exist teacher detail] [the specified name]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsExistTeacherDetail(string name)
        {
            return base.Any(p => p.Name.ToLower() == name.ToLower());
        }

    }

}
