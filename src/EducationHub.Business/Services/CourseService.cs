using ApiResults;
using EducationHub.Business.Entities;
using EducationHub.Business.Interfaces.Repositories;
using EducationHub.Business.Interfaces.Services;
using EducationHub.Business.Messages;
using EducationHub.Business.Validators.Course;
using EducationHub.Business.Validators.User;
using EducationHub.Shared.Dtos.Course;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationHub.Business.Services
{
    internal class CourseService : ICourseService
    {
        private readonly IBaseRepository<Course> _repository;

        public CourseService(IBaseRepository<Course> repository)
        {
            _repository = repository;
        }

        public async Task<ApiResult> GetAllByFilter(CourseGetByFilterDto courseGetByFilterDto)
        {
            var result = await _repository.Get
            return null;
        }

        public async Task<ApiResult> Delete(CourseDeleteDto courseDeleteDto)
        {
            var validation = new CourseDeleteDtoValidator().Validate(courseDeleteDto);

            if (!validation.IsValid)
                return Result.Error(
                    EducationHubErrors.Application_Error_InvalidRequest,
                    validation.Errors);

            var existentCourse = await _repository.FindOneAsync(Course.SameIdFilterDefinition(courseDeleteDto.Id));

            if (existentCourse is null)
                return Result.Error(EducationHubErrors.CourseDelete_Error_NotFound);

            if (courseDeleteDto.UserId.Equals(existentCourse.ProfessorId))
                return Result.Error(EducationHubErrors.CourseDelete_Error_Forbidden);

            await _repository.DeleteOneAsync(courseDeleteDto.Id);

            return Result.Success(EducationHubMessages.CourseDelete_Success);
        }

        public async Task<ApiResult> Insert(CoursePostDto courseDto)
        {
            var validation = new CoursePostDtoValidator().Validate(courseDto);

            if (!validation.IsValid)
                return Result.Error(
                    EducationHubErrors.Application_Error_InvalidRequest,
                    validation.Errors);

            var exists = await _repository.Exists(Course.SameTitleFilterDefinition(courseDto.Title));

            if (exists)
                return Result.Error(EducationHubErrors.CourseInsert_Error_AlreadyExists);

            var course = new Course(courseDto);
            await _repository.InsertOneAsync(course);

            return Result.Success(EducationHubMessages.CourseInsert_Success, course);
        }

        public async Task<ApiResult> Update(CoursePutDto courseDto)
        {
            var validation = new CoursePutDtoValidator().Validate(courseDto);

            if (!validation.IsValid)
                return Result.Error(
                    EducationHubErrors.Application_Error_InvalidRequest,
                    validation.Errors);

            var existentCourse = await _repository.FindOneAsync(Course.SameIdFilterDefinition(courseDto.Id));

            if (existentCourse is null)
                return Result.Error(EducationHubErrors.CourseUpdate_Error_NotFound);

            if (courseDto.UserId.Equals(existentCourse.ProfessorId))
                return Result.Error(EducationHubErrors.CourseUpdate_Error_Forbidden);

            var existsWithSameTitle = await _repository.Exists(Course.SameTitleFilterDefinition(courseDto.Title));

            if (existsWithSameTitle)
                return Result.Error(EducationHubErrors.CourseInsert_Error_AlreadyExists);

            existentCourse.Update(courseDto);
            await _repository.UpdateAsync(existentCourse, existentCourse.UpdateDefinition());

            return Result.Success(EducationHubMessages.CourseUpdate_Success, existentCourse);
        }
    }
}
