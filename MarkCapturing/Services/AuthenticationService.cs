﻿using DataAccessLibrary;
using DataAccessLibrary.Repositories;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// This class should only be responsible for authenticating if the user exists or not.
/// </summary>

namespace MarkCapturing.Services
{
    public class AuthenticationService
    {
        private readonly UserRepository userRepository;
        private readonly ResetRequestRepository resetRequestRepository;

        public AuthenticationService()
        {
            userRepository = new UserRepository();
            resetRequestRepository = new ResetRequestRepository();
        }
        private User GetUser(string username)
        {
            return userRepository.GetUserByUsername(username);
        }
        private PasswordResetRequest GetPasswordResetRequestUser(string username)
        {
            return resetRequestRepository.GetUser(username);
        }
        public bool AuthenticateUser(string username,string password)
        {
            // Logic to validate user credentials against the stored data in our database
            return (GetUser(username) != null && GetUser(username).Password == password);

            //User user = GetUser(username);
            //if (user != null && user.Password == password)
            //{
            //    return true;
            //}
            //return false;
        }
        public bool IsResetPassword(string username)
        {
            if (username != null)
                return GetUser(username).IsPasswordReset;
            else
                return false;
        }
        public bool IsResetToken(string username,string enteredPassword)
        {
            enteredPassword = GetPasswordResetRequestUser(username).ResetToken;
            return true;
            //User user = userRepository.GetUserByUsername(username);
            //return enteredPassword == user.ResetToken;
        }
        public bool IsPasswordUpdated(string newPassword, string username)
        {
            userRepository.UpdatePassword(newPassword,GetUser(username));
            return true;
        }
        public List<string> GetListOfUsernames()
        {
            return userRepository.GetAllUsers().Select(u => u.UserName).ToList();
        }
        public bool IsPasswordReset(bool IsChanged, string username)
        {
            userRepository.UpdateIsResetPassword(IsChanged,GetUser(username));
            return true;
        }
        public bool IsPasswordResetRequested(bool IsChanged,string username)
        {
            userRepository.UpdateIsPasswordRequest(IsChanged,GetUser(username));
            return true;
        }
        public bool IsResetRequestDeleted(string username)
        {
            return resetRequestRepository.DeleteResetRequest(GetPasswordResetRequestUser(username).UserName);
        }
    }
}

