using AutoMapper;
using Core.Entities;
using Core.Exceptions.Business;
using Core.Exceptions.NotFound;
using Microsoft.AspNetCore.Identity;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Users.Dtos.Requests;
using SweetDictionary.Models.Users.Dtos.Response;
using SweetDictionary.Service.Constants;
using SweetDictionary.Service.Users.Services.Abstracts;
using static StackExchange.Redis.Role;

namespace SweetDictionary.Service.Users.Services.Concretes;

public class EfUserService(UserManager<User> userManager, IMapper mapper) : IUserService
{
    public async Task<User> RegisterUserAsync(RegisterRequestDto registerRequestDto)
    {
        User user = new User()
        {
            Email = registerRequestDto.Email,
            UserName = registerRequestDto.Username,
            BirthDate = registerRequestDto.BirthDate,
        };

        var result = await userManager.CreateAsync(user, registerRequestDto.Password);

        var role = await userManager.AddToRoleAsync(user, "User");        
        if (!role.Succeeded)
        {
            throw new BusinessException(role.Errors.First().Description);
        }

        return user;
    }

    public async Task<User> LoginAsync(LoginRequestDto dto)
    {
        var user = await userManager.FindByEmailAsync(dto.Email);

        CheckUserExists(user);

        var result = await userManager.CheckPasswordAsync(user, dto.Password);

        if (result is false)
        {
            throw new NotFoundException("Login failed, please check login information");
        }

        return user;
    }

    public async Task<ReturnModel<NoData>> UpdateAsync(string id, UpdateUserRequestDto dto)
    {
        User user = await userManager.FindByIdAsync(id);
        CheckUserExists(user);
        
        if (dto.Username is not null)
        {
            user.UserName = dto.Username;
        }
        
        if (dto.BirthDate is not null)
        {
            user.BirthDate = dto.BirthDate;
        }
        
        var result = await userManager.UpdateAsync(user);

        if (result.Succeeded is false)
        {
            throw new BusinessException(result.Errors.First().Description);
        }

        return ReturnModel<NoData>.ReturnModelOfSuccess(null,204,Messages.UserUpdatedMessage);
    }

    public async Task<ReturnModel<NoData>> DeleteAsync(string id)
    {
        User user = await userManager.FindByIdAsync(id);
        CheckUserExists(user);

        await userManager.DeleteAsync(user);

        return ReturnModel<NoData>.ReturnModelOfSuccess(null,204,Messages.UserDeletedMessage);
    }

    public async Task<ReturnModel<UserResponseDto>> GetByEmailAsync(string email)
    {
        var user = await userManager.FindByEmailAsync(email);

        CheckUserExists(user);

        var response = mapper.Map<UserResponseDto>(user);
        return ReturnModel<UserResponseDto>.ReturnModelOfSuccess(response, 200);
    }

    public async Task<ReturnModel<NoData>> ChangePasswordAsync(string userId, ChangePasswordRequestDto dto)
    {
        User user = await userManager.FindByIdAsync(userId);
        CheckUserExists(user);

        var result = await userManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword);
        if (result.Succeeded is false)
        {
            throw new NotFoundException(result.Errors.First().Description);
        }
        return ReturnModel<NoData>.ReturnModelOfSuccess(null,204,"Password has been updated successfully");
    }

    private void CheckUserExists(User? user)
    {
        if (user is null)
        {
            throw new NotFoundException("The user does not exist");
        }
    }

}