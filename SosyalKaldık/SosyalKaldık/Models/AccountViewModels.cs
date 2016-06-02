using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SosyalKaldık.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        int a = 0;
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
    public class Etklinlikler
    {
       public List<kategoriler> etkList = new List<kategoriler>();
    }
    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class EtkinlikModel
    {
        public EtkinlikModel()
        {
            this.Kategoriler= new List<SelectListItem>();
            Kategoriler.Add(new SelectListItem { Text = "Seçiniz", Value = "" });
        }
        
        public int ETK_ID { get; set; }
        [Display(Name = "Başlık")]
        public string ETK_BASLIK { get; set; }
        [Display(Name = "Açıklama")]
        public string ETK_ACIKLAMA { get; set; }
        [Display(Name = "Şehir")]
        public string ETK_SEHIR { get; set; }
        [Display(Name = "İlçe")]
        public string ETK_ILCE { get; set; }
        [Display(Name = "Tarih - Saat")]
        public System.DateTime ETK_TARIH_SAAT { get; set; }
        public int KUL_ID { get; set; }
        public string Tel { get; set; }
        public int KAT_ID { get; set; }
        [Display(Name ="Kategori")]
        public List<SelectListItem> Kategoriler = new List<SelectListItem>();
        public List<ETKINLIK> etkinlikList = new List<ETKINLIK>();
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

 

        public class RegisterViewModel
    {
        [Required]
        
        [Display(Name = "Adı")]
        public string Adı { get; set; }

        [Required]
        
        [Display(Name = "Soyadı")]
        public string Soyadı { get; set; }

        [Required]
        
        [Display(Name = "Telefon No")]
        public string Tel { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
