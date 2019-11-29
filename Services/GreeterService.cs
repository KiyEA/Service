using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using UsingService.Context;

namespace UsingService.Services
{
    public class UsingService : TransportService.TransportServiceBase
    {
        private readonly ILogger<UsingService> _logger;
        public UsingService(ILogger<UsingService> logger)
        {
            _logger = logger;
        }

        public override Task<User> GetOneOfUser(UserRequest request, ServerCallContext context){
            var optionsBuilder = new DbContextOptionsBuilder<UserContext>();
            optionsBuilder.UseSqlite("Data sourse = tdb.mdf");
            using var con = new UserContext(optionsBuilder.Options);
            var user = con.Users.Find(request.IdUser);
            return Task.FromResult(user);
        }
        public override Task<Response> AddUser(User request, ServerCallContext context)
        {
            Response response = new Response();
            try
            {
                
                var optionsBuilder = new DbContextOptionsBuilder<UserContext>();
                optionsBuilder.UseSqlite("Data sourse = tdb.mdf");
                using var con = new UserContext(optionsBuilder.Options);
                con.Users.Add(request);
                con.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                response.ModificationResponse = Changes.AddFailed;
                return Task.FromResult(response);
            }
            response.ModificationResponse = Changes.AddOk;
            return Task.FromResult(response);
        }
        public override Task<Response> UpdateUser(User request, ServerCallContext context)
        {
            Response response = new Response();
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<UserContext>();
                optionsBuilder.UseSqlite("Data sourse = tdb.mdf");
                using var con = new UserContext(optionsBuilder.Options);
                var user = con.Users.First();
                user.Email = request.Email;
                con.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                response.ModificationResponse = Changes.AddFailed;
                return Task.FromResult(response);
            }
            response.ModificationResponse = Changes.AddOk;
            return Task.FromResult(response);
        }
        public override Task<Response> AddDriver(Driver request, ServerCallContext context)
        {
            Response response = new Response();
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<DriverContext>();
                optionsBuilder.UseSqlite("Data sourse = tbd.mdf");
                using var con = new DriverContext(optionsBuilder.Options);
                con.Drivers.Add(request);
                con.SaveChangesAsync();
            }
            catch(Exception e)
            {
                _logger.LogInformation(e.Message);
                response.ModificationResponse = Changes.AddFailed;
                return Task.FromResult(response);
            }
            response.ModificationResponse = Changes.AddOk;
            return Task.FromResult(response);
        }
        public override Task<Response> UpdateDriver(Driver request, ServerCallContext context)
        {
            Response response = new Response();
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<DriverContext>();
                optionsBuilder.UseSqlite("Data sourse = tdb.mdf");
                using var con = new DriverContext(optionsBuilder.Options);
                var driver = con.Drivers.First();
                driver.Card = request.Card;
                con.SaveChangesAsync();
            }
            catch(Exception e)
            {
                _logger.LogInformation(e.Message);
                response.ModificationResponse = Changes.AddFailed;
                return Task.FromResult(response);
            }
            response.ModificationResponse = Changes.AddOk;
            return Task.FromResult(response);
        }
        public override Task<Response> AddBus(Bus request, ServerCallContext context)
        {
            Response response = new Response();
            try
            {

                var optionsBuilder = new DbContextOptionsBuilder<BusContext>();
                optionsBuilder.UseSqlite("Data sourse = tdb.mdf");
                using var con = new BusContext(optionsBuilder.Options);
                con.Buses.Add(request);
                con.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                response.ModificationResponse = Changes.AddFailed;
                return Task.FromResult(response);
            }
            response.ModificationResponse = Changes.AddOk;
            return Task.FromResult(response);
        }
        public override Task<Response> AddHistory(History request, ServerCallContext context)
        {
            Response response = new Response();
            try
            {

                var optionsBuilder = new DbContextOptionsBuilder<HistoryContext>();
                optionsBuilder.UseSqlite("Data sourse = tdb.mdf");
                using var con = new HistoryContext(optionsBuilder.Options);
                con.Histories.Add(request);
                con.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                response.ModificationResponse = Changes.AddFailed;
                return Task.FromResult(response);
            }
            response.ModificationResponse = Changes.AddOk;
            return Task.FromResult(response);
        }
        public override Task<Response> AddRoute(Route request, ServerCallContext context)
        {
            Response response = new Response();
            try
            {

                var optionsBuilder = new DbContextOptionsBuilder<RouteContext>();
                optionsBuilder.UseSqlite("Data sourse = tdb.mdf");
                using var con = new RouteContext(optionsBuilder.Options);
                con.Routes.Add(request);
                con.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                response.ModificationResponse = Changes.AddFailed;
                return Task.FromResult(response);
            }
            response.ModificationResponse = Changes.AddOk;
            return Task.FromResult(response);
        }
        public override Task GetHistoryList(HistoryRequest request, IServerStreamWriter<History> responseStream, ServerCallContext context)
        {
            
        }
    }
}
