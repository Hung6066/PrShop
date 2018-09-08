using AutoMapper;
using BotDetect.Web.Mvc;
using ProShop.Service;
using ProShop.Web.Infrastructure.Extensions;
using ProShop.Web.Models;
using PrShop.Common;
using PrShop.Model.Models;
using System.Text;
using System.Web.Mvc;

namespace ProShop.Web.Controllers
{
    public class ContactController : Controller
    {
        private IContactDetailService _contactDetailService;
        private IFeedbackService _feedbackService;
        public ContactController(IContactDetailService contactDetailService, IFeedbackService feedbackService)
        {
            _contactDetailService = contactDetailService;
            _feedbackService = feedbackService;
        }

        // GET: Contact
        public ActionResult Index()
        {
            
            FeedbackViewModel viewModel = new FeedbackViewModel();
            viewModel.ContactDetail = GetDetail();
            return View(viewModel);
        }
        [HttpPost]
        [CaptchaValidation("CaptchaCode","ContactCaptcha","Mã xác nhận không đúng!")]
        public ActionResult SendFeedback(FeedbackViewModel feedbackViewModel)
        {
            if (ModelState.IsValid)
            {
                Feedback newFeedback = new Feedback();
                newFeedback.UpdateFeedback(feedbackViewModel);
                _feedbackService.Create(newFeedback);
                _feedbackService.Save();

                ViewData["SuccessMsg"] = "Gửi phản hồi thành công";
                

                string content = System.IO.File.ReadAllText(Server.MapPath("/Assets/client/template/contact_template.html"));
                content = content.Replace("{{Name}}", feedbackViewModel.Name);
                content = content.Replace("{{Email}}", feedbackViewModel.Email);
                content = content.Replace("{{Message}}", feedbackViewModel.Message);
                var adminEmail = ConfigHelper.GetByKey("AdminEmail");

                MainHelper.SendMail(adminEmail, "Thông tin liên hệ từ website",content);

                feedbackViewModel.Name = "";
                feedbackViewModel.Email = "";
                feedbackViewModel.Message = "";

            }

            feedbackViewModel.ContactDetail = GetDetail();
            
            return View("Index", feedbackViewModel);
           
        }
        private ContactDetailViewModel GetDetail()
        {
            var model = _contactDetailService.GetDefaultContact();
            var contactDetailViewModel = Mapper.Map<ContactDetail, ContactDetailViewModel>(model);
            return contactDetailViewModel;
        }
        
    }
}