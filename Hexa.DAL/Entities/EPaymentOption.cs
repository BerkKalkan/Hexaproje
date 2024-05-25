using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexa.DAL.Entities
{
	public enum EPaymentOption
	{
		[Display(Name ="Kredi Karti İle Ödeme")]
		KrediKartı = 1,

		[Display(Name ="Havale ile Ödeme")]
		Havale,

		[Display(Name ="Kapıda Nakit İle ödeme")]
		KapıdaOdeme
	}
}
