﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProShop.Web.Models
{
    public class PostCategoryViewModel
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Alias { set; get; }
        public string Description { set; get; }
        public int? ParentID { set; get; }
        public int? DisplayOrder { set; get; }
        public string Image { set; get; }
        public bool? HomeFlag { set; get; }
        public virtual IEnumerable<PostViewModel> Posts { set; get; }

        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public bool Status { get; set; }
    }
}