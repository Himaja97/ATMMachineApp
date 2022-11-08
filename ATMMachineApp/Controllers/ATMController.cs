using ATMMachineApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using static ATMMachineApp.CommonEnums;

namespace ATMMachineApp.Controllers
{
	public class ATMController : ApiController
	{
		public void GetResultantDenominations(int accountId, int amount)
		{
			try
			{
				if (VerifyAccountBalance(accountId, amount))
				{
					GetResultantNotes(accountId, amount);
				}
			}
			catch (Exception)
			{

				throw;
			}

		}

		public bool VerifyAccountBalance(int accountId, int amount)
		{
			try
			{
				//fetch  balance amount from user's account
				var accountDetails = accountDetails.FirstOrDefault(x => x.AccountId == accountId);
				if (accountDetails == null)
				{
					// custom error as invalid account
					throw new Exception("invalid account");
				}
				if (accountDetails.BalanceAmount > amount)
					return true;
				else
					return false;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public void GetResultantNotes(int accountId, int amount)
		{
			//fetch  balance amount from user's account from DB //resultant set of multi tables
			var accountDetails = new List<AccountDetails>()
			{
				new AccountDetails()
				{
					AccountId=1,
				AccountHolderType = 1,
				AccountType = 1,
				BalanceAmount = 4000,
				TransactionDate = DateTime.UtcNow.Date.AddDays(-2)
				},

				new AccountDetails()
				{
						AccountId=1,
				AccountHolderType = 1,
				AccountType = 1,
				BalanceAmount = 4000,
				TransactionDate = DateTime.UtcNow.Date.AddDays(-35)
				},

			};
			var currentAccDetails = accountDetails.Where(x => x.AccountId == accountId).ToList();
			if (currentAccDetails == null && currentAccDetails.Count == 0)
			{
				// custom error as invalid account
				throw new Exception("invalid account");
			}
			if (currentAccDetails.FirstOrDefault().AccountType == (int)AccountTypes.Savings && currentAccDetails.FirstOrDefault().AccountHolderType == (int)AccountHolderTypes.Individual)
			{
				var currentMonthWithdrawls = currentAccDetails.Where(x => x.TransactionDate months == DateTime.UtcNow.Month && x.TransactionType == TransactionType.WithDrawl);
				if (currentMonthWithdrawls > 3)
				{
					amount = amount - 100;
				}
			}

			int[] currencyNotes = new int[] { 2000, 500, 200, 100, 50, 20, 10, 5 };
			int[] requiredNotes = new int[8];

			for (int i = 0; i < currencyNotes.Length; i++)
			{
				if (amount > currencyNotes[i])
				{
					requiredNotes[i] = amount / currencyNotes[i];
					amount = amount % currencyNotes[i];
				}
			}

			for (int i = 0; i < currencyNotes.Length; i++)
			{
				if (requiredNotes[i] > 0)
				{
					Console.WriteLine($"{currencyNotes[i]} - {requiredNotes[i]} note(s)");
				}
			}
		}

		/// <summary>
		/// Tried using Dictionary
		/// </summary>
		/// <param name="accountId"></param>
		/// <param name="amount"></param>
		public void GetResultantNotes1(int accountId, int amount)
		{

			Dictionary<string, int> currencyNotes = new Dictionary<string, int> {
				{ "2000",0 },
				{"500", 0},
				{"200", 0},
				{"100", 0},
				{"50" , 0},
				{"20" , 0},
				{"10" , 0},
				{" 5" , 0}
			};

			//int[] requiredNotes = new int[8];

			for (int i = 0; i < currencyNotes.Keys.Count; i++)
			{
				if (amount > currencyNotes.Keys[i])
				{
					currencyNotes.Values[i] += amount / currencyNotes[i];
					amount = amount % currencyNotes[i];
				}
			}



		}
	}
}