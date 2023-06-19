using api_projeto_final.DataModels;
using Microsoft.EntityFrameworkCore;
using DevOne.Security.Cryptography.BCrypt;
using Microsoft.AspNetCore.Mvc;

using System.Security.Cryptography;
using System;
using System.Text;

namespace api_projeto_final.Service
{
    public class authService
    {

        private DbConnect connect;
        private DbSet<auth> auth;
        private DbSet<token> token;

        public authService()
        {
            this.connect = new DbConnect();
            this.auth = connect.auth;
            this.token = connect.tokens;
        }

        public async Task<OkResult> setUserAuth(user user)
        {
            auth oldAuth = await this.auth.FirstOrDefaultAsync(auth => auth.user == user);
            if (oldAuth != null)
            {
                this.auth.Remove(oldAuth);
            }

            auth auth = new auth();
            auth.user = user;
            auth.password_salt = this.generateSalt();
            auth.password_hashed = this.encodePassword(user.password, auth.password_salt);

            try
            {

                var response = await this.auth.AddAsync(auth);
                //await this.connect.SaveChangesAsync(); nao posso comiitar as mudancas por causa q eu commito na action

                return response != null ? new OkResult() : throw new Exception("Cannot create auth");

            }catch(Exception ex)
            {
                throw new Exception("Erro to register the auth: "+ex.Message);
            }

        }

        public token? validateSessionToken(string guiven_token)
        {
            try
            {
                // eu sei que isso nao ta da melhor maneira possivel
                token foundToken = this.connect.tokens.AsNoTracking().FirstOrDefault(token => token.token_value == guiven_token);

                if (foundToken == null || foundToken.expires_at <= DateTime.UtcNow)
                    return null;

                return foundToken;
            }
            catch(Exception ex)
            {
                throw new Exception("Error to validate token: "+ex.Message);
            }
        }

        public token? login(user user)
        {
            auth auth = this.connect.auth.AsNoTracking().FirstOrDefault(auth => auth.user == user);

            string given_passwd = this.encodePassword(user.password, auth.password_salt);
            string stored_passwd = auth.password_hashed;

            if(given_passwd != stored_passwd)
            {
                throw new Exception("Wrong Password!");
            }

            token? oldToken = this.connect.tokens.AsNoTracking().FirstOrDefault(token => token.userId == user.id);
            if(oldToken != null)
                this.connect.tokens.Remove(oldToken);

            token newToken = this.generateSessionToken(user);

            try
            {
                this.connect.tokens.Add(newToken);
                this.connect.SaveChanges();

                return newToken;

            }catch(Exception ex)
            {
                throw new Exception("Error to Login: "+ex.Message);
            }

        }

        private token generateSessionToken(user user)
        {
            token token = new token();

            DateTime created = DateTime.Now;

            token.userId = user.id;
            token.token_value = generateToken();
            token.created_at = created.ToUniversalTime();
            token.expires_at = created.AddHours(4).ToUniversalTime();

            return token;
        }

        private string generateToken(int length = 32)
        {
            byte[] randomBytes = new byte[length];
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetBytes(randomBytes);
            }
            return Convert.ToBase64String(randomBytes);
        }


        private string encodePassword(string password, string salt)
        {
            return BCryptHelper.HashPassword(password, salt);
        }

        private string generateSalt()
        {
            return BCryptHelper.GenerateSalt();
        }
    }
}
