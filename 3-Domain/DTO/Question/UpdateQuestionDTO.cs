using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.DTO.Question
{
    public class UpdateQuestionDTO
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public TypeQuestion TypeQuestion { get; set; }
    }
}