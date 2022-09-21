using AutoRent.Data.Interfaces;
using AutoRent.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoRent.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AutoRentDbContext _dbContext;
        private IGenericRepository<Booking> _bookingRepository;
        private IGenericRepository<Car> _carRepository;
        private IGenericRepository<Feature> _featureRepository;
        private IGenericRepository<Location> _locationRepository;
        private IGenericRepository<Payment> _paymentRepository;
        private IGenericRepository<Post> _postRepository;
        private IGenericRepository<Rating> _ratingRepository;
        private IGenericRepository<User> _userRepository;

        public UnitOfWork(AutoRentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IGenericRepository<Booking> BookingRepository
        {
            get
            {
                if(_bookingRepository == null)
                {
                    _bookingRepository = new GenericRepository<Booking>(_dbContext);
                }
                return _bookingRepository;
            }
        }

        public IGenericRepository<Car> CarRepository
        {
            get
            {
                if(_carRepository == null)
                {
                    _carRepository = new GenericRepository<Car>(_dbContext);
                }
                return _carRepository;
            }
        } 

        public IGenericRepository<Feature> FeatureRepository
        {
            get
            {
                if(_featureRepository == null)
                {
                    _featureRepository = new GenericRepository<Feature>(_dbContext);
                }
                return _featureRepository;
            }
        } 

        public IGenericRepository<Location> LocationRepository
        {
            get
            {
                if(_locationRepository == null)
                {
                    _locationRepository = new GenericRepository<Location>(_dbContext);
                }
                return _locationRepository;
            }
        } 

        public IGenericRepository<Payment> PaymentRepository
        {
            get
            {
                if(_paymentRepository == null)
                {
                    _paymentRepository = new GenericRepository<Payment>(_dbContext);
                }
                return _paymentRepository;
            }
        }

        public IGenericRepository<Post> PostRepository
        {
            get
            {
                if(_postRepository == null)
                {
                    _postRepository = new GenericRepository<Post>(_dbContext);
                }
                return _postRepository;
            }
        } 

        public IGenericRepository<Rating> RatingRepository
        {
            get
            {
                if(_ratingRepository == null)
                {
                    _ratingRepository = new GenericRepository<Rating>(_dbContext);
                }
                return _ratingRepository;
            }
        } 

        public IGenericRepository<User> UserRepository
        {
            get
            {
                if(_userRepository == null)
                {
                    _userRepository = new GenericRepository<User>(_dbContext);
                }
                return _userRepository;
            }
        } 

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
