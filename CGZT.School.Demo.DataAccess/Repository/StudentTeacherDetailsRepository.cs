using CGZT.School.Demo.Contracts.Common;
using CGZT.School.Demo.Contracts.Repository;
using CGZT.School.Demo.DataContext.DemoDataModels;
using CGZT.School.Demo.DataContext.DemoDbContext;
using CGZT.School.Demo.Entities.DTO.StudentTeacher;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.DataAccess.Repository
{
    public class StudentTeacherDetailsRepository : IStudentTeacherDetailsRepository
    {
        private readonly IEntityMapper _entityMapper;
        private readonly DemoEntities _demoEntities;

        public StudentTeacherDetailsRepository(IEntityMapper entityMapper, DemoEntities demoEntities)
        {
            _entityMapper = entityMapper;
            _demoEntities = demoEntities;
        }
        public List<TeacherStudentMappings> GetTeacherWiseStudentDetails()
        {
            var dbObject = _demoEntities.DemoTTeachers.Select(p => new TeacherStudentMappings {
                Id = p.Id,
                Teacher = p.Email,
                Students = p.DemoTTeacherStudentMappings.Select(q => q.DemoTStudent.Email)
            }).ToList();

            return dbObject;
        }

        public List<string> GetTeacherWiseStudentDetails(List<string> teacher)
        {

            // var returnObject = _demoEntities.DemoTTeachers.AsEnumerable().Where(p => teacher.Any(q => p.Email.Contains(q))).Select(p => p.Email).ToList();

            var query = _demoEntities.DemoTTeacherStudentMappings.Include(p => p.DemoTTeacher).Include(p => p.DemoTStudent).AsQueryable();

            foreach (var filter in teacher)
            {
                query = query.Where(x => x.DemoTTeacher.Email.Contains(filter));
            }
            var result = query.Select(p=>p.DemoTStudent.Email).ToList();
            return result;
        }
        public TeacherStudentMappings SaveStudentTeacherDetails(TeacherStudentMappings saveObject)
        {
            var obj = _demoEntities.DemoTTeachers.Where(p => p.Email.ToLower() == saveObject.Teacher.ToLower()).FirstOrDefault();

            var query = _demoEntities.DemoTTeacherStudentMappings.Include(p => p.DemoTTeacher).Include(p => p.DemoTStudent).AsQueryable();

            foreach (var filter in saveObject.Students)
            {
                query = query.Where(x => x.DemoTStudent.Email.Contains(filter));
            }
            var result = query.Select(p => p.DemoTStudent.Id).ToList();

            var mappedentity = _entityMapper.Map<TeacherStudentMappings, DemoTTeacher>(saveObject);
            mappedentity.CreatedBy = "System";
            mappedentity.CreatedAt = DateTime.Now;

            //_demoEntities.Set<DemoTTeacherStudentMapping>().Add(mappedentity);
            //Save();
            return _entityMapper.Map<DemoTTeacher, TeacherStudentMappings>(mappedentity);
        }

        public void Save()
        {
            _demoEntities.SaveChanges();
        }


    }
}
