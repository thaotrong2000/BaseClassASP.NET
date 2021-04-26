using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Repository
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: NTThao (21/04/2021)
        public IEnumerable<Customer> GetAll();
        public Customer GetById(Guid customerId);
        public int Insert(Customer customer);
        public int Update(Customer customer);
        public int Delete(Guid customerId);
        public bool CheckCustomerCodeExist(string customerCode);
        public bool CheckPhoneNumberExist(string phoneNumber);
    }
}
