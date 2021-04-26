using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using MySqlConnector;

namespace MISA.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool CheckCustomerCodeExist(string customerCode)
        {
            var dbstringConnection = "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "Database = MF0_NVManh_CukCuk02;" +
                "User Id = dev;" +
                "Password = 12345678;" +
                "AllowZeroDateTime=True"
                ;
            IDbConnection dbConnection = new MySqlConnection(dbstringConnection);
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@m_CustomerCode", customerCode);
            var customerCodeExist = dbConnection.QueryFirstOrDefault<bool>("Proc_CheckCustomerCodeExists", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return customerCodeExist;
        }

        public bool CheckPhoneNumberExist(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid customerId)
        {
            var dbstringConnection = "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "Database = MF0_NVManh_CukCuk02;" +
                "User Id = dev;" +
                "Password = 12345678;" +
                "AllowZeroDateTime=True"
                ;
            IDbConnection dbConnection = new MySqlConnection(dbstringConnection);
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerId", customerId);
            var customers = dbConnection.Execute("Proc_DeleteCustomer",
                param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return customers;
        }

        public IEnumerable<Customer> GetAll()
        {
            string connectString = "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "Database = MF0_NVManh_CukCuk02;" +
                "User Id = dev;" +
                "Password = 12345678;" +
                "AllowZeroDateTime=True"
                ;
            IDbConnection dbConnection = new MySqlConnection(connectString);
            var customers = dbConnection.Query<Customer>("SELECT * FROM Customer");
            return customers;
        }

        public Customer GetById(Guid customerId)
        {
            string connectString = "Host = 47.241.69.179;" +
               "Port = 3306;" +
               "Database = MF0_NVManh_CukCuk02;" +
               "User Id = dev;" +
               "Password = 12345678;" +
               "AllowZeroDateTime=True";
            IDbConnection dbConnection = new MySqlConnection(connectString);

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerId", customerId);
            var customer = dbConnection.QueryFirstOrDefault<Customer>("Proc_GetCustomerById",
                param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return customer;
        }

        public int Insert(Customer customer)
        {
            var connectString = "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "Database = MF0_NVManh_CukCuk02;" +
                "User Id = dev;" +
                "Password = 12345678;" +
                "AllowZeroDateTime=True";
            IDbConnection dbConnection = new MySqlConnection(connectString);
            var rowsAffect = dbConnection.Execute("Proc_InsertCustomer",
                param: customer, commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }

        public int Update(Customer customer)
        {
            var dbStringConnection = "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "Database = MF0_NVManh_CukCuk02;" +
                "User Id = dev;" +
                "Password = 12345678;" +
                "AllowZeroDateTime=True";
            IDbConnection dbConnection = new MySqlConnection(dbStringConnection);

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerId", customer.CustomerId);
            dynamicParameters.Add("@CustomerCode", customer.CustomerCode);
            dynamicParameters.Add("@FullName", customer.FullName);
            dynamicParameters.Add("@MemberCardCode", customer.MemberCardCode);

            dynamicParameters.Add("@CustomerGroupId", customer.CustomerGroupId);
            dynamicParameters.Add("@DateOfBirth", customer.DateOfBirth);
            dynamicParameters.Add("@Gender", customer.Gender);
            dynamicParameters.Add("@Email", customer.Email);
            dynamicParameters.Add("@PhoneNumber", customer.PhoneNumber);
            dynamicParameters.Add("@CompanyName", customer.CompanyName);
            dynamicParameters.Add("@CompanyTaxCode", customer.CompanyTaxCode);
            dynamicParameters.Add("@Address", customer.Address);



            // Update data 

            var updateCustomer = dbConnection.Execute("Proc_UpdateCustomer", dynamicParameters, commandType: CommandType.StoredProcedure);
            return updateCustomer;
        }
    }
}
