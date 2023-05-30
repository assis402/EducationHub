using ApiResults;
using EducationHub.Business.Entities;
using EducationHub.Shared.Dtos.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationHub.Business.Interfaces.Services
{
    public interface ICourseService
    {
        public Task<ApiResult> Insert(CoursePostDto courseDto);

        public Task<ApiResult> Update(CoursePostDto courseDto);

        public Task<ApiResult> Delete(string courseId);

        public Task<ApiResult> GetAllByFilter(CourseGetByFilterDto courseGetByFilterDto);
    }
}
