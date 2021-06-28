using CGZT.School.Demo.Business.Managers;
using CGZT.School.Demo.Business.Mappers;
using CGZT.School.Demo.Business.Mappers.Notification;
using CGZT.School.Demo.Business.Mappers.Student;
using CGZT.School.Demo.Business.Validators;
using CGZT.School.Demo.Business.Wrapper;
using CGZT.School.Demo.Contracts.Common;
using CGZT.School.Demo.Contracts.Manager;
using CGZT.School.Demo.Contracts.MessageHandlers;
using CGZT.School.Demo.Contracts.Repository;
using CGZT.School.Demo.DataAccess.Mappers;
using CGZT.School.Demo.DataAccess.Repository;
using CGZT.School.Demo.DataContext.DemoDbContext;
using CGZT.School.Demo.Entities;
using CGZT.School.Demo.Entities.Common;
using CGZT.School.Demo.Entities.DTO.Notification;
using CGZT.School.Demo.Entities.DTO.StudentTeacher;
using CGZT.School.Demo.Resources.Student;
using CGZT.School.Demo.Resources.Teacher;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGZT.School.Demo.WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration Configuration)
        {

            services.AddControllers();

            #region Managers
            services.AddScoped<ITeacherDetailsManager, TeacherDetailsManager>();
            services.AddScoped<IStudentDetailsManager, StudentDetailsManager>();
            services.AddScoped<IStudentTeacherDetailsManager, StudentTeacherDetailsManager>();
            services.AddScoped<INotificationDetailsManager, NotificationDetailsManager>();
            #endregion

            //#region Repos
            services.AddScoped<ITeacherDetailsRepository, TeacherDetailsRepository>();
            services.AddScoped<IStudentDetailsRepository, StudentDetailsRepository>();
            services.AddScoped<IStudentTeacherDetailsRepository, StudentTeacherDetailsRepository>();
            services.AddScoped<INotificationDetailsRepository, NotificationDetailsRepository>();
            //#endregion

            #region Mappers
            services.AddSingleton<IEntityMapper, EntityMapper>();
            services.AddSingleton<IMapper<IList<Message>, ServiceResponse>, ServiceErrorMapper>();
            services.AddSingleton<IMapper<Object, ServiceResponse>, ServiceResponseMapper>();
            services.AddSingleton<IMapper<StudentDataMapperWrapper, Students>, StudentDataMapper>();
            services.AddSingleton<IMapper<NotificationDataMapperWrapper, NotificationRecipients>, NotificationDataMapper>();
            #endregion

            #region utils
            #endregion

            #region Validators
            services.AddScoped<IValidator<Teacher>, TeacherDetailsValidator>();
            services.AddScoped<IValidator<Students>, StudentDetailsValidator>();
            #endregion

            #region ErrorHandlers
            services.AddSingleton<ITeacherDetailsErrorMessageHandler,
                         TeacherDetailsErrorMessageHandler>();
            services.AddSingleton<IStudentDetailsErrorMessageHandler,
                         StudentDetailsErrorMessageHandler>();
            #endregion

            #region DBContext
            services.AddDbContext<DemoEntities>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DemoEntities")
            ));
            #endregion

            //#region ResponseCompression

            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);

            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.MimeTypes = new[]
                        {
                    // Default
                    "text/plain",
                    "text/css",
                    "application/javascript",
                    "text/html",
                    "application/xml",
                    "text/xml",
                    "application/json",
                    "text/json",
                    // Custom
                    "image/svg+xml",
                     "application/atom+xml"
                };
            });

            //#endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CGZT.School.Demo", Version = "v1" });
            });
            #endregion

            #region ApplicationInsight
            services.AddApplicationInsightsTelemetry();
            #endregion

            return services;
        }
    }

}
