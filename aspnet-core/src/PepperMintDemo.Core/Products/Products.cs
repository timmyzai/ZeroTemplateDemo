using PepperMintDemo.Common.Dto;
using PepperMintDemo.Authorization.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace PepperMintDemo.Products
{
    [Table("Products")]
    public class Products : AuditedEntity<Guid>
    {

        [Required]
        [StringLength(ProductsConsts.MaxNameLength, MinimumLength = ProductsConsts.MinNameLength)]
        public virtual string Name { get; set; }

        public virtual ProductType Type { get; set; }

        public virtual long UserId { get; set; }

        [ForeignKey("UserId")]
        public User UserFk { get; set; }

    }
}