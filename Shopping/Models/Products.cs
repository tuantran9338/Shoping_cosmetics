using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shopping.Models
{
    public class Products
    {
        [Key]
        public int id { get; set; }

        [Required]
        [DisplayName("Sản phẩm")]
        [StringLength(50)]
        public string name { get; set; }

        [Range(0,100000)]
        [DisplayName("Đơn Giá")]
        public double price { get; set; }

        [Range(0, 100000)]
        [DisplayName("Số lượng")]
        public int amount { get; set; }

        [StringLength(500)]
        [DisplayName("Mô tả")]
        public string desrition { get; set; }

        [StringLength(250)]
        [DisplayName("Upload hình ảnh")]
        public string thumbnail { get; set; }

        [Required]
        [DisplayName("Trạng thái")]
        public bool valid { get; set; }

        [ForeignKey("category")]
        [DisplayName("Danh mục")]
        public int cateId { get; set; }

        public Category category { get; set; }

    }
}