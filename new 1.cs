public void Borrow(string membershipID, Material materialID)
{
		using (var unitOfWork = new UnitOfWork(new ActiveLearningContext()))
		{
			var member = unitOfWork.Members.Find(c=> c.MemberID == membershipID ).where(d => d.ExpiryDate > DateTime.now);

			if (member == null)
			{
				return false;
			}
			
			string materalType = unitOfWork.Material.Find(c=> c.MaterialID == materialID ).MaterialType;
			
			if (materalType == "C")
			{
				// Check CD can be loan
				var loandCD = unitOfWork.Copy.Find(c=> c.MaterialID == materialID );
							
				if (loandCD.Status == "S")
				{
					// Can Loan
					
				}
				else
				{	
					return false;
				}
				
				// Find member Loan Limit
				int loanLimit = unitOfWork.MemberType.Find(c=> c.MemberTypeID == member.MemberTypeID ).AVLimit;
												
				
				// Find current loan count
				int currentLoandCount = 0;
				
				var loans = unitOfWork.Loan.Find(c=> c.MemberID == membershipID ).where(d => d.Status == "L");
				foreach (var loan in loans)
				{
					var loandCD = unitOfWork.Copy.Find(c=> c.AccessionNo == loan.AccessionNo).MaterialID;
					
					var loadMaterialType = unitOfWork.Material.Find(c=> c.MaterialID == loandCD.MaterialID).MaterialType;
					
					if (loadMaterialType == "C")
					{
						currentLoandCount++;
					}															
				}
				
				if (loanLimit<currentLoandCount)
				{
					// Can Loan
					Loan loan = new Loan();
					loan.MemberID = member.MemberID;
					loan.AccessionNo = loandCD.AccessionNo;
					loan.DateBorrowed = datetime.now;
					
					 using (TransactionScope scope = new TransactionScope())
                    {
                        unitOfWork.Loans.Add(loan);
                        unitOfWork.Complete();
                        scope.Complete();
                    }				
				}			
			}
			else
			{
				// Check Book can be loan
				var loandBook = unitOfWork.Copy.Find(c=> c.MaterialID == materialID );
							
				if (loandBook.Status != "S")
				{
					// Can Loan
					
				}
				else
				{	
					return false;
				}
				
				// Find member Loan Limit
				var memberLoan = unitOfWork.MemberType.Find(c=> c.MemberTypeID == member.MemberTypeID );
				
				int loanLimit = memberLoan.TotalLimit - memberLoan.AVLimit;										
				
				// Find current loan count
				int currentLoandCount = 0;
				
				var loans = unitOfWork.Loan.Find(c=> c.MemberID == membershipID ).where(d => d.Status == "L");
				foreach (var loan in loans)
				{
					var loandCD1 = unitOfWork.Copy.Find(c=> c.AccessionNo == loan.AccessionNo).MaterialID;
					
					var loadMaterialType = unitOfWork.Material.Find(c=> c.MaterialID == loandCD1.MaterialID).MaterialType;
					
					if (loadMaterialType != "C")
					{
						currentLoandCount++;
					}															
				}
				
				if (loanLimit<currentLoandCount)
				{
					// Can Loan
					Loan loan = new Loan();
					loan.MemberID = member.MemberID;
					loan.AccessionNo = loandBook.AccessionNo;
					loan.DateBorrowed = datetime.now;
					
					 using (TransactionScope scope = new TransactionScope())
                    {
                        unitOfWork.Loans.Add(loan);
                        unitOfWork.Complete();
                        scope.Complete();
                    }				
				}			
								
			}								
		}	
}