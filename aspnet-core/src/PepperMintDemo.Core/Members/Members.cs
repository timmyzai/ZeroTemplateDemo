using PepperMintDemo.Authorization.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace PepperMintDemo.Members
{
    [Table("Members")]
    public class Members : AuditedEntity<Guid>
    {

        [Required]
        [StringLength(MembersConsts.MaxNameLength, MinimumLength = MembersConsts.MinNameLength)]
        public virtual string Name { get; set; }

        public virtual long UserId { get; set; }

        [ForeignKey("UserId")]
        public User UserFk { get; set; }

    }
}