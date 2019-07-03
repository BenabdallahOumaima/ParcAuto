using System;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Data.Filtering;
using System.Linq;
using DevExpress.ExpressApp;

namespace GestParcAuto.Module.CustomFunctions
{

    public class CurrentUserNameFunction : ICustomFunctionOperatorBrowsable, ICustomFunctionOperatorFormattable,
        ICustomFunctionOperatorQueryable
    {
        const string FunctionName = "CurrentUserName";
        static readonly CurrentUserNameFunction instance = new CurrentUserNameFunction();
        public static void Register()
        {
            CriteriaOperator.RegisterCustomFunction(instance);
        }
        public static bool Unregister()
        {
            return CriteriaOperator.UnregisterCustomFunction(instance);
        }
        #region ICustomFunctionOperatorBrowsable Members
        public FunctionCategory Category
        {
            get { return FunctionCategory.Logical; }
        }
        public string Description
        {
            get { return "Cette fonction retourne le nom de l'utilsateur connecté"; }
        }
        public bool IsValidOperandCount(int count)
        {
            return count >= 0; // At least two operands must be specified. 
        }
        public bool IsValidOperandType(int operandIndex, int operandCount, Type type)
        {
            //return type == typeof(object ); // All operands should be strings. 
            return true; // All operands should be strings. 
        }
        public int MaxOperandCount
        {
            get { return 0; } // Accepts an infinite number of operands. 
        }
        public int MinOperandCount
        {
            get { return 0; } // At least two operands must be specified. 
        }
        #endregion

        #region ICustomFunctionOperator Members
        // Evaluates the function on the client. 
        public object Evaluate(params object[] operands)
        {
            return SecuritySystem.CurrentUserName;
        }

        public string Name
        {
            get { return FunctionName; }
        }
        public Type ResultType(params Type[] operands)
        {
            foreach (Type operand in operands)
            {
                if (operand != typeof(string)) return typeof(object);
            }
            return typeof(string);
        }
        #endregion

        #region ICustomFunctionOperatorFormattable Members
        // The function's expression to be evaluated on the server. 
        public string Format(Type providerType, params string[] operands)
        {
            // This example implements the function for MS Access databases only. 
            if (providerType == typeof(AccessConnectionProvider))
            {
                StringBuilder result = new StringBuilder();
                result.Append("(");
                for (int i = 0; i < operands.Length; i++)
                {
                    if (i > 0) result.Append(" + ");
                    result.AppendFormat("({0})", operands[i]);
                }
                result.Append(")");
                return result.ToString();
            }
            throw new NotSupportedException(providerType.FullName);
        }
        #endregion

        // The method name must match the function name (specified via FunctionName). 
        public static string MyConcat(string string1, string string2, string string3, string string4)
        {
            return (string)instance.Evaluate(string1, string2, string3, string4);
        }

        #region ICustomFunctionOperatorQueryable Members
        public System.Reflection.MethodInfo GetMethodInfo()
        {
            return typeof(CurrentUserNameFunction).GetMethod(FunctionName);
        }
        #endregion
    }
}