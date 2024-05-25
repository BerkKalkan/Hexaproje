using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexa.DAL.Entities
{
	public class Admin
	{
        public int ID {get; set; }

		[Column(TypeName = "varchar(20)"), StringLength(20), Display(Name = "Kullanıcı Adı"),Required(ErrorMessage ="kullanıcı adı boş geçilemez")]
		public string UserName {get; set; }

		[Column(TypeName = "varchar(32)"), StringLength(32), Display(Name = "Şifre"),Required(ErrorMessage ="Şifre Boş bırakılamaz")]
		public string Password { get; set; }

		[Column(TypeName = "varchar(50)"), StringLength(50), Display(Name = "Admin Adı"),Required(ErrorMessage ="Ad Soyad Boş Kalamaz")]
		public string NameSurname { get; set; }

		[Display(Name ="Son Giriş Tarihi")]
        public DateTime LastLoginDate { get; set; }

		[Column(TypeName = "varchar(20)"), StringLength(20), Display(Name = "Son Girilen IP")]
		public string LastLoginIP { get; set; }
    }
}
