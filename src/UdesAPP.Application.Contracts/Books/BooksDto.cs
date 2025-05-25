using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using JetBrains.Annotations;
using Volo.Abp.Application.Dtos;

namespace UdesAPP.Books
{
    public class BooksDto : AuditedEntityDto<Guid>
    {
        [Required(ErrorMessage = "Kitap adı zorunludur.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Seri seçimi zorunludur.")]
        public int? Serie { get; set; }
        [Required(ErrorMessage = "Eğitim programı seçimi zorunludur.")]
        public int? Program { get; set; }
        public int NumberOfPages { get; set; }
        public int NumberOfTopics { get; set; }
        public int NumberOfSentences { get; set; }
        public int NumberOfWords { get; set; }
    }
}