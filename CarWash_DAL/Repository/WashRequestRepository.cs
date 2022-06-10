using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWash_DAL.Data;
using CarWash_DAL.Interface;
using CarWash_DAL.Models;
using Microsoft.EntityFrameworkCore;
namespace CarWash_DAL.Repository
{
    public class WashRequestRepository : IWashRequest<WashRequest>
    {
        private readonly CarWashDBContext carWashDatabaseContext;
        public WashRequestRepository(CarWashDBContext _carWashDatabaseContext)
        {
            carWashDatabaseContext = _carWashDatabaseContext;
        }
        public async Task<List<WashRequest>> getWashRequestDetails()
        {
            var requests =
              await (from c in carWashDatabaseContext.CwcarRecords
                     join w in carWashDatabaseContext.CwwashNows on c.CarRegistrationNumber equals w.WashNowSelectedCar
                     join u in carWashDatabaseContext.CwuserProfiles on c.UserId equals u.UserId
                     join a in carWashDatabaseContext.Cwaddresses on c.UserId equals a.UserId
                    select new WashRequest
                     {
                         UserFirstName = u.UserFirstName,
                         UserLastName = u.UserLastName,
                         UserEmail = u.UserEmail,
                         UserMobileNumber = u.UserMobileNumber,
                         AddressLine1 = a.AddressLine1,
                         AddressLine2 = a.AddressLine2,
                         AddressLandmark = a.AddressLandmark,
                         AddressCity = a.AddressCity,
                         AddressState = a.AddressState,
                         AddressPincode = a.AddressPincode,
                         CarCompany = c.CarCompany,
                         CarModel = c.CarModel,
                         CarColor = c.CarColor,
                         CarRegistrationNumber = c.CarRegistrationNumber,
                         packageName = w.PackageName,
                         WashNowWashNotes = w.WashNowWashNotes,
                         WashNowRequestTime = w.WashNowRequestTime,
                         WashRequestStatus = w.RequestStatus
                     }).ToListAsync();
            return requests;
        }
        public async Task<List<WashRequest>> getWashRequestByEmail(string email)
        {
            var requests =
              await (from c in carWashDatabaseContext.CwcarRecords
                     join w in carWashDatabaseContext.CwwashNows on c.CarRegistrationNumber equals w.WashNowSelectedCar
                     join u in carWashDatabaseContext.CwuserProfiles on c.UserId equals u.UserId 
                     where u.UserEmail == email
                     select new WashRequest
                     {
                         UserFirstName=u.UserFirstName,
                         CarCompany = c.CarCompany,
                         CarModel = c.CarModel,
                         CarColor = c.CarColor,
                         CarRegistrationNumber = c.CarRegistrationNumber,
                         packageName = w.PackageName,
                         WashNowWashNotes = w.WashNowWashNotes,
                         WashNowRequestTime = w.WashNowRequestTime,
                         WashRequestStatus=w.RequestStatus
                     }).ToListAsync();
            return requests;
        }
        public  string AcceptRequest(string carNum)
            {

            CwwashNow cwwash = carWashDatabaseContext.CwwashNows.SingleOrDefault(x => x.WashNowSelectedCar == carNum);
            try
                {
                    if (cwwash != null)
                    {
                    cwwash.RequestStatus = "Accepted";
                    carWashDatabaseContext.SaveChanges();
                        return cwwash.RequestStatus;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            return "Invalid Wash Request";
        }
        public string RejectRequest(string carNum)
        {
            CwwashNow cwwash = carWashDatabaseContext.CwwashNows.SingleOrDefault(x => x.WashNowSelectedCar == carNum);
            try
            {
                if (cwwash != null)
                {
                    cwwash.RequestStatus = "Rejected";
                    carWashDatabaseContext.SaveChanges();
                    return cwwash.RequestStatus;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return "Invalid Wash Request";
        }
    }
}
