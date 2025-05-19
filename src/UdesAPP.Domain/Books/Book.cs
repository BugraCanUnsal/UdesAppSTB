using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace UdesAPP.Books
{
    public class Book : AuditedAggregateRoot<Guid>
    {
        public string Title { get; set; }
        public int Serie { get; set; }
        public int Program { get; set; }
        public int NumberOfPages { get; set; }
        public int NumberOfTopics { get; set; }
        public int NumberOfSentences { get; set; }
        public int NumberOfWords { get; set; }
    }
}
