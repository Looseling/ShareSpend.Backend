using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpend.Domain.Entities
{
    public class ReceiptStorageModel
    {
        public string ReceiptContainerId { get; set; }
        public string ReceiptId { get; set; }
        public byte[] ReceiptImage { get; set; }
    }
}