using System;
using System.Collections.Generic;
using System.Text;

namespace Thymio_V2
{
    class Condition
    {
        private Dictionary<Operator, string> operatorList;


        private static Condition _instance;
        public static Condition Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Condition();
                return _instance;
            }
        }

        private Condition()
        {
            operatorList = new Dictionary<Operator, string>();
            operatorList.Add(Operator.EQUAL, "==");
            operatorList.Add(Operator.INF, "<");
            operatorList.Add(Operator.SUP, ">");
            operatorList.Add(Operator.SUP_AND_EQUAL, ">=");
            operatorList.Add(Operator.INF_AND_EQUAL, "<=");
            operatorList.Add(Operator.AND, "and");
            operatorList.Add(Operator.OR, "or");
            operatorList.Add(Operator.NOT, "not");
        }

        public string getOperator(Operator op)
        {
            return operatorList[op];
        }


        //public string createCondition(string val1, Operator op, string val2 )
        //{
        //    //getOperator();

        //    return "";
        //}
        //public string createCondition(Properties val1, Operator op, int val2)
        //{
        //    //getOperator();

        //    return "";
        //}
    }
}
