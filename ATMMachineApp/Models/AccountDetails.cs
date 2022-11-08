using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATMMachineApp.Models
{
	public class AccountDetails
	{
		public int AccountId { get; set; }
		public int AccountType { get; set; }
		public int AccountHolderType { get; set; }
		public double BalanceAmount { get; set; }
		public DateTime TransactionDate { get; set; }
		public int TransactionType { get; set; }
	}
}