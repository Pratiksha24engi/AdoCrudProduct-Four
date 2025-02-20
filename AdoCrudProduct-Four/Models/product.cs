using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdoCrudProduct_Four.Models
{
    public class product
    {
        public int productId { get; set; }
        public string productName {  get; set; }
        public float rate {  get; set; }
        public float tax {  get; set; }
        public int stockQuantity {  get; set; }
    }
}