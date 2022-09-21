using AutoRent.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoRent.Core.Interfaces
{
    public interface IPaymentService : IService<PaymentRequestDto,PaymentResponseDto>
    {
        public Task<PaymentResponseDto> GetPaymentById(string id);
        public Task<List<PaymentResponseDto>> GetAllPayments();
    }
}
