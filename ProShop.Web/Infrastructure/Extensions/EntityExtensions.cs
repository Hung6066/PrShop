using ProShop.Web.Models;
using PrShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProShop.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryVm)
            {
                postCategory.ID = postCategoryVm.ID;
                postCategory.Name = postCategoryVm.Name;
                postCategory.Description = postCategoryVm.Description;
                postCategory.Alias = postCategoryVm.Alias;
                postCategory.ParentID = postCategoryVm.ParentID;
                postCategory.DisplayOrder = postCategoryVm.DisplayOrder;
                postCategory.Image = postCategoryVm.Image;
                postCategory.HomeFlag = postCategoryVm.HomeFlag;

                postCategory.CreateDate = postCategoryVm.CreateDate;
                postCategory.CreateBy = postCategoryVm.CreateBy;
                postCategory.UpdateDate = postCategoryVm.UpdateDate;
                postCategory.UpdateBy = postCategoryVm.UpdateBy;
                postCategory.MetaKeyword = postCategoryVm.MetaKeyword;
                postCategory.MetaDescription = postCategoryVm.MetaDescription;
                postCategory.Status = postCategoryVm.Status;

        }
        public static void UpdatePost(this Post post, PostViewModel postVm)
        {
            post.ID = postVm.ID;
            post.Name = postVm.Name;
            post.Description = postVm.Description;
            post.Alias = postVm.Alias;
            post.CategoryID = postVm.CategoryID;
            post.Content = postVm.Content;
            post.Image = postVm.Image;
            post.HomeFlag = postVm.HomeFlag;
            post.ViewCount = postVm.ViewCount;

            post.CreateDate = postVm.CreateDate;
            post.CreateBy = postVm.CreateBy;
            post.UpdateDate = postVm.UpdateDate;
            post.UpdateBy = postVm.UpdateBy;
            post.MetaKeyword = postVm.MetaKeyword;
            post.MetaDescription = postVm.MetaDescription;
            post.Status = postVm.Status;
           

        }

    }
}