using AutoRent.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoRent.Data.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Booking> BookingRepository { get; }
        public IGenericRepository<Car> CarRepository { get; }
        public IGenericRepository<Feature> FeatureRepository { get; }
        public IGenericRepository<Location> LocationRepository { get; }
        public IGenericRepository<Payment> PaymentRepository { get; }
        public IGenericRepository<Post> PostRepository { get; }
        public IGenericRepository<Rating> RatingRepository { get; }
        public IGenericRepository<User> UserRepository { get; }

        Task Save();
    }
}
