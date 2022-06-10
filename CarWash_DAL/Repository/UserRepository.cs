using System;
using System.Linq;
using System.Threading.Tasks;
using CarWash_DAL.Interface;
using CarWash_DAL.Models;
using Microsoft.EntityFrameworkCore;
using CarWash_DAL.Data;
using System.Collections.Generic;

namespace CarWash_DAL.Repository
{
    public class UserRepository : IUserRepository<CwuserProfile>
    {
        private readonly CarWashDBContext carWashDatabaseContext;
        public UserRepository(CarWashDBContext _carWashDatabaseContext)
        {
            carWashDatabaseContext = _carWashDatabaseContext;
        }
        //This Method Inserts the User Profile into database
        #region Create User
        public async Task<CwuserProfile> CreateUser(UserProfile user)
        {
            try
            {
                var newuser = new CwuserProfile()
            {
                UserFirstName = user.UserFirstName,
                UserLastName = user.UserLastName,
                UserEmail = user.UserEmail,
                UserGender = user.UserGender,
                UserRole = user.UserRole,
                UserMobileNumber = user.UserMobileNumber,
                UserPassword = user.UserPassword
            };
           
                if (carWashDatabaseContext != null)
                {
                    await carWashDatabaseContext.CwuserProfiles.AddAsync(newuser);
                    await carWashDatabaseContext.SaveChangesAsync();
                    return newuser;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        } 
        #endregion
        public async Task<UserProfile> GetUserbyEmail(string email)
        {
            if (carWashDatabaseContext != null)
            {
                return await (from u in carWashDatabaseContext.CwuserProfiles
                              where u.UserEmail == email
                              select new UserProfile
                              {
                                  UserFirstName = u.UserFirstName,
                                  UserLastName = u.UserLastName,
                                  UserEmail = u.UserEmail,
                                  UserRole = u.UserRole,
                                  UserGender = u.UserGender,
                                  UserMobileNumber = u.UserMobileNumber,
                                  UserPassword = u.UserPassword
                              }).FirstOrDefaultAsync();
            }
            return null;
        }
        public async Task<string> AddAddress(Address address)
        {
            var addressdata = await carWashDatabaseContext.CwuserProfiles.Where(x => x.UserEmail == address.email).FirstOrDefaultAsync();
            try
            {
                var userAddress = new Cwaddress()
                {
                    UserId = addressdata.UserId,
                    AddressLine1 = address.AddressLine1,
                    AddressLine2 = address.AddressLine2,
                    AddressLandmark = address.AddressLandmark,
                    AddressCity = address.AddressCity,
                    AddressState = address.AddressState,
                    AddressPincode = address.AddressPincode
                };
                if (carWashDatabaseContext != null)
                {
                    await carWashDatabaseContext.Cwaddresses.AddAsync(userAddress);
                    await carWashDatabaseContext.SaveChangesAsync();
                    return addressdata.UserEmail;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }
        public async Task<Address> GetAddressbyEmail(string email)
        {
            if (carWashDatabaseContext != null)
            {
                var user = await carWashDatabaseContext.CwuserProfiles.Where(x => x.UserEmail == email).FirstOrDefaultAsync();

                return await (from u in carWashDatabaseContext.Cwaddresses
                              where u.UserId == user.UserId
                              select new Address
                              {
                                  AddressLine1 = u.AddressLine1,
                                  AddressLine2 = u.AddressLine2,
                                  AddressCity = u.AddressCity,
                                  AddressLandmark = u.AddressLandmark,
                                  AddressState = u.AddressState,
                                  AddressPincode = u.AddressPincode

                              }).FirstOrDefaultAsync();
            }
            return null;
        }

      

        public async Task<List<UserProfile>> GetAllCustomers()
        {
            if (carWashDatabaseContext != null)
            {
                return await(from u in carWashDatabaseContext.CwuserProfiles where u.UserRole=="Customer"
                             select new UserProfile
                             {
                                 UserFirstName = u.UserFirstName,
                                 UserLastName = u.UserLastName,
                                 UserEmail = u.UserEmail,
                                 UserGender = u.UserGender,
                                 UserMobileNumber = u.UserMobileNumber,
                                 UserRole = u.UserRole
                             }).ToListAsync();
            }
            return null;
        }

        public async Task<List<UserProfile>> GetAllWashers()
        {
            if (carWashDatabaseContext != null)
            {
                return await(from u in carWashDatabaseContext.CwuserProfiles
                             where u.UserRole == "Washer"
                             select new UserProfile
                             {
                                 UserFirstName = u.UserFirstName,
                                 UserLastName = u.UserLastName,
                                 UserEmail = u.UserEmail,
                                 UserGender = u.UserGender,
                                 UserMobileNumber = u.UserMobileNumber,
                                 UserRole = u.UserRole
                             }).ToListAsync();
            }
            return null;
        }
    }
}
