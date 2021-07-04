using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
	[Table("tblEmployee")]
	public class Employee
	{
		
		public int EmployeeID { get; set; }
		public string Name { get; set; }
		public string Gender { get; set; }
	}
}