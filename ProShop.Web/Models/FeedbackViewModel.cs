using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProShop.Web.Models
{
    public class FeedbackViewModel
    {
        public int ID { get; set; }
        [MaxLength(250, ErrorMessage ="Tên không được quá 250 ký tự")]
        [Required(ErrorMessage ="Tên phải nhập")]
        public string Name { get; set; }
        [MaxLength(250, ErrorMessage = "Email không được quá 250 ký tự")]
        public string Email { get; set; }
        [MaxLength(250, ErrorMessage = "Tin nhắn không được quá 500 ký tự")]
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required(ErrorMessage ="Phải nhập trạng thái")]
        public bool Status { get; set; }
        public ContactDetailViewModel ContactDetail { get; set; }
    
    }
}