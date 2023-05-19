﻿using ApiResults;
using EducationHub.Business.Entities;
using EducationHub.Business.Interfaces.Repositories;
using EducationHub.Shared.Dtos;

namespace EducationHub.Business.Interfaces.Services
{
    public interface IUserService
    {
        public Task<ApiResult> Login(LoginDto loginDto);

        public Task<ApiResult> SignUp(SignUpDto signUpDto);
    }
}