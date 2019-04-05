using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Shopping.Models
{
    public class CartItem
    {
        public Products product { get; set; }
        public int quantity { get; set; }

        public CartItem()
        {

        }

        public CartItem(Products products, int quantity)
        {
            this.product = product;
            this.quantity = quantity;
        }

        public double totalprice { get => product.price * quantity; }
    }
}