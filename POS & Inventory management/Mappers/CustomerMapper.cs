using POS___Inventory_management.Dtos.CustomerDtos;
using POS___Inventory_management.Entities;

namespace POS___Inventory_management.Mappers
{
    public static class CustomerMapper
    {
        public static CustomerDto ToCustomerDto(this Customer entity)
        {
            return new CustomerDto
            {
                Name = entity.Name,
                PhoneNo = entity.PhoneNo,
                Address = entity.Address,
                Email = entity.Email,
            };
        }

        public static Customer ToCustomerFromCreateDto(this CreateCustomerDto customerDto)
        {
            return new Customer
            {
                Name = customerDto.Name,
                PhoneNo = customerDto.PhoneNo,
                Address = customerDto.Address,
                Email = customerDto.Email,
            };
        }
    }
}
