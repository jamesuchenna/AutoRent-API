using AutoMapper;
using AutoRent.Core.Interfaces;
using AutoRent.Data.Interfaces;
using AutoRent.Dtos;
using AutoRent.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoRent.Core.Services
{
    internal class PaymentService : IPaymentService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(ILogger logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(PaymentRequestDto paymentRequestDto)
        {
            var payment = _mapper.Map<Payment>(paymentRequestDto);

            if (payment == null)
            {
                _logger.LogInformation("Payment DTO did not map to Payment: Invalid input provided");
                throw new Exception("One or more of your inputs are incorrect");
            }

            payment.Id = Guid.NewGuid().ToString();
            payment.CreatedAt = DateTime.Now;
            payment.UpdatedAt = DateTime.Now;

            try
            {
                await _unitOfWork.PaymentRepository.AddAsync(payment);
                await _unitOfWork.Save();

                _logger.LogInformation($"Payment {payment.Id} successfully added to database");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not add payment to database: {ex.Message}");
                throw new Exception("Sorry, we can;t process your payment at this time");
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                await _unitOfWork.PaymentRepository.DeleteAsync(id);
                await _unitOfWork.Save();
                _logger.LogInformation($"Successfully deleted payment {id} from database");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not delete payment {id} from database: {ex.Message}");
                throw new Exception($"Could not delete payment {id} from database");
            }
        }

        public async Task<List<PaymentResponseDto>> GetAllPayments()
        {
            var payments = await _unitOfWork.PaymentRepository.GetAllAsync();
            return _mapper.Map<List<PaymentResponseDto>>(payments);
        }

        public async Task<PaymentResponseDto> GetPaymentById(string id)
        {
            var payment = await _unitOfWork.PaymentRepository.GetAsync(p => p.Id == id);
            return _mapper.Map<PaymentResponseDto>(payment);
        }

        public async Task Update(string id, PaymentRequestDto paymentRequestDto)
        {
            var payment = await _unitOfWork.PaymentRepository.GetAsync(p => p.Id == id);
            payment.Status = paymentRequestDto.Status;
            payment.UpdatedAt = DateTime.Now;

            try
            {
                _unitOfWork.PaymentRepository.Update(payment);
                await _unitOfWork.Save();
                _logger.LogInformation($"Updated payment {id} information successfully");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not update payment {id} information: {ex.Message}");
                throw new Exception("Could not update payment information");
            }
        }
    }
}
