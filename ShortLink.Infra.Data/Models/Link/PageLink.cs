using ShortLink.Infra.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.Infra.Data.Models.Link
{
    public class PageLink: BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortKey { get; set; }
        public DateTime CreateDate { get; set; }
        public int CountView { get; set; }  
    }
}
