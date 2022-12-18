﻿using IB.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IB.Domain.Entities
{
    public partial class Transaction : BaseEntity<int>, IAuditEntity
    {
        public override int? Id => base.Id;
        public int TransactionTypeId { get; set; }
        public int AccountId { get; set; }
        public double Amount { get; set; }
        public DateTime? Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedByUser { get; set; }

        public virtual TransactionType TransactionType { get; set; }
        public virtual Account Account { get; set; }
        public Transaction()
        {
            this.CreatedAt = DateTime.Now;
        }
    }
}