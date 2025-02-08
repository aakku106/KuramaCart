using System;
using System.Linq;
using Microsoft.AspNetCore.Components;
using OnlineStore.Data;
using OnlineStore.Models;

namespace OnlineStore.Components.Pages
{
    public partial class Beauty
    {
        private Product? selectedProduct;

        private void SelectProduct(Product product)
        {
            selectedProduct = product;
        }
    }
}