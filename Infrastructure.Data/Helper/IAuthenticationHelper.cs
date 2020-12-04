﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity;

namespace Infrastructure.Data.Helper
{
    public interface IAuthenticationHelper
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);

        string GenerateToken(User user);
    }
}
