using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System.Runtime.InteropServices;

namespace ExQuizIt.Models
{
	public class User : IdentityUser
	{
		[MaxLength(25)]
		public string Displayname { get; set; }
	}
}
