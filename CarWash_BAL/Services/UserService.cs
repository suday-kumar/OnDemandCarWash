using System;
using System.Threading.Tasks;
using CarWash_DAL.Interface;
using CarWash_DAL.Models;
using CarWash_DAL.Data;
using System.Collections.Generic;

namespace CarWash_BAL
{
    public class UserService
    {
        public readonly IUserRepository<CwuserProfile> userRepository;
        public UserService(IUserRepository<CwuserProfile> _userRepository)
        {
            userRepository = _userRepository;
        }
        public async Task<CwuserProfile> CreateUser(UserProfile user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }
                else
                {
                    return await userRepository.CreateUser(user);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<UserProfile> GetUserbyEmail(string email)
        {
            try
            {
                var user = await userRepository.GetUserbyEmail(email);
                if (user == null)
                {
                    return null;
                }
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<string> AddAddress(Address address)
        {
            try
            {
                if (address == null)
                {
                    throw new ArgumentNullException(nameof(address));
                }
                else
                {
                    await userRepository.AddAddress(address);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return address.email;
        }
        public async Task<Address> GetAddressByEmail(string email)
        {
            try
            {
                var user = await userRepository.GetAddressbyEmail(email);
                if (user == null)
                {
                    return null;
                }
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<List<UserProfile>> GetAllCustomers()
        {
            var customers = await userRepository.GetAllCustomers();

            return customers;
        }
        public async Task<List<UserProfile>> GetAllWashers()
        {
            var washers = await userRepository.GetAllWashers();

            return washers;
        }
    }

}
