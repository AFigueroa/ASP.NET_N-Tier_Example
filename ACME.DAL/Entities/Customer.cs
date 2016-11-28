using System.Collections.Generic;
using ACME.Common.Interfaces;


namespace ACME.DAL
{
    public class Customer : EntityBase, ILoggable
    {
        // A constructor without paramaters is called default constructor
        public Customer()
            :this(0) // Chaining: a constructor calls on a another constructor
        {
            // No need to have defualt constructors if the logic is empty
            // If no default constructor is defined the compilation will create one
        }

        public Customer(int customerId)
        {
            // This referances the class
            this.CustomerId = customerId;

            // Initialize the address list
            AddressList = new List<Address>();
        }

        public int CustomerType { get; set; }
        // Using static were able to declare members that belong to the class itself and not to instances of those classes.
        public static int InstanceCount { get; set; }
        
        // Verbose definition of a class property
        private string _lastName;
        public string LastName
        {
            get
            {
                // Any logic here
                return _lastName;
            }
            set
            {
                // Example logic: verify the user is allowed to update _lastName
                _lastName = value;
            }
        }

        // Auto-implemented: When you don't need logic within getter or setter
        public string FirstName { get; set; }

        public string EmailAddress { get; set; }
        public List<Address> AddressList { get; set; }

        // The class can set this property but any external resource cannot
        public int CustomerId { get; private set; }

        public string FullName {
            get
            {
                string fullName = LastName;

                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(fullName))
                    {
                        fullName += ", ";
                    }
                    fullName += FirstName;
                }

                return fullName;
            }
        }

        /// <summary>
        /// Validates that required fields are correct
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(LastName)) isValid = false;
            if (string.IsNullOrWhiteSpace(EmailAddress)) isValid = false;

            return isValid;
        }

        // Overriding base class's methods
        public override string ToString()
        {
            return FullName;
        }

        public string Log()
        {
            var logString = this.CustomerId + ": " +
                this.FullName + " " +
                "Email: " + this.EmailAddress + " " +
                "Status: " + this.EntitySate.ToString();

            return logString;
        }
    }
}
