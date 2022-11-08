using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATMMachineApp
{
	public class CommonEnums
	{
		public enum AccountHolderTypes
		{
			Individual,
			Business
		}
		public enum AccountTypes
		{
			Savings,
			Checking
		}
		public enum TransactionType
		{
			WithDrawl			
		}
	}
}