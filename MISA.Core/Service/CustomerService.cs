using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Service
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository _customerRepository;
        public int Delete(Guid customerId)
        {
            var rowsAffect = _customerRepository.Delete(customerId);
            return rowsAffect;
        }

        public IEnumerable<Customer> GetAll()
        {
            var customers = _customerRepository.GetAll();
            return customers;
        }

        public Customer GetById(Guid customerId)
        {
            var customers = _customerRepository.GetById(customerId);
            return customers;
        }

        public int Insert(Customer customer)
        {

            // Validate dữ liệu 
            // Check các thông tin bắt buộc nhập
            if (string.IsNullOrEmpty(customer.CustomerCode))
            {
                var response = new
                {
                    devMsg = "Mã khách hàng không được để trống",
                    MISACode = "001"
                };
                throw new Exception("Mã khách hàng không được phép để trống!!!");
            }
            var rowsAffect = _customerRepository.Insert(customer);
            return rowsAffect;
        }

        public int Update(Customer customer)
        {
            var rowsAffect = _customerRepository.Update(customer);
            return rowsAffect;
        }
    }
}
