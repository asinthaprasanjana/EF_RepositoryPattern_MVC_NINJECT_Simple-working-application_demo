using DataEntity;
using DataEntity.Repository;
using DataEntityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.MajorBusinessLogic
{
    public class UserManagement:IUserRepository,IAuthntication
    {
        private readonly UserRepository repository;
        private readonly DataContext context = new DataContext();

   
        public UserManagement() {

            repository = new UserRepository();

        }

        public IEnumerable<User> User
        {
            get
            {
                return context.Users;
            }
        }

        public User AddNewUser(User user)
        {
            //MapperConfig.ConfigAutoMapper();

            if (this.IsUserValid(user))
            {
                if (repository.GetUser(user.Username) == null)
                {
                    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

                    byte[] buffer = new byte[50];

                    byte[] salt = new byte[25];
                    rng.GetBytes(salt);

                    string saltString = Encoding.Default.GetString(salt);

                    string hashedPassString = this.GenerateSaltedHash(user.Password, saltString);

                    user.Password = hashedPassString;
                    user.PasswordSalt = saltString;
                    user.IsLoked = false;
                    user.LastLogin = null;
                    user.NumOfInvalidLogins = 0;
                    

                    var savedUser = repository.Insert(user);

                    return savedUser;
                }
                else
                {
                    throw new InvalidOperationException("Username is not available.");
                }
            }
            else
            {
                throw new ArgumentNullException("Provided information is not valid.");
            }
        }

        private string GenerateSaltedHash(string passwordString, string saltString)
        {
            RNGCryptoServiceProvider rngProvider = new RNGCryptoServiceProvider();

            SHA256 sha256 = SHA256Managed.Create();

            byte[] passwordBytes = new byte[(passwordString.Length + saltString.Length) * sizeof(char)];
            Buffer.BlockCopy((passwordString + saltString).ToCharArray(), 0, passwordBytes, 0, passwordBytes.Length);

            byte[] passwordHash = sha256.ComputeHash(passwordBytes);

            string encryptedPassord = Encoding.Default.GetString(passwordHash);

            return encryptedPassord;
        }

        private bool IsUserValid(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User Does not exists");
            }

            if (string.IsNullOrEmpty(user.Username))
            {
                throw new ArgumentNullException("Insert username Field!");
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                throw new ArgumentNullException("Insert password Field!");
            }

            return true;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool AuthenticacteForm(string username,string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var user = repository.GetUser(username);

                if (user != null)
                {
                    if (!user.IsLoked)
                    {
                        var hashedPass = this.GenerateSaltedHash(password, user.PasswordSalt);

                        if (hashedPass.Equals(user.Password))
                        {
                            user.NumOfInvalidLogins = 0;
                            user.IsLoked = false;
                            user.LastLogin = DateTime.Now;

                            repository.Update(user);

                            user.Password = string.Empty;
                            user.PasswordSalt = string.Empty;

                            System.Diagnostics.Debug.WriteLine("Login success!");
                            return true;

                        }
                        else
                        {
                            if (user.NumOfInvalidLogins < 2)
                            {
                                user.NumOfInvalidLogins++;
                                repository.Update(user);

                                return false;
                            }
                            else
                            {
                                user.NumOfInvalidLogins++;
                                user.IsLoked = true;
                                repository.Update(user);

                                //throw new InvalidOperationException("Login not succesful. Account Locked!.");
                                return false;
                            }
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("User has been locked.");
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                //throw new ArgumentNullException("Username or password cannot be null or empty.");
                return false;
            }
        }
    }
}
