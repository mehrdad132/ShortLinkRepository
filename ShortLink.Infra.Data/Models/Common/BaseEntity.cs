using System.ComponentModel.DataAnnotations;
using System;

namespace ShortLink.Infra.Data.Models.Common
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public bool IsDelete { get; set; }
    }
}
