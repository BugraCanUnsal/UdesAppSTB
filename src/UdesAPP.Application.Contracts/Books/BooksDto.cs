using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace UdesAPP.Books
{
    public class BooksDto : AuditedEntityDto<Guid>
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
