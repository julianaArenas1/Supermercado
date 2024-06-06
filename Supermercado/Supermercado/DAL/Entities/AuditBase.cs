﻿using System.ComponentModel.DataAnnotations;

namespace Supermercado.DAL.Entities
{
    public class AuditBase
    {
        [Key]
        public virtual Guid Id { get; set; } 
        public virtual DateTime CreatedDate { get; set; } 
        public virtual DateTime ModifiedDate { get; set; } 
    }
}
