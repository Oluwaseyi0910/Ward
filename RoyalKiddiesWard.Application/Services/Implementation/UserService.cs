﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using RoyalKiddiesWard.Application.Services.Interfaces;
using RoyalKiddiesWard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalKiddiesWard.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<UserService> _logger;
        private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager, ILogger<UserService> logger, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _logger = logger;
            _signInManager = signInManager;
        }

        public async Task<User> AuthenticateUser(string email, string password)
        {
            var checkedUser  = await GetUserIfExists(email);

            var user = await CheckPassword(checkedUser, password);

            return user;

        }

        public async Task<User> CheckPassword(User user, string password)
        {

           var result = _userManager.PasswordHasher.VerifyHashedPassword(user,
               user.PasswordHash, password);

            if (result == PasswordVerificationResult.Failed)
            {
                return null;
            }
            await _signInManager.PasswordSignInAsync(user.Email, password, false, false);

            return user;
            
        }

        public async Task<User> GetUserIfExists(string email)
        {
            User user = null;
            try
            {
               user = await _userManager.FindByEmailAsync(email);
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message} {ex.StackTrace}");

                throw;
            }
            
        }

        public async Task<User> GetUserIfAccountIsRestricted(string email)
        {
            User user = null;
            try
            {
                user = await _userManager.FindByEmailAsync(email);
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message} {ex.StackTrace}");

                throw;
            }
        }
        public async Task<User> GetNewUserIfExists(string email, string password)
        {
            var checkedUser = await GetUserIfExists(email);

            var user = await CheckPassword(checkedUser, password);

            return user;

            if (user != null)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("");
            }

        }

        public async Task<List<string>> GetRolesByUser(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return roles.ToList();
        }
        }
    }

