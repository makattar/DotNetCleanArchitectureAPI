using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Dto.Product
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
    }
}
