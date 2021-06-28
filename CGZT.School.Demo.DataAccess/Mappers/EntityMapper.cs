using AutoMapper;
using CGZT.School.Demo.Contracts.Common;
using CGZT.School.Demo.DataContext.DemoDataModels;
using CGZT.School.Demo.Entities.DTO.Notification;
using CGZT.School.Demo.Entities.DTO.StudentTeacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.DataAccess.Mappers
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="CGZT.School.Demo.Contracts.Common.IEntityMapper" />
    public class EntityMapper : IEntityMapper
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private MapperConfiguration _config;

        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityMapper"/> class.
        /// </summary>
        public EntityMapper()
        {
            Configure();
            Create();
        }

        /// <summary>
        /// Configures this instance.
        /// </summary>
        private void Configure()
        {
            _config = new MapperConfiguration(cfg =>
            {


                //cfg.CreateMap<DemoTTeacher, TeacherStudentMapping>()
                //    .ForMember(p => p.Students, q => q.MapFrom(r => r.DemoTTeacherStudentMappings));


                cfg.CreateMap<DemoTTeacher, TeacherStudentMapping>()
                    .ForMember(p => p.Students, q => q.MapFrom(x => x.DemoTTeacherStudentMappings.Select(y => y.DemoTStudent).ToList()));


                cfg.CreateMap<TeacherStudentMapping, DemoTTeacher>()
                 .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Teacher))
                  .ForMember(dest => dest.DemoTTeacherStudentMappings, opt => opt.MapFrom(src => src.Students))
                  .AfterMap((src, dest) => {
                      foreach (var b in dest.DemoTTeacherStudentMappings)
                      {
                          b.DemoTStudentId = src.Id;
                      }
                  });

               cfg.CreateMap<DemoTStudent, TeacherStudentMapping>()
                          .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Id))
                         .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src));


                cfg.CreateMap<DemoTTeacherStudentMapping, TeacherStudentMapping>()
                .ForMember(t => t.Students, m => m.MapFrom(u => u.DemoTStudent))
                      .ForMember(t => t.Id, m => m.MapFrom(u => u.DemoTStudentId))
                      .ForMember(t => t.Teacher, m => m.MapFrom(u => u.DemoTTeacher))
                      .ForMember(t => t.Id, m => m.MapFrom(u => u.DemoTTeacherId))
                .ReverseMap();

                cfg.CreateMap<DemoTTeacher, Teacher>().ReverseMap();

                cfg.CreateMap<DemoTStudent, Students>().ReverseMap();

                cfg.CreateMap<DemoTNotificationRecipient, NotificationRecipients>()
              .ForMember(t => t.Notification, m => m.MapFrom(u => u.DemoTNotification))
                    .ForMember(t => t.Id, m => m.MapFrom(u => u.DemoTNotificationId))
              .ReverseMap();

                cfg.CreateMap<DemoTNotification, Notifications>().ReverseMap();

            });
        }

        /// <summary>
        /// Creates the mapper.
        /// </summary>
        private void Create()
        {
            _mapper = _config.CreateMapper();
        }

        #region Genaric Mapper
        /// <summary>
        /// Maps the specified source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }
        #endregion
    }

}
